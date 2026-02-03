using UnityEngine;
using DG.Tweening;
using UnityEngine.EventSystems;
using Cysharp.Threading.Tasks.Triggers;

public class CreditButton : MonoBehaviour, IPointerEnterHandler, IPointerDownHandler, IPointerUpHandler
{
    public System.Action OnClick;
    [SerializeField] private CanvasGroup canvasGroup;
    public void OnPointerEnter(PointerEventData eventData)
    {
        OnClick?.Invoke();
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
    }
}
