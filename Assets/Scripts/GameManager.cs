using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;

public class GameManager : MonoBehaviour
{
    [SerializeField]private GameObject normalBlock;
    [SerializeField] int baseHitpoints;
    [SerializeField] private List<GameObject> SpecialBlocks = new List<GameObject>();
    //
    class BlockSpawn
    {
        public Vector2 position;
        public int hitPoints;
        public Color color;
        public bool isNormal;
    }
    //
    private List<BlockSpawn> _blockSpawns = new List<BlockSpawn>();
    
    private List<GameObject> blocks = new List<GameObject>();
    // // Start is called before the first frame update
    void Start()
    {
        float xPosition = 1;
        for (int i = 0; i <= 5; i++)
        {
            BlockSpawn spawn = new BlockSpawn();
            spawn.position = new Vector2(xPosition, 9.5f);
            _blockSpawns.Add(spawn);
            xPosition += 1.6f;
            Debug.Log("??");
        }
        SetBlockSpawns();
        SpawnBlocks();
    }
    //
    //
    void Update()
    {
        // if (Input.GetButtonDown("Fire1"))
        // {
        //     MoveBlock();
        //     baseHitpoints += 2;
        //     SetBlockSpawns();
        //    // SpawnBlocks();
        // }
    }
    
    void MoveBlock()
    {
        foreach ( GameObject block in blocks)
        {
            MoveBlock();
            baseHitpoints += 2;
            SetBlockSpawns();
            SpawnBlocks();
        }
    }
    //
    void MoveBlock()
    {
        foreach ( GameObject block in blocks)
        {
            block.transform.position = new Vector2(block.transform.position.x, block.transform.position.y - 1.5f);
        }
    }
    //
    void SetBlockSpawns()
    {
        Color newColor = Random.ColorHSV();
        foreach (BlockSpawn spawns in _blockSpawns)
        {
            //Select if block will be normal or special
            int prob = Random.Range(0, 2);
            if (prob != 2)
            {
                spawns.isNormal = true;
                spawns.color = newColor;
            }
            else
            {
                spawns.isNormal = false;
            }
            spawns.hitPoints = baseHitpoints;
            Debug.Log("is normal = " + spawns.isNormal);
        }
    }
    void SpawnBlocks()
    {
        foreach (BlockSpawn spawn in _blockSpawns)
        {
            // GameObject newBlock;
            // newBlock = Instantiate(normalBlock, spawn.position, quaternion.identity);
            // blocks.Add(newBlock);
            if (spawn.isNormal)
            {
                //Set hit points
                //newBlockScript.SetHitpoints(spawn.hitPoints);
                //Set color
                GameObject newInstatiatedBlock =Instantiate(normalBlock, spawn.position, quaternion.identity);
                blocks.Add(newInstatiatedBlock);
                NormalBlock blockScript = newInstatiatedBlock.GetComponent<NormalBlock>();
                if (blockScript == null)
                {
                    Debug.Log("no script");
                }
                else
                {
                    Debug.Log("script here");
                }
                blockScript.SetSpriteColor(spawn.color);
                
                Debug.Log("trying");
            }
            else
            {
                int rand = Random.Range(0, SpecialBlocks.Count);
                GameObject specialBlock = SpecialBlocks[rand];
                NormalBlock blockScript = specialBlock.GetComponent<NormalBlock>();
                //blockScript.SetHitpoints(spawn.hitPoints);
                GameObject instatiatedSpecialBlock = Instantiate(specialBlock, spawn.position, quaternion.identity);
                blocks.Add(instatiatedSpecialBlock);
            }
        }
    }
}
