﻿using System.IO;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using ToDoList.Models;

namespace ToDoList;

public class DatabaseContext : DbContext
{
    private const string NameDatabase = "todobase.sqlite";

    public const int VersionDatabase = 1;
    
    public DbSet<TaskModel> ToDoTasks { get; set; } = null!;
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!File.Exists(NameDatabase))
        {
            //По сути ничего не нужно инициализировать из начальной базы
            //Все таблицы и прочее создаются во время работы программы
            //Так что ничего не теряем если будем сами создавать базу
            File.WriteAllBytes(NameDatabase, Array.Empty<byte>());
        }

        optionsBuilder.UseSqlite("Data Source=todobase.sqlite");
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TaskModel>(entity =>
        {
            entity.HasKey(e => e.Id);
        });
    }
}