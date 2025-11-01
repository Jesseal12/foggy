using UnityEngine;

public class NPCMover : MonoBehaviour
{
    private Vector2 _targetOne = Vector2.right * 4.5f;
    private Vector2 _targetTwo = Vector2.right * -4.5f;
    private Vector2 _target;
    private const float ProximityThreshold = 0.1f;
    private const float Speed = 1f;
    
    private void Start()
    {
     _target = _targetOne;
    }
    
    private void FixedUpdate()
    {
        if (ProximityCheck())
        {
            ChangeTarget();
            FlipCharacter();
        }
        
        Move();
    }

    private void Move()
    {
        transform.position = Vector2.MoveTowards(transform.position, _target, Speed * Time.fixedDeltaTime);
        //_rb2d.MovePosition(_rb2d.position + _velocity * Time.fixedDeltaTime);
    }
    private bool ProximityCheck()
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
