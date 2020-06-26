using ConsoleAppinterview;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WindowsFormsAppAccounting
{
   
    public partial class FormAddFlat : Form
    {

        public static int generalNumberOfResidents;
        public FormAddFlat()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox6_Enter(object sender, EventArgs e)    //ввод количества жильцов здесь должен быть вызов формы, в которую будет вбиваться соответвующаяя дата
        {

        }

        private void FormAddFlat_Load(object sender, EventArgs e)
        {

        }

        private void textBox14_TextChanged(object sender, EventArgs e)
        {

        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            using (var context = new MyDBContext()) //MyDBContext это названиие главной базы из  главного точка кс 
            {
                NumberOfResidents c = new NumberOfResidents()
                {
                    numberOfResidents= Convert.ToInt32(textBox6.Text),
                   
                    Datetime= textBox15.Text,

                    Number= Convert.ToInt32(textBox1.Text)

                };
                context.Peoples.Add(c);
                NameSakeListOfResidents d = new NameSakeListOfResidents()
                {
                    Datetime = textBox15.Text,
                    Number = Convert.ToInt32(textBox1.Text)

                };
                context.nameSakeListOfResidents.Add(d);
                var flat1 = new Flat()
                {
                   
                Number = Convert.ToInt32(textBox1.Text),
                    Entrance = Convert.ToInt32(textBox3.Text),
                    floor = Convert.ToInt32(textBox2.Text),
                    TotalArea = Convert.ToInt32(textBox4.Text),
                    LivingArea = Convert.ToInt32(textBox5.Text),
                    numberOfResidents = c ?? null,
                    
                };
                context.Flats.Add(flat1);
                context.SaveChanges();
            }
        }
        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox7_Enter(object sender, EventArgs e)
        {
          
        }

        private void textBox7_DoubleClick(object sender, EventArgs e)
        {
           
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }
       
        private void textBox7_MouseDoubleClick(object sender, MouseEventArgs e)  //по  двойному щелчку идет заполнение таблицы о проживающих от времени 
        {
           
        }

        private void textBox7_MouseLeave(object sender, EventArgs e)
        {
            //using (var context = new MyDBContext()) //MyDBContext это названиие главной базы из  главного точка кс 
            //{
            //    NameSakeListOfResidents d = new NameSakeListOfResidents()
            //    {
            //        NameList = Convert.ToString(textBox7.Text),
            //        Datetime = textBox15.Text,
            //        Number = Convert.ToInt32(textBox1.Text)

            //    };
            //    context.nameSakeListOfResidents.Add(d);
            //}
        }

        private void textBox15_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (var context = new MyDBContext()) //MyDBContext это названиие главной базы из  главного точка кс 
            {
                NameSakeListOfResidents d = new NameSakeListOfResidents()
                {
                    NameList = Convert.ToString(textBox7.Text),
                    Datetime = textBox15.Text,
                    Number = Convert.ToInt32(textBox1.Text)
                };
                context.nameSakeListOfResidents.Add(d);
                context.SaveChanges();
            }
        }
    }
}
