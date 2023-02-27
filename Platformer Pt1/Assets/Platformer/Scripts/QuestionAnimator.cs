using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestionAnimator : MonoBehaviour
{
    
    public Vector2 shift;
    private Material mat;
    private MeshRenderer mr; 
    // Update is called once per frame

    private void Start()
    {
        mr = GetComponent<MeshRenderer>();
        mat = mr.material;
    }

    void Update()
    {
        // Vector2 shift = new Vector2(0f, 0.2f);
        // Vector2 getOff = mat.mainTextureOffset;
        // getOff += shift;
        // mat.mainTextureOffset = getOff * Time.deltaTime;
        Vector2 newPos = mat.mainTextureOffset + shift * Time.deltaTime;
        
        mat.mainTextureOffset = newPos;
    }
    
}
