using UnityEngine;
using UnityEngine.Video;
using UnityEngine.UI;

/// <summary>
/// Lab 6 HOÀN CHỈNH: Hiển thị video QUA CẢ HAI CÁCH
/// 1. RenderTexture → UI RawImage (2D)
/// 2. RenderTexture → Material Override (3D Object)
/// </summary>
public class Lab6_Complete_2D_And_3D : MonoBehaviour
{
    [Header("Video Player Settings")]
    public VideoPlayer videoPlayer;
    public VideoClip videoClip;
    
    [Header("Render Target")]
    public RenderTexture renderTexture;
    
    [Header("CÁCH 1: Hiển thị trên UI (2D)")]
    [Tooltip("UI RawImage để hiển thị video")]
    public RawImage rawImage2D;
    
    [Header("CÁCH 2: Hiển thị trên 3D Object")]
    [Tooltip("3D Object (Quad, Plane, hoặc bất kỳ object nào có Renderer)")]
    public GameObject object3D;
    
    [Header("Playback Controls")]
    public bool playOnStart = true;
    public bool loop = true;

    private Material material3D;

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
        
        // Đặt video clip
        if (videoClip != null)
        {
            videoPlayer.source = VideoSource.VideoClip;
            videoPlayer.clip = videoClip;
        }
        
        // QUAN TRỌNG: Đặt render mode là RenderTexture
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
        // ✅ CÁCH 1: Hiển thị lên UI RawImage (2D)
        if (rawImage2D != null)
        {
            rawImage2D.texture = renderTexture;
            Debug.Log("✅ CÁCH 1: Video hiển thị trên UI RawImage (2D)");
        }
        else
        {
            Debug.LogWarning("⚠ Chưa assign RawImage 2D!");
        }
        
        // ✅ CÁCH 2: Material Override trên 3D Object
        if (object3D != null)
        {
            Renderer renderer = object3D.GetComponent<Renderer>();
            if (renderer != null)
            {
                // Tạo material mới để không ảnh hưởng material gốc
                material3D = new Material(renderer.material);
                material3D.mainTexture = renderTexture;
                renderer.material = material3D;
                
                Debug.Log("✅ CÁCH 2: Video hiển thị trên 3D Object (Material Override)");
            }
            else
            {
                Debug.LogError("❌ 3D Object không có Renderer component!");
            }
        }
        else
        {
            Debug.LogWarning("⚠ Chưa assign 3D Object!");
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
                Debug.Log("⏸ Video tạm dừng");
            }
            else
            {
                videoPlayer.Play();
                Debug.Log("▶ Video đang phát");
            }
        }
        
        // Phím S để Stop
        if (Input.GetKeyDown(KeyCode.S))
        {
            videoPlayer.Stop();
            Debug.Log("■ Video đã dừng");
        }
        
        // Phím R để Restart
        if (Input.GetKeyDown(KeyCode.R))
        {
            videoPlayer.time = 0;
            videoPlayer.Play();
            Debug.Log("🔄 Video restart");
        }
    }

    void OnDestroy()
    {
        // Clean up
        if (renderTexture != null && renderTexture.name == "VideoRenderTexture")
        {
            renderTexture.Release();
        }
        
        if (material3D != null)
        {
            Destroy(material3D);
        }
    }
}
