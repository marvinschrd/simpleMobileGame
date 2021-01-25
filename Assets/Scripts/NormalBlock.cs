using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class NormalBlock : MonoBehaviour
{
    private SpriteRenderer sprite;
    private ParticleSystem particle;
    private int hitpoints = 1;
    
    private TextMeshPro text;
    
    // Start is called before the first frame update
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
       // particle = GetComponent<ParticleSystem>();
    }
    
    // Update is called once per frame
    void Update()
    {
        //text.text = hitpoints.ToString();
        if (hitpoints <= 0)
        {
            DestroyBlock();
        }
    }
    
    public void SetSpriteColor(Vector4 color)
    {
        sprite.color = color;
        if (particle != null)
        {
            var particleMain = particle.main;
            var particleMainStartColor = particleMain.startColor;
            particleMainStartColor.color = color;
        }
    }
    public void SetHitpoints(int points)
    {
        hitpoints = points;
    }
    
    
    private void OnCollisionEnter(Collision other)
    {
        hitpoints--;
    }
    
    
    void DestroyBlock()
    {
        Destroy(gameObject);
    }
}
