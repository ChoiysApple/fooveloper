using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BgRepeat : MonoBehaviour {

    public float scrollSpeed = 1.2f;
    private Material thisMaterial;

    void Start()
    {
        thisMaterial = GetComponent<Renderer>().material;
    }

    void Update()
    {
        Vector2 newOffset = thisMaterial.mainTextureOffset;
        newOffset.Set(newOffset.x + (scrollSpeed * Time.deltaTime), 0);
        thisMaterial.mainTextureOffset = newOffset;
    }
}
