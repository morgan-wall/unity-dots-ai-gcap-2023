// Copyright (c) 2023 Morgan Wall. All rights reserved.

using System;
using UnityEngine;
using Utils;

namespace AI.Options
{
    [Serializable]
    [CreateAssetMenu(fileName = "OptionRegistry", menuName = "Options/Option Registry")]
    public sealed class OptionRegistry : ScriptableObjectRegistry<OptionConfig>
    {
    }
}
