﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TQ
{
    public partial class MainForm : MetroFramework.Forms.MetroForm // 상속 클래스 변경
    {

        public MainForm()
        {

            InitializeComponent();
        }
        private void loginBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            LoginForm login = new LoginForm();
            login.ShowDialog();
            this.Close();

        }
    }
}
