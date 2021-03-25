using ContactInformationCore.Model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactInformationCore
{
    public class ContactInfoDbContext: DbContext
    {
        public ContactInfoDbContext(string connectionString) : base(connectionString)
        {
                  
        }
        public DbSet<ContactInfo> ContactInfo { get; set; }
    }
}
