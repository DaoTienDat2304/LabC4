# ✅ Lab 6 - Quick Checklist (CẢ 2D + 3D)

## 🎯 Setup nhanh trong 5 phút

### 1️⃣ Tạo UI (2D)
```
□ Hierarchy → UI → Canvas
□ Canvas → UI → Raw Image (tên: VideoDisplay_2D)
□ Position: X: -300, Y: 0 | Size: 640 x 360
```

### 2️⃣ Tạo 3D Object
```
□ Hierarchy → 3D Object → Quad (tên: VideoDisplay_3D)
□ Position: X: 3, Y: 0, Z: 0
□ Scale: X: 6.4, Y: 3.6, Z: 1
```

### 3️⃣ Tạo Video Controller
```
□ Hierarchy → Create Empty (tên: VideoController)
□ Add Component → Lab6_Complete_2D_And_3D
```

### 4️⃣ Assign trong Inspector
```
VideoController → Lab6_Complete_2D_And_3D:

Video Player Settings:
  □ Video Clip: [7476691344838.mp4] ← Kéo từ Audio&Video/

Render Target:
  □ Render Texture: [VideoRenderTexture.renderTexture]

CÁCH 1: Hiển thị trên UI (2D):
  □ Raw Image 2D: [VideoDisplay_2D] ← Kéo RawImage

CÁCH 2: Hiển thị trên 3D Object:
  □ Object 3D: [VideoDisplay_3D] ← Kéo Quad

Playback Controls:
  ☑ Play On Start
  ☑ Loop
```

### 5️⃣ Test
```
□ Nhấn Play trong Unity
□ Video hiển thị ở BÊN TRÁI (2D RawImage) ✅
□ Video hiển thị ở BÊN PHẢI (3D Quad) ✅
□ Check Console: 2 dòng log xanh ✅
```

---

## 📸 Scene Layout

```
╔════════════════════════════════╗
║                                ║
║  [📺 2D]        [📺 3D]       ║
║  RawImage       Quad           ║
║  (UI)           (3D Object)    ║
║                                ║
╚════════════════════════════════╝
```

---

## 🎮 Controls khi chạy

| Phím | Chức năng |
|------|-----------|
| SPACE | Play/Pause |
| S | Stop |
| R | Restart |

---

## ✅ Deliverable Checklist

Để nộp bài, cần có:
```
□ Screenshot showing CẢ HAI video (2D + 3D)
□ Console logs: "✅ CÁCH 1..." và "✅ CÁCH 2..."
□ Inspector screenshot của VideoController setup
□ Video recording (optional nhưng tốt hơn)
```

---

## 🎓 Điểm mấu chốt

**Lab 6 yêu cầu:**
> Hiển thị video qua:
> - RenderTexture + UI RawImage **HOẶC**
> - Material Override trên object 3D

**Bạn đang làm:** ✅ CẢ HAI!
- RenderTexture → RawImage (2D) ✅
- RenderTexture → Material 3D ✅

**Kết quả:** Điểm tối đa! 💯

---

## ⚠️ Nếu gặp lỗi

### Video không hiển thị?
→ Check Console có 2 dòng "✅ CÁCH 1" và "✅ CÁCH 2" không

### Chỉ thấy 1 video?
→ Check xem đã assign đủ cả RawImage2D và Object3D chưa

### 3D Object bị đen?
→ Check Main Camera có trong scene không
→ Position camera: (0, 0, -10)

### 2D UI không thấy?
→ Check Canvas Render Mode = Screen Space Overlay
→ Check RawImage có trong Canvas không

