using System;
using System.Collections.Generic;
using System.Linq;
using LinqToDB.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LinqToDB.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void ListOfProductssWIthCategoryAndSupplier()
        {
            using (var connection = new Northwind())
            {
                foreach (var prod in connection.Products.LoadWith(p => p.Category).LoadWith(p => p.Supplier))
                {
                    Console.WriteLine("{0} - {1} | {2}", prod.Name, prod.Category.Name, prod.Supplier.ContactName);
                }
            }
        }

        [TestMethod]
        public void EmployeesWithTheirRegions()
        {
            using (var connection = new Northwind())
            {
                foreach (var employeeRegion in
                    (from e in connection.Employees
                     join et in connection.EmployeeTerritories on e.EmployeeId equals et.EmployeeId
                     select new { e.FirstName, et.Territory.Region.RegionDescription }).Distinct())
                {
                    Console.WriteLine("{0} - {1}", employeeRegion.FirstName, employeeRegion.RegionDescription);
                }
            }
        }

        [TestMethod]
        public void RegionsStatisticByEmployeeCount()
        {
            using (var connection = new Northwind())
            {
                var query =
                    from et in connection.EmployeeTerritories
                    join t in connection.Territories on et.TerritoryId equals t.TerritoryId
                    join r in connection.Regions on t.RegionId equals r.RegionId
                    select new { et.EmployeeId, r, r.RegionDescription };

                var query2 = from EmpReg in query
                             group EmpReg by EmpReg.r
                    into e
                             select new { EmployeeCOunt = e.Count(p => p.EmployeeId != 0), Region = e.Key.RegionDescription };

                foreach (var employeeRegion in query2)
                {
                    Console.WriteLine("{0} - {1}", employeeRegion.Region, employeeRegion.EmployeeCOunt);
                }
            }
        }

        [TestMethod]
        public void EmployeeWithHisShippers()
        {
            using (var connection = new Northwind())
            {
                LinqToDB.Common.Configuration.Linq.AllowMultipleQuery = true;
                List<object> employeeShipper = new List<object>();
                foreach (var employee in connection.Employees.LoadWith(e => e.Orders).ToList())
                {
                    foreach (var order in employee.Orders)
                    {
                        employeeShipper.Add((from s in connection.Shippers
                                             where s.ShipperId == order.ShipperId
                                             select new { employee.FirstName, s.CompanyName }).Distinct().FirstOrDefault());
                    }
                }
                foreach (var e in employeeShipper.Distinct())
                {
                    Console.WriteLine(e);
                }

            }
        }

        [TestMethod]
        public void AdditionOfNewEmployeeAssosiatedWithTerritoties()
        {
            using (var connection = new Northwind())
            {
                Employee newEmployee = new Employee { FirstName = "Yana", LastName = "Haiduk" };

                try
                {
                    connection.BeginTransaction();
                    newEmployee.EmployeeId = Convert.ToInt32(connection.InsertWithIdentity(newEmployee));

                    connection.Territories.Where(t => t.TerritoryDescription.Length <= 5)
                        .Insert(connection.EmployeeTerritories,
                            t =>
                                new EmployeeTerritory { EmployeeId = newEmployee.EmployeeId, TerritoryId = t.TerritoryId });
                    connection.CommitTransaction();
                }
                catch
                {
                    connection.RollbackTransaction();
                }
            }
        }

        [TestMethod]
        public void MoveProductsFromOneCategoryToAnother()
        {
            using (var connection = new Northwind())
            {
                int updatedCount = connection.Products
                    .Update(p => p.CategoryId == 1, pr => new Product
                    {
                        CategoryId = 2
                    });

                Console.WriteLine(updatedCount);
            }
        }
    }
}
