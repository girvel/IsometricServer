﻿using System;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
using Isometric.CommonStructures;

namespace Isometric.Editor.Extensions
{
    public static class ResourcesHelper
    {
        public static bool TryParse(this string str, out Resources result)
        {
            result = new Resources();

            if (!Regex.IsMatch(str, @"^ *(\w*: *\d{1,},? *)*(\w*: *\d{1,})? *$"))
            {
                return false;
            }
            
            foreach (var type in typeof(ResourceType).GetEnumNames())
            {
                int resource;
                var resourceParts =
                    Regex.Match(str, type.ToLower() + @": \d*")
                        .ToString()
                        .Split(' ');

                if (resourceParts.Length == 2 && int.TryParse(resourceParts[1], out resource))
                {
                    result.ResourcesArray[(int) (ResourceType) Enum.Parse(typeof(ResourceType), type)] = resource;
                }
            }

            return true;
        }
    }
}