using System;
using System.Collections.Generic;
using TailwindMerge.Models;
using TailwindMerge.Interfaces;
using TailwindMerge.Utilities;

namespace TailwindMerge
{
    public abstract class ClassMapFactory
    {
        private const string CLASS_PART_SEPARATOR = "-";

        public static ClassPart Create(TailwindMergeConfig config)
        {
            ClassPart classMap = new();

            Dictionary<string, List<object>> prefixedClassGroups = GetPrefixedClassGroups(
                config.ClassGroups,
                config.Prefix
            );

            foreach (var (classGroupId, classGroup) in prefixedClassGroups)
            {
                ProcessClassesRecursively(classGroup, classMap, classGroupId, config.Theme);
            }

            return classMap;
        }

        private static void ProcessClassesRecursively(List<object> classGroup, ClassPart classPart, string classGroupId, Dictionary<string, object> theme)
        {
            foreach (var classDefinition in classGroup)
            {
                if (classDefinition is string classDefString)
                {
                    ClassPart classPartToEdit = classDefString == string.Empty ? classPart : GetPart(classPart, classDefString);
                    classPartToEdit.SetClassGroupId(classGroupId);
                    continue;
                }

                if (classDefinition is ThemeGetter themeGetter)
                {
                    Dictionary<string, dynamic> themeResult = themeGetter.Execute(theme);

                    // Convert the themeResult dictionary to a List<object>
                    List<object> themeList = new List<object>();
                    foreach (var kvp in themeResult)
                    {
                        var themeItem = new Dictionary<string, dynamic>
                        {
                            { kvp.Key, kvp.Value }
                        };
                        themeList.Add(themeItem);
                    }

                    ProcessClassesRecursively(
                        themeList,
                        classPart,
                        classGroupId,
                        theme
                    );
                    continue;
}

                if (classDefinition is IRule ruleInterface)
                {
                    classPart.Validators.Add(new ClassValidator(classGroupId, ruleInterface));
                    continue;
                }

                if (classDefinition is Dictionary<string, object> classDefDict)
                {
                    foreach (var (key, value) in classDefDict)
                    {
                        ProcessClassesRecursively(
                            (List<object>)value,
                            GetPart(classPart, key),
                            classGroupId,
                            theme
                        );
                    }
                }
            }
        }

        private static ClassPart GetPart(ClassPart classPart, string path)
        {
            ClassPart currentClassPartObject = classPart;

            foreach (string pathPart in path.Split(CLASS_PART_SEPARATOR))
            {
                if (!currentClassPartObject.NextPart.ContainsKey(pathPart))
                {
                    currentClassPartObject.NextPart[pathPart] = new ClassPart();
                }

                currentClassPartObject = currentClassPartObject.NextPart[pathPart];
            }

            return currentClassPartObject;
        }

        private static Dictionary<string, List<object>> GetPrefixedClassGroups(Dictionary<string, List<object>> classGroups, string prefix)
        {
            if (string.IsNullOrEmpty(prefix))
            {
                return classGroups;
            }

            Dictionary<string, List<object>> output = new();

            foreach (var (classGroupId, classGroup) in classGroups)
            {
                output[classGroupId] = classGroup.ConvertAll(classDefinition =>
                {
                    if (classDefinition is string classDefString)
                    {
                        return prefix + classDefString;
                    }

                    if (classDefinition is Dictionary<string, object> classDefDict)
                    {
                        Dictionary<string, object> prefixedClassDefinition = new();
                        foreach (var (key, value) in classDefDict)
                        {
                            prefixedClassDefinition[prefix + key] = value;
                        }
                        return prefixedClassDefinition;
                    }

                    return classDefinition;
                });
            }

            return output;
        }
    }
}
