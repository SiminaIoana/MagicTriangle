/**************************************************************************
 *                                                                        *
 *  File:        Geometrie.cs                                             *
 *  Copyright:   (c) 2025, Simina Rusu, Codrina Tăbușcă, Tudor Rotariu,   *
 *               Vasile Leșan                                             *
 *  E-mail:      simina-ioana.rusu@student.tuiasi.ro,                     *
 *               codrina-florentina.tabusca@student.tuiasi.ro,            *
 *               tudor-liviu.rotariu@student.tuiasi.ro                    *
 *               vasile.lesan@student.tuiasi.ro                           *
 *  Description: Utility class providing geometric calculations and       *
 *               accessors for areas, perimeters, lines etc.              *
 *                                                                        *
 *  This program is free software; you can redistribute it and/or modify  *
 *  it under the terms of the GNU General Public License as published by  *
 *  the Free Software Foundation. This program is distributed in the      *
 *  hope that it will be useful, but WITHOUT ANY WARRANTY; without even   *
 *  the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR   *
 *  PURPOSE. See the GNU General Public License for more details.         *
 *                                                                        *
 **************************************************************************/


using System;
using System.Drawing;

namespace Proiect
{
    public static class Geometrie
    {
        /// <summary>
        /// Returnează aria triunghiului definit de cele trei puncte date.
        /// </summary>
        /// /// <param name="p1">Primul punct al triunghiului.</param>
        /// <param name="p2">Al doilea punct al triunghiului.</param>
        /// <param name="p3">Al treilea punct al triunghiului.</param>
        /// <returns>Aria triunghiului.</returns>
        public static double GetArie(Point p1, Point p2, Point p3)
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
        public static double GetPerimetru(Point p1, Point p2, Point p3)
        {
            return CalculeazaPerimetru(p1, p2, p3);
        }

        /// <summary>
        /// Returnează distanța dintre cele două puncte date.
        /// </summary>
        /// <param name="p1">Primul punct.</param>
        /// <param name="p2">Al doilea punct.</param>
        /// <returns>Distanța dintre p1 și p2.</returns>
        public static double GetDistanta(Point p1, Point p2)
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
        public static PointF GetCentruDeGreutate(Point p1, Point p2, Point p3)
        {
            return CentruDeGreutate(p1, p2, p3);
        }

        /// <summary>
        /// Returnează centrul cercului înscris în triunghiul definit de cele trei puncte.
        /// </summary>
        /// <param name="p1">Primul vârf al triunghiului.</param>
        /// <param name="p2">Al doilea vârf al triunghiului.</param>
        /// <param name="p3">Al treilea vârf al triunghiului.</param>
        /// <returns>Punctul care reprezintă centrul cercului înscris.</returns>
        public static PointF GetCentruCercInscris(Point p1, Point p2, Point p3)
        {
            return CentruCercInscris(p1, p2, p3);
        }


        /// <summary>
        /// Returnează raza cercului înscris în triunghiul format de cele trei puncte date.
        /// </summary>
        /// <param name="p1">Primul vârf al triunghiului.</param>
        /// <param name="p2">Al doilea vârf al triunghiului.</param>
        /// <param name="p3">Al treilea vârf al triunghiului.</param>
        /// <returns>Raza cercului înscris.</returns>
        public static double GetRazaCercInscris(Point p1, Point p2, Point p3)
        {
            return RazaCercInscris(p1, p2, p3);
        }


        /// <summary>
        /// Returnează centrul cercului circumscris triunghiului definit de cele trei puncte date.
        /// </summary>
        /// <param name="p1">Primul vârf al triunghiului.</param>
        /// <param name="p2">Al doilea vârf al triunghiului.</param>
        /// <param name="p3">Al treilea vârf al triunghiului.</param>
        /// <returns>Punctul ce reprezintă centrul cercului circumscris.</returns>
        public static PointF GetCentruCercCircumscris(Point p1, Point p2, Point p3)
        {
            return CentruCercCircumscris(p1, p2, p3);
        }


        /// <summary>
        /// Returnează raza cercului circumscris triunghiului definit de cele trei puncte date.
        /// </summary>
        /// <param name="p1">Primul vârf al triunghiului.</param>
        /// <param name="p2">Al doilea vârf al triunghiului.</param>
        /// <param name="p3">Al treilea vârf al triunghiului.</param>
        /// <returns>Raza cercului circumscris.</returns>
        public static double GetRazaCercCircumscris(Point p1, Point p2, Point p3)
        {
            return RazaCercCircumscris(p1, p2, p3);
        }


