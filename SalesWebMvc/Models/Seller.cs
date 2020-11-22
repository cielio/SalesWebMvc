using System;
using System.Collections.Generic;
using System.Linq;

namespace SalesWebMvc.Models
{
    public class Seller
    {
        public int ID { get; set; }
        public String Name { get; set; }
        public DateTime BirthDate { get; set; }
        public double Dalary { get; set; }
        public Department Department { get; set; }
        public ICollection<SalerRecord> Sales { get; set; } = new List<SalerRecord>();

        public Seller()
        {
        }

        public Seller(int iD, string name, DateTime birthDate, double dalary, Department department)
        {
            ID = iD;
            Name = name;
            BirthDate = birthDate;
            Dalary = dalary;
            Department = department;
        }

        public void AddSales(SalerRecord salerRecord)
        {
            Sales.Add(salerRecord);
        }
        public void RemoveSales(SalerRecord salerRecord)
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
