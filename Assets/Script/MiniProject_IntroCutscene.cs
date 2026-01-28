using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class MiniProject_IntroCutscene : MonoBehaviour
{
    public VideoPlayer videoPlayer;
    public AudioSource bgmAudioSource;
    public GameObject skipButton; // Button UI để skip

    void Start()
    {
        // Đăng ký event khi video kết thúc
        videoPlayer.loopPointReached += OnIntroEnded;
        
        // Play video và nhạc nền
        videoPlayer.Play();
        if (bgmAudioSource != null)
        {
            bgmAudioSource.Play();
        }
    }

    void OnIntroEnded(VideoPlayer vp)
    {
        LoadGameplay();
    }

    // Hàm này gọi từ Button Skip
    public void SkipIntro()
    {
        LoadGameplay();
    }

    void LoadGameplay()
    {
        // Chuyển sang scene gameplay (đổi tên scene phù hợp)
        SceneManager.LoadScene("GameplayScene");
    }

    void OnDestroy()
    {
        if (videoPlayer != null)
        {
            videoPlayer.loopPointReached -= OnIntroEnded;
        }
    }
}
