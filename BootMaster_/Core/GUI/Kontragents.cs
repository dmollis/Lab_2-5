using BootMaster_;
using BudMayster_.Core.Classes;

namespace BudMayster_.Core.GUI
{
    public partial class Kontragents : Form
    {
        public Kontragents()
        {
            InitializeComponent();
            товариToolStripMenuItem.Click += (sender, e) => General.товариToolStripMenuItem_Click(sender, e, this);
            загальнийToolStripMenuItem.Click += (sender, e) => General.загальнийToolStripMenuItem_Click(sender, e, this);
            вихідToolStripMenuItem.Click += (sender, e) => General.вихідToolStripMenuItem_Click(sender, e);
            btn_goods.Click += (sender, e) => General.btn_goods_Click(sender, e, this);
        }

        private void btnKontr1_Click(object sender, EventArgs e)
        {
            General.previousLocation = General.GetLocation(this);
            Suppliers suppForm = new Suppliers()
            {
                StartPosition = FormStartPosition.Manual,
                Location = General.previousLocation
            };
            suppForm.Show();
            this.Hide();
        }

        private void btnMenu1_Click(object sender, EventArgs e)
        {
            General.previousLocation = General.GetLocation(this);
            Suppliers suppForm = new Suppliers()
            {
                StartPosition = FormStartPosition.Manual,
                Location = General.previousLocation
            };
            suppForm.Show();
            this.Hide();
        }

        private void Suppliers_Load(object sender, EventArgs e)
        {
            LoadKontr();
            LoadKontrMenu();
        }

        public void LoadKontrMenu()
        {
            List<string> kontrMenu = Categories.GetKontr();

            for (int i = 0; i < kontrMenu.Count && i < 3; i++)
            {
                var button = this.Controls.Find($"btnMenu{i + 1}", true).FirstOrDefault() as Button;
                if (button != null)
                {
                    button.Text = kontrMenu[i];
                }
            }
        }

        public void LoadKontr()
        {
            List<string> categories = Categories.GetKontr();

            for (int i = 0; i < categories.Count && i < 3; i++)
            {
                var button = this.Controls.Find($"btnKontr{i + 1}", true).FirstOrDefault() as Button;
                if (button != null)
                {
                    button.Text = categories[i];
                }
            }
        }
    }
}
