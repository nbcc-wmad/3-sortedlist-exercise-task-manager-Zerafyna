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

            DateTime date = dtpTaskDate.Value.Date;

            if (tasks.ContainsKey(date))
            {
                MessageBox.Show("Only one task per day is allowed.");
                return;
            }
            else
            {
                int lastReccord = tasks.Count - 1;
                tasks.Add(date, txtTask.Text.Trim());
                // binding data to lst
                lstTasks.DisplayMember = "Key";
                lstTasks.ValueMember = "Value";
                lstTasks.DataSource = new BindingSource(tasks, null);

                lstTasks.SelectedIndex = -1;
                txtTask.ResetText();
            }

        }

        private void btnRemoveTask_Click(object sender, EventArgs e)
        {
            if(lstTasks.SelectedIndex == -1)
            {
                MessageBox.Show("You must select a task to remove.");
            }
            else if(tasks.Count == 0)
            {
                MessageBox.Show("There are no task to remove.");
            }
            else
            {
                //remove here
            }
        }

        private void btnPrintAll_Click(object sender, EventArgs e)
        {
            if(tasks.Count != 0)
            {
                string msg = string.Empty;

                foreach (var item in tasks)
                {
                    msg += $"{item.Key.ToString("MM'/'dd'/'yyyy")} {item.Value}\n";
                }

                MessageBox.Show(msg);
            }
            else
            {
                MessageBox.Show("There is nothing to pront.");
            }
        }

        #endregion

        #region Events

        private void lstTasks_SelectedValueChanged(object sender, EventArgs e)
        {
            //int position = tasks.IndexOfKey(lstTasks.SelectedItem);
            if(lstTasks.SelectedIndex == -1)
            {
                lblTaskDetails.ResetText();
            }
            else
            {
                lblTaskDetails.Text = lstTasks.SelectedValue.ToString();
            }
            
        }

        #endregion

    }
}
