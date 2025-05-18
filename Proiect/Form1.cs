using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
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

            //initializarea observatorului 
            new TriangleSubscriber(this);
            pictureBox1.MouseClick += new MouseEventHandler(pictureBox1_Click);
            //adaugarea unui nou eveniment de desenare dupa click
            pictureBox1.Paint += new PaintEventHandler(pictureBox1_Paint);


            //evenimentul de bifare al casutelor
            checkBoxBisectoare.CheckedChanged += new EventHandler(checkBoxBisectoare_CheckedChanged);
            checkBoxMediane.CheckedChanged += new EventHandler(checkBoxMediane_CheckedChanged);
            checkBoxInaltimi.CheckedChanged += new EventHandler(checkBoxInaltimi_CheckedChanged);
            checkBoxCercInscris.CheckedChanged += new EventHandler(checkBoxCercInscris_CheckedChanged);
            checkBoxCercCircumscris.CheckedChanged += new EventHandler(checkBoxCercCircumscris_CheckedChanged);

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
            if(vP1 == 0 || vP2 == 0 || vP3 == 0)
            {
                MessageBox.Show("Trebuie setate toate punctele!");
            }
            vP1 = 0;
            nOfPoints = 2;
        }

        /// <summary>
        /// Functie de callback pentru redesenarea celui de al treilea punct al triunghiului
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonRescrierePunct3_Click(object sender, EventArgs e)
        {
            if (vP1 == 0 || vP2 == 0 || vP3 == 0)
            {
                MessageBox.Show("Trebuie setate toate punctele!");
            }
            vP3 = 0;
            nOfPoints = 2;

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
            if (vP1 == 0 || vP2 == 0 || vP3 == 0)
            {
                MessageBox.Show("Trebuie setate toate punctele!");
            }
            vP2 = 0;
            nOfPoints = 2;
        }


        /// <summary>
        /// Gestionarea de click-uri pentru setarea punctelor si desenarea triunghiului
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            try
            {
                if (nOfPoints >= 3)
                    return;

                MouseEventArgs mouseE = (MouseEventArgs)e;

                //pozitia relativa a punctului la evenimentul de click
                Point punctRelativ = pictureBox1.PointToClient(Cursor.Position);

                if(vP1==0)
                {
                    p1 = punctRelativ;
                    vP1++;
                    nOfPoints++;

                }
                else if(vP1==1)
                {
                    vP1++;
                }
                else if(vP2==0)
                {
                    p2 = punctRelativ;
                    vP2++;
                    nOfPoints++;

                }
                else if (vP2 == 1)
                {
                    vP2++;
                }
                else if (vP3 == 0)
                {
                    p3 = punctRelativ;
                    vP3++;
                    

                }
                else if (vP3 == 1)
                {
                    vP3++;
                    nOfPoints++;
                }

                pictureBox1.Invalidate();
                Notify();

            }
            catch(Exception ex)
            {
                //trebuie implementata o functie pentru ErrorHandle
                throw new Exception("ttt",ex);
            }
        }

        /// <summary>
        /// Functie pentru desenarea triunghiului pe interfata
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            DesenareTriunghi(e.Graphics);
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

            return l1 + l2 + l3;
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


        /// <summary>
        /// Functie ce va returna punctul de intersectie dintre o dreapta si perpendiculara dusa dintr-un punct pe acea dreapta
        /// </summary>
        /// <param name="punct"></param>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <returns></returns>
        private PointF PerpendicularaPunctDreapta(Point p, Point startL, Point endL)
        {

            //p --> varful din care pleaca inaltimea
            //startL -> punctul de start ar dreptei pe care pica inaltimea
            //vector AB
            float ABx = endL.X - startL.X;
            float ABy = endL.Y - startL.Y;

            //vector AP
            float APx = p.X - startL.X;
            float APy = p.Y - startL.Y;

            //produs scalat intre AP si AB
            float produsScalar = APx * ABx + ABy * APy;

            //lungimea lui AB la patrat
            float lungime = ABx * ABx + ABy * ABy;

            //scalarul t
            float t = produsScalar / lungime;

            //coordonatele puntului proiectat
            float Hx = startL.X + t * ABx;
            float Hy = startL.Y + t * ABy;

            return new PointF(Hx, Hy);
        }

        private PointF GetIntersectie(Point p1, PointF p2, Point p3, Point p4)
        {
            //coeficienti pante
            float a1 = p2.Y - p1.Y;
            float b1 = p1.X - p2.X;
            float c1 = a1 * p1.X + b1 * p1.Y;

            float a2 = p4.Y - p3.Y;
            float b2 = p3.X - p4.X;
            float c2 = a2 * p3.X + b2 * p3.Y;

            float determinant = a1 * b2 - a2 * b1;

            if(determinant==0)
            {
                throw new ArgumentException("Liniile nu se intersecteaza!");
            }

            float x = (b2 * c1 - b1 * c2) / determinant;
            float y = (a1 * c2 - a2 * c1) / determinant;


            return new PointF(x, y);
        }


        

        //////    FUNCTII PENTRU DESENAREA TRIUNGHIULUI / ELEMENTELOR SPECIFICE TRIUNGHILUI    //////////////////////////////////////////////

        private void DesenareTriunghi(Graphics g)
        {
            try
            {
                if(nOfPoints>=3)
                {
                    Pen pen = new Pen(Color.Black, 3);
                    g.DrawLine(pen, p1, p2);
                    g.DrawLine(pen, p2, p3);
                    g.DrawLine(pen, p3, p1);

                    if(checkBoxMediane.Checked)
                    {
                        DesenareMediana(g, p1, p2, p3);
                    }
                    if(checkBoxBisectoare.Checked)
                    {
                        DesenareBisectoare(g, p1, p2, p3);
                    }
                    if(checkBoxInaltimi.Checked)
                    {
                        DesenareInaltime(g, p1, p2, p3);
                    }
                }
                else
                {
                    g.Clear(Color.White);
                }
            }
            catch(Exception e)
            {
                throw new Exception("De implementat", e);
            }


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
            PointF centruInscris = CentruCercInscris(p1, p2, p3);

            PointF i1 = GetIntersectie(p1, centruInscris, p2, p3);
            PointF i2 = GetIntersectie(p2, centruInscris, p1, p3);
            PointF i3 = GetIntersectie(p3, centruInscris, p1, p2);

            Pen p = new Pen(Color.LightSkyBlue, 1);
            g.DrawLine(p, p1, i1);
            g.DrawLine(p, p2, i2);
            g.DrawLine(p, p3, i3);

            //desenare centru
            int diametru = 10;
            g.FillEllipse(Brushes.DarkBlue, centruInscris.X - diametru / 2, centruInscris.Y - diametru / 2, diametru, diametru);

        }

        private void checkBoxBisectoare_CheckedChanged(object sender, EventArgs e)
        {
            pictureBox1.Invalidate();
            Notify();
        }

        private void checkBoxMediane_CheckedChanged(object sender, EventArgs e)
        {
            pictureBox1.Invalidate();
            Notify();
        }

        private void checkBoxInaltimi_CheckedChanged(object sender, EventArgs e)
        {
            pictureBox1.Invalidate();
            Notify();
        }

        private void checkBoxCercInscris_CheckedChanged(object sender, EventArgs e)
        {
            pictureBox1.Invalidate();
            Notify();
        }

        private void checkBoxCercCircumscris_CheckedChanged(object sender, EventArgs e)
        {
            pictureBox1.Invalidate();
            Notify();
        }

        private void buttonResetare_Click(object sender, EventArgs e)
        {
            p1 = Point.Empty;
            p2 = Point.Empty;
            p3 = Point.Empty;

            vP1 = 0;
            vP2 = 0;
            vP3 = 0;

            nOfPoints = 0;

            pictureBox1.Invalidate();
            Notify();
        }

        private void DesenareMediana(Graphics g, Point p1, Point p2, Point p3)
        {
            //calcul mijloc pentru fiecare dreapta a triunghiului
            Point m1 = new Point((p2.X + p3.X) / 2, (p2.Y + p3.Y) / 2);
            Point m2 = new Point((p1.X + p3.X) / 2, (p1.Y + p3.Y) / 2);
            Point m3 = new Point((p1.X + p2.X) / 2, (p1.Y + p2.Y) / 2);

            Pen p = new Pen(Color.Pink, 1);
            //desenare mediane in plan
            g.DrawLine(p, p1, m1);
            g.DrawLine(p, p2, m2);
            g.DrawLine(p, p3, m3);

            //intersectia medianelor este centrul de greutate
            PointF centruGreutate = CentruDeGreutate(p1, p2, p3);

            int diametru = 10;
            g.FillEllipse(Brushes.DeepPink, centruGreutate.X - diametru / 2, centruGreutate.Y - diametru / 2, diametru, diametru);

        }

        private void DesenareInaltime(Graphics g, Point p1, Point p2, Point p3)
        {
            PointF H1 = PerpendicularaPunctDreapta(p1, p2, p3);
            PointF H2 = PerpendicularaPunctDreapta(p2, p1, p3);
            PointF H3 = PerpendicularaPunctDreapta(p3, p1, p2);

            Pen p = new Pen(Color.Green, 1);
            g.DrawLine(p, p1, new Point((int)H1.X, (int)H1.Y));
            g.DrawLine(p, p2, new Point((int)H2.X, (int)H2.Y));
            g.DrawLine(p, p3, new Point((int)H3.X, (int)H3.Y));

            
            PointF ortocentru = GetIntersectie(p1, H1, p2, Point.Round(H2));

            int diametru = 10;
            g.FillEllipse(Brushes.DarkGreen, ortocentru.X - diametru / 2, ortocentru.Y - diametru / 2, diametru, diametru);


        }


    }
}
