using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Ozon_Tech_Api.Tables;

namespace Ozon_Tech_Api.Contexts
{
    internal class Contexts
    {
        public class ApplicationContext : DbContext
        {
            protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            {
               Config config = new Config();

                optionsBuilder.UseNpgsql($"Host={config.Host};Port={config.Port};Database={config.Database};Username={config.Username};Password={config.Password}");
            }

            public DbSet<User> User { get; set; }
            public DbSet<Route> Route { get; set; }
            public DbSet<Course> Course { get; set; }
            public DbSet<File_Recommendations> File_Recommendations { get; set; }
            public DbSet<File_To_Send> File_To_Send { get; set; }
            public DbSet<File_Topics> File_Topics { get; set; }
            public DbSet<Message> Message { get; set; }
            public DbSet<Message_Text> Message_Text { get; set; }
            public DbSet<Reminder> Reminder { get; set; }
            public DbSet<Send_Order> Send_Order { get; set; }
            public DbSet<Statuses> Statuses { get; set; }
            public DbSet<User_Responses> User_Responses { get; set; }
            public DbSet<Users_Course_End> Users_Course_End { get; set; }
        }
    }
}
