using UnityEngine;

public class DamageObject : MonoBehaviour
{
    public float damage;

    public void Start()
    {
        if (damage <= 0)
        {
            throw new System.ArgumentException("Damage parameter must be greater than zero");
        }
        
    }
    
}
