using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

namespace WindowsFormsApp22
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        /*double CZK(double vyplata)
        {
            vyplata *= 22.35;
            return vyplata;
        }*/

        private void Form1_Load(object sender, EventArgs e)
        {
            int zeny = 0;
            string[] slova;
            double vyplata = 0;
            int soucet = 0;
            double prumer = 0;
            OpenFileDialog soubor = new OpenFileDialog();
            soubor.InitialDirectory = Path.GetDirectoryName(Application.ExecutablePath);
            if (soubor.ShowDialog() == DialogResult.OK)
            {
                StreamReader ctenar = new StreamReader(soubor.FileName, Encoding.GetEncoding("windows-1250"));
                StreamWriter zapisovac = new StreamWriter("best.txt", false, Encoding.GetEncoding("windows-1250"));
                for (int i = 0; i < 100; i++)
                {
                    string radek = ctenar.ReadLine();
                    slova = radek.Split(',');
                    if (slova[2] == "Female")
                    {
                        zeny++;
                    }
                    if(Convert.ToInt32(slova[4]) > vyplata)
                    {
                        vyplata = Convert.ToInt32(slova[4]);
                    }
                    soucet += Convert.ToInt32(slova[3]);
                    prumer = (double)soucet / 100;
                    if (Convert.ToInt32(slova[4])* 22.35 < 17300)
                    {
                        listBox1.Items.Add(Convert.ToInt32(slova[4]) * 22.35);
                    }
                }

                MessageBox.Show("Počet žen: " + zeny.ToString());
                zapisovac.WriteLine("Výplata: " + vyplata *22.35);
                zapisovac.WriteLine("Průměrný věk: " + prumer);
                ctenar.Close();
                zapisovac.Close();
                
            }

        }
    }
}
