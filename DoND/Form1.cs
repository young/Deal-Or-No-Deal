using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections.Specialized;

namespace DoND
{
    public partial class Form1 : Form
    {
        long[] Amounts = new long[21] {
            10,20,30,40,50,80,100,200,500,750,1000,2000,5000,7500,10000,15000,20000,50000,80000,100000,250000
        };
        static Random random = new Random();

        public Form1()
        {
            InitializeComponent();

        }

        private void btnReject_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            label1.Text = "";
        
        }

   

        private void label31_Click(object sender, EventArgs e)
        {

        }

        private void applyGroups()
        {
            OrderedDictionary Cases = new OrderedDictionary();
            Cases.Add("label1", "");
            Cases.Add("label2", "");
            Cases.Add("label3", "");

            if (Cases.Contains(label1.Name)){
                MessageBox.Show("Test");
            }

        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            
            foreach (long value in Amounts)
            {
                System.Diagnostics.Debug.WriteLine(value);
            }
            Shuffle(Amounts);
            System.Diagnostics.Debug.WriteLine("");
            System.Diagnostics.Debug.WriteLine("");
            System.Diagnostics.Debug.WriteLine("");
            foreach (long value in Amounts)
            {
                System.Diagnostics.Debug.WriteLine(value);
            }

        }
        // Fisher-Yates shuffle
        private static void Shuffle(long[] array)
        {
          
            for (int i = array.Length; i > 1; i--)
            {
                // Pick random element to swap.
                int j = random.Next(i); // 0 <= j <= i-1
                // Swap.
                long tmp = array[j];
                array[j] = array[i - 1];
                array[i - 1] = tmp;
            }

        }

    }
}
