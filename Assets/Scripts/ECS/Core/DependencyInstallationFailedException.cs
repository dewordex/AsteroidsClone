using System;
using System.Runtime.Serialization;
using JetBrains.Annotations;

namespace Leopotam.Ecs
{
    [Serializable]
    public sealed class DependencyInstallationFailedException : Exception
    {
        public string Target { get; }
        public string Dependency { get; }

        public DependencyInstallationFailedException(string target, string dependency) 
            : base($"Failed to install dependencies. For the [{target}] no instance found [{dependency}]")
        {
            Target = target;
            Dependency = dependency;
        }

        private DependencyInstallationFailedException([NotNull] SerializationInfo info, StreamingContext context) : base(info, context) { }
    }
}