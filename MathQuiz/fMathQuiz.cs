using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MathQuiz
{
    public partial class fMathQuiz : Form
    {

        Random randomizer = new Random();

        int addend1;
        int addend2;

        int minuend;
        int subtrahend;

        int multiplicand;
        int multiplier;

        int dividend;
        int divisor;

        int timeLeft;

        private bool CheckTheAnswer()
        {
            if ((addend1 + addend2 == somme.Value)
                && (minuend - subtrahend == difference.Value)
                && (multiplicand * multiplier == produit.Value)
                && (dividend / divisor == quotient.Value))
                return true;
            else
                return false;
        }

        public void StartTheQuiz()
        {
            addend1 = randomizer.Next(51);
            addend2 = randomizer.Next(51);
            plusLeftLabel.Text = addend1.ToString();
            plusRightLabel.Text = addend2.ToString();
            somme.Value = 0;
            somme.ValueChanged += new EventHandler(somme_sound);

            minuend = randomizer.Next(1, 101);
            subtrahend = randomizer.Next(1, minuend);
            minusLeftLabel.Text = minuend.ToString();
            minusRightLabel.Text = subtrahend.ToString();
            difference.Value = 0;
            difference.ValueChanged += new EventHandler(sub_sound);

            multiplicand = randomizer.Next(2, 11);
            multiplier = randomizer.Next(2, 11);
            timesLeftLabel.Text = multiplicand.ToString();
            timesRightLabel.Text = multiplier.ToString();
            produit.Value = 0;
            produit.ValueChanged += new EventHandler(produit_sound);

            divisor = randomizer.Next(2, 11);
            int temporaryQuotient = randomizer.Next(2, 11);
            dividend = divisor * temporaryQuotient;
            dividedLeftLabel.Text = dividend.ToString();
            dividedRightLabel.Text = divisor.ToString();
            quotient.Value = 0;
            quotient.ValueChanged += new EventHandler(quotient_sound);

            timeLeft = 30;
            timeLabel.Text = "30 seconds";
            timer1.Start();
        }
        public fMathQuiz()
        {
            InitializeComponent();
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label15_Click(object sender, EventArgs e)
        {

        }

        private void startButton_Click(object sender, EventArgs e)
        {
            StartTheQuiz();
            startButton.Enabled = false;
        }

        private void timeLabel_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (CheckTheAnswer())
            {
                timer1.Stop();
                MessageBox.Show("You Got all the answers right!",
                                "Congratulations!");
                startButton.Enabled = true;
            }
            else if (timeLeft > 0)
            {
                timeLeft = timeLeft - 1;
                timeLabel.Text = timeLeft + " seconds";
                if (timeLeft <= 5)
                    timeLabel.BackColor = Color.Red;
            }
            else
            {
                timer1.Stop();
                timeLabel.Text = "Time's up!";
                ResetTimeLabelColor();
                MessageBox.Show("You didn't finish in time.", "Sorry!");
                somme.Value = addend1 + addend2;
                difference.Value = minuend - subtrahend;
                produit.Value = multiplicand * multiplier;
                quotient.Value = dividend / divisor;
                startButton.Enabled = true;
            }
        }

        private void ResetTimeLabelColor()
        {
            timeLabel.BackColor = SystemColors.Control;
        }

        private void answer_Enter(object sender, EventArgs e)
        {
            NumericUpDown answerBox = sender as NumericUpDown;

            if (answerBox != null)
            {
                int lenghtOfAnswer = answerBox.Value.ToString().Length;
                answerBox.Select(0, lenghtOfAnswer);
            }
        }

        private void somme_sound(object sender, EventArgs e)
        {
            if (addend1 + addend2 == somme.Value)
                SystemSounds.Beep.Play();
        }

        private void sub_sound(object sender, EventArgs e)
        {
            if (minuend - subtrahend == somme.Value)
                SystemSounds.Beep.Play();
        }

        private void produit_sound(object sender, EventArgs e)
        {
            if (multiplicand * multiplier == somme.Value)
                SystemSounds.Beep.Play();
        }

        private void quotient_sound(object sender, EventArgs e)
        {
            if (dividend / divisor == somme.Value)
                SystemSounds.Beep.Play();
        }
    }
}
