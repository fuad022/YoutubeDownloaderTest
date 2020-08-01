using System;
using System.IO;
using System.Windows.Forms;
using VideoLibrary;

namespace YoutubeDownloaderTest
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            using(FolderBrowserDialog fbd = new FolderBrowserDialog() { Description = "Select your path" })
            {
                if(fbd.ShowDialog() == DialogResult.OK)
                {
                    var youtube = YouTube.Default;
                    var video = await youtube.GetVideoAsync(textBox1.Text);
                    //File.WriteAllBytes(fbd.SelectedPath + @"\" + video.FullName + ".mp3", await video.GetBytesAsync());
                    File.WriteAllBytes(fbd.SelectedPath + @"\" + video.FullName, await video.GetBytesAsync());
                    button1.Text = "Complete";
                }
            }
        }

        private async void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
