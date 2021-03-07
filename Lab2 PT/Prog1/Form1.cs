using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Prog1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            button4.Enabled = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //создание контекстного меню
            ContextMenu contextMenu1 = new ContextMenu(); ;
            MenuItem menuItem1 = new MenuItem();
            MenuItem menuItem2 = new MenuItem();
            MenuItem menuItem3 = new MenuItem();
            contextMenu1.MenuItems.AddRange(new MenuItem[] { menuItem1, menuItem2, menuItem3 });
            menuItem1.Index = 0;
            menuItem1.Text = "Открыть";
            menuItem2.Index = 1;
            menuItem2.Text = "Сохранить";
            menuItem3.Index = 2;
            menuItem3.Text = "Сохранить как";
            richTextBox1.ContextMenu = contextMenu1;
            menuItem1.Click += new EventHandler(this.menuItem1_Click);
            menuItem2.Click += new EventHandler(this.menuItem2_Click);
            menuItem3.Click += new EventHandler(this.menuItem3_Click);
        }

        string MyFName = "";
        private void menuItem1_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Текстовые файлы (*.rtf; *.txt; *.dat) | *.rtf; *.txt; *.dat";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                MyFName = openFileDialog1.FileName;
                richTextBox1.LoadFile(MyFName);
            }
        }
        private void menuItem2_Click(object sender, EventArgs e)
        {
            if (MyFName != "")
                richTextBox1.SaveFile(MyFName);
            else
            {
                saveFileDialog1.Filter = "Текстовые файлы (*.rtf; *.txt; *.dat) | *.rtf; *.txt; *.dat";
                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    MyFName = saveFileDialog1.FileName;
                    richTextBox1.SaveFile(MyFName);
                }
            }
        }

        private void menuItem3_Click(object sender, EventArgs e)
        {
            saveFileDialog1.Filter = "Текстовые файлы (*.rtf; *.txt; *.dat) | *.rtf; *.txt; *.dat";
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                MyFName = saveFileDialog1.FileName;
                richTextBox1.SaveFile(MyFName);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            richTextBox1.Clear();
            button2.Enabled = true;
            button3.Enabled = true;
            button4.Enabled = true;
            numKlick = 0;
            numChars = 0;
            for (int i = 0; i < textsLen.Count; i++)
            {
                textsLen.RemoveAt(i);
                textsStart.RemoveAt(i);
            }
        }

        int result1, result2;
        private void button2_Click(object sender, EventArgs e)
        {
            int LenText;
            textBox1.Text += "Поиск первого слова" + Environment.NewLine;
            String FWord = textBox2.Text.ToString();
            LenText = richTextBox1.Text.Length;
            result1 = FindWord(FWord, LenText);
            if (result1 != -1)
            {
                textBox1.Text += "Позиция первого слова: " + (result1 + 1) + Environment.NewLine + Environment.NewLine;
                richTextBox1.SelectionStart = result1;
                richTextBox1.SelectionLength = FWord.Length;
                richTextBox1.SelectionBackColor = Color.Red;
                button2.Enabled = false;
                if (button3.Enabled == false)
                    button4.Enabled = true;
            }
            else
                textBox1.Text += "Слово не найдено " + Environment.NewLine + Environment.NewLine;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int LenText;
            textBox1.Text += "Поиск второго слова" + Environment.NewLine;
            String FWord = textBox3.Text.ToString();
            LenText = richTextBox1.Text.Length;
            result2 = FindWord(FWord, LenText);
            if (result2 != -1)
            {
                textBox1.Text += "Позиция второго слова: " + (result2 + 1) + Environment.NewLine + Environment.NewLine;
                richTextBox1.SelectionStart = result2;
                richTextBox1.SelectionLength = FWord.Length;
                richTextBox1.SelectionBackColor = Color.Green;
                button3.Enabled = false;
                if (button2.Enabled == false)
                    button4.Enabled = true;
            }
            else
                textBox1.Text += "Слово не найдено " + Environment.NewLine + Environment.NewLine;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (result1 < result2)
            {
                richTextBox1.Select(result2, textBox3.Text.Length);
                richTextBox1.SelectedText = textBox2.Text.ToString();
                richTextBox1.Select(result1, textBox2.Text.Length);
                richTextBox1.SelectedText = textBox3.Text.ToString();
                textBox1.Text += "Произошла замена слов";
                button4.Enabled = false;
            }
            else
            {
                richTextBox1.Select(result1, textBox2.Text.Length);
                richTextBox1.SelectedText = textBox3.Text.ToString();
                richTextBox1.Select(result2, textBox3.Text.Length);
                richTextBox1.SelectedText = textBox2.Text.ToString();
                textBox1.Text += "Произошла замена слов";
                button4.Enabled = false;
            }
        }


        List<int> textsLen = new List<int>();
        List<int> textsStart = new List<int>();
        int numKlick = 0;
        int numChars = 0;
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == (char)Keys.Home)
            {

                string text = richTextBox1.Text;
                string[] splitText = text.Split('.', '!', '?');

                if (numKlick == 0)
                    for (int i = 0; i < splitText.Length; i++)
                    {
                        textsStart.Add(numChars);
                        textsLen.Add(splitText[i].Length);
                        numChars += splitText[i].Length + 1;
                    }

                if (numKlick == 0)
                {
                    Coloring(textsStart[1], textsLen[1]);
                    textBox1.Text += $"Выделено предложение 2. Оно начинается на {textsStart[1]} символе длинной в {textsLen[1]} символов." + Environment.NewLine;
                }

                else if (numKlick == 1)
                {
                    Coloring(textsStart[0], textsLen[0]);
                    textBox1.Text += $"Выделено предложение 1. Оно начинается на {textsStart[0]} символе длинной в {textsLen[0]} символов." + Environment.NewLine;
                }
                else if (numKlick == 2)
                {
                    Coloring(textsStart[2], textsLen[2]);
                    textBox1.Text += $"Выделено предложение 3. Оно начинается на {textsStart[2]} символе длинной в {textsLen[2]} символов." + Environment.NewLine;
                }
                else if (splitText.Length - 1 <= numKlick)
                    textBox1.Text += "Все предложения закончились." + Environment.NewLine;
                else
                {
                    Coloring(textsStart[numKlick], textsLen[numKlick]);
                    textBox1.Text += $"Выделено предложение {numKlick + 1}. Оно начинается на {textsStart[numKlick]} символе длинной в {textsLen[numKlick]} символов." + Environment.NewLine;
                }

                numKlick++;
            }
        }

        void Coloring(int start, int len)
        {
            richTextBox1.SelectionStart = start;
            richTextBox1.SelectionLength = len;
            richTextBox1.SelectionBackColor = Color.Aqua;
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            if (richTextBox1.Text == "")
                button1_Click(sender, null);
        }

        int FindWord(String FWord, int n)
        {
            int LenWord;
            String ComparText;
            LenWord = FWord.Length;
            for (int i = 0; i <= n - LenWord; i++)
            {
                ComparText = richTextBox1.Text.Substring(i, LenWord);
                if (ComparText == FWord)
                    return i;
            }
            return -1;
        }
    }
}