using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateTriangle : MonoBehaviour
{
    GameObject triangle;
    Vector2 location;
    GameObject playerObj;
    // Start is called before the first frame update
    void Start()
    {
        playerObj = GameObject.Find("Player");
        Vector2 p1 = new Vector2(1.0f, 0.0f);
        Vector2 p2 = new Vector2(1.0f, 1.0f);
        Vector2 p3 = new Vector2(0.0f, 0.0f);
        triangle = new GameObject(); // create a new game object to hold the triangle
        triangle.AddComponent<PolygonCollider2D>(); // add a polygon collider component to the triangle
        triangle.AddComponent<SpriteRenderer>(); // add a sprite renderer component to the triangle
        triangle.GetComponent<SpriteRenderer>().sortingOrder = 1; // set the sorting order of the sprite renderer
        triangle.GetComponent<PolygonCollider2D>().points = new Vector2[] { p1, p2, p3 }; // set the points of the polygon collider
        triangle.GetComponent<PolygonCollider2D>().isTrigger = true;

            
    // create a texture for the sprite
    Texture2D texture = new Texture2D(128, 128);
    Color[] pixels = new Color[texture.width * texture.height];
    for (int i = 0; i < pixels.Length; i++) {
        pixels[i] = Color.white;
    }
    texture.SetPixels(pixels);
    texture.Apply();
    
    // create a sprite for the triangle and set its texture and color
    Sprite sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), new Vector2(0.5f, 0.5f));
    triangle.GetComponent<SpriteRenderer>().sprite = sprite;
    triangle.GetComponent<SpriteRenderer>().color = Color.red;
    }

    // Update is called once per frame
    void Update()
    {
        location = playerObj.transform.position;
        triangle.transform.position = location;
        triangle.transform.rotation = Quaternion.LookRotation(Vector3.forward, Input.mousePosition - triangle.transform.position);
    }
}
