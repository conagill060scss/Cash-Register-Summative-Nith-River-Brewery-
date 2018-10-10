using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cash_Register_Summative
{
    public partial class Form1 : Form
    {
        const double SMOKEY = 6.99;
        const double TRACTOR = 5.50;
        const double WILLOW = 3;
        const double TAX = 0.13;
        double total = 0;
        double tax = 0;
        double subTotal = 0;
        int smokeyTotal = 0;
        int tractorTotal = 0;
        int willowTotal = 0;
        double willowCost;
        double smokeyCost;
        double tractorCost;
        double pay = 0;
        double change = 0;
        bool stopCode1 = true;
        bool stopCode2;
        int x = 450;
        int y = 70;
        int height = 340;
        int width = 250;


        public Form1()
        {
            InitializeComponent();
        }

        private void drinkButton_Click(object sender, EventArgs e)
        {
            stopCode1 = false;
            //input
            try
            {
                smokeyTotal = Convert.ToInt16(smokeyTextbox.Text);
                if (smokeyTotal < 0)
                {
                    smokeyTotal = 0;

                }
            }
            catch
            {
                smokeyTotal = 0;
            }
            try {
                tractorTotal = Convert.ToInt16(tractorTextbox.Text);
                if (tractorTotal < 0)
                {
                    tractorTotal = 0;
                }
            }
            catch
            {
                tractorTotal = 0;
            }
            try
            {
                willowTotal = Convert.ToInt16(willowTextbox.Text);
                if (willowTotal < 0)
                {
                    willowTotal = 0;
                }
            }
            catch
            {
                willowTotal = 0;

            }



            //math
            willowCost = willowTotal * WILLOW;
            smokeyCost = smokeyTotal * SMOKEY;
            tractorCost = tractorTotal * TRACTOR;
            subTotal = willowCost + smokeyCost + tractorCost;
            tax = subTotal * TAX;
            total = tax + subTotal;

            //output
            subtotalnumberLabel.Text = subTotal.ToString("C");
            taxnumberLabel.Text = tax.ToString("C");
            totalnumberLabel.Text = total.ToString("C");
            

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (stopCode1 == false)
            {
                try
                {
                    pay = Convert.ToInt16(payTextbox.Text);
                    if (pay < total)
                    {
                        changeLabel.Text = "Money Still Owed:";
                        stopCode2 = true;
                    }
                    else
                    {
                        changeLabel.Text = "Change:";
                        stopCode2 = false;
                    }
                    change = pay - total;

                    changenumberLabel.Text = change.ToString("C");


                }
                catch
                {
                    changeLabel.Text = "Cash only";
                }
            }
        }

        private void tabButton_Click(object sender, EventArgs e)
        {
            if (stopCode2 == false)
            {
                //defining drawing 
                Graphics g = this.CreateGraphics();
                Font drawFont = new Font("Mistral", 12, FontStyle.Bold);
                SolidBrush drawBrush = new SolidBrush(Color.LightGray);
                Pen drawPen = new Pen(Color.Black, 12);

                g.FillRectangle(drawBrush, x, y, width, height);
                drawBrush.Color = Color.White;
                Thread.Sleep(100);

                while (x < 700)
                {
                    g.FillRectangle(drawBrush, x, y, width, height);

                    Thread.Sleep(100);
                    this.Refresh();

                }
            }
        }
    }
}