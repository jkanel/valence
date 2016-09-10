using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Valence.Entities
{
    [Table("Address", Schema = "dbo")]
    public class Address: EntityBase
    {
        [Key]
        public int AddressId { get; set; }

        public string AddressName { get; set; }
        public string StreetAddress1 { get; set; }
        public string StreetAddress2 { get; set; }
        public string City { get; set; }
        public string StateProvinceCode { get; set; }
        public string CountryCode { get; set; }
        public string PostalCode { get; set; }
        public double? Lattitude { get; set; }
        public double? Longitude { get; set; }

        public static double Distance(double BeginLattitude, double BeginLongitude, double EndLattitude, double EndLongitude)
        {
            throw new NotImplementedException();
            //return 0.00;
        }

    }
}
