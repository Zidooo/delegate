using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static ClassLibrary1.Class1;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public string sum { get; }
        public string fio { get; }
        auth iniz;

        public Form1()
        {
            InitializeComponent();
        }

        public class auth
        {
            public string fio;
            public int sum;

            public auth(string FIO, int SUM)
            {
                fio = FIO;
                sum = SUM;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // создаем банковский счет
            Account account = new Account(Convert.ToInt32(textBox2.Text));
            // Добавляем в делегат ссылку на метод PrintSimpleMessage
            account.RegisterHandler(PrintSimpleMessage);
            // Два раза подряд пытаемся снять деньги
            account.Take(Convert.ToInt32(textBox3.Text));
            void PrintSimpleMessage(string message) => listBox1.Items.Add(message);

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            // создаем банковский счет
            Account account = new Account(Convert.ToInt32(textBox2.Text));
            // Добавляем в делегат ссылку на метод PrintSimpleMessage
            account.RegisterHandler(PrintSimpleMessage);
            // Два раза подряд пытаемся снять деньги
            account.Add(Convert.ToInt32(textBox3.Text));
            void PrintSimpleMessage(string message) => listBox1.Items.Add(message);
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            iniz = new auth(fio, Convert.ToInt32(sum));
        }
    }
}
