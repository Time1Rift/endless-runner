using UnityEngine;

public class Enemy : ObjectBody
{
    [SerializeField] private float _damage;

    protected override void Action(Player player) => player.TakeDamage(_damage);
}