using BootMaster_;

namespace BudMayster_.Core.GUI
{
    public partial class KNAYF : Form
    {
        public KNAYF()
        {
            InitializeComponent();
            контрагентиToolStripMenuItem.Click += (sender, e) => General.контрагентиToolStripMenuItem_Click(sender, e, this);
            загальнийToolStripMenuItem.Click += (sender, e) => General.загальнийToolStripMenuItem_Click(sender, e, this);
            вихідToolStripMenuItem.Click += (sender, e) => General.вихідToolStripMenuItem_Click(sender, e);
            btn_supp.Click += (sender, e) => General.btn_supp_Click(sender, e, this);
            товариToolStripMenuItem.Click += (sender, e) => General.товариToolStripMenuItem_Click(sender, e, this);
            btn_goods.Click += (sender, e) => General.btn_goods_Click(sender, e, this);
        }

        private void btn_grunt_Click(object sender, EventArgs e)
        {
            General.previousLocation = General.GetLocation(this);
            Grunt gruntForm = new Grunt()
            {
                StartPosition = FormStartPosition.Manual,
                Location = General.previousLocation
            };
            gruntForm.Show();
            this.Hide();
        }

        private void btn_grunt_folder_Click(object sender, EventArgs e)
        {
            General.previousLocation = General.GetLocation(this);
            Grunt gruntForm = new Grunt()
            {
                StartPosition = FormStartPosition.Manual,
                Location = General.previousLocation
            };
            gruntForm.Show();
            this.Hide();
        }
    }
}
