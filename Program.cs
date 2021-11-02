using System;
using System.Collections.Generic;

namespace Payroll
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Employee> Staff = new List<Employee>();

            Staff.Add(new Employee { ID = 10001, Name = "Kwame Atta 01", Rank = "R1" });
            Staff.Add(new Employee { ID = 10002, Name = "Kwame Atta 02", Rank = "R1" });
            Staff.Add(new Employee { ID = 10003, Name = "Kwame Atta 03", Rank = "R1" });
            Staff.Add(new Employee { ID = 10004, Name = "Kwame Atta 04", Rank = "R1" });
            Staff.Add(new Employee { ID = 10005, Name = "Kwame Atta 05", Rank = "R1" });
            Staff.Add(new Employee { ID = 10006, Name = "Kwame Atta 06", Rank = "R2" });
            Staff.Add(new Employee { ID = 10007, Name = "Kwame Atta 07", Rank = "R3" });
            Staff.Add(new Employee { ID = 10008, Name = "Kwame Atta 08", Rank = "R4" });
            Staff.Add(new Employee { ID = 10009, Name = "Kwame Atta 09", Rank = "R1" });
            Staff.Add(new Employee { ID = 10010, Name = "Kwame Atta 10", Rank = "R1" });
            Staff.Add(new Employee { ID = 10011, Name = "Kwame Atta 11", Rank = "R1" });
            Staff.Add(new Employee { ID = 10012, Name = "Kwame Atta 12", Rank = "R2" });

            List<Rank> rank = new List<Rank>();

            rank.Add(new Rank { Rk = 1, Basic = 2100 });
            rank.Add(new Rank { Rk = 2, Basic = 790 });
            rank.Add(new Rank { Rk = 3, Basic = 1680 });
            rank.Add(new Rank { Rk = 4, Basic = 810 });

            Employee[] emp = new Employee[Staff.Count];
            Salary sal = new Salary();

            Console.WriteLine("ID\tName\t\tRank\tBasic Salary\tNet Salary");
            Console.WriteLine("................................................................");

            foreach (Employee staff in Staff)
            {
                staff.Basic = rank.Find(x => x.Rk.Equals(int.Parse(staff.Rank.Substring(1)))).Basic;
                staff.Net = sal.Net(staff.Basic);
                Console.WriteLine("{0}\t{1}\t{2}\t{3}\t\t{4}", staff.ID, staff.Name, staff.Rank, staff.Basic, staff.Net);
            }
        }

    }

    public class Employee
    {
        public int ID { get; set; }
        public String Name { get; set; }
        public String Rank { get; set; }
        public double Basic { get; set; }
        public double Net { get; set; }
    }

    public class Rank
    {
        public int Rk { get; set; }
        public int Basic { get; set; }
    }

    public class Salary
    {
        public double Deduction(double Basic)
        {
            double SSNIT = Basic * 0.03;
            double NHIS = Basic * 0.043;
            double VAT;
            if (Basic > 100 && Basic < 300)
            {
                VAT = Basic * 0.075;
            }
            else
            {
                VAT = Basic * 0.03;
            }
            return SSNIT + NHIS + VAT;
        }

        public double Net(double Basic)
        {
            double deduction = Deduction(Basic);

            double Allowance = 120 + 112 + 800;

            return Basic + Allowance - deduction; ;
        }
    }
}
