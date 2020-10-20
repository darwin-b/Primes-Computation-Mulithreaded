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

        List<ListViewItem> listResults = new List<ListViewItem>();
        HashSet<int> hashSetPrimes = new HashSet<int>();
        public Form1()
        {
            InitializeComponent();
            backgroundWorker1.WorkerReportsProgress = true;
            backgroundWorker1.WorkerSupportsCancellation = true;
            //lstViewResults.Items.Add(primes_compute(2310));
        }

        private void btnCompute_Click(object sender, EventArgs e)
        {
            if (backgroundWorker1.IsBusy && backgroundWorker1.WorkerSupportsCancellation == true)
            {
                lblMsg.Text = "Bg busy and cancelling";
                listResults = new List<ListViewItem>();
                lstViewResults.Items.Clear();
                backgroundWorker1.CancelAsync();
                //backgroundWorker1.RunWorkerAsync(1000);
            }
            else
            {
                lblMsg.Text = "BG not busy - starting worker";
                lstViewResults.Items.Clear();
                backgroundWorker1.CancelAsync();
                lblProgress.Text = "";
                progressBar1.Value = 0;
                backgroundWorker1.RunWorkerAsync(1000);
            }

            hashSetPrimes = primes(10000);
            
        }


        private void Form1_Load(object sender, EventArgs e)
        {

            backgroundWorker1.DoWork += bgWorkerDoWork_Compute;

        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled)
            {
                lblProgress.Text = "Operation was canceled";
                btnCompute_Click(sender, e);
            }
            else if (e.Error != null) lblProgress.Text = "Error: " + e.Error.Message;
            else
            {
                lstViewResults.Items.Clear();
                foreach (ListViewItem item in listResults)
                {
                    lstViewResults.Items.Add(item);
                }
                listResults = new List<ListViewItem>();
            };
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            //if(typeof(e)=typeof(ListViewItem))
            //{

            //}
            lblProgress.Text = (e.ProgressPercentage.ToString() + "%");
            progressBar1.Value = int.Parse(e.ProgressPercentage.ToString());
        }


        private ListViewItem primes_compute(int num, HashSet<int> primesSet)
        {

            ListViewItem listFactors = new ListViewItem(num.ToString());
            int bound = (int) Math.Sqrt(num);
            string factors="";
            foreach(var prime in primesSet)
            {
                if(num%prime==0) factors += prime.ToString()+" ";
            }

            listFactors.SubItems.Add(factors);
            //lstViewResults.Items.Add(number);
            return listFactors;
        }

        private HashSet<int> primes(int upperBound)
        {
            HashSet<int> primes = new HashSet<int>();
            int bound1 = (int) Math.Ceiling(Math.Sqrt(upperBound));
            for (int i=2;i<=bound1;i++)
            {
                bool flagP = true;
                int bound2 = (int)Math.Ceiling(Math.Sqrt(upperBound));
                for (int j=2;j<=bound2;j++)
                {
                    if(i%j==0 && i!=j)
                    {
                        flagP = false;
                        break;
                    }
                }
                if(flagP)                 
                    primes.Add(i);
            }
            return primes;
        }


        private void bgWorkerDoWork_Compute(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = sender as BackgroundWorker;
            int lBound = int.Parse(msktxtLowerBound.Text);
            int uBound = int.Parse(msktxtUpperBound.Text);
            //listResults = new List<ListViewItem>();
            Console.WriteLine(lBound+ uBound);
            hashSetPrimes = primes(uBound);
            for(int i = lBound; i <= uBound; i++)
            {
                if(worker.CancellationPending== true)
                {
                    e.Cancel = true;
                    break;
                }
                else
                {
                    //System.Threading.Thread.Sleep(500);

                    listResults.Add(primes_compute(i, hashSetPrimes));

                    //lblProgress.Text = ((i - lBound) * 100 / (uBound - lBound)).ToString();
                    worker.ReportProgress((i-lBound) * 100/(uBound-lBound));
                    
                }
            }
        }

        private void backgroundWorker2_DoWork(object sender, DoWorkEventArgs e)
        {

        }

        private void backgroundWorker2_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {

        }

        private void backgroundWorker2_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {

        }
    }
}
