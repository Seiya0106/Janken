using UnityEngine;

public class SEManager : MonoBehaviour
{
    [Header("Singleton Instance")]
    public static SEManager Instance { get; private set; }
    [Header("SEの音源")]
    public AudioClip pushSE;
    public AudioClip hoverSE;
    public AudioClip putSE;
    public AudioClip lightAttackSE;
    public AudioClip heavyAttackSE;
    public AudioClip guardSE;
    public AudioClip winSE;
    public AudioClip drawSE;
    public AudioClip loseSE;
    [Header("AudioSource")]
    [SerializeField] private AudioSource audioSource;
    void Start()
    {
        DontDestroyOnLoad(gameObject);
        audioSource = GetComponent<AudioSource>();
        audioSource.volume = 0.5f;
    }
    private void Awake()
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
    /// <summary>
    /// SEを再生する関数
    /// </summary>
    /// <param name="seName"></param>
    public void PlaySE(string seName)
    {
        if (seName == "push")
        {
            audioSource.clip = pushSE;
        }
        else if (seName == "hover")
        {
            audioSource.clip = hoverSE;
        }
        else if (seName == "put")
        {
            audioSource.clip = putSE;
        }
        else if (seName == "lightAttack")
        {
            audioSource.clip = lightAttackSE;
        }
        else if (seName == "heavyAttack")
        {
            audioSource.clip = heavyAttackSE;
        }
        else if (seName == "guard")
        {
            audioSource.clip = guardSE;
        }
        else if (seName == "win")
        {
            audioSource.clip = winSE;
        }
        else if (seName == "draw")
        {
            audioSource.clip = drawSE;
        }
        else if (seName == "lose")
        {
            audioSource.clip = loseSE;
        }
        audioSource.Play();
    }
}
