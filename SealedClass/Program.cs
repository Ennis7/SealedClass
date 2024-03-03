using System.Drawing;
using System.Xml.Linq;

namespace SealedClass;
interface IEmployee
{
    //Properties
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }

    //Methods
    public string Fullname();
    public double Pay();
}
class Program
{
    class Employee : IEmployee
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public Employee()
        {
            Id = 0;
            FirstName = string.Empty;
            LastName = string.Empty;
        }
        public Employee(int id, string firstName, string lastName)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
        }
        public string Fullname()
        {
            return FirstName + " " + LastName;
        }
        public virtual double Pay()
        {
            double salary;
            Console.WriteLine($"What is {this.Fullname()}'s weekly salary?");
            salary = double.Parse(Console.ReadLine());
            return salary;
        }

    }

    //Sealed Class
    sealed class Executive : Employee
    {
        public string Title { get; set; }
        public double Salary { get; set; }

        //default parameterized constructor
        public Executive(int id, string firstName, string lastName, string title, double salary)
            :base(id, firstName, lastName)
        {
            Title = title;
            Salary = salary;
            //FirstName = firstName;
            //LastName = lastName;
            //Id = id;
        }

        public override string ToString()
        {
            return "\nName: " + Fullname() + "\nTitle: " + Title + "\nSalary: " + Salary;
        }

        //Override the Pay() method and create one for Executive
        public override double Pay()
        {
            return Salary;
        }

    }
    static void Main(string[] args)

    {
        //employee object w/ console.WriteLine
        Employee lilith = new Employee(6, "Lilith", "Fire");

        Console.WriteLine($"Employee Information: \nNamw: {lilith.Fullname()} \nSalary: {lilith.Pay()}");
        Console.ReadLine();

        //executive object w/ console.WriteLine
        Executive blair = new Executive(7, "Blair", "Witch", "Executive", 1000);

        Console.WriteLine($"Employee Information: {blair.ToString()}");
        Console.ReadLine();
    }
}

