using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomPropertyDrawer(typeof(Toggleable<>))]
public class ToggleableDrawer : PropertyDrawer
{
    bool initializedDrawer;

    const float displayPropertyWidth = 125f;

    public void OnEnable(SerializedProperty property)  //Not sure how to call this
    {
        initializedDrawer = true;
    }

    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        if (!initializedDrawer)
            OnEnable(property);


        SerializedProperty dataType = property.FindPropertyRelative("myValue");
        SerializedProperty toogle = property.FindPropertyRelative("toogle");
      //  Object dataTypeOfAnyObject = dataType.objectReferenceValue;
      

       
        EditorGUI.BeginProperty(position, label, property);
        int indentSaved = EditorGUI.indentLevel;
        float widthFromIndentation = indentSaved * 9f;
        EditorGUI.indentLevel = 0;

        Rect labelRect = new Rect(widthFromIndentation + position.x, position.y, 180, 20);
        Rect leftRect = new Rect(widthFromIndentation + position.x -15, position.y, 60, 20);
        Rect rightRect = new Rect(widthFromIndentation + position.x + 240, position.y, 120, 20);

        EditorGUI.LabelField(labelRect, property.name);

        
        toogle.boolValue = EditorGUI.Toggle(leftRect, toogle.boolValue);
       
        if(!toogle.boolValue)
        {
            EditorGUI.PropertyField(rightRect, dataType, GUIContent.none);
        }
      
        //EditorGUI.PropertyField(rightRect, animBounds);

        EditorGUI.EndProperty();
        EditorGUI.indentLevel = indentSaved;

        //base.OnGUI(position, property, label);
    }

    //public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
    //{
    //    if (!initializedDrawer)
    //        OnEnable(property);

    //    return 20; //base.GetPropertyHeight(property, label); //* amtOfLines
    //}
}
