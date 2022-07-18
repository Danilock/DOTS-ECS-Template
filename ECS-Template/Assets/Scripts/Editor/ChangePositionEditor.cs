using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEditor.IMGUI.Controls;

[CustomEditor(typeof(ChangePosition)), CanEditMultipleObjects]
public class ChangePositionEditor : Editor
{
    private BoxBoundsHandle _boundsHandle = new BoxBoundsHandle();

    private void OnSceneGUI()
    {
        ChangePosition changePosition = (ChangePosition)target;

        _boundsHandle.center = changePosition.GetPoint;
        _boundsHandle.size = changePosition.GetBounds.size;

        EditorGUI.BeginChangeCheck();

        _boundsHandle.DrawHandle();

        Vector3 newPosition = Handles.PositionHandle(changePosition.GetPoint, Quaternion.identity);
        newPosition -= changePosition.transform.position;

        if (EditorGUI.EndChangeCheck())
        {
            Undo.RecordObject(changePosition, "Process Target Detection");
            changePosition.GetOffset = newPosition;

            Bounds newBounds = new Bounds();
            newBounds.center = _boundsHandle.center;
            newBounds.size = _boundsHandle.size;

            changePosition.GetBounds = newBounds;
        }
    }
}
