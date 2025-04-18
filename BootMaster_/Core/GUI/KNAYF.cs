using BootMaster_;
using BudMayster_.Core.Classes;

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

        private void btnMenu1_Click(object sender, EventArgs e)
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

        private void btn_supp_Click(object sender, EventArgs e)
        {
            General.previousLocation = General.GetLocation(this);
            Kontragents kontragentsfForm = new Kontragents()
            {
                StartPosition = FormStartPosition.Manual,
                Location = General.previousLocation
            };
            kontragentsfForm.Show();
            this.Hide();
        }

        private void KNAYF_Load(object sender, EventArgs e)
        {
            LoadCategories();
            LoadCategoriesMenu();
        }

        public void LoadCategoriesMenu()
        {
            var connection = new DatabaseConnection(Constants.Instance.connection);
            List<string> categoriesMenu = Categories.GetCategories(connection);

            for (int i = 0; i < categoriesMenu.Count && i < 12; i++)
            {
                var button = this.Controls.Find($"btnMenu{i + 1}", true).FirstOrDefault() as Button;
                if (button != null)
                {
                    button.Text = categoriesMenu[i];
                }
            }
        }

        public void LoadCategories()
        {
            var connection = new DatabaseConnection(Constants.Instance.connection);
            List<string> categories = Categories.GetCategories(connection);

            for (int i = 0; i < categories.Count && i < 12; i++)
            {
                var button = this.Controls.Find($"btnСateg{i + 1}", true).FirstOrDefault() as System.Windows.Forms.Button;
                if (button != null)
                {
                    button.Text = categories[i];
                }
            }
        }
    }
}
