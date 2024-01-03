namespace TailwindMerge.Interfaces
{
    public interface ITailwindMergePlugin
    {
        TailwindMergeConfig Invoke(TailwindMergeConfig config);
    }
}
