using System;
using System.Drawing;
using System.Drawing.Drawing2D;


namespace Proiect.Utils
{
    public static class Desenator
    {
        /// <summary>
        /// Desenează triunghiul format de cele trei puncte p1, p2 și p3
        /// Desenează medianele, bisectoarele și înălțimile triunghiului dacă sunt bifate opțiunile corespunzătoare
        /// </summary>
        /// <param name="g">Obiectul Graphics pe care se face desenul.</param>
        /// <exception cref="Exception">Aruncă excepția cu un mesaj specific în cazul unei erori.</exception>
        public static void DesenareTriunghi(
            Graphics g,
            int nOfPoints,
            Point p1,
            Point p2,
            Point p3,
            bool deseneazaMediane,
            bool deseneazaBisectoare,
            bool deseneazaInaltimi,
            bool deseneazaMediatoare)
        {
            try
            {
                if (nOfPoints >= 3)
                {
                    Pen pen = new Pen(Color.Black, 3);
                    g.DrawLine(pen, p1, p2);
                    g.DrawLine(pen, p2, p3);
                    g.DrawLine(pen, p3, p1);

                    if (deseneazaMediane)
                    {
                        DesenareMediana(g, p1, p2, p3);
                    }
                    if (deseneazaBisectoare)
                    {
                        DesenareBisectoare(g, p1, p2, p3);
                    }
                    if (deseneazaInaltimi)
                    {
                        DesenareInaltime(g, p1, p2, p3);
                    }
                    if (deseneazaMediatoare)
                    {
                        DesenareMediatoare(g, p1, p2, p3);
                    }
                }
                else
                {
                    g.Clear(Color.White);
                }
            }
            catch (Exception e)
            {
                ErrorHandler.MesajEroare(e);
            }
        }

        /// <summary>
        /// Desenează cercul înscris în triunghiul definit de punctele p1, p2 și p3, cu culoarea BlueViolet
        /// </summary>
        /// <param name="g">Obiectul Graphics pe care se face desenul.</param>
        /// <param name="p1">Primul punct al triunghiului.</param>
        /// <param name="p2">Al doilea punct al triunghiului.</param>
        /// <param name="p3">Al treilea punct al triunghiului.</param>
        public static void DesenareCercInscris(Graphics g, Point p1, Point p2, Point p3)
        {
            PointF centru = Geometrie.GetCentruCercInscris(p1, p2, p3);
            float raza = (float)Geometrie.GetRazaCercInscris(p1, p2, p3);
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
        public static void DesenareCerCircumscris(Graphics g, Point p1, Point p2, Point p3)
        {
            PointF centru = Geometrie.GetCentruCercCircumscris(p1, p2, p3);
            float raza = (float)Geometrie.GetRazaCercCircumscris(p1, p2, p3);
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
        public static void DesenareBisectoare(Graphics g, Point p1, Point p2, Point p3)
        {
            PointF centruInscris = Geometrie.GetCentruCercInscris(p1, p2, p3);

            PointF i1 = Geometrie.GetIntersectie(p1, centruInscris, p2, p3);
            PointF i2 = Geometrie.GetIntersectie(p2, centruInscris, p1, p3);
            PointF i3 = Geometrie.GetIntersectie(p3, centruInscris, p1, p2);

            Pen p = new Pen(Color.DarkBlue, 1);
            g.DrawLine(p, p1, i1);
            g.DrawLine(p, p2, i2);
            g.DrawLine(p, p3, i3);

            //desenare centru
            int diametru = 10;
            g.FillEllipse(Brushes.DarkBlue, centruInscris.X - diametru / 2, centruInscris.Y - diametru / 2, diametru, diametru);

        }

        private static void DesenareMediana(Graphics g, Point p1, Point p2, Point p3)
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
            PointF centruGreutate = Geometrie.GetCentruDeGreutate(p1, p2, p3);

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
        private static void DesenareInaltime(Graphics g, Point p1, Point p2, Point p3)
        {
            PointF H1 = Geometrie.GetPerpendicularaDinPunctPeDreapta(p1, p2, p3);
            PointF H2 = Geometrie.GetPerpendicularaDinPunctPeDreapta(p2, p1, p3);
            PointF H3 = Geometrie.GetPerpendicularaDinPunctPeDreapta(p3, p1, p2);

            Pen p = new Pen(Color.Green, 1);
            g.DrawLine(p, p1, new Point((int)H1.X, (int)H1.Y));
            g.DrawLine(p, p2, new Point((int)H2.X, (int)H2.Y));
            g.DrawLine(p, p3, new Point((int)H3.X, (int)H3.Y));

            PointF ortocentru = Geometrie.GetIntersectie(p1, H1, p2, Point.Round(H2));

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

        private static void DesenarePrelungireLatura(Graphics g, Point p1, Point p2)
        {
            const float extensie = 100;

            //calculam directia
            float dx = p2.X - p1.X;
            float dy = p2.Y - p1.Y;

            double lungime = Geometrie.GetDistanta(p1, p2);

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

        private static void DesenarePrelungireMediatoare(Graphics g, Point p1, Point p2)
        {
            //calculam mijlocul laturei formata de punctele p1 si p2
            PointF mijloc = new PointF((p1.X + p2.X) / 2f, (p1.Y + p2.Y) / 2f);

            //calculam vectorul directiei dintre cele doua puncte
            float dx = p2.X - p1.X;
            float dy = p2.Y - p1.Y;

            //calculam distanta dintre cele doua puncte
            double lungime = Geometrie.GetDistanta(p1, p2);

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

        private static void DesenareMediatoareLatura(Graphics g, Point p1, Point p2, PointF centru)
        {
            // Calculăm mijlocul laturii formate de p1 și p2
            PointF mijloc = new PointF((p1.X + p2.X) / 2f, (p1.Y + p2.Y) / 2f);

            // Desenăm linia dintre mijloc și centrul cercului circumscris
            Pen p = new Pen(Color.Red, 1);
            g.DrawLine(p, mijloc, centru);
        }

        private static void DesenareMediatoare(Graphics g, Point p1, Point p2, Point p3)
        {
            PointF centru = Geometrie.GetCentruCercCircumscris(p1, p2, p3);

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
    }
}
