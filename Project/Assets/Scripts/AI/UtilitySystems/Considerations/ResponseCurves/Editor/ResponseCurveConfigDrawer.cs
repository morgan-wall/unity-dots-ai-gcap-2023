// Copyright (c) 2023 Morgan Wall. All rights reserved.

using System;
using UnityEditor;
using UnityEngine;

namespace AI.UtilitySystems.Considerations.ResponseCurves.Editor
{
    [CustomPropertyDrawer(typeof(ResponseCurveConfig))]
    public class ResponseCurveConfigDrawer : PropertyDrawer
    {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {   
            EditorGUI.BeginProperty(position, label, property);
            
            var parentProperty = property.FindPropertyRelative("ResponseCurve");
            EditorGUI.PropertyField(position, parentProperty, true);
            
            var responseCurve = (ResponseCurve)parentProperty.intValue;
            switch (responseCurve)
            {
                case ResponseCurve.Linear:
                {
                    SerializedProperty responseCurveProperty = property.FindPropertyRelative("LinearResponseCurveConfig");
                    Rect responseCurvePosition = new Rect(position.x, position.y + EditorGUIUtility.singleLineHeight,
                        position.size.x, EditorGUI.GetPropertyHeight(responseCurveProperty));
                    EditorGUI.PropertyField(responseCurvePosition, responseCurveProperty, true);
                    break;
                }
                case ResponseCurve.Quadratic:
                {
                    SerializedProperty responseCurveProperty = property.FindPropertyRelative("QuadraticResponseCurveConfig");
                    Rect responseCurvePosition = new Rect(position.x, position.y + EditorGUIUtility.singleLineHeight,
                        position.size.x, EditorGUI.GetPropertyHeight(responseCurveProperty));
                    EditorGUI.PropertyField(responseCurvePosition, responseCurveProperty, true);
                    break;
                }
                case ResponseCurve.Exponential:
                {
                    SerializedProperty responseCurveProperty = property.FindPropertyRelative("ExponentialResponseCurveConfig");
                    Rect responseCurvePosition = new Rect(position.x, position.y + EditorGUIUtility.singleLineHeight,
                        position.size.x, EditorGUI.GetPropertyHeight(responseCurveProperty));
                    EditorGUI.PropertyField(responseCurvePosition, responseCurveProperty, true);
                    break;
                }
                case ResponseCurve.Logistic:
                {
                    SerializedProperty responseCurveProperty = property.FindPropertyRelative("LogisticResponseCurveConfig");
                    Rect responseCurvePosition = new Rect(position.x, position.y + EditorGUIUtility.singleLineHeight,
                        position.size.x, EditorGUI.GetPropertyHeight(responseCurveProperty));
                    EditorGUI.PropertyField(responseCurvePosition, responseCurveProperty, true);
                    break;
                }
                case ResponseCurve.Sine:
                {
                    SerializedProperty responseCurveProperty = property.FindPropertyRelative("SineResponseCurveConfig");
                    Rect responseCurvePosition = new Rect(position.x, position.y + EditorGUIUtility.singleLineHeight,
                        position.size.x, EditorGUI.GetPropertyHeight(responseCurveProperty));
                    EditorGUI.PropertyField(responseCurvePosition, responseCurveProperty, true);
                    break;
                }
                case ResponseCurve.Cosine:
                {
                    SerializedProperty responseCurveProperty = property.FindPropertyRelative("CosineResponseCurveConfig");
                    Rect responseCurvePosition = new Rect(position.x, position.y + EditorGUIUtility.singleLineHeight,
                        position.size.x, EditorGUI.GetPropertyHeight(responseCurveProperty));
                    EditorGUI.PropertyField(responseCurvePosition, responseCurveProperty, true);
                    break;
                }
                
                default:
                    throw new NotImplementedException();
            }
            
            EditorGUI.EndProperty();
        }

        public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
        {
            var parentProperty = property.FindPropertyRelative("ResponseCurve");
            float propertyHeight = EditorGUI.GetPropertyHeight(parentProperty);
            
            var responseCurve = (ResponseCurve)parentProperty.intValue;
            switch (responseCurve)
            {
                case ResponseCurve.Linear:
                {
                    SerializedProperty responseCurveProperty = property.FindPropertyRelative("LinearResponseCurveConfig");
                    propertyHeight += EditorGUI.GetPropertyHeight(responseCurveProperty);
                    break;
                }
                case ResponseCurve.Quadratic:
                {
                    SerializedProperty responseCurveProperty = property.FindPropertyRelative("QuadraticResponseCurveConfig");
                    propertyHeight += EditorGUI.GetPropertyHeight(responseCurveProperty);
                    break;
                }
                case ResponseCurve.Exponential:
                {
                    SerializedProperty responseCurveProperty = property.FindPropertyRelative("ExponentialResponseCurveConfig");
                    propertyHeight += EditorGUI.GetPropertyHeight(responseCurveProperty);
                    break;
                }
                case ResponseCurve.Logistic:
                {
                    SerializedProperty responseCurveProperty = property.FindPropertyRelative("LogisticResponseCurveConfig");
                    propertyHeight += EditorGUI.GetPropertyHeight(responseCurveProperty);
                    break;
                }
                case ResponseCurve.Sine:
                {
                    SerializedProperty responseCurveProperty = property.FindPropertyRelative("SineResponseCurveConfig");
                    propertyHeight += EditorGUI.GetPropertyHeight(responseCurveProperty);
                    break;
                }
                case ResponseCurve.Cosine:
                {
                    SerializedProperty responseCurveProperty = property.FindPropertyRelative("CosineResponseCurveConfig");
                    propertyHeight += EditorGUI.GetPropertyHeight(responseCurveProperty);
                    break;
                }
                
                default:
                    throw new NotImplementedException();
            }
            
            return propertyHeight;
        }
    }
}
