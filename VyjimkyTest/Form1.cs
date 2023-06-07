using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VyjimkyTest
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            listBox1.Visible = true;
            double[] pole = new double[textBox1.Lines.Count()];
            int soucet = 0;
            double pocet = 0;
            double prumer = 0;
            for (int i = 0; i < textBox1.Lines.Count(); i++) 
            {
                try
                {
                    pole[i] = Convert.ToDouble(textBox1.Lines[i]);
                    if(pole[i]<0)
                    {
                        try
                        {
                            checked { soucet = soucet + Convert.ToInt32(pole[i]); };
                            listBox1.Items.Add(pole[i]);
                        }
                        catch(OverflowException ex)
                        {
                            soucet = soucet+0;
                            pocet--;
                            MessageBox.Show(ex.ToString());
                        }
                        catch(ArithmeticException ex)
                        {
                            soucet = soucet + 0;
                            pocet--;

                            MessageBox.Show(ex.ToString());
                        }
                        finally
                        {
                            
                            pocet++;
                        }
                       
                    }
                }
                catch(OverflowException ex)
                {
                    MessageBox.Show(ex.ToString());
                }
                catch(FormatException ex)
                {
                    
                    MessageBox.Show(ex.ToString() + "\n \n Na řádku: "+(i+1));
                }

            }
            try
            {
                prumer = soucet / pocet;
            }
            catch(DivideByZeroException ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                label1.Visible = true;
                
                label1.Text = "Průměr je: " + prumer;
                MessageBox.Show("Průměr je: " + prumer);
            }

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            textBox2.Visible = false;
            button2.Visible = true;
            label1.Visible = false;
            listBox1.Visible = false;
            button2.Enabled = true;
            pictureBox1.Visible = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            pictureBox1.Visible = true;
            textBox2.Visible = true;
            MessageBox.Show("Ahoj já jsem Křupka! Zahraj si moji hru!");
            textBox2.Text = "http://krupkaclicker.jednoduse.cz/";
        }
    }
}
