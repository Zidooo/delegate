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

        public Form1()
        {
            InitializeComponent();
        }
        Account accc;
        void DisplayMessage(Account sender, AccountEventArgs e)
        {
            MessageBox.Show($"Сумма транзакции: {e.Sum}");
            MessageBox.Show(e.Message);
            MessageBox.Show($"Текущая сумма на счете: {sender.sum}");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int x = Convert.ToInt32(textBox3.Text);
             if (accc.sum < x)
             {
                 accc.Notify += DisplayMessage;   // Добавляем обработчик для события Notify
                 listBox1.Items.Clear();
                 listBox1.Items.Add("На счету недосатточно средств");
                 accc.Notify -= DisplayMessage;   // Добавляем обработчик для события Notify
             }
             else
             {
                 accc.Notify += DisplayMessage;   // Добавляем обработчик для события Notify
                 accc.Take(Convert.ToInt32(textBox3.Text));
                 listBox1.Items.Clear();
                 listBox1.Items.Add($"Владелец: {accc.fio}, счет: {accc.sum}");
                 accc.Notify -= DisplayMessage;   // Добавляем обработчик для события Notify
             }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            accc.Notify += DisplayMessage;   // Добавляем обработчик для события Notify
            accc.Add(Convert.ToInt32(textBox3.Text));
            listBox1.Items.Clear();
            listBox1.Items.Add($"Владелец: {accc.fio}, счет: {accc.sum}");
            accc.Notify -= DisplayMessage;   // Добавляем обработчик для события Notify
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            accc = new Account(Convert.ToInt32(textBox2.Text), textBox1.Text);
            listBox1.Items.Clear();
            listBox1.Items.Add($"Владелец: {accc.fio}, счет: {accc.sum}");
            button2.Visible = true;
            button3.Visible = true;
            textBox3.Visible = true;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
