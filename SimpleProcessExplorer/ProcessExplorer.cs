using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace ProcessExplorer
{
    public partial class ProcessExplorer : Form
    {
        public ProcessExplorer() =>  InitializeComponent();
        private void RefreshButton(object sender, EventArgs e) => UpdateProcessList();
        private void AppLoading(object sender, EventArgs e) => UpdateProcessList();
        private void QuitButton(object sender, EventArgs e)
        {
            if (MessageBox.Show("Voulez-vous quitter?", "Confirmation", MessageBoxButtons.YesNo) == DialogResult.Yes)
                Application.Exit();
        }
        private void KillButton(object sender, EventArgs e)
        {
            string process = listBox1.SelectedItem.ToString();

            if (MessageBox.Show("Voulez-vous fermer le processus " + process + " ?", "Confirmation", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                bool killedSomething = Tools.KillProcess(process);
                if (killedSomething) MessageBox.Show(process + " a été tué", "Information");
                else MessageBox.Show("Erreur dans la tentative de tuer " + process, "Information");
            }
        }
        private void UpdateProcessList()
        {
            int i = 0;
            foreach (string process in Tools.ListProcess())
            {
                if (!listBox1.Items.Contains(process))
                    listBox1.Items.Insert(i++, process);
            }
        }

    }
}
