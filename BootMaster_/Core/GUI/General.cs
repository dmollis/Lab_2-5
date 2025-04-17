using BudMayster_.Core.GUI;

namespace BootMaster_
{
    public partial class General : Form
    {
        public static Point previousLocation;

        public General()
        {
            InitializeComponent();
            товариToolStripMenuItem.Click += (sender, e) => товариToolStripMenuItem_Click(sender, e, this);
            контрагентиToolStripMenuItem.Click += (sender, e) => контрагентиToolStripMenuItem_Click(sender, e, this);
            вихідToolStripMenuItem.Click += (sender, e) => вихідToolStripMenuItem_Click(sender, e);
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
            OpenForm(new Kontragents(), currentForm);
        }

        public static void btn_goods_Click(object sender, EventArgs e, Form currentForm)
        {
            OpenForm(new Goods(), currentForm);
        }

        public static void контрагентиToolStripMenuItem_Click(object sender, EventArgs e, Form currentForm)
        {
            OpenForm(new Kontragents(), currentForm);
        }

        public static void товариToolStripMenuItem_Click(object sender, EventArgs e, Form currentForm)
        {
            OpenForm(new Goods(), currentForm);
        }

        public static void загальнийToolStripMenuItem_Click(object sender, EventArgs e, Form currentForm)
        {
            OpenForm(new General(), currentForm);
        }

        public static void вихідToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void файлToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
