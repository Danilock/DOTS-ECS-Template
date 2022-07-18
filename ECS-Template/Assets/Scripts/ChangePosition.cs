using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangePosition : MonoBehaviour
{
    [SerializeField] private Vector3 _offset;

    public Vector3 GetOffset
    {
        get => _offset;
        set => _offset = value;
    }

    [SerializeField] private Bounds _bounds;

    private Vector3 GetRandomVector
    {
        get
        {
            return new Vector3(
                Random.Range(GetPoint.x + _bounds.extents.x, GetPoint.x - _bounds.extents.x), 
                Random.Range(GetPoint.y + _bounds.extents.y, GetPoint.y - _bounds.extents.y)
                );
        }
    }

    [SerializeField] private Vector3 _initialPoint;

    public Vector3 GetPoint
    {
        get
        {
            if (Application.isPlaying)
                return _initialPoint + _offset;

            return transform.position + _offset;
        }
    }

    public Bounds GetBounds
    {
        get => _bounds;
        set => _bounds = value;
    }

    private void Awake()
    {
        _initialPoint = transform.position;
    }

    public void SetRandomPosition()
    {
        transform.position = GetRandomVector;
    }
}
