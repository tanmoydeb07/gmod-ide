using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GModIDE.Classes;

namespace LanguagePacker
{
    public partial class AddEditDialog : Form
    {
        public AddEditDialog()
        {
            InitializeComponent();
        }

        private void AddEditDialog_Load(object sender, EventArgs e)
        {
            //Icon
            Icon = SilkHandler.ToIcon(LanguagePacker.Properties.Resources.textfield);
        }

        public static KeyValuePair<String, String> EditExistingPair(KeyValuePair<String,String> cur)
        {
            AddEditDialog aed = new AddEditDialog();
            
            aed.txtName.Text = cur.Key;
            aed.txtTrans.Text = cur.Value;

            if (aed.ShowDialog() == DialogResult.Cancel) {
                return cur;
            }

            return new KeyValuePair<string, string>(aed.txtName.Text, aed.txtTrans.Text);
        }

        public static KeyValuePair<String, String> AddPair()
        {
            AddEditDialog aed = new AddEditDialog();

            if (aed.ShowDialog() == DialogResult.Cancel)
            {
                return new KeyValuePair<string, string>("", "");
            }

            return new KeyValuePair<string, string>(aed.txtName.Text, aed.txtTrans.Text);
        }

        private const int CP_NOCLOSE_BUTTON = 0x200;
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams myCp = base.CreateParams;
                myCp.ClassStyle = myCp.ClassStyle | CP_NOCLOSE_BUTTON;
                return myCp;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtName.Text == "")
            {
                MessageBox.Show("You must enter a translation name!", "Darn!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            else if (txtTrans.Text == "")
            {
                MessageBox.Show("You must enter a translation result!", "Darn!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DialogResult = System.Windows.Forms.DialogResult.OK;

            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.Cancel;
            Close();
        }

        private void enter()
        {
            btnSave_Click(this, new EventArgs());
        }

        private void AddEditDialog_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) { enter(); }
        }

        private void txtName_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) { enter(); }
        }

        private void txtTrans_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) { enter(); }
        }

        private void btnSave_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) { enter(); }
        }

        private void btnCancel_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) { btnCancel_Click(this, new EventArgs()); }
        }
    }
}
