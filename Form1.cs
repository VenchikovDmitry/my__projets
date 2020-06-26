using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using ConsoleAppinterview;
using System.Threading;
namespace WindowsFormsAppAccounting
{
    public partial class Form1 : Form
    {
       
        public Form1()
        {
           
            InitializeComponent();
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            richTextBoxList.Text = "наведите мышь";
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

            FormAddFlat formAddFlat = new FormAddFlat();
            formAddFlat.Show();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
           
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            using (var context = new MyDBContext()) //MyDBContext это названиие главной базы из  главного точка кс 
            {
                int generalNumberOfResidents = 0;

                var result2 = context.Peoples.Where(item => item.Datetime == textBox1.Text);
                foreach (var obj in result2)
                {
                    generalNumberOfResidents += obj.numberOfResidents;
                }
                richTextBox1.Text = "\n общее количество проживающих на заданную дату - " + generalNumberOfResidents;
            }
        }
    

    private void button1_Click(object sender, EventArgs e)
    {
        using (var context = new MyDBContext()) //MyDBContext это названиие главной базы из  главного точка кс 
        {
            int GeneralArea = 0;
                richTextBox1.Text = "";
                var result2 = context.Flats.Where(item => item.TotalArea > 0);
            foreach (var obj in result2)
            {
                GeneralArea += obj.TotalArea;
            }
            richTextBox1.Text = "\n общая площадь квартир равняется - " + GeneralArea;
        }
    }

       private void button4_Click(object sender, EventArgs e)
       {
        using (var context = new MyDBContext()) //MyDBContext это названиие главной базы из  главного точка кс 
            {
                richTextBox1.Text = "";
            for (int i = 1; i <= context.Flats.Max(p => p.Entrance); i++)
            {
                var result2 = context.Flats.Where(item => item.Entrance == i);

                int counter = 0;
                foreach (var obj in result2)
                {
                    counter++;
                }
                richTextBox1.Text += $"\n количество квартир в {i}-м подъезде " + counter;

            }

        }
       }
 
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void richTextBoxList_TextChanged(object sender, EventArgs e)
        {

        }
        delegate void Mes();
        private  void Loading()
        {
            using (var context = new MyDBContext()) 
            {
                richTextBoxList.Text = "";
                var result2 = context.Flats.Where(item => item.Number != 0); ;
                List<int> list = new List<int>();

                foreach (var obj in result2)
                {
                    list.Add(obj.Number);

                }
                IEnumerable<int> distinctAges = list.Distinct();
                foreach (var obj in list)
                {
                    richTextBoxList.Text += "\n квартира номер - " + obj;
                }

            }
        }
  
        private void richTextBoxList_MouseEnter(object sender, EventArgs e)
        {
            using (var context = new MyDBContext()) 
            {
                richTextBoxList.Text = "";
                var result2 = context.Flats.Where(item => item.Number != 0); ;
                List<int> list = new List<int>();

                foreach (var obj in result2)
                {
                    list.Add(obj.Number);

                }
                IEnumerable<int> distinctAges = list.Distinct();
                foreach (var obj in distinctAges)
                {
                    richTextBoxList.Text += "\n квартира номер - " + obj;
                }

            }
        }

        private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            using (var context = new MyDBContext())                                 
            {

                int d = Convert.ToInt32(comboBox1.SelectedItem.ToString());
                var result = from item in context.Flats
                                
                             where item.Number == d
                             select item;

                foreach (var item in result)
                {
               
                    context.Flats.Remove(item);
                    
                }

                var result2 = from item in context.Peoples

                             where item.Number == d
                             select item;

                foreach (var item in result2)
                {

                    context.Peoples.Remove(item);

                }
                var result3 = from item in context.nameSakeListOfResidents

                              where item.Number == d
                              select item;

                foreach (var item in result3)
                {

                    context.nameSakeListOfResidents.Remove(item);

                }

                context.SaveChanges();
            }
        }

        private void comboBox1_MouseEnter(object sender, EventArgs e)
        {
            using (var context = new MyDBContext()) 
            {
                var result2 = context.Flats.Where(item => item.Number != 0); ;
                List<int> list = new List<int>();

                foreach (var obj in result2)
                {
                      list.Add(obj.Number);
                 
                }
                IEnumerable<int> distinctAges = list.Distinct();
                comboBox1.Items.Clear();
                foreach (var obj in distinctAges)
                {
                    try
                    {
                        comboBox1.Items.Add(obj);
                    }
                    catch (NullReferenceException)
                    {

                    }

                }


            }
          
          

        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            using (var context = new MyDBContext()) 
            {
                richTextBox1.Text = "";
                // дальше логика выборки

                var result2 = from item in context.Flats
                where item.Entrance != -1
                                        select item;
                if (textBox3.Text != "")
                  {
                    int entrance = 0;
                    try
                    {
                        entrance = Convert.ToInt32(textBox3.Text);

                    }
                    catch
                    {
                        MesWin mes = new MesWin();
                        mes.Show();
                    }
                    result2 = from item in result2
                              where item.Entrance == entrance
                              select item;
                }

                if (textBox4.Text != "")
                {
                    int fl = 0;
                    try
                    {
                        fl = Convert.ToInt32(textBox4.Text);

                    }
                    catch
                    {
                        MesWin mes = new MesWin();
                        mes.Show();
                    }

                    result2 = from item in result2
                                  where item.floor == fl
                                  select item;
                    
                }
              
                if (textBox5.Text != "")
                {
                    int fl = 0;
                    try
                    {
                        fl = Convert.ToInt32(textBox5.Text);

                    }
                    catch
                    {
                        MesWin mes = new MesWin();
                        mes.Show();
                    }
                    result2 = from item in result2
                              where item.TotalArea == fl
                              select item;
                }
                if (textBox8.Text != "")
                {
                    int fl = 0;
                    try
                    {
                        fl = Convert.ToInt32(textBox8.Text);

                    }
                    catch
                    {
                        MesWin mes = new MesWin();
                        mes.Show();
                    }
                    result2 = from item in result2
                              where item.numberOfResidents.numberOfResidents == fl
                              select item;
                }

                if (textBox7.Text != "")
                    {
                    int fl = 0;
                    try
                    {
                        fl = Convert.ToInt32(textBox7.Text);
                    }
                    catch
                    {
                        MesWin mes = new MesWin();
                        mes.Show();
                    }
                    result2 = from item in result2
                              where item.LivingArea == fl
                              select item;
     
                    }
                
                    if (textBox6.Text != "")
                    {
                                  result2 = from item in result2
                                  where item.numberOfResidents.Datetime == textBox6.Text
                                  select item;
                    }

                List<int> list = new List<int>();

                foreach (var obj in result2)
                {
                    list.Add(obj.Number);

                }
                IEnumerable<int> OutList = list.Distinct();

                richTextBox1.Text = "";


                foreach (var obj in OutList)
                {
                    richTextBox1.Text += "\n квартира номер - " + obj;
                }
                list.Clear();
                OutList = null;
            }
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
