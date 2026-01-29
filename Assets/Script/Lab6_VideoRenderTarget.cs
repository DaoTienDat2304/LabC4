using UnityEngine;
using UnityEngine.Video;
using UnityEngine.UI;

public class Lab6_VideoRenderTarget : MonoBehaviour
{
    [Header("Video Player Settings")]
    public VideoPlayer videoPlayer;
    public VideoClip videoClip;
    
    [Header("Render Target")]
    public RenderTexture renderTexture;
    
    [Header("Display Options")]
    [Tooltip("UI RawImage để hiển thị video (cho 2D UI)")]
    public RawImage rawImage;
    
    [Tooltip("Material của 3D object để hiển thị video (optional)")]
    public Material targetMaterial;
    
    [Header("Playback Controls")]
    public bool playOnStart = true;
    public bool loop = true;

    void Start()
    {
        SetupVideoPlayer();
        SetupRenderTarget();
    }

    void SetupVideoPlayer()
    {
        // Nếu chưa có VideoPlayer, tự động thêm component
        if (videoPlayer == null)
        {
            videoPlayer = GetComponent<VideoPlayer>();
            if (videoPlayer == null)
            {
                videoPlayer = gameObject.AddComponent<VideoPlayer>();
            }
        }

        // Cấu hình VideoPlayer
        videoPlayer.playOnAwake = false;
        videoPlayer.isLooping = loop;
        
        // Đặt video clip nếu có
        if (videoClip != null)
        {
            videoPlayer.source = VideoSource.VideoClip;
            videoPlayer.clip = videoClip;
        }
        
        // Đặt render mode là RenderTexture
        videoPlayer.renderMode = VideoRenderMode.RenderTexture;
        
        // Tạo RenderTexture nếu chưa có
        if (renderTexture == null)
        {
            renderTexture = new RenderTexture(1920, 1080, 0);
            renderTexture.name = "VideoRenderTexture";
        }
        
        // Gán RenderTexture cho VideoPlayer
        videoPlayer.targetTexture = renderTexture;
        
        // Play video nếu playOnStart = true
        if (playOnStart)
        {
            videoPlayer.Play();
        }
    }

    void SetupRenderTarget()
    {
        // Hiển thị lên UI RawImage (cho 2D)
        if (rawImage != null)
        {
            rawImage.texture = renderTexture;
            Debug.Log("Video được hiển thị trên UI RawImage");
        }
        
        // Hiển thị lên Material của 3D object
        if (targetMaterial != null)
        {
            targetMaterial.mainTexture = renderTexture;
            Debug.Log("Video được hiển thị trên Material 3D");
        }
    }

    void Update()
    {
        // Phím Space để Play/Pause
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (videoPlayer.isPlaying)
            {
                videoPlayer.Pause();
            }
            else
            {
                videoPlayer.Play();
            }
        }
        
        // Phím S để Stop
        if (Input.GetKeyDown(KeyCode.S))
        {
            videoPlayer.Stop();
        }
        
        // Phím R để Restart
        if (Input.GetKeyDown(KeyCode.R))
        {
            videoPlayer.time = 0;
            videoPlayer.Play();
        }
    }

    void OnDestroy()
    {
        // Clean up RenderTexture nếu được tạo dynamically
        if (renderTexture != null && renderTexture.name == "VideoRenderTexture")
        {
            renderTexture.Release();
        }
    }
}
