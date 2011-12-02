﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;
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
                 
        }

   

        private void label31_Click(object sender, EventArgs e)
        {

        }

        private void applyGroups()
        {
          int i = Amounts.Count();
          i = i - 1;


            OrderedDictionary Cases = new OrderedDictionary();
            Cases.Add("label1", Amounts[i--]);
            Cases.Add("label2", Amounts[i--]);
            Cases.Add("label3", Amounts[i--]);
            Cases.Add("label4", Amounts[i--]);
            Cases.Add("label5", Amounts[i--]);
            Cases.Add("label6", Amounts[i--]);
            Cases.Add("label7", Amounts[i--]);
            Cases.Add("label9", Amounts[i--]);
            Cases.Add("label10", Amounts[i--]);
            Cases.Add("label11", Amounts[i--]);
            Cases.Add("label12", Amounts[i--]);
            Cases.Add("label13", Amounts[i--]);
            Cases.Add("label14", Amounts[i--]);
            Cases.Add("label15", Amounts[i--]);
            Cases.Add("label16", Amounts[i--]);
            Cases.Add("label17", Amounts[i--]);
            Cases.Add("label18", Amounts[i--]);
            Cases.Add("label19", Amounts[i--]);
            Cases.Add("label20", Amounts[i--]);
            Cases.Add("label21", Amounts[i--]);
            // setup collections for keys and values
            ICollection keyCollection = Cases.Keys;
            ICollection valueCollection = Cases.Values;

            // Display the contents of the "new" Dictionary using an enumerator
            IDictionaryEnumerator myEnumerator = Cases.GetEnumerator();

            String[] myKeys = new String[Cases.Count];
            String[] myValues = new String[Cases.Count];
        
          


            foreach (DictionaryEntry de in Cases)
            {
                MessageBox.Show(de.Value.ToString());
            }

      


        }

        private void btnAccept_Click(object sender, EventArgs e)
        { Shuffle(Amounts);
            applyGroups();
           
        }

        // Fisher-Yates shuffle
        private static void Shuffle(long[] array)
        {
            for (int i = array.Length; i > 1; i--)
            {
                // Pick random element to swap
                int j = random.Next(i);
                // Swap
                long tmp = array[j];
                array[j] = array[i - 1];
                array[i - 1] = tmp;
            }
        }




    }
}
