﻿using System;

namespace Detached.Annotations
{
    [AttributeUsage(AttributeTargets.Property, Inherited = true, AllowMultiple = false)]
    public sealed class MapIgnoreAttribute : Attribute
    {
    }
}