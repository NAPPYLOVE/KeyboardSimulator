using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ProgressBar;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;

namespace Клавиатурный_тренажер
{
    public partial class Form1 : Form
    {
        string chars = "абвгдеёжзийклмнопрстуфхцчшщъыьэюя";
        Random rand = new Random();
        private Stopwatch stopwatch;
        int i;

        public Form1()
        {
            InitializeComponent();
        }

        async Task RandCharAsync()
        {
            if (button1.Text == "Stop")
            {
                i = rand.Next(1, 33);
                label2.Text = chars[i].ToString();
            }
            else if (button1.Text == "Reset")
            {
                //ddgsdg
            }
            /*if ((Int32)(stopwatch.Elapsed.TotalSeconds) == 60) cases = 1;*/
        }

        async Task TimerAsync()
        {
            stopwatch = new Stopwatch();
            timer1.Tick += new EventHandler(timer1_Tick);

            if (button1.Text == "Start")
            {
                stopwatch.Start();
                timer1.Enabled = true;
                button1.Text = "Stop";
            }
            else if (button1.Text == "Stop")
            {
                stopwatch.Stop();
                timer1.Enabled = false;
                button1.Text = "Reset";
            }
            else if (button1.Text == "Reset")
            {
                stopwatch.Reset();
                label2.Text = "";
                label1.Text = "00:00:00";
                button1.Text = "Start";
            }
        }

        public async void button1_Click(object sender, EventArgs e)
        {
            await TimerAsync();
            await RandCharAsync();
        }

        public void timer1_Tick(object sender, EventArgs e)
        {
            this.label1.Text = String.Format("{0:mm\\:ss\\:fff}", stopwatch.Elapsed);
        }

        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.ToString() == label2.Text)
            {
                this.BackColor = Color.Green;
            }
        }
    }
}