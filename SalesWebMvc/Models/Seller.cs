using System;
using System.Collections.Generic;
using System.Linq;

namespace SalesWebMvc.Models
{
    public class Seller
    {
        public int ID { get; set; }
        public String Name { get; set; }
        public String Email { get; set; }
        public DateTime BirthDate { get; set; }
        public double Dalary { get; set; }
        public Department Department { get; set; }
        public int DepartmentId { get; set; }
        public ICollection<SalesRecord> Sales { get; set; } = new List<SalesRecord>();

        public Seller()
        {
        }

        public Seller(int iD, string name, string email, DateTime birthDate, double dalary, Department department)
        {
            ID = iD;
            Name = name;
            Email = email;
            BirthDate = birthDate;
            Dalary = dalary;
            Department = department;
        }

        public void AddSales(SalesRecord salerRecord)
        {
            Sales.Add(salerRecord);
        }
        public void RemoveSales(SalesRecord salerRecord)
        {
            Sales.Remove(salerRecord);
        }

        public double TotalSales(DateTime initial, DateTime final)
        {
            return Sales.Where(salerRecord => salerRecord.Date >= initial && salerRecord.Date <= final)
                .Sum(salerRecord => salerRecord.Amount);
        }
    }
}
