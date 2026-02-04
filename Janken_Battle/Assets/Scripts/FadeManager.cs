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
    /// <summary>
    /// フェードインする関数
    /// </summary>
    /// <param name="duration"></param>
    public void FadeIn(float duration)
    {
        canvasGroup.alpha = 1;
        canvasGroup.DOFade(0, duration).SetEase(Ease.OutCubic);
    }
    /// <summary>
    /// フェードアウトする関数
    /// </summary>
    /// <param name="duration"></param>
    public void FadeOut(float duration)
    {
        canvasGroup.alpha = 0;
        canvasGroup.DOFade(1, duration).SetEase(Ease.OutCubic);
    }
}
