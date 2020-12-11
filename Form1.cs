using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
using Emgu.CV.Util;
using System.IO.Ports;


//technically Final Project Now
//Progressive from Lab 5 to now
//Incorporates Lab 5,6,7,8,10 and possibly lab 4 material
namespace Lab5
{

    public partial class Form1 : Form
    {
        //setup 
        SerialPort arduinoSerial = new SerialPort();//serial port name
        VideoCapture _capture; //start getting webcam image
        Thread _captureThread; // thread for webcam image
        Thread serialMonitoringThread; //thread for serial monitoring

        //Boolian value for waiting on robot code to process
        public bool ArduinoWantsLocation = true;
        //array for location and shape of identiied contour
        public double[,] RobotShapes = new double[100, 3];
        

        //initial thresholds
        private int BMin = 70;
        private int BMax = 255;
        private int CMin = 170;
        private int CMax = 255;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            _capture = new VideoCapture(1); //webcam selection
            _captureThread = new Thread(ProcessImage); //call image processing
            _captureThread.Start(); //start thread           

            try
            {
                arduinoSerial.PortName = "COM4";//com port
                arduinoSerial.BaudRate = 115200; //baud rate of arduino
                arduinoSerial.Open(); //open

                //get rid of garbage in buffer
                arduinoSerial.DiscardOutBuffer();
                arduinoSerial.DiscardInBuffer();
               
                //Thread for seial monitoring
                serialMonitoringThread = new Thread(MonitorSerialData);
                serialMonitoringThread.Start(); //start thread
            }
           
            //incase we dont open correctly
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Initializing COM Port"); //ardunio not connected restart if this happens
                Close();
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            _captureThread.Abort(); //close form
            serialMonitoringThread.Abort();
        }

        private void ProcessImage()
        {
            while (_capture.IsOpened)
            {
                // frame maintenance
                Mat sourceFrame = _capture.QueryFrame();
                // resize to PictureBox aspect ratio
                int newHeight = (sourceFrame.Size.Height * sourcePictureBox.Size.Width) / sourceFrame.Size.Width;
                Size newSize = new Size(sourcePictureBox.Size.Width, newHeight); 
                CvInvoke.Resize(sourceFrame, sourceFrame, newSize);
                //display raw webcam image on form
                sourcePictureBox.Image = sourceFrame.Bitmap;

                // new mat for each image cloning
                var binaryImage = new Mat();
                var blurredImage = new Mat(); 
                var cannyImage = new Mat();
                var decoratedImage = new Mat();

                //Binary threshold source image & display it
                CvInvoke.CvtColor(sourceFrame, binaryImage, ColorConversion.Bgr2Gray);
                CvInvoke.Threshold(binaryImage, binaryImage, BMin, BMax, Emgu.CV.CvEnum.ThresholdType.Binary);
                BinaryImageBox.Image = binaryImage.Bitmap;

                //Gaussian Blur of binary image & display it
                //CvInvoke.GaussianBlur(binaryImage, blurredImage, new Size(5, 5), 0);
                //blurPictureBox.Image = blurredImage.Bitmap;

                // convert to B/W
                // CvInvoke.CvtColor(blurredImage, blurredImage, typeof(Bgr), typeof(Gray)); //not sure if iI need this already in black and white
                //Canny process and display it
                //CvInvoke.Canny(blurredImage, cannyImage, CMin, CMax);
                //cannyPictureBox.Image = cannyImage.Bitmap;


                // make a copy of the canny image, convert it to color for decorating:
                CvInvoke.CvtColor(binaryImage, decoratedImage, ColorConversion.Gray2Bgr);
                
                // find contours:
                using (VectorOfVectorOfPoint contours = new VectorOfVectorOfPoint())
                {
                    // Build list of contours
                    CvInvoke.FindContours(binaryImage, contours, null, RetrType.List, ChainApproxMethod.ChainApproxSimple);

                    //Create array for shape declaration
                    string[] Shape = new string[2];
                    Shape[0] = "Square";
                    Shape[1] = "Triangle";
                     //create varaible to store number of shapes on paper
                    int shapesFound = 0; //This number will always be larger then the actual number becasue dots and orgin drawing are shapes as well 
                    

                    for (int i = 0; i < contours.Size; i++)
                    {
                        VectorOfPoint contour = contours[i];
                        //find area of the countour
                        double Area = CvInvoke.ContourArea(contours[i]);
                        //get rid of garabge contours outside of my desired areas 
                        if (Area > 50 && Area < 3000)
                        {
                            //square instance
                            if (Area > 700)
                            {
                                //Draw square, declare bounding box, call marking function
                                CvInvoke.Polylines(decoratedImage, contour, true, new Bgr(Color.Red).MCvScalar);
                                Rectangle boundingBox = CvInvoke.BoundingRectangle(contours[i]);
                               
                                MarkDetectedObject(decoratedImage, contours[i], boundingBox, Shape[0],0,shapesFound);
                            }

                            //traingle instance
                            else
                            {
                                //Draw triangle, declare bounding box, call marking function
                                CvInvoke.Polylines(decoratedImage, contour, true, new Bgr(Color.Green).MCvScalar);
                                Rectangle boundingBox = CvInvoke.BoundingRectangle(contours[i]);
                                MarkDetectedObject(decoratedImage, contours[i], boundingBox, Shape[1],1,shapesFound);
                            }
                           
                            //add to shapes we care about
                            shapesFound++;
                        }
                    }

                    //display final product drawing in picture box for user analysis of issues
                    contourPictureBox.Image = decoratedImage.Bitmap;

                    //edit label for number of shapes on page
                    Invoke(new Action(() =>
                    {
                        contourLabel.Text = $"There are {shapesFound} contours detected";
                    }));

                    //If arduino wants new coordinates then send them if not lets wait for it to need more
                    if (ArduinoWantsLocation == true && shapesFound > 0)
                    {
                       RobotShapeCoordinates(RobotShapes[0, 0], RobotShapes[0, 1], RobotShapes[0, 2]);
                       ArduinoWantsLocation = false;
                    }
                }
            }
        }

