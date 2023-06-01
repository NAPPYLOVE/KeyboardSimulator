using System;
using System.IO;

namespace Клавиатурный_тренажер
{
    internal class FileStream
    {
        public static void AppendAllText(string SavesText, string lvl, string textlvl, string timer2)
        {
            string path = @"D:\Учёба\ООП 2\Saves.txt";

            File.AppendAllText(path, DateTime.Now + "\nРежим сложности: " + lvl + "\nРежим времени: " + textlvl + "\nЗатраченное время: " + timer2 + "\n" + SavesText + "\n\n");
        }
    }
}