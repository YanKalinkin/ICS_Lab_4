using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;
using System.Windows.Forms;
using System.Security.Cryptography;
using ICS_Lab_4_dll;

namespace ICS_Lab_4
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Int32 number_p;
            Int32 number_q;
            if (!int.TryParse(textBox3.Text, out int int_or_not) || !int.TryParse(textBox4.Text, out int int_not))
                MessageBox.Show("Entered numbers are not integer!");
            else if (!MyRSA.Miller_Rabin(Convert.ToInt32(textBox3.Text), 20) || !MyRSA.Miller_Rabin(Convert.ToInt32(textBox4.Text),20))
            {
                MessageBox.Show("Entered numbers are not simple!");
            }
            else if (Convert.ToInt32(textBox3.Text) == Convert.ToInt32(textBox4.Text))
            {
                MessageBox.Show("Entered number are simple but equal!");
            }
            else
            {
                number_p = Convert.ToInt32(textBox3.Text);
                number_q = Convert.ToInt32(textBox4.Text);
                if (!int.TryParse(textBox6.Text, out int int_check))
                    MessageBox.Show("Number 'e' is not integer!");
                else if (!MyRSA.e_check(Convert.ToInt32(textBox6.Text), MyRSA.euler_f(number_p, number_q), number_p, number_q))
                    MessageBox.Show("Number 'e' is not correct!");
                else
                {
                    textBox5.Text = MyRSA.d_find(Convert.ToInt32(textBox6.Text), MyRSA.euler_f(number_p, number_q)).ToString();
                    textBox7.Text = textBox6.Text;
                    textBox8.Text = MyRSA.n_module(number_p, number_q).ToString();
                    textBox10.Text = textBox5.Text;
                    textBox9.Text = textBox8.Text;
                }
            }
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < textBox1.Text.Length; i++)
            {
                textBox2.Text += MyRSA.RSA_encrypt(MyRSA.get_index(textBox1.Text[i]), Convert.ToInt32(textBox7.Text), Convert.ToInt32(textBox8.Text)).ToString();
                textBox2.Text += ' ';
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBox1.Text = string.Empty;
            textBox2.Text = string.Empty;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int counter = 0;
            if (textBox2.Text[textBox2.Text.Length - 1] != ' ')
                textBox2.Text += ' ';
            for (int i = 0; i < textBox2.Text.Length; i++)
            {
                if (textBox2.Text[i] == ' ')
                    counter++;
            }
            for (int j = 0; j < counter; j++)
            {
                string set = "";
                for (int k = 0; k < textBox2.Text.Length; k++)
                {
                    if (textBox2.Text[k] != ' ')
                        set += textBox2.Text[k];
                    else
                        break;
                }
                textBox2.Text = textBox2.Text.Remove(0, set.Length + 1);
                textBox1.Text += MyRSA.RSA_decrypt(Convert.ToInt32(set), Convert.ToInt32(textBox10.Text), Convert.ToInt32(textBox9.Text));
            }
        }
    }
}
