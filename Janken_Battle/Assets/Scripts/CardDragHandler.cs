using UnityEngine;
using UnityEngine.EventSystems;

public class CardDragHandler : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    [Header("ドラッグ前の位置と親を保存するための変数")]
    private Vector2 prevPos;
    private Transform prevParent;
    private int prevSiblingIndex;
    [Header("ドラッグ時のalphaを変えるためのCanvasGroup")]
    public CanvasGroup canvasGroup;
    [Header("ドロップ先のDropZone")]
    public RectTransform dropZone;
    [Header("CardAnimationの参照")]
    private CardAnimation CardAnimation;
    [Header("ドロップが成功したかのフラグ")]
    private bool droppedInZone = false;
    public CardData cardData;
    void Awake()
    {
        CardAnimation = GetComponent<CardAnimation>();
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        // 元の位置と親とインデックスを保存
        prevPos = transform.position;
        prevParent = transform.parent;
        prevSiblingIndex = transform.GetSiblingIndex();

        // ドラッグ開始時にカードの大きさを元に戻す
        transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);

        droppedInZone = false;
        canvasGroup.blocksRaycasts = false; // ドラッグ中にRaycastを無効化
        if (CardAnimation != null)
        {
            CardAnimation.enabled = false; // カードアニメーションを無効化
        }
    }
    public void OnDrag(PointerEventData eventData)
    {
        transform.position = eventData.position;
        canvasGroup.alpha = 0.6f;
    }
    public void OnEndDrag(PointerEventData eventData)
    {
        canvasGroup.alpha = 1.0f;
        
        // レイキャストを元に戻す
        canvasGroup.blocksRaycasts = true;
        
        // DropZoneで処理されなかった場合は元の位置に戻す
        if (!droppedInZone)
        {
            transform.SetParent(prevParent);
            transform.SetSiblingIndex(prevSiblingIndex);
            transform.position = prevPos;
            
            // アニメーションを再有効化
            if (CardAnimation != null)
            {
                CardAnimation.enabled = true;
            }
        }
    }

    public void SetDroppedInZone(bool value)
    {
        droppedInZone = value;
    }
}
