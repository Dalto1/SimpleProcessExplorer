using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace ProcessExplorer
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int i = 0;
            foreach (Process proc in Process.GetProcesses())
            {
                string process = UppercaseFirst(proc.ProcessName);
                if (!listBox1.Items.Contains(process))
                {
                    listBox1.Items.Insert(i, process);
                    i++;
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Voulez-vous quitter?", "Confirmation", MessageBoxButtons.YesNo) == DialogResult.Yes)
                Application.Exit();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            String processToKill = listBox1.SelectedItem.ToString();

            if (MessageBox.Show("Voulez-vous fermer le processus " + processToKill + " ?", "Confirmation", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {

                bool killedSomething = false;
                try
                {
                    foreach (Process P in Process.GetProcessesByName(processToKill))
                    {
                        try
                        {
                            P.Kill();
                            killedSomething = true;
                        }
                        catch { }
                    }
                }
                catch { }
                if (killedSomething) MessageBox.Show(processToKill + " a été tué", "Information");
                else MessageBox.Show("Erreur dans la tentative de tuer " + processToKill, "Information");
            }
        }
        static string UppercaseFirst(string s)
        {
            if (string.IsNullOrEmpty(s))
            {
                return string.Empty;
            }
            return char.ToUpper(s[0]) + s.Substring(1);
        }
    }
}
