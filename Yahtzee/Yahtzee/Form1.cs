using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//Hi
namespace Yahtzee
{
    public partial class Form1 : Form
    {
        
        int die_one = 0;
        int die_two = 0;
        int die_three = 0;
        int die_four = 0;
        int die_five = 0;
        int Turn = 1;
        int MaxTurn = 13;
        int DiceRolls = 1;
        int DiceRollsMax = 3;
        
        bool OnesTaken = false, TwosTaken = false, ThreesTaken = false, FoursTaken = false, FivesTaken = false, SixesTaken = false, ThreeKindTaken = false, FourKindTaken = false, FullHouseTaken = false, SmallStraightTaken = false, LargeStraightTaken = false, YahtzeeTaken = false, ChanceTaken = false;
        bool ReRollOne = true, ReRollTwo = true, ReRollThree = true, ReRollFour = true, ReRollFive = true;

        public Form1()
        {
            InitializeComponent();
            DieOneButton.Enabled = false;
            DieTwoButton.Enabled = false;
            DieThreeButton.Enabled = false;
            DieFourButton.Enabled = false;
            DieFiveButton.Enabled = false;
            CurrTurnLabel.Text = Turn.ToString();
            PlayAGButton.Visible = false;
        }

        private void RollDiceButton_Click(object sender, EventArgs e)
        {
            CurrTurnLabel.Text = Turn.ToString();
            ChoseAnsButton.Enabled = true;
            if (DiceRolls == DiceRollsMax)
            {
                RollDiceButton.Enabled = false;
                DieOneButton.Enabled = false;
                DieTwoButton.Enabled = false;
                DieThreeButton.Enabled = false;
                DieFourButton.Enabled = false;
                DieFiveButton.Enabled = false;
            }
            DiceRolls++;

            Random random = new Random();
            if (ReRollOne == true) { die_one = random.Next(1, 7); }
            if (ReRollTwo == true) { die_two = random.Next(1, 7); }
            if (ReRollThree == true) { die_three = random.Next(1, 7); }
            if (ReRollFour == true) { die_four = random.Next(1, 7); }
            if (ReRollFive == true) { die_five = random.Next(1, 7); }
            ReRollOne = false; ReRollTwo = false; ReRollThree = false; ReRollFour = false; ReRollFive = false;
            KeepD1Label.Text = "D1"; KeepD2Label.Text = "D2"; KeepD3Label.Text = "D3"; KeepD4Label.Text = "D4"; KeepD5Label.Text = "D5";

            DieOnelabel.Text = "Die One: " + die_one.ToString();
            DieTwolabel.Text = "Die Two: " + die_two.ToString();
            DieThreelabel.Text = "Die Three: " + die_three.ToString();
            DieFourlabel.Text = "Die Four: " + die_four.ToString();
            DieFivelabel.Text = "Die Five: " + die_five.ToString();

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
            if (answer != 0 && ThreeKindTaken == false)
            {
                PosAns.Items.Add("Three Of A Kind: " + answer);
            }
            answer = FourKind();
            if (answer != 0 && FourKindTaken == false)
            {
                PosAns.Items.Add("Four Of A Kind: " + answer);
            }
            answer = FullHouse();
            if (answer != 0 && FullHouseTaken == false)
            {
                PosAns.Items.Add("Full House: " + answer);
            }
            answer = SmallStraight();
            if (answer != 0 && SmallStraightTaken == false)
            {
                PosAns.Items.Add("Small Straight: " + answer);
            }
            answer = LargeStraight();
            if (answer != 0 && LargeStraightTaken == false)
            {
                PosAns.Items.Add("Large Straight: " + answer);
            }
            answer = YahtzeeWin();
            if (answer != 0 && YahtzeeTaken == false)
            {
                PosAns.Items.Add("Yahtzee!: " + answer);
            }
            answer = ChanceWin();
            if (answer != 0 && ChanceTaken == false)
            {
                PosAns.Items.Add("Chance: " + answer);
            }

            if (PosAns.Items.Count <= 0 && DiceRolls > DiceRollsMax)
            {
                if (OnesTaken == false)
                {
                    PosAns.Items.Add("Ones: 0");
                }

                if (TwosTaken == false)
                {
                    PosAns.Items.Add("Twos: 0");
                }

                if (ThreesTaken == false)
                {
                    PosAns.Items.Add("Threes: 0");
                }

                if (FoursTaken == false)
                {
                    PosAns.Items.Add("Fours: 0");
                }

                if (FivesTaken == false)
                {
                    PosAns.Items.Add("Fives: 0");
                }

                if (SixesTaken == false)
                {
                    PosAns.Items.Add("Sixes: 0");
                }

                if (ThreeKindTaken == false)
                {
                    PosAns.Items.Add("Three Of A Kind: 0");
                }
                answer = FourKind();
                if (FourKindTaken == false)
                {
                    PosAns.Items.Add("Four Of A Kind: 0");
                }

                if (FullHouseTaken == false)
                {
                    PosAns.Items.Add("Full House: 0");
                }

                if (SmallStraightTaken == false)
                {
                    PosAns.Items.Add("Small Straight: 0");
                }

                if (LargeStraightTaken == false)
                {
                    PosAns.Items.Add("Large Straight: 0");
                }

                if (YahtzeeTaken == false)
                {
                    PosAns.Items.Add("Yahtzee!: 0");
                }

                if (ChanceTaken == false)
                {
                    PosAns.Items.Add("Chance: 0");
                }
            }
            else if (PosAns.Items.Count <= 0)
            {
                ChoseAnsButton.Enabled = false;
            }

            if (DiceRolls < DiceRollsMax)
            {
                DieOneButton.Enabled = true;
                DieTwoButton.Enabled = true;
                DieThreeButton.Enabled = true;
                DieFourButton.Enabled = true;
                DieFiveButton.Enabled = true;
            }
            if (Turn == MaxTurn)
            {
                Finished();
            }

            RollDiceButton.Enabled = false;
        }

