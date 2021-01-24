using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    [SerializeField] int rows;
    [SerializeField] int cols;
    private float tileSize;

    [SerializeField] private float cellSize;
    private Vector3 position;


    private int[,] gridArray;

    struct Cell
    {
        private Vector2 position;
    }

    private Cell[,] cells;
    
    // Start is called before the first frame update
    void Start()
    {
        
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnDrawGizmos()
    {
        for (int i = 0; i <= gridArray.Length; i++)
        {
            for (int y = 0; y <= gridArray.Length; y++)
            { 
                
                Gizmos.DrawCube( new Vector3(1,1,1),new Vector3(1,1,0));
            }
        }
    }
}
