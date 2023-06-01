using System;
using System.IO;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Клавиатурный_тренажер
{
    public partial class Form1 : Form
    {
        private Stopwatch stopwatch;
        bool check = true;
        int i, Level, score, mistakes, i2, mode = 4, time;
        string[] textArr;
        string textCheck, timer, timer2, t1, t2, SavesText, lvl, timelvl;
        float rezult, timeCalc;

        async Task SelectLevelAsync()
        {
            if (Level == 1)
            {
                textArr = File.ReadAllText(@"D:\Учёба\ООП 2\\Letters.txt").Split('\n');
            }
            else if (Level == 2)
            {
                textArr = File.ReadAllText(@"D:\Учёба\ООП 2\\Words.txt").Split('\n');
            }
            else if (Level == 3)
            {
                textArr = File.ReadAllText(@"D:\Учёба\ООП 2\\Phrases.txt").Split('\n');
            }
        }

        public Form1()
        {
            InitializeComponent();
            button8.BackColor = Color.LimeGreen;
        }

        public async Task CompareTime()
        {
            if (mode == 1)
            {
                if (time == Int32.Parse(String.Format("{0:ss}", stopwatch.Elapsed)))
                {
                    button1.Text = "Stop";
                    this.ActiveControl = null;
                    await TimerAsync();
                }
            }
            else if (mode == 2 || mode == 3)
            {
                if (time == Int32.Parse(String.Format("{0:mm}", stopwatch.Elapsed)))
                {
                    button1.Text = "Stop";
                    this.ActiveControl = null;
                    await TimerAsync();
                }
            }
            else if (mode == 4)
            {
                //jooj
            }

        }

        public async Task Calc()
        {
            if (score != 0)
            {
                timer = String.Format("{0:mm\\:ss}", stopwatch.Elapsed);
                timer2 = String.Format("{0:mm\\:ss\\:fff}", stopwatch.Elapsed);
                t1 = timer[0].ToString() + timer[1].ToString();
                t2 = timer[3].ToString() + timer[4].ToString();
                timeCalc = ((float.Parse(t1)*60) + float.Parse(t2)) / 60;
                rezult = score / timeCalc;
            }
            else if (score == 0 || timeCalc == 0)
            {
                rezult = 0;
            }
        }

        public async Task Calc2()
        {
            timer2 = String.Format("{0:mm\\:ss\\:fff}", stopwatch.Elapsed);
        }

        async Task Reset()
        {
            if (button1.Text == "Reset")
            {
                label2.Text = "";
                label3.Text = "";
                check = true;
                label1.Text = "00:00:00";
                score = 0;
                mistakes = 0;
            }
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
                button2.Enabled = true;
                button3.Enabled = true;
                button4.Enabled = true;
                button5.Enabled = true;
                button6.Enabled = true;
                button7.Enabled = true;
                button8.Enabled = true;

                stopwatch.Stop();
                timer1.Enabled = false;
                button1.Text = "Reset";
                SavesText = "Длина текста: " + score + " Символов" + "\n" + "Ошибки: " + mistakes + "\n" + "Средняя скорость: " + (Int32)rezult + " симв/мин";
                MessageBox.Show(
                "Длина текста: " + score + " Символов" + "\n" + "Ошибки: " + mistakes + "\n" + "Средняя скорость: " + (Int32)rezult + " симв/мин",
                "Результат",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information,
                MessageBoxDefaultButton.Button1);
                FileStream.AppendAllText(SavesText, lvl, timelvl, timer2);
            }
            else if (button1.Text == "Reset")
            {
                stopwatch.Reset();
                button1.Text = "Start";
            }
        }

        public async void button1_Click(object sender, EventArgs e)
        {
            Randoms r = new Randoms();
            Locker l = new Locker();

            if (Level != 1 && Level != 2 && Level != 3) {
                MessageBox.Show(
                "Выберите уровень сложности!",
                "Ошибка",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information,
                MessageBoxDefaultButton.Button1);
            }
            else
            {
                if (button1.Text == "Start")
                {
                    l.Lock(Level, mode, button2, button3, button4, button5, button6, button7, button8);
                }
                this.ActiveControl = null;
                await Reset();
                await SelectLevelAsync();
                await TimerAsync();
                await r.RandCharAsync(check, i, textArr, button1, label2, label3);
            }
        }

        public void timer1_Tick(object sender, EventArgs e)
        {
            label1.Text = String.Format("{0:mm\\:ss\\:fff}", stopwatch.Elapsed);
            Calc();
            Calc2();
            CompareTime();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            button2.BackColor = Color.LimeGreen;
            button3.BackColor = Color.DarkSlateBlue;
            button4.BackColor = Color.DarkSlateBlue;
            Level = 1;
            lvl = "Easy";
        }

        private void button3_Click(object sender, EventArgs e)
        {

            button2.BackColor = Color.DarkSlateBlue;
            button3.BackColor = Color.LimeGreen;
            button4.BackColor = Color.DarkSlateBlue;
            Level = 2;
            lvl = "Medium";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            button2.BackColor = Color.DarkSlateBlue;
            button3.BackColor = Color.DarkSlateBlue;
            button4.BackColor = Color.LimeGreen;
            Level = 3;
            lvl = "Hard";
        }

        private void button5_Click(object sender, EventArgs e)
        {
            button5.BackColor = Color.LimeGreen;
            button6.BackColor = Color.DarkSlateBlue;
            button7.BackColor = Color.DarkSlateBlue;
            button8.BackColor = Color.DarkSlateBlue;
            mode = 1;
            time = 30;
            timelvl = "30 с";
        }

        private void button6_Click(object sender, EventArgs e)
        {
            button5.BackColor = Color.DarkSlateBlue;
            button6.BackColor = Color.LimeGreen;
            button7.BackColor = Color.DarkSlateBlue;
            button8.BackColor = Color.DarkSlateBlue;
            mode = 2;
            time = 1;
            timelvl = "60 с";
        }

        private void button7_Click(object sender, EventArgs e)
        {
            button5.BackColor = Color.DarkSlateBlue;
            button6.BackColor = Color.DarkSlateBlue;
            button7.BackColor = Color.LimeGreen;
            button8.BackColor = Color.DarkSlateBlue;
            mode = 3;
            time = 2;
            timelvl = "120 с";
        }

        private void button8_Click(object sender, EventArgs e)
        {
            button5.BackColor = Color.DarkSlateBlue;
            button6.BackColor = Color.DarkSlateBlue;
            button7.BackColor = Color.DarkSlateBlue;
            button8.BackColor = Color.LimeGreen;
            mode = 4;
            timelvl = "∞";
        }

        async Task CompareAsync()
        {
            Randoms r = new Randoms();

            if (textArr.Last() == label2.Text)
            {
                if (textCheck.Equals(label2.Text))
                {
                    check = true;
                    i2 = 0;
                    textCheck = "";
                    r.RandCharAsync(check, i, textArr, button1, label2, label3);
                }
            }
            else
            {
                if (textCheck.Equals(label2.Text.Substring(0, label2.Text.Length - 1)))
                {
                    check = true;
                    i2 = 0;
                    textCheck = "";
                    r.RandCharAsync(check, i, textArr, button1, label2, label3);
                }
            }
        }

        public async void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == label2.Text[i2] && button1.Text == "Stop")
            {
                score++;
                textCheck += e.KeyChar.ToString();
                label3.Text += e.KeyChar.ToString();
                i2++;
                await CompareAsync();
            }
            else
            {
                mistakes++;
            }
        }
    }
}