using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class FadeManager : MonoBehaviour
{
    public static FadeManager Instance { get; private set; }
    [SerializeField] private CanvasGroup canvasGroup;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        canvasGroup = GetComponent<CanvasGroup>();
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        this.gameObject.SetActive(false);
    }
    public void FadeIn(float duration)
    {
        canvasGroup.alpha = 1;
        canvasGroup.DOFade(0, duration).SetEase(Ease.OutCubic);
    }
    public void FadeOut(float duration)
    {
        canvasGroup.alpha = 0;
        canvasGroup.DOFade(1, duration).SetEase(Ease.OutCubic);
    }
}
