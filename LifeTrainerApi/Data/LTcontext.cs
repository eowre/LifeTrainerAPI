using LifeTrainerApi.Models;
using Microsoft.EntityFrameworkCore;

namespace LifeTrainerApi.Data
{
    public class LTcontext : DbContext
    {
        // Constructor
        public LTcontext(DbContextOptions<LTcontext> options) : base(options) { }
        public DbSet<Avatar> avatars { get; set; }
        public DbSet<Item> items { get; set; }
    }
}
