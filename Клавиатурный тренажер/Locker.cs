using System.Threading.Tasks;
using System.Windows.Forms;

namespace Клавиатурный_тренажер
{
    internal class Locker : Form1
    {
        public async Task Lock(int Level, int mode, Button button2, Button button3, Button button4, Button button5, Button button6, Button button7, Button button8)
        {
            if (Level == 1)
            {
                button3.Enabled = false;
                button4.Enabled = false;
            }
            else if (Level == 2)
            {
                button2.Enabled = false;
                button4.Enabled = false;
            }
            else if (Level == 3)
            {
                button2.Enabled = false;
                button3.Enabled = false;
            }

            if (mode == 1)
            {
                button6.Enabled = false;
                button7.Enabled = false;
                button8.Enabled = false;
            }
            else if (mode == 2)
            {
                button5.Enabled = false;
                button7.Enabled = false;
                button8.Enabled = false;
            }
            else if (mode == 3)
            {
                button5.Enabled = false;
                button6.Enabled = false;
                button8.Enabled = false;
            }
            else if (mode == 4)
            {
                button5.Enabled = false;
                button6.Enabled = false;
                button7.Enabled = false;
            }
        }
    }
}