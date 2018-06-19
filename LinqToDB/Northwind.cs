using LinqToDB.Data;
using LinqToDB.Models;

namespace LinqToDB
{
    public class Northwind : DataConnection
    {
        public Northwind() : base("Northwind") { }
        public ITable<Category> Categories => this.GetTable<Category>();
        public ITable<Product> Products => this.GetTable<Product>();
        public ITable<Supplier> Suppliers => this.GetTable<Supplier>();
        public ITable<Employee> Employees => this.GetTable<Employee>();
        public ITable<EmployeeTerritory> EmployeeTerritories => this.GetTable<EmployeeTerritory>();
        public ITable<Territory> Territories => this.GetTable<Territory>();
        public ITable<Region> Regions => this.GetTable<Region>();
        public ITable<Order> Orders => this.GetTable<Order>();
        public ITable<Shipper> Shippers => this.GetTable<Shipper>();
    }
}
