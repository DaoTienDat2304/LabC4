using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class Lab7_VideoEvents : MonoBehaviour
{
    private VideoPlayer videoPlayer;
    public GameObject endUI; // UI hiển thị khi video kết thúc

    void Start()
    {
        videoPlayer = GetComponent<VideoPlayer>();
        
        if (endUI != null)
        {
            endUI.SetActive(false);
        }

        // Đăng ký event khi video sẵn sàng
        videoPlayer.prepareCompleted += OnVideoPrepared;
        
        // Đăng ký event khi video kết thúc
        videoPlayer.loopPointReached += OnVideoEnded;
    }

    void OnVideoPrepared(VideoPlayer vp)
    {
        Debug.Log("Video đã sẵn sàng!");
    }

    void OnVideoEnded(VideoPlayer vp)
    {
        Debug.Log("Video đã kết thúc!");
        
        if (endUI != null)
        {
            endUI.SetActive(true);
        }
        
        // Hoặc chuyển scene (bỏ comment dòng dưới nếu muốn)
        // SceneManager.LoadScene("GameplayScene");
    }

    void OnDestroy()
    {
        // Hủy đăng ký event khi destroy
        if (videoPlayer != null)
        {
            videoPlayer.prepareCompleted -= OnVideoPrepared;
            videoPlayer.loopPointReached -= OnVideoEnded;
        }
    }
}
