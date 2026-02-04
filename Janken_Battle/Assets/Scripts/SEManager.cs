using UnityEngine;

public class SEManager : MonoBehaviour
{
    public static SEManager Instance { get; private set; }
    [Header("SEの音源")]
    public AudioClip pushSE;
    [Header("AudioSource")]
    [SerializeField] private AudioSource audioSource;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
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
    }
}
