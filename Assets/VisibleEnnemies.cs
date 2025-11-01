using System;
using UnityEngine;

public class VisibleEnnemies : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
 public SpriteRenderer spriteRenderer;
 public Sprite sprite;
    private void OnCollisionEnter2D(Collision2D other)
    {


        var visible = other.gameObject.GetComponent<IVisible>();
        if(visible != null)
             visible.SetVisible(true);
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        var notVisible = other.gameObject.GetComponent<IVisible>();
        if (notVisible != null)
        {
            notVisible.SetVisible(false);
        }
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
