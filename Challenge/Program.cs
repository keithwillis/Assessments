using System;
using System.Collections.Generic;
using System.Linq;

namespace Challenge
{

    public class Challenge
    {
        static void Main(string[] args)
        {
            //initialize objects (users and subscriptions)

            //This was done via tests in the assessment
            Console.WriteLine(BillFor(null, null, null));
        }


        public static Decimal BillFor(string month, Subscription activeSubscription, User[] users)
        {
            decimal total = 0M;
            DateTime dt = DateFromMonthString(verifyMonthString(month));
            DateTime LastDay = LastDayOfMonth(dt);
            decimal dailyRate = 0;

            if (activeSubscription is null || users == null)
                return 0M;

            dailyRate = activeSubscription.MonthlyPriceInDollars / LastDay.Day;


            while (dt <= LastDayOfMonth(dt))
            {
                var userCount = users.Where(u => u.ActivatedOn <= dt && u.DeactivatedOn >= dt).Count();
                total += (decimal)userCount * dailyRate;
                dt = NextDay(dt);
            }

            return decimal.Round(total, 2);
        }

        /*******************
        * Helper functions *
        *******************/

        private static DateTime DateFromMonthString(string month)
        {

            var dateparts = month.Split('-');

            return new DateTime(int.Parse(dateparts[0]), int.Parse(dateparts[1]), 1);

        }

        private static string verifyMonthString(string month)
        {
            if (month == null || !month.Contains('-'))
                return string.Format("{0}-{1}", DateTime.Now.Year, DateTime.Now.Month.ToString().PadLeft(2, '0'));
            else
                return month;

        }

        /**
        Takes a DateTime object and returns a DateTime which is the first day
        of that month. For example:

        FirstDayOfMonth(new DateTime(2019, 2, 7)) // => new DateTime(2019, 2, 1)
        **/
        private static DateTime FirstDayOfMonth(DateTime date)
        {
            return new DateTime(date.Year, date.Month, 1);
        }

        /**
        Takes a DateTime object and returns a DateTime which is the last day
        of that month. For example:

        LastDayOfMonth(new DateTime(2019, 2, 7)) // => new DateTime(2019, 2, 28)
        **/
        private static DateTime LastDayOfMonth(DateTime date)
        {
            return new DateTime(date.Year, date.Month, DateTime.DaysInMonth(date.Year, date.Month));
        }

        /**
        Takes a DateTime object and returns a DateTime which is the next day.
        For example:

        NextDay(new DateTime(2019, 2, 7))  // => new DateTime(2019, 2, 8)
        NextDay(new DateTime(2019, 2, 28)) // => new DateTime(2019, 3, 1)
        **/
        private static DateTime NextDay(DateTime date)
        {
            return date.AddDays(1);
        }
    }
}