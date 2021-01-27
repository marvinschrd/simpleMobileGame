using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Mathematics;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class NormalBlock : MonoBehaviour
{
    private SpriteRenderer _spriteRenderer;
     [SerializeField] GameObject particle;
    private int hitpoints = 1;
    
    //private TextMeshPro text;
    
    // Start is called before the first frame update
    void Start()
    {
    }
    
    // Update is called once per frame
    void Update()
    {
        //text.text = hitpoints.ToString();
         if (hitpoints <= 0)
         {
             // particle = GetComponent<ParticleSystem>();
             DestroyBlock();
         }
     }
    
    
    public void SetSpriteColor(Color newColor)
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _spriteRenderer.color = newColor;
        // if (particle != null)
        // {
        //     var particleMain = particle.main;
        //     var particleMainStartColor = particleMain.startColor;
        //     particleMainStartColor.color = new Color();
        // }
    }
    public void SetHitpoints(int points)
    {
        hitpoints = points;
    }


    private void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log("hit");
        hitpoints--;
    }


    void DestroyBlock()
    {
        Instantiate(particle, transform.position, quaternion.identity);
        Destroy(gameObject);
    }
}
