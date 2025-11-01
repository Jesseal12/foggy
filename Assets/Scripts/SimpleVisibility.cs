using System;
using UnityEngine;

public class SimpleVisibility : MonoBehaviour, IVisible
{
    public bool visible;
    public SpriteRenderer spriteRenderer;
    public Sprite spriteWhenVisible;
    public Sprite spriteWhenNotVisible;
    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        UpdateSprite();
    }

    void UpdateSprite()
    {
        spriteRenderer.sprite = visible ?  spriteWhenVisible : spriteWhenNotVisible;        
    }
    public void SetVisible(bool visible)
    {
        this.visible = visible;
        UpdateSprite();
    }

    public bool IsVisible()
    {
 return visible;        
    }
}
