using UnityEngine;

public class BGMManager : MonoBehaviour
{
    public static BGMManager Instance { get; private set; }
    [SerializeField] private AudioSource audioSource;
    [Header("BGMの音源")]
    public AudioClip mainBGM;
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
    void Start()
    {
        DontDestroyOnLoad(gameObject);
        audioSource = GetComponent<AudioSource>();
        audioSource.volume = 0.5f;
        audioSource.clip = mainBGM;
        audioSource.Play();
    }
}
