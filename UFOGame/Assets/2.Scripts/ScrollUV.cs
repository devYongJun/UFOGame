using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollUV : MonoBehaviour
{
    public float speed;

    private Material _mat;

    void Awake()
    {
        _mat = GetComponent<MeshRenderer>().material;    
    }

    void Update()
    {
        Vector2 offset = _mat.mainTextureOffset;
        offset.x += Time.deltaTime * speed;
        _mat.mainTextureOffset = offset;
    }
}
