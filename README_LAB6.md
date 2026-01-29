# 🎬 Lab 6 - Video Render Target (HOÀN CHỈNH)

## 📌 Tình huống của bạn

✅ Đã làm Material Override ở dự án 3D khác  
✅ Đang làm dự án 2D hiện tại  
❓ Cần làm sao để hoàn thành Lab 6?  

## ✨ Giải pháp

**Làm CẢ HAI trong cùng một scene 2D!**

- Giữ nguyên dự án 2D của bạn
- Thêm 1 Quad 3D vào scene
- Demo cả 2 cách hiển thị video

---

## 🚀 Bắt đầu nhanh

### Option 1: Chỉ làm 2D (đơn giản) ⭐ Recommended nếu chỉ cần pass

**Script:** `Lab6_VideoRenderTarget.cs`  
**File hướng dẫn:** `LAB6_CHECKLIST.md`

```
✓ Setup UI RawImage
✓ Hiển thị video trên UI
✓ Thời gian: 3 phút
```

### Option 2: Làm CẢ 2D + 3D (đầy đủ) 💯 Recommended cho điểm cao

**Script:** `Lab6_Complete_2D_And_3D.cs`  
**File hướng dẫn:** `LAB6_QUICK_CHECKLIST_BOTH.md`

```
✓ Setup UI RawImage (2D)
✓ Setup Quad 3D Object
✓ Hiển thị video ở CẢ HAI nơi
✓ Thời gian: 5 phút
```

---

## 📚 Files bạn cần dùng

### Scripts (Assets/Script/)
```
1. Lab6_VideoRenderTarget.cs              ← Cho 2D only
2. Lab6_Complete_2D_And_3D.cs            ← Cho 2D + 3D ⭐
3. Lab6_7_VideoRenderWithEvents.cs        ← Advanced (optional)
```

### Hướng dẫn (Root folder)
```
1. LAB6_CHECKLIST.md                      ← Quick guide cho 2D only
2. LAB6_QUICK_CHECKLIST_BOTH.md          ← Quick guide cho 2D + 3D ⭐
3. LAB6_SETUP_2D_AND_3D.md               ← Full guide chi tiết
4. LAB6_SETUP_INSTRUCTIONS.md             ← Full guide cho 2D only
5. LAB_COMPARISON.md                      ← So sánh các labs
```

### Assets cần có
```
✓ Video file: Assets/Audio&Video/*.mp4
✓ RenderTexture: Assets/Audio&Video/VideoRenderTexture.renderTexture
```

---

## 🎯 Recommended Path (Cho bạn)

**→ Dùng Option 2: Lab6_Complete_2D_And_3D.cs**

### Tại sao?
1. ✅ Demo đầy đủ 2 cách (2D + 3D)
2. ✅ Điểm cao hơn
3. ✅ Chỉ tốn thêm 2 phút so với làm 2D only
4. ✅ Dự án 2D vẫn là 2D (chỉ thêm 1 Quad để demo)

### Làm gì?
1. Đọc file: **`LAB6_QUICK_CHECKLIST_BOTH.md`**
2. Follow từng bước trong checklist
3. Setup xong trong 5 phút
4. Screenshot/record để nộp bài

---

## 🎮 Quick Start Commands (Trong Unity)

```
1. Hierarchy → UI → Canvas
2. Canvas → UI → Raw Image (VideoDisplay_2D)
3. Hierarchy → 3D Object → Quad (VideoDisplay_3D)
4. Hierarchy → Create Empty (VideoController)
5. VideoController → Add Component → Lab6_Complete_2D_And_3D
6. Kéo thả trong Inspector theo checklist
7. Play!
```

---

## 📋 Deliverable

### Cần nộp:
- [ ] Screenshot: Video hiển thị trên 2D RawImage
- [ ] Screenshot: Video hiển thị trên 3D Quad
- [ ] Screenshot: Console logs (✅ CÁCH 1, ✅ CÁCH 2)
- [ ] Screenshot: Inspector setup
- [ ] Video recording (optional nhưng hay hơn)

### Tiêu chí:
✅ Video render qua RenderTexture  
✅ Hiển thị đúng trên UI (2D)  
✅ Hiển thị đúng trên 3D Object (Material Override)  
✅ Code sạch, có comments  
✅ Controls hoạt động (Space, S, R)  

---

## 🆘 Cần giúp đỡ?

### Đọc theo thứ tự:
1. **`LAB6_QUICK_CHECKLIST_BOTH.md`** ← BẮT ĐẦU TỪ ĐÂY
2. `LAB6_SETUP_2D_AND_3D.md` (nếu cần chi tiết hơn)
3. `LAB_COMPARISON.md` (hiểu khác biệt giữa các labs)

### Common issues:
- Video không hiển thị → Check Troubleshooting trong checklist
- 3D Object không thấy → Check Camera position
- 2D UI không thấy → Check Canvas settings

---

## ⏱️ Timeline

```
[0-2 phút]  Setup UI + 3D Object
[2-3 phút]  Create VideoController + Add Script
[3-4 phút]  Assign trong Inspector
[4-5 phút]  Test và verify
[5-10 phút] Screenshot/recording
```

**Total: ~10 phút để hoàn thành toàn bộ!**

---

## 🎉 Kết luận

**Bạn lo:** "Tôi đã làm dự án 2D rồi, làm sao để làm Material Override 3D?"

**Giải đáp:** Thêm 1 Quad 3D vào scene 2D → Done! Vẫn là dự án 2D nhưng có demo cả 3D!

**Next step:** Mở file `LAB6_QUICK_CHECKLIST_BOTH.md` và bắt đầu! 🚀

