using Microsoft.VisualStudio.TestTools.UnitTesting;
using EmployeeClass;
using System;


namespace EmployeeClassTest
{
    [TestClass]
    public class EmployeeTest
    {
       
        [TestMethod]
        [DataRow(2021, 04, 27)]
        [DataRow(2017, 05, 03)]
        [DataRow(1951, 12, 21)]
        public void TestCheckValidEmployeeDate(int year, int month, int day)
        {
            try
            {
                var employee = new Employee("Desire", "Tilleras", new DateTime(year, month, day),
                new DateTime(1989, 07, 16), 29000, 10, "070125355", "desire.tilleras@gmail.com");
                Assert.Fail();
            }
            catch (Exception Ex)
            {
                Assert.IsTrue(Ex is AssertFailedException);
            }
        }

        [TestMethod]
        [DataRow(2021, 09, 27, DisplayName = "In the future")]
        [DataRow(1951, 04, 03, DisplayName = "More than 70 years")]
        [DataRow(2030, 12, 21, DisplayName = "In the future")]
        public void TestCheckInvalidEmployeeDate(int year, int month, int day)
        {
           
            Exception exception = null;
            try
            {
                var employee = new Employee("Desire", "Tilleras", new DateTime(year, month, day),
                new DateTime(1989, 07, 16), 29000, 10, "070125355", "desire.tilleras@gmail.com");
            }
            catch (Exception Ex)
            {
                exception = Ex;
            }
             Assert.IsNotNull(exception);
        }

        [TestMethod]
        [DataRow("desire.tilleras@@gmail.com", DisplayName = "Wrong input, to many @")]
        [DataRow("desire tilleras@gmail.com", DisplayName = "Wrong input, contains whitespace")]
        [DataRow("desiretilleras@gmailcom", DisplayName = "Wrong input, no period")]

        public void TestCheckInvalidEmail(string input)
        {
            Exception exception = null;
            try
            {
                var employee = new Employee("Desire", "Tilleras", new DateTime(2018, 02, 21),
                new DateTime(1989, 07, 16), 29000, 10, "070125355", input);
            }
            catch (Exception Ex)
            {
                exception = Ex;
            }
            Assert.IsNotNull(exception);
        }
        [TestMethod]
        [DataRow("desire.tilleras@gmail.com")]
        [DataRow("emma.andersson@mail.com")]
        [DataRow("pontus-berntsson@hotmail.se")]

        public void TestCheckValidEmail(string input)
        {
            Exception exception = null;
            try
            {

                var employee = new Employee("Desire", "Tilleras", new DateTime(2018, 02, 21),
                new DateTime(1989, 07, 16), 29000, 10, "070125355", input);
            }
            catch (Exception Ex)
            {
                exception = Ex;
            }
            Assert.IsNull(exception);
        }
        [TestMethod]
        [DataRow(2022, 09, 27, DisplayName = "In the future")]
        [DataRow(2005, 12, 03, DisplayName = "Younger than 16")]
        [DataRow(2030, 12, 21, DisplayName = "In the future")]

        public void TestCheckInvalidBirthDate(int year, int month, int day)
        {
            Exception exception = null;
            try
            {
                var employee = new Employee("Desire", "Tilleras", new DateTime(2018, 02, 21),
                new DateTime(year, month, day), 29000, 10, "070125355", "desire.tilleras@gmail.com");
            }
            catch (Exception Ex)
            {
                exception = Ex;
            }
            Assert.IsNotNull(exception);
        }
        [TestMethod]
        [DataRow(1989, 09, 27)]
        [DataRow(1992, 12, 03)]
        [DataRow(2005, 04, 21)]