        private void Finished()
        {
            int sum = 0, totalSum = 0;
            int[] Categories = new int[13];
            if(!Int32.TryParse(OnesAnsLabel.Text, out Categories[0]))
            {
                Categories[0] = 0;
            }
            if (!Int32.TryParse(TwosAnsLabel.Text, out Categories[1]))
            {
                Categories[1] = 0;
            }
            if (!Int32.TryParse(ThreesAnsLabel.Text, out Categories[2]))
            {
                Categories[2] = 0;
            }
            if (!Int32.TryParse(FoursAnsLabel.Text, out Categories[3]))
            {
                Categories[3] = 0;
            }
            if (!Int32.TryParse(FivesAnsLabel.Text, out Categories[4]))
            {
                Categories[4] = 0;
            }
            if (!Int32.TryParse(SixesAnsLabel.Text, out Categories[5]))
            {
                Categories[5] = 0;
            }
            if (!Int32.TryParse(ThreeKindAnsLabel.Text, out Categories[6]))
            {
                Categories[6] = 0;
            }
            if (!Int32.TryParse(FourKindAnsLabel.Text, out Categories[7]))
            {
                Categories[7] = 0;
            }
            if (!Int32.TryParse(FullHouseAnsLabel.Text, out Categories[8]))
            {
                Categories[8] = 0;
            }
            if (!Int32.TryParse(SmallStraightAnsLabel.Text, out Categories[9]))
            {
                Categories[9] = 0;
            }
            if (!Int32.TryParse(LargeStraightAnsLabel.Text, out Categories[10]))
            {
                Categories[10] = 0;
            }
            if (!Int32.TryParse(YahtzeeAnsLabel.Text, out Categories[11]))
            {
                Categories[11] = 0;
            }
            if (!Int32.TryParse(ChanceAnsLabel.Text, out Categories[12]))
            {
                Categories[12] = 0;
            }
           
            for (int i = 0; i < (Categories.Length) / 2; i++)
            {
                sum += Categories[i];
            }
            SumAnsLabel.Text = sum.ToString();
            for (int i = 0; i < Categories.Length; i++)
            {
                totalSum += Categories[i];
            }
            TotalScoreAnsLabel.Text = totalSum.ToString();
            DieOneButton.Enabled = false;
            DieTwoButton.Enabled = false;
            DieThreeButton.Enabled = false;
            DieFourButton.Enabled = false;
            DieFiveButton.Enabled = false;
            PlayAGButton.Visible = true;
            CurrTurnLabel.Text = "1";
            SumAnsLabel.Text = "";
            TotalScoreAnsLabel.Text = "";

        }

