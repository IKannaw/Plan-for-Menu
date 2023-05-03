using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plan_for_Menu
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] curries = { "Chicken", "Beef", "Chicken Egg", " Duck Egg Chat", "Chicken's heart and lung fired ", "nga(fish) phal kyaw", "Fired fish", "Pork fired", "Chicken Gwe toat Kyaw" };

            //string[] soups = { "Son tan Hin yae", "Chin yae","buu thee tha pyawann","Vegetabel Hin yae","Chin sat Hin yae"};
            //string[] sides = { "Nga Pi Kyaw", "Mushroom Kyaw","Nga Yout Thi Htoun", "ngan pyar yae phyaw", "Pone yai gyi thout", "Kha son yat kyaw", "Pae Thi Kyaw", "Pane mone lar kyaw","latt phat thoat","Chin Paung Rwat Kyaw","A Sane Kyaw","Pae Pin Pout Kyaw","Arr Luu Thi Chat","Tha Yat Chin Thoat","Pan Htwa HPyaw",};

            string[] sweetSoup = { "buu thee tha pyawann", "Vegetabel Hin yae", "Pae Hin" };
            string[] spicySoup = { "Son tan Hin yae", "Chin sat Hin yae" };
            string[] sourSoup = { "Chin yae" };

            string[] sweetSide = { "Mushroom Kyaw", "Pone yai gyi thout", "Kha son yat kyaw", "Pae Thi Kyaw", "Pane mone lar kyaw", "A Sane Kyaw", "Pae Pin Pout Kyaw", "Arr Luu Thi Chat" };
            string[] spicySide = { "Nga Pi Kyaw", "Nga Yout Thi Htoun", "ngan pyar yae phyaw", "latt phat thoat", "Pan Htwa HPyaw" };
            string[] sourSide = { "Chin Paung Rwat Kyaw", "Tha Yat Chin Thoat" };

            string[] teams = { "TeamA - ( Wai Yan Myoe and Thein Thein Soe )", " TeamB - ( Htet Myat and Nyi Lin Htet )", "TeamC - ( ma need and Ko Toe Tat )" };


            var soup = new Dictionary<string, string[]>()
            {
                {"sweet", sweetSoup},
                {"spicy",spicySoup },
                {"sour",sourSoup }
            };

            var sideDish = new Dictionary<string, string[]>()
            {
               {"sweet", sweetSide},
               {"spicy",spicySide },
               {"sour",sourSide }
            };

            // get user input for the month and year
            Console.Write("Enter the month (1-12): ");
            int month = int.Parse(Console.ReadLine());

            Console.Write("Enter the year: ");
            int year = int.Parse(Console.ReadLine());

            Console.Write("Enter the dat: ");
            int startingDay = int.Parse(Console.ReadLine());

            // get the number of days in the specified month
            int daysInMonth = DateTime.DaysInMonth(year, month);

            // create an empty array to store the menu for the month
            string[,] menu = new string[daysInMonth, 3];

            // loop through each day in the month and select a random option for each category
            Random rnd = new Random();
            for (int i = 0; i < daysInMonth; i++)
            {
                int curryIndex = rnd.Next(curries.Length);
                string soupType = soup.Keys.ElementAt(rnd.Next(soup.Count));
                string sideType = sideDish.Keys.Where(key => key != soupType).ElementAt(rnd.Next(sideDish.Count - 1));
                string soupName = soup[soupType][rnd.Next(soup[soupType].Length)];
                string sideName = sideDish[sideType][rnd.Next(sideDish[sideType].Length)];

                menu[i, 0] = curries[curryIndex];
                menu[i, 1] = soupName;
                menu[i, 2] = sideName;
            }
            // print the menu for the month
            Console.WriteLine(" ");
            Console.WriteLine("Menu for {0}/{1}:", month, year);
            Console.WriteLine(" ");

            int currentTeamIndex = 0;
            int curryDaysCount = 0;
            int j = 0;
            string curry = "";
            for (int day = startingDay; day <= daysInMonth; day++)
            {
                Console.WriteLine($"{teams[currentTeamIndex]} is on duty");
                currentTeamIndex++;
                if (currentTeamIndex >= teams.Length)
                {
                    currentTeamIndex = 0;
                }
                if (curryDaysCount == 0)
                {
                    curry = menu[j, 0];
                }
                else
                {
                    curry = "No";
                }
                curryDaysCount++;
                if (curryDaysCount > 1)
                {
                    curryDaysCount = 0;
                }
                Console.WriteLine("Day {0}: curry- ({1}) , soup- ({2}), side dish- ({3}) ", day, curry, menu[j, 1], menu[j, 2]);
                Console.WriteLine(" ");
                j++;
            }
            Console.ReadLine();
        }
    }
}
