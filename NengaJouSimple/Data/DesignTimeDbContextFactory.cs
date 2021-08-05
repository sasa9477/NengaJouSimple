using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Text;

namespace NengaJouSimple.Data
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
    {
        // マイグレーションコマンド
        // Add-Migration InitialCreate -Output "Data/Migrations"

        public ApplicationDbContext CreateDbContext(string[] args)
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>().UseSqlite("Data Source=:memory:").Options;

            return new ApplicationDbContext(options);
        }
    }
}
