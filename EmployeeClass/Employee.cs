using System;
using System.Linq;
using System.Net.Mail;
using System.Text.RegularExpressions;
using Xamarin.Essentials;

namespace EmployeeClass
{
    public class Employee
    {
        public string specialChar = @"\|!#$%&/()=?»«@£§€{}.;'<>_,";

        private string firstName;
        public string FirstName
        {
            get { return firstName; }
            set 
            {
                foreach (var item in specialChar)
                {
                    if (value.Contains(item)) throw new FormatException("Name cannot contain special characters");
                }
                if (value == null) throw new ArgumentNullException("Name cannot be null");

                if (value.Length > 16 || value.Length < 1) throw new ArgumentOutOfRangeException("Name must be between 1-15 letters");

                if (value.Any(char.IsDigit)) throw new FormatException("Name cannot contain digits");

                firstName = value;

            }
        }

        private string lastName;

        public string LastName
        {
            get { return lastName; }
            set
            {
                foreach (var item in specialChar) if (value.Contains(item)) throw new FormatException("Name cannot contain special characters");

                if (value == null) throw new ArgumentNullException("Name cannot be null");

                if (value.Length > 20 || value.Length < 1) throw new ArgumentOutOfRangeException("Name must be between 1-15 letters");

                if (value.Any(char.IsDigit)) throw new FormatException("Name cannot contain digits");
 
                lastName = value;

            }
        }

        private DateTime employeeDate;      

        public DateTime EmployeeDate
        {
            get { return employeeDate; }
            set 
            {
                if (value > DateTime.Now) throw new ArgumentOutOfRangeException("Date of employment cannot be in the future");
                if (value < DateTime.Now.AddYears(-70)) throw new ArgumentOutOfRangeException("Date of employment cannot be more than 70 years ago");
                employeeDate = value;
            }   
        }

        private DateTime dateOfBirth;

        public DateTime DateOfBirth
        {
            get { return dateOfBirth; }
            set
            {
                if (value > DateTime.Now) throw new ArgumentOutOfRangeException("Date of Birth cannot be in the future");
                if (value > DateTime.Now.AddYears(-16)) throw new ArgumentOutOfRangeException("Employee cannot be younger than 16");
                dateOfBirth = value; 
            }
        }

        private double salary;

        public double Salary
        {
            get { return salary; }
            set
            {
                if (value <= 0) throw new ArgumentOutOfRangeException("Salary cannot be less than zero");
                
                salary = value; 
            }
        }

        private int bonus;

        public int BonusPercentage
        {
            get { return bonus; }
            set 
            {
                if (value <= 0) throw new ArgumentOutOfRangeException("Bonus cannot be zero or less than zero");
                if (value > 100) throw new ArgumentOutOfRangeException("Bonus percentage cannot be over 100%");
      
                bonus = value; 
            
            }
        }
       
        private string phoneNumber;
        public string PhoneNumber
        {
            get { return phoneNumber; }
            set 
            {
                Regex regex = new Regex(@"^[0-9\s-]*$");
                if (!regex.IsMatch(value)) throw new FormatException("Phonenumber can only conatin numbers, whitespace and -");
                phoneNumber = value; 
            }
        }

        private string email;

        public string Email
        {
            get { return email; }
            set 
            {
                Regex regex = new Regex(@"^[\w!#$%&'*+\-/=?\^_`{|}~]+(\.[\w!#$%&'*+\-/=?\^_`{|}~]+)*@((([\-\w]+\.)+[a-zA-Z]{2,4})|(([0-9]{1,3}\.){3}[0-9]{1,3}))\z");
                if(!regex.IsMatch(value)) throw new FormatException("Email in incorrect format");

                email = value; 
            }
        }

         public Employee(string firstName, string lastName, DateTime employeeDate, DateTime dateOfBirth, double salary,
            int bonus, string phoneNumber, string mail)
        {
           FirstName = firstName;
           LastName = lastName;
           EmployeeDate = employeeDate;
            DateOfBirth = dateOfBirth;
           Salary = salary;
           BonusPercentage = bonus;
           PhoneNumber = phoneNumber;
            Email = mail;
        }

        public int RaiseSalaryWithBonus(int bonus, double salary)
        {
            float bonusdecimal = ((bonus / 100F) * (float)salary) + (float)salary;
            int raisedSalary = (int)bonusdecimal;

            return raisedSalary;
        }

        public override string ToString()
        {

            return $"{FirstName} {LastName} Email: {Email}";
        }

    }
}
