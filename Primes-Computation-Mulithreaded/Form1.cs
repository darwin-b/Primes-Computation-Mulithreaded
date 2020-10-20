
/******************************************************************************
* Multithreaded Computation
*
* This program takes lower & upper bound values from fields as input and does 2 computation 
* tasks which are run as separate threads from that of main user interface thread.
* 
* Computation Tasks
*   - Compute and store all primes less than or equal to the square root of the upper bound.  
*   - Compute and display the numbers in the range of lower & upper bounds, along with their unique prime factors.  
*   
*	
* Written by Nikhil Darwin Bollepalli, starting October 14, 2020.
******************************************************************************/
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Primes_Computation_Mulithreaded
{
    public partial class Form1 : Form
    {

        System.Drawing.Color colorGreen = System.Drawing.Color.Green;
        System.Drawing.Color colorRed = System.Drawing.Color.Red;
        System.Drawing.Color colorBlack = System.Drawing.Color.Black;
        HashSet<int> hashSetPrimes = new HashSet<int>();
        public Form1()
        {
            InitializeComponent();
            InitializeBackgroundWorker();
            backgroundWorker1.WorkerReportsProgress = true;
            backgroundWorker1.WorkerSupportsCancellation = true;

            //lstViewResults.Items.Add(primes_compute(2310));
        }

        private void btnCompute_Click(object sender, EventArgs e)
        {
            if (backgroundWorker1.IsBusy && backgroundWorker1.WorkerSupportsCancellation == true)
            {
                lblMsg.Text = "BGWorker busy and cancelling";
                lstViewResults.Items.Clear();
                backgroundWorker1.CancelAsync();
                lblFactorsProgress.Visible = true;
                lblProgress.Visible = true;
                lblProgress.Text = "Computation1";
                lblFactorsProgress.Text = "Computation2";
                lblMsg.ForeColor = colorBlack;
                progressBar1.Value = 0;
                progressBar2.Value = 0;
                //backgroundWorker1.RunWorkerAsync(1000);
            }
            else
            {
                lblMsg.Text = "BGWorker not busy - starting worker";
                lstViewResults.Items.Clear();
                try
                {
                    int lBound = int.Parse(msktxtLowerBound.Text.Replace(" ", ""));
                    int uBound = int.Parse(msktxtUpperBound.Text.Replace(" ", ""));
                    lblFactorsProgress.Visible = true;
                    lblProgress.Visible = true;
                    lblProgress.Text = "Computation1";
                    lblFactorsProgress.Text = "Computation2";
                    lblMsg.Text = "";
                    lblMsg.ForeColor = colorBlack;
                    progressBar1.Value = 0;
                    progressBar2.Value = 0;
                    List<int> args = new List<int>();
                    args.Add(lBound);
                    args.Add(uBound);
                    backgroundWorker1.RunWorkerAsync(args);
                }
                catch(Exception exception)
                {
                    lblMsg.Text = "Error : Empty fields are not valid input";
                    lblMsg.ForeColor = colorRed;
                }
                   


                
            }

            //hashSetPrimes = primes(10000);

        }


        /************************************************************************************
         * InitializeBackgroundWorker() : Initializes BachgroundWorker with event handlers.   
         * 
         ***********************************************************************************/
        private void InitializeBackgroundWorker()
        {
            backgroundWorker1 = new BackgroundWorker();
            backgroundWorker1.DoWork += new DoWorkEventHandler(bgWorkerDoWork_Compute);
            backgroundWorker1.RunWorkerCompleted += new RunWorkerCompletedEventHandler(backgroundWorker1_RunWorkerCompleted);
            backgroundWorker1.ProgressChanged += new ProgressChangedEventHandler(backgroundWorker1_ProgressChanged);
        }


        /************************************************************************************
         *  backgroundWorker1_RunWorkerCompleted() : handles and updates to UI main thread on success results or 
         *                                          failure status of background thread.
         * 
         ***********************************************************************************/
        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {

            if (e.Error != null)
            {
                lblMsg.Text = "Error: " + e.Error.Message;
                lblMsg.ForeColor = colorRed;
            }
            else if(e.Cancelled)
            {
                lblMsg.Text = "Operation was canceled and started re-computing";
                lblMsg.ForeColor = colorRed;
                btnCompute_Click(sender, e);
            }
            else
            {
                lblMsg.Text = "Computations finished!";
                lblMsg.ForeColor = colorGreen;
            };
        }


        /************************************************************************************
         *  backgroundWorker1_ProgressChanged() : handles and updates to UI main thread on progress changes.
         * 
         ***********************************************************************************/
        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            //Console.WriteLine(typeof())
            //var lstItemsFactors = (ListViewItem)e.UserState;
            var lstItemsFactors = e.UserState as ListViewItem;
            if (lstItemsFactors != null)
            {
                lblMsg.Text = "Factorising Number : " + lstItemsFactors.SubItems[0].Text;
                lstViewResults.Items.Add(lstItemsFactors);
                lblFactorsProgress.Text = ("Computation 2 : " + e.ProgressPercentage.ToString() + "%");
                Console.WriteLine("Progress : " + lblProgress.Text + "%");
                progressBar2.Value = int.Parse(e.ProgressPercentage.ToString());
            }
            else
            {
                lblMsg.Text = e.UserState.ToString();
                lblProgress.Text = ("Computation 1: " + e.ProgressPercentage.ToString() + "%");
                Console.WriteLine("Progress : " + lblProgress.Text + "%");
                progressBar1.Value = int.Parse(e.ProgressPercentage.ToString());
            }


        }


        /************************************************************************************
         *  primes_compute() : Computation2 - Compute and display the numbers in the range of lower & upper bounds,
         *                                    along with their unique prime factors given primes upto square root of upperbound (computaion1 results)
         * 
         ***********************************************************************************/
        private ListViewItem primes_compute(int num, HashSet<int> primesSet)
        {

            ListViewItem listFactors = new ListViewItem(num.ToString());
            int bound = (int)Math.Sqrt(num);
            string factors = "";
            foreach (var prime in primesSet)
            {
                if (num % prime == 0) factors += prime.ToString() + " ";
                while (num % prime == 0) num = num / prime;
            }

            if (num != 1) factors += num.ToString();
            listFactors.SubItems.Add(factors);
            //lstViewResults.Items.Add(number);
            return listFactors;
        }


        /************************************************************************************
         *  primes() : Computation1 - Compute and store all primes less than or equal to the square root of the upper bound in hashset
         * 
         ***********************************************************************************/
        private HashSet<int> primes(int upperBound, BackgroundWorker worker, DoWorkEventArgs e)
        {
            HashSet<int> primes = new HashSet<int>();
            int bound1 = (int)Math.Ceiling(Math.Sqrt(upperBound));
            for (int i = 2; i <= bound1; i++)
            {
                if (worker.CancellationPending == true)
                {
                    e.Cancel = true;
                    break;
                }
                else
                {
                    System.Threading.Thread.Sleep(1);
                    bool flagP = true;
                    int bound2 = (int)Math.Ceiling(Math.Sqrt(upperBound));
                    for (int j = 2; j <= bound2; j++)
                    {
                        if (i % j == 0 && i != j)
                        {
                            flagP = false;
                            break;
                        }
                    }
                    if (flagP)
                        primes.Add(i);

                    //listResults.Add(primes_compute(i, hashSetPrimes));
                    //ListViewItem factors = primes_compute(i, hashSetPrimes);
                    worker.ReportProgress(i * 100 / bound1, "Computation1: Primes up to square root of upperbound!");
                }


            }
            return primes;
        }


        /************************************************************************************
         *  bgWorkerDoWork_Compute() : controlls the background thread computations & calls to report progress changes/results
         * 
         ***********************************************************************************/
        private void bgWorkerDoWork_Compute(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = sender as BackgroundWorker;

            //Extract arguments sent from BGworker1.runsync()
            int lBound = ((List<int>)e.Argument)[0];
            int uBound = ((List<int>)e.Argument)[1];


            if (lBound <= uBound)
            {
                Console.WriteLine(lBound + " - " + uBound);
                hashSetPrimes = primes(uBound, worker, e);
                Console.WriteLine("Computation1 Finished");

                //sleep thread to allow time to update prograss bar1 completely
                System.Threading.Thread.Sleep(1000);
                //lblProgress.Text = "Computation1 Finished";

                for (int i = lBound; i <= uBound; i++)
                {
                    if (worker.CancellationPending == true)
                    {
                        e.Cancel = true;
                        break;
                    }
                    else if(lBound!=uBound)
                    {
                        System.Threading.Thread.Sleep(1);
                        //listResults.Add(primes_compute(i, hashSetPrimes));
                        ListViewItem factors = primes_compute(i, hashSetPrimes);
                        worker.ReportProgress((i - lBound) * 100 / (uBound - lBound), factors);
                    }
                    else
                    {
                        //sleep thread to control refressh rate of UI update of factors on screen to prevent freeze of application
                        System.Threading.Thread.Sleep(1);
                        
                        ListViewItem factors = primes_compute(i, hashSetPrimes);
                        worker.ReportProgress(100, factors);
                        
                    }
                }
            }
            else
            {
                throw new Exception("Lowerbound value greater than Upperbound.");
            }


        }

    }
}
