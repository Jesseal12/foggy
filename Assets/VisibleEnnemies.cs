using System;
using Unity.VisualScripting;
using UnityEngine;

public class VisibleEnnemies : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    private void OnTriggerEnter2D(Collider2D other)
    {
       
  

        var visible = other.gameObject.GetComponent<IVisible>();
        if (visible != null)
        {
            print("Vihollinen näkyy");
            visible.SetVisible(true);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        

        var notVisible = other.gameObject.GetComponent<IVisible>();
        if (notVisible != null)
        {
            
            print("Viholline häviää");
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
