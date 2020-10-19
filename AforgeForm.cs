using AForge.Video.DirectShow;
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
using Emgu.CV.Aruco;
using System.Drawing.Printing;
using Emgu.CV.Util;
using Emgu.CV.Structure;
using Emgu.CV.CvEnum;
using System.Threading;

namespace Aruco
{
    public partial class AforgeForm : Form
    {
        FilterInfoCollection videoDevices;
        VideoCaptureDevice videoSource;
        object LockUI = new Object();

        private DetectorParameters _detectorParameters;

        private VectorOfInt _allIds = new VectorOfInt();
        private VectorOfVectorOfPointF _allCorners = new VectorOfVectorOfPointF();
        private VectorOfInt _markerCounterPerFrame = new VectorOfInt();
        private Size _imageSize = Size.Empty;

        Mat _frame = new Mat();
        Mat _frameCopy = new Mat();

        Mat _cameraMatrix = new Mat();
        Mat _distCoeffs = new Mat();
        Mat rvecs = new Mat();
        Mat tvecs = new Mat();

        private bool _useThisFrame = false;

        int markersX = 5;
        int markersY = 7;
        int markersLength = 80;
        int markersSeparation = 30;
        Image bmIm;

        private Dictionary _dict;

        private Dictionary ArucoDictionary
        {
            get
            {
                if (_dict == null)
                    _dict = new Dictionary(Dictionary.PredefinedDictionaryName.Dict4X4_100);
                return _dict;
            }

        }

        private GridBoard _gridBoard;
        private GridBoard ArucoBoard
        {
            get
            {
                if (_gridBoard == null)
                {
                    _gridBoard = new GridBoard(markersX, markersY, markersLength, markersSeparation, ArucoDictionary);
                }
                return _gridBoard;
            }
        }

