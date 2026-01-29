# 🎓 Lab 6 - Cách hoạt động (How It Works)

## 🧠 Khái niệm chính: RenderTexture

**RenderTexture** là texture đặc biệt có thể:
- Nhận video stream từ VideoPlayer
- Chia sẻ cho nhiều objects khác nhau
- Sử dụng như texture thông thường

---

## 🔄 Luồng dữ liệu (Data Flow)

### Lab 5 (Cũ - Direct):
```
Video File (.mp4)
    ↓
VideoPlayer
    ↓
Screen (Direct)
```
❌ Không linh hoạt  
❌ Chỉ hiển thị full screen  

---

### Lab 6 (Mới - RenderTexture):
```
Video File (.mp4)
    ↓
VideoPlayer
    ↓
RenderTexture (trung gian)
    ↓           ↓
RawImage    Material 3D
(UI 2D)     (Override)
```
✅ Linh hoạt  
✅ Có thể hiển thị nhiều nơi  
✅ Có thể resize, transform  

---

## 📊 So sánh các cách render video

### 1. Direct / Camera Mode (Lab 5)
```csharp
videoPlayer.renderMode = VideoRenderMode.CameraFarPlane;
```
- Video render trực tiếp lên camera
- Full screen
- Không thể tùy chỉnh vị trí/size

### 2. RenderTexture Mode (Lab 6) ⭐
```csharp
videoPlayer.renderMode = VideoRenderMode.RenderTexture;
videoPlayer.targetTexture = renderTexture;
```
- Video render vào texture
- Texture có thể dùng cho bất kỳ đâu
- Linh hoạt 100%

---

## 🎯 Lab 6 - Chi tiết implementation

### Bước 1: Setup VideoPlayer
```csharp
videoPlayer.renderMode = VideoRenderMode.RenderTexture;
videoPlayer.targetTexture = renderTexture; // RenderTexture 1920x1080
videoPlayer.Play();
```

### Bước 2A: Hiển thị trên UI (2D)
```csharp
rawImage.texture = renderTexture;
```
- RawImage là UI component
- Hiển thị trong Canvas
- Có thể resize, anchor, v.v.

### Bước 2B: Hiển thị trên 3D Object
```csharp
Renderer renderer = quad.GetComponent<Renderer>();
Material newMaterial = new Material(renderer.material);
newMaterial.mainTexture = renderTexture; // Material Override!
renderer.material = newMaterial;
```
- Lấy Renderer của 3D object (Quad, Plane, Cube, ...)
- Tạo material mới
- Override mainTexture với RenderTexture
- Assign material mới cho object

---

## 🏗️ Cấu trúc Scene

```
Scene
│
├── Canvas (UI Layer)
│   ├── VideoDisplay_2D (RawImage)
│   │   └── texture = renderTexture ← CÁCH 1
│   └── EventSystem
│
├── VideoDisplay_3D (Quad) ← 3D World Space
│   └── Material.mainTexture = renderTexture ← CÁCH 2
│
├── VideoController (Empty GameObject)
│   └── Lab6_Complete_2D_And_3D.cs
│       ├── videoPlayer.targetTexture = renderTexture
│       ├── rawImage.texture = renderTexture
│       └── material.mainTexture = renderTexture
│
└── Main Camera
    └── Nhìn thấy cả UI và 3D Object
```

---

## 🎨 Visual Explanation

### Camera View:
```
╔═══════════════════════════════════════╗
║ Canvas (UI Layer - always on top)    ║
║  ┌─────────────┐                     ║
║  │ 📺 Video    │                     ║
║  │ (RawImage)  │                     ║
║  │ 2D UI       │      ╔═══════╗     ║
║  └─────────────┘      ║ 📺    ║     ║
║                       ║ Video ║     ║
║                       ║ (Quad)║     ║
║                       ║ 3D    ║     ║
║                       ╚═══════╝     ║
╚═══════════════════════════════════════╝
    ↑                       ↑
    UI Layer            World Space
   (2D Canvas)          (3D Scene)
```

### Data Flow:
```
   [Video File]
        ↓
   VideoPlayer.Play()
        ↓
  [RenderTexture] ← Texture chung
        ↓
    ┌───┴───┐
    ↓       ↓
[UI 2D]  [3D Quad]
 Left     Right
```

---

## 💡 Tại sao làm thế này?

### Use Cases thực tế:

#### 1. TV Screen trong game 3D
```
Player đi vào phòng
→ Thấy TV (Quad 3D)
→ TV đang phát video
→ Video render qua RenderTexture
```

#### 2. Video menu background (2D UI)
```
Main menu
→ Background là video
→ Dùng RawImage full screen
→ UI buttons ở trên
```

#### 3. Security Camera Feed
```
Nhiều màn hình
→ Hiển thị cùng 1 video
→ Chỉ cần 1 VideoPlayer
→ 1 RenderTexture
→ Nhiều Materials/RawImages
```

#### 4. Billboard quảng cáo
```
Thế giới mở
→ Nhiều billboards
→ Tất cả hiển thị cùng 1 quảng cáo
→ Performance tốt (chỉ decode 1 lần)
```

---

## 🔧 Technical Details

### RenderTexture Properties:
```csharp
RenderTexture rt = new RenderTexture(1920, 1080, 0);
// Width: 1920
// Height: 1080
// Depth: 0 (không cần depth buffer cho video)
```

### Material Override Process:
```csharp
// 1. Lấy material hiện tại
Material originalMat = renderer.material;

// 2. Tạo material mới (instance)
Material newMat = new Material(originalMat);

// 3. Override texture
newMat.mainTexture = renderTexture;

// 4. Assign lại cho renderer
renderer.material = newMat;
```

### Tại sao tạo material mới?
- Không muốn thay đổi material gốc (shared material)
- Material gốc có thể được dùng bởi objects khác
- Instance material chỉ ảnh hưởng object này

---

## 🎯 Key Takeaways

1. **RenderTexture = trung gian linh hoạt**
   - Nhận video từ VideoPlayer
   - Chia sẻ cho nhiều consumers

2. **Material Override = gán texture mới cho 3D object**
   - Tạo material instance
   - Set mainTexture
   - Performance tốt

3. **RawImage = hiển thị texture trên UI**
   - Đơn giản: `rawImage.texture = renderTexture`
   - Tích hợp tốt với Canvas

4. **Một video, nhiều outputs**
   - Decode 1 lần
   - Hiển thị nhiều nơi
   - Tiết kiệm resources

---

## 📚 References

### Unity Documentation:
- VideoPlayer.renderMode
- VideoPlayer.targetTexture
- RenderTexture class
- Material.mainTexture
- RawImage.texture

### Related Labs:
- Lab 5: Video Player Basic (direct rendering)
- Lab 7: Video Events (event handling)
- Lab 6 + 7: Combined (render + events)

---

## ✨ Summary

**Lab 6 dạy bạn:**
- ✅ Sử dụng RenderTexture làm trung gian
- ✅ Hiển thị video trên UI (2D)
- ✅ Material Override cho 3D objects
- ✅ Flexibility trong việc hiển thị media content

**Skills học được:**
- Render target concepts
- Material system
- UI/3D integration
- Resource optimization

