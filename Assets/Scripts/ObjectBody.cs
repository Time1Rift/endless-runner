using UnityEngine;

public abstract class ObjectBody : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Player player))
            Action(player);

        Die();
    }

    private void Die() => gameObject.SetActive(false);

    protected abstract void Action(Player player);
}