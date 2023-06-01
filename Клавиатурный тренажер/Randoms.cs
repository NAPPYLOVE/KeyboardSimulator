using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Клавиатурный_тренажер
{
    internal class Randoms : Form1
    {
        public async Task RandCharAsync(bool check, int i, string[] textArr, Button button1, Label label2, Label label3)
        {
            Random rand = new Random();

            if (button1.Text == "Stop" && check == true)
            {
                i = rand.Next(0, textArr.Length);
                check = false;
                label2.Text = textArr[i].ToString();
                label3.Text = "";
            }
        }
    }
}
