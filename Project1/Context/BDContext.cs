using Project1.BDInitializer;
using Project1.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Project1.Context
{
    public class BDContext: DbContext
    {
        /*создание и наполнение БД
        static BDContext()
        {
            Database.SetInitializer<BDContext>(new Initializer());
        }*/
        /*public BDContext() : base("DefaultConnection")
        { }*/
        public DbSet<Detail> Details { get; set; }
        public DbSet<Zakaz> Zakazs  { get; set; }
        public DbSet<TypeMashin> TypeMashins { get; set; }
        public DbSet<Money> Moneys { get; set; }
        public DbSet<Bazaar> Bazaars { get; set; }
        public DbSet<NameOfMashin> NameOfMashins { get; set; }
        public DbSet<Worker> Workers { get; set; }
        public DbSet<Credit> Credits { get; set; }
    }
}