using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Hangman_game
{
    public partial class Leaderboard : Form
    {
        string path = @"files/leaderboard.txt";
        public Leaderboard()
        {
            InitializeComponent();
            listBox1.Items.Add("Сложность:");
            listBox2.Items.Add("Кол-во ошибок:");
            listBox3.Items.Add("Время:");
            listBox4.Items.Add("Имя:");
            using (StreamReader sr = new StreamReader(path, System.Text.Encoding.Default))
            {
                string line;
                int count = 0;
                while ((line = sr.ReadLine()) != null)
                {
                    count++;
                    string[] split = line.Split(' ');
                    //line = Convert.ToString(count++) + ". " + line;
                    //listView1.Items.Add(line);
                    listBox1.Items.Add(count + ". " + split[0]);
                    listBox2.Items.Add(split[1]);
                    listBox3.Items.Add(split[2]);
                    listBox4.Items.Add(split[3]);
                }
                sr.Close();
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            listBox2.Items.Clear();
            listBox3.Items.Clear();
            listBox4.Items.Clear();
            listBox1.Items.Add("Сложность:");
            listBox2.Items.Add("Кол-во ошибок:");
            listBox3.Items.Add("Время:");
            listBox4.Items.Add("Имя:");
            StreamWriter sw = new StreamWriter(path, false, System.Text.Encoding.Default);
            sw.Close();
            btnClear.Enabled = false;
        }
    }
}
