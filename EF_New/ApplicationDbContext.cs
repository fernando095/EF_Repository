﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace EF_New
{
    class ApplicationDbContext : DbContext
    {
        public DbSet<Estudante> Estudantes { get; set; }
        public DbSet<Endereco> Enderecos { get; set; }
        public DbSet<Turma> Turmas { get; set; }



        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=INOTE152\\SQLEXPRESS; Initial Catalog=banco; Integrated Security=True;")
                //Habilitar os logs
                .EnableSensitiveDataLogging(true)
                .UseLoggerFactory(new LoggerFactory()
                    .AddConsole((category, level) => level == LogLevel.Information && category == DbLoggerCategory.Database.Command.Name, true));
        }
    }
}
