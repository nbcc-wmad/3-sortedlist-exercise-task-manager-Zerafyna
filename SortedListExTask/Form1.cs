using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

    /*
    * Author: Erica Moisei
    * Date: Apr. 30/2019
    * Exercise: SortedListExerciseTask
    * Notes: 
    */ 

namespace SortedListExTask
{
    public partial class Form1 : Form
    {
        SortedList<DateTime, string> tasks = new SortedList<DateTime, string>();

        public Form1()
        {
            InitializeComponent();
        }

        #region Controlls

        private void btnAddTask_Click(object sender, EventArgs e)
        {
            if (txtTask.Text.Trim() == string.Empty)
            {
                MessageBox.Show("You must enter a task.");
                return;
            }

            DateTime date = dtpTaskDate.Value;

            if (tasks.ContainsKey(date))
            {
                MessageBox.Show("Only one task per day is allowed.");
                return;
            }
            else
            {
                int lastReccord = tasks.Count - 1;
                tasks.Add(date, txtTask.Text.Trim());
                lstTasks.Items.Add(date);
            }

        }

        private void btnRemoveTask_Click(object sender, EventArgs e)
        {

        }

        private void btnPrintAll_Click(object sender, EventArgs e)
        {

        }

        #endregion

    }
}
