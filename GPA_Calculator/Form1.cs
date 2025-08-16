using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Menu;

namespace GPA_Calculator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void buttonCalculate_Click(object sender, EventArgs e)
        {
            TextBox[] midtermBoxes = { textBox2, textBox11, textBox12, textBox8, textBox14, textBox17, textBox20, textBox23 };
            TextBox[] finalBoxes = { textBox3, textBox7, textBox5, textBox10, textBox15, textBox18, textBox21, textBox24 };
            ComboBox[] creditBoxes = { comboBox1, comboBox2, comboBox3, comboBox4, comboBox5, comboBox6, comboBox7, comboBox8 };
            Label[] scoreLabels = { label5, label6, label7, label8, label9, label10, label11, label12 };

            double totalWeightedScore = 0;
            int totalCredits = 0;

            for (int i = 0; i < 8; i++)
            {
                if (double.TryParse(midtermBoxes[i].Text, out double vize) &&
                    double.TryParse(finalBoxes[i].Text, out double final) &&
                    int.TryParse(creditBoxes[i].Text, out int credit))
                {
                    double avg = (vize * 0.4 + final * 0.6);
                    string grade;
                    if (avg >= 90 && avg <= 100)
                    {
                        grade = "A";
                    }
                    else if (avg >= 85 && avg <= 89)
                    {
                        grade = "A-";
                    }
                    else if (avg >= 80 && avg <= 84)
                    {
                        grade = "B+";
                    }
                    else if (avg >= 75 && avg <= 79)
                    {
                        grade = "B";
                    }
                    else if (avg >= 70 && avg <= 74)
                    {
                        grade = "B-";
                    }
                    else if (avg >= 65 && avg <= 69)
                    {
                        grade = "C+";
                    }
                    else if (avg >= 60 && avg <= 64)
                    {
                        grade = "C";
                    }
                    else if (avg >= 55 && avg <= 59)
                    {
                        grade = "C-";
                    }
                    else if (avg >= 50 && avg <= 54)
                    {
                        grade = "D";
                    }
                    else
                        grade = "F";
                    scoreLabels[i].Text = "Course Score: " + (avg / 25.0).ToString("F2") + " / " + grade;
                    totalWeightedScore += avg * credit;
                    totalCredits += credit;
                }
                else
                {
                    scoreLabels[i].Text = "Incomplete data!";
                }
            }

            if (totalCredits > 0)
                label13.Text = "GPA: " + (totalWeightedScore / (totalCredits*25.0)).ToString("F2");
            else
                label13.Text = "GPA cannot be calculated";
        }








        
        
    }
}
