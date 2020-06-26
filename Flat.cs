using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppinterview
{
   
    public class Flat
    {
        //задаем  идентификатор
        public int Id { get; set; }
        public int Number { get; set; }  //номер квартиры
        public int Entrance { get; set; }  //номер подъезда
        public int floor { get; set; }    //этаж
        public int TotalArea { get; set; }    //может быть  нулевым поэтому и знак вопроса ?
        public int LivingArea { get; set; }    //может быть  нулевым поэтому и знак вопроса ?
     
        public  NumberOfResidents numberOfResidents { get; set; }
        

        //  public Dictionary<DateTime, int> NumberOfResidents = new Dictionary<DateTime, int>(4); //количество  проживающих  с привязкой  к дате 

        // public List<string> NameSakeListOfResidents = new List<string>();
        // public Flat(int number, int entrance, int totalArea, int livingArea, int numberOfResidents, string surName)
        // {


        //  }
       // public virtual ICollection<NumberOfResidents> Peoples { get; set; } // это  позволяет автоматически подставлять свойства

    }
}
