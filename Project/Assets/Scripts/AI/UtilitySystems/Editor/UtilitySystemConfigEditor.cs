// Copyright (c) 2023 Morgan Wall. All rights reserved.

using UnityEditor;
using UnityEngine;

namespace AI.UtilitySystems.Editor
{
    [CustomEditor(typeof(UtilitySystemConfig))]
    public class UtilitySystemConfigEditor : UnityEditor.Editor
    {
        // N.B. This custom editor was created to circumvent indentation tweaks for child property drawers.
    }
}
