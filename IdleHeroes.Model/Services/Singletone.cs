using System;
using System.Collections.Generic;
using System.Text;

namespace IdleHeroes.Model.Services
{
    public abstract class Singletone<T> where T:new()
    {
        private static object locker = new object();

        public static T Instance 
        { 
            get
            {
                lock(locker)
                {
                    if (_instance == null)
                        _instance = new T();
                    return _instance;
                }                
            }
        }
        private static T _instance;
    }
}
