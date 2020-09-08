namespace Data.Migrations
{
    using Data.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Data.EmployeeDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Data.EmployeeDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data
            context.Employees.AddOrUpdate(
                new Employee
                {
                    FullName = "Nguyễn Anh Đức",
                    Salary = 1000,
                    CreatedDate = DateTime.Now,
                    Status = true
                },
                new Employee
                {
                    FullName = "Đỗ Minh Phượng",
                    Salary = 2000,
                    CreatedDate = DateTime.Now,
                    Status = true
                },
                new Employee
                {
                    FullName = "Trần Thu Uyên",
                    Salary = 3000,
                    CreatedDate = DateTime.Now,
                    Status = false
                }
                );
            context.SaveChanges();
        }
    }
}
