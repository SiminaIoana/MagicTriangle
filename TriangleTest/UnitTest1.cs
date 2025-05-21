using System;
using System.Drawing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Proiect;


namespace TriangleTest
{
    [TestClass]
    public class UnitTest1
    {
        private Form1 form;
        [ TestInitialize]
        public void Setup()
        {
            form = new Form1();
        }

        /// <summary>
        /// Testare daca numarul de puncte e 0
        /// </summary>

        [TestMethod]
        public void TestGetNumberOfPoints()
        {
            Assert.AreEqual(0, form.GetNrOfPoints());
        }

        /// <summary>
        /// Testara pentru a afla daca punctele sunt goale
        /// </summary>
        [TestMethod]
        public void TestGetP1()
        {
            Assert.AreEqual(Point.Empty, form.GetP1());
        }

        [TestMethod]
        public void TestGetP2()
        {
            Assert.AreEqual(Point.Empty, form.GetP2());
        }

        [TestMethod]
        public void TestGetP3()
        {
            Assert.AreEqual(Point.Empty, form.GetP3());
        }

        /// <summary>
        /// Testare pentru a afla daca punctele au valoarea 0
        /// </summary>
        /// 

        [TestMethod]
        public void TestGetV1()
        {
            Assert.AreEqual(0, form.GetV1());
        }

        [TestMethod]
        public void TestGetV2()
        {
            Assert.AreEqual(0, form.GetV2());
        }

        [TestMethod]
        public void TestGetV3()
        {
            Assert.AreEqual(0, form.GetV3());
        }


        /// <summary>
        /// Testare distanta intre 2 puncte
        /// </summary>
        [TestMethod]
        public void TestDistanta()
        {
            var a = new Point(0, 0);
            var b = new Point(3, 4);
            double expected = 5.0;

            double result = Geometrie.GetDistanta(a, b);

            Assert.AreEqual(expected, result, 0.001);


        }

        /// <summary>
        /// Testare exceptie pentru distanta dintre 2 puncte identice
        /// </summary>
        [TestMethod]
        public void TestDistanta_SamePoint()
        {
            var a = new Point(2, 2);

            var ex = Assert.ThrowsException<ArgumentException>(() =>
            {
                Geometrie.GetDistanta(a, a);
            });
            Assert.AreEqual("Aceste puncte sunt identice", ex.Message);
            
        }


        /// <summary>
        /// Testare calcul arie pentru triunghi dreptunghic
        /// </summary>
        [TestMethod]
        public void TestArie_TringhiDreptunghic()
        {
            var a = new Point(0, 0);
            var b = new Point(4, 0);
            var c = new Point(0, 3);

            double result = Geometrie.GetArie(a, b, c);

            Assert.AreEqual(6.0, result, 0.001);

        }

        /// <summary>
        /// Testare calcul perimetru pentru triunghi 
        /// </summary>
        [TestMethod]
        public void TestPerimetru()
        {
            var a = new Point(0, 0);
            var b = new Point(3, 0);
            var c = new Point(0, 4);

            double result = Geometrie.GetPerimetru(a, b, c);

            double expected = 3 + 4 + 5;

            Assert.AreEqual(expected, result, 0.001);
        }


        /// <summary>
        /// Testam daca se arunca exceptia in cazul in care 2 laturi sunt coliniare
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestRazaCercCircumscrisExceptie()
        {
            Point p1 = new Point(0, 0);
            Point p2 = new Point(1, 1);
            Point p3 = new Point(2, 2);

            double raza = Geometrie.GetRazaCercCircumscris(p1, p2, p3);

        }

        /// <summary>
        /// Testam daca se arunca exceptia in cazul in care 2 laturi sunt paralele
        /// </summary>

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]

        public void TestCalculeazaIntersectiaExceptia()
        {
            Point p1 = new Point(0, 0);
            PointF p2 = new PointF(1, 1);

            Point p3 = new Point(0, 1);
            Point p4 = new Point(1, 2);

            PointF intersectie = Geometrie.GetIntersectie(p1, p2, p3, p4);

        }


