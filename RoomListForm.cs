using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RoomList
{
    public partial class RoomListForm : Form
    {
        public RoomListForm()
        {
            InitializeComponent();
        }

        private void RoomListForm_Load(object sender, EventArgs e)
        {
            //test용 -> 원래는 서버에서 가져온 정보들로 출력
            string[] row0 = { "방1", "접속 인원 3 / 5" };
            string[] row1 = { "방2", "접속 인원 4 / 5" };
            string[] row2 = { "방3", "접속 인원 2 / 5" };

            dataGridView1.Rows.Add(row0);
            dataGridView1.Rows.Add(row1);
            dataGridView1.Rows.Add(row2);

            foreach (DataGridViewRow row in dataGridView1.Rows)
                row.Cells[2].Value = "입장하기";
        }
    }
}
