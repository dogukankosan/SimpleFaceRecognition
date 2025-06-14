# 🤖 SimpleFaceRecognition

## 📝 Tanıtım

**SimpleFaceRecognition**, temel yüz tanıma ve tanımlama işlemlerini gerçekleştiren, pratik ve sade bir Windows uygulamasıdır. Görüntü işleme algoritmalarıyla kişilerin yüzlerini algılayıp kaydedebilir, yeni gelen görüntülerde eşleşme olup olmadığını tespit edebilir.

---

## 🚀 Özellikler

- 📷 Kameradan veya dosyadan yüz algılama
- 🗂️ Yüz veritabanı oluşturma ve yönetme
- 🔍 Yüz tanıma ve eşleşme işlemleri
- 📝 Kaydedilen yüzler için profil ve meta bilgi tutma
- ⚡ Hızlı ve sade arayüz (WinForms veya WPF)
- 📊 Tanıma sonucu ve geçmiş kayıtların görüntülenmesi

---

## 🏗️ Teknik Altyapı

- **Platform:** C# (.NET, Windows Forms veya WPF)
- **Görüntü İşleme:** OpenCV, EmguCV veya Accord.NET gibi kütüphanelerle yüz tanıma
- **Veritabanı:** Yerel dosya tabanlı, SQLite veya dahili koleksiyon
- **Ana Bileşenler:**
  - Kamera entegrasyonu ve canlı görüntü akışı
  - Yüz algılama ve işaretleme
  - Yüz kayıt ve karşılaştırma algoritmaları
  - Kullanıcı arayüzü
- **Ekstra:**  
  - Hata, log ve istatistik mekanizması
  - Genişletilebilir ve modüler yapı

---

## 📂 Klasör Yapısı

```
SimpleFaceRecognition/
├── Models/           # Yüz ve profil modelleri
├── FaceDetection/    # Algoritmalar ve yardımcı sınıflar
├── Database/         # Yerel veri yönetimi
├── UI/               # Arayüz katmanı (Form, WPF, Controls)
├── Logging/          # Log ve hata yönetimi
├── Config/           # Ayar ve konfigürasyon dosyaları
├── Program.cs        # Uygulama girişi
└── ...
```

---

## ⚙️ Kurulum & Kullanım

1. Projeyi klonlayın veya indirin.
2. Gerekli NuGet/OpenCV kütüphanelerini yükleyin.
3. Kamerayı bağlayın veya görsel dosya seçin.
4. Visual Studio ile projeyi açıp çalıştırın.
5. Yüz kaydı ekleyin ve tanıma işlemlerini başlatın.

---

## 🤝 Katkı

Katkı sağlamak için projeyi forklayabilir ve pull request gönderebilirsiniz.

---

## 📄 Lisans

Bu proje MIT lisansı ile sunulmuştur.