        /// <summary>
        /// Testare calcul centru de greutate
        /// </summary>
        [TestMethod]
        public void TestCentruGreutate()
        {
            Point p1 = new Point(0, 0);
            Point p2 = new Point(6, 0);
            Point p3 = new Point(0, 6);
            PointF centru = Geometrie.GetCentruDeGreutate(p1, p2, p3);

            Assert.AreEqual(2, centru.X, 0.0001);
            Assert.AreEqual(2, centru.Y, 0.0001);

        }


        /// <summary>
        /// Testare calcul raza cerc circumscris pentru triunghi
        /// </summary>
        [TestMethod]
        public void TestRazaCercCircumscris()
        {
            Point p1 = new Point(0, 0);
            Point p2 = new Point(0, 2);
            Point p3 = new Point(2, 0);
            double raza = Geometrie.GetRazaCercCircumscris(p1, p2, p3);
            Assert.AreEqual(1.4142, raza, 0.0001);
        }


        /// <summary>
        /// Testare calcul pentru coordonatele punctului de intersectie al doua drepte
        /// </summary>
        [TestMethod]
        public void TestCalculeazaIntersectie()
        {
            Point p1 = new Point(0, 0);
            PointF p2 = new PointF(2, 2);
            Point p3 = new Point(0, 2);
            Point p4 = new Point(2, 0);

            PointF intersectie = Geometrie.GetIntersectie(p1, p2, p3, p4);
            Assert.AreEqual(1, intersectie.X, 0.001);
            Assert.AreEqual(1, intersectie.Y, 0.001);
        }

        /// <summary>
        /// Testare calcul proiectie perpendiculara dintr-un punct pe o dreapta (punctul unde se va afla perpendiculara )
        /// </summary>
        [TestMethod]
        public void TestPerpendicularaPunctDreapta()
        {
            Point p = new Point(2, 3);

            Point startL = new Point(0, 0);
            Point endL = new Point(4, 0);

            PointF rezultat = Geometrie.GetPerpendicularaDinPunctPeDreapta(p, startL, endL);

            Assert.AreEqual(2f, rezultat.X, 0.001);
            Assert.AreEqual(0f, rezultat.Y, 0.001);
        }

        /// <summary>
        /// Testare calcul raza cerc inscris in triunghi
        /// </summary>
        [TestMethod]
        public void TestRazaCercInscris()
        {
            Point p1 = new Point(0, 0);
            Point p2 = new Point(4, 0);
            Point p3 = new Point(0, 3);

            double rezultat = Geometrie.GetRazaCercInscris(p1, p2, p3);

            Assert.AreEqual(1.0, rezultat, 0.001);
        }

        /// <summary>
        /// Testare calcul coordonate centru cern circumscris in triunghi
        /// </summary>

        [TestMethod]
        public void TestCentruCercCircumscris()
        {
            Point p1 = new Point(0, 0);
            Point p2 = new Point(0, 2);
            Point p3 = new Point(2, 0);

            PointF rezultat = Geometrie.GetCentruCercCircumscris(p1, p2, p3);

            Assert.AreEqual(1.0f, rezultat.X, 0.001);
            Assert.AreEqual(1.0f, rezultat.Y, 0.001);
        }

        /// <summary>
        /// Testare calcul coordonate centru cern inscris in triunghi
        /// </summary>
        [TestMethod]
        public void TestCentruCercInscris()
        {
            Point p1 = new Point(0, 0); 
            Point p2 = new Point(2, 0); 
            Point p3 = new Point(0, 2);

            PointF rezultat = Geometrie.GetCentruCercInscris(p1, p2, p3);

            Assert.AreEqual(0.586f, rezultat.X, 0.001);
            Assert.AreEqual(0.586f, rezultat.Y, 0.001);
        }

        /// <summary>
        /// Testare exceptie aruncata de metoda Arie cand 2 puncte sunt identice
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestAriePuncteIdentice()
        {
            Point p1 = new Point(0, 0);
            Point p2 = new Point(0, 0); // Identic cu p1
            Point p3 = new Point(1, 1);

            var rezultat = Geometrie.GetArie(p1, p2, p3);

        }

    }

}
