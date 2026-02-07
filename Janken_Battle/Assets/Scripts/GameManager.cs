using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using System.Threading;
using System;
using Unity.VisualScripting;

public class GameManager : MonoBehaviour
{
    [Header("キャンセルトークン")]
    private CancellationTokenSource cts;
    [Header("GameManagerの参照")]
    public static GameManager Instance { get; private set; }
    [Header("カードがセットされたかどうか")]
    private bool isCardSeted = false;
    private bool isGameInProgress = false;
    [Header("相手のカード")]
    public List<Image> opponentCardImages;
    public List<CardData> opponentCardDatas;
    public Image opponentCard;
    private int enemyIndex = 0;
    private int index = 0;
    [Header("プレイヤーのカードデータ")]
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
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        isCardSeted = false;
        cts = new CancellationTokenSource();
    }

    // Update is called once per frame
    void Update()
    {
        if (isCardSeted && !isGameInProgress)
        {
            Debug.Log("カードがセットされました");
            isCardSeted = false;
            isGameInProgress = true;
            enemyIndex = UnityEngine.Random.Range(0, opponentCardDatas.Count);
            opponentCard.sprite = opponentCardDatas[enemyIndex].cardSprite;
            Debug.Log(opponentCardDatas[enemyIndex].cardType);
            Destroy(opponentCardImages[index].gameObject);
            GameProgress(cts.Token).Forget();
        }
    }
    public void SetCard()
    {
        isCardSeted = true;
    }
    /// <summary>
    /// プレイヤーのカードがセットされたら、相手のカードをランダムに決定し、ゲームの進行を開始する関数
    /// </summary>
    /// <returns></returns>
    private async UniTask GameProgress(CancellationToken token)
    {
        await UniTask.Delay(TimeSpan.FromSeconds(1), cancellationToken: token);
        // ここに勝敗判定の処理を追加する予定
        playerCard = DropZone.Instance.SetPlayerCard();
        if (playerCard.cardType == CardData.CardType.Rock && opponentCardDatas[enemyIndex].cardType == CardData.CardType.Scissors ||
            playerCard.cardType == CardData.CardType.Scissors && opponentCardDatas[enemyIndex].cardType == CardData.CardType.Paper ||
            playerCard.cardType == CardData.CardType.Paper && opponentCardDatas[enemyIndex].cardType == CardData.CardType.Rock)
        {
            Debug.Log("プレイヤーの勝ち");
        }
        else if (playerCard.cardType == CardData.CardType.Barrier || opponentCardDatas[enemyIndex].cardType == CardData.CardType.Barrier)
        {
            Debug.Log("バリアが出たので無効試合");
        }
        else if (playerCard.cardType == opponentCardDatas[enemyIndex].cardType)
        {
            Debug.Log("引き分け");
        }
        else
        {
            Debug.Log("相手の勝ち");
        }
        Debug.Log("ゲーム終了");
        if (index < opponentCardImages.Count)
        {
            index++;
        }
        isGameInProgress = false;
    }
    private void OnDestroy()
    {
        cts.Cancel();
        cts.Dispose();
    }
}
