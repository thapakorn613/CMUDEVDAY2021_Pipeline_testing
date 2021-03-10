using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CMUDevday2021.Model.entity;
using Microsoft.EntityFrameworkCore;

namespace CMUDevday2021.Model
{
    public class UserContext : DbContext
    {
        public UserContext(DbContextOptions<UserContext> option) : base(option)
        {

        }
        public DbSet<Menu> Menu { get; set; }
        public DbSet<User> User { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Menu>().HasData(
                 new
                 {
                     MenuId = 1,
                     MenuName = "menu1",
                     MenuPath = "/",
                 },
                 new
                 {
                     MenuId = 2,
                     MenuName = "menu2",
                     MenuPath = "/",
                 },
                 new
                 {
                     MenuId = 3,
                     MenuName = "menu3",
                     MenuPath = "/",
                 },
                 new
                 {
                     MenuId = 4,
                     MenuName = "menu4",
                     MenuPath = "/",
                 },
                 new
                 {
                     MenuId = 5,
                     MenuName = "menu5",
                     MenuPath = "/",
                 },
                 new
                 {
                     MenuId = 6,
                     MenuName = "menu6",
                     MenuPath = "/",
                 }
            );
        }
    }
}
