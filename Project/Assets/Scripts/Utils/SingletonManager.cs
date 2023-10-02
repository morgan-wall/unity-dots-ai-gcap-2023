// Copyright (c) 2023 Morgan Wall. All rights reserved.

using UnityEngine;

namespace Utils
{
    public class SingletonManager : MonoBehaviour
    {
        [SerializeField]
        private ScriptableObject[] _singletons = new ScriptableObject[]{};
    }
}
