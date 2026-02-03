using DG.Tweening;
using UnityEngine;

public class FadeManager : MonoBehaviour
{
    public static FadeManager Instance { get; private set; }
    [SerializeField] private CanvasGroup canvasGroup;
    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
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
