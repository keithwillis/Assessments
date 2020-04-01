using System.Collections.Generic;
using NUnit.Framework;
using System;

namespace AssessmentTest
{
    [TestFixture]
    public class InvoiceTest
    {
        /* test fixtures */

        Subscription newPlan = new Subscription(1, 1, 4);

        User[] noUsers = new User[0];

        User[] constantUsers = {
      new User(1, "Employee #1", new DateTime(2018, 11, 4), DateTime.MaxValue, 1),
      new User(2, "Employee #2", new DateTime(2018, 12, 4), DateTime.MaxValue, 1)
  };

        User[] userSignedUp = {
      new User(1, "Employee #1", new DateTime(2018, 11, 4), DateTime.MaxValue, 1),
      new User(2, "Employee #2", new DateTime(2018, 12, 4), DateTime.MaxValue, 1),
      new User(3, "Employee #3", new DateTime(2019, 1, 10), DateTime.MaxValue, 1),
  };

        /* end test fixtures */

        [Test]
        public void WorksWhenTheMonthIsInvalid()
        {
            Assert.That(Challenge.BillFor("yyyy-mm", newPlan, noUsers), Is.EqualTo(0).Within(0.01));
        }

        [Test]
        public void WorksWhenActiveSubscriptionIsNull()
        {
            Assert.That(Challenge.BillFor("2019-01", null, noUsers), Is.EqualTo(0).Within(0.01));
        }


        [Test]
        public void WorksWhenTheCustomerHasNoActiveUsersDuringTheMonth()
        {
            Assert.That(Challenge.BillFor("2019-01", newPlan, noUsers), Is.EqualTo(0).Within(0.01));
        }

        [Test]
        public void WorksWhenEverythingStaysTheSameForAMonth()
        {
            Assert.That(Challenge.BillFor("2019-01", newPlan, constantUsers), Is.EqualTo(8).Within(0.01));
        }

        [Test]
        public void WorksWhenAUserIsActivatedDuringTheMonth()
        {
            Assert.That(Challenge.BillFor("2019-01", newPlan, userSignedUp), Is.EqualTo(10.84).Within(0.01));
        }
    }
}