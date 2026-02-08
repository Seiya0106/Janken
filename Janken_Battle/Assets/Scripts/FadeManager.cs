using DG.Tweening;
using UnityEngine;
using Cysharp.Threading.Tasks;
using System;
using System.Threading;
using UnityEngine.SceneManagement;

public class FadeManager : MonoBehaviour
{
    public static FadeManager Instance { get; private set; }
    private CancellationTokenSource cts;
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
        cts = new CancellationTokenSource();
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
    /// <summary>
    /// ゲームシーンをロードする関数
    /// </summary>
    /// <returns></returns>
    public async UniTask LoadGame()
    {
        FadeOut(3f);
        await UniTask.Delay(TimeSpan.FromSeconds(3), cancellationToken: cts.Token);
        SceneManager.LoadScene("Game");
        await UniTask.Delay(TimeSpan.FromSeconds(1), cancellationToken: cts.Token);
        FadeIn(2f);
    }
    public async UniTask LoadTitle()
    {
        FadeOut(3f);
        await UniTask.Delay(TimeSpan.FromSeconds(3), cancellationToken: cts.Token);
        SceneManager.LoadScene("Title");
        await UniTask.Delay(TimeSpan.FromSeconds(1), cancellationToken: cts.Token);
        FadeIn(2f);
    }
    private void OnDestroy()
    {
        cts.Cancel();
        cts.Dispose();
    }
}
