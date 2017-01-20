using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Yahtzee
{
    public partial class Form1 : Form
    {
        int die_one = 0;
        int die_two = 0;
        int die_three = 0;
        int die_four = 0;
        int die_five = 0;

        bool OnesTaken = false, TwosTaken = false, ThreesTaken = false, FoursTaken = false, FivesTaken = false, SixesTaken = false, ThreeKindTaken = false, FourKindTake = false, FullHouseTaken = false, SmallStraightTaken = false, LargeStraightTaken = false, Yahtzee = false, Chance = false;

        public Form1()
        {
            InitializeComponent();
        }

        private void RollDiceButton_Click(object sender, EventArgs e)
        {
            Random random = new Random();
            die_one = random.Next(1, 6);
            die_two = random.Next(1, 6);
            die_three = random.Next(1, 6);
            die_four = random.Next(1, 6);
            die_five = random.Next(1, 6);

            DieOnelabel.Text = "Die 1: " + die_one.ToString();
            DieTwolabel.Text = "Die 2: " + die_two.ToString();
            DieThreelabel.Text = "Die 3: " + die_three.ToString();
            DieFourlabel.Text = "Die 4: " + die_four.ToString();
            DieFivelabel.Text = "Die 5: " + die_five.ToString();

            PosAns.Items.Clear();
            int answer = UpperSection(1);
            if (answer != 0 && OnesTaken == false)
            {
                PosAns.Items.Add("Ones: " + answer);
            }
            answer = UpperSection(2);
            if (answer != 0 && TwosTaken == false)
            {
                PosAns.Items.Add("Twos: " + answer);
            }
            answer = UpperSection(3);
            if (answer != 0 && ThreesTaken == false)
            {
                PosAns.Items.Add("Threes: " + answer);
            }
            answer = UpperSection(4);
            if (answer != 0 && FoursTaken == false)
            {
                PosAns.Items.Add("Fours: " + answer);
            }
            answer = UpperSection(5);
            if (answer != 0 && FivesTaken == false)
            {
                PosAns.Items.Add("Fives: " + answer);
            }
            answer = UpperSection(6);
            if (answer != 0 && SixesTaken == false)
            {
                PosAns.Items.Add("Sixes: " + answer);
            }

            answer = ThreeKind();
            if (answer != 0)
            {
                PosAns.Items.Add("Three Of A Kind: " + answer);
            }

           
        }

        private int UpperSection(int numb)
        {
            int sum = 0;
            if (die_one == numb)
            {
                sum += die_one;
            }
            if (die_two == numb)
            {
                sum += die_two;
            }
            if (die_three == numb)
            {
                sum += die_three;
            }
            if (die_four == numb)
            {
                sum += die_four;
            }
            if (die_five == numb)
            {
                sum += die_five;
            }
            return sum;
        }

        private int ThreeKind()
        {
            int sum = 0;
            int[] Dice = new int[5];
            Dice[0] = die_one;
            Dice[1] = die_two;
            Dice[2] = die_three;
            Dice[3] = die_four;
            Dice[4] = die_five;


            for (int k = 0; k < Dice.Length; k++)
            {
                for (int i = 0; i < Dice.Length; i++)
                {
                    for (int j = 0; j < Dice.Length; j++)
                    {
                        if (i != j && i != k && j != k)
                        {
                            if (Dice[i] == Dice[j] && Dice[j] == Dice[k])
                            {
                                sum = die_one + die_two + die_three + die_four + die_five;
                                return sum;
                            }
                        }
                    }
                }
            }

            return 0;
        }

        private void DieOneButton_Click(object sender, EventArgs e)
        {

        }

        private void DieTwoButton_Click(object sender, EventArgs e)
        {

        }

        private void DieThreeButton_Click(object sender, EventArgs e)
        {

        }

        private void DieFourButton_Click(object sender, EventArgs e)
        {

        }

        private void DieFiveButton_Click(object sender, EventArgs e)
        {

        }

        private void ChoseAnsButton_Click(object sender, EventArgs e)
        {
            SetAnswer(PosAns.SelectedItem);
            PosAns.Items.Clear();
        }

        private void SetAnswer(object ans)
        {
            string strg_ans = ans.ToString();
            if (strg_ans.Contains("Ones"))
            {
                OnesAnsLabel.Text = UpperSection(1).ToString();
            }
        }
    }
}
