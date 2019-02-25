using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class MagicDrawScript : MonoBehaviour
{

    Texture2D texture;

    public int drawRadius = 20;
    public Color drawColor = Color.black;

    Color32[] colors;

    private int WIDTH = 1024;
    private int HEIGHT = 1024;

	public bool debugDraw = false;

    // Start is called before the first frame update
    void Start()
    {
		Debug.Log("Magic screen initializing");
		WIDTH = GetComponent<RawImage>().texture.width;
		HEIGHT = GetComponent<RawImage>().texture.height;
		Debug.Log("Magic screen w: " + WIDTH + " h: " + HEIGHT);

        colors = new Color32[WIDTH * HEIGHT];

        texture = new Texture2D(WIDTH, HEIGHT);
        texture.wrapMode = TextureWrapMode.Clamp;
        GetComponent<RawImage>().texture = texture;

        ClearPixels();
		if(debugDraw) {
			TestDraw();
		}
    }

    // Update is called once per frame
    void Update()
    {

        //Debug.Log("Mouse pos:" + Input.mousePosition);
    }

    public void ClearPixels()
    {
        Color color = Color.clear;

        for (int y = 0; y < texture.height; y++)
        {
            for (int x = 0; x < texture.width; x++)
            {
                colors[x*WIDTH + y] = color;
            }
        }

        texture.SetPixels32(colors);

        texture.Apply();
    }

    public void DrawAt(int x, int y)
    {
        for(int i = Mathf.Max(0, x - drawRadius); i < Mathf.Min(WIDTH, x + drawRadius); i++)
        {
            for (int j = Mathf.Max(0, y - drawRadius); j < Mathf.Min(HEIGHT, y + drawRadius); j++)
            {
                colors[j * WIDTH + i] = drawColor;
            }
        }
    }

    // MUST call to apply changes made with DrawAt()
    public void ApplyDraw()
    {
        texture.SetPixels32(colors);
        texture.Apply();
    }

    public void TestDraw()
    {
        Debug.Log("Start TextDraw");
        for (int i = 0; i < WIDTH; i++)
        {
            DrawAt(i, i);
        }

        ApplyDraw();
    }
}
