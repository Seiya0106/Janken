using UnityEngine;

public class SEManager : MonoBehaviour
{
    [Header("Singleton Instance")]
    public static SEManager Instance { get; private set; }
    [Header("SEの音源")]
    public AudioClip pushSE;
    public AudioClip hoverSE;
    public AudioClip putSE;
    [Header("AudioSource")]
    [SerializeField] private AudioSource audioSource;
    void Start()
    {
        DontDestroyOnLoad(this);
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
            audioSource.Play();
        }
        else if (seName == "hover")
        {
            audioSource.clip = hoverSE;
            audioSource.Play();
        }
        else if (seName == "put")
        {
            audioSource.clip = putSE;
            audioSource.Play();
        }
    }
}
