using CalebMVCAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace CalebMVCAPI.Data
{
   public class calebAPIContext : DbContext
   {
      public calebAPIContext(DbContextOptions<calebAPIContext> opt) : base(opt)
      {

      }

      public DbSet<calebModels> calebModelDB { get; set; }
   }
}