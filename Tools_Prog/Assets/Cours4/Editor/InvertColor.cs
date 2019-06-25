using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class InvertColor : AssetPostprocessor
{
    private void OnPostprocessTexture(Texture2D a_Texture)
    {
        string lowerPath = assetPath.ToLower();

        if(lowerPath.Contains("invert"))
        {
           Color[] col = a_Texture.GetPixels();

           for(int i = 0; i < col.Length; i++)
           {
                col[i].r = -col[i].r;
                col[i].g = -col[i].g; 
                col[i].b = -col[i].b;             
           }

           a_Texture.SetPixels(col);
        }
    }
}
