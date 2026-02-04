using UnityEngine;
using UnityEngine.EventSystems;
using DG.Tweening;
public class BackButton : MonoBehaviour, IPointerEnterHandler, IPointerDownHandler, IPointerUpHandler
, IPointerExitHandler
{
    public GameObject creditPanel;
    public System.Action OnClick;
    [SerializeField] private CanvasGroup canvasGroup;
    public void OnPointerEnter(PointerEventData eventData)
    {
        OnClick?.Invoke();
        transform.localScale = new Vector3(1.1f, 1.1f, 1.1f);
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
        creditPanel.SetActive(false);
    }
}
