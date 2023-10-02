// Copyright (c) 2023 Morgan Wall. All rights reserved.

using System;
using System.Collections.Generic;
using UnityEngine;

namespace Utils
{
    [Serializable]
    public abstract class ScriptableObjectRegistry<T> : ScriptableObject where T : ScriptableObject
    {
        [SerializeField]
        private T[] _registrants = new T[]{};

        private int[] _keys = new int[]{};
        private Dictionary<int, T> _registrantForKey = new Dictionary<int, T>();
        private Dictionary<T, int> _keyForRegistrant = new Dictionary<T, int>();

        private static ScriptableObjectRegistry<T> _instance = null; 
        public static ScriptableObjectRegistry<T> Instance
        {
            get
            {
                if (_instance == null)
                {
                    var foundObjects = Resources.FindObjectsOfTypeAll<ScriptableObjectRegistry<T>>();
                    _instance = foundObjects.Length > 0 ? foundObjects[0] : null;
                }
                return _instance;
            }
        }
        
        public T[] Registrants
        {
            get { return _registrants; }
        }

        public int[] Keys
        {
            get { return _keys; }
        }

        private void Awake()
        {
            _instance = this;
        }

        private void OnEnable()
        {
            _keys = new int[Registrants.Length];
            for (int i = 0; i < Registrants.Length; ++i)
            {
                _keys[i] = i;
                _registrantForKey.Add(i, Registrants[i]);
                _keyForRegistrant.Add(Registrants[i], i);
            }
        }

        public bool TryGetKey(T registrant, out int key)
        {
            return _keyForRegistrant.TryGetValue(registrant, out key);
        }

        public bool TryGetRegistrant(int key, out T registrant)
        {
            return _registrantForKey.TryGetValue(key, out registrant);
        }
    }
}
