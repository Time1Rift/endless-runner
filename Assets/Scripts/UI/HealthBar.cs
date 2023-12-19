using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private Heart _heart;

    private List<Heart> _hearts = new();

    private void OnEnable()
    {
        _player.HealthChanged += OnHealthChanged;
    }

    private void OnDisable()
    {
        _player.HealthChanged -= OnHealthChanged;
    }

    private void OnHealthChanged(float health)
    {
        if (_hearts.Count < health)
        {
            float value = health - _hearts.Count;

            for (int i = 0; i < value; i++)
                CreateHeart();
        }

        if (_hearts.Count > health)
        {
            float value = _hearts.Count - health;

            for (int i = 0; i < value; i++)
                DestroyHeart(_hearts[_hearts.Count - 1]);
        }
    }

    private void CreateHeart()
    {
        Heart newHeart = Instantiate(_heart, transform);
        newHeart.ToFill();
        _hearts.Add(newHeart);
    }

    private void DestroyHeart(Heart _heart)
    {
        _hearts.Remove(_heart);
        _heart.ToEmpty();
    }
}