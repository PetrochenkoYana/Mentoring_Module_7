using LinqToDB.Mapping;

namespace LinqToDB.Models
{
    [Table("Products")]
    public class Product
    {
        [Column("ProductId")]
        [PrimaryKey]
        [Identity]
        public int Id { get; set; }

        [Column("ProductName")]
        public string Name { get; set; }

        [Column("CategoryID")]
        public int CategoryId { get; set; }

        [Association(ThisKey = "CategoryId", OtherKey = nameof(Models.Category.Id), CanBeNull = true)]
        public Category Category { get; set; }

        [Association(ThisKey = nameof(SupplierId), OtherKey = nameof(Models.Supplier.Id), CanBeNull = true)]
        public Supplier Supplier { get; set; }

        [Column("SupplierID")]
        public int SupplierId { get; set; }

        [Column("QuantityPerUnit")]
        public string QuantityPerUnit { get; set; }

        [Column("UnitPrice")]
        public decimal? UnitPrice { get; set; }
    }
}
