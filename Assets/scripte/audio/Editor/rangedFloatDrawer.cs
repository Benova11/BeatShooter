using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomPropertyDrawer(typeof(rangedFlot),true)]
public class rangedFloatDrawer : PropertyDrawer
{
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        label = EditorGUI.BeginProperty(position, label, property);
        position = EditorGUI.PrefixLabel(position, label);

        SerializedProperty minProp = property.FindPropertyRelative("_minValue");
        SerializedProperty maxProp = property.FindPropertyRelative("_maxValue");

        float minValue = minProp.floatValue;
        float maxValue = maxProp.floatValue;

        float rangeMin = 0;
        float rangeMax = 1;

        var ranges = (minMaxRangedAttribute[])fieldInfo.GetCustomAttributes(typeof(minMaxRangedAttribute), true);
        if (ranges.Length > 0)
        {
            rangeMin = ranges[0].Min;
            rangeMax = ranges[0].Max;
        }

        var minLableRect = new Rect(position);
        minLableRect.width = 40;
        GUI.Label(minLableRect, new GUIContent(minValue.ToString("F2")));
        position.xMin += 40;    

        var maxLableRect = new Rect(position);
        maxLableRect.xMin = maxLableRect.xMax - 40;
        GUI.Label(maxLableRect, new GUIContent(minValue.ToString("F2")));
        position.xMax -= 40;

        EditorGUI.BeginChangeCheck();
        EditorGUI.MinMaxSlider(position,ref minValue,ref maxValue,rangeMin,rangeMax);
        if (EditorGUI.EndChangeCheck())
        {
            minProp.floatValue = minValue;
            maxProp.floatValue = maxValue;
                
        }

        EditorGUI.EndProperty();
    }
}
