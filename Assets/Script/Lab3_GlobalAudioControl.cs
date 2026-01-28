using UnityEngine;

public class Lab3_GlobalAudioControl : MonoBehaviour
{
    private bool isMuted = false;

    void Update()
    {
        // Phím M: Mute/Unmute
        if (Input.GetKeyDown(KeyCode.M))
        {
            isMuted = !isMuted;
            AudioListener.volume = isMuted ? 0f : 1f;
        }

        // Phím P: Pause/Resume
        if (Input.GetKeyDown(KeyCode.P))
        {
            AudioListener.pause = !AudioListener.pause;
        }
    }
}
