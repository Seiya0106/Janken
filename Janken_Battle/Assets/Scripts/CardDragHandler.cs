using UnityEngine;
using UnityEngine.EventSystems;

public class CardDragHandler : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    [Header("ドラッグ前の位置と親を保存するための変数")]
    private Vector2 prevPos;
    private GameObject prevParent;
    [Header("ドロップ先のDropZone")]
    public RectTransform dropZone;
    public void OnBeginDrag(PointerEventData eventData)
    {
        // 元の位置と親を保存
        prevPos = transform.position;
        prevParent = transform.parent.gameObject;
    }
    public void OnDrag(PointerEventData eventData)
    {
        transform.position = eventData.position;
    }
    public void OnEndDrag(PointerEventData eventData)
    {
        Vector2 dropZonePos = dropZone.InverseTransformPoint(eventData.position);
        if (dropZone.rect.Contains(dropZonePos))
        {
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
