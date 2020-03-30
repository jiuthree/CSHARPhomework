using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace homework7
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (graphics == null) graphics = this.panel1.CreateGraphics();
            drawCayleyTree(n, 200, 310, leng, -Math.PI / 2);

        }
        private Graphics graphics;
        double th1 = 30 * Math.PI / 180;
        double th2 = 20 * Math.PI / 180;
        double per1 = 0.6;
        double per2 = 0.7;
        int n = 10;
        double leng = 100;
        System.Drawing.Pen color = Pens.Blue;
        void drawCayleyTree(int n, double x0, double y0, double leng, double th) {
            if (n == 0) return;
            double x1 = x0 + leng * Math.Cos(th);
            double y1 = y0 + leng * Math.Sin(th);
            drawLine(x0, y0, x1, y1);
            drawCayleyTree(n - 1, x1, y1, per1 * leng, th + th1);
            drawCayleyTree(n - 1, x1, y1, per2 * leng, th - th2);


        }
        void drawLine(double x0,double y0,double x1,double y1) {
            graphics.DrawLine(color,
                (int)x0,(int)y0,(int)x1,(int)y1); }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            n=int.Parse(textBox1.Text);
        }

        private void hScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {
            leng =(double)hScrollBar1.Value;
            label2.Text = hScrollBar1.Value.ToString();
        }

        private void hScrollBar2_Scroll(object sender, ScrollEventArgs e)
        {
            per1 = ((double)hScrollBar2.Value * 1.0)/1000 ;
            label3.Text = per1.ToString();
           
        }

        private void hScrollBar3_Scroll(object sender, ScrollEventArgs e)
        {
            per2 = ((double)hScrollBar3.Value * 1.0) / 1000;
            label4.Text = per2.ToString();

        }

        private void hScrollBar4_Scroll(object sender, ScrollEventArgs e)
        {
            th1 = ((double)hScrollBar4.Value * 1.0) * Math.PI / 180;
            label5.Text = th1.ToString();
        }

        private void hScrollBar5_Scroll(object sender, ScrollEventArgs e)
        {
            th2 = ((double)hScrollBar4.Value * 1.0) * Math.PI / 180;
            label6.Text = th2.ToString();
        }

        

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked) { color = Pens.Red; }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked) { color = Pens.Yellow; }
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked) { color = Pens.Blue; }
        }
    }
}
