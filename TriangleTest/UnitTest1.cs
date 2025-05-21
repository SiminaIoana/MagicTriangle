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

        [TestMethod]
        public void TestGetP1()
        {
            Assert.AreEqual(0, form.GetV1());
        }
    }

}
