using System.Formats.Asn1;
using System.Net;
using System.Net.Sockets;

namespace ClientProgram
{

    public partial class Form1 : ClientForm
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            TryConnectServer();
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            TryConnectServer();
        }
        /*
        public override void ViewRoom(int room)
        {
            tbRoomNum.Text = room.ToString();
        }
        */
        public override void SignIn(string username)
        {
            if (username != string.Empty)
            {
                client.username = username;
                ShowMessageBox("�α��� ����");
            }
            else
            {
                ShowMessageBox("�α��� ����");
            }
        }

        public override void SignUp(bool success)
        {
            if (success)
            {
                ShowMessageBox("ȸ������ ����");
            }
            else
            {
                ShowMessageBox("ȸ������ ����");
            }
        }
        
        public override void RoomList(List<string> roomList)
        {
            tbRoomList.Text = "";

            foreach (string room in roomList)
            {
                string[] roomInfo = room.Split(',');
                string roomName = roomInfo[0];
                string playerCount = roomInfo[1];
                string roomMax = roomInfo[2];

                tbRoomList.Text = tbRoomList.Text + string.Format("{0} - {1}/{2}\r\n", roomName, playerCount, roomMax);
            }
        }

        public override void RoomCreate(bool success)
        {
            if (success)
            {
                ShowMessageBox("�� ���� ����");
            }
            else
            {
                ShowMessageBox("�� ���� ����");
            }
        }

        public override void RoomJoin(string result)
        {
            if (result.Equals("-1"))
            {
                ShowMessageBox("�������� �ʴ� ���Դϴ�.");
            }
            else if (result.Equals("-2"))
            {
                ShowMessageBox("������ ���� á���ϴ�.");
            }
            else
            {
                client.RequestSendRoomChat("�ý���", client.username + "��(��) �濡 ������");
                ShowMessageBox(result + " �濡 �����Ϸ�");
            }
        }

        public override void RoomOut()
        {
            ShowMessageBox("�� ����");
        }

        /*
        public override void RoomChat(List<string> chatList)
        {
            tbRoomChat.Text = "";
            chatList.ForEach(chat =>
            {
                tbRoomChat.Text += chat + "\r\n";
            });
        }
        */
        private void btnViewRoomNum_Click(object sender, EventArgs e)
        {
            client.RequestGetRoom();
        }
        /*
        private void btnChangeRoomNum_Click(object sender, EventArgs e)
        {
            int newRoom = 0;
            if (int.TryParse(tbRoomNum.Text, out newRoom))
            {
                client.RequestSetRoom(newRoom);
            }
        }
        */
        private void btnSignIn_Click(object sender, EventArgs e)
        {
            string username = tbUsername.Text;
            string password = tbPassword.Text;

            if (username != string.Empty && password != string.Empty)
            {
                client.RequestSignIn(username, password);
            }
        }

        private void btnSignUp_Click(object sender, EventArgs e)
        {
            string username = tbUsername.Text;
            string password = tbPassword.Text;

            if (username != string.Empty && password != string.Empty)
            {
                client.RequestSignUp(username, password);
            }
        }

        private void btnRefreshRoomList_Click(object sender, EventArgs e)
        {
            client.RequestRoomList();
        }

        private void btnRoomCreate_Click(object sender, EventArgs e)
        {
            string roomName = tbRoomName.Text;
            string roomMax = tbRoomCount.Text;

            if (roomName != string.Empty && roomMax != string.Empty)
            {
                int num = 0;
                if (int.TryParse(tbRoomCount.Text, out num))
                {
                    client.RequestRoomCreate(roomName, roomMax);
                }
            }
        }

        private void btnJoinRoom_Click(object sender, EventArgs e)
        {
            string roomName = tbRoomName.Text;

            if (roomName != string.Empty)
            {
                client.RequestRoomJoin(roomName);
            }
        }
        private void btnOutRoom_Click(object sender, EventArgs e)
        {
            client.RequestRoomOut();
        }

        private void mainLogin_btn_Click(object sender, EventArgs e)
        {
            login_panel.Visible = true;
        }

        private void login_btn_Click(object sender, EventArgs e)
        {
            login_panel.Visible = false;
            gameStart_panel.Visible = true;
            welcom_label.Text = String.Format("{0} �� ȯ���մϴ�:)", tbUsername.Text);
        }

        private void gameStart_btn_Click(object sender, EventArgs e)
        {
            gameStart_panel.Visible = false;
            roomList_panel.Visible = true;
        }

        private void roomList_panel_VisibleChanged(object sender, EventArgs e)
        {
            mainTitle_label.Visible = true;
            comein_label.Visible = true;
            comein_label.Text = String.Format("{0} �� ���� ��", tbUsername.Text);
        }

        private void makeRoom_btn_Click(object sender, EventArgs e)
        {
            roomPeople_label.Visible = true;
            tbRoomCount.Visible = true;
            btnRoomCreate.Visible = true;
        }

        /*
        private void btnSend_Click(object sender, EventArgs e)
        {
            string content = tbMessage.Text;
            if (content != string.Empty)
            {
                client.RequestSendRoomChat(client.username, content);
                tbMessage.Text = "";
            }
        }
        */
    }
}