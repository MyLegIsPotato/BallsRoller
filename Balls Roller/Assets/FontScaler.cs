using DG.Tweening;
using ModestTree;
using TMPro;
using UnityEngine;

public class FontScaler : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI text;

    private void Awake()
    {
        Assert.IsNotNull(text, "Text is not assigned in the inspector");
    }

    public void Animate()
    {
        DOTween.Sequence()
            .Append(text.DOFade(1, 0.5f))
            .Append(text.transform.DOScale(1.2f, 0.5f).SetLoops(5, LoopType.Yoyo))
            .Append(text.DOFade(0, 0.5f))
            .OnComplete(() => gameObject.SetActive(false));
        DOTween.Play(text.gameObject);
    }
}
