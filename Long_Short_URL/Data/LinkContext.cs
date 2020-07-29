using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Long_Short_URL.Models
{
    public class LinkContext : DbContext
    {
        // Доступ к сущности Link.
        public DbSet<Link> Links { get; set; }
        public LinkContext(DbContextOptions<LinkContext> options)  : base(options)
        {
        }
    }
}
