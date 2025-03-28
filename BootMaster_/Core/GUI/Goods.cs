using BootMaster_;
using BudMayster_.Core.Classes;

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

        private void Goods_Load(object sender, EventArgs e)
        {
            Scroll();
            LoadCategories();
            LoadCategoriesMenu();
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

        private void Scroll()
        {
            panel2.AutoScroll = true;
            vScrollBar1.Visible = true;
            panel2.Height = 683;
            vScrollBar1.Maximum = panel2.Height;
            vScrollBar1.LargeChange = 50;
        }

        public void LoadCategoriesMenu()
        {
            List<string> categoriesMenu = Categories.GetCategories();

            for (int i = 0; i < categoriesMenu.Count && i < 12; i++)
            {
                var button = this.Controls.Find($"btnMenu{i + 1}", true).FirstOrDefault() as System.Windows.Forms.Button;
                if (button != null)
                {
                    button.Text = categoriesMenu[i];
                }
            }
        }

        public void LoadCategories()
        {
            List<string> categories = Categories.GetCategories();

            for (int i = 0; i < categories.Count && i < 12; i++)
            {
                var button = this.Controls.Find($"btnСateg{i + 1}", true).FirstOrDefault() as System.Windows.Forms.Button;
                if (button != null)
                {
                    button.Text = categories[i];
                }
            }
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
    }
}
