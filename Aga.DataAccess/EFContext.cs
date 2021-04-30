using Aga.DataAccess.Entity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aga.DataAccess
{
    public class EFContext : IdentityDbContext<User>
    {
        public EFContext(DbContextOptions<EFContext> options) : base (options)
        {

        }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<New> News { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Homework> Homeworks { get; set; }
        public DbSet<Lesson> Lessons { get; set; }
        public DbSet<Reward> Rewards { get; set; }
        public DbSet<StudentReward> StudentRewards { get; set;}
    }
}
