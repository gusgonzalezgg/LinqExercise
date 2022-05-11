using System;
using System.Collections.Generic;
using System.Linq;

namespace LinqExercise
{
    class Program
    {
        //Static array of integers
        private static int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 0 };

        static void Main(string[] args)
        {

            /*
             * Complete every task using Method OR Query syntax.
             *
             * HINT: Use the List of Methods defined in the Lecture Material Google Doc ***********
             *
             * You may find that Method syntax is easier to use since it is most like C#
             * Every one of these can be completed using Linq and then printing with a foreach loop.
             * Push to your github when completed!
             */

            //Print the Sum and Average of numbers

            int Sum = numbers.Sum(x => x);

            Console.WriteLine("The sum of all the numbers in the array 'numbers' is " + Sum);
            Console.WriteLine();
            double average = numbers.Average(x => x);

            Console.WriteLine("Whereas average of all the numbers in the array 'numbers' is " + average);
            Console.WriteLine();

            ////Order numbers in ascending order and decsending order. Print each to console.

            //Console.WriteLine("This list, rearranged in ascending order");
            IEnumerable<int> orderByAscending = numbers.OrderBy(x => x).ToList();
            foreach (int x in orderByAscending)
            {
                Console.WriteLine(x);
            }
            Console.ReadLine();

            Console.WriteLine("Now rearranged in descending order");
            IEnumerable<int> orderByDescending = numbers.OrderByDescending(x => x).ToList();
            foreach (int x in orderByDescending)
            {
                Console.WriteLine(x);
            }
            Console.ReadLine();

            //Print to the console only the numbers greater than 6

            Console.WriteLine("Now, we're only printing out numbers in the array larger than 6");
            IEnumerable<int> greaterThanSix = numbers.Where(digit => digit > 6).ToList();

            foreach (var digit in greaterThanSix)
            {
                Console.WriteLine(digit);
            }
            Console.ReadLine();


            //Order numbers in any order (acsending or desc) but only print 4 of them **foreach loop only!**
            Console.WriteLine("Now I've put them in ascending order, and added a foreach loop to filter out odds and the 0");
            IEnumerable<int> onlyFour = numbers.OrderBy(digit => digit);
            foreach (var digit in onlyFour)
            {
                if (digit > 0 && digit % 2 == 0) 
                Console.WriteLine(digit);
            }
            //Change the value at index 4 to your age, then print the numbers in decsending order

            numbers[4] = 29;

            IEnumerable<int> addedMyAge = numbers.OrderByDescending(num => num);
            foreach (var thing in addedMyAge)
            {
                Console.WriteLine(thing);
            }

            // List of employees ***Do not remove this***
            var employees = CreateEmployees();

            //Print all the employees' FullName properties to the console only if their FirstName starts with a C OR an S.
            //Order this in acesnding order by FirstName.

            IEnumerable<Employee> cOrS = employees.Where(fs => fs.FirstName.Contains('C') || fs.FirstName.Contains('S'))
                                                  .OrderBy(fs => fs.FirstName).ToList();
                                                  
            foreach (Employee e in cOrS)
            {
               Console.WriteLine(e.FullName);
            }


            //Print all the employees' FullName and Age who are over the age 26 to the console.

            
            //Order this by Age first and then by FirstName in the same result.

            employees.Where(emp => emp.Age > 26)
                     .OrderBy(emp => emp.Age)
                     .ThenBy(emp => emp.FullName)
                     .ToList().ForEach(emp => Console.WriteLine(($"Name: " + emp.FullName + " Age: " + emp.Age)));

            //Print the Sum and then the Average of the employees' YearsOfExperience

            int expSum = employees.Sum(sum => sum.YearsOfExperience);
            Console.WriteLine(expSum);

            double expAvg = employees.Average(avg => avg.YearsOfExperience);
            Console.WriteLine(expAvg);

            //if their YOE is less than or equal to 10 AND Age is greater than 35

            IEnumerable<Employee> newOne = employees.Where(emp => emp.YearsOfExperience <= 10 && emp.Age > 35).ToList();
            foreach (var person in newOne)
            {    
                Console.WriteLine($"{person.FirstName} {person.LastName} is over 35 with 10 or less years of experience");
            
            }
            //Add an employee to the end of the list without using employees.Add()


            employees.Append(new Employee("Gus", "Gonzalez", 29, 10)).ToList()
                     .ForEach(person => Console.WriteLine($"Name: " + person.FullName + " Age: " + person.Age));

            
            
        }

        #region CreateEmployeesMethod
        private static List<Employee> CreateEmployees()
        {
            List<Employee> employees = new List<Employee>();
            employees.Add(new Employee("Cruz", "Sanchez", 25, 10));
            employees.Add(new Employee("Steven", "Bustamento", 56, 5));
            employees.Add(new Employee("Micheal", "Doyle", 36, 8));
            employees.Add(new Employee("Daniel", "Walsh", 72, 22));
            employees.Add(new Employee("Jill", "Valentine", 32, 43));
            employees.Add(new Employee("Yusuke", "Urameshi", 14, 1));
            employees.Add(new Employee("Big", "Boss", 23, 14));
            employees.Add(new Employee("Solid", "Snake", 18, 3));
            employees.Add(new Employee("Chris", "Redfield", 44, 7));
            employees.Add(new Employee("Faye", "Valentine", 32, 10));

            return employees;
        }
        #endregion
    }
}
