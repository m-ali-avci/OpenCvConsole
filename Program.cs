using System;
using OpenCvSharp;

namespace OpenCV_C73
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Kamera başlatılıyor...");
            Console.WriteLine("ESC: çıkış | S: fotoğraf kaydet | G: gri tonlama değiştir | F: yüz tespiti aç/kapat");

            VideoCapture kamera = new VideoCapture(0);
            if (!kamera.IsOpened())
            {
                Console.WriteLine("Kamera bulunamadı!");
                Console.ReadKey();
                return;
            }

            Mat kare = new Mat();
            Window pencere = new Window("Kamera");

            bool griMod = false; // gri tonlama açık mı?
            bool yuzMod = false; // yüz tespiti açık mı?
            CascadeClassifier yuzAlgilayici = new CascadeClassifier("haarcascade_frontalface_default.xml");

            while (true)
            {
                kamera.Read(kare);
                if (kare.Empty())
                    break;

                // gri mod aktifse siyah-beyaz yap
                if (griMod)
                {
                    Cv2.CvtColor(kare, kare, ColorConversionCodes.BGR2GRAY);
                    Cv2.CvtColor(kare, kare, ColorConversionCodes.GRAY2BGR); // tekrar renklendir (yüz çizimi için)
                }

                // yüz tespiti aktifse dikdörtgen çiz
                if (yuzMod)
                {
                    Mat gri = new Mat();
                    Cv2.CvtColor(kare, gri, ColorConversionCodes.BGR2GRAY);
                    Rect[] yuzler = yuzAlgilayici.DetectMultiScale(gri, 1.1, 4);
                    foreach (var yuz in yuzler)
                    {
                        Cv2.Rectangle(kare, yuz, new Scalar(0, 0, 255), 2);
                    }
                    gri.Dispose();
                }

                Cv2.ImShow("Kamera", kare);

                int tus = Cv2.WaitKey(1);

                // ESC -> çıkış
                if (tus == 27)
                    break;

                // S -> fotoğraf kaydet
                else if (tus == 's' || tus == 'S')
                {
                    string dosya = "foto_" + DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".jpg";
                    Cv2.ImWrite(dosya, kare);
                    Console.WriteLine("Fotoğraf kaydedildi: " + dosya);
                }

                // G -> gri tonlama aç/kapat
                else if (tus == 'g' || tus == 'G')
                {
                    griMod = !griMod;
                    Console.WriteLine("Gri tonlama modu: " + (griMod ? "AÇIK" : "KAPALI"));
                }

                // F -> yüz tespiti aç/kapat
                else if (tus == 'f' || tus == 'F')
                {
                    yuzMod = !yuzMod;
                    Console.WriteLine("Yüz tespiti: " + (yuzMod ? "AÇIK" : "KAPALI"));
                }
            }

            // kaynakları serbest bırak
            kamera.Release();
            kare.Dispose();
            pencere.Close();
            Cv2.DestroyAllWindows();

            Console.WriteLine("Program kapandı.");
        }
    }
}
