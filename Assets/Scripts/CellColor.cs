using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CellColor : MonoBehaviour
{
    private MeshRenderer _meshRenderer;
    
    void Start()
    {
        _meshRenderer = GetComponent<MeshRenderer>();

    }

    void Update()
    {

        if (_meshRenderer.sharedMaterial.color != Color.white)
        {
            float r = _meshRenderer.sharedMaterial.color.r;
            float g = _meshRenderer.sharedMaterial.color.g;
            float b = _meshRenderer.sharedMaterial.color.b;
            
            if (r < 1)
            {
                r += 0.01f;
            }

            if (g < 1)
            {
                g += 0.01f;
            }

            if (b < 1)
            {
                b += 0.01f;
            }

            Color col = new Color(r, g, b);
            _meshRenderer.sharedMaterial.color = col;
        };
    }
}