        private void MarkDetectedObject(Mat frame, VectorOfPoint contour, Rectangle boundingBox, string shape, int Sort, int Found)
        {
            //Finding center of bounding box or shape, this should be close enough for what I need
            Point center = new Point(boundingBox.X + boundingBox.Width / 2, boundingBox.Y + boundingBox.Height / 2);
            // Drawing contour and dot in center
            if (shape == "Square")
            {
                //Draw Square in red with dot in the center
                CvInvoke.Polylines(frame, contour, true, new Bgr(Color.Red).MCvScalar);
                CvInvoke.Circle(frame, center, 1, new Bgr(Color.Red).MCvScalar);
            }
            else
            {
                //Draw Triangle in green with dot in the center
                CvInvoke.Polylines(frame, contour, true, new Bgr(Color.Green).MCvScalar);
                CvInvoke.Circle(frame, center, 1, new Bgr(Color.Green).MCvScalar);
            }

            //Plot the origin of reference for user and debugging purposes
            Point origin = new Point(0, 0);
            CvInvoke.Circle(frame,origin, 10, new Bgr(Color.Orange).MCvScalar);
            //After drawing it is clear that the orgin of reference for shapes is the top left corner of the paper furthest from the robot

            // Write information next to marked object
            var info = new string[]
            {
                    //I only wnat the shape name below to limit clutter on screen
                    $"{shape}",
            };

            //writing text below shapes
            WriteMultilineText(frame, info, new Point(center.X, boundingBox.Bottom + 12));


            //Convert Camera pixels to length
            //Pixels per x and y
            double CameraX = frame.Width;
            double CameraY = frame.Height;

            //Convert pixel numbers to length in 1/4 inch intervals
            double CoordinateX = Math.Round(44 * center.X / CameraX) ;
            double CoordinateY = Math.Round(34 * center.Y / CameraY) ;

            //Store center of shape values for robot in terms of length not pixels
            //X
            RobotShapes[Found , 0] = CoordinateX;
            //Y
            RobotShapes[Found, 1] = CoordinateY;
            //Shape
            RobotShapes[Found, 2] = Sort;
        }

        private void WriteMultilineText(Mat frame, string[] lines, Point origin)
        {
            //Wrtie text below shapes in Blue
            for (int i = 0; i < lines.Length; i++)
            {
                int y = i * 10 + origin.Y; // Moving down on each line
                CvInvoke.PutText(frame, lines[i], new Point(origin.X, y),
                FontFace.HersheyPlain, 0.8, new Bgr(Color.Blue).MCvScalar);
            }
        }

        private void RobotShapeCoordinates(double X, double Y,double Sort)
        {
           //convert center of coordinates to bytes
            byte[] buffer = new byte[5] {Encoding.ASCII.GetBytes("<")[0],
                                         Convert.ToByte(X),
                                         Convert.ToByte(Y),
                                         Convert.ToByte(Sort),
                                         Encoding.ASCII.GetBytes(">")[0]};
            //Send them to robot 
            arduinoSerial.Write(buffer, 0, 5);
        }

        private void MonitorSerialData()
        {
            while (true)
            {
                // block until \n character is received, extract command data
                string msg = arduinoSerial.ReadLine();
                // confirm the string has both < and > characters
                if (msg.IndexOf("<") == -1 || msg.IndexOf(">") == -1)
                {
                    continue;
                }
                // remove everything before (and including) the < character
                msg = msg.Substring(msg.IndexOf("<")+1);
                // remove everything after (and including) the > character
                msg = msg.Remove(msg.IndexOf(">"));
                // if the resulting string is empty, disregard and move on
                if (msg.Length == 0)
                {
                    continue;
                }
                // parse the command
                if (msg.Substring(0, 1) == "S")
                {
                    ArduinoWantsLocation = false;
                }
                else if (msg.Substring(0, 1) == "P")
                {
                    ArduinoWantsLocation = true;
                }
                else
                {
                    Invoke(new Action(() =>
                    {
                        xLabel.Text = $"X:{msg.Substring(1)} ";
                    }));
                   
                }
            }
        }

        private void BinaryMintrackBar1_Scroll(object sender, EventArgs e)
        {
            //Binary Min threshold Value based on trackbar value
            BMin = BinaryMintrackBar1.Value;
        }

        private void BinaryMaxtrackBar2_Scroll(object sender, EventArgs e)
        {
            //Binary Max threshold Value based on trackbar value
            BMax = BinaryMaxtrackBar2.Value;
        }

        private void CannyMintrackBar5_Scroll(object sender, EventArgs e)
        {
            //Canny Min threshold Value based on trackbar value
            CMin = CannyMintrackBar5.Value;
        }

        private void CannyMaxtrackBar6_Scroll(object sender, EventArgs e)
        {
            //Canny Max threshold Value based on trackbar value
            CMax = CannyMaxtrackBar6.Value;
        }
    }
}
