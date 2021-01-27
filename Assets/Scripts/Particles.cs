using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Particles : MonoBehaviour
{
    private ParticleSystem particle;
    // Start is called before the first frame update
    void Start()
    {
        particle = GetComponent<ParticleSystem>();
        Destroy();
    }

    void Destroy()
    {
        float time = particle.main.duration;
        Destroy(gameObject, time);
    }
}
