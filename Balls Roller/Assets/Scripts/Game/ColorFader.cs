using DG.Tweening;
using System.Collections.Generic;
using UnityEngine;

public class ColorFader : MonoBehaviour
{
    [SerializeField]
    private float fadeSpeed = 0.5f;
    [SerializeField]
    private Material material;
    [SerializeField]
    private Collector collector;
    [SerializeField]
    List<Color> colors = new List<Color>();

    private void Start()
    {
        collector.OnCollect += FadeColor;
    }

    private void FadeColor(Collector collector, int score)
    {
        TweenColor(material.color, colors[score%colors.Count], fadeSpeed, material);
    }

    private void TweenColor(Color startColor, Color endColor, float duration, Material m)
    {
        DOTween.To(() => startColor, x => m.color = x, endColor, duration);
    }
}