        private void PlayAGButton_Click(object sender, EventArgs e)
        {
            die_one = 0; die_two = 0; die_three = 0; die_four = 0; die_five = 0; Turn = 1; MaxTurn = 13; DiceRolls = 1; DiceRollsMax = 3;

            OnesTaken = false; TwosTaken = false; ThreesTaken = false; FoursTaken = false; FivesTaken = false;
            SixesTaken = false; ThreeKindTaken = false; FourKindTaken = false; FullHouseTaken = false; SmallStraightTaken = false; LargeStraightTaken = false; YahtzeeTaken = false; ChanceTaken = false;
            ReRollOne = true; ReRollTwo = true; ReRollThree = true; ReRollFour = true; ReRollFive = true;
            PosAns.Items.Clear();
            DieOneButton.Enabled = true; DieTwoButton.Enabled = true; DieThreeButton.Enabled = true;
            DieFourButton.Enabled = true; DieFiveButton.Enabled = true; RollDiceButton.Enabled = true;
            ChoseAnsButton.Enabled = true; OnesAnsLabel.Text = ""; TwosAnsLabel.Text = ""; ThreesAnsLabel.Text = ""; FoursAnsLabel.Text = ""; FivesAnsLabel.Text = "";
            SixesAnsLabel.Text = ""; ThreeKindAnsLabel.Text = ""; FourKindAnsLabel.Text = ""; FullHouseAnsLabel.Text = ""; SmallStraightAnsLabel.Text = "";
            LargeStraightAnsLabel.Text = ""; YahtzeeAnsLabel.Text = ""; ChanceAnsLabel.Text = ""; DieOnelabel.Text = "Die One: "; DieTwolabel.Text = "Die Two: "; DieThreelabel.Text = "Die Three: ";
            DieFourlabel.Text = "Die Four: "; DieFivelabel.Text = "Die Five: "; KeepD1Label.Text = "D1"; KeepD2Label.Text = "D2"; KeepD3Label.Text = "D3"; KeepD4Label.Text = "D4"; KeepD5Label.Text = "D5";
            SumAnsLabel.Text = ""; TotalScoreAnsLabel.Text = ""; CurrTurnLabel.Text = "";  
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

        private int FourKind()
        {
            int sum = 0;
            int[] Dice = new int[5];
            Dice[0] = die_one;
            Dice[1] = die_two;
            Dice[2] = die_three;
            Dice[3] = die_four;
            Dice[4] = die_five;

            for (int l = 0; l < Dice.Length; l++)
            {
                for (int k = 0; k < Dice.Length; k++)
                {
                    for (int i = 0; i < Dice.Length; i++)
                    {
                        for (int j = 0; j < Dice.Length; j++)
                        {
                            if (i != j && i != k && i != l && j != k && j != l && k != l )
                            {
                                if (Dice[i] == Dice[j] && Dice[j] == Dice[k] && Dice[k] == Dice[l])
                                {
                                    sum = die_one + die_two + die_three + die_four + die_five;
                                    return sum;
                                }
                            }
                        }
                    }
                }
            }
            return 0;
        }

        private void CheckCount(int DieCount, bool TwoCount, bool ThreeCount)
        {
            switch (DieCount)
            {
                case 2:
                    TwoCount = true;
                    break;
                case 3:
                    ThreeCount = true;
                    break;
            }
        }

        private int FullHouse()
        {
            bool TwoCount = false, ThreeCount = false;
            int OneNumb = 0, TwoNumb = 0, ThreeNumb = 0, FourNumb = 0, FiveNumb = 0; 
            int[] Dice = new int[5];
            Dice[0] = die_one;
            Dice[1] = die_two;
            Dice[2] = die_three;
            Dice[3] = die_four;
            Dice[4] = die_five;

            for (int die = 0; die < Dice.Length; die++)
            {
                switch (Dice[die])
                {
                    case 1:
                        OneNumb++;
                        break;
                    case 2:
                        TwoNumb++;
                        break;
                    case 3:
                        ThreeNumb++;
                        break;
                    case 4:
                        FourNumb++;
                        break;
                    case 5:
                        FiveNumb++;
                        break;
                }
            }

            CheckCount(OneNumb, TwoCount, ThreeCount);
            CheckCount(TwoNumb, TwoCount, ThreeCount);
            CheckCount(ThreeNumb, TwoCount, ThreeCount);
            CheckCount(FourNumb, TwoCount, ThreeCount);
            CheckCount(FiveNumb, TwoCount, ThreeCount);

            if (TwoCount == true && ThreeCount == true)
            {
                return 25;
            }
            else
            {
                return 0;
            }
        }

        private int SmallStraight()
        {
            string DiceOrder;
            int[] Dice = new int[5];
            Dice[0] = die_one;
            Dice[1] = die_two;
            Dice[2] = die_three;
            Dice[3] = die_four;
            Dice[4] = die_five;

            Array.Sort(Dice);
            DiceOrder = string.Join("", Dice);
            if (DiceOrder.Contains("1234") || DiceOrder.Contains("2345") || DiceOrder.Contains("3456"))
            {
                return 30;
            }

            return 0;
        }

        private int LargeStraight()
        {
            string DiceOrder;
            int[] Dice = new int[5];
            Dice[0] = die_one;
            Dice[1] = die_two;
            Dice[2] = die_three;
            Dice[3] = die_four;
            Dice[4] = die_five;

            Array.Sort(Dice);
            DiceOrder = string.Join("", Dice);
            if (DiceOrder == "12345" || DiceOrder == "23456")
            {
                return 40;
            }

            return 0;
        }

        private int YahtzeeWin()
        {
            if (die_one == die_two && die_two == die_three && die_three == die_four && die_four == die_five)
            {
                return 50;
            }

            return 0;
        }

        private int ChanceWin()
        {
            return die_one + die_two + die_three + die_four;
        }

        private void DieOneButton_Click(object sender, EventArgs e)
        {
            if (ReRollOne == false)
            {
                ReRollOne = true;
                KeepD1Label.Text = "";
                ChoseAnsButton.Enabled = false;
                RollDiceButton.Enabled = true;
            }
            else
            {
                ReRollOne = false;
                KeepD1Label.Text = "D1";
                ChoseAnsButton.Enabled = true;
                if (ReRollOne == false && ReRollTwo == false && ReRollThree == false && ReRollFour == false && ReRollFive == false)
                {
                    RollDiceButton.Enabled = false;
                }
            }
        }

        private void DieTwoButton_Click(object sender, EventArgs e)
        {
            if (ReRollTwo == false)
            {
                ReRollTwo = true;
                KeepD2Label.Text = "";
                ChoseAnsButton.Enabled = false;
                RollDiceButton.Enabled = true;
            }
            else
            {
                ReRollTwo = false;
                KeepD2Label.Text = "D2";
                ChoseAnsButton.Enabled = true;
                if (ReRollOne == false && ReRollTwo == false && ReRollThree == false && ReRollFour == false && ReRollFive == false)
                {
                    RollDiceButton.Enabled = false;
                }
            }
        }

        private void DieThreeButton_Click(object sender, EventArgs e)
        {
            if (ReRollThree == false)
            {
                ReRollThree = true;
                KeepD3Label.Text = "";
                ChoseAnsButton.Enabled = false;
                RollDiceButton.Enabled = true;
            }
            else
            {
                ReRollThree = false;
                KeepD3Label.Text = "D3";
                ChoseAnsButton.Enabled = true;
                if (ReRollOne == false && ReRollTwo == false && ReRollThree == false && ReRollFour == false && ReRollFive == false)
                {
                    RollDiceButton.Enabled = false;
                }
            }
        }

        private void DieFourButton_Click(object sender, EventArgs e)
        {
            if (ReRollFour == false)
            {
                ReRollFour = true;
                KeepD4Label.Text = "";
                ChoseAnsButton.Enabled = false;
                RollDiceButton.Enabled = true;
            }
            else
            {
                ReRollFour = false;
                KeepD4Label.Text = "D4";
                ChoseAnsButton.Enabled = true;
                if (ReRollOne == false && ReRollTwo == false && ReRollThree == false && ReRollFour == false && ReRollFive == false)
                {
                    RollDiceButton.Enabled = false;
                }
            }
        }

        private void DieFiveButton_Click(object sender, EventArgs e)
        {
            if (ReRollFive == false)
            {
                ReRollFive = true;
                KeepD5Label.Text = "";
                ChoseAnsButton.Enabled = false;
                RollDiceButton.Enabled = true;
            }
            else
            {
                ReRollFive = false;
                KeepD5Label.Text = "D5";
                ChoseAnsButton.Enabled = true;
                if(ReRollOne == false && ReRollTwo == false && ReRollThree == false && ReRollFour == false && ReRollFive == false)
                {
                    RollDiceButton.Enabled = false;
                }
            }
        }

        private void ChoseAnsButton_Click(object sender, EventArgs e)
        {
            SetAnswer(PosAns.SelectedItem);
            PosAns.Items.Clear();
            RollDiceButton.Enabled = true;
            DiceRolls = 1;
            ReRollOne = true; ReRollTwo = true; ReRollThree = true; ReRollFour = true; ReRollFive = true;
            DieOneButton.Enabled = false;
            DieTwoButton.Enabled = false;
            DieThreeButton.Enabled = false;
            DieFourButton.Enabled = false;
            DieFiveButton.Enabled = false;
            ChoseAnsButton.Enabled = false;
            Turn++;
        }

        private void SetAnswer(object ans)
        {
            string strg_ans = ans.ToString();
            if (strg_ans.Contains("Ones"))
            {
                OnesAnsLabel.Text = UpperSection(1).ToString();
                OnesTaken = true;
            }
            else if (strg_ans.Contains("Twos"))
            {
                TwosAnsLabel.Text = UpperSection(2).ToString();
                TwosTaken = true;
            }
            else if (strg_ans.Contains("Threes"))
            {
                ThreesAnsLabel.Text = UpperSection(3).ToString();
                ThreesTaken = true;
            }
            else if (strg_ans.Contains("Fours"))
            {
                FoursAnsLabel.Text = UpperSection(4).ToString();
                FoursTaken = true;
            }
            else if (strg_ans.Contains("Fives"))
            {
                FivesAnsLabel.Text = UpperSection(5).ToString();
                FivesTaken = true;
            }
            else if (strg_ans.Contains("Sixes"))
            {
                SixesAnsLabel.Text = UpperSection(6).ToString();
                SixesTaken = true;
            }
            else if (strg_ans.Contains("Three Of A Kind"))
            {
                ThreeKindAnsLabel.Text = ThreeKind().ToString();
                ThreeKindTaken = true;
            }
            else if (strg_ans.Contains("Four Of A Kind"))
            {
              FourKindAnsLabel.Text = FourKind().ToString();
                FourKindTaken = true;
            }
            else if (strg_ans.Contains("Full House"))
            {
               FullHouseAnsLabel.Text = FullHouse().ToString();
                FullHouseTaken = true;
            }
            else if (strg_ans.Contains("Small Straight"))
            {
                SmallStraightAnsLabel.Text = SmallStraight().ToString();
                SmallStraightTaken = true;
            }
            else if (strg_ans.Contains("Large Straight"))
            {
                LargeStraightAnsLabel.Text = LargeStraight().ToString();
                LargeStraightTaken = true;
            }
            else if (strg_ans.Contains("Yahtzee"))
            {
               YahtzeeAnsLabel.Text = YahtzeeWin().ToString();
                YahtzeeTaken = true;
            }
            else if (strg_ans.Contains("Chance"))
            {
                ChanceAnsLabel.Text = ChanceWin().ToString();
                ChanceTaken = true;
            }
        }
    }
}
