using UnityEngine;
using UnityEngine.EventSystems;
using DG.Tweening;
using Unity.VisualScripting;

public class StartButton : MonoBehaviour, IPointerEnterHandler, IPointerDownHandler, IPointerUpHandler
{
    public System.Action OnClick;
    [SerializeField] private GameObject fadeManager;
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
        fadeManager.SetActive(true);
        FadeManager.Instance.FadeOut(3f);
    }
}
