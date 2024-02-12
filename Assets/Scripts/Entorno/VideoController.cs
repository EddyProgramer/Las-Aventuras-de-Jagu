/*using UnityEngine;
using UnityEngine.Video;

public class VideoController : MonoBehaviour
{
    public VideoClip videoClip;
    private VideoPlayer videoPlayer;

    void Start()
    {
        videoPlayer = gameObject.AddComponent<VideoPlayer>();
        videoPlayer.clip = videoClip;
        videoPlayer.playOnAwake = false;
        videoPlayer.renderMode = VideoRenderMode.MaterialOverride;
        videoPlayer.targetMaterialRenderer = GetComponent<Renderer>();
        videoPlayer.targetMaterialProperty = "_MainTex";

        // Para reproducir el video automáticamente al iniciar el juego
        videoPlayer.Play();
    }
}*/


using UnityEngine;
using UnityEngine.Video;

public class Video : MonoBehaviour
{
    public VideoPlayer videoPlayer;
      void Start()
    {
        // Configura el VideoPlayer para que no se reproduzca automáticamente al iniciar.
        videoPlayer.playOnAwake = false;
    }

    void Update()
    {
        // Ejemplo: Si se presiona la tecla (P), pausa o reanuda el video.
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (videoPlayer.isPlaying)
                videoPlayer.Pause();
            else
                videoPlayer.Play();
        }
    }
}
