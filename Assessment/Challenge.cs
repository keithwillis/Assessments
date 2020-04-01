using System;
using System.Collections.Generic;
using System.Linq;

public class Subscription
{
    public Subscription() { }
    public Subscription(int id, int customerId, int monthlyPriceInDollars)
    {
        this.Id = id;
        this.CustomerId = customerId;
        this.MonthlyPriceInDollars = monthlyPriceInDollars;
    }

    public int Id;
    public int CustomerId;
    public int MonthlyPriceInDollars;
}

public class User
{
    public User() { }
    public User(int id, string name, DateTime activatedOn, DateTime deactivatedOn, int customerId)
    {
        this.Id = id;
        this.Name = name;
        this.ActivatedOn = activatedOn;
        this.DeactivatedOn = deactivatedOn;
        this.CustomerId = customerId;
    }

    public int Id;
    public string Name;
    public DateTime ActivatedOn;
    public DateTime DeactivatedOn;
    public int CustomerId;
}

public class Challenge
{
    public static Decimal BillFor(string month, Subscription activeSubscription, User[] users)
    {
        decimal total = 0M;
        DateTime CurrentDay = DateTime.Now;
        try
        {
            CurrentDay = DateFromMonthString(month);
        }
        catch
        {
            return total;
        }
        
        DateTime LastDay = LastDayOfMonth(CurrentDay);

        if (activeSubscription == null)
            return 0M;

        decimal dailyRate = (decimal)activeSubscription.MonthlyPriceInDollars / (decimal)LastDay.Day;


        while (CurrentDay <= LastDay)
        {
            var userCount = users.Where(u => u.ActivatedOn <= CurrentDay && u.DeactivatedOn >= CurrentDay).Count();

            total += (decimal)userCount * dailyRate;

            CurrentDay = NextDay(CurrentDay);
        }

        return decimal.Round(total, 2);
    }

    /*******************
    * Helper functions *
    *******************/

    private static DateTime DateFromMonthString(string month)
    {
        var dateparts = month.Split('-');
        int dateYear, dateMonth;

        int.TryParse(dateparts[0], out dateYear);
        int.TryParse(dateparts[1], out dateMonth);

        return new DateTime(dateYear, dateMonth, 1);

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