using CustomerManagement.BusinessEntities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerManagement.EFRepositories
{
    public class GeoDBContext : DbContext
    {
        public IDbSet<Customer> Customers { get; set; }
        public IDbSet<Address> Addresses { get; set; }

    }
}
