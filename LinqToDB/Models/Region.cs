using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LinqToDB.Mapping;

namespace LinqToDB.Models
{
    [Table("[dbo].[Region]")]
    public class Region
    {
        [Column("RegionID")]
        [Identity]
        [PrimaryKey]
        public int RegionId { get; set; }

        [Column("RegionDescription")]
        [NotNull]
        public string RegionDescription { get; set; }

        [Association(ThisKey = nameof(RegionId), OtherKey = nameof(Models.Territory.RegionId), CanBeNull = true)]
        public IEnumerable<Territory> Territories { get; set; }
    }
}
