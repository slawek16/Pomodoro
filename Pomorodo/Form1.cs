using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;
using System.Collections;

namespace Pomorodo
{
    

    public partial class Form1 : Form
    {
        Timer tim = new System.Windows.Forms.Timer();
        private byte min = 0;
        private byte sec = 3;
        private string timex = "";
        private byte pomodor = 7;
        private bool kontroler = true;

        private SoundPlayer sound1 = new SoundPlayer(@"D:\studia\programy_c\Pomorodo\Pomorodo\sound1.wav");
        private SoundPlayer soudn2 = new SoundPlayer(@"D:\studia\programy_c\Pomorodo\Pomorodo\sound2.wav");


        List<Zadanie> zadania = new List<Zadanie>();
        

        public Form1()
        {
            InitializeComponent();
            
            
        }

       

        private void kontrolka()
        {
            
            if(pomodor==8)
            {
                label3.Text = "koniec pracy";
                pomodor = 1;
                tim.Stop();
                
                
            }
            else
            {
                if (kontroler is true)
                {
                    tim.Interval = 1000;
                    tim.Tick -= tick_a;
                    tim.Tick -= tick_b;
                    tim.Tick += new EventHandler(tick_a);
                    tim.Start();
                }
                else
                {
                    tim.Interval = 1000;
                    tim.Tick -= tick_a;
                    tim.Tick -= tick_b;
                    tim.Tick += new EventHandler(tick_b);
                    tim.Start();
                }
            }

            
        }

       private void tick_a(object sender, EventArgs e)
        {
            label2.Text = "" + pomodor + "/7";
            label3.Text = "praca...";
            label3.BackColor = Color.IndianRed;
            
            

            if (sec==00)
            {
                min--;
                sec = 60;
            }
            sec--;
            timex = min + ":" + sec;
            label1.Text = timex;

            if ((min==0)&&(sec==0))
            {
                min = 5;
                sec = 0;
                kontroler = false;

                label3.Text = "praca zakonczona...";
                sound1.Play();
                kontrolka();
                tim.Stop();

            }
            
        }
        private void tick_b(object sender, EventArgs e)
        {
            label2.Text = "" + pomodor + "/7";
            label3.Text = "przerwa...";
            label3.BackColor = Color.YellowGreen;
            timex = min + "::" + sec;
            label1.Text = timex;

            if (sec == 00)
            {
                min--;
                sec = 60;
            }
            sec--;
            timex = min + "::" + sec;
            label1.Text = timex;
            if ((min == 0) && (sec == 0))
            {
                label1.Text = timex;
                min = 25;
                sec = 0;
                kontroler = true;
                pomodor++;

                label3.Text = "przerwa zakonczona...";
                kontrolka();
                soudn2.Play();
                tim.Stop();

            }
            
        }




        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            kontrolka();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            tim.Stop();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            min = 25;
            sec = 0;
            pomodor = 1;
            kontroler = true;
            timex = min + ":" + sec;
            label1.Text = timex;
            tim.Stop();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            
            zadania.Add(new Zadanie(textBox1.Text));
            
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = zadania;
            dataGridView1.Columns[0].Width = 30;
            dataGridView1.Columns[1].Width = 270;
            dataGridView1.Columns[0].HeaderText = "Stan Zadania";
            dataGridView1.DefaultCellStyle.BackColor = Color.Green;
            


        }
        private void textBox1_MouseClick(object sender, EventArgs e)
        {
            textBox1.Text = "";
        }
        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {

        }
    }
}
