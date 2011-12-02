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
        public static double[] CashRemaining = new double[21] {
            10,20,30,40,50,80,100,200,500,750,1000,2000,5000,7500,10000,15000,20000,50000,80000,100000,250000
        };
        public static double numCasesLeft = 21;
        public static double offerAmount = 0;
        static Random random = new Random();
        public static OrderedDictionary Cases = new OrderedDictionary();
        public static OrderedDictionary AmountInCases = new OrderedDictionary();
        public Form1()
        {
            InitializeComponent();

        }

     

        private void Form1_Load(object sender, EventArgs e)
        {   
            // randomize the amounts
            Shuffle(Amounts);
            
            applyGroups();
            ExpectedValue(CashRemaining, numCasesLeft);
        }

        private double ExpectedValue(double[] ex, double numCasesLeft)
        {
            double expected = 0.0;
           
            foreach (double x in ex)
            {
                expected += (x * (1.0 / numCasesLeft));
            }
          
            return expected;
        }
        // because a label element cannot directly have a value we call
        // this method that uses OrderedDictionaries to create entries
        // that will correspond to labels in the form. It will then
        // give the labels values.
        private void applyGroups()
        {
            int i = Amounts.Count() - 1;

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


            int z = CashRemaining.Count() - 1;

            AmountInCases.Add("label22", CashRemaining[z--]);
            AmountInCases.Add("label23", CashRemaining[z--]);
            AmountInCases.Add("label24", CashRemaining[z--]);
            AmountInCases.Add("label25", CashRemaining[z--]);
            AmountInCases.Add("label26", CashRemaining[z--]);
            AmountInCases.Add("label27", CashRemaining[z--]);
            AmountInCases.Add("label28", CashRemaining[z--]);
            AmountInCases.Add("label29", CashRemaining[z--]);
            AmountInCases.Add("label30", CashRemaining[z--]);
            AmountInCases.Add("label31", CashRemaining[z--]);
            AmountInCases.Add("label32", CashRemaining[z--]);
            AmountInCases.Add("label33", CashRemaining[z--]);
            AmountInCases.Add("label34", CashRemaining[z--]);
            AmountInCases.Add("label35", CashRemaining[z--]);
            AmountInCases.Add("label36", CashRemaining[z--]);
            AmountInCases.Add("label37", CashRemaining[z--]);
            AmountInCases.Add("label38", CashRemaining[z--]);
            AmountInCases.Add("label39", CashRemaining[z--]);
            AmountInCases.Add("label40", CashRemaining[z--]);
            AmountInCases.Add("label41", CashRemaining[z--]);
     
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
      
        // Every label's Click event is handled by this event handler
        private void label_Click(object sender, EventArgs e)
        {
            Label clickedLabel = sender as Label;
             Control.ControlCollection ctrls = this.Controls;
            string name;
            string value = "";


            // simple check to see if the label has already 
            // been clicked by checking the forground color.
            // If it has been clicked then the click will not
            // do anything.
            if (clickedLabel.ForeColor != Color.Red)
            { 
                foreach (DictionaryEntry de in Cases)
                { 
                    name = de.Key.ToString();
                    value = de.Value.ToString();
                    if (name.Equals(clickedLabel.Name))
                    {                        
                       foreach (Control c in ctrls)
                        {
                            // search the form for a label(control) where the
                            // text field equals the value of the case
                            // that was just clicked
                            if (c.Text.Equals(value))
                            {
                                c.ForeColor = Color.DarkBlue;
                                c.Font = new Font("Arial", 12, FontStyle.Strikeout);
                                break;
                            }
                        }
                        clickedLabel.Text = de.Value.ToString();
                        break;
                    }
                  
                }

                double val = Convert.ToDouble(value);
                for ( int x = 0; x < CashRemaining.Length; x++)
                {
                    if (val == CashRemaining[x])
                    {
                        CashRemaining[x] = 0;
                    }
                }
                 clickedLabel.ForeColor = Color.Red;
                
                
                 dealerOffer(val);
                    return;
                } 

        }

        private void dealerOffer(double finalVal)
        {
            double offerSeed = ExpectedValue(CashRemaining, numCasesLeft--);
            double[] offerModifiers = new double[7] {0.05, 0.08, 0.12, 0.15, 0.25, 0.30, 0.40 };

            if (numCasesLeft == 0)
            {
                MessageBox.Show("You won $" + finalVal);
                Application.Exit();
            }

            if ((numCasesLeft % 3 == 0) && (numCasesLeft < 21) && (numCasesLeft >= 3))
            {
                int j = random.Next(7);
                double offerOffSet = offerModifiers[j] * offerSeed;
                double offerAmount = offerOffSet + offerSeed;

                if (MessageBox.Show("The offer is $" + Math.Round(offerAmount, 0), "Dealer Offer", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    MessageBox.Show("You won $" + Math.Round(offerAmount, 0) );
                    Application.Exit();

                }


            }

        }


    }
}
