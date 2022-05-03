using System;
using System.Collections.Generic;
using System.IO;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Globalization;

namespace ConsoleApp3
{
    class Program
    {

            /* Създава се класа съдържащ свойствата съответни на информацията във файла */

            public class MovieStar
            {

                public string dateOfBirth { get; set; }

                public string Name { get; set; }

                public string Surname { get; set; }

                public string Sex { get; set; }

                public string Nationality { get; set; }

            }

            static void Main(string[] args)
            {
                /* Създава се променилава, чиято стойност е равна на съдържанието от файла, използва се функция за четене на файлове */

                string text = File.ReadAllText(@"c:\jsonFolder\input.txt");

                /* Създава се обект използван за преобразуване на информация от файла в обекти */

                MovieStar[] movieStar = JsonConvert.DeserializeObject<MovieStar[]>(text);

                /* Използва се цикъл за преминаване през всяко свойствие или инстанция на обекта, за да бъде изписано след това в конзолата пред потребителя */

                foreach (var item in movieStar)
                {

                    /* Създава се променлива съдържаща датата на раждане на всяка филмова звезда от файла*/

                    string dateInput = item.dateOfBirth;

                    /* Създава се DateTime клас променлива съдържаща датата на раждане, преобразувана от първоначалната й форма в по-лесно разбираема от компютъра такава*/

                    DateTime parsedDate = DateTime.Parse(dateInput);

                    /* В конзолата се изкарват всички инстанции или свойства на обектите с изключение на датата на раждане*/

                    Console.WriteLine("{0} {1}\n {2}\n {3}", item.Name, item.Surname, item.Sex, item.Nationality);

                    /* Създава се нова променлива съдържаща реалното време и дата*/

                    DateTime now = DateTime.Now;

                    /* Използва се TimeSpan форматът за низове, за да определи начина на форматиране на низа и неговото изписване пред потребителя. Променливата се използва за съдържане на получения резултат при изваждането на сегашната дата и време и датата на раждане на определената филмова звезда*/

                    TimeSpan timeSpan = now - parsedDate;

                    /* В конзолата се изкарват дните получени при изваждането и се делят на 365, за да се получат годините на филмовата звезда*/

                    Console.WriteLine(timeSpan.Days / 365 + " years old\n");

                }

                /* За да не се затвори конзолата веднага след изпълнение на програмата се изчаква натиск на бутон от потребителя*/

                Console.WriteLine("Press any key to exit.");

                System.Console.ReadKey();

            }
        }
    }