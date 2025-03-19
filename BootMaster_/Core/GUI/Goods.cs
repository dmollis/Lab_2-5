<<<<<<< HEAD
﻿using BootMaster_;
using BudMayster.Classes;
using BudMayster_.Core.Classes;
using MySql.Data.MySqlClient;
=======
﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
>>>>>>> e53e0cd (Add Goods Form Design)

namespace BudMayster_.Core.GUI
{
    public partial class Goods : Form
    {
        public Goods()
        {
            InitializeComponent();
<<<<<<< HEAD
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
                var button = this.Controls.Find($"btnMenu{i + 1}", true).FirstOrDefault() as Button;
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
                var button = this.Controls.Find($"btnСateg{i + 1}", true).FirstOrDefault() as Button;
                if (button != null)
                {
                    button.Text = categories[i];
                }
            }
=======
        }

        private void button47_Click(object sender, EventArgs e)
        {

        }

        private void vScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {

>>>>>>> e53e0cd (Add Goods Form Design)
        }
    }
}
