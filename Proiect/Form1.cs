/**************************************************************************
 *                                                                        *
 *  File:        Form1.cs                                                 *
 *  Copyright:   (c) 2025, Simina Rusu, Codrina Tăbușcă, Tudor Rotariu,   *
 *               Vasile Leșan                                             *
 *  E-mail:      simina-ioana.rusu@student.tuiasi.ro,                     *
 *               codrina-florentina.tabusca@student.tuiasi.ro,            *
 *               tudor-liviu.rotariu@student.tuiasi.ro                    *
 *               vasile.lesan@student.tuiasi.ro                           *
 *  Description: Windows Forms app for drawing and analyzing a            *
 *               triangle with real-time updates.                         *
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
using System.Collections.Generic;
using System.Drawing;
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

            //facem interfata mai mare pentru o vizualizare mai buna
            this.WindowState = FormWindowState.Maximized;
            pictureBox1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Bottom;
            buttonExit.Anchor = AnchorStyles.Bottom;
            buttonHelp.Anchor = AnchorStyles.Bottom;

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
                ErrorHandler.MesajEroare(new Exception("Trebuie să setați toate cele 3 puncte ale triunghiului."));
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
                ErrorHandler.MesajEroare(new Exception("Trebuie să setați toate cele 3 puncte ale triunghiului."));
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
                ErrorHandler.MesajEroare(new Exception("Trebuie să setați toate cele 3 puncte ale triunghiului."));
                return;
            }
            try
            {
                double arie = Geometrie.GetArie(p1, p2, p3);
                double perimetru = Geometrie.GetPerimetru(p1, p2, p3);
                PointF centruInscris = Geometrie.GetCentruCercInscris(p1, p2, p3);
                PointF centruCircumscris = Geometrie.GetCentruCercCircumscris(p1, p2, p3);

                richTextBoxCalculate.Text = string.Format("Aria: {0}\nPerimetrul: {1}\nCentru inscris:  X: {2}, Y: {3} \nCentru circumscris:  X: {4}, Y: {5}", arie, perimetru, centruInscris.X, centruInscris.Y, centruCircumscris.X, centruCircumscris.Y);


            }
            catch (Exception ex)
            {
                ErrorHandler.MesajEroare(ex);
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
                ErrorHandler.MesajEroare(new Exception("Trebuie să setați toate cele 3 puncte ale triunghiului."));
                return;
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
                ErrorHandler.MesajEroare(ex);
            }
        }

        /// <summary>
        /// Functie pentru desenarea triunghiului pe interfata
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            Desenator.DesenareTriunghi(e.Graphics,
                    nOfPoints,
                    p1,
                    p2,
                    p3,
                    checkBoxMediane.Checked,
                    checkBoxBisectoare.Checked,
                    checkBoxInaltimi.Checked,
                    checkBoxMediatoare.Checked);

            if(nOfPoints == 3)
            {
                if (checkBoxCercInscris.Checked)
                    Desenator.DesenareCercInscris(e.Graphics, p1, p2, p3);
                if (checkBoxCercCircumscris.Checked)
                    Desenator.DesenareCerCircumscris(e.Graphics, p1, p2, p3);
            }
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

        /// <summary>
        /// Eveniment care se declanșează când se schimbă starea checkbox-ului pentru afișarea mediatoarei
        /// </summary>
        /// <param name="sender">Obiectul care a generat evenimentul</param>
        /// <param name="e">Datele evenimentului</param>
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
    }
}