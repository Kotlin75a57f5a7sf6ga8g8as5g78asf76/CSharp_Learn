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
    public partial class Menu : Form
    {
        public static string path1 = @"files\words01.txt";
        public static string path2 = @"files\leaderboard.txt";
        public static string path3 = "files";
        public Menu()
        {
            InitializeComponent();
            DirectoryInfo dirInfo = new DirectoryInfo(path3);
            if (!dirInfo.Exists)
            {
                dirInfo.Create();
            }
            // Если нет файла словаря
            if (!File.Exists(path1))
            {
                using (FileStream fs = File.Create(path1))
                {
                   byte[] info = new UTF8Encoding(true).GetBytes("школа\n" +
                                                                 "колледж\n" +
                                                                 "автомобиль\n" +
                                                                 "пылесос\n" +
                                                                 "антиквариат\n" +
                                                                 "клавиатура\n" +
                                                                 "планета\n" +
                                                                 "вагон\n" +
                                                                 "микрофон\n" +
                                                                 "антенна\n");
                    // Если файла со словами нет создаем этот фаил с станадартными словами.
                    fs.Write(info, 0, info.Length);
                }
            }
            // Если нет файла leaderboard создаем пустой
            if (!File.Exists(path2))
                File.Create(path2).Close();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Game f2 = new Game();
            this.Hide();
            f2.ShowDialog(); // Shows Game
            this.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Rules f2 = new Rules();
            this.Hide();
            f2.ShowDialog(); // Shows Rules
            this.Show();
        }
        private void button3_Click(object sender, EventArgs e)
        {
            System.Environment.Exit(1);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (System.IO.File.Exists(@"files\leaderboard.txt"))
            {
                Leaderboard f2 = new Leaderboard();
                this.Hide();
                f2.ShowDialog(); // Shows Leaderboard
                this.Show();
            }
        }
    }
}