        public AforgeForm()
        {
            InitializeComponent();

            _detectorParameters = DetectorParameters.GetDefault();

            try
            {
                videoDevices = new FilterInfoCollection(FilterCategory.VideoInputDevice);

                if (videoDevices.Count == 0)
                {
                    throw new Exception();
                }

                for (int i = 1, n = videoDevices.Count; i <= n; i++)
                {
                    string cameraName = i + " : " + videoDevices[i - 1].Name;
                    comboBoxCameraList.Items.Add(cameraName);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void buttonStartCamera_Click(object sender, EventArgs e)
        {
            StartCamera();
            buttonStartCamera.Enabled = false;
            buttonStopCamera.Enabled = true;
        }

        private void buttonStopCamera_Click(object sender, EventArgs e)
        {
            StopCamera();
            buttonStartCamera.Enabled = true;
            buttonStopCamera.Enabled = false;
        }
        private void StartCamera()
        {
            videoSource = new VideoCaptureDevice(videoDevices[comboBoxCameraList.SelectedIndex].MonikerString);
            videoSource.NewFrame += VideoSource_NewFrame;
            videoSource.Start();
        }
        private void StopCamera()
        {

            try
            {
                videoSource.SignalToStop();
                Thread.Sleep(1000);
                videoSource.WaitForStop();
                pictureBoxVideo.Image = null;
            }
            catch (Exception)
            {

                throw;
            }


        }
        private void CalibrateCamera()
        {
            int totalPoints = _markerCounterPerFrame.ToArray().Sum();
            if (totalPoints > 0)
            {
                double repError = ArucoInvoke.CalibrateCameraAruco(_allCorners, _allIds, _markerCounterPerFrame, ArucoBoard, _imageSize,
                   _cameraMatrix, _distCoeffs, null, null, CalibType.Default, new MCvTermCriteria(30, double.Epsilon));

                UpdateMessage(String.Format("Camera calibration completed with reprojection error: {0}", repError));
                _allCorners.Clear();
                _allIds.Clear();
                _markerCounterPerFrame.Clear();
                _imageSize = Size.Empty;

            }
        }

        private void VideoSource_NewFrame(object sender, AForge.Video.NewFrameEventArgs eventArgs)
        {
            if (pictureBoxVideo.Image != null)
                pictureBoxVideo.Image.Dispose();
            if (eventArgs.Frame != null)
            {
                Image<Bgr, Byte> frameimage = eventArgs.Frame.ToImage<Bgr, Byte>().Clone();
                _frameCopy = frameimage.Mat;

                using (VectorOfInt ids = new VectorOfInt())
                using (VectorOfVectorOfPointF corners = new VectorOfVectorOfPointF())
                using (VectorOfVectorOfPointF rejected = new VectorOfVectorOfPointF())
                {
                    //DetectorParameters p = DetectorParameters.GetDefault();
                    ArucoInvoke.DetectMarkers(_frameCopy, ArucoDictionary, corners, ids, _detectorParameters, rejected);

                    if (ids.Size > 0)
                    {
                        ArucoInvoke.RefineDetectedMarkers(_frameCopy, ArucoBoard, corners, ids, rejected, null, null, 10, 3, true, null, _detectorParameters);
                        //cameraButton.Text = "Calibrate camera";
                        this.Invoke((Action)delegate
                        {
                            useThisFrameButton.Enabled = true;
                        });
                        ArucoInvoke.DrawDetectedMarkers(_frameCopy, corners, ids, new MCvScalar(0, 255, 0));

                        if (!_cameraMatrix.IsEmpty && !_distCoeffs.IsEmpty)
                        {
                            ArucoInvoke.EstimatePoseSingleMarkers(corners, markersLength, _cameraMatrix, _distCoeffs, rvecs, tvecs);
                            for (int i = 0; i < ids.Size; i++)
                            {
                                using (Mat rvecMat = rvecs.Row(i))
                                using (Mat tvecMat = tvecs.Row(i))
                                using (VectorOfDouble rvec = new VectorOfDouble())
                                using (VectorOfDouble tvec = new VectorOfDouble())
                                {
                                    double[] values = new double[3];
                                    rvecMat.CopyTo(values);
                                    rvec.Push(values);
                                    tvecMat.CopyTo(values);
                                    tvec.Push(values);
                                    if (ids.Size == 1) UpdatePosition(tvec, rvec);

                                    ArucoInvoke.DrawAxis(_frameCopy, _cameraMatrix, _distCoeffs, rvec, tvec,
                                       markersLength * 0.5f);

                                }
                            }
                        }

                        if (_useThisFrame)
                        {
                            _allCorners.Push(corners);
                            _allIds.Push(ids);
                            _markerCounterPerFrame.Push(new int[] { corners.Size });
                            _imageSize = _frameCopy.Size;
                            UpdateMessage(String.Format("Using {0} points", _markerCounterPerFrame.ToArray().Sum()));
                            _useThisFrame = false;
                            CalibrateCamera();
                        }
                    }
                    else
                    {
                        this.Invoke((Action)delegate
                        {
                            useThisFrameButton.Enabled = false;
                        });

                        //cameraButton.Text = "Stop Capture";
                    }
                    pictureBoxVideo.Image = _frameCopy.ToBitmap();
                }
            }
        }

        private void comboBoxCameraList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxCameraList.SelectedItem != null)
            {
                buttonStartCamera.Enabled = true;
            }
        }

        private void UpdateMessage(String message)
        {
            if (this.InvokeRequired)
            {
                this.Invoke((Action)delegate { UpdateMessage(message); });
                return;
            }

            messageLabel.Text = message;
        }
        private void UpdatePosition(VectorOfDouble tValues, VectorOfDouble rValues)
        {

            if (this.InvokeRequired)
            {
                this.Invoke(new Action(() =>
                {
                    textBoxX.Text = tValues[0].ToString();
                    textBoxY.Text = tValues[1].ToString();
                    textBoxZ.Text = tValues[2].ToString();

                    textBoxU.Text = rValues[0].ToString();
                    textBoxV.Text = rValues[1].ToString();
                    textBoxW.Text = rValues[2].ToString();
                }
                ));
                return;
            }
            else
            {
                textBoxX.Text = tValues[0].ToString();
                textBoxY.Text = tValues[1].ToString();
                textBoxZ.Text = tValues[2].ToString();

                textBoxU.Text = rValues[0].ToString();
                textBoxV.Text = rValues[1].ToString();
                textBoxW.Text = rValues[2].ToString();
            }
        }

        private void buttonPrintboardAruco_Click(object sender, EventArgs e)
        {
            Size imageSize = new Size();

            int margins = markersSeparation;
            imageSize.Width = markersX * (markersLength + markersSeparation) - markersSeparation + 2 * margins;
            imageSize.Height = markersY * (markersLength + markersSeparation) - markersSeparation + 2 * margins;
            int borderBits = 1;

            Mat boardImage = new Mat();
            ArucoBoard.Draw(imageSize, boardImage, margins, borderBits);
            bmIm = boardImage.ToBitmap();
            PrintImage();
        }

        private void PrintImage()
        {
            PrintDocument pd = new PrintDocument();

            //pd.DefaultPageSettings.Margins = new Margins(0, 0, 0, 0);
            //pd.OriginAtMargins = false;
            //pd.DefaultPageSettings.Landscape = true;

            pd.PrintPage += new PrintPageEventHandler(pd_PrintPage);

            PrintPreviewDialog printPreviewDialog1 = new PrintPreviewDialog();

            printPreviewDialog1.Document = pd;
            //printPreviewDialog1.AutoScale = true;
            printPreviewDialog1.ShowDialog();
        }

        void pd_PrintPage(object sender, PrintPageEventArgs e)
        {
            double cmToUnits = 100 / 2.54;
            e.Graphics.DrawImage(bmIm, 0, 0, (float)(18.75 * cmToUnits), (float)(26.25 * cmToUnits));
        }

        private void useThisFrameButton_Click(object sender, EventArgs e)
        {
            _useThisFrame = true;
        }
    }
}
