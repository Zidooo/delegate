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
using Microsoft.Toolkit.Uwp.Notifications;

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
            MessageBox.Show($"Владелец счета: {accc.fio}\nСумма транзакции: {e.Sum} руб.\n"+ e.Message+$"\nТекущая сумма на счете: {sender.sum} руб.");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int x = Convert.ToInt32(textBox3.Text);
             if (accc.sum < x)
             {
                 accc.Notify += DisplayMessage;   // Добавляем обработчик для события Notify
                 listBox1.Items.Clear();
                 listBox1.Items.Add("На счету недостаточно средств");
                 accc.Notify -= DisplayMessage;   // Добавляем обработчик для события Notify
                new ToastContentBuilder()
                .AddText($"На счету недостаточно средств")
                .Show();
            }
             else
             {
                 accc.Notify += DisplayMessage;   // Добавляем обработчик для события Notify
                 accc.Take(Convert.ToInt32(textBox3.Text));
                 listBox1.Items.Clear();
                 listBox1.Items.Add($"Владелец: {accc.fio}, счет: {accc.sum}");
                 accc.Notify -= DisplayMessage;   // Добавляем обработчик для события Notify
                new ToastContentBuilder()
                .AddText($"Владелец счета: {accc.fio}, счет: {accc.sum}")
                .Show();
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
                                             
            new ToastContentBuilder()
                .AddText($"Владелец: {accc.fio}, счет: {accc.sum}")
                .AddText($"К счету добавленно {}")
                .Show();

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
