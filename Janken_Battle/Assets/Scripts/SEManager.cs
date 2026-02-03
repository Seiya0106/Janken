using UnityEngine;

public class SEManager : MonoBehaviour
{
    public static SEManager Instance { get; private set; }
    public AudioClip pushSE;
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
    public void PlaySE(string seName)
    {
        if (seName == "push")
        {
            audioSource.clip = pushSE;
            audioSource.Play();
        }
    }
}
