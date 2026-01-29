# Lab 6 - Setup CẢ 2D VÀ 3D (Hoàn chỉnh 100%)

## 🎯 Mục tiêu
Demo video qua **CẢ HAI CÁCH**:
1. ✅ RenderTexture → UI RawImage (2D)
2. ✅ RenderTexture → Material Override (3D Object)

---

## 📋 Setup trong Unity (5 phút)

### Bước 1: Setup UI (2D)

#### 1.1 Tạo Canvas
```
Hierarchy → UI → Canvas
```

#### 1.2 Tạo RawImage
```
Canvas → Right-click → UI → Raw Image
Đặt tên: VideoDisplay_2D
```

#### 1.3 Chỉnh RawImage
```
Inspector:
- Rect Transform → Width: 640, Height: 360
- Position: X: -300, Y: 0 (bên trái màn hình)
```

---

### Bước 2: Setup 3D Object

#### 2.1 Tạo Quad (hoặc Plane)
```
Hierarchy → 3D Object → Quad
Đặt tên: VideoDisplay_3D
```

#### 2.2 Chỉnh vị trí Quad
```
Inspector → Transform:
- Position: X: 3, Y: 0, Z: 0 (bên phải)
- Rotation: X: 0, Y: 0, Z: 0
- Scale: X: 6.4, Y: 3.6, Z: 1
```

#### 2.3 Đảm bảo có Camera
```
Nếu chưa có Main Camera:
Hierarchy → Camera
Tag: MainCamera
Position: X: 0, Y: 0, Z: -10
```

---

### Bước 3: Setup Video Controller

#### 3.1 Tạo Empty GameObject
```
Hierarchy → Create Empty
Đặt tên: VideoController
```

#### 3.2 Add Script
```
VideoController → Add Component → Lab6_Complete_2D_And_3D
```

---

### Bước 4: Assign trong Inspector

Click vào **VideoController**, trong Inspector:

```
┌─────────────────────────────────────────────┐
│ Lab6 Complete 2D And 3D (Script)           │
├─────────────────────────────────────────────┤
│ Video Player Settings                       │
│   Video Clip: [Kéo .mp4 từ Audio&Video/]  │ ← 7476691344838.mp4
│                                             │
│ Render Target                               │
│   Render Texture: [VideoRenderTexture]     │ ← Từ Audio&Video folder
│                                             │
│ CÁCH 1: Hiển thị trên UI (2D)             │
│   Raw Image 2D: [VideoDisplay_2D]          │ ← Kéo RawImage vào
│                                             │
│ CÁCH 2: Hiển thị trên 3D Object           │
│   Object 3D: [VideoDisplay_3D]             │ ← Kéo Quad vào
│                                             │
│ Playback Controls                           │
│   Play On Start: ☑                         │
│   Loop: ☑                                  │
└─────────────────────────────────────────────┘
```

---

## ▶️ Test

### 1. Nhấn Play
Bạn sẽ thấy video hiển thị ở **HAI NƠI**:
- Bên trái: UI RawImage (2D) ✅
- Bên phải: Quad 3D Object ✅

### 2. Test Controls
| Phím | Chức năng |
|------|-----------|
| **SPACE** | Play / Pause |
| **S** | Stop |
| **R** | Restart |

### 3. Check Console
```
✅ CÁCH 1: Video hiển thị trên UI RawImage (2D)
✅ CÁCH 2: Video hiển thị trên 3D Object (Material Override)
```

---

## 🎨 Layout mẫu cho Scene

```
╔════════════════════════════════════╗
║                                    ║
║  [2D RawImage]    [3D Quad]       ║
║   📺 Video         📺 Video        ║
║   (UI Canvas)      (3D Object)     ║
║                                    ║
╚════════════════════════════════════╝
```

**Cả hai đều hiển thị cùng một video từ cùng RenderTexture!**

---

## 🎯 Deliverable

### Screenshot/Recording phải có:
1. ✅ Video trên UI RawImage (bên trái)
2. ✅ Video trên 3D Quad (bên phải)
3. ✅ Console logs showing cả 2 cách
4. ✅ Inspector showing script setup

### Scene Hierarchy sẽ trông như này:
```
Scene
├── Canvas
│   ├── VideoDisplay_2D (RawImage) ← CÁCH 1
│   └── EventSystem
├── VideoDisplay_3D (Quad) ← CÁCH 2
├── VideoController (Empty GameObject)
│   └── Lab6_Complete_2D_And_3D (Script)
└── Main Camera
```

---

## 💡 Giải thích Technical

### RenderTexture là trung gian:
```
VideoPlayer
    ↓
RenderTexture (texture chung)
    ↓         ↓
RawImage   Material 3D
(UI 2D)    (Override)
```

### Một video → nhiều outputs:
- Cùng một video
- Cùng một RenderTexture
- Nhưng hiển thị ở **2 nơi khác nhau**
- Không tốn thêm memory/performance vì chỉ render 1 lần

---

## ⚠️ Troubleshooting

### 3D Object không hiển thị video?
```
✓ Check: Object3D có Renderer component?
✓ Check: Camera có nhìn thấy object không?
✓ Check: Quad có bị che không?
```

### 2D hoặc 3D hiển thị đen?
```
→ Check RenderTexture đã assign đúng chưa
→ Check video đã play chưa (Console logs)
```

### Chỉ muốn demo 1 cách thôi?
```
→ Để một trong hai field (RawImage2D hoặc Object3D) trống
→ Script sẽ tự động skip phần đó
```

---

## ✨ Hoàn thành!

Bây giờ bạn đã demo được **CẢ HAI CÁCH** trong cùng một scene!
- Project 2D vẫn là 2D
- Nhưng có thêm 1 Quad 3D để demo Material Override
- Đầy đủ deliverable của Lab 6! 🎉

