using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectBoom : MonoBehaviour //爆炸特效类
{
    ParticleSystem sys;
    void Start()
    {
        sys = GetComponent<ParticleSystem>();
    }
    void Update()
    {
        if (!sys.isPlaying)
            Destroy(gameObject);
    }
}
