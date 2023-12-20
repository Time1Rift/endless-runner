using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class CellBar : MonoBehaviour
{
    [SerializeField] private float _duration;

    private Image _image;

    private void Awake()
    {
        _image = GetComponent<Image>();
        _image.fillAmount = 0;
    }

    public void ToFill()
    {
        float startValue = 0;
        float endValue = 1;
        StartCoroutine(ChangeFullness(startValue, endValue, Fill));
    }

    public void ToEmpty()
    {
        float startValue = 1;
        float endValue = 0;
        StartCoroutine(ChangeFullness(startValue, endValue, Destroy));
    }

    private void Fill(float value)
    {
        _image.fillAmount = value;
    }

    private void Destroy(float value)
    {
        _image.fillAmount = value;
        Destroy(gameObject);
    }

    private IEnumerator ChangeFullness(float startValue, float endValue, Action<float> End—hanges)
    {
        float elapsed = 0;
        float nextValue;

        while (elapsed <= _duration)
        {
            nextValue = Mathf.Lerp(startValue, endValue, elapsed / _duration);
            _image.fillAmount = nextValue;
            elapsed += Time.deltaTime;
            yield return null;
        }

        End—hanges?.Invoke(endValue);
    }
}