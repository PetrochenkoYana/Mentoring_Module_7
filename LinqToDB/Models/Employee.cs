using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LinqToDB.Mapping;

namespace LinqToDB.Models
{
    [Table("Employees")]
    public class Employee
    {
        [Column("EmployeeID")]
        [PrimaryKey]
        [Identity]
        public int EmployeeId { get; set; }

        [Column("LastName")]
        public string LastName { get; set; }

        [Column("FirstName")]
        public string FirstName { get; set; }

        [Association(ThisKey = nameof(EmployeeId), OtherKey = nameof(Models.Order.EmployeeId), CanBeNull = true)]
        public IEnumerable<Order> Orders { get; set; }
    }
}
