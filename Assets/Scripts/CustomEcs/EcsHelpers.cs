using System.Threading;

namespace CustomEcs
{
    internal static class EcsComponentPool
    {
        internal static int ComponentTypesCount;
    }

    internal static class EcsComponentType<T>
    {
        // ReSharper disable once StaticMemberInGenericType
        public static readonly int TypeIndex;

        static EcsComponentType() => TypeIndex = Interlocked.Increment(ref EcsComponentPool.ComponentTypesCount);
    }
}