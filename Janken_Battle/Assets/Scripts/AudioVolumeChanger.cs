using UnityEngine;
using UnityEngine.UI;

public class AudioVolumeChanger : MonoBehaviour
{
    public Slider volumeSlider;
    public AudioSource audioSource;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (volumeSlider.name == "BGM")
        {
            audioSource = BGMManager.Instance.GetComponent<AudioSource>();
        }
        else if (volumeSlider.name == "SE")
        {
            audioSource = SEManager.Instance.GetComponent<AudioSource>();
        }
        volumeSlider.value = audioSource.volume;
    }

    public void OnVolumeChange()
    {
        audioSource.volume = volumeSlider.value;
    }
}
