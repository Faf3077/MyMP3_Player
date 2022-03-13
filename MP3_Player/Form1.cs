using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;
using System.IO;


namespace MP3_Player
{
    public partial class Form1 : Form
    {

        [System.Runtime.InteropServices.DllImport("winmm.dll")]
        private static extern
            Boolean PlaySound(string lpszName, int hModule, int dwFlags);
     
        public Form1()
        {
            InitializeComponent();
        }
        
        WMPLib.WindowsMediaPlayer WMP = new WMPLib.WindowsMediaPlayer();
        private void Form1_Load(object sender, EventArgs e)
        {
            DirectoryInfo dir = new DirectoryInfo("музыка");
            FileInfo[] files = dir.GetFiles("*.mp3");
            foreach (FileInfo fi in files)
            {
                listBox1.Items.Add(fi.ToString());
            }
            button4.Visible = false;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            WMP.URL = @"музыка\"+ listBox1.SelectedItem;
            WMP.controls.play();
            button1.Click -= new EventHandler(button1_Click);
            button1.Click += new EventHandler(button4_Click);
          
        }
    
        private void button3_Click(object sender, EventArgs e)
        {
            (listBox1.SelectedIndex)++;
            WMP.URL = @"музыка\" + listBox1.SelectedItem; 
            WMP.controls.play();
            if ((listBox1.SelectedIndex) == 2)//тут не понял как обраться к предпоследнему элементу, чтобы кнопка успевала прятаться
            {
                button3.Visible = false;
            }
            button2.Visible = true;
        }

       

        private void button4_Click(object sender, EventArgs e)
        {
            
            WMP.controls.stop();
            button1.Click -= new EventHandler(button4_Click);
            button1.Click += new EventHandler(button1_Click);

        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
       
        }

        private void button2_Click(object sender, EventArgs e)
        {
            (listBox1.SelectedIndex)--;
            WMP.URL = @"музыка\" + listBox1.SelectedItem;
            WMP.controls.play();
            if ((listBox1.SelectedIndex) == 0)
            {
                button2.Visible = false;
            }
            button3.Visible = true;
        }
    }
}
