using UnityEngine;

public class RandomMover : MonoBehaviour
{
    [SerializeField] private float _speed = 2;
    [SerializeField] private float _circleRadius = 4;
    private Vector3 _target;

    private void Start()
    {
        ApplyNewTarget();
    }

    private void Update()
    {
        Move(_target, _speed);

        if (transform.position == _target)
        {
            ApplyNewTarget();
        }
    }

    private void Move(Vector3 target, float speed)
    {
        transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);
    }

    private void ApplyNewTarget()
    {
        _target = transform.position + GetPositionInsideCircle(_circleRadius);
    }

    private Vector3 GetPositionInsideCircle(float radius)
    {
        return Random.insideUnitCircle * radius;
    }
}
