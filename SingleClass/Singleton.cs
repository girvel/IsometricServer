﻿using System;
using System.Reflection;

namespace SingleClass
{
    public abstract class Singleton<T> where T : new()
    {
        private static T _instance;
        public static T Instance {
            get {
                if (_instance == null)
                {
                    _instance = new T();
                }

                return _instance;
            }
        }
    }
}

