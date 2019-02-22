using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class MagicDrawScript : MonoBehaviour
{

    Texture2D texture;

    public int drawRadius = 20;
    public Color drawColor = Color.black;

    // Start is called before the first frame update
    void Start()
    {
        texture = new Texture2D(1024, 1024);

        ClearPixels();
    }

    // Update is called once per frame
    void Update()
    {

        Debug.Log("Mouse pos:" + Input.mousePosition);
    }

    void ClearPixels()
    {
        for (int y = 0; y < texture.height; y++)
        {
            for (int x = 0; x < texture.width; x++)
            {
                Color color = Color.clear;
                texture.SetPixel(x, y, color);
            }
        }

        texture.Apply();
    }

    void DrawAt(int x, int y)
    {
        for(int i = x - drawRadius; i < x + drawRadius; i++)
        {
            for (int j = y - drawRadius; j < y + drawRadius; j++)
            {
                texture.SetPixel(i, j, drawColor);
            }
        }

        texture.Apply();
    }

    void DrawPixels()
    {
        GetComponent<RawImage>().texture = texture;

        for (int y = 0; y < texture.height; y++)
        {
            for (int x = 0; x < texture.width; x++)
            {
                if((x & y) == 0)
                {
                    Color color = Color.black;
                    texture.SetPixel(x, y, color);
                }
            }
        }
        texture.Apply();
    }
}
