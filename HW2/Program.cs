
using System;

internal class Person
{
    private string name;
    private string address;
    private double salary;

    public Person(string name, string address, double salary)
    {
        this.name = name;
        this.address = address;
        this.salary = salary;
    }

    public string Name
    {
        get { return name; }
        set { name = value; }
    }

    public string Address
    {
        get { return address; }
        set { address = value; }
    }

    public double Salary
    {
        get { return salary; }
        set { salary = value; }
    }
}

internal class Program
{
    static Person InputPersonInfo(string name, string address, string sSalary)
    {
        if (string.IsNullOrWhiteSpace(sSalary))
        {
            throw new Exception("Ban phai nhap luong!");
        }

        if (!double.TryParse(sSalary, out double salary))
        {
            throw new Exception("Luong phai la mot so!");
        }

        if (salary <= 0)
        {
            throw new Exception("Luong phai lon hon 0!");
        }

        return new Person(name, address, salary);
    }

    static void DisplayPersonInfo(Person person)
    {
        Console.WriteLine("Ho ten: " + person.Name);
        Console.WriteLine("Dia chi: " + person.Address);
        Console.WriteLine("Luong: " + person.Salary);
        Console.WriteLine("-----------------------------");
    }

    static Person[] SortBySalary(Person[] persons)
    {
        int n = persons.Length;

        for (int i = 0; i < n - 1; i++)
        {
            for (int j = 0; j < n - i - 1; j++)
            {
                if (persons[j].Salary > persons[j + 1].Salary)
                {
                    Person temp = persons[j];
                    persons[j] = persons[j + 1];
                    persons[j + 1] = temp;
                }
            }
        }

        return persons;
    }

    static void Main(string[] args)
    {
        Person[] persons = new Person[3];

        Console.WriteLine("===== QUAN LY NHAN VIEN =====");

        for (int i = 0; i < persons.Length; i++)
        {
            Console.WriteLine("\nNhap thong tin nguoi thu " + (i + 1));

            Console.Write("Nhap ho ten: ");
            string name = Console.ReadLine();

            Console.Write("Nhap dia chi: ");
            string address = Console.ReadLine();

            bool validSalary = false;

            while (!validSalary)
            {
                Console.Write("Nhap luong: ");
                string sSalary = Console.ReadLine();

                try
                {
                    persons[i] = InputPersonInfo(name, address, sSalary);
                    validSalary = true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        Console.WriteLine("\n===== DANH SACH DA NHAP =====");

        for (int i = 0; i < persons.Length; i++)
        {
            DisplayPersonInfo(persons[i]);
        }

        SortBySalary(persons);

        Console.WriteLine("\n===== DANH SACH SAU KHI SAP XEP LUONG TANG DAN =====");

        for (int i = 0; i < persons.Length; i++)
        {
            DisplayPersonInfo(persons[i]);
        }

        Console.WriteLine("Nhan phim bat ky de ket thuc...");
        Console.ReadKey();
    }
}
