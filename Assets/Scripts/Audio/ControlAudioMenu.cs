using UnityEngine;
using UnityEngine.UI;

public class ControlAudioMenu : MonoBehaviour
{
    public AudioSource audioSource;
    public Sprite audioImage;
    public Sprite muteImage;

    private Image buttonImage;
    private bool isPlaying = false;

   public void Start()
    {
        audioSource.Play();
        buttonImage = GetComponent<Image>();
        buttonImage.sprite = audioImage;
    }

    public void ToggleAudio()
    {
        if (isPlaying)
        {
            audioSource.Pause();
            buttonImage.sprite = muteImage;
        }
        else
        {
            audioSource.UnPause();
            buttonImage.sprite = audioImage;
        }

        isPlaying = !isPlaying;
    }
}