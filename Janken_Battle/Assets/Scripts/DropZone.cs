using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class DropZone : MonoBehaviour, IDropHandler
{
    public static DropZone Instance { get; private set; }
    private CardData playerCard;
    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    public void OnDrop(PointerEventData eventData)
    {
        SEManager.Instance.PlaySE("put");
        GameObject droppedObject = eventData.pointerDrag;
        playerCard = droppedObject.GetComponent<CardDragHandler>().cardData;
        Debug.Log(playerCard.cardType);
        if (droppedObject != null)
        {
            CardDragHandler cardDragHandler = droppedObject.GetComponent<CardDragHandler>();
            if (cardDragHandler != null)
            {
                // ドロップ先をDropZoneに変更
                droppedObject.transform.SetParent(this.transform);
                droppedObject.transform.position = this.transform.position;
                
                // ドロップ成功フラグを設定
                cardDragHandler.SetDroppedInZone(true);
                GameManager.Instance.SetCard();
            }
        }
        else
        {
            Debug.Log("Dropped object is null");
        }
    }
    public CardData SetPlayerCard()
    {
        return playerCard;
    }
}
