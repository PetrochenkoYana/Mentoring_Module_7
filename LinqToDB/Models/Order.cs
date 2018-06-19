using System;
using LinqToDB.Mapping;

namespace LinqToDB.Models
{
    [Table("Orders")]
    public class Order
    {
        [Column("OrderID")]
        [Identity]
        [PrimaryKey]
        public int OrderId { get; set; }

        [Column("ShipVia")]
        public int? ShipperId { get; set; }

        [Column("EmployeeID")]
        public int? EmployeeId { get; set; }

        [Association(ThisKey = nameof(EmployeeId), OtherKey = nameof(Models.Employee.EmployeeId), CanBeNull = true)]
        public Employee Employee { get; set; }

        [Association(ThisKey = nameof(ShipperId), OtherKey = nameof(Models.Shipper.ShipperId), CanBeNull = true)]
        public Shipper Shipper { get; set; }

    }
}
