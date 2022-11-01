using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    public class Class1
    {
        // Объявляем делегат
        public delegate void AccountHandler(string message);
        public class Account
        {
            int sum;
            // Создаем переменную делегата
            AccountHandler taken;
            public Account(int sum)
            {
                this.sum = sum;
            }

            // Регистрируем делегат
            public void RegisterHandler(AccountHandler del)
            {
                taken = del;
            }
            public void Add(int sum)
            {
                this.sum += sum;
                taken?.Invoke($"К счету добалвено {sum} Баланс: {this.sum} у.е.");
            }


            public void Take(int sum)
            {
                if (this.sum >= sum)
                {
                    this.sum -= sum;
                    // вызываем делегат, передавая ему сообщение
                    taken?.Invoke($"Со счета списано {sum} у.е. Баланс: {this.sum}");
                }
                else
                {
                    taken?.Invoke($"Недостаточно средств. Баланс: {this.sum} у.е.");
                }
            }
        }
    }
}
