using UnityEngine;
using UnityEngine.EventSystems;

public class DropZone : MonoBehaviour, IDropHandler
{
    public void OnDrop(PointerEventData eventData)
    {
        Debug.Log("OnDrop");
        GameObject droppedObject = eventData.pointerDrag;
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
            }
        }
        else
        {
            Debug.Log("Dropped object is null");
        }
    }
}
