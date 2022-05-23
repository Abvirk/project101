using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Emgu.CV;
using Emgu.CV.Structure;
using Emgu.CV.Face;
using Emgu.CV.CvEnum;
using System.IO;
using System.Threading;
using System.Diagnostics;
using System.Media;

namespace Project001
{
    public partial class Form1 : Form
    {
        #region Properties

        private VideoCapture videoCapture = null;
        private VideoCapture faceRecognizeCapture = null;

        private Image<Bgr, Byte> currentFrame = null;
        Mat frame = new Mat();
        private bool facesDetectionEnabled = true;
        CascadeClassifier faceCasacdeClassifier = new CascadeClassifier("D:\\Learning\\WindowForms\\Project001\\haarcascade_frontalface_alt_tree.xml");

        List<Mat> TrainedFaces = new List<Mat>();
        List<int> PersonsLabes = new List<int>();
        EigenFaceRecognizer recognizer;
        List<string> PersonsNames = new List<string>();

        System.Windows.Forms.Timer myTimer = new System.Windows.Forms.Timer();

        System.Windows.Forms.Timer alarmTimmer = new System.Windows.Forms.Timer();

        TimeSpan timeleft = TimeSpan.FromSeconds(10);
        TimeSpan alarmTimerLeft = TimeSpan.FromSeconds(10);

        bool saveImages = false;
        bool playAlarm = false;

        #endregion

        public Form1()
        {
            InitializeComponent();
            myTimer.Interval = 1000;
            myTimer.Tick += new EventHandler(TimerEventProcessor);

            alarmTimmer.Interval = 1000;
            alarmTimmer.Tick += new EventHandler(AlarmTimerEventProcessor);
        }

        private void TimerEventProcessor(Object myObject, EventArgs myEventArgs)
        {
            if (timeleft.Seconds > 0)
            {
                timeleft = TimeSpan.FromSeconds(timeleft.Seconds - 1);
                lblTimmer.Text = timeleft.ToString("ss");// + " Mins";
            }
            else
            {
                myTimer.Stop();
                //label3.Text = "Time Up";
                btnAddPerson.Enabled = true;
                tbPersonName.Enabled = true;
                btnStartRecognization.Enabled = true;
                saveImages = false;
                tbPersonName.Text = string.Empty;

                timeleft = TimeSpan.FromSeconds(10);
            }
        }


        private void AlarmTimerEventProcessor(Object myObject, EventArgs myEventArgs)
        {
            if (alarmTimerLeft.Seconds > 0)
            {
                alarmTimerLeft = TimeSpan.FromSeconds(alarmTimerLeft.Seconds - 1);
                playAlarm = false;
                lblAlarm.Text = alarmTimerLeft.ToString("ss") + " For Alarm.";
            }
            else
            {
                alarmTimmer.Stop();
                playAlarm = true;
                btnStartRecognization.Enabled = true;
                btnAddPerson.Enabled = true;
                alarmTimerLeft = TimeSpan.FromSeconds(10);
            }
        }


        private bool TrainModelImages()
        {
            int ImagesCount = 0;
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
                    TrainedFaces.Add(trainedImage.Mat);
                    PersonsLabes.Add(ImagesCount);
                    string name = file.Split('\\').Last().Split('_')[0];
                    PersonsNames.Add(name);
                    ImagesCount++;
                    Debug.WriteLine(ImagesCount + ". " + name);

                }

                if (TrainedFaces.Count() > 0)
                {
                    // recognizer = new EigenFaceRecognizer(ImagesCount,Threshold);
                    //recognizer = new EigenFaceRecognizer(ImagesCount, Threshold);
                    //recognizer.Train(TrainedFaces.ToArray(), PersonsLabes.ToArray());
                    recognizer = new EigenFaceRecognizer(PersonsLabes.Count);
                    recognizer.Train(TrainedFaces.ToArray(), PersonsLabes.ToArray());
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                //isTrained = false;
                //MessageBox.Show("Error in Train Images: " + ex.Message);
                return false;
            }

        }

