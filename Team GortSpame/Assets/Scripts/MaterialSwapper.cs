using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialSwapper : MonoBehaviour
{
    private Material firstMat;
    [SerializeField] private Material secondMat;
    private Color _matColor;
    private Texture _matTexture;
    
    // Start is called before the first frame update
    void Start()
    {
        firstMat = GetComponent<Renderer>().material;
        _matColor = firstMat.color;
        _matTexture = firstMat.mainTexture;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SwapMaterial(bool second)
    {
        secondMat.color = _matColor;
        secondMat.mainTexture = _matTexture;
        GetComponent<Renderer>().sharedMaterial = second ? secondMat : firstMat;
    }
}
