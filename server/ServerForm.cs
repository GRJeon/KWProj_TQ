using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ServerProgram
{
    public class ServerForm : Form
    {
        private System.ComponentModel.IContainer components;

        /// <summary>
        ///  Form에 로그를 출력할 때 사용할 수 있다. override 필요
        /// </summary>
        public virtual void PrintLog(string content)
        {

        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // ServerForm
            // 
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Name = "ServerForm";
            this.ResumeLayout(false);

        }
    }
}
