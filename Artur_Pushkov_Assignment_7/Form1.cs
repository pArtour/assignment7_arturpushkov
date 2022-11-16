using System.IO;
namespace Artur_Pushkov_Assignment_7
{
    public partial class Form1 : Form
    {
        string[] correctAnswersArray = { "B", "D", "A", "A", "C", "A", "B", "A", "C", "D", "B","C", "D", "A", "D", "C", "C", "B", "D", "A" };

        string[] studentAnswersArray = new string[20];
        public Form1()
        {
            InitializeComponent();
        }

        private void openBtn_Click(object sender, EventArgs e)
        {
            listBox2.Items.AddRange(correctAnswersArray);

            OpenFileDialog open = new OpenFileDialog();
            if (open.ShowDialog() == DialogResult.OK)
            {
                textBox2.Text = open.FileName;
            }

            StreamReader sReader = new StreamReader(open.FileName);
            int index = 0;

            while (index < correctAnswersArray.Length && !sReader.EndOfStream)
            {
                studentAnswersArray[index] = sReader.ReadLine();
                index++;
            }
            foreach (string str in studentAnswersArray)
            {
                listBox1.Items.Add(str);
            }

            openBtn.Enabled = false;
        }

        private void goBtn_Click(object sender, EventArgs e)
        {
            int i = 0;
            int qNumber = 1;
            int correctAnsw = 0;
            int incorrectAnsw = 0;
            do
            {
                if (studentAnswersArray[i] == correctAnswersArray[i])
                {
                    correctAnsw++;
                }
                if (studentAnswersArray[i] != correctAnswersArray[i])
                {
                    listBox3.Items.Add(qNumber);
                    incorrectAnsw++;
                }
                i++;
                qNumber++;
            }

            while (i != 20);
            correct_count.Text = correctAnsw.ToString();
            incorrect_count.Text = incorrectAnsw.ToString();
            if (correctAnsw >= 15)
            {
                textBox1.Text = "Passed!";

            }
            if (correctAnsw < 15)
            {
                textBox1.Text = "Failed";

            }

            goBtn.Enabled = false;
        }

        private void clearBtn_Click(object sender, EventArgs e)
        {
            openBtn.Enabled = true;
            goBtn.Enabled = true;
            listBox1.Items.Clear();
            listBox2.Items.Clear();
            listBox3.Items.Clear();
            textBox1.Clear();
            textBox2.Clear();
            correct_count.Text = "";
            incorrect_count.Text = "";
        }

        private void incorrect_count_Click(object sender, EventArgs e)
        {

        }
    }
}