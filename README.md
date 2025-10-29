# OpenCV_C73 — C# 7.3 ile Basit Kamera Uygulaması ( .NET Framework 4.8 )

Bu proje, **C# 7.3 (.NET Framework 4.8)** ve **OpenCvSharp4** ile yazılmış basit bir kamera uygulamasıdır.  
Konsol penceresinden çalışır; OpenCV penceresinde canlı görüntü açar. Tek tuşla fotoğraf kaydı, gri tonlama ve (isteğe bağlı) yüz tespiti içerir.

## ✨ Özellikler
- Canlı kamera akışı (Varsayılan kamera: index `0`)
- **S** tuşu ile fotoğraf kaydetme (`foto_YYYYMMDD_HHMMSS.jpg`)
- **G** tuşu ile gri tonlama (aç/kapat)
- **F** tuşu ile yüz tespiti (aç/kapat) — *Haar cascade dosyası gerekir*
- **ESC** ile çıkış

## 🧩 Gereksinimler
- Windows 10/11, 64-bit
- Visual Studio 2022 (veya 2019)
- .NET Framework **4.8**
- NuGet paketleri:
  - `OpenCvSharp4`
  - `OpenCvSharp4.runtime.win`
- Proje **platformu**: `x64`  
  (Visual Studio üst çubuk: **Hata Ayıklama  x64** görmelisiniz)

## 🔧 Kurulum (Adım Adım)
1. **Konsol Uygulaması (.NET Framework 4.8)** projesi oluşturun.
2. Projeye sağ tık → **NuGet Paketlerini Yönet…**  
   `OpenCvSharp4` ve `OpenCvSharp4.runtime.win` paketlerini kurun.
3. Üst menü → **Derleme > Yapılandırma Yöneticisi…**  
   **Etkin çözüm platformu = x64** yapın.
4. (Yüz tespiti kullanacaksanız) `haarcascade_frontalface_default.xml` dosyasını proje köküne koyun.

## ▶️ Çalıştırma
- Visual Studio üstten **Hata Ayıklamadan Başlat (Ctrl+F5)**.
- Açılan OpenCV penceresinde:
  - **S** → fotoğraf kaydet
  - **G** → gri tonlama aç/kapat
  - **F** → yüz tespiti aç/kapat *(XML dosyası yoksa önce ekleyin)*
  - **ESC** → çıkış

## 📁 Dosya Yapısı (Önerilen)
