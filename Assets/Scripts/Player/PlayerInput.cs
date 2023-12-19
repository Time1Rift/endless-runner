using UnityEngine;

[RequireComponent(typeof(PlayerMover))]
public class PlayerInput : MonoBehaviour
{
    private PlayerMover _mover;

    private void Awake()
    {
        _mover = GetComponent<PlayerMover>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
            _mover.TryMoverUp();

        if (Input.GetKeyDown(KeyCode.S))
            _mover.TryMoverDown();
    }
}