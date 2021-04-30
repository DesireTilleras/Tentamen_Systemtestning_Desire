using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EmployeeClass;


namespace EmployeeClassTest
{
    [TestClass]
    public class ConstructorTest
    {
        [TestMethod]
        [DataRow("Desire", "Tilleras", "2018-06-22", "1989-07-16", "29000", 15, "070123456", "desire.tilleras@mail.com")]
        public void TestCheckValidEmployee(string firstName, string lastName, string dateOfEmployement,
             string dateOfBirth, string salary, int bonus, string phoneNumber, string email)
        {
            var employee = new Employee(firstName, lastName, DateTime.Parse(dateOfEmployement),
            DateTime.Parse(dateOfBirth), double.Parse(salary), bonus, phoneNumber, email);

            Assert.IsNotNull(employee);
        }

        [TestMethod]
        [DataRow(null, "Tilleras", "2018-06-22", "1989-07-16", "29000", 15, "070123456", "desire.tilleras@mail.com")]
        [DataRow("Desire", null, "2018-06-22", "1989-07-16", "29000", 15, "070123456", "desire.tilleras@mail.com")]
        [DataRow("Desire", "Tillerås", null, "1989-07-16", "29000", 15, "070123456", "desire.tilleras@mail.com")]
        [DataRow("Desire", "Tilleras", "2018-06-22", null, "29000", 15, "070123456", "desire.tilleras@mail.com")]
        [DataRow("Desire", "Tilleras", "2018-06-22", "1989-07-16", null, 15, "070123456", "desire.tilleras@mail.com")]
        [DataRow("Desire", "Tilleras", "2018-06-22", "1989-07-16", "29000", 15, null, "desire.tilleras@mail.com")]
        [DataRow("Desire", "Tilleras", "2018-06-22", "1989-07-16", "29000", 15, "070123456", null)]
        public void TestCheckEveryPropertyIsNotNull(string firstName, string lastName, string dateOfEmployement,
        string dateOfBirth, string salary, int bonus, string phoneNumber, string email)
        {
            Exception exception = null;
            try
            {
                var employee1 = new Employee(firstName, lastName, DateTime.Parse(dateOfEmployement),
                DateTime.Parse(dateOfBirth), double.Parse(salary), bonus, phoneNumber, email);
            }
            catch (Exception ex)
            {
                exception = ex;
            }

            Assert.IsNotNull(exception);
        }

    }
}
