using BootMaster_;
using BudMayster.Classes;
using BudMayster_.Core.Classes;

namespace BudMayster_.Core.GUI
{
    public partial class Grunt : Form
    {
        public Grunt()
        {
            InitializeComponent();
            контрагентиToolStripMenuItem.Click += (sender, e) => General.контрагентиToolStripMenuItem_Click(sender, e, this);
            загальнийToolStripMenuItem.Click += (sender, e) => General.загальнийToolStripMenuItem_Click(sender, e, this);
            вихідToolStripMenuItem.Click += (sender, e) => General.вихідToolStripMenuItem_Click(sender, e);
            btn_supp.Click += (sender, e) => General.btn_supp_Click(sender, e, this);
            товариToolStripMenuItem.Click += (sender, e) => General.товариToolStripMenuItem_Click(sender, e, this);
            btn_goods.Click += (sender, e) => General.btn_goods_Click(sender, e, this);
        }

        private void Grunt_Load(object sender, EventArgs e)
        {
            Scroll();
            LoadCategoriesMenu();
            LoadMaterials();
        }

        private void Scroll()
        {
            panel1.AutoScroll = true;
            vScrollBar2.Visible = true;
            panel1.Height = 515;
            vScrollBar2.Maximum = panel2.Height;
            vScrollBar2.LargeChange = 50;
            hScrollBar1.Visible = true;
            panel1.Width = 185;
            hScrollBar1.Maximum = panel1.Width;
            hScrollBar1.LargeChange = 50;
        }

        public void LoadCategoriesMenu()
        {
            List<string> categoriesMenu = Categories.GetCategories();

            for (int i = 0; i < categoriesMenu.Count && i < 12; i++)
            {
                var button = this.Controls.Find($"btnMenu{i + 1}", true).FirstOrDefault() as Button;
                if (button != null)
                {
                    button.Text = categoriesMenu[i];
                }
            }
        }

        public void LoadMaterials()
        {
            List<Material> materials = Material.GetMaterialsInj();

            for (int i = 0; i < materials.Count && i < 9; i++)
            {
                var id = this.Controls.Find($"txtId{i + 1}", true).FirstOrDefault() as TextBox;
                var name = this.Controls.Find($"txtName{i + 1}", true).FirstOrDefault() as TextBox;
                var quantity = this.Controls.Find($"txtQuant{i + 1}", true).FirstOrDefault() as TextBox;
                var priceZakup = this.Controls.Find($"txtPriceZakup{i + 1}", true).FirstOrDefault() as TextBox;
                var percZakup = this.Controls.Find($"txtPercZakup{i + 1}", true).FirstOrDefault() as TextBox;
                var priceOpt = this.Controls.Find($"txtPriceOpt{i + 1}", true).FirstOrDefault() as TextBox;
                var percOpt = this.Controls.Find($"txtPercOpt{i + 1}", true).FirstOrDefault() as TextBox;
                var priceProd = this.Controls.Find($"txtPriceProd{i + 1}", true).FirstOrDefault() as TextBox;

                if (id != null) id.Text = materials[i].ID.ToString();
                if (name != null) name.Text = materials[i].Name;
                if (quantity != null) quantity.Text = materials[i].Quantity.ToString();
                if (priceZakup != null) priceZakup.Text = materials[i].Price_zakup.ToString("F2");
                if (percZakup != null) percZakup.Text = materials[i].Percent_zakup.ToString("F1");
                if (priceOpt != null) priceOpt.Text = materials[i].Price_opt.ToString("F2");
                if (percOpt != null) percOpt.Text = materials[i].Percent_opt.ToString("F1");
                if (priceProd != null) priceProd.Text = materials[i].Price_prod.ToString("F2");
            }
        }
    }
}
