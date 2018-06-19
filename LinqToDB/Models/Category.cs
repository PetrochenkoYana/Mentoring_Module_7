using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LinqToDB.Mapping;

namespace LinqToDB.Models
{
    [Table("Categories")]
    public class Category
    {
        [Column("CategoryID")]
        [PrimaryKey]
        [Identity]
        public int Id { get; set; }

        [Column("CategoryName")]
        public string Name { get; set; }

        [Column]
        public string Description { get; set; }
    }
}
