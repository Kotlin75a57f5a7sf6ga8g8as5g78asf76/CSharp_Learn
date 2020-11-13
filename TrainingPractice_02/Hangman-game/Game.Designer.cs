namespace Hangman_game
{
    partial class Game
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.textBoxLetter = new System.Windows.Forms.TextBox();
            this.textBoxChars = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.buttonNewGame = new System.Windows.Forms.Button();
            this.comboBoxDifficulty = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.buttonCheckLetter = new System.Windows.Forms.Button();
            this.pictureHangman = new System.Windows.Forms.PictureBox();
            this.lblTimer = new System.Windows.Forms.Label();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.lblMistakes = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.tBName = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureHangman)).BeginInit();
            this.SuspendLayout();
            // 
            // textBoxLetter
            // 
            this.textBoxLetter.Location = new System.Drawing.Point(13, 219);
            this.textBoxLetter.Name = "textBoxLetter";
            this.textBoxLetter.Size = new System.Drawing.Size(36, 20);
            this.textBoxLetter.TabIndex = 7;
            this.textBoxLetter.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxLetter_KeyPress);
            // 
            // textBoxChars
            // 
            this.textBoxChars.Location = new System.Drawing.Point(13, 287);
            this.textBoxChars.Name = "textBoxChars";
            this.textBoxChars.ReadOnly = true;
            this.textBoxChars.Size = new System.Drawing.Size(126, 20);
            this.textBoxChars.TabIndex = 9;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(10, 262);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(129, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Использованные буквы";
            // 
            // buttonNewGame
            // 
            this.buttonNewGame.Location = new System.Drawing.Point(38, 69);
            this.buttonNewGame.Name = "buttonNewGame";
            this.buttonNewGame.Size = new System.Drawing.Size(78, 33);
            this.buttonNewGame.TabIndex = 11;
            this.buttonNewGame.Text = "Новая игра";
            this.buttonNewGame.UseVisualStyleBackColor = true;
            this.buttonNewGame.Click += new System.EventHandler(this.buttonNewGame_Click_1);
            // 
            // comboBoxDifficulty
            // 
            this.comboBoxDifficulty.FormattingEnabled = true;
            this.comboBoxDifficulty.Items.AddRange(new object[] {
            "Легко",
            "Средний",
            "Продвинутый"});
            this.comboBoxDifficulty.Location = new System.Drawing.Point(18, 31);
            this.comboBoxDifficulty.Name = "comboBoxDifficulty";
            this.comboBoxDifficulty.Size = new System.Drawing.Size(121, 21);
            this.comboBoxDifficulty.TabIndex = 12;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(44, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 13);
            this.label2.TabIndex = 13;
            this.label2.Text = "Сложность";
            // 
            // buttonCheckLetter
            // 
            this.buttonCheckLetter.Enabled = false;
            this.buttonCheckLetter.Location = new System.Drawing.Point(64, 216);
            this.buttonCheckLetter.Name = "buttonCheckLetter";
            this.buttonCheckLetter.Size = new System.Drawing.Size(75, 23);
            this.buttonCheckLetter.TabIndex = 14;
            this.buttonCheckLetter.Text = "Проверить";
            this.buttonCheckLetter.UseVisualStyleBackColor = true;
            this.buttonCheckLetter.Click += new System.EventHandler(this.buttonCheckLetter_Click);
            // 
            // pictureHangman
            // 
            this.pictureHangman.Image = global::Hangman_game.Properties.Resources.Hangman01;
            this.pictureHangman.InitialImage = null;
            this.pictureHangman.Location = new System.Drawing.Point(161, 12);
            this.pictureHangman.Name = "pictureHangman";
            this.pictureHangman.Size = new System.Drawing.Size(192, 301);
            this.pictureHangman.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureHangman.TabIndex = 8;
            this.pictureHangman.TabStop = false;
            // 
            // lblTimer
            // 
            this.lblTimer.AutoSize = true;
            this.lblTimer.Location = new System.Drawing.Point(370, 12);
            this.lblTimer.Name = "lblTimer";
            this.lblTimer.Size = new System.Drawing.Size(46, 13);
            this.lblTimer.TabIndex = 15;
            this.lblTimer.Text = "Время: ";
            // 
            // timer
            // 
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // lblMistakes
            // 
            this.lblMistakes.AutoSize = true;
            this.lblMistakes.Location = new System.Drawing.Point(370, 34);
            this.lblMistakes.Name = "lblMistakes";
            this.lblMistakes.Size = new System.Drawing.Size(50, 13);
            this.lblMistakes.TabIndex = 16;
            this.lblMistakes.Text = "Ошибок:";
            // 
            // btnSave
            // 
            this.btnSave.Enabled = false;
            this.btnSave.Location = new System.Drawing.Point(382, 57);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(103, 56);
            this.btnSave.TabIndex = 17;
            this.btnSave.Text = "Cохранить результат в таблице лидеров";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(379, 125);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(122, 45);
            this.label1.TabIndex = 18;
            this.label1.Text = "Можете ввести своё имя или оставить поле пустым";
            // 
            // tBName
            // 
            this.tBName.Location = new System.Drawing.Point(373, 173);
            this.tBName.Name = "tBName";
            this.tBName.ReadOnly = true;
            this.tBName.Size = new System.Drawing.Size(112, 20);
            this.tBName.TabIndex = 19;
            // 
            // Game
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(513, 450);
            this.Controls.Add(this.tBName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.lblMistakes);
            this.Controls.Add(this.lblTimer);
            this.Controls.Add(this.buttonCheckLetter);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.comboBoxDifficulty);
            this.Controls.Add(this.buttonNewGame);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBoxChars);
            this.Controls.Add(this.pictureHangman);
            this.Controls.Add(this.textBoxLetter);
            this.Name = "Game";
            this.Text = "Игра";
            ((System.ComponentModel.ISupportInitialize)(this.pictureHangman)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox textBoxLetter;
        private System.Windows.Forms.PictureBox pictureHangman;
        private System.Windows.Forms.TextBox textBoxChars;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button buttonNewGame;
        private System.Windows.Forms.ComboBox comboBoxDifficulty;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button buttonCheckLetter;
        private System.Windows.Forms.Label lblTimer;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label lblMistakes;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tBName;
    }
}