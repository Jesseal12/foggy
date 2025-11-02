using UnityEngine;

public class NPCMover : MonoBehaviour
{
    private Vector2 _targetOne = Vector2.right * 4.5f;
    private Vector2 _targetTwo = Vector2.right * -4.5f;
    private Vector2 _target;
    
    private const float ProximityThreshold = 0.1f;
    private const float MaxSpeed = 2f;
    private const float MinSpeedFactor = .1f;
    private const float MaxSpeedFactor = 1f;
    
    private void Start()
    {
     _target = _targetOne;
    }
    
    private void FixedUpdate()
    {
        if (TimeToReturn())
        {
            ChangeTarget();
            FlipCharacter();
        }
        
        Move();
    }
    
    private void Move()
    {
        float smoothSpeed = Mathf.Clamp(ProximityCheck(), MinSpeedFactor, MaxSpeedFactor) * MaxSpeed;
        transform.position = Vector2.MoveTowards(transform.position, _target, smoothSpeed * Time.fixedDeltaTime);
    }
    private float ProximityCheck()
    {
        var dist1 = Vector2.Distance(transform.position, _targetOne);
        var dist2 = Vector2.Distance(transform.position, _targetTwo);
        
        return dist1 > dist2 ? dist2 : dist1;
    }

    private bool TimeToReturn()
    { 
        return Vector2.Distance(transform.position, _target) < ProximityThreshold;
    }
    private void ChangeTarget()
    {
        _target = _target == _targetOne ? _targetTwo : _targetOne;
    }

    private void FlipCharacter()
    {
        transform.rotation = Quaternion.Euler(0, transform.rotation == Quaternion.Euler(0, 0, 0) ? 180 : 0, 0);
    }
}
