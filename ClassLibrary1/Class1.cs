using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    public class Class1
    {
        public delegate void AccountHandler(Account sender, AccountEventArgs e);

        public class Account
        {
            public event AccountHandler Notify;
            public int sum { get; private set; }
            public string fio;
            // Создаем переменную делегата
            AccountHandler taken;
            public Account(int sum, string fio)
            {
                this.sum = sum;
                this.fio = fio;
            }


            public void RegisterHandler(AccountHandler del)
            {
                taken += del;
            }



            public void Add(int sum)
            {
                this.sum += sum;
                Notify?.Invoke(this, new AccountEventArgs($"На счет поступило: {sum} руб.", sum));
            }

            public void Take(int sum)
            {
                if (this.sum >= sum)
                {
                    this.sum -= sum;
                    // вызываем делегат, передавая ему сообщение
                    Notify?.Invoke(this, new AccountEventArgs($"Сумма {sum} снята со счета", sum));
                }
                else
                {
                    Notify?.Invoke(this, new AccountEventArgs("Недостаточно денег на счете", sum));
                }
            }
        }
        public class AccountEventArgs
        {
            // Сообщение
            public string Message { get; }
            // Сумма, на которую изменился счет
            public int Sum { get; }
            public AccountEventArgs(string message, int sum)
            {
                Message = message;
                Sum = sum;
            }
        }
    }
}
