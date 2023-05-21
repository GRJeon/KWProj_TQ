﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace client
{
    public partial class MainForm : ClientForm
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            //TryConnectServer();
        }

        /// <summary>
        /// 메인 화면에서 로그인 화면으로 넘어가는 이벤트
        /// </summary>
        private void main_login_btn_Click(object sender, EventArgs e)
        {
            panel1_login_server.Visible = true;
            p1_username_tbx.Text = null;
            p1_pw_tbx.Text = null;
        }

        #region panel1_login: 서버 연결 panel
        /// <summary>
        /// 서버 연결하기 버튼 클릭 시 이벤트
        /// 아무것도 입력하지 않으면 팝업 띄움.
        /// 그게 아니라면, 서버 연결하고 로그인 패널로 넘어감
        /// </summary>
        private void p1_connect_btn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(p1_ip_tbx.Text))
            {
                ShowMessageBox("IP를 입력해주세요", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                TryConnectServer(p1_ip_tbx.Text);
                p1_1_login_panel.Invoke(new MethodInvoker(delegate { p1_1_login_panel.Visible = true; }));
                p1_login_btn.Invoke(new MethodInvoker(delegate { p1_1_login_panel.Visible = true; }));
                //                p1_1_login_panel.Visible = true;
                //                p1_login_btn.Visible = true;
            }
        }

        private void p1_ip_tbx_KeyPress(object sender, KeyPressEventArgs e)
        {
            // 숫자, 백스페이스, '.'만 입력 가능
            if (!(char.IsDigit(e.KeyChar) || e.KeyChar == Convert.ToChar(Keys.Back) || e.KeyChar == 46))
            {
                e.Handled = true;
            }
        }

        public override void ConnectServerResult(bool success)
        {
            if (success)
            {
                //연결 성공
                p1_connect_btn.Invoke(new MethodInvoker(delegate { p1_connect_btn.Visible = false; }));
                p1_login_btn.Invoke(new MethodInvoker(delegate { p1_login_btn.Visible = true; }));
                /*
                p1_connect_btn.Visible = false;
                p1_login_btn.Visible = true;
                */
            }
            else
            {
                //연결 실패
                ShowMessageBox("서버 연결 실패", "Fail", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region panel1-1: 서버 연결 후 로그인 panel
        /// <summary>
        /// 기존의 서버 연결하는 패널 위로 로그인 패널이 나타남
        /// </summary>
        private void p1_1_login_panel_VisibleChanged(object sender, EventArgs e)
        {
            p1_signUp_btn.Invoke(new MethodInvoker(delegate { p1_signUp_btn.Visible = true; }));
            p1_login_btn.Invoke(new MethodInvoker(delegate { p1_login_btn.Visible = true; }));
            p2_gameStart_btn.Invoke(new MethodInvoker(delegate { p2_gameStart_btn.Visible = false; }));
            /*
            p1_signUp_btn.Visible = true;
            p1_login_btn.Visible = true;
            */
        }

        /// <summary>
        /// 로그인 버튼을 눌렀을 때, 각 경우에 따라 다른 팝업 창 띄움
        /// </summary>
        static string message;
        readonly object locker = new object();
        bool islock = false;


        public override void SignUp(bool success)
        {
            lock (locker)
            {
                islock = true;
                if (success)
                    message = "success";
                else
                    message = "failed";
                islock = false;
                Monitor.Pulse(locker);
            }
        }

        private void p1_signUp_btn_Click(object sender, EventArgs e)
        {
            string username = p1_pw_tbx.Text;
            string password = p1_username_tbx.Text;
            DialogResult result;

            if (username != string.Empty && password != string.Empty)
            {
                client.RequestSignUp(username, password);
            }
            // 이름, 비번 둘 중 하나라도 입력하지 않으면 팝업 띄움
            if (string.IsNullOrEmpty(p1_username_tbx.Text) || string.IsNullOrEmpty(p1_pw_tbx.Text))
            {
                ShowMessageBox("이름과 비밀번호를 정확히 입력해주세요.", "Login Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            // 입력 정보가 맞는 지 확인하는 팝업 띄움
            // 팝업에 Yes, No 버튼이 있음. No가 입력되면 다시 입력 창으로 되돌아감 
            else
            {
                string nameCheck = string.Format("당신은 {0} 님이 맞습니까?", p1_username_tbx.Text);
                var name_messageRes = MessageBox.Show(nameCheck, "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (name_messageRes == DialogResult.No)
                {
                    return;
                }
                else
                {
                    name_messageRes = DialogResult.Yes;
                }

                string pwCheck = string.Format("비밀번호는 {0} 이 맞습니까?", p1_pw_tbx.Text);
                var pw_messageRes = MessageBox.Show(pwCheck, "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (pw_messageRes == DialogResult.No)
                {
                    return;
                }
                else
                {
                    pw_messageRes = DialogResult.Yes;
                    result = DialogResult.Yes;
                }

                if (result == DialogResult.Yes)
                {

                    client.RequestSignUp(p1_username_tbx.Text, p1_pw_tbx.Text);
                    islock = true;
                    lock (locker)
                    {
                        while (islock == true)
                        {
                            Monitor.Wait(locker);
                        }
                    }
                    if (message.Equals("success"))
                    {
                        MessageBox.Show("회원가입 성공", "Success", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    }
                    else
                    {
                        MessageBox.Show("이미 가입되어 있습니다.", "SignUp", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }


        public override void SignIn(string username)
        {
            lock (locker)
            {
                islock = true;
                message = username;
                islock = false;
                Monitor.Pulse(locker);
            }
        }

        private void p1_login_btn_Click(object sender, EventArgs e)
        {
            // 로그인 버튼 눌렀을 때 유효성 검사
            string username = p1_username_tbx.Text;
            string password = p1_pw_tbx.Text;
            DialogResult result = DialogResult.None;

            // 이름, 비번 둘 중 하나라도 입력하지 않으면 팝업 띄움
            if (string.IsNullOrEmpty(p1_username_tbx.Text) || string.IsNullOrEmpty(p1_pw_tbx.Text))
            {
                ShowMessageBox("이름과 비밀번호를 정확히 입력해주세요.", "Login Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            // 입력 정보가 맞는 지 확인하는 팝업 띄움
            // 팝업에 Yes, No 버튼이 있음. No가 입력되면 다시 입력 창으로 되돌아감 
            else
            {
                string nameCheck = string.Format("당신은 {0} 님이 맞습니까?", p1_username_tbx.Text);
                var name_messageRes = MessageBox.Show(nameCheck, "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (name_messageRes == DialogResult.No)
                {
                    return;
                }
                else
                {
                    name_messageRes = DialogResult.Yes;
                }

                string pwCheck = string.Format("비밀번호는 {0} 이 맞습니까?", p1_pw_tbx.Text);
                var pw_messageRes = MessageBox.Show(pwCheck, "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (pw_messageRes == DialogResult.No)
                {
                    return;
                }
                else
                {
                    pw_messageRes = DialogResult.Yes;
                }

                if (pw_messageRes == DialogResult.Yes && name_messageRes == DialogResult.Yes)
                {
                    result = DialogResult.Yes;
                }
            }

            // 모든 정보가 맞을 때, 게임 시작 패널로 넘어감
            if (result == DialogResult.Yes)
            {
                client.RequestSignIn(p1_username_tbx.Text, p1_pw_tbx.Text);
                islock = true;
                lock (locker)
                {
                    while (islock == true)
                    {
                        Monitor.Wait(locker);
                    }
                }
                if (message.Equals(p1_username_tbx.Text))
                {
                    //p1_gameStart_btn.Invoke(new MethodInvoker(delegate { p1_gameStart_btn.Visible = true; }));
                    panel1_login_server.Invoke(new MethodInvoker(delegate { panel1_login_server.Visible = false; }));
                    panel2_gameStart.Invoke(new MethodInvoker(delegate { panel2_gameStart.Visible = true; }));
                }
                else
                {
                    MessageBox.Show("Failed", "Login", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }

        }
        #endregion

        #region panel2_gameStart: 로그아웃, 게임시작 가능

        private void p2_logout_btn_Click(object sender, EventArgs e)
        {
            panel2_gameStart.Invoke(new MethodInvoker(delegate { panel2_gameStart.Visible = false; }));
            p2_gameStart_btn.Invoke(new MethodInvoker(delegate { p2_logout_btn.Visible = false; }));
            p1_1_login_panel.Invoke(new MethodInvoker(delegate { p1_1_login_panel.Visible = true; }));

            //panel2_gameStart.Visible = false;
            //p2_gameStart_btn.Visible = false;
            //p1_1_login_panel.Visible = true;

        }

        /// <summary>
        /// 입력 받은 username을 가져와서 문구 출력
        /// </summary>
        private void panel2_gameStart_VisibleChanged(object sender, EventArgs e)
        {
            p2_welcome__label.Text = String.Format("{0} 님 환영합니다:)", p1_username_tbx.Text);
            p2_gameStart_btn.Visible = true;
            p2_logout_btn.Visible = true;
        }

        private void p2_gameStart_btn_Click(object sender, EventArgs e)
        {
            panel2_gameStart.Invoke(new MethodInvoker(delegate { panel2_gameStart.Visible = false; }));
            panel3_roomList.Invoke(new MethodInvoker(delegate { panel3_roomList.Visible = true; }));
            p3_title_label.Visible = true;
        }
        #endregion

        #region panel3_roomList: 방 리스트 (방 생성, 입장, 퇴장)
        private void panel3_roomList_VisibleChanged(object sender, EventArgs e)
        {
            p3_comein_label.Text = String.Format("{0} 님 접속 중", p1_username_tbx.Text);
            p3_roomname_tbx.Visible = false;
        }

        private void p3_makeRoom_btn_Click(object sender, EventArgs e)
        {
            p3_roomname_label.Visible = true;
            p3_roomname_label.Text = "생성 할 방 이름";
            p3_roomname_tbx.Visible = true;
            p3_roomname_tbx.Text = "";
            p3_create_btn.Visible = true;
            p3_people_label.Visible = true;
            p3_people_tbx.Visible = true;
            p3_people_tbx.Text = "";
        }


        List<string> serverRoomInfo;    // RoomList 함수가 서버로 부터 받아 온 방 정보를 사용하기 위함.

        // 서버에 존재하는 방 정보를 가져와서 방 리스트에 출력
        public override void RoomList(List<string> roomList)
        {
            p3_dataGridView1.Invoke(new MethodInvoker(delegate { p3_dataGridView1.Rows.Clear(); }));

            //새로 고침시, 셀 추가 문제 해결
            serverRoomInfo = roomList;

            foreach (string room in roomList)
            {
                string[] roomInfo = room.Split(',');
                string roomName = roomInfo[0];
                string playerCount = roomInfo[1];
                string roomMax = roomInfo[2];

                playCount_change(playerCount);
                // 아무 정보도 없을 때 예외 처리 필요함
                p3_dataGridView1.Invoke(new MethodInvoker(delegate { p3_dataGridView1.Rows.Add(roomName, playerCount + '/' + roomMax); }));
            }
        }

        private void playCount_change(string playerCount)
        {
            switch (playerCount)
            {
                case "0":
                    p4_1_player1.Invoke(new MethodInvoker(delegate { p4_1_player1.Text = p1_username_tbx.Text; }));
                    break;
                case "1":
                    p4_1_player2.Invoke(new MethodInvoker(delegate { p4_1_player2.Text = p1_username_tbx.Text; }));
                    break; ;
                case "2":
                    p4_1_player3.Invoke(new MethodInvoker(delegate { p4_1_player3.Text = p1_username_tbx.Text; }));
                    break;
                case "3":
                    p4_1_player4.Invoke(new MethodInvoker(delegate { p4_1_player4.Text = p1_username_tbx.Text; }));
                    break;
                case "4":
                    p4_1_player5.Invoke(new MethodInvoker(delegate { p4_1_player5.Text = p1_username_tbx.Text; }));
                    break;
            }
        }

        /// <summary>
        /// 방 생성하기 버튼 클릭 시 이벤트
        /// 방 이름과 최대 정원이 모두 입력되면 방 생성함
        /// </summary>
        private void p3_create_btn_Click(object sender, EventArgs e)
        {
            string roomName = p3_roomname_tbx.Text;
            string roomMax = p3_people_tbx.Text;

            //최대 정원 5 이상일 경우 오류 출력
            if (Convert.ToInt32(roomMax) > 5)    
            {
                ShowMessageBox("최대 정원 수를 초과했습니다.\n다시 입력해주세요.\n(최대 정원 수: 5명)", "Fail", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                if (roomName != string.Empty && roomMax != string.Empty)
                {
                    int num = 0;
                    try
                    {
                        if (int.TryParse(p3_people_tbx.Text, out num))
                        {
                            client.RequestRoomCreate(roomName, roomMax);
                        }

                        panel3_roomList.Visible = false;
                        panel4_1_owner_waitRoom.Visible = true;
                    }
                    catch (NullReferenceException nre)
                    {
                        return;
                    }
                }
            }
        }

        public override void RoomCreate(bool success)
        {
            if (success)
            {
                ShowMessageBox("방 생성 성공", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                p4_player1.Invoke(new MethodInvoker(delegate { p4_player1.Text = p1_username_tbx.Text; }));
                p4_1_player1.Invoke(new MethodInvoker(delegate { p4_1_player1.Text = p1_username_tbx.Text; }));
            }
            else
            {
                ShowMessageBox("방 생성 실패", "Fail", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        public override void OwnerWait()
        {
            //방장의 게임 시작 전 화면. 게임 시작 버튼, 강퇴 버튼
            //panel3_roomList.Visible = false;
            //panel4_1_owner_waitRoom.Visible = true;
            p4_1_player1.Invoke(new MethodInvoker(delegate { p4_player1.Text = p1_username_tbx.Text; }));
            //panel3_roomList.Invoke(new MethodInvoker(delegate { panel3_roomList.Visible = false; }));
            //panel4_1_owner_waitRoom.Invoke(new MethodInvoker(delegate { panel4_1_owner_waitRoom.Visible = true; }));
            p4_1_chat_tbx.Text = "";

            client.RequestPlayerList(roomName);
            p4_1_current_player();
        }

        string roomName;
        //테이블 내 입장하기 버튼 클릭 시
        private void p3_dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string rName = p3_dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            roomName = rName;
            if (rName != string.Empty)
            {
                client.RequestRoomJoin(rName);   // 서버에 방 이름 정보 보냄
                //client.RequestRoomCreate(roomName, "5");
                
            }
        }


        public override void RoomJoin(string result)
        {
            if (result.Equals("-1"))
            {

                ShowMessageBox("존재하지 않는 방입니다.", "Fail", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (result.Equals("-2"))
            {

                ShowMessageBox("정원이 가득 찼습니다.", "Fail", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                // 대기 방 패널로 넘어가야 됨.
                panel3_roomList.Invoke(new MethodInvoker(delegate { panel3_roomList.Visible = false; }));
                panel4_player_waitRoom.Invoke(new MethodInvoker(delegate { panel4_player_waitRoom.Visible = true; }));
                ShowMessageBox(result + " 방에 참가완료", "Room Join", MessageBoxButtons.OK, MessageBoxIcon.Information);

                client.RequestSendRoomChat("시스템", p1_username_tbx.Text + "이(가) 방에 참가함");
                client.RequestPlayerList(roomName); // 현재 방에 접속된 접속 인원 이름을 받아옴.
            }
        }
        public override void PlayerWait()
        {
            // 참가자의 게임 시작 전 화면 -> 플레이어용 대기 방 화면
            //panel3_roomList.Visible = false;
            //panel4_player_waitRoom.Visible = true;
            p4_chat_tbx.Text = "";

            //panel3_roomList.Invoke(new MethodInvoker(delegate { panel3_roomList.Visible = false; }));
            //panel4_player_waitRoom.Invoke(new MethodInvoker(delegate { panel4_player_waitRoom.Visible = true; }));
        }

        // 새로 고침 버튼 클릭 시 이벤트
        private void p3_refresh_btn_Click(object sender, EventArgs e)
        {
            client.RequestRoomList();
        }

        // 뒤로 가기 버튼 클릭 시 이벤트
        private void p3_back_btn_Click(object sender, EventArgs e)
        {
            client.RequestRoomOut();
            p3_title_label.Visible = false;
            p3_people_label.Visible = false;
            p3_people_tbx.Visible = false;
            p3_create_btn.Visible = false;
            p3_roomname_label.Visible = false;
            p3_roomname_tbx.Visible = false;
            panel3_roomList.Visible = false;
            panel2_gameStart.Visible = true;
        }

        #endregion


        #region panel4_waitRoom: 대기 방(채팅)


        public override void PresenterWait()
        {
            // 방 리스트에서 대기 방으로 이동
            //panel3_roomList.Visible = false;
            //panel4_waitRoom.Visible = true;

            panel3_roomList.Invoke(new MethodInvoker(delegate { panel3_roomList.Visible = false; }));
            panel4_player_waitRoom.Invoke(new MethodInvoker(delegate { panel4_player_waitRoom.Visible = true; }));
        }

        // 접속자 리스트 - 문제: 방장만 제대로 출력x(only 자기 이름)
        public override void PlayerList(List<string> playerList)
        {
            int cnt = playerList.Count;
            if (cnt > 0)
            {
                p6_player1.Invoke(new MethodInvoker(delegate { p6_player1.Text = playerList[0]; }));
                p4_player1.Invoke(new MethodInvoker(delegate { p4_player1.Text = playerList[0]; }));    //플레이어
                p4_1_player1.Invoke(new MethodInvoker(delegate { p4_1_player1.Text = playerList[0]; }));    //방장
            }
            if (cnt > 1)
            {
                // 플레이어
                p4_player2.Invoke(new MethodInvoker(delegate { p4_player2.Text = playerList[1]; }));
                p4_player2.Invoke(new MethodInvoker(delegate { p4_player2.BackColor = Color.LightSkyBlue; }));
                p4_w_state_player2.Invoke(new MethodInvoker(delegate { p4_w_state_player2.Visible = true; }));
 
                p6_player2.Invoke(new MethodInvoker(delegate { p6_player2.Text = playerList[1]; }));
                p6_player2.Invoke(new MethodInvoker(delegate { p6_player2.BackColor = Color.LightSkyBlue; }));
                p6_player2_score.Invoke(new MethodInvoker(delegate { p6_player2_score.Visible = true; }));
                // 방장
                p4_1_player2.Invoke(new MethodInvoker(delegate { p4_1_player2.Text = playerList[1]; }));
                p4_1_player2.Invoke(new MethodInvoker(delegate { p4_1_player2.BackColor = Color.LightSkyBlue; }));
                p4_1_state_player2.Invoke(new MethodInvoker(delegate { p4_1_state_player2.Visible = true; }));
            }
            if (cnt > 2)
            {
                p4_player3.Invoke(new MethodInvoker(delegate { p4_player3.Text = playerList[2]; }));
                p4_player3.Invoke(new MethodInvoker(delegate { p4_player3.BackColor = Color.LightSkyBlue; }));
                p4_w_state_player3.Invoke(new MethodInvoker(delegate { p4_w_state_player3.Visible = true; }));

                p6_player3.Invoke(new MethodInvoker(delegate { p6_player3.Text = playerList[2]; }));
                p6_player3.Invoke(new MethodInvoker(delegate { p6_player3.BackColor = Color.LightSkyBlue; }));
                p6_player3_score.Invoke(new MethodInvoker(delegate { p6_player3_score.Visible = true; }));

                p4_1_player3.Invoke(new MethodInvoker(delegate { p4_1_player3.Text = playerList[2]; }));
                p4_1_player3.Invoke(new MethodInvoker(delegate { p4_1_player3.BackColor = Color.LightSkyBlue; }));
                p4_1_state_player3.Invoke(new MethodInvoker(delegate { p4_1_state_player3.Visible = true; }));
            }
            if (cnt > 3)
            {
                p4_player4.Invoke(new MethodInvoker(delegate { p4_player4.Text = playerList[3]; }));
                p4_player4.Invoke(new MethodInvoker(delegate { p4_player4.BackColor = Color.LightSkyBlue; }));
                p4_w_state_player4.Invoke(new MethodInvoker(delegate { p4_w_state_player4.Visible = true; }));

                p6_player4.Invoke(new MethodInvoker(delegate { p6_player4.Text = playerList[3]; }));
                p6_player4.Invoke(new MethodInvoker(delegate { p6_player4.BackColor = Color.LightSkyBlue; }));
                p6_player4_score.Invoke(new MethodInvoker(delegate { p6_player4_score.Visible = true; }));

                p4_1_player4.Invoke(new MethodInvoker(delegate { p4_1_player4.Text = playerList[3]; }));
                p4_1_player4.Invoke(new MethodInvoker(delegate { p4_1_player4.BackColor = Color.LightSkyBlue; }));
                p4_1_state_player4.Invoke(new MethodInvoker(delegate { p4_1_state_player4.Visible = true; }));
            }
            if (cnt > 4)
            {
                p4_player5.Invoke(new MethodInvoker(delegate { p4_player5.Text = playerList[4]; }));
                p4_player5.Invoke(new MethodInvoker(delegate { p4_player5.BackColor = Color.LightSkyBlue; }));
                p4_w_state_player5.Invoke(new MethodInvoker(delegate { p4_w_state_player5.Visible = true; }));

                p6_player5.Invoke(new MethodInvoker(delegate { p6_player5.Text = playerList[4]; }));
                p6_player5.Invoke(new MethodInvoker(delegate { p6_player5.BackColor = Color.LightSkyBlue; }));
                p6_player5_score.Invoke(new MethodInvoker(delegate { p6_player5_score.Visible = true; }));

                p4_1_player5.Invoke(new MethodInvoker(delegate { p4_1_player5.Text = playerList[4]; }));
                p4_1_player5.Invoke(new MethodInvoker(delegate { p4_1_player5.BackColor = Color.LightSkyBlue; }));
                p4_1_state_player5.Invoke(new MethodInvoker(delegate { p4_1_state_player5.Visible = true; }));
            }
            p4_current_player();
            p4_1_current_player();
            p6_current_player();
        }

        private void p4_refesh_Click(object sender, EventArgs e)
        {
            p4_player_change();
            client.RequestPlayerList(roomName);
        }

        private void p4_1_refresh_btn_Click(object sender, EventArgs e)
        {
            p4_1_player_change();
            client.RequestPlayerList(roomName);
        }

        int Game_start = 0; //chatList.Clear를 한번만 하기 위해서 사용
        List<string> Q_AList; //chatList.Clear를 한번만 하기 위해서 사용2

        //대기화면 채팅, 게임 질의응답 
        public override void RoomChat(List<string> chatList)
        {
            p4_chat_tbx.Invoke(new MethodInvoker(delegate { p4_chat_tbx.Text = ""; }));
            chatList.ForEach(chat =>
            {
                p4_chat_tbx.Invoke(new MethodInvoker(delegate { p4_chat_tbx.Text += chat + "\r\n"; }));
            });

            p4_1_chat_tbx.Invoke(new MethodInvoker(delegate { p4_1_chat_tbx.Text = ""; }));
            chatList.ForEach(chat =>
            {
                p4_1_chat_tbx.Invoke(new MethodInvoker(delegate { p4_1_chat_tbx.Text += chat + "\r\n"; }));
            });
            // 현재 방에 아무도 없다면 대화내용 삭제 > 현재의 
            // 게임 시작시, chatList 내용 삭제 후 게임 내용 넣기
            Q_AList = chatList; 
            if(panel5.Visible == true || panel6_Answer.Visible == true)
            {
                //chatList.Clear();
                chatList = Q_AList;
            }
            p6_QA_tbx.Invoke(new MethodInvoker(delegate { p6_QA_tbx.Text = ""; }));
            chatList.ForEach(chat =>
            {
                p6_QA_tbx.Invoke(new MethodInvoker(delegate { p6_QA_tbx.Text += chat + "\r\n"; }));
            });
        }

        private void p4_send_btn_Click(object sender, EventArgs e)
        {
            string content = p4_message_tbx.Text;
            client.username = p1_username_tbx.Text;
            if (content != string.Empty)
            {
                client.RequestSendRoomChat(client.username, content);
                p4_message_tbx.Text = "";
            }
        }

        private void p4_1_send_btn_Click(object sender, EventArgs e)
        {
            string content = p4_1_message_tbx.Text;
            client.username = p1_username_tbx.Text;
            if (content != string.Empty)
            {
                client.RequestSendRoomChat(client.username, content);
                p4_1_message_tbx.Text = "";
            }
        }

        
        private void panel4_waitRoom_VisibleChanged(object sender, EventArgs e)
        {
            if(panel4_player_waitRoom.Visible == true)
            {
                client.RequestRoomList();
                RoomList(serverRoomInfo);
                
                foreach (string room in serverRoomInfo)
                {
                    string[] roomInfo = room.Split(',');
                    string roomName = roomInfo[0];
                    string playerCount = roomInfo[1];
                    string roomMax = roomInfo[2];
                    
                    p4_roomInfo_label.Invoke(new MethodInvoker(delegate { p4_roomInfo_label.Text = string.Format("{0} 님 {1} 방 접속 중", p1_username_tbx.Text, roomName); }));
                    // "방 이름 - 접속 인원 / 최대 정원" 으로 나타나야 하는데, 접속 인원이 반영 안됨.
                    // p4_roomInfo_label.Text = String.Format("{0} 방 - {1} / {2}", roomName, playerCount, roomMax);

                    switch (playerCount)
                    {
                        case "0":
                            p4_player1.Invoke(new MethodInvoker(delegate { p4_player1.Text = p1_username_tbx.Text; }));
                            break;
                        case "1":
                            p4_player2.Invoke(new MethodInvoker(delegate { p4_player2.Text = p1_username_tbx.Text; }));
                            break;
                        case "2":
                            p4_player3.Invoke(new MethodInvoker(delegate { p4_player3.Text = p1_username_tbx.Text; }));
                            break;
                        case "3":
                            p4_player4.Invoke(new MethodInvoker(delegate { p4_player4.Text = p1_username_tbx.Text; }));
                            break;
                        case "4":
                            p4_player5.Invoke(new MethodInvoker(delegate { p4_player5.Text = p1_username_tbx.Text; }));
                            break;
                    }
                }
                
            }
            else
            {
                p4_roomInfo_label.Invoke(new MethodInvoker(delegate { p4_roomInfo_label.Visible = false; }));
            }

        }

        
        private void panel4_1_owner_waitRoom_VisibleChanged(object sender, EventArgs e)
        {
            client.RequestRoomList();
            RoomList(serverRoomInfo);

            if (panel4_1_owner_waitRoom.Visible == true)
            {
                foreach (string room in serverRoomInfo)
                {
                    string[] roomInfo = room.Split(',');
                    string roomName = roomInfo[0];
                    string playerCount = roomInfo[1];
                    string roomMax = roomInfo[2];

                    //p4_1_roomInfo_label.Invoke(new MethodInvoker(delegate { p4_1_roomInfo_label.Text = string.Format("{0} 님 {1} 방 접속 중", p1_username_tbx.Text, roomName); }));
                    // "방 이름 - 접속 인원 / 최대 정원" 으로 나타나야 하는데, 접속 인원이 반영 안됨.
                    p4_roomInfo_label.Invoke(new MethodInvoker(delegate { p4_roomInfo_label.Text = String.Format("{0} 방 - {1} / {2}", roomName, playerCount, roomMax); }));


                    switch (playerCount)
                    {
                        case "0":
                            p4_1_player1.Invoke(new MethodInvoker(delegate { p4_1_player1.Text = p1_username_tbx.Text; }));
                            break;
                        case "1":
                            p4_1_player2.Invoke(new MethodInvoker(delegate { p4_1_player2.Text = p1_username_tbx.Text; }));
                            break; ;
                        case "2":
                            p4_1_player3.Invoke(new MethodInvoker(delegate { p4_1_player3.Text = p1_username_tbx.Text; }));
                            break;
                        case "3":
                            p4_1_player4.Invoke(new MethodInvoker(delegate { p4_1_player4.Text = p1_username_tbx.Text; }));
                            break;
                        case "4":
                            p4_1_player5.Invoke(new MethodInvoker(delegate { p4_1_player5.Text = p1_username_tbx.Text; }));
                            break;
                    }
                }

            }
            else
            {
                p4_1_roomInfo_label.Invoke(new MethodInvoker(delegate { p4_1_roomInfo_label.Visible = false; }));
            }
        }

        //일반 접속자 화면에 현재 자신 표시
        private void p4_current_player()
        {
            string p_name = p1_username_tbx.Text;
            if (p_name == p4_player1.Text)
            {
                p4_player1.ForeColor = Color.DarkGreen;
            }
            else if (p_name == p4_player2.Text)
                p4_player2.ForeColor = Color.DarkGreen;
            else if (p_name == p4_player3.Text)
                p4_player3.ForeColor = Color.DarkGreen;
            else if (p_name == p4_player4.Text)
                p4_player4.ForeColor = Color.DarkGreen;
            else if (p_name == p4_player5.Text)
                p4_player5.ForeColor = Color.DarkGreen;
        }

        //owner화면에 현재 자신 표시
        private void p4_1_current_player()
        {
            string p_name = p1_username_tbx.Text;
            if (p_name == p4_1_player1.Text)
            {
                p4_1_player1.ForeColor = Color.DarkGreen;
            }
            else if (p_name == p4_1_player2.Text)
                p4_1_player2.ForeColor = Color.DarkGreen;
            else if (p_name == p4_1_player3.Text)
                p4_1_player3.ForeColor = Color.DarkGreen;
            else if (p_name == p4_1_player4.Text)
                p4_1_player4.ForeColor = Color.DarkGreen;
            else
                p4_1_player5.ForeColor = Color.DarkGreen;
        }

        private void p4_player_change() // 기본 폼 설정 > 나가기 시 남은 사람들 폼에 적용
        {
            p4_player2.BackColor = Color.LightGray;
            p4_player2.Invoke(new MethodInvoker(delegate { p4_player2.Text = ""; }));
            p4_player3.BackColor = Color.LightGray;
            p4_player3.Invoke(new MethodInvoker(delegate { p4_player3.Text = ""; }));
            p4_player4.BackColor = Color.LightGray;
            p4_player4.Invoke(new MethodInvoker(delegate { p4_player4.Text = ""; }));
            p4_player5.BackColor = Color.LightGray;
            p4_player5.Invoke(new MethodInvoker(delegate { p4_player5.Text = ""; }));
        }

        private void p4_1_player_change() // 기본 폼 설정 > 나가기 시 남은 사람들 폼에 적용
        {
            p4_1_player2.BackColor = Color.LightGray;
            p4_1_player2.Invoke(new MethodInvoker(delegate { p4_1_player2.Text = ""; }));
            p4_1_player3.BackColor = Color.LightGray;
            p4_1_player3.Invoke(new MethodInvoker(delegate { p4_1_player3.Text = ""; }));
            p4_1_player4.BackColor = Color.LightGray;
            p4_1_player4.Invoke(new MethodInvoker(delegate { p4_1_player4.Text = ""; }));
            p4_1_player5.BackColor = Color.LightGray;
            p4_1_player5.Invoke(new MethodInvoker(delegate { p4_1_player5.Text = ""; }));
        }

        #region RoomOut
        public override void RoomOut()
        {
            ShowMessageBox("방 나옴", "Room Out", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void p4_Out_btn_Click(object sender, EventArgs e)
        {
            client.RequestRoomOut();
            p4_chat_tbx.Text = "";
            p4_ready_btn.Text = "READY";
            p3_people_label.Visible = false;
            p3_people_tbx.Visible = false;
            p3_create_btn.Visible = false;
            p3_roomname_label.Visible = false;
            panel4_player_waitRoom.Visible = false;
            panel3_roomList.Visible = true;
        }

        private void p4_1_out_btn_Click(object sender, EventArgs e)
        {
            client.RequestRoomOut();
            p4_1_chat_tbx.Text = "";
            p4_1_start_btn.Text = "READY";
            p3_people_label.Visible = false;
            p3_people_tbx.Visible = false;
            p3_create_btn.Visible = false;
            p3_roomname_label.Visible = false;
            panel4_1_owner_waitRoom.Invoke(new MethodInvoker(delegate { panel4_1_owner_waitRoom.Visible = false; }));
            panel3_roomList.Invoke(new MethodInvoker(delegate { panel3_roomList.Visible = true; }));
        }
        #endregion

        public override void GameReady(bool ready)
        {
            //ShowMessageBox("준비 완료", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //p4_ready_btn.Invoke(new MethodInvoker(delegate { p4_ready_btn.Text = "Ready Done"; }));

            if (ready == true)
            {
                // 출제자와 정답자 구분
                // 출제자이면 5번 패널 -> 방장 위임, 게임 시작하기 버튼 들어감
                // 정답자이면 6번 패널 -> 별도 다른 조치 필요 없음
                ShowMessageBox("준비 완료", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
                p4_ready_btn.Invoke(new MethodInvoker(delegate { p4_ready_btn.Text = "Ready Done"; }));
                //p4_ready_btn.Text = "Ready Done";
            }

        }

        private void p4_ready_btn_Click(object sender, EventArgs e)
        {
            //p4_gameStart_btn.Visible = true;
            string player = p1_username_tbx.Text;
            if (player == p4_player2.Text)
                p4_state_player2.Text = "준비 완료";
            else if (player == p4_player3.Text)
                p4_state_player3.Text = "준비 완료";
            else if (player == p4_player4.Text)
                p4_state_player4.Text = "준비 완료";
            else if (player == p4_player5.Text)
                p4_state_player5.Text = "준비 완료";
            panel4_player_waitRoom.Visible=false;
            panel6_Answer.Visible = true; //p6화면 확인 test
            //Game_start = 2;
            Q_AList.Clear();
        }

        private void p4_1_ready_btn_Click(object sender, EventArgs e)
        {
            client.RequestGameReady();
        }

        #endregion

        //owner에서 start클릭 > 아무도 없을 경우 오류 작성 후 작동 x
        private void p4_gameStart_btn_Click(object sender, EventArgs e)
        {
            if(serverRoomInfo == null)
            {
                ShowMessageBox("아직 접속자가 없습니다.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                panel4_player_waitRoom.Invoke(new MethodInvoker(delegate { panel4_player_waitRoom.Visible = false; }));
                //panel5_Quest.Invoke(new MethodInvoker(delegate { panel5_Quest.Visible = true; }));
                panel6_Answer.Invoke(new MethodInvoker(delegate { panel6_Answer.Visible = true; }));
            }        
        }

        bool buzzer_on = false;
        int b_cnt1 = 5, b_cnt2 = 5, b_cnt3 = 5, b_cnt4 = 5, b_cnt5 = 5;
        //정답 버튼
        private void buzzer_Click(object sender, EventArgs e)
        {
            timer1.Start();
            client.RequestBuzzer();

            //if(b_cnt1==0 || b_cnt2 == 0 || b_cnt3 == 0 || b_cnt4 == 0 || b_cnt5 == 0)
            
                //폼을 정답 맞추는 것으로 바꿔야 함 - 턴 없애기, tbx 입력
                //버저를 누른 유저에게만 해당하도록 설정 필요
            p6_player_turn_label.Invoke(new MethodInvoker(delegate { p6_player_turn_label.Visible = false; }));
            p6_answer_tbx.Invoke(new MethodInvoker(delegate { p6_answer_tbx.ReadOnly = false; }));
            p6_answer_tbx.Invoke(new MethodInvoker(delegate { p6_answer_tbx.Text = ""; }));
            p6_answer_tbx.ForeColor = Color.CornflowerBlue;
            
            buzzer_on = true;

            if (b_cnt1 <= 0)
            {
                ShowMessageBox("부저 횟수 초과", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                buzzer_on = false;
            }
            if (b_cnt2 <= 0)
            {
                ShowMessageBox("부저 횟수 초과", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                buzzer_on = false;
            }
            if (b_cnt3 <= 0)
            {
                ShowMessageBox("부저 횟수 초과", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                buzzer_on = false;
            }
            if (b_cnt4 <= 0)
            {
                ShowMessageBox("부저 횟수 초과", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                buzzer_on = false;
            }
            if (b_cnt5 <= 0)
            {
                ShowMessageBox("부저 횟수 초과", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                buzzer_on = false;
            }
            //정답을 맞추는 사람만 라벨 변경 필요 > 출제자가 정답 전송 시 스코어 늘리기


            //부저 제한 횟수 넘길 시, 오류 출력 필요 > 사람마다 횟수 계산
            string p_name = p1_username_tbx.Text;
            if (p_name == p4_player1.Text)
            {
                b_cnt1--;
                if (b_cnt1 <= 0)
                    p6_buzzer_btn.Text = "정답 ( 0 / 5 )";
                else
                    p6_buzzer_btn.Text = "정답 ( " + b_cnt1 + "/ 5 )";
            }
            else if (p_name == p4_player2.Text)
            {
                b_cnt2--;
                if (b_cnt2 <= 0)
                    p6_buzzer_btn.Text = "정답 ( 0 / 5 )";
                else
                    p6_buzzer_btn.Text = "정답 ( " + b_cnt2 + "/ 5 )";
            }
            else if (p_name == p4_player3.Text)
            {
                b_cnt3--;
                if (b_cnt3 <= 0)
                    p6_buzzer_btn.Text = "정답 ( 0 / 5 )";
                else
                    p6_buzzer_btn.Text = "정답 ( " + b_cnt3 + "/ 5 )";
            }
            else if (p_name == p4_player4.Text)
            {
                b_cnt4--;
                if (b_cnt4 <= 0)
                    p6_buzzer_btn.Text = "정답 ( 0 / 5 )";
                else
                    p6_buzzer_btn.Text = "정답 ( " + b_cnt4 + "/ 5 )";
            }
            else if (p_name == p4_player5.Text)
            {
                b_cnt5--;
                if (b_cnt5 <= 0)
                    p6_buzzer_btn.Text = "정답 ( 0 / 5 )";
                else
                    p6_buzzer_btn.Text = "정답 (" + b_cnt5 + "/ 5 )";
            }
        }

        #region panel6_Answer: 질문자 화면

        // 사용자 턴 나타냄 - 주황색 테두리
        private void p6_turn()    
        {
            p6_player_turn_label.Invoke(new MethodInvoker(delegate { p6_player_turn_label.Visible = true; }));
            string p_name = p1_username_tbx.Text;
            if (p_name == p4_player1.Text)
                p6_player_turn_label.Location = new Point(34, 23);
            else if (p_name == p4_player2.Text)
                p6_player_turn_label.Location = new Point(34, 114);
            else if (p_name == p4_player3.Text)
                p6_player_turn_label.Location = new Point(34, 204);
            else if (p_name == p4_player4.Text)
                p6_player_turn_label.Location = new Point(34, 294);
            else if (p_name == p4_player5.Text)
                p6_player_turn_label.Location = new Point(34, 384);
        }

        // 현재 사용자 표시 - 뒷 배경 초록색
        private void p6_current_player()
        {
            string p_name = p1_username_tbx.Text;
            if (p_name == p6_player1.Text)
            {       //테두리 추가시, 사용자 이름이랑 뒷배경색 안 나옴
                p6_player1.BackColor = Color.MediumSeaGreen;
                p6_player1_score.BackColor = Color.MediumSeaGreen;
            }
            else if (p_name == p6_player2.Text)
            {
                p6_player2.BackColor = Color.MediumSeaGreen;
                p6_player2_score.BackColor = Color.MediumSeaGreen;
            }
            else if (p_name == p6_player3.Text)
            {
                p6_player3.BackColor = Color.MediumSeaGreen;
                p6_player3_score.BackColor = Color.MediumSeaGreen;
            }
            else if (p_name == p6_player4.Text)
            {
                p6_player4.BackColor = Color.MediumSeaGreen;
                p6_player4_score.BackColor = Color.MediumSeaGreen;
            }
            else if (p_name == p6_player5.Text)
            {
                p6_player5.BackColor = Color.MediumSeaGreen;
                p6_player5_score.BackColor = Color.MediumSeaGreen;
            }
        }

        int turn_cnt = 0;   // 질문 횟수 계산

        // 게임 시작 후 질문자가 질문을 기다리는 화면 > 턴x
        public override void QuestionerWait()
        {   //질의응답 창 test를 위해 주석 처리
            p6_answer_tbx.Text = "( 질문 순서가 아닙니다. )";
            p6_answer_tbx.ReadOnly = true;
            if(turn_cnt > 20)   // 질문 20번 넘었을 때
                ShowMessageBox("질문 횟수가 20번이 넘었습니다...", "GameOver", MessageBoxButtons.OK, MessageBoxIcon.Stop);
        }

        // 게임 시작 후 질문자가 질문을 작성하는 화면 > 턴o
        public override void QuestionerQuestion()
        {
            //사용자 턴에 따른 사용자 리스트 라벨 변경 > 사용자 누구? -> 테두리 색 변환
            if(turn_cnt < 21)
            {
                p6_turn(); // 질문자 표시
                p6_answer_tbx.Text = "";
                p6_answer_tbx.ReadOnly = false; //입력받기 가능
                p6_answer_tbx.ForeColor = Color.DodgerBlue;
                turn_cnt++;
            }
            else
            {   // 질문 20번 넘었을 때
                ShowMessageBox("질문 횟수가 20번이 넘었습니다...", "GameOver", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void panel6_Answer_VisibleChanged(object sender, EventArgs e)
        {   //질의응답 창 test를 위해 주석 처리
            p6_solution_label.Invoke(new MethodInvoker(delegate { p6_solution_label.Text = "? ? ?"; }));
            p6_answer_tbx.Text = "( 출제자가 답을 입력 중입니다. )";
            p6_answer_tbx.ReadOnly = true;
            Game_start = 1;
        }

        private void p6_send_btn_Click(object sender, EventArgs e)
        {
            if (buzzer_on)  // 부저 -> 정답 입력
                client.RequestSendQuestion("[ ! ]" + p6_answer_tbx.Text);
            else            // 일반 질문 입력
                client.RequestSendQuestion("[ Q" + turn_cnt + " ] " + p1_username_tbx.Text + " : " + p6_answer_tbx.Text);
            p6_answer_tbx.Text = "";
        }
        #endregion
        private void timer1_Tick(object sender, EventArgs e)
        {   //시간 표시할 라벨
            //label1.Text=(int.Parse(label1.text)+1).ToString();
            //if (Label1.text == '5')
            {
                //timer1.Stop();
                // client.RequestGuessAnswer(Textbox.Text);
                //답 읽어오기
            }
        }
    }
}