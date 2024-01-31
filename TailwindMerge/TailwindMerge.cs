using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using TailwindMerge.Utilities;
using TailwindMerge.Models;
using TailwindMerge.Interfaces;

namespace TailwindMerge
{
    public class TailwindMerge
    {
        private const string SplitClassesRegex = @"\s+";
        private const string ImportantModifier = "!";

        private LruCache _cache;
        private ClassUtils _classUtils;
        private TailwindMergeConfig _config;
        private static TailwindMerge _instance;

        public TailwindMerge(TailwindMergeConfig config = null)
        {
            _config = config ?? TailwindMergeConfig.Default();
            _classUtils = new ClassUtils(_config);
            _cache = new LruCache(_config.CacheSizeValue);
        }

        public string Merge(params object[] classList)
        {
            string joinedClassList = Join(classList);

            //string? cachedResult = _cache.Get(joinedClassList);
            //if (cachedResult != null)
            //{
            //    return cachedResult;
            //}

            string result = MergeClassList(joinedClassList);
            _cache.Set(joinedClassList, result);

            return result;
        }

        public TailwindMerge Extend(params Func<TailwindMergeConfig, TailwindMergeConfig>[] plugins)
        {
            foreach (var plugin in plugins)
            {
                _config = plugin(_config);
            }

            _classUtils = new ClassUtils(_config);
            _cache = new LruCache(_config.CacheSizeValue);

            return this;
        }

        public static TailwindMerge Instance()
        {
            return _instance ??= new TailwindMerge();
        }

        private string MergeClassList(string classList)
        {
            var classes = Regex.Split(classList.Trim(), SplitClassesRegex)
                               .Select(DetermineClassContext)
                               .ToArray();

            classes = FilterConflictingClasses(classes).ToArray();

            return string.Join(" ", classes.Select(c => c.OriginalClassName));
        }

        private string Join(params object[] classList)
        {
            return string.Join(" ", classList.SelectMany(item =>
            {
                return item switch
                {
                    string str => new[] { str },
                    IDictionary<string, bool> dict => dict.Where(pair => pair.Value).Select(pair => pair.Key),
                    _ => Enumerable.Empty<string>()
                };
            }));
        }

        private ClassContext DetermineClassContext(string originalClassName)
        {
            var modifiersContext = _classUtils.SplitModifiers(originalClassName);
            var classGroupId = _classUtils.GetClassGroupId(modifiersContext.BaseClassName);
            var hasPostfixModifier = modifiersContext.MaybePostfixModifierPosition.HasValue;

            if (string.IsNullOrEmpty(classGroupId))
            {
                if (!modifiersContext.MaybePostfixModifierPosition.HasValue)
                {
                    return new ClassContext(false, originalClassName);
                }

                classGroupId = _classUtils.GetClassGroupId(modifiersContext.BaseClassName);
                if (string.IsNullOrEmpty(classGroupId))
                {
                    return new ClassContext(false, originalClassName);
                }

                hasPostfixModifier = false;
            }

            var variantModifier = string.Join(":", _classUtils.SortModifiers(modifiersContext.Modifiers));
            var modifierId = modifiersContext.HasImportantModifier
                             ? variantModifier + ImportantModifier
                             : variantModifier;

            return new ClassContext(
                true,
                originalClassName,
                hasPostfixModifier,
                modifierId,
                classGroupId
            );
        }

        private IEnumerable<ClassContext> FilterConflictingClasses(ClassContext[] classes)
        {
            var classGroupsInConflict = new HashSet<string>();

            foreach (var context in classes)
            {
                if (!context.IsTailwindClass)
                {
                    yield return context;
                    continue;
                }

                var classId = context.ModifierId + context.ClassGroupId;
                if (classGroupsInConflict.Contains(classId))
                {
                    continue;
                }

                classGroupsInConflict.Add(classId);

                var conflicts = _classUtils.GetConflictingClassGroupIds(context.ClassGroupId, context.HasPostfixModifier);
                foreach (var group in conflicts)
                {
                    classGroupsInConflict.Add(context.ModifierId + group);
                }

                yield return context;
            }
        }
    }
}
