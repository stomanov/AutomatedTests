using AutoFixture;
using SeleniumTasks.Models.AutomationPractice;
using System;

namespace SeleniumTasks.Factories.AutomationPractice
{
    public static class UserFactory
    {
        public static UserModel CreateValidUser()
        {
            var fixture = new Fixture();
            var dateTime = fixture.Create<DateTime>();

            return new UserModel
            {
                FirstName = "Ivan",
                LastName = "Karenin",
                Year = "1970",
                Month = dateTime.Month.ToString(),
                Day = dateTime.Day.ToString(),
                Password = "AzSymProstKasket",
                Gender = "Female",
                PostCode = "75000",
                Address = "ul.Pere Toshev 14, 1945, ACME Innovations Inc.",
                City = "Prilep",
                Phone = "+359 89 9222222",
                State = "Arizona",
            };
        }
    }
}