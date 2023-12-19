using UnityEngine;

public class PlayerMover : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _stepSize;
    [SerializeField] private float _maxHeight;
    [SerializeField] private float _minHeight;

    private Vector3 _targetPosition;

    private void Start()
    {
        _targetPosition = transform.position;
    }

    private void Update()
    {
        if (_targetPosition != transform.position)
            transform.position = Vector3.MoveTowards(transform.position, _targetPosition, _speed * Time.deltaTime);
    }

    public void TryMoverUp()
    {
        if (_targetPosition.y < _maxHeight)
            SetNextPosition(_stepSize);

    }

    public void TryMoverDown()
    {
        if (_targetPosition.y > _minHeight)
            SetNextPosition(-_stepSize);
    }

    private void SetNextPosition(float step) => _targetPosition.y += step;
}