using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Configuration;
using System.Collections.Specialized;
using System.IO;
using System.Net;

namespace ONELLECT_task
{
    class Program
    {
        class MassiveForTask
        {
            List<int> numbersList = new List<int> { };
            Random rnd = new Random();
            // MassiveCreate() Создают случайно генерируемый массив в от 20 до 100
            public void MassiveCreate()
            {
                int numbRnd = rnd.Next(20, 101);
                Console.WriteLine(numbRnd);
                for (int i = 0; i < numbRnd; i++)
                {
                    numbersList.Add(rnd.Next(-100, 101));
                }
                MassiveOrder();
            }
            // MassivePrint() Вывод массива на консоль
            public void MassivePrint()
            {
                int j = 1;
                foreach (int item in numbersList)
                {
                    Console.Write(item);
                    Console.Write(" ");
                    if (j % 10 == 0) { Console.WriteLine(); }
                    j++;
                }
            }
            // MassiveOrder() Сортирует массив случайным образом
            public void MassiveOrder()
            {
                int orderMod = rnd.Next(1, 3);
                switch (orderMod)
                {
                    case 1:
                        numbersList.Sort();
                        Console.WriteLine("Возрастание");
                        MassivePrint();
                        break;
                    case 2:
                        numbersList.Sort();
                        numbersList.Reverse();
                        Console.WriteLine("Убывание");
                        MassivePrint();
                        break;
                }
            }
            // MassivePost() Отправляет массив на сервер
            public void MassivePost()
            {
                //получеение URL из App.config
                string sAttr = ConfigurationManager.AppSettings.Get("URL1");
                string url = $"{sAttr}";
                using (var webClient = new WebClient())
                {
                    var pars = new NameValueCollection();
                    var body = new NameValueCollection();
                    string mass = "";
                    foreach (int t in numbersList)
                    {
                        mass += Convert.ToString(t) + " ";
                    }
                    var response = webClient.UploadString(url, Convert.ToString(mass));
                    Console.ReadKey();
                }
            }
        }
        static void Main(string[] args)
        {
            //создание экземпляра объекта
            MassiveForTask massive = new MassiveForTask();
            massive.MassiveCreate();
            massive.MassivePost();

        }
    }
}
