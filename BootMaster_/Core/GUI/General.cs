using BudMayster_.Core.GUI;

namespace BootMaster_
{
    public partial class General : Form
    {
        public static Point previousLocation;

        public General()
        {
            InitializeComponent();
            ÚÓ‚‡ËToolStripMenuItem.Click += (sender, e) => ÚÓ‚‡ËToolStripMenuItem_Click(sender, e, this);
            ÍÓÌÚ‡„ÂÌÚËToolStripMenuItem.Click += (sender, e) => ÍÓÌÚ‡„ÂÌÚËToolStripMenuItem_Click(sender, e, this);
            ‚Ëı≥‰ToolStripMenuItem.Click += (sender, e) => ‚Ëı≥‰ToolStripMenuItem_Click(sender, e);
            btn_supp.Click += (sender, e) => btn_supp_Click(sender, e, this);
            btn_goods.Click += (sender, e) => btn_goods_Click(sender, e, this);
        }

        public static void OpenForm(Form newForm, Form currentForm)
        {
            previousLocation = currentForm.Location;
            newForm.StartPosition = FormStartPosition.Manual;
            newForm.Location = previousLocation;
            newForm.Show();
            currentForm.Hide();
        }

        public static Point GetLocation(Form form)
        {
            return form.Location;
        }

        public static void btn_supp_Click(object sender, EventArgs e, Form currentForm)
        {
            OpenForm(new Suppliers(), currentForm);
        }

        public static void btn_goods_Click(object sender, EventArgs e, Form currentForm)
        {
            OpenForm(new Goods(), currentForm);
        }

        public static void ÍÓÌÚ‡„ÂÌÚËToolStripMenuItem_Click(object sender, EventArgs e, Form currentForm)
        {
            OpenForm(new Suppliers(), currentForm);
        }

        public static void ÚÓ‚‡ËToolStripMenuItem_Click(object sender, EventArgs e, Form currentForm)
        {
            OpenForm(new Goods(), currentForm);
        }

        public static void Á‡„‡Î¸ÌËÈToolStripMenuItem_Click(object sender, EventArgs e, Form currentForm)
        {
            OpenForm(new General(), currentForm);
        }

        public static void ‚Ëı≥‰ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
