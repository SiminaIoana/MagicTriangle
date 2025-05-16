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
    public partial class Form1 : Form, IObservableObj
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
        private List<ISubscriber> subscribers = new List<ISubscriber>();

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
            return Arie(p1, p2, p3);
        }

        public double GetPerimetru(Point p1, Point p2, Point p3)
        {
            return CalculeazaPerimetru(p1,p2,p3);
        }

        public double GetDistanta(Point p1, Point p2)
        {
            return CalculeazaDistanta(p1, p2);
        }

        public PointF GetCentruDeGreutate(Point p1, Point p2, Point p3)
        {
            return CentruDeGreutate(p1,p2,p3);
        }

        public PointF GetCentruCercInscris(Point p1, Point p2, Point p3)
        {
            return CentruCercInscris(p1,p2,p3);
        }

        public double GetRazaCercInscris(Point p1, Point p2, Point p3)
        {
            return RazaCercInscris(p1,p2,p3);
        }

        public PointF GetCentruCercCircumscris(Point p1, Point p2, Point p3)
        {
            return CentruCercCircumscris(p1,p2,p3);
        }

        public double GetRazaCercCircumscris(Point p1, Point p2, Point p3)
        {
            return RazaCercCircumscris(p1,p2,p3);
        }

        public PointF GetOrtocentru(Point p1, Point p2, Point p3)
        {
            return Ortocentru(p1,p2,p3);
        }


        /// <summary>
        /// Functia implementata din IObservableObj
        /// </summary>
        /// <param name="subscriber"></param>
        public void AddSubscriber(ISubscriber subscriber)
        {
            subscribers.Add(subscriber);
        }

        /// <summary>
        /// Functia implementata din IObservableObj
        /// </summary>
        /// <param name="subscriber"></param>
        public void RemoveSubscriber(ISubscriber subscriber)
        {
            subscribers.Remove(subscriber);
        }
        /// <summary>
        /// Functia implementata din IObservableObj
        /// </summary>
        /// <param name="subscriber"></param>
        public void Notify()
        {
            foreach(ISubscriber s in subscribers)
            {
                s.Update(p1, p2, p3, nOfPoints);
            }
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


        private double CalculeazaDistanta(Point p1, Point p2)
        {
            if (p1 == p2)
            {
                throw new ArgumentException("Aceste puncte sunt identice");
            }
            else
            {
                double x1 = p1.X, x2 = p2.X;
                double y1 = p1.Y, y2 = p2.Y;
                double difX = Math.Pow((x1 - x2), 2);
                double difY = Math.Pow((y1 - y2), 2);
                return Math.Sqrt(difX + difY); //hei, eu zic ca e cu + formula (tudor)
            }


        }

        private double CalculeazaPerimetru(Point p1, Point p2, Point p3)
        {

            double l1 = CalculeazaDistanta(p1, p2);
            double l2 = CalculeazaDistanta(p2, p3);
            double l3 = CalculeazaDistanta(p3, p1);

            return l1 + l2 + l2;
        }

        private double Arie(Point p1, Point p2, Point p3)
        {
            double l1 = CalculeazaDistanta(p1, p2);
            double l2 = CalculeazaDistanta(p2, p3);
            double l3 = CalculeazaDistanta(p3, p1);

            double p = (l1 + l2 + l3) / 2;

            return Math.Sqrt(p * (p - l1) * (p - l2) * (p - l3)); //formula lui Heron
        }

        private PointF CentruDeGreutate(Point p1, Point p2, Point p3)
        {
            float x = (p1.X + p2.X + p3.X) / 3.0f;
            float y = (p1.Y + p2.Y + p3.Y) / 3.0f;

            return new PointF(x, y);
        }


        private PointF CentruCercInscris(Point p1, Point p2, Point p3)
        {
            double a = CalculeazaDistanta(p2, p3);
            double b = CalculeazaDistanta(p1, p3);
            double c = CalculeazaDistanta(p1, p2);

            double sum = a + b + c;

            float x = (float)((a * p1.X + b * p2.X + c * p3.X) / sum);
            float y = (float)((a * p1.Y + b * p2.Y + c * p3.Y) / sum);

            return new PointF(x, y);
        }

        private double RazaCercInscris(Point p1, Point p2, Point p3) //aici era de tip PointF da zic ca ar trb double nu??
        {
            double arie = Arie(p1, p2, p3);
            double s = CalculeazaPerimetru(p1, p2, p3) / 2;

            return arie / s;

        }

        private PointF CentruCercCircumscris(Point p1, Point p2, Point p3)
        {
            double a = CalculeazaDistanta(p2, p3);
            double b = CalculeazaDistanta(p1, p3);
            double c = CalculeazaDistanta(p1, p2);

            double a2 = a * a;
            double b2 = b * b;
            double c2 = c * c;

            double x = (a2 * p1.X + b2 * p2.X + c2 * p3.X) / (a2 + b2 + c2);
            double y = (a2 * p1.Y + b2 * p2.Y + c2 * p3.Y) / (a2 + b2 + c2);

            return new PointF((float)x, (float)y);
        }

        private double RazaCercCircumscris(Point p1, Point p2, Point p3) //la fel, double in loc de PointF idk
        {
            double a = CalculeazaDistanta(p1, p2);
            double b = CalculeazaDistanta(p2, p3);
            double c = CalculeazaDistanta(p3, p1);

            double aria = Arie(p1, p2, p3);

            if (aria == 0)
            {
                throw new ArgumentException("Punctele sunt coliniare, nu există cerc circumscris.");
            }
            return (a * b * c) / (4 * aria);
        }

        private PointF Ortocentru(Point p1, Point p2, Point p3)
        {
            float x1 = p1.X, y1 = p1.Y;
            float x2 = p2.X, y2 = p2.Y;
            float x3 = p3.X, y3 = p3.Y;

            float a1 = x2 - x1;
            float b1 = y2 - y1;
            float a2 = x3 - x1;
            float b2 = y3 - y1;

            float c1 = a1 * (x1 + x2) + b1 * (y1 + y2);
            float c2 = a2 * (x1 + x3) + b2 * (y1 + y3);

            float d = 2 * (a1 * (y3 - y2) - b1 * (x3 - x2));

            float x = (b2 * c1 - b1 * c2) / d;
            float y = (a1 * c2 - a2 * c1) / d;

            return new PointF(x, y);
        }

        /// <summary>
        /// Functie ce va returna punctul de intersectie dintre o dreapta si perpendiculara dusa dintr-un punct pe acea dreapta
        /// </summary>
        /// <param name="punct"></param>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <returns></returns>
        private PointF PerpendicularaPunctDreapta(Point p, Point startL, Point endL)
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

        private void DesenareBisectoare(Graphics g, Point p1, Point p2, Point p3)
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
