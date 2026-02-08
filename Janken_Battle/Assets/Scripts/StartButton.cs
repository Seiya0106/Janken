using UnityEngine;
using UnityEngine.EventSystems;
using DG.Tweening;
using Cysharp.Threading.Tasks;
using System.Threading;
using System;
using UnityEngine.SceneManagement;

public class StartButton : MonoBehaviour, IPointerEnterHandler, IPointerDownHandler, IPointerUpHandler
, IPointerExitHandler
{
    [SerializeField] private GameObject fadeManager;
    [SerializeField] private CanvasGroup canvasGroup;
    private CancellationTokenSource cts;
    void Start()
    {
        cts  = new CancellationTokenSource();
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        transform.localScale = new Vector3(1.1f, 1.1f, 1.1f);
        SEManager.Instance.PlaySE("hover");
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        transform.DOScale(0.9f, 0.24f).SetEase(Ease.OutCubic);
        canvasGroup.DOFade(0.8f, 0.24f).SetEase(Ease.OutCubic);
    }
    public void OnPointerUp(PointerEventData eventData)
    {
        transform.DOScale(1.0f, 0.24f).SetEase(Ease.OutCubic);
        canvasGroup.DOFade(1.0f, 0.24f).SetEase(Ease.OutCubic);
        SEManager.Instance.PlaySE("push");
        FadeManager.Instance.FadeOut(3f);
        LoadGame(cts.Token).Forget();
    }
    private async UniTask LoadGame(CancellationToken token)
    {
        await UniTask.Delay(TimeSpan.FromSeconds(3), cancellationToken: token);
        SceneManager.LoadScene("Game");
        await UniTask.DelayFrame(1, cancellationToken: token);
        FadeManager.Instance.FadeIn(3f);
    }
}
