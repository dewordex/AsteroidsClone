using System;

namespace CustomEcs.Systems
{
    [AttributeUsage(AttributeTargets.Field)]
    public class IgnoreInjectAttribute : Attribute
    {
    }
}