        /// <summary>
        /// Calculează punctul de intersecție al celor două drepte definite de punctele (p1, p2) și (p3, p4).
        /// </summary>
        /// <param name="p1">Primul punct al primei drepte.</param>
        /// <param name="p2">Al doilea punct al primei drepte (tip PointF pentru precizie zecimală).</param>
        /// <param name="p3">Primul punct al celei de-a doua drepte.</param>
        /// <param name="p4">Al doilea punct al celei de-a doua drepte.</param>
        /// <returns>Punctul de intersecție ca un obiect PointF.</returns>
        public static PointF GetIntersectie(Point p1, PointF p2, Point p3, Point p4)
        {
            return CalculeazaIntersectie(p1, p2, p3, p4);
        }


        /// <summary>
        /// Calculează distanța dintre două puncte în plan.
        /// Aruncă excepție dacă punctele sunt identice.
        /// </summary>
        /// <param name="p1">Primul punct</param>
        /// <param name="p2">Al doilea punct</param>
        /// <returns>Distanța dintre p1 și p2</returns>
        /// <exception cref="ArgumentException">Dacă p1 și p2 sunt identice</exception>
        private static double CalculeazaDistanta(Point p1, Point p2)
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
        private static double CalculeazaPerimetru(Point p1, Point p2, Point p3)
        {

            double l1 = CalculeazaDistanta(p1, p2);
            double l2 = CalculeazaDistanta(p2, p3);
            double l3 = CalculeazaDistanta(p3, p1);

            return Math.Round((l1 + l2 + l3),3);
        }


        /// <summary>
        /// Calculează aria triunghiului definit de cele trei puncte date folosind formula lui Heron.
        /// </summary>
        /// <param name="p1">Primul vârf al triunghiului.</param>
        /// <param name="p2">Al doilea vârf al triunghiului.</param>
        /// <param name="p3">Al treilea vârf al triunghiului.</param>
        /// <returns>Aria triunghiului.</returns>
        private static double Arie(Point p1, Point p2, Point p3)
        {
            double l1 = CalculeazaDistanta(p1, p2);
            double l2 = CalculeazaDistanta(p2, p3);
            double l3 = CalculeazaDistanta(p3, p1);

            double p = (l1 + l2 + l3) / 2;

            return Math.Round(Math.Sqrt(p * (p - l1) * (p - l2) * (p - l3)),3);
        }


        /// <summary>
        /// Calculează centrul de greutate al triunghiului definit de cele trei puncte
        /// </summary>
        /// <param name="p1">Primul vârf al triunghiului</param>
        /// <param name="p2">Al doilea vârf al triunghiului</param>
        /// <param name="p3">Al treilea vârf al triunghiului</param>
        /// <returns>Coordonatele centrului de greutate al triunghiului</returns>
        private static PointF CentruDeGreutate(Point p1, Point p2, Point p3)
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
        private static PointF CentruCercInscris(Point p1, Point p2, Point p3)
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
        private static double RazaCercInscris(Point p1, Point p2, Point p3)
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
        private static PointF CentruCercCircumscris(Point p1, Point p2, Point p3)
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
        private static double RazaCercCircumscris(Point p1, Point p2, Point p3)
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
        /// <param name="p">Punctul din care se coboară perpendiculara.</param>
        /// <param name="startL">Punctul de start al dreptei.</param>
        /// <param name="endL">Punctul de sfârșit al dreptei.</param>
        /// <returns>Punctul de pe dreaptă unde cade perpendiculara din p.</returns>
        public static PointF GetPerpendicularaDinPunctPeDreapta(Point p, Point startL, Point endL)
        {
            return PerpendicularaPunctDreapta(p, startL, endL);
        }


        /// <summary>
        /// Functie ce va calcula punctul de intersectie dintre o dreapta si perpendiculara dusa dintr-un punct pe acea dreapta
        /// </summary>
        /// <param name="punct"></param>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <returns></returns>
        private static PointF PerpendicularaPunctDreapta(Point p, Point startL, Point endL)
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
        private static PointF CalculeazaIntersectie(Point p1, PointF p2, Point p3, Point p4)
        {
            //coeficienti pante
            float a1 = p2.Y - p1.Y;
            float b1 = p1.X - p2.X;
            float c1 = a1 * p1.X + b1 * p1.Y;

            float a2 = p4.Y - p3.Y;
            float b2 = p3.X - p4.X;
            float c2 = a2 * p3.X + b2 * p3.Y;

            float determinant = a1 * b2 - a2 * b1;

            if (determinant == 0)
            {
                throw new ArgumentException("Liniile nu se intersecteaza!");
            }

            float x = (b2 * c1 - b1 * c2) / determinant;
            float y = (a1 * c2 - a2 * c1) / determinant;


            return new PointF(x, y);
        }
    }
}
