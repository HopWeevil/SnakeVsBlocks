using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundColorizer : MonoBehaviour
{
    [SerializeField] private Color[] _colors;
    private void Awake()
    {
        Camera.main.backgroundColor = _colors[Random.Range(0, _colors.Length)];
    }
}
