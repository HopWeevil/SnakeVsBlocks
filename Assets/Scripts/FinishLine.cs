using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class FinishLine : MonoBehaviour
{
    [SerializeField] private ParticleSystem _finishEffect;

    public void PlayFinishEffect()
    {
        Instantiate(_finishEffect, transform.position, Quaternion.identity).Play();
    }
}
