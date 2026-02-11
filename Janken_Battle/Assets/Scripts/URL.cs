using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class URL : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler
{
    private TextMeshProUGUI urlText;
    public string url;
    void Awake()
    {
        urlText = GetComponent<TextMeshProUGUI>();
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        urlText.rectTransform.localScale = new Vector3(1.1f, 1.1f, 1.1f);
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        urlText.rectTransform.localScale = new Vector3(1f, 1f, 1f);
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        OpenURL();
    }
    public void OpenURL()
    {
        Application.OpenURL(url);
    }
}
