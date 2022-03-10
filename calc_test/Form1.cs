using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace calc_test
{
    public partial class Form1 : Form
    {
        int selected_index = 1; // care label e selectat
        public Form1()
        {
            InitializeComponent();
            comboBox1.SelectedIndex = comboBox2.SelectedIndex = 3;
            this.ActiveControl = null;
        }

        private void label1_Click(object sender, EventArgs e)
        {
            selected_index = 1;
            label1.ForeColor = SystemColors.ControlText;
            label2.ForeColor = SystemColors.WindowFrame;
            this.ActiveControl = null;
        }

        private void label2_Click(object sender, EventArgs e)
        {
            selected_index = 2;
            label1.ForeColor = SystemColors.WindowFrame;
            label2.ForeColor = SystemColors.ControlText;
            this.ActiveControl = null;
        }

        void do_conversion()
        {
            if (selected_index == 1)
            {
                double n, rez = 0;
                try { n = double.Parse(label1.Text); }
                catch (Exception ex) { return; }
                if (comboBox1.SelectedIndex<7 && comboBox2.SelectedIndex<7)
                {// subunitati ale gramului
                    rez = n * Math.Pow(10, comboBox1.SelectedIndex - comboBox2.SelectedIndex);
                }
                else if(comboBox1.SelectedIndex == 7)
                {
                    if (comboBox2.SelectedIndex == 7) rez = n;
                    else if(comboBox2.SelectedIndex == 8) rez = n * 2267.962;
                    else
                    {
                        rez = n * 0.453592; // in kg
                        rez = rez * Math.Pow(10, 6 - comboBox2.SelectedIndex);
                    }
                }
                else if(comboBox2.SelectedIndex == 7)
                {
                    if (comboBox1.SelectedIndex == 7) rez = n;
                    else if (comboBox1.SelectedIndex == 8) rez = n / 2267.962;
                    else
                    {
                        rez = n / 0.453592; // in kg
                        rez = rez / Math.Pow(10, 7 - comboBox2.SelectedIndex);
                    }
                }
                else if (comboBox1.SelectedIndex == 8)
                {
                    if (comboBox2.SelectedIndex == 8) rez = n;
                    else if (comboBox2.SelectedIndex == 7) rez = n * 0.000441;
                    else
                    {
                        rez = n * 0.0002; // in kg
                        rez = rez * Math.Pow(10, 6 - comboBox2.SelectedIndex);
                    }
                }
                else if (comboBox2.SelectedIndex == 8)
                {
                    if (comboBox1.SelectedIndex == 8) rez = n;
                    else if (comboBox1.SelectedIndex == 7) rez = n / 0.000441;
                    else
                    {
                        rez = n / 0.0002; // in kg
                        rez = rez / Math.Pow(10, 7 - comboBox2.SelectedIndex);
                    }
                }
                label2.Text = rez.ToString();
            }
            else
            {
                double n, rez = 0;
                try { n = double.Parse(label2.Text); }
                catch (Exception ex) { return; }
                if (comboBox2.SelectedIndex < 7 && comboBox1.SelectedIndex < 7)
                {// subunitati ale gramului
                    rez = n * Math.Pow(10, comboBox2.SelectedIndex - comboBox1.SelectedIndex);
                }
                else if (comboBox2.SelectedIndex == 7)
                {
                    if (comboBox1.SelectedIndex == 7) rez = n;
                    else if (comboBox1.SelectedIndex == 8) rez = n * 2267.962;
                    else
                    {
                        rez = n * 0.453592; // in kg
                        rez = rez * Math.Pow(10, 6 - comboBox1.SelectedIndex);
                    }
                }
                else if (comboBox1.SelectedIndex == 7)
                {
                    if (comboBox2.SelectedIndex == 7) rez = n;
                    else if (comboBox2.SelectedIndex == 8) rez = n / 2267.962;
                    else
                    {
                        rez = n / 0.453592; // in kg
                        rez = rez / Math.Pow(10, 7 - comboBox1.SelectedIndex);
                    }
                }
                else if (comboBox2.SelectedIndex == 8)
                {
                    if (comboBox1.SelectedIndex == 8) rez = n;
                    else if (comboBox1.SelectedIndex == 7) rez = n * 0.000441;
                    else
                    {
                        rez = n * 0.0002; // in kg
                        rez = rez * Math.Pow(10, 6 - comboBox1.SelectedIndex);
                    }
                }
                else if (comboBox1.SelectedIndex == 8)
                {
                    if (comboBox2.SelectedIndex == 8) rez = n;
                    else if (comboBox2.SelectedIndex == 7) rez = n / 0.000441;
                    else
                    {
                        rez = n / 0.0002; // in kg
                        rez = rez / Math.Pow(10, 7 - comboBox1.SelectedIndex);
                    }
                }
                label1.Text = rez.ToString();
            }
        }

        bool ok(Label label)
        {
            try
            {
                double.Parse(label.Text);
            }
            catch (Exception ex) { return false; }
            return true;
        }

        private void buttonCifra_Click(object sender, EventArgs e)
        {
            if(selected_index == 1)
            {
                if (label1.Text == "0") label1.Text = ""; 
                label1.Text = label1.Text + ((Button)sender).Text;
            }
            else
            {
                if (label2.Text == "0") label2.Text = "";
                label2.Text = label2.Text + ((Button)sender).Text;
            }
            do_conversion();
            this.ActiveControl = null;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            double rez;
            if(selected_index == 1)
            {
                try { rez = double.Parse(label1.Text); }
                catch (Exception ex) { return; }
                if(rez==(int)rez)
                {
                    label1.Text = label1.Text + ",";
                }
            }
            else
            {
                try { rez = double.Parse(label2.Text); }
                catch (Exception ex) { return; }
                if (rez == (int)rez)
                {
                    label2.Text = label2.Text + ",";
                }
            }
            this.ActiveControl = null;
        }

        private void button15_Click(object sender, EventArgs e)
        {
            if(selected_index == 1)
            {
                label1.Text = label1.Text.Remove(label1.Text.Length - 1);
                if (ok(label1)) do_conversion();
                if (label1.Text == "") label1.Text = label2.Text = "0";
            }
            else
            {
                label2.Text = label2.Text.Remove(label2.Text.Length - 1);
                if (ok(label2)) do_conversion();
                if (label2.Text == "") label2.Text = label1.Text = "0";
            }
            this.ActiveControl = null;
        }

        private void button14_Click(object sender, EventArgs e)
        {
            label1.Text = label2.Text = "0";
            this.ActiveControl = null;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            do_conversion();
            this.ActiveControl = null;
        }

        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar >= '0' && e.KeyChar <= '9' || e.KeyChar == ',')
            {
                if (selected_index == 1)
                {
                    if (label1.Text == "0") label1.Text = "";
                    label1.Text = label1.Text + e.KeyChar;
                }
                else
                {
                    if (label2.Text == "0") label2.Text = "";
                    label2.Text = label2.Text + e.KeyChar;
                }
                do_conversion();
            }
            else if (",.".Contains(e.KeyChar)) button3_Click(sender, null);
            else if (e.KeyChar == '\b') button15_Click(sender, null);
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            this.ActiveControl = null;
        }

        private void button13_Click(object sender, EventArgs e)
        {
            this.ActiveControl = null;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.ActiveControl = null;
        }
    }
}
