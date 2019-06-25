using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class SpritePostProcessor : AssetPostprocessor
{
    private void OnPostprocessTexture(Texture2D a_Texture)
    {
        Debug.Log(a_Texture.name + " , width = " + a_Texture.width + " , height " + a_Texture.height);
    }

    private void OnPostprocessSprite(Texture2D a_Texture, Sprite[] a_Sprites)
    {
        Debug.Log("post Process sprite = " + a_Sprites.Length);
    }
}
