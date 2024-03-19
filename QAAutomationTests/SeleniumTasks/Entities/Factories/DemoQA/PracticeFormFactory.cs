using AutoFixture;
using System;

namespace SeleniumProject.Entities.DemoQA
{
    public static class PracticeFormFactory
    {
        public static PracticeFormModel CreateValidUser()
        {
            var fixture = new Fixture();
            var dateTime = fixture.Create<DateTime>();

            return new PracticeFormModel
            {
                FirstName = "Ivan",
                LastName = "Karenin",
                Email = "kasket_prost@mail.com",
                Gender = "Female",
                PhoneNumber = "0899222222",
                Day = dateTime.Day.ToString(),
                Month = dateTime.Month.ToString(),
                Year = "1970",
                Subjects = "Kaskets making",
                Hobby1 = "Sports",
                Hobby2 = "Music",
                Address = "ul. Sekvoja 55, 1616 Sofia, Bulgaria",
                State = "Uttar Pradesh",
                City = "Lucknow",
            };
        }
    }
}