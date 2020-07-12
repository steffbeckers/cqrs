using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CRM.API.Models;

namespace CRM.API.Data
{
    public class CRMContext : DbContext
    {
        public CRMContext (DbContextOptions<CRMContext> options) : base(options)
        {
        }

        public DbSet<Contact> Contact { get; set; }
    }
}
