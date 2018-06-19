using System.Collections.Generic;
using LinqToDB.Mapping;

namespace LinqToDB.Models
{
    [Table("Suppliers")]
    public class Supplier
    {
        [Column("SupplierID")]
        [PrimaryKey]
        [Identity]
        public int Id { get; set; }

        [Column("CompanyName")]
        [NotNull]
        public string CompanyName { get; set; }

        [Column("ContactName")]
        public string ContactName { get; set; }

        [Association(ThisKey = nameof(Id), OtherKey = nameof(Models.Product.SupplierId), CanBeNull = true)]
        public IEnumerable<Product> Products { get; set; }
    }
}