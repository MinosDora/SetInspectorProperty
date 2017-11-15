using System;
using System.Reflection;
using UnityEngine;
using UnityEditor;

[CustomPropertyDrawer(typeof(SetInspectorPropertyAttribute))]
public class SetInspectorPropertyEditor : PropertyDrawer
{
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        EditorGUI.BeginChangeCheck();
        EditorGUI.PropertyField(position, property, label);

        SetInspectorPropertyAttribute setProperty = attribute as SetInspectorPropertyAttribute;
        if (EditorGUI.EndChangeCheck())
        {
            setProperty.IsDirty = true;
        }
        else if (setProperty.IsDirty)
        {
            object targetObject = property.serializedObject.targetObject;
            Type type = targetObject.GetType();
            PropertyInfo propertyInfo = type.GetProperty(setProperty.Name);
            if (propertyInfo != null)
            {
                propertyInfo.SetValue(targetObject, fieldInfo.GetValue(targetObject), null);
            }
            else
            {
                Debug.LogError(setProperty.Name + " has not defined.");
            }
            setProperty.IsDirty = false;
        }
    }
}