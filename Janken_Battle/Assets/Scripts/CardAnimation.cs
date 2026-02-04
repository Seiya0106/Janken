using UnityEngine;
using UnityEngine.EventSystems;

public class CardAnimation : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [Header("カードの元の位置と親を保存するための変数")]
    private int originalSiblingIndex;
    [Header("GameManagerの参照")]
    public GameManager gameManager;
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
}
