using UnityEngine;

public class Ring : ObjectBody
{
    [SerializeField] private float _powerHealing;

    protected override void Action(Player player) => player.AddHealth(_powerHealing);
}