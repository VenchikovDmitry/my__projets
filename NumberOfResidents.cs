using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppinterview
{
     public  class NumberOfResidents
    {
       // [Key, ForeignKey("Flat")]
        public int Id { get; set; }
        public int numberOfResidents { get; set; }  //количество  проживающих  с привязкой  к дате 
        public string Datetime { get; set; }//время
        public int Number { get; set; }  //номер квартиры


       


       //public virtual Flat Flats { get; set; } // это  позволяет автоматически подставлять свойства
       
    }
}
