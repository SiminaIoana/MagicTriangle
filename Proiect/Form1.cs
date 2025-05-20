using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.CompilerServices;


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

        /// <summary>
        /// Returnează aria triunghiului definit de cele trei puncte date.
        /// </summary>
        /// /// <param name="p1">Primul punct al triunghiului.</param>
        /// <param name="p2">Al doilea punct al triunghiului.</param>
        /// <param name="p3">Al treilea punct al triunghiului.</param>
        /// <returns>Aria triunghiului.</returns>
        public double GetArie(Point p1, Point p2, Point p3)
        {
            return Arie(p1, p2, p3);
        }

        /// <summary>
        /// Returnează perimetrul triunghiului definit de cele trei puncte date.
        /// </summary>
        /// /// /// <param name="p1">Primul punct al triunghiului.</param>
        /// <param name="p2">Al doilea punct al triunghiului.</param>
        /// <param name="p3">Al treilea punct al triunghiului.</param>
        /// <returns>Perimetrul triunghiului.</returns>
        public double GetPerimetru(Point p1, Point p2, Point p3)
        {
            return CalculeazaPerimetru(p1,p2,p3);
        }

        /// <summary>
        /// Returnează distanța dintre cele două puncte date.
        /// </summary>
        /// <param name="p1">Primul punct.</param>
        /// <param name="p2">Al doilea punct.</param>
        /// <returns>Distanța dintre p1 și p2.</returns>
        public double GetDistanta(Point p1, Point p2)
        {
            return CalculeazaDistanta(p1, p2);
        }

        /// <summary>
        /// Returnează centrul de greutate triunghiului definit de cele trei puncte.
        /// </summary>
        /// <param name="p1">Primul punct al triunghiului.</param>
        /// <param name="p2">Al doilea punct al triunghiului.</param>
        /// <param name="p3">Al treilea punct al triunghiului.</param>
        /// <returns>Punctul care reprezintă centrul de greutate.</returns>
        public PointF GetCentruDeGreutate(Point p1, Point p2, Point p3)
        {
            return CentruDeGreutate(p1,p2,p3);
        }

        /// <summary>
        /// Returnează centrul cercului înscris în triunghiul definit de cele trei puncte.
        /// </summary>
        /// <param name="p1">Primul vârf al triunghiului.</param>
        /// <param name="p2">Al doilea vârf al triunghiului.</param>
        /// <param name="p3">Al treilea vârf al triunghiului.</param>
        /// <returns>Punctul care reprezintă centrul cercului înscris.</returns>
        public PointF GetCentruCercInscris(Point p1, Point p2, Point p3)
        {
            return CentruCercInscris(p1,p2,p3);
        }

        /// <summary>
        /// Returnează raza cercului înscris în triunghiul format de cele trei puncte date.
        /// </summary>
        /// <param name="p1">Primul vârf al triunghiului.</param>
        /// <param name="p2">Al doilea vârf al triunghiului.</param>
        /// <param name="p3">Al treilea vârf al triunghiului.</param>
        /// <returns>Raza cercului înscris.</returns>
        public double GetRazaCercInscris(Point p1, Point p2, Point p3)
        {
            return RazaCercInscris(p1,p2,p3);
        }

        /// <summary>
        /// Returnează centrul cercului circumscris triunghiului definit de cele trei puncte date.
        /// </summary>
        /// <param name="p1">Primul vârf al triunghiului.</param>
        /// <param name="p2">Al doilea vârf al triunghiului.</param>
        /// <param name="p3">Al treilea vârf al triunghiului.</param>
        /// <returns>Punctul ce reprezintă centrul cercului circumscris.</returns>
        public PointF GetCentruCercCircumscris(Point p1, Point p2, Point p3)
        {
            return CentruCercCircumscris(p1,p2,p3);
        }

        /// <summary>
        /// Returnează raza cercului circumscris triunghiului definit de cele trei puncte date.
        /// </summary>
        /// <param name="p1">Primul vârf al triunghiului.</param>
        /// <param name="p2">Al doilea vârf al triunghiului.</param>
        /// <param name="p3">Al treilea vârf al triunghiului.</param>
        /// <returns>Raza cercului circumscris.</returns>
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
                //MessageBox.Show("Trebuie setate toate punctele!");
                MesajEroare(new Exception("Trebuie să setați toate cele 3 puncte ale triunghiului."));
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
                MesajEroare(new Exception("Trebuie să setați toate cele 3 puncte ale triunghiului."));
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
            if (nOfPoints < 3)
            {
                MesajEroare(new Exception("Trebuie să setați toate cele 3 puncte ale triunghiului."));
                return;
            }
            try
            {
                double arie = Arie(p1, p2, p3);
                double perimetru = CalculeazaPerimetru(p1, p2, p3);
                PointF centruInscris =CentruCercInscris(p1, p2, p3);
                PointF centruCircumscris = CentruCercCircumscris(p1, p2, p3);

                richTextBoxCalculate.Text = string.Format("Aria: {0}\nPerimetrul: {1}\nCentru inscris:  X: {2}, Y: {3} \nCentru circumscris:  X: {4}, Y: {5}", arie, perimetru, centruInscris.X, centruInscris.Y, centruCircumscris.X, centruCircumscris.Y);


            }
            catch (Exception ex)
            {
                MesajEroare(ex);
                return;
            }
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
                MesajEroare(ex);
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

            if(nOfPoints == 3)
            {
                if (checkBoxCercInscris.Checked)
                    DesenareCercInscris(e.Graphics, p1, p2, p3);
                if (checkBoxCercCircumscris.Checked)
                    DesenareCerCircumscris(e.Graphics, p1, p2, p3);
            }
        }


        //////    FUNCTII PENTRU CALCULE ASUPRA TRIUNGHIULUI    ////////////////////////////////////////////////////////////////////////


        /// <summary>
        /// Calculează distanța dintre două puncte în plan.
        /// Aruncă excepție dacă punctele sunt identice.
        /// </summary>
        /// <param name="p1">Primul punct</param>
        /// <param name="p2">Al doilea punct</param>
        /// <returns>Distanța dintre p1 și p2</returns>
        /// <exception cref="ArgumentException">Dacă p1 și p2 sunt identice</exception>
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
                return Math.Sqrt(difX + difY);
            }
        }

        /// <summary>
        /// Calculează perimetrul triunghiului definit de cele trei puncte date.
        /// </summary>
        /// <param name="p1">Primul vârf al triunghiului.</param>
        /// <param name="p2">Al doilea vârf al triunghiului.</param>
        /// <param name="p3">Al treilea vârf al triunghiului.</param>
        /// <returns>Suma lungimilor laturilor triunghiului.</returns>
        private double CalculeazaPerimetru(Point p1, Point p2, Point p3)
        {

            double l1 = CalculeazaDistanta(p1, p2);
            double l2 = CalculeazaDistanta(p2, p3);
            double l3 = CalculeazaDistanta(p3, p1);

            return l1 + l2 + l3;
        }

        /// <summary>
        /// Calculează aria triunghiului definit de cele trei puncte date folosind formula lui Heron.
        /// </summary>
        /// <param name="p1">Primul vârf al triunghiului.</param>
        /// <param name="p2">Al doilea vârf al triunghiului.</param>
        /// <param name="p3">Al treilea vârf al triunghiului.</param>
        /// <returns>Aria triunghiului.</returns>
        private double Arie(Point p1, Point p2, Point p3)
        {
            double l1 = CalculeazaDistanta(p1, p2);
            double l2 = CalculeazaDistanta(p2, p3);
            double l3 = CalculeazaDistanta(p3, p1);

            double p = (l1 + l2 + l3) / 2;

            return Math.Sqrt(p * (p - l1) * (p - l2) * (p - l3));
        }

        /// <summary>
        /// Calculează centrul de greutate al triunghiului definit de cele trei puncte
        /// </summary>
        /// <param name="p1">Primul vârf al triunghiului</param>
        /// <param name="p2">Al doilea vârf al triunghiului</param>
        /// <param name="p3">Al treilea vârf al triunghiului</param>
        /// <returns>Coordonatele centrului de greutate al triunghiului</returns>
        private PointF CentruDeGreutate(Point p1, Point p2, Point p3)
        {
            float x = (p1.X + p2.X + p3.X) / 3.0f;
            float y = (p1.Y + p2.Y + p3.Y) / 3.0f;

            return new PointF(x, y);
        }

        /// <summary>
        /// Calculează centrul cercului înscris în triunghiul definit de cele trei puncte
        /// </summary>
        /// <param name="p1">Primul vârf al triunghiului</param>
        /// <param name="p2">Al doilea vârf al triunghiului</param>
        /// <param name="p3">Al treilea vârf al triunghiului</param>
        /// <returns>Coordonatele centrului cercului înscris</returns>
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

        /// <summary>
        /// Calculează raza cercului înscris în triunghiul definit de cele trei puncte
        /// </summary>
        /// <param name="p1">Primul vârf al triunghiului</param>
        /// <param name="p2">Al doilea vârf al triunghiului</param>
        /// <param name="p3">Al treilea vârf al triunghiului</param>
        /// <returns>Raza cercului înscris</returns>
        private double RazaCercInscris(Point p1, Point p2, Point p3)
        {
            double arie = Arie(p1, p2, p3);
            double s = CalculeazaPerimetru(p1, p2, p3) / 2;

            return arie / s;

        }

        /// <summary>
        /// Calculează centrul cercului circumscris triunghiului definit de cele trei puncte
        /// </summary>
        /// <param name="p1">Primul vârf al triunghiului</param>
        /// <param name="p2">Al doilea vârf al triunghiului</param>
        /// <param name="p3">Al treilea vârf al triunghiului</param>
        /// <returns>Punctul cu coordonatele centrului cercului circumscris</returns>
        private PointF CentruCercCircumscris(Point p1, Point p2, Point p3)
        {
            // coordonatele celor 3 puncte
            float x1 = p1.X, y1 = p1.Y;
            float x2 = p2.X, y2 = p2.Y;
            float x3 = p3.X, y3 = p3.Y;

            // calculam determinantul sistemului dat de ecuatiile celor 3 mediatoare
            float d = 2 * (x1 * (y2 - y3) + x2 * (y3 - y1) + x3 * (y1 - y2));

            // coordonata X a punctului de intersectie
            float ux = ((x1 * x1 + y1 * y1) * (y2 - y3) + 
                (x2 * x2 + y2 * y2) * (y3 - y1) +
                (x3 * x3 + y3 * y3) * (y1 - y2)) / d;

            // coordonata Y a punctului de intersectie
            float uy = ((x1 * x1 + y1 * y1) * (x3 - x2) +
                (x2 * x2 + y2 * y2) * (x1 - x3) +
                (x3 * x3 + y3 * y3) * (x2 - x1)) / d;

            return new PointF(ux, uy);
        }

        /// <summary>
        /// Calculează raza cercului circumscris triunghiului definit de cele trei puncte
        /// </summary>
        /// <param name="p1">Primul vârf al triunghiului</param>
        /// <param name="p2">Al doilea vârf al triunghiului</param>
        /// <param name="p3">Al treilea vârf al triunghiului</param>
        /// <returns>Raza cercului circumscris</returns>
        /// <exception cref="ArgumentException">Punctele sunt coliniare, deci cercul circumscris nu există.</exception>
        private double RazaCercCircumscris(Point p1, Point p2, Point p3)
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

        /// <summary>
        /// Calculează punctul de intersecție dintre două drepte definite de două perechi de puncte.
        /// </summary>
        /// <param name="p1">Primul punct pe prima dreaptă.</param>
        /// <param name="p2">Al doilea punct pe prima dreaptă.</param>
        /// <param name="p3">Primul punct pe a doua dreaptă.</param>
        /// <param name="p4">Al doilea punct pe a doua dreaptă.</param>
        /// <returns>Punctul de intersecție al celor două drepte</returns>
        /// <exception cref="ArgumentException">Dacă dreptele sunt paralele și nu se intersectează</exception>
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


        /// <summary>
        /// Desenează triunghiul format de cele trei puncte p1, p2 și p3
        /// Desenează medianele, bisectoarele și înălțimile triunghiului dacă sunt bifate opțiunile corespunzătoare
        /// </summary>
        /// <param name="g">Obiectul Graphics pe care se face desenul.</param>
        /// <exception cref="Exception">Aruncă excepția cu un mesaj specific în cazul unei erori.</exception>
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
                    if(checkBoxMediatoare.Checked)
                    {
                        DesenareMediatoare(g, p1, p2, p3);
                    }
                }
                else
                {
                    g.Clear(Color.White);
                }
            }
            catch(Exception e)
            {
                MesajEroare(e);
            }
        }

        /// <summary>
        /// Desenează cercul înscris în triunghiul definit de punctele p1, p2 și p3, cu culoarea BlueViolet
        /// </summary>
        /// <param name="g">Obiectul Graphics pe care se face desenul.</param>
        /// <param name="p1">Primul punct al triunghiului.</param>
        /// <param name="p2">Al doilea punct al triunghiului.</param>
        /// <param name="p3">Al treilea punct al triunghiului.</param>
        private void DesenareCercInscris(Graphics g, Point p1, Point p2, Point p3)
        {
            PointF centru = GetCentruCercInscris(p1, p2, p3);
            float raza = (float)GetRazaCercInscris(p1, p2, p3);
            float diametru = 2 * raza;
            float x = centru.X - raza;
            float y = centru.Y - raza;
            g.DrawEllipse(Pens.DarkBlue, x, y, diametru, diametru);
        }

        /// <summary>
        /// Desenează cercul circumscris triunghiului definit de punctele p1, p2 și p3, cu culoarea roșie
        /// </summary>
        /// <param name="g">Obiectul Graphics pe care se face desenul.</param>
        /// <param name="p1">Primul punct al triunghiului.</param>
        /// <param name="p2">Al doilea punct al triunghiului.</param>
        /// <param name="p3">Al treilea punct al triunghiului.</param>
        private void DesenareCerCircumscris(Graphics g, Point p1, Point p2, Point p3)
        {
            PointF centru = GetCentruCercCircumscris(p1, p2, p3);
            float raza = (float)GetRazaCercCircumscris(p1, p2, p3);
            float diametru = 2 * raza;
            float x = centru.X - raza;
            float y = centru.Y - raza;
            g.DrawEllipse(Pens.Red, x, y, diametru, diametru);
        }

        /// <summary>
        /// Desenează bisectoarele triunghiului format din punctele p1, p2 și p3
        /// </summary>
        /// <param name="g">Obiectul Graphics pe care se face desenarea.</param>
        /// <param name="p1">Primul vârf al triunghiului.</param>
        /// <param name="p2">Al doilea vârf al triunghiului.</param>
        /// <param name="p3">Al treilea vârf al triunghiului.</param>
        private void DesenareBisectoare(Graphics g, Point p1, Point p2, Point p3)
        {
            PointF centruInscris = CentruCercInscris(p1, p2, p3);

            PointF i1 = GetIntersectie(p1, centruInscris, p2, p3);
            PointF i2 = GetIntersectie(p2, centruInscris, p1, p3);
            PointF i3 = GetIntersectie(p3, centruInscris, p1, p2);

            Pen p = new Pen(Color.DarkBlue, 1);
            g.DrawLine(p, p1, i1);
            g.DrawLine(p, p2, i2);
            g.DrawLine(p, p3, i3);

            //desenare centru
            int diametru = 10;
            g.FillEllipse(Brushes.DarkBlue, centruInscris.X - diametru / 2, centruInscris.Y - diametru / 2, diametru, diametru);

        }

        /// <summary>
        /// Eveniment care se declanșează când se schimbă starea checkbox-ului pentru afișarea bisectoarelor
        /// </summary>
        /// <param name="sender">Obiectul care a generat evenimentul</param>
        /// <param name="e">Datele evenimentului</param>
        private void checkBoxBisectoare_CheckedChanged(object sender, EventArgs e)
        {
            pictureBox1.Invalidate();
            Notify();
        }

        /// <summary>
        /// Eveniment care se declanșează când se schimbă starea checkbox-ului pentru afișarea medianelor
        /// </summary>
        /// <param name="sender">Obiectul care a generat evenimentul</param>
        /// <param name="e">Datele evenimentului</param>
        private void checkBoxMediane_CheckedChanged(object sender, EventArgs e)
        {
            pictureBox1.Invalidate();
            Notify();
        }

        /// <summary>
        /// Eveniment care se declanșează când se schimbă starea checkbox-ului pentru afișarea înălțimilor
        /// </summary>
        /// <param name="sender">Obiectul care a generat evenimentul</param>
        /// <param name="e">Datele evenimentului</param>
        private void checkBoxInaltimi_CheckedChanged(object sender, EventArgs e)
        {
            pictureBox1.Invalidate();
            Notify();
        }

        /// <summary>
        /// Eveniment care se declanșează când se schimbă starea checkbox-ului pentru afișarea cercului înscris
        /// </summary>
        /// <param name="sender">Obiectul care a generat evenimentul</param>
        /// <param name="e">Datele evenimentului</param>
        private void checkBoxCercInscris_CheckedChanged(object sender, EventArgs e)
        {
            pictureBox1.Invalidate();
            Notify();
        }

        /// <summary>
        /// Eveniment care se declanșează când se schimbă starea checkbox-ului pentru afișarea cercului circumscris
        /// </summary>
        /// <param name="sender">Obiectul care a generat evenimentul</param>
        /// <param name="e">Datele evenimentului</param>
        private void checkBoxCercCircumscris_CheckedChanged(object sender, EventArgs e)
        {
            pictureBox1.Invalidate();
            Notify();
        }

        private void checkBoxMediatoare_CheckedChanged(object sender, EventArgs e)
        {
            pictureBox1.Invalidate();
            Notify();
        }

        /// <summary>
        /// Resetează toate punctele și variabilele legate de triunghi la valorile inițiale
        /// </summary>
        /// <param name="sender">Obiectul care a declanșat evenimentul</param>
        /// <param name="e">Datele evenimentului.</param>
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

        /// <summary>
        /// Desenează medianele triunghiului definit de punctele p1, p2 și p3.
        /// </summary>
        /// <param name="g">Obiectul Graphics pe care se face desenarea.</param>
        /// <param name="p1">Primul vârf al triunghiului.</param>
        /// <param name="p2">Al doilea vârf al triunghiului.</param>
        /// <param name="p3">Al treilea vârf al triunghiului.</param>
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

        /// <summary>
        /// Desenează înălțimile triunghiului format de punctele p1, p2 și p3,
        /// </summary>
        /// <param name="g">Obiectul Graphics pe care se face desenarea.</param>
        /// <param name="p1">Primul vârf al triunghiului.</param>
        /// <param name="p2">Al doilea vârf al triunghiului.</param>
        /// <param name="p3">Al treilea vârf al triunghiului.</param>
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

            // desenam prelungirile laturilor in cazul incare triunghiul contine un unghi obtuz
            DesenarePrelungireLatura(g, p1, p2);
            DesenarePrelungireLatura(g, p2, p3);
            DesenarePrelungireLatura(g, p1, p3);

            // desenam inaltimile
            g.DrawLine(p, ortocentru, new Point((int)H1.X, (int)H1.Y));
            g.DrawLine(p, ortocentru, new Point((int)H2.X, (int)H2.Y));
            g.DrawLine(p, ortocentru, new Point((int)H3.X, (int)H3.Y));

            int diametru = 10;
            g.FillEllipse(Brushes.DarkGreen, ortocentru.X - diametru / 2, ortocentru.Y - diametru / 2, diametru, diametru);
        }

        private void DesenarePrelungireLatura(Graphics g, Point p1, Point p2)
        {
            const float extensie = 100;

            //calculam directia
            float dx = p2.X - p1.X;
            float dy = p2.Y - p1.Y;

            double lungime = CalculeazaDistanta(p1, p2);

            //normalizam vectorul directie
            dx /= (float)lungime;
            dy /= (float)lungime;

            //prelungim linia in ambele directii
            PointF pStart = new PointF(p1.X - dx * extensie, p1.Y - dy * extensie);
            PointF pEnd = new PointF(p2.X + dx * extensie, p2.Y + dy * extensie);

            using (Pen penPunctat = new Pen(Color.Gray, 1))
            {
                penPunctat.DashStyle = DashStyle.Dot;
                g.DrawLine(penPunctat, pStart, pEnd);
            }
        }

        private void DesenarePrelungireMediatoare(Graphics g, Point p1, Point p2)
        {
            //calculam mijlocul laturei formata de punctele p1 si p2
            PointF mijloc = new PointF((p1.X + p2.X) / 2f, (p1.Y + p2.Y) / 2f);

            //calculam vectorul directiei dintre cele doua puncte
            float dx = p2.X - p1.X;
            float dy = p2.Y - p1.Y;

            //calculam distanta dintre cele doua puncte
            double lungime = GetDistanta(p1, p2);

            //normalizam vectorul perpendicular
            float nx = -dy / (float)lungime;
            float ny = dx / (float)lungime;

            //extindem linia mediatoarei
            float extensie = 50;
            PointF pStart = new PointF(mijloc.X - nx * extensie, mijloc.Y - ny * extensie);
            PointF pEnd = new PointF(mijloc.X + nx * extensie, mijloc.Y + ny * extensie);

            using (Pen penPunctat = new Pen(Color.Gray, 1))
            {
                penPunctat.DashStyle = DashStyle.Dot;
                g.DrawLine(penPunctat, pStart, pEnd);
            }
        }

        private void DesenareMediatoareLatura(Graphics g, Point p1, Point p2, PointF centru)
        {
            // Calculăm mijlocul laturii formate de p1 și p2
            PointF mijloc = new PointF((p1.X + p2.X) / 2f, (p1.Y + p2.Y) / 2f);

            // Desenăm linia dintre mijloc și centrul cercului circumscris
            Pen p = new Pen(Color.Red, 1);
            g.DrawLine(p, mijloc, centru);
        }

        private void DesenareMediatoare(Graphics g, Point p1, Point p2, Point p3)
        {
            PointF centru = CentruCercCircumscris(p1, p2, p3);

            DesenarePrelungireMediatoare(g, p1, p2);
            DesenarePrelungireMediatoare(g, p2, p3);
            DesenarePrelungireMediatoare(g, p1, p3);

            DesenareMediatoareLatura(g, p1, p2, centru);
            DesenareMediatoareLatura(g, p2, p3, centru);
            DesenareMediatoareLatura(g, p1, p3, centru);

            // Desenăm centrul cercului circumscris ca un punct
            int diametru = 10;
            g.FillEllipse(Brushes.Red, centru.X - diametru / 2, centru.Y - diametru / 2, diametru, diametru);
        }

        private void MesajEroare(Exception e, [CallerMemberName] string functie = "")
        {
            string mesaj = $"A apărut o eroare în execuția programului.";

            // informatii detaliate pentru debug
            mesaj += $"\n\nMesaj: {e.Message}";
            mesaj += $"\nTip: {e.GetType().Name}";
            mesaj += $"\nFuncție: {functie}";

            MessageBox.Show(mesaj, "Eroare critică", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

    }
}