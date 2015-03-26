using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;

namespace KinectWheels_Installer
{
    public partial class Form1 : Form
    {
        bool isKinectSDK = false;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            OutputBox.SelectionAlignment = HorizontalAlignment.Center;
            OutputBox.Text = "Press start to begin installing Kinect Wheels";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string kinectAddress = @"C:\Program Files\Microsoft SDKs\Kinect\v1.8\";
            if (File.Exists(@"C:\Program Files\Microsoft SDKs\Kinect\v1.8\KinectCpp.dll") && File.Exists(kinectAddress + "Redist.txt"))
            {
                OutputBox.Text = "Kinect Wheels already installed";
            }
            else
            {
                if (File.Exists(kinectAddress+ "Redist.txt"))
                {
                    OutputBox.Text = "Kinect SDK found";
                    isKinectSDK = true;
                }
                else
                {
                    OutputBox.Text = "Kinect SDK not found";
                    try
                    {
                        Process p = new Process();
                        p.StartInfo.FileName = "Content\\KinectSDK-v1.8-Setup.exe";
                        OutputBox.Text = "Running the kinect SDK";
                        p.Start();
                        p.WaitForExit();
                        OutputBox.Text = "SDK installed";
                        if (Directory.Exists(kinectAddress))
                        {
                            OutputBox.Text = "Kinect SDK found";
                            isKinectSDK = true;
                        }
                    }
                    catch (Exception exc)
                    {
                        OutputBox.Text = "The SDK installer is missing from content directory";
                    }   
                }
                if (isKinectSDK)
                {
                    if (File.Exists("Content\\KinectCpp.dll")&&!File.Exists(@"C:\Program Files\Microsoft SDKs\Kinect\v1.8\KinectCpp.dll"))
                    {
                        File.Copy("Content\\KinectCpp.dll", @"C:\Program Files\Microsoft SDKs\Kinect\v1.8\KinectCpp.dll");
                        OutputBox.Text = "DLL copied, install complete";
                    }
                    else
                    {
                        if(!File.Exists(@"C:\Program Files\Microsoft SDKs\Kinect\v1.8\KinectCpp.dll"))
                            OutputBox.Text = "KinectCpp.dll missing form content directory";
                        else
                        OutputBox.Text = "Installation Complete";
                    }
                }
            }
        }
        private void OutputBox_TextChanged(object sender, EventArgs e)
        {
            
        }
    }
}