        private void btnAddPerson_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tbPersonName.Text))
            {
                MessageBox.Show("Please person name.");
                return;
            }
            btnAddPerson.Enabled = false;
            btnStartRecognization.Enabled = false;

            saveImages = true;

            if (videoCapture != null) videoCapture.Dispose();
            videoCapture = new VideoCapture();
            videoCapture.ImageGrabbed += ProcessFrame;
            videoCapture.Start();

            myTimer.Start();
            lblTimmer.Text = timeleft.ToString("ss");
        }

        private void ProcessFrame(object sender, EventArgs e)
        {
            //Step 1: Video Capture
            if (videoCapture != null && videoCapture.Ptr != IntPtr.Zero)
            {
                videoCapture.Retrieve(frame, 0);
                currentFrame = frame.ToImage<Bgr, Byte>().Resize(pictureBox1.Width, pictureBox1.Height, Inter.Cubic);

                ////Step 2: Face Detection
                if (facesDetectionEnabled)
                {

                    //Convert from Bgr to Gray Image
                    Mat grayImage = new Mat();
                    CvInvoke.CvtColor(currentFrame, grayImage, ColorConversion.Bgr2Gray);
                    //Enhance the image to get better result
                    CvInvoke.EqualizeHist(grayImage, grayImage);

                    Rectangle[] faces = faceCasacdeClassifier.DetectMultiScale(grayImage, 1.1, 3, Size.Empty, Size.Empty);
                    //If faces detected
                    if (faces.Length > 0)
                    {

                        foreach (var face in faces)
                        {
                            //Draw square around each face 
                            CvInvoke.Rectangle(currentFrame, face, new Bgr(Color.Red).MCvScalar, 2);

                            //Step 3: Add Person 

                            //Assign the face to the picture Box face picDetected
                            Image<Bgr, Byte> resultImage = currentFrame.Convert<Bgr, Byte>();
                            resultImage.ROI = face;
                            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
                            pictureBox2.Image = resultImage.ToBitmap();


                            //We will create a directory if does not exists!
                            string path = Directory.GetCurrentDirectory() + @"\TrainedImages";
                            if (!Directory.Exists(path))
                                Directory.CreateDirectory(path);
                            // we will save 10 images with delay a second for each image
                            //  to avoid hang GUI we will create a new task

                            if (saveImages)
                            {
                                resultImage.Resize(200, 200, Inter.Cubic).Save(path + @"\" + tbPersonName.Text + "_" + DateTime.Now.ToString("dd-mm-yyyy-hh-mm-ss") + ".jpg");
                                //Task.Factory.StartNew(() =>
                                //{
                                //    for (int i = 0; i < 10; i++)
                                //    {
                                //        // resize the image then saving it
                                //        resultImage.Resize(200, 200, Inter.Cubic).Save(path + @"\" + tbPersonName.Text + "_" + DateTime.Now.ToString("dd-mm-yyyy-hh-mm-ss") + ".jpg");
                                //        Thread.Sleep(1000);
                                //    }
                                //});
                            }
                        }
                    }
                }

                //Render the video capture into the Picture Box picCapture
                pictureBox1.Image = currentFrame.ToBitmap();
            }

            //Dispose the Current Frame after processing it to reduce the memory consumption.
            if (currentFrame != null)
                currentFrame.Dispose();
        }

        private void btnStartRecognization_Click(object sender, EventArgs e)
        {
            if (faceRecognizeCapture != null) faceRecognizeCapture.Dispose();

            //TrainModelImages();
            btnStartRecognization.Enabled = false;
            btnAddPerson.Enabled = false;

            faceRecognizeCapture = new VideoCapture();
            faceRecognizeCapture.ImageGrabbed += ProcessReconizationFrame;
            faceRecognizeCapture.Start();

            alarmTimmer.Start();
            lblAlarm.Text = alarmTimerLeft.ToString("ss");
        }

        private void ProcessReconizationFrame(object sender, EventArgs e)
        {
            //Step 1: Video Capture
            if (faceRecognizeCapture != null && faceRecognizeCapture.Ptr != IntPtr.Zero)
            {
                faceRecognizeCapture.Retrieve(frame, 0);
                currentFrame = frame.ToImage<Bgr, Byte>().Resize(pictureBox1.Width, pictureBox1.Height, Inter.Cubic);


                ////Step 2: Face Detection
                //Convert from Bgr to Gray Image
                Mat grayImage = new Mat();
                CvInvoke.CvtColor(currentFrame, grayImage, ColorConversion.Bgr2Gray);
                //Enhance the image to get better result
                CvInvoke.EqualizeHist(grayImage, grayImage);

                Rectangle[] faces = faceCasacdeClassifier.DetectMultiScale(grayImage, 1.1, 3, Size.Empty, Size.Empty);
                //If faces detected
                if (faces.Length > 0)
                {

                    foreach (var face in faces)
                    {
                        //Draw square around each face 
                        CvInvoke.Rectangle(currentFrame, face, new Bgr(Color.Red).MCvScalar, 2);

                        //Step 3: Add Person 

                        //Assign the face to the picture Box face picDetected
                        Image<Bgr, Byte> resultImage = currentFrame.Convert<Bgr, Byte>();
                        resultImage.ROI = face;
                        pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
                        pictureBox2.Image = resultImage.ToBitmap();

                        // Step 5: Recognize the face 

                        Image<Gray, Byte> grayFaceResult = resultImage.Convert<Gray, Byte>().Resize(200, 200, Inter.Cubic);

                        CvInvoke.EqualizeHist(grayFaceResult, grayFaceResult);

                        if (recognizer is null)
                        {
                            CvInvoke.PutText(currentFrame, "Unknown", new Point(face.X - 2, face.Y - 2),
                              FontFace.HersheyComplex, 1.0, new Bgr(Color.Orange).MCvScalar);
                            CvInvoke.Rectangle(currentFrame, face, new Bgr(Color.Red).MCvScalar, 2);
                        }
                        else
                        {
                            var result = recognizer.Predict(grayFaceResult);
                            pictureBox1.Image = grayFaceResult.ToBitmap();

                            Debug.WriteLine(result.Label + ". Distance ==> " + result.Distance);

                            //Here results found known faces
                            if (result.Label != -1 && result.Distance < 4000)// 
                            {
                                //pictureBox2.Image = TrainedFaces[result.Label].ToBitmap();
                                //Debug.WriteLine(result.Label + ". " + result.Distance);

                                //Remove Event
                                faceRecognizeCapture.ImageGrabbed -= ProcessReconizationFrame;

                                CvInvoke.PutText(currentFrame, PersonsNames[result.Label], new Point(face.X - 2, face.Y - 2),
                                    FontFace.HersheyComplex, 1.0, new Bgr(Color.Orange).MCvScalar);
                                CvInvoke.Rectangle(currentFrame, face, new Bgr(Color.Green).MCvScalar, 2);

                                //lblPersonName.Text = $"The person is detected and name is ({PersonsNames[result.Label]})";

                                MessageBox.Show($"Person is detected ({PersonsNames[result.Label]}).", "Message");
                            }
                            //here results did not found any know faces
                            else
                            {
                                if (playAlarm)
                                {
                                    SoundPlayer simpleSound = new SoundPlayer(@"c:\Windows\Media\Alarm06.wav");
                                    simpleSound.Play();

                                    faceRecognizeCapture.ImageGrabbed -= ProcessReconizationFrame;
                                }
                                CvInvoke.PutText(currentFrame, "Unknown", new Point(face.X - 2, face.Y - 2),
                                    FontFace.HersheyComplex, 1.0, new Bgr(Color.Orange).MCvScalar);
                                CvInvoke.Rectangle(currentFrame, face, new Bgr(Color.Red).MCvScalar, 2);

                            }
                        }
                    }
                }
                //Render the video capture into the Picture Box picCapture
                pictureBox1.Image = currentFrame.ToBitmap();

            }

            //Dispose the Current Frame after processing it to reduce the memory consumption.
            if (currentFrame != null)
                currentFrame.Dispose();

        }

        private void btnTrainModel_Click(object sender, EventArgs e)
        {
            TrainModelImages();
        }
    }
}