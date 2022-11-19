using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UserMaintenance.Entities;

namespace UserMaintenance
{
    public partial class Form1 : Form
    {
        BindingList<User> users = new BindingList<User>();


        public Form1()
        {
            InitializeComponent();

            lblFullName.Text = Resource1.FullName;
            btnAdd.Text = Resource1.Add;
            btnFajlba.Text = Resource1.FajlbaIras;
            btnTorles.Text = Resource1.Torles;

            listUsers.DataSource = users;
            listUsers.ValueMember = "ID";
            listUsers.DisplayMember = "FullName";

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var u = new User()
            {

                FullName = txtFullName.Text
            };
            users.Add(u);
        }

        private void btnFajlba_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                using(StreamWriter sw = new StreamWriter(sfd.FileName))
                {
                    foreach(User item in users)
                    {
                        sw.WriteLine(item.ID + ";" + item.FullName);
                    }
                }
            }
        }

        private void btnTorles_Click(object sender, EventArgs e)
        {
            User valasztottUser = (User)listUsers.SelectedItem;
            users.Remove(valasztottUser);
        }
    }
}
