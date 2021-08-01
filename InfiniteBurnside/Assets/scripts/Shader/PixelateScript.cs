 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PixelateScript : MonoBehaviour
{
    [ExecuteInEditMode]
    private Material material;
    private Vector2 pixelSize = new Vector2(4, 4);


    private void Awake()
    {
        material = new Material(Shader.Find("Hidden/pixelation"));
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnRenderImage(RenderTexture source, RenderTexture destination)
    {
        material.SetFloat("_screenWidth", Screen.width);
        material.SetFloat("_screenHeight", Screen.height);
        material.SetFloat("_pixelX", pixelSize.x);
        material.SetFloat("_pixelY", pixelSize.y);
        Graphics.Blit(source, destination, material);
    }


}
