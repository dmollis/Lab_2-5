using BootMaster_;

namespace BudMayster_.Core.GUI
{
    public partial class Goods : Form
    {
        public Goods()
        {
            InitializeComponent();
            контрагентиToolStripMenuItem.Click += (sender, e) => General.контрагентиToolStripMenuItem_Click(sender, e, this);
            загальнийToolStripMenuItem.Click += (sender, e) => General.загальнийToolStripMenuItem_Click(sender, e, this);
            вихідToolStripMenuItem.Click += (sender, e) => General.вихідToolStripMenuItem_Click(sender, e);
            btn_supp.Click += (sender, e) => General.btn_supp_Click(sender, e, this);
        }

        private void btn_knauf_Click(object sender, EventArgs e)
        {
            General.previousLocation = General.GetLocation(this);
            KNAYF knaufForm = new KNAYF()
            {
                StartPosition = FormStartPosition.Manual,
                Location = General.previousLocation
            };
            knaufForm.Show();
            this.Hide();
        }

        private void btn_knauf_folder_Click(object sender, EventArgs e)
        {
            General.previousLocation = General.GetLocation(this);
            KNAYF knaufForm = new KNAYF()
            {
                StartPosition = FormStartPosition.Manual,
                Location = General.previousLocation
            };
            knaufForm.Show();
            this.Hide();
        }
    }
}
