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
using System.Diagnostics;

namespace Hangman_game
{
	public partial class Game : Form
	{
		static readonly Random random = new Random();
		static string randomWord;
		string[] words;
		static int lifes;
		Font MyFont;
		Label[] labels;
		PictureBox[] hidden;
		bool GameOver;
		Timer timer;
		Stopwatch sw;
		int mistakes;
		int difficulty = -1;

		public Game()
		{

			InitializeComponent();
			words = ReadWords("words01");
			
			comboBoxDifficulty.SelectedIndex = 0;
			MyFont = new Font("Arial", 14);
			GameOver = true;
			randomWord = null;
		}
		string[] ReadWords(string FileName)
		{
			// Читаем файл, узнаем сколько в нём строк
			string[] strWords = File.ReadAllLines(@"files/" + FileName + ".txt");
			return strWords;
		}
		void GetRandomWord(string[] rndwords)
		{
			int randomNumber = random.Next(0, rndwords.Length);
			randomWord = rndwords[randomNumber];
			randomWord = randomWord.ToLower();
		}
		private void changeHangmanImage()
		{
		if (lifes == 5)					
			pictureHangman.Image = Hangman_game.Properties.Resources.Hangman02;
		else if (lifes == 4)
			pictureHangman.Image = Hangman_game.Properties.Resources.Hangman03;
		else if (lifes == 3)
			pictureHangman.Image = Hangman_game.Properties.Resources.Hangman04;
		else if (lifes == 2)
			pictureHangman.Image = Hangman_game.Properties.Resources.Hangman05;
		else if (lifes == 1)
			pictureHangman.Image = Hangman_game.Properties.Resources.Hangman06;
		else if (lifes == 0)
			pictureHangman.Image = Hangman_game.Properties.Resources.Hangman07;
		}
        private void buttonNewGame_Click_1(object sender, EventArgs e)
        {
			timer = new Timer();
			timer.Interval = (1000);
			timer.Tick += new EventHandler(timer_Tick);
			sw = new Stopwatch();
			timer.Start();
			sw.Start();

			comboBoxDifficulty.Enabled = false;
			GameOver = false;
			GetRandomWord(words);
			
			int x = 15;
			int y = 330;
			buttonCheckLetter.Enabled = true;
			lifes = 6;
			changeHangmanImage();
			textBoxChars.Text = "";
			if (comboBoxDifficulty.Text.Equals("Легко"))
				difficulty = 2;
			else if (comboBoxDifficulty.Text.Equals("Средний"))
				difficulty = 1;
			else if (comboBoxDifficulty.Text.Equals("Продвинутый"))
				difficulty = 0;
			if (labels != null) //Если у нас уже было слово раньше, мы удаляем его из формы
				for (int i = 0; i < labels.Length; i++)
					Controls.Remove(labels[i]);
			if (hidden != null)
				for (int i = 0; i < hidden.Length; i++)
					Controls.Remove(hidden[i]);
			labels = new Label[randomWord.Length];
			hidden = new PictureBox[randomWord.Length];

			for (int i = 0; i < randomWord.Length; i++)
			{
				labels[i] = new Label(); //Делаем столько надписей, сколько букв в слове
				hidden[i] = new PictureBox();
			}
			// Добавляем квадраты в форму
			for (int i = 0; i < labels.Length; i++)
			{
				hidden[i].Left = x;
				hidden[i].Top = y;
				hidden[i].Size = new Size(25, 25);
				hidden[i].Image = Properties.Resources.hidden_letter;
				hidden[i].SizeMode = PictureBoxSizeMode.Normal;
				Controls.Add(hidden[i]);
				x += 30;
			}
			// Добавляем подсказки в зависимости от выбранной сложности
			String hintsAdded = "";
			for (int i = 0; i < difficulty; i++)
			{
				char letter;

				do
				{
					letter = (char)random.Next(65, 11030);
				} while (!randomWord.Contains(letter) || hintsAdded.Contains(letter));

				for (int j = 0; j < randomWord.Length; j++)
				{
					if (randomWord[j] == letter)
					{
						labels[j].Text = letter.ToString();
						// Меняем изображение на букву
						labels[j].Left = hidden[j].Left;
						labels[j].Top = hidden[j].Top;
						labels[j].Size = hidden[j].Size;
						labels[j].Font = MyFont;
						Controls.Remove(hidden[j]);
						Controls.Add(labels[j]);
						//Добавляем букву к уже использованным буквам
						hintsAdded += letter;
					}
				}
			}

		}
		//########################### ФУНКЦИЯ ПРОВЕРКИ ########################################
		private void CheckLetter()
		{
			if (!GameOver)
			{
				if (textBoxLetter.Text.Length == 1)
				{
					char letter = textBoxLetter.Text.ToLower()[0];
					bool success = false;

					if (randomWord.Contains(letter))
					{
						for (int i = 0; i < randomWord.Length; i++)
						{
							if (letter == randomWord[i])
							{
								labels[i].Text = letter.ToString();
								labels[i].Left = hidden[i].Left;
								labels[i].Top = hidden[i].Top;
								labels[i].Size = hidden[i].Size;
								labels[i].Font = MyFont;
								Controls.Add(labels[i]);
								Controls.Remove(hidden[i]);
								success = true;
							}
						}
					}

					if (!success)
					{
						if (!textBoxChars.Text.Contains(letter))
						{
							lifes -= 1;
							this.changeHangmanImage();
							textBoxChars.Text += (letter + " ");
							mistakes++;
							lblMistakes.Text = $"Ошибок: {mistakes}";
						}
						else
						{
							MessageBox.Show("Вы уже вводили эту букву!");
						}
					}

					
					GameOver = true;
					//Проверяем, окончена ли игра
					if (lifes > 0)
					{
						for (int i = 0; i < labels.Length; i++)
						{
							if (labels[i].Text.Equals(""))
								GameOver = false;
						}

						if (GameOver)
						{
							buttonCheckLetter.Enabled = false;
							timer.Stop();
							sw.Stop();
							lblTimer.Text = "Завершено за " + sw.Elapsed.Seconds.ToString() + " секунд";
							btnSave.Enabled = true;
							tBName.ReadOnly = false;
							MessageBox.Show("Поздравляю! Вы выиграли игру."); // ПОБЕДА
						}
					}
					else
					{ //Если игра окончена
						MessageBox.Show("Вы проиграли.");
						buttonCheckLetter.Enabled = false;

						//Мы показываем решение
						for (int i = 0; i < randomWord.Length; i++)
						{
							if (labels[i].Text.Equals(""))
							{
								labels[i].Text = randomWord[i].ToString();
								labels[i].Left = hidden[i].Left;
								labels[i].Top = hidden[i].Top;
								labels[i].Size = hidden[i].Size;
								labels[i].Font = MyFont;
								Controls.Add(labels[i]);
								Controls.Remove(hidden[i]);
							}
						}
					}
				}
				else
				{
					MessageBox.Show("Вы должны ввести одну букву");
				}
			}
			else
			{
				MessageBox.Show("Вы должны начать новую игру");
			}

			textBoxLetter.Text = "";
		}
		private void textBoxLetter_KeyPress(object sender, KeyPressEventArgs e) // Обработка Enter
		{
			if (e.KeyChar == (char)13)
			{
				CheckLetter();
			}
		}

        private void buttonCheckLetter_Click(object sender, EventArgs e)
        {
			CheckLetter();
		}

        private void timer_Tick(object sender, EventArgs e)
        {
			lblTimer.Text = "Время: " + sw.Elapsed.Seconds.ToString() + " секунд";
			Application.DoEvents();
		}

        private void btnSave_Click(object sender, EventArgs e)
        {
			btnSave.Enabled = false;
			string writePath = @"files/leaderboard.txt";
			string strdifficulty = "0";
			switch (difficulty)
            {
				case 2:
					strdifficulty = "Легко";
					break;
				case 1:
					strdifficulty = "Средний";
					break;
				case 0:
					strdifficulty = "Продвинутый";
					break;
            }
			string strTime = Convert.ToString(sw.Elapsed.Minutes) + ":" + Convert.ToString(sw.Elapsed.Seconds);
			using (StreamWriter sw = new StreamWriter(writePath, true, System.Text.Encoding.Default))
			{
				sw.Write(strdifficulty + " ");
				sw.Write(mistakes + " ");
				sw.Write(strTime + " ");
				sw.WriteLine(tBName.Text);
				sw.Close();
			}

		}
    }
}
