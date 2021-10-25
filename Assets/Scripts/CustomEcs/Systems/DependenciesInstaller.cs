using System;
using System.Collections.Generic;
using System.Reflection;
using CustomEcs.Groups;
using UnityEngine;

namespace CustomEcs.Systems
{
    public class DependenciesInstaller
    {
        public void InstallDependencies(IEcsSystem system, EcsWorld world, IReadOnlyDictionary<Type, object> dependencies)
        {
            var fields = system.GetType().GetFields(
                BindingFlags.NonPublic |
                BindingFlags.Instance);

            foreach (var fieldInfo in fields)
            {
                if (TryInstallGroup(system, world, fieldInfo)) continue;
                if (TryInstallEcsWorld(system, world, fieldInfo)) continue;
                InstallOther(system, fieldInfo, dependencies);
            }
        }

        private bool TryInstallGroup(IEcsSystem system, EcsWorld world, FieldInfo fieldInfo)
        {
            if (typeof(IGroup).IsAssignableFrom(fieldInfo.FieldType))
            {
                var instance = Activator.CreateInstance(fieldInfo.FieldType, world);
                fieldInfo.SetValue(system, instance);
                return true;
            }

            return false;
        }

        private bool TryInstallEcsWorld(IEcsSystem system, EcsWorld world, FieldInfo fieldInfo)
        {
            if (fieldInfo.FieldType.IsAssignableFrom(typeof(EcsWorld)))
            {
                fieldInfo.SetValue(system, world);
                return true;
            }

            return false;
        }

        private void InstallOther(IEcsSystem system, FieldInfo fieldInfo, IReadOnlyDictionary<Type, object> dependencies)
        {
            if (Attribute.IsDefined(fieldInfo, typeof(IgnoreInjectAttribute)) == false)
            {
                var type = fieldInfo.FieldType;
                if (dependencies.TryGetValue(type, out var dependency))
                {
                    fieldInfo.SetValue(system, dependency);
                }
                else
                {
#if UNITY_EDITOR
                    Debug.LogError($"Failed to install dependencies. For the [{system.GetType()}] no instance found [{type}]");
#endif
                }
            }
        }
    }
}