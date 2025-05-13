using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proiect
{
    public partial class Form1: Form, IObservableObj
    {
        //atributele necesare pentru desenarea triunghiului
        private int nOfPoints = 0;

        //punctele triunghiului
        private Point p1, p2, p3;

        //valorile punctelor triunghiului
        private int vP1 = 0;
        private int vP2 = 0;
        private int vP3 = 0;

        //lista de urmaritori
        private List<ISubscriber> subscriber = new List<ISubscriber>();
       
        /// <summary>
        /// Functie pentru initializarile componentelor necesare de pe interfata
        /// </summary>
        public Form1()
        {
            InitializeComponent();
            pictureBox1.MouseClick += new MouseEventHandler(pictureBox1_Click);
            //pictureBox1.Paint += new PaintEventHandler(pictureBox1_Paint);
            /////
        }


        ///Functii accesor pentru atributele clasei
        //public int GetNrOfPoints() => nOfPoints;
        //...completare





        /// <summary>
        /// Functia implementata din IObservableObj
        /// </summary>
        /// <param name="subscriber"></param>
        public void AddSubscriber(ISubscriber subscriber)
        {

        }

        /// <summary>
        /// Functia implementata din IObservableObj
        /// </summary>
        /// <param name="subscriber"></param>
        public void RemoveSubscriber(ISubscriber subscriber)
        {
        }
        /// <summary>
        /// Functia implementata din IObservableObj
        /// </summary>
        /// <param name="subscriber"></param>
        public void Notify()
        {

        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void richTextBoxCalculate_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
