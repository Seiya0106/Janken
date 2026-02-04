using UnityEngine;
using UnityEngine.EventSystems;

public class CardDragHandler : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    [Header("ドラッグ前の位置と親を保存するための変数")]
    private Vector2 prevPos;
    private GameObject prevParent;
    [Header("ドラッグ時のalphaを変えるためのCanvasGroup")]
    public CanvasGroup canvasGroup;
    [Header("ドロップ先のDropZone")]
    public RectTransform dropZone;
    public void OnBeginDrag(PointerEventData eventData)
    {
        // 元の位置と親を保存
        prevPos = transform.position;
        prevParent = transform.parent.gameObject;

        // ドラッグ開始時にカードの大きさを元に戻す
        transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
    }
    public void OnDrag(PointerEventData eventData)
    {
        transform.position = eventData.position;
        canvasGroup.alpha = 0.6f;
    }
    public void OnEndDrag(PointerEventData eventData)
    {
        canvasGroup.alpha = 1.0f;
        Vector2 dropZonePos = dropZone.InverseTransformPoint(eventData.position);
        if (dropZone.rect.Contains(dropZonePos))
        {
            CardAnimation cardAnimation = GetComponent<CardAnimation>();
            cardAnimation.enabled = false; // カードアニメーションを無効化
            transform.SetParent(dropZone);
            GetComponent<RectTransform>().anchoredPosition = Vector2.zero;
        }
        // ドロップ先がない場合、元の位置に戻す
        else
        {
            transform.SetParent(prevParent.transform);
            transform.position = prevPos;
        }
    }
}
