using UnityEngine;

public class BGMManager : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;
    [Header("BGMの音源")]
    public AudioClip mainBGM;
    void Start()
    {
        DontDestroyOnLoad(this);
        audioSource = GetComponent<AudioSource>();
        audioSource.volume = 0.5f;
        audioSource.clip = mainBGM;
        audioSource.Play();
    }
}
