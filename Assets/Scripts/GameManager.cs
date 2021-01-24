using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]private GameObject normalBlock;
    class BlockSpawn
    {
        public Vector2 position;
        private int type;
        private int hitPoints;
    }

    private List<BlockSpawn> _blockSpawns = new List<BlockSpawn>();

    private List<GameObject> blocks = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        float xPosition = 1;
        for (int i = 0; i <= 6; i++)
        {
            BlockSpawn spawn = new BlockSpawn();
            spawn.position = new Vector2(xPosition, 9.5f);
            _blockSpawns.Add(spawn);
            xPosition += 1.6f;
        }
        
        SpawnBlocks();
    }
    
    
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            MoveBlock();
            SpawnBlocks();
        }
    }



    void SpawnBlocks()
    {
        foreach (BlockSpawn spawn in _blockSpawns)
        {
            GameObject newBlock;
            newBlock = Instantiate(normalBlock, spawn.position, quaternion.identity);
            blocks.Add(newBlock);
        }
    }

    void MoveBlock()
    {
        foreach ( GameObject block in blocks)
        {
            block.transform.position = new Vector2(block.transform.position.x, block.transform.position.y - 1);
        }
    }
    
}