        public void TestCheckValidBirthDate(int year, int month, int day)
        {
            Exception exception = null;
            try
            {
                var employee = new Employee("Desire", "Tilleras", new DateTime(2018, 02, 21),
                new DateTime(year, month, day), 29000, 10, "070125355", "desire.tilleras@gmail.com");
            }
            catch (Exception Ex)
            {
                exception = Ex;
            }
            Assert.IsNull(exception);
        }
        [TestMethod]
        [DataRow("-1200", DisplayName = "Salary cannot be negative")]
        [DataRow("0", DisplayName = "Salary cannot be zero")]
        public void TestCheckInvalidSalary(string salary)
        {
            Exception exception = null;
            try
            {
                var employee = new Employee("Desire", "Tilleras", new DateTime(2018, 02, 21),
                new DateTime(1989, 07, 16), decimal.Parse(salary), 10, "070125355", "desire.tilleras@gmail.com");
            }
            catch (Exception Ex)
            {
                exception = Ex;
            }
            Assert.IsNotNull(exception);
        }
        [TestMethod]
        [DataRow("29000")]
        [DataRow("500000")]
        [DataRow("1")]
        public void TestCheckValidSalary(string salary)
        {
            Exception exception = null;
            try
            {
                var employee = new Employee("Desire", "Tilleras", new DateTime(2018, 02, 21),
                new DateTime(1989, 07, 16), decimal.Parse(salary), 10, "070125355", "desire.tilleras@gmail.com");
            }
            catch (Exception Ex)
            {
                exception = Ex;
            }
            Assert.IsNull(exception);
        }
        [TestMethod]
        [DataRow("070123456#")]
        [DataRow("070/1236548")]
        [DataRow("070*23665548")]
        public void TestCheckInvalidPhoneNumber(string phoneNumber)
        {
            Exception exception = null;
            try
            {
                var employee = new Employee("Desire", "Tilleras", new DateTime(2018, 02, 21),
                new DateTime(1989, 07, 16), 29000, 10, phoneNumber, "desire.tilleras@gmail.com");
            }
            catch (Exception Ex)
            {
                exception = Ex;
            }
            Assert.IsNotNull(exception);
        }
        [TestMethod]
        [DataRow("070123456")]
        [DataRow("070-123 65 48")]
        [DataRow("07023665548")]
        public void TestCheckValidPhoneNumber(string phoneNumber)
        {
            Exception exception = null;
            try
            {
                var employee = new Employee("Desire", "Tilleras", new DateTime(2018, 02, 21),
                new DateTime(1989, 07, 16), 29000, 10, phoneNumber, "desire.tilleras@gmail.com");
            }
            catch (Exception Ex)
            {
                exception = Ex;
            }
            Assert.IsNull(exception);
        }
        [TestMethod]
        [DataRow("#Desire", DisplayName = "No symbols allowed")]
        [DataRow("EmmaDesireTilleras", DisplayName = "Too many characters")]
        [DataRow("1Desire", DisplayName = "No numbers allowed")]
        [DataRow("", DisplayName = "Empty string is not allowed")]
        public void TestCheckInvalidFirstName(string firstName)
        {
            Exception exception = null;
            try
            {
                var employee = new Employee(firstName, "Tilleras", new DateTime(2018, 02, 21),
                new DateTime(1989, 07, 16), 29000, 10, "0701234567", "desire.tilleras@gmail.com");
            }
            catch (Exception Ex)
            {
                exception = Ex;
            }
            Assert.IsNotNull(exception);
        }
        [TestMethod]
        [DataRow("Desiré")]
        [DataRow("Anna-Greta")]
        [DataRow("D")]
        public void TestCheckValidFirstName(string firstName)
        {
            Exception exception = null;
            try
            {
                var employee = new Employee(firstName, "Tilleras", new DateTime(2018, 02, 21),
                new DateTime(1989, 07, 16), 29000, 10, "0701234567", "desire.tilleras@gmail.com");
            }
            catch (Exception Ex)
            {
                exception = Ex;
            }
            Assert.IsNull(exception);
        }
        [TestMethod]
        [DataRow("#Tillerås", DisplayName = "No symbols allowed")]
        [DataRow("TillerasTillerasagain", DisplayName = "Too many characters")]
        [DataRow("1Tilleras", DisplayName = "No numbers allowed")]
        [DataRow("", DisplayName = "Empty string is not allowed")]
        public void TestCheckInvalidLastName(string lastName)
        {
            Exception exception = null;
            try
            {
                var employee = new Employee("Desiré", lastName, new DateTime(2018, 02, 21),
                new DateTime(1989, 07, 16), 29000, 10, "0701234567", "desire.tilleras@gmail.com");
            }
            catch (Exception Ex)
            {
                exception = Ex;
            }
            Assert.IsNotNull(exception);
        }
        [TestMethod]
        [DataRow("Tillerås")]
        [DataRow("Alm-Tillerås")]
        [DataRow("T")]
        public void TestCheckValidLastName(string lastName)
        {
            Exception exception = null;
            try
            {
                var employee = new Employee("Desiré", lastName, new DateTime(2018, 02, 21),
                new DateTime(1989, 07, 16), 29000, 10, "0701234567", "desire.tilleras@gmail.com");
            }
            catch (Exception Ex)
            {
                exception = Ex;
            }
            Assert.IsNull(exception);
        }
        [TestMethod]
        [DataRow("29000", 10, 31900)]
        [DataRow("30000", 5, 31500)]
        [DataRow("60000", 25, 75000)]
        [DataRow("100000", 2, 102000)]
        public void TestRaisedSalary(string salary, int bonusPercentage, int expectedResult)
        {
            var employee = new Employee("Desiré", "Tillerås", new DateTime(2018, 02, 21),
            new DateTime(1989, 07, 16), decimal.Parse(salary), bonusPercentage, "0701234567", "desire.tilleras@gmail.com");

            int result = employee.RaiseSalaryWithBonus(employee.BonusPercentage, employee.Salary);

            Assert.AreEqual(result, expectedResult);
        }
        [TestMethod]
        [DataRow(-1, DisplayName = "Bonus cannot be below 1")]
        [DataRow(0, DisplayName = "Bonus cannot be 0")]
        [DataRow(101, DisplayName = "Bonus cannot be over 100")]
        public void TestCheckInvalidBonus(int bonus)
        {
            Exception exception = null;
            try
            {
                var employee = new Employee("Desiré", "Tillerås", new DateTime(2018, 02, 21),
                new DateTime(1989, 07, 16), 29000, bonus, "0701234567", "desire.tilleras@gmail.com");
            }
            catch (Exception Ex)
            {
                exception = Ex;
            }
            Assert.IsNotNull(exception);
        }

        [TestMethod]
        [DataRow("Desiré Tillerås Email: desire.tilleras@gmail.com")]
        public void TestCheckValidToString(string input)
        {
            //return $"{FirstName} {LastName} Email: {Email}";

            var employee = new Employee("Desiré", "Tillerås", new DateTime(2018, 02, 21),
           new DateTime(1989, 07, 16), 29000, 10, "0701234567", "desire.tilleras@gmail.com");

           string result = employee.ToString();

            Assert.AreEqual(result, input);
        }



    }
}
