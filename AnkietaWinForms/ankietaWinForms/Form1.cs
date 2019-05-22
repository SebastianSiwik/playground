using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ankietaWinForms
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LABEL_QUESTION = new Point(ClientSize.Width / 2 - labelQuestion.Size.Width / 2, (int)(ClientSize.Height * 0.13));
            LABEL_ANSWER = new Point(ClientSize.Width / 2 - labelAnswer.Size.Width / 2, (int)(ClientSize.Height * 1.1));
            BUTTON_YES = new Point(ClientSize.Width / 2 - buttonYes.Width - (int)(buttonNo.Width * 0.1), (int)(ClientSize.Height * 0.3));
            BUTTON_NO = new Point(ClientSize.Width / 2 + (int)(buttonNo.Width * 0.1), (int)(ClientSize.Height * 0.3));
            BUTTON_CHOICE1 = new Point(ClientSize.Width / 2 - buttonChoice1.Width - (int)(buttonChoice2.Width * 0.1), (int)(ClientSize.Height * 0.6));
            BUTTON_CHOICE2 = new Point(ClientSize.Width / 2 + (int)(buttonChoice2.Width * 0.1), (int)(ClientSize.Height * 0.6));

            labelQuestion.Location = LABEL_QUESTION;
            labelAnswer.Location = LABEL_ANSWER;
            buttonYes.Location = BUTTON_YES;
            buttonNo.Location = BUTTON_NO;
            buttonChoice1.Location = BUTTON_CHOICE1;
            buttonChoice2.Location = BUTTON_CHOICE2;
        }
        protected override bool ProcessDialogKey(Keys keyData)
        {
            if (ModifierKeys == Keys.None && keyData == Keys.Escape)
            {
                Application.Exit();
                return true;
            }
            return base.ProcessDialogKey(keyData);
        }
        private void UpdateQuestionLabel()
        {
            LABEL_QUESTION = new Point(ClientSize.Width / 2 - labelQuestion.Size.Width / 2, (int)(ClientSize.Height * 0.13));
            labelQuestion.Location = new Point(LABEL_QUESTION.X, labelQuestion.Location.Y);

        }
        private void UpdateAnswers()
        {
            if(answerIndex == 1 || answerIndex == 3 || answerIndex == 5)
            {
                buttonChoice1.Visible = true;
                buttonChoice2.Visible = true;
            }
            else
            {
                buttonChoice1.Visible = false;
                buttonChoice2.Visible = false;
            }

            if(answerIndex == 7)
            {
                buttonYes.Visible = false;
                buttonNo.Visible = false;
                buttonChoice1.Visible = false;
                buttonChoice2.Visible = false;
            }
            
            if(answerIndex == 1)
            {
                buttonYes.Image = Resample(Image.FromFile(@"ankietaWinForms\\ankietaWinForms\\bill.jpg"), buttonYes.Size);
                buttonNo.Image = Resample(Image.FromFile("C:\\Users\\strze\\source\\repos\\ankietaWinForms\\ankietaWinForms\\rain.jpg"), buttonNo.Size);
                buttonChoice1.Image = Resample(Image.FromFile("C:\\Users\\strze\\source\\repos\\ankietaWinForms\\ankietaWinForms\\tiger.jpg"), buttonChoice1.Size);
                buttonChoice2.Image = Resample(Image.FromFile("C:\\Users\\strze\\source\\repos\\ankietaWinForms\\ankietaWinForms\\puppy.jpg"), buttonChoice2.Size);
            }
            else if(answerIndex == 5)
            {
                pictureBox.Enabled = true;
                pictureBox.Location = new Point(ClientSize.Width / 2 - pictureBox.Width / 2, (int)(ClientSize.Height * 0.19)); ;
                pictureBox.Image = Resample(Image.FromFile("C:\\Users\\strze\\source\\repos\\ankietaWinForms\\ankietaWinForms\\panorama.jpg"), pictureBox.Size);
            }
            else
            {
                pictureBox.Enabled = false;
                pictureBox.Image = null;
                buttonYes.Image = null;
                buttonNo.Image = null;
                buttonChoice1.Image = null;
                buttonChoice2.Image = null;
            }

            buttonYes.Text = answers[answerIndex, 0];
            buttonNo.Text = answers[answerIndex, 1];
            buttonChoice1.Text = answers[answerIndex, 2];
            buttonChoice2.Text = answers[answerIndex, 3];
        }
        private static Bitmap Resample(Image img, Size size)
        {
            var bmp = new Bitmap(size.Width, size.Height,
                                 System.Drawing.Imaging.PixelFormat.Format32bppPArgb);
            using (var gr = Graphics.FromImage(bmp))
            {
                gr.DrawImage(img, new Rectangle(Point.Empty, size));
            }
            return bmp;
        }

        private void DisableButtons()
        {
            if (buttonYes.Enabled && buttonNo.Enabled && buttonChoice1.Enabled && buttonChoice2.Enabled)
            {
                buttonYes.Enabled = false;
                buttonNo.Enabled = false;
                buttonChoice1.Enabled = false;
                buttonChoice2.Enabled = false;
            }
        }
        private void EnableButtons()
        {
            if (!buttonYes.Enabled && !buttonNo.Enabled && !buttonChoice1.Enabled && !buttonChoice2.Enabled)
            {
                buttonYes.Enabled = true;
                buttonNo.Enabled = true;
                buttonChoice1.Enabled = true;
                buttonChoice2.Enabled = true;
            }
        }
        private void colorTimer_Tick(object sender, EventArgs e)
        {
            if (justSwitchedColors)
            {
                if (happiness < 0)
                {
                    if (R != 254)
                        R++;
                    if (G != 30)
                        G--;
                    if (B != 30)
                        B--;

                    if ((R == 254 || R == 253) && (G == 30 || G == 31) && (B == 30 || B == 31))
                        justSwitchedColors = false;
                }
                else if (happiness == 0)
                {
                    if (R != 30)
                        R--;
                    if (G != 30)
                        G--;
                    if (B != 254)
                        B++;

                    if ((R == 30 || R == 31) && (G == 30 || G==31) && (B == 254 || B == 253))
                        justSwitchedColors = false;
                }
                else
                {
                    if (R != 30)
                        R--;
                    if (G != 254)
                        G++;
                    if (B != 30)
                        B--;

                    if ((R == 30 || R == 31) && (G == 254 || G == 253) && (B == 30 || B == 31))
                        justSwitchedColors = false;
                }
            }

            else if (happiness < 0)
            {
                if (R <= 140)
                    reverse = false;
                if (R >= 254)
                    reverse = true;

                if (reverse)
                {
                    R -= 2;
                    G++;
                    B++;
                }
                else
                {
                    R += 2;
                    G--;
                    B--;
                }
            }
            else if (happiness == 0)
            {
                if (B <= 140)
                    reverse = false;
                if (B >= 254)
                    reverse = true;

                if (reverse)
                {
                    R++;
                    G++;
                    B -= 2;
                }
                else
                {
                    R--;
                    G--;
                    B += 2;
                }
            }
            else
            {
                if (G <= 140)
                    reverse = false;
                if (G >= 254)
                    reverse = true;

                if (reverse)
                {
                    R++;
                    G -= 2;
                    B++;
                }
                else
                {
                    R--;
                    G += 2;
                    B--;
                }
            }

            BackColor = Color.FromArgb(R, G, B);
            label1.Text = Convert.ToString(BackColor);

        }
        private void timer_Tick(object sender, EventArgs e)
        {
            DisableButtons();

            Animation.MoveLabel(ref labelQuestion, Animation.Direction.UP);

            if (buttonIndex == 0)
            {
                Animation.MoveButton(ref buttonNo, Animation.Direction.RIGHT);
                Animation.MoveButton(ref buttonYes, Animation.Direction.CENTER_RIGHT);
                Animation.MoveButton(ref buttonChoice1, Animation.Direction.LEFT);
                Animation.MoveButton(ref buttonChoice2, Animation.Direction.RIGHT);
            }
            else if(buttonIndex == 1)
            {
                Animation.MoveButton(ref buttonYes, Animation.Direction.LEFT);
                Animation.MoveButton(ref buttonNo, Animation.Direction.CENTER_LEFT);
                Animation.MoveButton(ref buttonChoice1, Animation.Direction.LEFT);
                Animation.MoveButton(ref buttonChoice2, Animation.Direction.RIGHT);
            }
            else if(buttonIndex == 2)
            {
                Animation.MoveButton(ref buttonYes, Animation.Direction.LEFT);
                Animation.MoveButton(ref buttonNo, Animation.Direction.RIGHT);
                Animation.MoveButton(ref buttonChoice1, Animation.Direction.CENTER_RIGHT);
                Animation.MoveButton(ref buttonChoice2, Animation.Direction.RIGHT);
            }
            else if(buttonIndex == 3)
            {
                Animation.MoveButton(ref buttonYes, Animation.Direction.LEFT);
                Animation.MoveButton(ref buttonNo, Animation.Direction.RIGHT);
                Animation.MoveButton(ref buttonChoice1, Animation.Direction.LEFT);
                Animation.MoveButton(ref buttonChoice2, Animation.Direction.CENTER_LEFT);
            }


            if ((buttonYes.Location.X + buttonYes.Width / 2) >= ClientSize.Width / 2 ||
                (buttonNo.Location.X + buttonNo.Width / 2) <= ClientSize.Width / 2 ||
                (buttonChoice1.Location.X + buttonChoice1.Width / 2) >= ClientSize.Width / 2 ||
                (buttonChoice2.Location.X + buttonChoice2.Width / 2) <= ClientSize.Width / 2)
            {
                questionIndex++;
                answerIndex++;
                labelQuestion.Text = questions[questionIndex];
                UpdateQuestionLabel();
                UpdateAnswers();
                timerBack.Enabled = true;
                timer.Enabled = false;
            }
        }
        private void timerBack_Tick(object sender, EventArgs e)
        {
            Animation.MoveLabel(ref labelQuestion, Animation.Direction.DOWN);

            if (buttonIndex == 0)
            {
                Animation.ButtonBack(ref buttonYes, Animation.Direction.LEFT, Animation.Distance.SHORT);
                Animation.ButtonBack(ref buttonNo, Animation.Direction.LEFT, Animation.Distance.LONG);
                Animation.ButtonBack(ref buttonChoice1, Animation.Direction.RIGHT, Animation.Distance.LONG);
                Animation.ButtonBack(ref buttonChoice2, Animation.Direction.LEFT, Animation.Distance.LONG);

                if (buttonYes.Location.X <= BUTTON_YES.X && buttonNo.Location.X <= BUTTON_NO.X)
                {
                    EnableButtons();
                    timerBack.Enabled = false;
                }
            }
            else if(buttonIndex == 1)
            {
                Animation.ButtonBack(ref buttonYes, Animation.Direction.RIGHT, Animation.Distance.LONG);
                Animation.ButtonBack(ref buttonNo, Animation.Direction.RIGHT, Animation.Distance.SHORT);
                Animation.ButtonBack(ref buttonChoice1, Animation.Direction.RIGHT, Animation.Distance.LONG);
                Animation.ButtonBack(ref buttonChoice2, Animation.Direction.LEFT, Animation.Distance.LONG);

                if (buttonYes.Location.X >= BUTTON_YES.X && buttonNo.Location.X >= BUTTON_NO.X)
                {
                    EnableButtons();
                    timerBack.Enabled = false;
                }
            }
            else if(buttonIndex == 2)
            {
                Animation.ButtonBack(ref buttonYes, Animation.Direction.RIGHT, Animation.Distance.LONG);
                Animation.ButtonBack(ref buttonNo, Animation.Direction.LEFT, Animation.Distance.LONG);
                Animation.ButtonBack(ref buttonChoice1, Animation.Direction.LEFT, Animation.Distance.SHORT);
                Animation.ButtonBack(ref buttonChoice2, Animation.Direction.LEFT, Animation.Distance.LONG);

                if (buttonChoice1.Location.X <= BUTTON_YES.X && buttonChoice2.Location.X <= BUTTON_NO.X)
                {
                    EnableButtons();
                    timerBack.Enabled = false;
                }
            }
            else if(buttonIndex == 3)
            {
                Animation.ButtonBack(ref buttonYes, Animation.Direction.RIGHT, Animation.Distance.LONG);
                Animation.ButtonBack(ref buttonNo, Animation.Direction.LEFT, Animation.Distance.LONG);
                Animation.ButtonBack(ref buttonChoice1, Animation.Direction.RIGHT, Animation.Distance.LONG);
                Animation.ButtonBack(ref buttonChoice2, Animation.Direction.RIGHT, Animation.Distance.SHORT);

                if (buttonChoice1.Location.X >= BUTTON_YES.X && buttonChoice2.Location.X >= BUTTON_NO.X)
                {
                    EnableButtons();
                    timerBack.Enabled = false;
                }
            }
            if(questionIndex == 7)
            {
                pictureBox.Size = new Size(512, 512);
                pictureBox.Location = new Point(ClientSize.Width / 2 - pictureBox.Width / 2, ClientSize.Height / 2 - pictureBox.Height / 2);
                if (happiness < 1)
                {
                    pictureBox.Image = Resample(Image.FromFile("C:\\Users\\strze\\source\\repos\\ankietaWinForms\\ankietaWinForms\\sad.png"), pictureBox.Size);
                    labelAnswer.Text = "You are a sad person";
                }
                else if (happiness > -1)
                {
                    pictureBox.Image = Resample(Image.FromFile("C:\\Users\\strze\\source\\repos\\ankietaWinForms\\ankietaWinForms\\happy.png"), pictureBox.Size);
                    labelAnswer.Text = "You are a happy person";
                }
                else
                {
                    pictureBox.Image = Resample(Image.FromFile("C:\\Users\\strze\\source\\repos\\ankietaWinForms\\ankietaWinForms\\neither.png"), pictureBox.Size);
                    labelAnswer.Text = "You're neither happy nor sad";
                }
                pictureBox.Enabled = true;
                if (!justFinishedQuiz)
                {
                    labelAnswer.Location = new Point(ClientSize.Width / 2 - labelAnswer.Width / 2, ClientSize.Height);
                }
                Animation.ResultLabelUp(ref labelAnswer);
            }
        }
        private void anyButton_Click(object sender, EventArgs e)
        {
            Button b = sender as Button;
            if (b.MinimumSize == new Size(0, 0))
            {
                buttonIndex = 0;
                happiness++;
            }
            else if (b.MinimumSize == new Size(1, 1))
            {
                buttonIndex = 1;
                happiness--;
            }
            else if (b.MinimumSize == new Size(2, 2))
            {
                buttonIndex = 2;
                happiness--;
            }
            else if (b.MinimumSize == new Size(3, 3))
            {
                buttonIndex = 3;
                happiness++;
            }
            if ((happiness - 2) == 0 || (happiness + 2) == 0)
            {
                justSwitchedColors = true;
            }

            timer.Enabled = true;
        }

        bool reverse = true, justSwitchedColors = false;
        static bool justFinishedQuiz = false;
        byte R = 146, G = 146, B = 142;
        sbyte happiness = 0;
        static byte buttonIndex = 0, questionIndex = 0, answerIndex = 0;

        static Point LABEL_QUESTION, LABEL_ANSWER, BUTTON_YES, BUTTON_NO, BUTTON_CHOICE1, BUTTON_CHOICE2;
        static Size _clientSize = new Size(1536, 864);
        static string[] questions = {"Did you eat breakfast this morning?",
                                    "Which picture do you like the most?",
                                    "Do you feel cold sweat running down your back?",
                                    "What would you rather do now?",
                                    "Does your everyday life exert a lot of stress on you?",
                                    "What does this picture make you feel?",
                                    "Are you sleepy?",
                                    "The result of your test is..."};
        static string[,] answers = { {"YES", "NO", "", ""},
                                    {"", "", "", "" },
                                    {"NO", "YES", "", "" },
                                    {"EAT A BURGER", "TALK TO MY FRIEND", "LEAVE", "PARTY AND DANCE" },
                                    {"NO", "YES", "", "" },
                                    {"HAPPINESS", "ANGER", "SADNESS", "INTERESTED" },
                                    {"NOT REALLY", "I AM", "", "" },
                                    {"", "", "", "" } };


        static public class Animation
        {
            static public void MoveButton(ref Button button, Direction direction)
            {
                if (direction == Direction.LEFT)
                {
                    if (button.Location.X > -button.Size.Width)
                        button.Location = new Point(button.Location.X - 8, button.Location.Y);
                }
                else if (direction == Direction.RIGHT)
                {
                    if (button.Location.X < (_clientSize.Width + button.Size.Width))
                        button.Location = new Point(button.Location.X + 8, button.Location.Y);
                }
                else if (direction == Direction.CENTER_LEFT)
                {
                    if ((button.Location.X + button.Width / 2) > _clientSize.Width / 2)
                        button.Location = new Point(button.Location.X - 2, button.Location.Y);
                }
                else if (direction == Direction.CENTER_RIGHT)
                {
                    if ((button.Location.X + button.Width / 2) < _clientSize.Width / 2)
                        button.Location = new Point(button.Location.X + 2, button.Location.Y);
                }
            }
            static public void ButtonBack(ref Button button, Direction direction, Distance distance)
            {
                if (direction == Direction.LEFT && distance == Distance.LONG)
                {
                    if (button.Location.X != (buttonIndex == 1 ? BUTTON_NO.X : BUTTON_CHOICE2.X))
                        button.Location = new Point(button.Location.X - 8, button.Location.Y);
                }
                else if (direction == Direction.LEFT && distance == Distance.SHORT)
                {
                    if (button.Location.X != (buttonIndex == 0 ? BUTTON_YES.X : BUTTON_CHOICE1.X))
                        button.Location = new Point(button.Location.X - 2, button.Location.Y);
                }
                else if (direction == Direction.RIGHT && distance == Distance.LONG)
                {
                    if (button.Location.X != (buttonIndex == 0 ? BUTTON_YES.X : BUTTON_CHOICE1.X))
                        button.Location = new Point(button.Location.X + 8, button.Location.Y);
                }
                else if (direction == Direction.RIGHT && distance == Distance.SHORT)
                {
                    if (button.Location.X != (buttonIndex == 1 ? BUTTON_NO.X : BUTTON_CHOICE2.X))
                        button.Location = new Point(button.Location.X + 2, button.Location.Y);
                }
            }

            static public void MoveLabel(ref Label label, Direction direction)
            {
                if (direction == Direction.UP)
                {
                    if (label.Location.Y >= -100)
                        label.Location = new Point(label.Location.X, label.Location.Y - 2);
                }
                else if (direction == Direction.DOWN)
                {
                    if (label.Location.Y != LABEL_QUESTION.Y)
                        label.Location = new Point(label.Location.X, label.Location.Y + 2);
                }
            }

            static public void ResultLabelUp(ref Label label)
            {
                if (!justFinishedQuiz)
                    justFinishedQuiz = true;
                if(label.Location.Y >= _clientSize.Height - 100)
                    label.Location = new Point(label.Location.X, label.Location.Y - 2);
            }

            public enum Direction
            {
                LEFT, RIGHT, UP, DOWN,
                CENTER_RIGHT, CENTER_LEFT
            }
            public enum Distance
            {
                LONG, SHORT
            }

        }
    }
}
