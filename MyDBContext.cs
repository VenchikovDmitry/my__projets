using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppinterview
{
   public class MyDBContext : DbContext 
    {
        public MyDBContext() : base("DbConnectionString")//это имя из  конфига 
        {

        }

        public DbSet<Flat> Flats { get; set; }    //это  позволяет  получить  всю таблицу
        public DbSet<NumberOfResidents> Peoples { get; set; }
        public DbSet<NameSakeListOfResidents> nameSakeListOfResidents { get; set; }
    }
}
