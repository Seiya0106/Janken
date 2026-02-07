using UnityEngine;
using UnityEngine.EventSystems;

public class CardAnimation : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [Header("GameManagerの参照")]
    public GameManager gameManager;

    public void OnPointerEnter(PointerEventData eventData)
    {
        // カードを拡大
        transform.localScale = new Vector3(1.3f, 1.3f, 1.3f);
        SEManager.Instance.PlaySE("hover");
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        // カードを元の大きさに戻す
        transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
    }
}
