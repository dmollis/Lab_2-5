using BootMaster_;
using BudMayster_.Core.Classes;

namespace BudMayster_.Core.GUI
{
    public partial class Suppliers : Form
    {
        public Suppliers()
        {
            InitializeComponent();
            товариToolStripMenuItem.Click += (sender, e) => General.товариToolStripMenuItem_Click(sender, e, this);
            загальнийToolStripMenuItem.Click += (sender, e) => General.загальнийToolStripMenuItem_Click(sender, e, this);
            вихідToolStripMenuItem.Click += (sender, e) => General.вихідToolStripMenuItem_Click(sender, e);
            btn_goods.Click += (sender, e) => General.btn_goods_Click(sender, e, this);
        }

        private void btn_kontr_menu_Click(object sender, EventArgs e)
        {
            General.previousLocation = General.GetLocation(this);
            Kontragents kontrForm = new Kontragents()
            {
                StartPosition = FormStartPosition.Manual,
                Location = General.previousLocation
            };
            kontrForm.Show();
            this.Hide();
        }

        private void Suppliers_Load(object sender, EventArgs e)
        {
            LoadSupp();
            LoadSuppMenu();
        }

        public void LoadSuppMenu()
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

        public void LoadSupp()
        {
            List<Supplier> supp = Supplier.GetSupplier();

            for (int i = 0; i < supp.Count && i < 6; i++)
            {
                var id = this.Controls.Find($"txtId{i + 1}", true).FirstOrDefault() as TextBox;
                var name = this.Controls.Find($"txtName{i + 1}", true).FirstOrDefault() as TextBox;
                var contact_info = this.Controls.Find($"txtTelNumb{i + 1}", true).FirstOrDefault() as TextBox;

                if (id != null) id.Text = supp[i].ID.ToString();
                if (name != null) name.Text = supp[i].Name;
                if (contact_info != null) contact_info.Text = supp[i].Contact_info;
            }
        }
    }
}
