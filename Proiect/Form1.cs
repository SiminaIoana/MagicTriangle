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
            //pictureBox1.MouseClick += new MouseEventHandler(pictureBox1_Click);
            //pictureBox1.Paint += new PaintEventHandler(pictureBox1_Paint);
            /////
        }


        ///Functii accesor pentru atributele clasei
        public int GetNrOfPoints() => nOfPoints;
        /// <summary>
        /// Accesori puncte
        /// </summary>
        /// <returns></returns>
        public Point GetP1() => p1;
        public Point GetP2() => p2;
        public Point GetP3() => p3;

        /// <summary>
        /// Accesori valori puncte
        /// </summary>
        /// <returns></returns>
        public int GetV1() => vP1;

        public int GetV2() => vP2;

        public int GetV3() => vP3;

        public double GetArie(Point p1, Point p2, Point p3)
        {
            return 2;
        }

        public double GetPerimetru(Point p1, Point p2, Point p3)
        {
            return 2;
        }

        public double GetDistanta(Point p1, Point p2)
        {
            return 2;
        }

        public double GetCentruDeGreutate(Point p1, Point p2, Point p3)
        {
            return 2;
        }

        public double GetCentruCercInscris(Point p1, Point p2, Point p3)
        {
            return 2;
        }

        public double GetRazaCercInscris(Point p1, Point p2, Point p3)
        {
            return 2;
        }

        public double GetCentruCercCircumscris(Point p1, Point p2, Point p3)
        {
            return 2;
        }

        public double GetRazaCercCircumscris(Point p1, Point p2, Point p3)
        {
            return 2;
        }

        public double GetOrtocentru(Point p1, Point p2, Point p3)
        {
            return 2;
        }



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
        

        /// <summary>
        /// Zona pentru afisarea valorilor masuratorilor
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void richTextBoxCalculate_TextChanged(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Functie de callback pentru redesenarea primului punct al triunghiului
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonRescrierePunct1_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Functie de callback pentru redesenarea celui de al treilea punct al triunghiului
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonRescrierePunct3_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Buton de Help
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonHelp_Click(object sender, EventArgs e)
        {
            
            
        }

        /// <summary>
        /// Buton de exit
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonExit_Click(object sender, EventArgs e)
        {
            Application.Exit();

        }

        /// <summary>
        /// Buton pentru afisarea valorilor in TextBox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonAfisareValori_Click(object sender, EventArgs e)
        {

        }

        

        /// <summary>
        /// Functie de callback pentru redesenarea al celui de al doilea punct al triunghiului
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonRescrierePunct2_Click(object sender, EventArgs e)
        {

        }


        /// <summary>
        /// Gestionarea de click-uri pentru setarea punctelor si desenarea triunghiului
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }



        //////    FUNCTII PENTRU CALCULE ASUPRA TRIUNGHIULUI    ////////////////////////////////////////////////////////////////////////
        

        private double Distanta(Point p1, Point p2)
        {
            return 2;
            //trebuie facuta implementare
        }

        private double Perimetru(Point p1, Point p2, Point p3)
        {

            ///trebuie facuta impplementare
            return 2.0;
        }

        private double Arie(Point p1, Point p2, Point p3)
        {
            return 2.0;
            //trebuie facuta implementare
        }

        private PointF CentruDeGreutate(Point p1, Point p2, Point p3)
        {
            return new PointF(2, 3);
            //trebuie facuta implementare
        }


        private PointF CentruCercInscris(Point p1, Point p2, Point p3)
        {
            return new PointF(2, 3);
            //trebuie facuta implementare;
        }

        private PointF RazaCercInscris (Point p1, Point p2, Point p3)
        {
            return new PointF(2, 3);
            //trebuie facuta implementare;
        }

        private PointF CentruCercCircumscris(Point p1, Point p2, Point p3)
        {
            return new PointF(2, 3);
            //trebuie facuta implementare;
        }

        private PointF RazaCercCircumscris(Point p1, Point p2, Point p3)
        {
            return new PointF(2, 3);
            //trebuie facuta implementare;
        }

        private PointF Ortocentru(Point p1, Point p2, Point p3)
        {
            return new PointF(2, 3);
            //trebuie facuta implementare;
        }

        /// <summary>
        /// Functie ce va returna punctul de intersectie dintre o dreaptasi perpendiculara dusa dintr-un punct pe acea dreapta
        /// </summary>
        /// <param name="punct"></param>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <returns></returns>
        private PointF PerpendicularaPunctDreapta(Point p, Point startL, Point endL )
        {
            return new PointF(2, 3);
            //trebuie facuta implementare;
            //p --> varful din care pleaca inaltimea
            //startL -> punctul de start ar dreptei pe care pica inaltimea
        }

        private PointF GetIntersectie(Point p1, Point p2, Point p3, Point p4)
        {
            return new PointF(2, 3);
            //trebuie facuta implementare;
        }




        //////    FUNCTII PENTRU DESENAREA TRIUNGHIULUI / ELEMENTELOR SPECIFICE TRIUNGHILUI    //////////////////////////////////////////////
        
        private void DesenareTriunghi(Graphics g)
        {
            //de implementat
        }

        private void DesenareCercInscris(Graphics g, Point p1, Point p2, Point p3)
        {
            //de implementat
        }

        private void DesenareCerCircumscris(Graphics g, Point p1, Point p2, Point p3)
        {
            //de implementat
        }

        private void DesenareBisectoare( Graphics g, Point p1, Point p2, Point p3)
        {
            //de implementat
        }

        private void DesenareMediana(Graphics g, Point p1, Point p2, Point p3)
        {
            //de implementat
        }

        private void DesenareInaltime(Graphics g, Point p1, Point p2, Point p3)
        {
            //de implementat
        }
















    }
}
