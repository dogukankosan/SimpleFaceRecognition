using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Face;
using Emgu.CV.Structure;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Simple_Face_Recognition_App
{
    public partial class Form1 : Form
    {
        #region Variables
        private Capture videoCapture = null;
        private Image<Bgr, Byte> currentFrame = null;
        private Mat frame = new Mat();
        private bool facesDetectionEnabled = default;
        private CascadeClassifier faceCasacdeClassifier = new CascadeClassifier("haarcascade_frontalface_alt.xml");
        private List<Image<Gray, Byte>> TrainedFaces = new List<Image<Gray, byte>>();
        private List<int> PersonsLabes = new List<int>();
        private bool EnableSaveImage = default;
        private bool isTrained = default;
        private EigenFaceRecognizer recognizer;
        private List<string> PersonsNames = new List<string>();
        #endregion
        public Form1()
        {
            InitializeComponent();
        }
        private void ProcessFrame(object sender, EventArgs e)
        {
            //VİDEO YAKALAMA
            if (videoCapture != null && videoCapture.Ptr != IntPtr.Zero)
            {
                videoCapture.Retrieve(frame, 0);
                currentFrame = frame.ToImage<Bgr, Byte>().Resize(picCapture.Width, picCapture.Height, Inter.Cubic);
                // YÜZ YAKALAMA
                if (facesDetectionEnabled)
                {
                    // GRİYE ÇEVİRME İŞLEMİ
                    Mat grayImage = new Mat();
                    CvInvoke.CvtColor(currentFrame, grayImage, ColorConversion.Bgr2Gray);
                    //GÖRÜNTÜYÜ İYİLEŞTİRME
                    CvInvoke.EqualizeHist(grayImage, grayImage);
                    Rectangle[] faces = faceCasacdeClassifier.DetectMultiScale(grayImage, 1.1, 3, Size.Empty, Size.Empty);
                    //YÜZ ALGILANIRSA
                    if (faces.Length > 0)
                    {
                        foreach (Rectangle face in faces)
                        {
                            //KARE ÇİZER YÜZER
                            CvInvoke.Rectangle(currentFrame, face, new Bgr(Color.Red).MCvScalar, 2);
                            //Step 3: KİŞİYİ EKLE 
                            //YÜZÜ RESME ATAYIN
                            Image<Bgr, Byte> resultImage = currentFrame.Convert<Bgr, Byte>();
                            resultImage.ROI = face;
                            picDetected.SizeMode = PictureBoxSizeMode.StretchImage;
                            picDetected.Image = resultImage.Bitmap;
                            if (EnableSaveImage)
                            {
                                //YOKSA DİZİN OLUŞTUR
                                string path = Directory.GetCurrentDirectory() + @"\TrainedImages";
                                if (!Directory.Exists(path))
                                    Directory.CreateDirectory(path);
                                //10 GÖRÜNTÜ KAYDEDER
                                Task.Factory.StartNew(() =>
                                {
                                    for (byte i = 0; i < 10; i++)
                                    {
                                        //GÖRÜNTÜYÜ BOYUTLANDIR VE DOSYAYA KAYDEDER
                                        resultImage.Resize(200, 200, Inter.Cubic).Save(path + @"\" + txtPersonName.Text + "_" + DateTime.Now.ToString("dd-mm-yyyy-hh-mm-ss") + ".jpg");
                                        Thread.Sleep(1000);
                                    }
                                });
                            }
                            EnableSaveImage = false;
                            if (btnAddPerson.InvokeRequired)
                            {
                                btnAddPerson.Invoke(new ThreadStart(delegate
                                {
                                    btnAddPerson.Enabled = true;
                                }));
                            }
                            // Step 5: YÜZÜ TANIMA İŞLEMİ
                            if (isTrained)
                            {
                                Image<Gray, Byte> grayFaceResult = resultImage.Convert<Gray, Byte>().Resize(200, 200, Inter.Cubic);
                                CvInvoke.EqualizeHist(grayFaceResult, grayFaceResult);
                                FaceRecognizer.PredictionResult result = recognizer.Predict(grayFaceResult);
                                pctNowUser.Image = grayFaceResult.Bitmap;
                                pctOldUser.Image = TrainedFaces[result.Label].Bitmap;
                                Debug.WriteLine(result.Label + ". " + result.Distance);
                                //SONUÇLAR BİLİNEN YÜZÜ BULDU
                                if (result.Label != -1 && result.Distance < 2000)
                                {
                                    CvInvoke.PutText(currentFrame, PersonsNames[result.Label], new Point(face.X - 2, face.Y - 2),
                                        FontFace.HersheyComplex, 1.0, new Bgr(Color.Orange).MCvScalar);
                                    CvInvoke.Rectangle(currentFrame, face, new Bgr(Color.Green).MCvScalar, 2);
                                }
                                //TANIMLANAMAYAN YÜZ
                                else
                                {
                                    CvInvoke.PutText(currentFrame, "Bilinmiyor", new Point(face.X - 2, face.Y - 2),
                                        FontFace.HersheyComplex, 1.0, new Bgr(Color.Orange).MCvScalar);
                                    CvInvoke.Rectangle(currentFrame, face, new Bgr(Color.Red).MCvScalar, 2);
                                }
                            }
                        }
                    }
                }
                //YAKALANAN YÜZÜ PICTUREBOXA AKTAR
                picCapture.Image = currentFrame.Bitmap;
            }
            //BELLEK OPTİMAZYONU İÇİN ÇERVEÇİYİ ATIYOR
            if (currentFrame != null)
                currentFrame.Dispose();
        }
        private void btnAddPerson_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtPersonName.Text))
            {
                btnAddPerson.Enabled = false;
                EnableSaveImage = true;
            }
            else
            {
                MessageBox.Show("LÜTFEN METİN KUTUSUNU BOŞ GEÇMEYİNİZ", "KİŞİ İSMİNİ METİN KUTUSUNA YAZINIZ",MessageBoxButtons.OK,MessageBoxIcon.Error);
                txtPersonName.Focus();
            }
        }
        private void btnTrain_Click(object sender, EventArgs e)
        {
            TrainImagesFromDir();
        }
        private bool TrainImagesFromDir()
        {
            ushort ImagesCount = 0;
            double Threshold = 2000;
            TrainedFaces.Clear();
            PersonsLabes.Clear();
            PersonsNames.Clear();
            try
            {
                string path = Directory.GetCurrentDirectory() + @"\TrainedImages";
                string[] files = Directory.GetFiles(path, "*.jpg", SearchOption.AllDirectories);
                foreach (var file in files)
                {
                    Image<Gray, byte> trainedImage = new Image<Gray, byte>(file).Resize(200, 200, Inter.Cubic);
                    CvInvoke.EqualizeHist(trainedImage, trainedImage);
                    TrainedFaces.Add(trainedImage);
                    PersonsLabes.Add(ImagesCount);
                    string name = file.Split('\\').Last().Split('_')[0];
                    PersonsNames.Add(name);
                    ImagesCount++;
                    Debug.WriteLine(ImagesCount + ". " + name);
                }
                if (TrainedFaces.Count() > 0)
                {
                    recognizer = new EigenFaceRecognizer(ImagesCount, Threshold);
                    recognizer.Train(TrainedFaces.ToArray(), PersonsLabes.ToArray());
                    isTrained = true;
                    return true;
                }
                else
                {
                    isTrained = false;
                    return false;
                }
            }
            catch (Exception ex)
            {
                isTrained = false;
                MessageBox.Show("Kişi Tanıma İşlemi Hatalı: " + ex.Message, "HATALI", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            // VİDEO İŞLEMİNİ BAŞLAT
            if (videoCapture != null) videoCapture.Dispose();
            videoCapture = new Capture();
            Application.Idle += ProcessFrame;
            facesDetectionEnabled = true;
        }
        private void txtPersonName_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (!Char.IsLetterOrDigit(ch) || ch >= 128 || ch == 305 || ch == 304 || ch == 287 || ch == 286 ||
              ch == 351 || ch == 350 || ch == 231 || ch == 199 || ch == 252 || ch == 220 || ch == 246 || ch == 214)
            {
                if (ch != 8)
                    e.Handled = true;
            }
        }
    }
}