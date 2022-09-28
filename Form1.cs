using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PasswordGenerator
{
    public partial class Form1 : Form
    {
        Random random = new Random();
        int timeLeft = 30;

        public Form1()
        {
            InitializeComponent();
        }

        private void PasswordGenerator()
        {
            int PasswordLength = random.Next(8, 25);
            String allCharacters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789abcdefghijklmnopqrstuvwxyz!@#$%^&*";
            String RandomPassword = "";

            for (int i = 0; i < PasswordLength; i++)
            {
                int randomIndex = random.Next(0, allCharacters.Length);
                RandomPassword += allCharacters[randomIndex];
            }

            PasswordLabel.Text = RandomPassword;
        }

        private void UserIDLabel_Click(object sender, EventArgs e)
        {

        }

        private void DateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            DateTimePicker.Checked = true;
        }

        private void PasswordButton_Click(object sender, EventArgs e)
        {
            if (UserIDTextBox.Text != "" && DateTimePicker.Checked == true)
            {
                PasswordGenerator();
                ErrorLabel.Text = "";
                timer.Start();
            }
            else
            {
                ErrorLabel.Text = "Invalid credentials.";
            }
        }

        private void CopyPasswordButton_Click(object sender, EventArgs e)
        {
            if (PasswordLabel.Text != "")
                Clipboard.SetText(PasswordLabel.Text);
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            if (timeLeft > 0)
            {
                timeLeft--;
                TimerLabel.Text = timeLeft.ToString();
            }
            else
            {
                PasswordGenerator();
                timeLeft = 30;
            }
        }

        private void TimerLabel_Click(object sender, EventArgs e)
        {

        }
    }
}
