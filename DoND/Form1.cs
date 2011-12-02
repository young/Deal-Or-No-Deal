using System;
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
        public static OrderedDictionary Cases = new OrderedDictionary();
        public Form1()
        {
            InitializeComponent();

        }

        private void btnReject_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Shuffle(Amounts);
            applyGroups();  
        }

   

        private void label31_Click(object sender, EventArgs e)
        {

        }

        private void applyGroups()
        {
          int i = Amounts.Count();
          i = i - 1;


            Cases.Add("label1", Amounts[i--]);
            Cases.Add("label2", Amounts[i--]);
            Cases.Add("label3", Amounts[i--]);
            Cases.Add("label4", Amounts[i--]);
            Cases.Add("label5", Amounts[i--]);
            Cases.Add("label6", Amounts[i--]);
            Cases.Add("label7", Amounts[i--]);
            Cases.Add("label8", Amounts[i--]);
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

     
        }

        private void btnAccept_Click(object sender, EventArgs e)
        { 
           
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


        /// <summary>
        /// Every label's Click event is handled by this event handler
        /// </summary>
        /// <param name="sender">The label that was clicked</param>
        /// <param name="e"></param>
        private void label_Click(object sender, EventArgs e)
        {
            Label clickedLabel = sender as Label;

            // simple check to see if the label has already 
            // been clicked by checking the forground color.
            // if it has been clicked then the click will not
            // do anything.
            if (clickedLabel.ForeColor != Color.Red)
            { 
                foreach (DictionaryEntry de in Cases)
                { 
                    string name = de.Key.ToString();
                    if (name.Equals(clickedLabel.Name))
                        clickedLabel.Text = de.Value.ToString();
                }
      
                 clickedLabel.ForeColor = Color.Red;
                    return;
                } 
                   

               
            
        }




    }
}
