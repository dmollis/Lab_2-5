using BootMaster_;

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
    }
}
