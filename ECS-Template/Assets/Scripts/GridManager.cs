using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    public int Width;
    public int Height;

    [SerializeField] private Tile _tilePrefab;

    private void Start()
    {
        
    }

    private void InitializeTileMap()
    {
        for(int i = 0; i < Width * Height; i++)
        {

        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(transform.position, new Vector3(Width, Height, 0f));
    }
}
