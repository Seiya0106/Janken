using UnityEngine;
using UnityEngine.EventSystems;

public class URL : MonoBehaviour, IPointerDownHandler
{
    public string url;
    public void OnPointerDown(PointerEventData eventData)
    {
        OpenURL();
    }
    public void OpenURL()
    {
        Application.OpenURL(url);
    }
}
