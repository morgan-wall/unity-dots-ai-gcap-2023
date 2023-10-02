// Copyright (c) 2023 Morgan Wall. All rights reserved.

using System;
using UnityEditor;
using UnityEngine;

namespace AI.UtilitySystems.Considerations.Normalization.Editor
{
    [CustomPropertyDrawer(typeof(NormalizerConfig))]
    public class NormalizerConfigDrawer : PropertyDrawer
    {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {   
            EditorGUI.BeginProperty(position, label, property);
            
            var normalizerProperty = property.FindPropertyRelative("Normalizer");
            EditorGUI.PropertyField(position, normalizerProperty, true);
            
            var normalizer = (Normalizer)normalizerProperty.intValue;
            switch (normalizer)
            {
                case Normalizer.Bounded:
                    SerializedProperty boundedNormalizerProperty = property.FindPropertyRelative("BoundedNormalizerConfig");
                    Rect normalizerPosition = new Rect(position.x, position.y + EditorGUIUtility.singleLineHeight,
                        position.size.x, EditorGUI.GetPropertyHeight(boundedNormalizerProperty));
                    EditorGUI.PropertyField(normalizerPosition, boundedNormalizerProperty, true);
                    break;
                
                default:
                    throw new NotImplementedException();
            }
            
            EditorGUI.EndProperty();
        }

        public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
        {
            var normalizerProperty = property.FindPropertyRelative("Normalizer");
            SerializedProperty boundedNormalizerProperty = property.FindPropertyRelative("BoundedNormalizerConfig");
            return EditorGUI.GetPropertyHeight(normalizerProperty) + EditorGUI.GetPropertyHeight(boundedNormalizerProperty);
        }
    }
}
