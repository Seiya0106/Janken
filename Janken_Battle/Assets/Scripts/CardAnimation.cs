using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CardAnimation : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
                            , IBeginDragHandler, IDragHandler, IEndDragHandler
{
    private int originalSiblingIndex;
    private Transform cardTransform;
    private Vector2 prevPos;
    [SerializeField] private GameObject prevParent;
    public RectTransform dropZone;
    void Start()
    {
        // 元のインデックスを保存
        originalSiblingIndex = transform.GetSiblingIndex();
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        // カードを全面に移動
        transform.SetAsLastSibling();

        transform.localScale = new Vector3(1.3f, 1.3f, 1.3f);
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        // カードを元の位置に戻す
        transform.SetSiblingIndex(originalSiblingIndex);

        transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
    }
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
