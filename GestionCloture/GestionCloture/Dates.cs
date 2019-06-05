using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionCloture
{
    abstract class Dates
    {

        public static string getPreviousMonth()
        {
            DateTime DateToday = DateTime.Today;
            DateToday = DateToday.AddMonths(-1);
            string previousMonth = DateToday.ToString("MM");
            return previousMonth;
        }

        public static string getPreviousMonth(DateTime date)
        {
            date = date.AddMonths(-1);
            string previousMonth = date.ToString("MM");
            return previousMonth;
        }


        public static string getNextMonth()
        {
            DateTime DateToday = DateTime.Today;
            DateToday = DateToday.AddMonths(1);
            string nextMonth = DateToday.ToString("MM");
            return nextMonth;
        }

        public static string getNextMonth(DateTime date)
        {
            date = date.AddMonths(1);
            string nextMonth = date.ToString("MM");
            return nextMonth;
        }

        public static bool Between(int firstDay, int secondDay)
        {
            DateTime DateToday = DateTime.Today;
            string day = DateToday.ToString("dd");
            int thisDay = int.Parse(day);
            if (thisDay < secondDay && thisDay > firstDay)
            {
                return true;
            }
            else
            {
                return false;
            }

        }
        public static bool Between(int firstDay, int secondDay, DateTime date)
        {
            string day = date.ToString("dd");
            int thisDay = int.Parse(day);
            if (thisDay < secondDay && thisDay > firstDay)
            {
                return true;
            }
            else
            {
                return false;
            }

        }                    

        
    }
}
