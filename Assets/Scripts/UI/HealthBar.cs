using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private CellBar _heart;

    private List<CellBar> _hearts = new();

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
        CellBar newHeart = Instantiate(_heart, transform);
        newHeart.ToFill();
        _hearts.Add(newHeart);
    }

    private void DestroyHeart(CellBar heart)
    {
        _hearts.Remove(heart);
        _heart.ToEmpty();
    }
}
