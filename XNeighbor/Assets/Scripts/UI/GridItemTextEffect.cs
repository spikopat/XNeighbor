using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class GridItemTextEffect : MonoBehaviour
{
    private Tween startingTween;
    private Tween endingTween;

    private void OnEnable()
    {
        StartingSequence();
        transform.localScale = Vector3.one;
    }

    private void OnDisable()
    {
        startingTween.Kill();
    }

    private void Start()
    {

    }

    private void StartingSequence()
    {
        startingTween = DOTween.Sequence()
            .Append(transform.DOScale(0.85f, 0.1f))
            .Append(transform.DOScale(1.15f, 0.1f))
            .Append(transform.DOScale(0.90f, 0.075f))
            .Append(transform.DOScale(1f, 0.075f));
    }

    public void EndingSequence()
    {
        endingTween = DOTween.Sequence()
            .Append(transform.DOScale(0, 0.4f)
                .SetDelay(0.2f)
                .SetEase(Ease.OutQuart)
            )
            .OnComplete(() => {
                gameObject.SetActive(false);
            });
    }

}