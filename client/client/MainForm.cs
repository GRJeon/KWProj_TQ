﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace client
{
    public partial class MainForm : ClientForm
    {
        public MainForm()
        {
            InitializeComponent();

            #region font 설정
            Font font_40 = new Font(FontLibrary.Families[0], 40f);
            Font font_20 = new Font(FontLibrary.Families[0], 20f);
            Font font_18 = new Font(FontLibrary.Families[0], 18f);
            Font font_16 = new Font(FontLibrary.Families[0], 16f);
            Font font_14 = new Font(FontLibrary.Families[0], 14f);
            Font font_12 = new Font(FontLibrary.Families[0], 12f);
            // main form
            title_label.Font = font_40;
            midTitle_label.Font = font_18;
            main_login_btn.Font = font_20;

            // panel1_login_server
            p1_login_btn.Font = font_20;
            p1_signUp_btn.Font = font_20;
            p1_ip_tbx.Font = font_16;
            p1_ip_label.Font = font_16;
            p1_connect_btn.Font = font_20;
            p1_title_label.Font = font_40;

            // p1_1_login
            p1_midTitle_label.Font = font_16;
            p1_username_tbx.Font = font_16;
            p1_username_label.Font = font_14;
            p1_pw_label.Font = font_14;
            p1_pw_tbx.Font = font_16;

            // panel2
            p2_logout_btn.Font = font_20;
            p2_gameStart_btn.Font = font_20;
            p2_welcome__label.Font = font_18;
            p2_title_label.Font = font_40;

            // panel3
            // datagridView 안에 있는 버튼은 따로 이름을 모르겠어서, 혹시 찾으시면 추가 부탁 드립니다.
            p3_rank_btn.Font = font_14;
            p3_title_label.Font = font_14;
            p3_dataGridView1.Font = font_14;
            p3_dataGridView1.DefaultCellStyle.Font = font_14;
            p3_create_btn.Font = font_14;
            p3_comein_label.Font = font_14;
            p3_back_btn.Font = font_14;
            p3_makeRoom_btn.Font = font_16;
            p3_refresh_btn.Font = font_12;
            p3_people_tbx.Font = font_12;
            p3_roomname_tbx.Font = font_12;
            p3_people_label.Font = new Font(FontLibrary.Families[0], 11f);
            p3_roomname_label.Font = new Font(FontLibrary.Families[0], 11f);
            p3_friend_list_btn.Font = font_12;

            // panel4
            p4_roomInfo_label.Font = font_12;
            p4_w_state_player1.Font = font_12;
            p4_w_state_player2.Font = font_12;
            p4_w_state_player3.Font = font_12;
            p4_w_state_player4.Font = font_12;
            p4_w_state_player5.Font = font_12;
            p4_player1.Font = font_12;
            p4_player2.Font = font_12;
            p4_player3.Font = font_12;
            p4_player4.Font = font_12;
            p4_player5.Font = font_12;
            p4_send_btn.Font = font_16;
            p4_Out_btn.Font = font_14;
            p4_refesh_btn.Font = font_14;
            p4_message_tbx.Font = font_12;
            p4_ready_btn.Font = font_16;
            p4_chat_tbx.Font = font_12;

            // panel4_1
            p4_1_roomInfo_label.Font = font_12;
            p4_1_state_player1.Font= font_12;
            p4_1_state_player2.Font = font_12;
            p4_1_state_player3.Font = font_12;
            p4_1_state_player4.Font = font_12;
            p4_1_state_player5.Font = font_12;
            p4_1_player1.Font = font_12;
            p4_1_player2.Font = font_12;
            p4_1_player3.Font = font_12;
            p4_1_player4.Font = font_12;
            p4_1_player5.Font = font_12;
            p4_1_refresh_btn.Font = font_14;
            p4_1_send_btn.Font = font_16;
            p4_1_out_btn.Font = font_14;
            p4_1_message_tbx.Font = font_12;
            p4_1_start_btn.Font = font_16;
            p4_1_chat_tbx.Font = font_12;

            // panel5
            p5_title_label.Font = font_18;
            p5_출제자_label.Font = font_14;
            p5_input_label.Font = font_14;
            p5_send_btn.Font = font_16;
            p5_message_tbx.Font = font_12;
            p5_player1.Font = font_14;
            p5_player2.Font = font_14;
            p5_player3.Font = font_14;
            p5_player4.Font = font_14;
            p5_player5.Font = font_14;
            p5_player1_score.Font = font_12;
            p5_player2_score.Font = font_12;
            p5_player3_score.Font = font_12;
            p5_player4_score.Font = font_12;
            p5_player5_score.Font = font_12;

            // panel5_1
            p5_1_unknown_btn.Font = font_16;
            p5_1_yes_btn.Font = font_16;
            p5_1_no_btn.Font = font_16;
            p5_1_QA_tbx.Font = font_12;
            p5_1_answer_label.Font = font_14;
            p5_1_출제자_label.Font = font_14;
            p5_1_player1.Font = font_14;
            p5_1_player2.Font = font_14;
            p5_1_player3.Font = font_14;
            p5_1_player4.Font = font_14;
            p5_1_player5.Font = font_14;
            p5_1_player1_score.Font = font_12;
            p5_1_player2_score.Font = font_12;
            p5_1_player3_score.Font = font_12;
            p5_1_player4_score.Font = font_12;
            p5_1_player5_score.Font = font_12;

            // panel5_2
            p5_2_QA_tbx.Font = font_12;
            p5_2_word_label.Font = font_14;
            p5_2_출제자_label.Font = font_14;
            p5_2_player1.Font = font_14;
            p5_2_player2.Font = font_14;
            p5_2_player3.Font = font_14;
            p5_2_player4.Font = font_14;
            p5_2_player5.Font = font_14;
            p5_2_player1_score.Font = font_12;
            p5_2_player2_score.Font = font_12;
            p5_2_player3_score.Font = font_12;
            p5_2_player4_score.Font = font_12;
            p5_2_player5_score.Font = font_12;

            // panel6
            p6_timer_label.Font = font_12;
            p6_player1.Font = font_14;
            p6_player2.Font = font_14;
            p6_player3.Font = font_14;
            p6_player4.Font = font_14;
            p6_player5.Font = font_14;
            p6_player1_score.Font = font_12;
            p6_player2_score.Font = font_12;
            p6_player3_score.Font = font_12;
            p6_player4_score.Font = font_12;
            p6_player5_score.Font = font_12;
            p6_buzzer_btn.Font = font_14;
            p6_solution_label.Font = font_14;
            p6_send_btn.Font = font_16;
            p6_answer_tbx.Font = font_12;
            p6_QA_tbx.Font = font_12;
            
            // panel6_2
            p6_2_timer_label.Font = font_12;
            p6_2_player1.Font = font_14;
            p6_2_player2.Font = font_14;
            p6_2_player3.Font = font_14;
            p6_2_player4.Font = font_14;
            p6_2_player5.Font = font_14;
            p6_2_player1_score.Font = font_12;
            p6_2_player2_score.Font = font_12;
            p6_2_player3_score.Font = font_12;
            p6_2_player4_score.Font = font_12;
            p6_2_player5_score.Font = font_12;
            p6_2_buzzer_btn.Font = font_14;
            p6_2_solution_label.Font = font_14;
            p6_2_send_btn.Font = font_16;
            p6_2_answer_tbx.Font = font_12;
            p6_2_QA_tbx.Font = font_12;

            // panel7
            p7_back_btn.Font = font_14;
            p7_ranking_label.Font = font_18;
            p7_ranking_dgv.Font = font_14;
            p7_ranking_dgv.DefaultCellStyle.Font = font_14; //셀 내부

            //p panel 8
            p8_back_btn.Font = font_14;
            p8_friendlist_label.Font = font_18;
            p8_friend_dgv.Font = font_14;
            p8_friend_dgv.DefaultCellStyle.Font = font_14; //셀 내부
            #endregion
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

        private void panel1_login_server_VisibleChanged(object sender, EventArgs e)
        {
            this.ActiveControl = p1_ip_tbx; // 커서 포커스 설정
        }

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
            }
        }

        private void p1_ip_tbx_KeyPress(object sender, KeyPressEventArgs e)
        {
            // 숫자, 백스페이스, '.'만 입력 가능
            if (!(char.IsDigit(e.KeyChar) || e.KeyChar == Convert.ToChar(Keys.Back) || e.KeyChar == 46))
            {
                e.Handled = true;
            }
            
            // 엔터 입력 시 send 버튼 클릭과 같은 이벤트
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                e.Handled = true;
                if (string.IsNullOrEmpty(p1_ip_tbx.Text))
                {
                    ShowMessageBox("IP를 입력해주세요", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    TryConnectServer(p1_ip_tbx.Text);
                }
            }
        }

        public override void ConnectServerResult(bool success)
        {
            if (success == true)
            {
                //연결 성공
                p1_connect_btn.Invoke(new MethodInvoker(delegate { p1_connect_btn.Visible = false; }));
                p1_1_login_panel.Invoke(new MethodInvoker(delegate { p1_1_login_panel.Visible = true; }));
                p1_signUp_btn.Invoke(new MethodInvoker(delegate { p1_signUp_btn.Visible = true; }));
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
            this.ActiveControl = p1_username_tbx;   // 커서 포커스 설정
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

        private void p1_username_tbx_KeyPress(object sender, KeyPressEventArgs e)
        {
            // 엔터 입력 시 send 버튼 클릭과 같은 이벤트
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                e.Handled = true;

                // 로그인 버튼 눌렀을 때 유효성 검사
                string username = p1_username_tbx.Text;
                string password = p1_pw_tbx.Text;
                DialogResult result = DialogResult.None;

                // 이름, 비번 둘 중 하나라도 입력하지 않으면 팝업 띄움
                if (string.IsNullOrEmpty(p1_username_tbx.Text) || string.IsNullOrEmpty(p1_pw_tbx.Text))
                {
                    ShowMessageBox("이름과 비밀번호를 정확히 입력해주세요.", "Login Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    result = DialogResult.Yes;
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
                        MessageBox.Show("로그인 정보가 없습니다.", "Login Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }

            }
        }

        private void p1_pw_tbx_KeyPress(object sender, KeyPressEventArgs e)
        {
            // ( , : \ | ) 괄호 안의 문자 입력 시 비번 생성 안됨  
            if ((e.KeyChar == 44 || e.KeyChar == 58 || e.KeyChar == 92 || e.KeyChar == 124))
            {
                ShowMessageBox(", : '\' | 는 특수문자로 사용할 수 없습니다.", "Sign Up Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                e.Handled = true;
            }

            // 엔터 입력 시 send 버튼 클릭과 같은 이벤트
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                e.Handled = true;

                // 로그인 버튼 눌렀을 때 유효성 검사
                string username = p1_username_tbx.Text;
                string password = p1_pw_tbx.Text;
                DialogResult result = DialogResult.None;

                // 이름, 비번 둘 중 하나라도 입력하지 않으면 팝업 띄움
                if (string.IsNullOrEmpty(p1_username_tbx.Text) || string.IsNullOrEmpty(p1_pw_tbx.Text))
                {
                    ShowMessageBox("이름과 비밀번호를 정확히 입력해주세요.", "Login Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    result = DialogResult.Yes;
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
                result = DialogResult.Yes;
                /*
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
                */
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
            client.RequestSignOut();
        }

        public override void SignOut()
        {
            panel2_gameStart.Visible = false;
            p1_1_login_panel.Visible = true;
            //panel2_gameStart.Invoke(new MethodInvoker(delegate { panel2_gameStart.Visible = false; }));
            p2_gameStart_btn.Invoke(new MethodInvoker(delegate { p2_logout_btn.Visible = false; }));
            //p1_1_login_panel.Invoke(new MethodInvoker(delegate { p1_1_login_panel.Visible = true; }));
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

        private void p3_roomname_tbx_VisibleChanged(object sender, EventArgs e)
        {
            this.ActiveControl = p3_roomname_tbx;   // 커서 포커스 설정
        }

        private void panel3_roomList_VisibleChanged(object sender, EventArgs e)
        {
            client.RequestRoomList();
            p3_comein_label.Text = String.Format("{0} 님 접속 중", p1_username_tbx.Text);
            p3_roomname_tbx.Visible = false;
        }

        // 방 만들기 버튼 클릭 시 이벤트
        private void p3_makeRoom_btn_Click(object sender, EventArgs e)
        {
            p3_roomname_label.Visible = true;
            p3_roomname_tbx.Visible = true;
            p3_roomname_tbx.Text = "";
            p3_create_btn.Visible = true;
            p3_people_label.Visible = true;
            p3_people_tbx.Visible = true;
            p3_people_tbx.Text = "";
        }


        //List<string> serverRoomInfo;    // RoomList 함수가 서버로 부터 받아 온 방 정보를 사용하기 위함.

        // 서버에 존재하는 방 정보를 가져와서 방 리스트에 출력
        public override void RoomList(List<string> roomList)
        {
            p3_dataGridView1.Invoke(new MethodInvoker(delegate { p3_dataGridView1.Rows.Clear(); }));

            //새로 고침시, 셀 추가 문제 해결
            //serverRoomInfo = roomList;

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
        /// 
        string roomname; // 현재 방 이름
        private void p3_create_btn_Click(object sender, EventArgs e)
        {
            string roomName = p3_roomname_tbx.Text;
            string roomMax = p3_people_tbx.Text;
            roomname = roomName;

            if (string.IsNullOrEmpty(p3_roomname_tbx.Text))
            {
                ShowMessageBox("방 이름을 입력해주세요", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if(string.IsNullOrEmpty(p3_people_tbx.Text))
            {
                ShowMessageBox("최대 정원을 입력해주세요", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                int maxPeople = Int32.Parse(p3_people_tbx.Text);
                if(maxPeople>5)
                {
                    ShowMessageBox("입장할 수 있는 최대 정원은 5명입니다.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else if(maxPeople<2)
                {
                    ShowMessageBox("2명 이상 입장해야 합니다.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    try
                    {
                        //OwnerWait();
                        //panel3_roomList.Invoke(new MethodInvoker(delegate { panel3_roomList.Visible = false; }));
                        //panel4_1_owner_waitRoom.Invoke(new MethodInvoker(delegate { panel4_1_owner_waitRoom.Visible = true; }));
                        client.RequestRoomCreate(roomName, roomMax);
                    }
                     catch (NullReferenceException n)
                    {
                        ShowMessageBox("create room error","Error",MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    
                }
            }
        }

        public override void RoomCreate(bool success)
        {
            if (success == true)
            {
                ShowMessageBox("방 생성 성공", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                //OwnerWait();

                p4_1_start_btn.Visible = true;

                client.RequestSendRoomChat("시스템", p1_username_tbx.Text + "이(가) 방에 참가함");
                client.RequestPlayerList(roomname); // 현재 방에 접속된 접속 인원 이름을 받아옴.
            }
            else
            {
                ShowMessageBox("방 생성 실패", "Fail", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void p3_people_tbx_KeyPress(object sender, KeyPressEventArgs e)
        {
            // 숫자, 백스페이스, '.'만 입력 가능
            if (!(char.IsDigit(e.KeyChar) || e.KeyChar == Convert.ToChar(Keys.Back)))
            {
                e.Handled = true;
            }

            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                e.Handled = true;
                string roomName = p3_roomname_tbx.Text;
                string roomMax = p3_people_tbx.Text;
                roomname = roomName;

                if (string.IsNullOrEmpty(p3_roomname_tbx.Text))
                {
                    ShowMessageBox("방 이름을 입력해주세요", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else if (string.IsNullOrEmpty(p3_people_tbx.Text))
                {
                    ShowMessageBox("최대 정원을 입력해주세요", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    int maxPeople = Int32.Parse(p3_people_tbx.Text);
                    if (maxPeople > 5)
                    {
                        ShowMessageBox("입장할 수 있는 최대 정원은 5명입니다.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else if (maxPeople < 2)
                    {
                        ShowMessageBox("2명 이상 입장해야 합니다.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        try
                        {
                            client.RequestRoomCreate(roomName, roomMax);
                        }
                        catch (NullReferenceException n)
                        {
                            ShowMessageBox("방을 생성하지 못했습니다.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                    }
                }
            }
        }


        public void Changing()
        {
            panel4_1_owner_waitRoom.Invoke(new MethodInvoker(delegate { panel4_1_owner_waitRoom.Visible = false; }));
            panel4_player_waitRoom.Invoke(new MethodInvoker(delegate { panel4_player_waitRoom.Visible = false; }));
            panel5_1_Owner_Answer.Invoke(new MethodInvoker(delegate { panel5_1_Owner_Answer.Visible=false; }));
            panel5_2_Owner_Wait.Invoke(new MethodInvoker(delegate { panel5_2_Owner_Wait.Visible = false; }));
            panel5_Owner.Invoke(new MethodInvoker(delegate { panel5_Owner.Visible = false; }));
            panel6_Answer.Invoke(new MethodInvoker(delegate { panel6_Answer.Visible = false; }));
            panel6_2_Answer_Wait.Invoke(new MethodInvoker(delegate { panel6_2_Answer_Wait.Visible = false; }));
        }
        //방장의 게임 시작 전 화면. 게임 시작 버튼, 강퇴 버튼 있어야 됨.
        public override void OwnerWait()
        {
            Changing();
            p4_1_roomInfo_label.Invoke(new MethodInvoker(delegate { p4_1_roomInfo_label.Text = "방장 방"; }));
           
            p4_player1.Invoke(new MethodInvoker(delegate { p4_player1.Text = p1_username_tbx.Text; }));
            p4_1_player1.Invoke(new MethodInvoker(delegate { p4_1_player1.Text = p1_username_tbx.Text; }));

            panel3_roomList.Invoke(new MethodInvoker(delegate { panel3_roomList.Visible = false; }));
            panel4_1_owner_waitRoom.Invoke(new MethodInvoker(delegate { panel4_1_owner_waitRoom.Visible = true; }));
            p4_1_chat_tbx.Invoke(new MethodInvoker(delegate { p4_1_chat_tbx.Text = ""; }));

            //client.RequestGameReady();
            //client.RequestPlayerList(roomname);
            p4_1_current_player();
        }

        
        //테이블 내 입장하기 버튼 클릭 시
        private void p3_dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex != -1)
            {
                string rName = p3_dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                roomname = rName;
                if (rName != string.Empty)
                {
                    client.RequestRoomJoin(rName);   // 서버에 방 이름 정보 보냄
                    //panel3_roomList.Invoke(new MethodInvoker(delegate { panel3_roomList.Visible = false; }));
                    //panel4_player_waitRoom.Invoke(new MethodInvoker(delegate { panel4_player_waitRoom.Visible = true; }));
                    //client.RequestRoomCreate(roomName, "5");
                    //PlayerWait();
                }
            }
        }

        private void p3_dataGridView1_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            
            foreach (DataGridViewColumn item in p3_dataGridView1.Columns)
            {
                item.SortMode = DataGridViewColumnSortMode.NotSortable;
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
            else if (result.Equals("-3"))
            {
                ShowMessageBox("당신은 이 방에서 퇴장당했습니다.", "Fail", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                p4_Out_btn_Click(null,null);
            }else if (result.Equals("-4"))
            {
                ShowMessageBox("이미 게임중인 방에는 참가할 수 없습니다.", "Fail", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                ShowMessageBox(result + " 방에 참가완료", "Room Join", MessageBoxButtons.OK, MessageBoxIcon.Information);
                panel8_friend.Invoke(new MethodInvoker(delegate { panel8_friend.Visible = false; }));

                // 플레이어의 대기 방 패널로 넘어가야 됨.
                try
                {
                    PlayerWait();   // 참가자의 게임 시작 전 화면

                    client.RequestSendRoomChat("유저", p1_username_tbx.Text + "이(가) 방에 참가함");
                    client.RequestPlayerList(roomname); // 현재 방에 접속된 접속 인원 이름을 받아옴.
                }
                catch(NullReferenceException n)
                {
                    ShowMessageBox("player wait room Error","Error",MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        public override void PlayerWait()
        {
            Changing();
            // 참가자의 게임 시작 전 화면 -> 플레이어 대기 방 화면
            //panel3_roomList.Visible = false;
            //panel4_player_waitRoom.Visible = true;
            p4_chat_tbx.Invoke(new MethodInvoker(delegate {  p4_chat_tbx.Text = ""; }));

            p4_roomInfo_label.Invoke(new MethodInvoker(delegate { p4_roomInfo_label.Text = "플레이어 방"; }));
            panel3_roomList.Invoke(new MethodInvoker(delegate { panel3_roomList.Visible = false; }));
            panel4_player_waitRoom.Invoke(new MethodInvoker(delegate { panel4_player_waitRoom.Visible = true; }));
        }

        // 새로 고침 버튼 클릭 시 이벤트
        private void p3_refresh_btn_Click(object sender, EventArgs e)
        {
            client.RequestRoomList();
        }

        // 뒤로 가기 버튼 클릭 시 이벤트
        private void p3_back_btn_Click(object sender, EventArgs e)
        {
            client.RequestRoomOut("0");
            p3_title_label.Visible = false;
            p3_people_label.Visible = false;
            p3_people_tbx.Visible = false;
            p3_create_btn.Visible = false;
            p3_roomname_label.Visible = false;
            p3_roomname_tbx.Visible = false;
            //panel3_roomList.Visible = false;
            //panel2_gameStart.Visible = true;
            backPanel();
        }

        private void backPanel()
        {
            panel3_roomList.Invoke(new MethodInvoker(delegate { panel3_roomList.Visible = false; }));
            panel2_gameStart.Invoke(new MethodInvoker(() => { panel2_gameStart.Visible = true; }));
        }
        #endregion


        #region panel4_waitRoom: 대기 방(채팅)
        public override void GameReady(bool ready)
        {
            string player = p1_username_tbx.Text;
            if (ready == true)
            {
                p4_ready_btn.Invoke(new MethodInvoker(delegate { p4_ready_btn.Text = "Cancel"; }));
            }
            else
            {
                p4_ready_btn.Invoke(new MethodInvoker(delegate { p4_ready_btn.Text = "Ready"; }));
            }
        }

        public override void ReadyList(List<string> readyList)
        {
            // 재입장시. 준비 완료 -> 대기중으로 바뀌지 않아 대기 중은 패널 시작시 넣음.
            //플레이어 화면

            p4_w_state_player2.Invoke(new MethodInvoker(delegate { p4_w_state_player2.Text = "대기 중"; }));
            p4_w_state_player3.Invoke(new MethodInvoker(delegate { p4_w_state_player3.Text = "대기 중"; }));
            p4_w_state_player4.Invoke(new MethodInvoker(delegate { p4_w_state_player4.Text = "대기 중"; }));
            p4_w_state_player5.Invoke(new MethodInvoker(delegate { p4_w_state_player5.Text = "대기 중"; }));

            p4_1_state_player2.Invoke(new MethodInvoker(delegate { p4_1_state_player2.Text = "대기 중"; }));
            p4_1_state_player3.Invoke(new MethodInvoker(delegate { p4_1_state_player3.Text = "대기 중"; }));
            p4_1_state_player4.Invoke(new MethodInvoker(delegate { p4_1_state_player4.Text = "대기 중"; }));
            p4_1_state_player5.Invoke(new MethodInvoker(delegate { p4_1_state_player5.Text = "대기 중"; }));

            if (readyList.Contains(p4_player2.Text)) p4_w_state_player2.Invoke(new MethodInvoker(delegate { p4_w_state_player2.Text = "준비완료"; }));

            if (readyList.Contains(p4_player3.Text)) p4_w_state_player3.Invoke(new MethodInvoker(delegate { p4_w_state_player3.Text = "준비완료"; }));

            if (readyList.Contains(p4_player4.Text)) p4_w_state_player4.Invoke(new MethodInvoker(delegate { p4_w_state_player4.Text = "준비완료"; }));

            if (readyList.Contains(p4_player5.Text)) p4_w_state_player5.Invoke(new MethodInvoker(delegate { p4_w_state_player5.Text = "준비완료"; }));

            //방장 화면
            if (readyList.Contains(p4_1_player2.Text)) p4_1_state_player2.Invoke(new MethodInvoker(delegate { p4_1_state_player2.Text = "준비완료"; }));

            if (readyList.Contains(p4_1_player3.Text)) p4_1_state_player3.Invoke(new MethodInvoker(delegate { p4_1_state_player3.Text = "준비완료"; }));

            if (readyList.Contains(p4_1_player4.Text)) p4_1_state_player4.Invoke(new MethodInvoker(delegate { p4_1_state_player4.Text = "준비완료"; }));

            if (readyList.Contains(p4_1_player5.Text)) p4_1_state_player5.Invoke(new MethodInvoker(delegate { p4_1_state_player5.Text = "준비완료"; }));
        }

        // 목록 클리어 > owner화면 & 접속자 화면
        private void PlayerList_clear()
        {
            // 방장 = player1 > 방장이라 state label 설정 x
            p4_player1.Invoke(new MethodInvoker(delegate { p4_player1.Text = ""; }));   // 이름 초기화
            p4_player1.Invoke(new MethodInvoker(delegate { p4_player1.ForeColor = Color.Black; })); // 글자색 초기화
            p4_1_player1.Invoke(new MethodInvoker(delegate { p4_1_player1.Text = ""; }));
            p4_1_player1.Invoke(new MethodInvoker(delegate { p4_1_player1.ForeColor = Color.Black; }));

            p5_player1.Invoke(new MethodInvoker(delegate { p5_player1.Text = ""; }));   // 이름 초기화
            p5_1_player1.Invoke(new MethodInvoker(delegate { p5_1_player1.Text = ""; }));
            p5_2_player1.Invoke(new MethodInvoker(delegate { p5_2_player1.Text = ""; }));

            p6_player1.Invoke(new MethodInvoker(delegate { p6_player1.Text = ""; }));   // 이름 초기화
            p6_2_player1.Invoke(new MethodInvoker(delegate { p6_2_player1.Text = ""; }));

            // player2  
            p4_player2.Invoke(new MethodInvoker(delegate { p4_player2.Text = ""; }));
            p4_player2.Invoke(new MethodInvoker(delegate { p4_player2.ForeColor = Color.Black; }));
            p4_player2.Invoke(new MethodInvoker(delegate { p4_player2.BackColor = Color.LightGray; }));   // 배경 색 초기화
            p4_w_state_player2.Invoke(new MethodInvoker(delegate { p4_w_state_player2.Visible = false; }));
            p4_1_player2.Invoke(new MethodInvoker(delegate { p4_1_player2.Text = ""; }));
            p4_1_player2.Invoke(new MethodInvoker(delegate { p4_1_player2.ForeColor = Color.Black; }));
            p4_1_player2.Invoke(new MethodInvoker(delegate { p4_1_player2.BackColor = Color.LightGray; }));
            p4_1_state_player2.Invoke(new MethodInvoker(delegate { p4_1_state_player2.Visible = false; }));

            p5_player2.Invoke(new MethodInvoker(delegate { p5_player2.Text = ""; }));   // 이름 초기화
            p5_player2.Invoke(new MethodInvoker(delegate { p5_player2.BackColor = Color.LightGray; }));   // 배경 색 초기화
            p5_player2_score.Invoke(new MethodInvoker(delegate { p5_player2_score.Visible = false; }));
            p5_1_player2.Invoke(new MethodInvoker(delegate { p5_1_player2.Text = ""; }));// 이름 초기화
            p5_1_player2.Invoke(new MethodInvoker(delegate { p5_1_player2.BackColor = Color.LightGray; }));   // 배경 색 초기화
            p5_1_player2_score.Invoke(new MethodInvoker(delegate { p5_1_player2_score.Visible = false; }));
            p5_2_player2.Invoke(new MethodInvoker(delegate { p5_2_player2.Text = ""; }));
            p5_2_player2.Invoke(new MethodInvoker(delegate { p5_2_player2.BackColor = Color.LightGray; }));   // 배경 색 초기화
            p5_2_player2_score.Invoke(new MethodInvoker(delegate { p5_2_player2_score.Visible = false; }));

            p6_player2.Invoke(new MethodInvoker(delegate { p6_player2.Text = ""; }));   // 이름 초기화
            p6_player2.Invoke(new MethodInvoker(delegate { p6_player2.BackColor = Color.LightGray; }));   // 배경 색 초기화
            p6_player2_score.Invoke(new MethodInvoker(delegate { p6_player2_score.Visible = false; }));
            p6_2_player2.Invoke(new MethodInvoker(delegate { p6_2_player2.Text = ""; }));
            p6_2_player2.Invoke(new MethodInvoker(delegate { p6_2_player2.BackColor = Color.LightGray; }));   // 배경 색 초기화
            p6_2_player2_score.Invoke(new MethodInvoker(delegate { p6_2_player2_score.Visible = false; }));

            // player3
            p4_player3.Invoke(new MethodInvoker(delegate { p4_player3.Text = ""; }));
            p4_player3.Invoke(new MethodInvoker(delegate { p4_player3.ForeColor = Color.Black; }));
            p4_player3.Invoke(new MethodInvoker(delegate { p4_player3.BackColor = Color.LightGray; }));
            p4_w_state_player3.Invoke(new MethodInvoker(delegate { p4_w_state_player3.Visible = false; }));
            p4_1_player3.Invoke(new MethodInvoker(delegate { p4_1_player3.Text = ""; }));
            p4_1_player3.Invoke(new MethodInvoker(delegate { p4_1_player3.ForeColor = Color.Black; }));
            p4_1_player3.Invoke(new MethodInvoker(delegate { p4_1_player3.BackColor = Color.LightGray; }));
            p4_1_state_player3.Invoke(new MethodInvoker(delegate { p4_1_state_player3.Visible = false; }));

            p5_player3.Invoke(new MethodInvoker(delegate { p5_player3.Text = ""; }));   // 이름 초기화
            p5_player3.Invoke(new MethodInvoker(delegate { p5_player3.BackColor = Color.LightGray; }));   // 배경 색 초기화
            p5_player3_score.Invoke(new MethodInvoker(delegate { p5_player3_score.Visible = false; }));
            p5_1_player3.Invoke(new MethodInvoker(delegate { p5_1_player3.Text = ""; }));// 이름 초기화
            p5_1_player3.Invoke(new MethodInvoker(delegate { p5_1_player3.BackColor = Color.LightGray; }));   // 배경 색 초기화
            p5_1_player3_score.Invoke(new MethodInvoker(delegate { p5_1_player3_score.Visible = false; }));
            p5_2_player3.Invoke(new MethodInvoker(delegate { p5_2_player3.Text = ""; }));
            p5_2_player3.Invoke(new MethodInvoker(delegate { p5_2_player3.BackColor = Color.LightGray; }));   // 배경 색 초기화
            p5_2_player3_score.Invoke(new MethodInvoker(delegate { p5_2_player3_score.Visible = false; }));

            p6_player3.Invoke(new MethodInvoker(delegate { p6_player3.Text = ""; }));   // 이름 초기화
            p6_player3.Invoke(new MethodInvoker(delegate { p6_player3.BackColor = Color.LightGray; }));   // 배경 색 초기화
            p6_player3_score.Invoke(new MethodInvoker(delegate { p6_player3_score.Visible = false; }));
            p6_2_player3.Invoke(new MethodInvoker(delegate { p6_2_player3.Text = ""; }));
            p6_2_player3.Invoke(new MethodInvoker(delegate { p6_2_player3.BackColor = Color.LightGray; }));   // 배경 색 초기화
            p6_2_player3_score.Invoke(new MethodInvoker(delegate { p6_2_player3_score.Visible = false; }));

            // player4
            p4_player4.Invoke(new MethodInvoker(delegate { p4_player4.Text = ""; }));
            p4_player4.Invoke(new MethodInvoker(delegate { p4_player4.ForeColor = Color.Black; }));
            p4_player4.Invoke(new MethodInvoker(delegate { p4_player4.BackColor = Color.LightGray; }));
            p4_w_state_player4.Invoke(new MethodInvoker(delegate { p4_w_state_player4.Visible = false; }));
            p4_1_player4.Invoke(new MethodInvoker(delegate { p4_1_player4.Text = ""; }));
            p4_1_player4.Invoke(new MethodInvoker(delegate { p4_1_player4.ForeColor = Color.Black; }));
            p4_1_player4.Invoke(new MethodInvoker(delegate { p4_1_player4.BackColor = Color.LightGray; }));
            p4_1_state_player4.Invoke(new MethodInvoker(delegate { p4_1_state_player4.Visible = false; }));

            p5_player4.Invoke(new MethodInvoker(delegate { p5_player4.Text = ""; }));   // 이름 초기화
            p5_player4.Invoke(new MethodInvoker(delegate { p5_player4.BackColor = Color.LightGray; }));   // 배경 색 초기화
            p5_player4_score.Invoke(new MethodInvoker(delegate { p5_player4_score.Visible = false; }));
            p5_1_player4.Invoke(new MethodInvoker(delegate { p5_1_player4.Text = ""; }));// 이름 초기화
            p5_1_player4.Invoke(new MethodInvoker(delegate { p5_1_player4.BackColor = Color.LightGray; }));   // 배경 색 초기화
            p5_1_player4_score.Invoke(new MethodInvoker(delegate { p5_1_player4_score.Visible = false; }));
            p5_2_player4.Invoke(new MethodInvoker(delegate { p5_2_player4.Text = ""; }));
            p5_2_player4.Invoke(new MethodInvoker(delegate { p5_2_player4.BackColor = Color.LightGray; }));   // 배경 색 초기화
            p5_2_player4_score.Invoke(new MethodInvoker(delegate { p5_2_player4_score.Visible = false; }));

            p6_player4.Invoke(new MethodInvoker(delegate { p6_player4.Text = ""; }));   // 이름 초기화
            p6_player4.Invoke(new MethodInvoker(delegate { p6_player4.BackColor = Color.LightGray; }));   // 배경 색 초기화
            p6_player4_score.Invoke(new MethodInvoker(delegate { p6_player4_score.Visible = false; }));
            p6_2_player4.Invoke(new MethodInvoker(delegate { p6_2_player4.Text = ""; }));
            p6_2_player4.Invoke(new MethodInvoker(delegate { p6_2_player4.BackColor = Color.LightGray; }));   // 배경 색 초기화
            p6_2_player4_score.Invoke(new MethodInvoker(delegate { p6_2_player4_score.Visible = false; }));

            // player5
            p4_player5.Invoke(new MethodInvoker(delegate { p4_player5.Text = ""; }));
            p4_player5.Invoke(new MethodInvoker(delegate { p4_player5.ForeColor = Color.Black; }));
            p4_player5.Invoke(new MethodInvoker(delegate { p4_player5.BackColor = Color.LightGray; }));
            p4_w_state_player5.Invoke(new MethodInvoker(delegate { p4_w_state_player5.Visible = false; }));
            p4_1_player5.Invoke(new MethodInvoker(delegate { p4_1_player5.Text = ""; }));
            p4_1_player5.Invoke(new MethodInvoker(delegate { p4_1_player5.ForeColor = Color.Black; }));
            p4_1_player5.Invoke(new MethodInvoker(delegate { p4_1_player5.BackColor = Color.LightGray; }));
            p4_1_state_player5.Invoke(new MethodInvoker(delegate { p4_1_state_player5.Visible = false; }));

            p5_player5.Invoke(new MethodInvoker(delegate { p5_player5.Text = ""; }));   // 이름 초기화
            p5_player5.Invoke(new MethodInvoker(delegate { p5_player5.BackColor = Color.LightGray; }));   // 배경 색 초기화
            p5_player5_score.Invoke(new MethodInvoker(delegate { p5_player5_score.Visible = false; }));
            p5_1_player5.Invoke(new MethodInvoker(delegate { p5_1_player5.Text = ""; }));// 이름 초기화
            p5_1_player5.Invoke(new MethodInvoker(delegate { p5_1_player5.BackColor = Color.LightGray; }));   // 배경 색 초기화
            p5_1_player5_score.Invoke(new MethodInvoker(delegate { p5_1_player5_score.Visible = false; }));
            p5_2_player5.Invoke(new MethodInvoker(delegate { p5_2_player5.Text = ""; }));
            p5_2_player5.Invoke(new MethodInvoker(delegate { p5_2_player5.BackColor = Color.LightGray; }));   // 배경 색 초기화
            p5_2_player5_score.Invoke(new MethodInvoker(delegate { p5_2_player5_score.Visible = false; }));

            p6_player5.Invoke(new MethodInvoker(delegate { p6_player5.Text = ""; }));   // 이름 초기화
            p6_player5.Invoke(new MethodInvoker(delegate { p6_player5.BackColor = Color.LightGray; }));   // 배경 색 초기화
            p6_player5_score.Invoke(new MethodInvoker(delegate { p6_player5_score.Visible = false; }));
            p6_2_player5.Invoke(new MethodInvoker(delegate { p6_2_player5.Text = ""; }));
            p6_2_player5.Invoke(new MethodInvoker(delegate { p6_2_player5.BackColor = Color.LightGray; }));   // 배경 색 초기화
            p6_2_player5_score.Invoke(new MethodInvoker(delegate { p6_2_player5_score.Visible = false; }));
        }

        // 접속자 리스트 - 문제: 방장만 제대로 출력x(only 자기 이름)
        public override void PlayerList(List<string> playerList)
        {
            int cnt = playerList.Count;
            PlayerList_clear();
            if (cnt > 0)
            {
                p4_player1.Invoke(new MethodInvoker(delegate { p4_player1.Text = playerList[0]; }));        //플레이어
                p4_1_player1.Invoke(new MethodInvoker(delegate { p4_1_player1.Text = playerList[0]; }));    //방장
                p5_player1.Invoke(new MethodInvoker(delegate { p5_player1.Text = playerList[0]; }));
                p5_1_player1.Invoke(new MethodInvoker(delegate { p5_1_player1.Text = playerList[0]; }));
                p5_2_player1.Invoke(new MethodInvoker(delegate { p5_2_player1.Text = playerList[0]; }));
                p6_player1.Invoke(new MethodInvoker(delegate { p6_player1.Text = playerList[0]; }));
                p6_2_player1.Invoke(new MethodInvoker(delegate { p6_2_player1.Text = playerList[0]; }));
            }
            if (cnt > 1)
            {
                // 플레이어
                p4_player2.Invoke(new MethodInvoker(delegate { p4_player2.Text = playerList[1]; }));
                p4_player2.Invoke(new MethodInvoker(delegate { p4_player2.BackColor = Color.LightSkyBlue; }));
                p4_w_state_player2.Invoke(new MethodInvoker(delegate { p4_w_state_player2.Visible = true; }));

                // 방장
                p4_1_player2.Invoke(new MethodInvoker(delegate { p4_1_player2.Text = playerList[1]; }));
                p4_1_player2.Invoke(new MethodInvoker(delegate { p4_1_player2.BackColor = Color.LightSkyBlue; }));
                p4_1_state_player2.Invoke(new MethodInvoker(delegate { p4_1_state_player2.Visible = true; }));

                p5_player2.Invoke(new MethodInvoker(delegate { p5_player2.Text = playerList[1]; }));
                p5_player2.Invoke(new MethodInvoker(delegate { p5_player2.BackColor = Color.LightSkyBlue; }));
                p5_player2_score.Invoke(new MethodInvoker(delegate { p5_player2_score.Visible = true; }));

                p5_1_player2.Invoke(new MethodInvoker(delegate { p5_1_player2.Text = playerList[1]; }));
                p5_1_player2.Invoke(new MethodInvoker(delegate { p5_1_player2.BackColor = Color.LightSkyBlue; }));
                p5_1_player2_score.Invoke(new MethodInvoker(delegate { p5_1_player2_score.Visible = true; }));

                p5_2_player2.Invoke(new MethodInvoker(delegate { p5_2_player2.Text = playerList[1]; }));
                p5_2_player2.Invoke(new MethodInvoker(delegate { p5_2_player2.BackColor = Color.LightSkyBlue; }));
                p5_2_player2_score.Invoke(new MethodInvoker(delegate { p5_2_player2_score.Visible = true; }));

                p6_player2.Invoke(new MethodInvoker(delegate { p6_player2.Text = playerList[1]; }));
                p6_player2.Invoke(new MethodInvoker(delegate { p6_player2.BackColor = Color.LightSkyBlue; }));
                p6_player2_score.Invoke(new MethodInvoker(delegate { p6_player2_score.Visible = true; }));

                p6_2_player2.Invoke(new MethodInvoker(delegate { p6_2_player2.Text = playerList[1]; }));
                p6_2_player2.Invoke(new MethodInvoker(delegate { p6_2_player2.BackColor = Color.LightSkyBlue; }));
                p6_2_player2_score.Invoke(new MethodInvoker(delegate { p6_2_player2_score.Visible = true; }));
            }
            if (cnt > 2)
            {
                p4_player3.Invoke(new MethodInvoker(delegate { p4_player3.Text = playerList[2]; }));
                p4_player3.Invoke(new MethodInvoker(delegate { p4_player3.BackColor = Color.LightSkyBlue; }));
                p4_w_state_player3.Invoke(new MethodInvoker(delegate { p4_w_state_player3.Visible = true; }));

                p4_1_player3.Invoke(new MethodInvoker(delegate { p4_1_player3.Text = playerList[2]; }));
                p4_1_player3.Invoke(new MethodInvoker(delegate { p4_1_player3.BackColor = Color.LightSkyBlue; }));
                p4_1_state_player3.Invoke(new MethodInvoker(delegate { p4_1_state_player3.Visible = true; }));

                p5_player3.Invoke(new MethodInvoker(delegate { p5_player3.Text = playerList[2]; }));
                p5_player3.Invoke(new MethodInvoker(delegate { p5_player3.BackColor = Color.LightSkyBlue; }));
                p5_player3_score.Invoke(new MethodInvoker(delegate { p5_player3_score.Visible = true; }));

                p5_1_player3.Invoke(new MethodInvoker(delegate { p5_1_player3.Text = playerList[2]; }));
                p5_1_player3.Invoke(new MethodInvoker(delegate { p5_1_player3.BackColor = Color.LightSkyBlue; }));
                p5_1_player3_score.Invoke(new MethodInvoker(delegate { p5_1_player3_score.Visible = true; }));

                p5_2_player3.Invoke(new MethodInvoker(delegate { p5_2_player3.Text = playerList[2]; }));
                p5_2_player3.Invoke(new MethodInvoker(delegate { p5_2_player3.BackColor = Color.LightSkyBlue; }));
                p5_2_player3_score.Invoke(new MethodInvoker(delegate { p5_2_player3_score.Visible = true; }));

                p6_player3.Invoke(new MethodInvoker(delegate { p6_player3.Text = playerList[2]; }));
                p6_player3.Invoke(new MethodInvoker(delegate { p6_player3.BackColor = Color.LightSkyBlue; }));
                p6_player3_score.Invoke(new MethodInvoker(delegate { p6_player3_score.Visible = true; }));

                p6_2_player3.Invoke(new MethodInvoker(delegate { p6_2_player3.Text = playerList[2]; }));
                p6_2_player3.Invoke(new MethodInvoker(delegate { p6_2_player3.BackColor = Color.LightSkyBlue; }));
                p6_2_player3_score.Invoke(new MethodInvoker(delegate { p6_2_player3_score.Visible = true; }));
            }
            if (cnt > 3)
            {
                p4_player4.Invoke(new MethodInvoker(delegate { p4_player4.Text = playerList[3]; }));
                p4_player4.Invoke(new MethodInvoker(delegate { p4_player4.BackColor = Color.LightSkyBlue; }));
                p4_w_state_player4.Invoke(new MethodInvoker(delegate { p4_w_state_player4.Visible = true; }));

                p4_1_player4.Invoke(new MethodInvoker(delegate { p4_1_player4.Text = playerList[3]; }));
                p4_1_player4.Invoke(new MethodInvoker(delegate { p4_1_player4.BackColor = Color.LightSkyBlue; }));
                p4_1_state_player4.Invoke(new MethodInvoker(delegate { p4_1_state_player4.Visible = true; }));

                p5_player4.Invoke(new MethodInvoker(delegate { p5_player4.Text = playerList[3]; }));
                p5_player4.Invoke(new MethodInvoker(delegate { p5_player4.BackColor = Color.LightSkyBlue; }));
                p5_player4_score.Invoke(new MethodInvoker(delegate { p5_player4_score.Visible = true; }));

                p5_1_player4.Invoke(new MethodInvoker(delegate { p5_1_player4.Text = playerList[3]; }));
                p5_1_player4.Invoke(new MethodInvoker(delegate { p5_1_player4.BackColor = Color.LightSkyBlue; }));
                p5_1_player4_score.Invoke(new MethodInvoker(delegate { p5_1_player4_score.Visible = true; }));

                p5_2_player4.Invoke(new MethodInvoker(delegate { p5_2_player4.Text = playerList[3]; }));
                p5_2_player4.Invoke(new MethodInvoker(delegate { p5_2_player4.BackColor = Color.LightSkyBlue; }));
                p5_2_player4_score.Invoke(new MethodInvoker(delegate { p5_2_player4_score.Visible = true; }));

                p6_player4.Invoke(new MethodInvoker(delegate { p6_player4.Text = playerList[3]; }));
                p6_player4.Invoke(new MethodInvoker(delegate { p6_player4.BackColor = Color.LightSkyBlue; }));
                p6_player4_score.Invoke(new MethodInvoker(delegate { p6_player4_score.Visible = true; }));

                p6_2_player4.Invoke(new MethodInvoker(delegate { p6_2_player4.Text = playerList[3]; }));
                p6_2_player4.Invoke(new MethodInvoker(delegate { p6_2_player4.BackColor = Color.LightSkyBlue; }));
                p6_2_player4_score.Invoke(new MethodInvoker(delegate { p6_2_player4_score.Visible = true; }));
            }
            if (cnt > 4)
            {
                p4_player5.Invoke(new MethodInvoker(delegate { p4_player5.Text = playerList[4]; }));
                p4_player5.Invoke(new MethodInvoker(delegate { p4_player5.BackColor = Color.LightSkyBlue; }));
                p4_w_state_player5.Invoke(new MethodInvoker(delegate { p4_w_state_player5.Visible = true; }));

                p4_1_player5.Invoke(new MethodInvoker(delegate { p4_1_player5.Text = playerList[4]; }));
                p4_1_player5.Invoke(new MethodInvoker(delegate { p4_1_player5.BackColor = Color.LightSkyBlue; }));
                p4_1_state_player5.Invoke(new MethodInvoker(delegate { p4_1_state_player5.Visible = true; }));

                p5_player5.Invoke(new MethodInvoker(delegate { p5_player5.Text = playerList[4]; }));
                p5_player5.Invoke(new MethodInvoker(delegate { p5_player5.BackColor = Color.LightSkyBlue; }));
                p5_player5_score.Invoke(new MethodInvoker(delegate { p5_player5_score.Visible = true; }));

                p5_1_player5.Invoke(new MethodInvoker(delegate { p5_1_player5.Text = playerList[4]; }));
                p5_1_player5.Invoke(new MethodInvoker(delegate { p5_1_player5.BackColor = Color.LightSkyBlue; }));
                p5_1_player5_score.Invoke(new MethodInvoker(delegate { p5_1_player5_score.Visible = true; }));

                p5_2_player5.Invoke(new MethodInvoker(delegate { p5_2_player5.Text = playerList[4]; }));
                p5_2_player5.Invoke(new MethodInvoker(delegate { p5_2_player5.BackColor = Color.LightSkyBlue; }));
                p5_2_player5_score.Invoke(new MethodInvoker(delegate { p5_2_player5_score.Visible = true; }));

                p6_player5.Invoke(new MethodInvoker(delegate { p6_player5.Text = playerList[4]; }));
                p6_player5.Invoke(new MethodInvoker(delegate { p6_player5.BackColor = Color.LightSkyBlue; }));
                p6_player5_score.Invoke(new MethodInvoker(delegate { p6_player5_score.Visible = true; }));

                p6_2_player5.Invoke(new MethodInvoker(delegate { p6_2_player5.Text = playerList[4]; }));
                p6_2_player5.Invoke(new MethodInvoker(delegate { p6_2_player5.BackColor = Color.LightSkyBlue; }));
                p6_2_player5_score.Invoke(new MethodInvoker(delegate { p6_2_player5_score.Visible = true; }));

            }
            p4_current_player();
            p4_1_current_player();
            p6_current_player();
            p6_2_current_player();
        }


        private void p4_1_refresh_btn_Click(object sender, EventArgs e)
        {
            p4_1_player_change();
            client.RequestPlayerList(roomname);
        }

        //대기화면 채팅, 게임 질의응답 
        public override void RoomChat(List<string> chatList)
        {
            // 플레이어 채팅
            p4_chat_tbx.Invoke(new MethodInvoker(delegate { p4_chat_tbx.Text = ""; }));
            chatList.ForEach(chat =>
            {
                p4_chat_tbx.Invoke(new MethodInvoker(delegate { p4_chat_tbx.AppendText( chat + "\r\n"); p4_chat_tbx.ScrollToCaret(); }));
            });

            // 방장 채팅
            p4_1_chat_tbx.Invoke(new MethodInvoker(delegate { p4_1_chat_tbx.Text = ""; }));
            chatList.ForEach(chat =>
            {
                p4_1_chat_tbx.Invoke(new MethodInvoker(delegate { p4_1_chat_tbx.AppendText( chat + "\r\n");p4_1_chat_tbx.ScrollToCaret(); }));
            });

            // 현재 방에 아무도 없다면 대화내용 삭제 > 현재의 
            // 게임 시작시, chatList 내용 삭제 후 게임 내용 넣기
            if (panel5_1_Owner_Answer.Visible == true) //판넬5 포함
            {
                //chatList.Clear();
                //chatList = Q_AList;
            }
            p5_1_QA_tbx.Invoke(new MethodInvoker(delegate { p5_1_QA_tbx.Text = ""; }));
            chatList.ForEach(chat =>
            {
                p5_1_QA_tbx.Invoke(new MethodInvoker(delegate { p5_1_QA_tbx.AppendText( chat + "\r\n");
                    p5_1_QA_tbx.Select(p5_1_QA_tbx.Text.Length, 0); p5_1_QA_tbx.ScrollToCaret(); }));
            });

            p5_2_QA_tbx.Invoke(new MethodInvoker(delegate { p5_2_QA_tbx.Text = ""; }));
            chatList.ForEach(chat =>
            {
                p5_2_QA_tbx.Invoke(new MethodInvoker(delegate {
                    p5_2_QA_tbx.AppendText(chat + "\r\n");
                    p5_2_QA_tbx.Select(p5_2_QA_tbx.Text.Length, 0); p5_2_QA_tbx.ScrollToCaret();
                }));
            });

            if ( panel6_Answer.Visible == true) //판넬5 포함
            {
                //chatList.Clear();
                //chatList = Q_AList;
            }
            p6_QA_tbx.Invoke(new MethodInvoker(delegate { p6_QA_tbx.Text = ""; p6_QA_tbx.ScrollToCaret(); }));
            chatList.ForEach(chat =>
            {
                p6_QA_tbx.Invoke(new MethodInvoker(delegate { p6_QA_tbx.AppendText(chat + "\r\n");
                    p6_QA_tbx.Select(p6_QA_tbx.Text.Length, 0); p6_QA_tbx.ScrollToCaret(); }));
            });

            p6_2_QA_tbx.Invoke(new MethodInvoker(delegate { p6_2_QA_tbx.Text = ""; p6_2_QA_tbx.ScrollToCaret();}));
            chatList.ForEach(chat =>
            {
                p6_2_QA_tbx.Invoke(new MethodInvoker(delegate { p6_2_QA_tbx.AppendText(chat + "\r\n");p6_2_QA_tbx.Select(p6_2_QA_tbx.Text.Length, 0);
                    p6_2_QA_tbx.ScrollToCaret();}));
            });
        }
       
        public override void Whisper(string msg)
        {
           
            int sender = Convert.ToInt32(msg.Substring(0, 1));
            switch (sender)
            {
                case 0:
                    p4_1_player1_ballon.Invoke(new MethodInvoker(delegate { p4_1_player1_ballon.Text = msg.Substring(1); }));
                    p4_1_player1_ballon.Invoke(new MethodInvoker(delegate { p4_1_player1_ballon.Visible = true; }));
                    p4_player1_ballon.Invoke(new MethodInvoker(delegate { p4_player1_ballon.Text = msg.Substring(1); }));
                    p4_player1_ballon.Invoke(new MethodInvoker(delegate { p4_player1_ballon.Visible = true; }));

                    break;
                case 1:
                    p4_1_player2_ballon.Invoke(new MethodInvoker(delegate { p4_1_player2_ballon.Text = msg.Substring(1); }));
                    p4_1_player2_ballon.Invoke(new MethodInvoker(delegate { p4_1_player2_ballon.Visible = true; }));
                    p4_player2_ballon.Invoke(new MethodInvoker(delegate { p4_player2_ballon.Text = msg.Substring(1); }));
                    p4_player2_ballon.Invoke(new MethodInvoker(delegate { p4_player2_ballon.Visible = true; }));

                    break;
                case 2:
                    p4_1_player3_ballon.Invoke(new MethodInvoker(delegate { p4_1_player3_ballon.Text = msg.Substring(1); }));
                    p4_1_player3_ballon.Invoke(new MethodInvoker(delegate { p4_1_player3_ballon.Visible = true; }));
                    p4_player3_ballon.Invoke(new MethodInvoker(delegate { p4_player3_ballon.Text = msg.Substring(1); }));
                    p4_player3_ballon.Invoke(new MethodInvoker(delegate { p4_player3_ballon.Visible = true; }));

                    break;
                case 3:
                    p4_1_player4_ballon.Invoke(new MethodInvoker(delegate { p4_1_player4_ballon.Text = msg.Substring(1); }));
                    p4_1_player4_ballon.Invoke(new MethodInvoker(delegate { p4_1_player4_ballon.Visible = true; }));
                    p4_player4_ballon.Invoke(new MethodInvoker(delegate { p4_player4_ballon.Text = msg.Substring(1); }));
                    p4_player4_ballon.Invoke(new MethodInvoker(delegate { p4_player4_ballon.Visible = true; }));

                    break;
                case 4:
                    p4_1_player5_ballon.Invoke(new MethodInvoker(delegate { p4_1_player5_ballon.Text = msg.Substring(1); }));
                    p4_1_player5_ballon.Invoke(new MethodInvoker(delegate { p4_1_player5_ballon.Visible = true; }));
                    p4_player5_ballon.Invoke(new MethodInvoker(delegate { p4_player5_ballon.Text = msg.Substring(1); }));
                    p4_player5_ballon.Invoke(new MethodInvoker(delegate { p4_player5_ballon.Visible = true; }));
                    break;
            }
        }
     
        #region Owner(방장)

        private void p4_1_start_btn_Click(object sender, EventArgs e)
        {
            // 게임 시작하기 버튼 누르면 게임에 모두 준비되었는 지 확인하는 request 보냄
            // 전부 준비 안 되어 있으면 GameStartFail() 실행
            //panel4_1_owner_waitRoom.Visible = false;

            // 화면 지저분하게 전환되어서 일단 보류
            // ShowMessageBox("게임을 시작합니다.","Start!",MessageBoxButtons.OK,MessageBoxIcon.Information);
            //client.RequestReadyList();
            client.RequestGameStart();
        }

        public override void ForceGameOver(int flag)
        {
            if(flag == 1)
            {
                ShowMessageBox("플레이어가 탈주함", "게임 무효", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                ShowMessageBox("알 수 없는 이유", "게임 무효", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // 전부 시작되지 않은 상태에서 방장이 start 버튼을 눌렀을 때 호출됨.
        public override void GameStartFail()
        {
            // 방장 패널에서 시작하기 버튼 안 띄움
            //p4_1_start_btn.Visible = false;
            ShowMessageBox("준비가 완료되지 않았습니다.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void p4_1_message_tbx_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                e.Handled = true;
                string content = p4_1_message_tbx.Text;
                client.username = p1_username_tbx.Text;
                if (content != string.Empty)
                {
                    client.RequestSendRoomChat(client.username, content);
                    p4_1_message_tbx.Text = "";
                }
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

        private void panel4_1_owner_waitRoom_VisibleChanged(object sender, EventArgs e)
        {
            //client.RequestRoomList();
            //RoomList(serverRoomInfo);
            client.RequestPlayerList(roomname);

            if (panel4_1_owner_waitRoom.Visible == true)
            {
                p4_1_state_player2.Invoke(new MethodInvoker(delegate { p4_1_state_player2.Text = "대기 중"; }));
                p4_1_state_player3.Invoke(new MethodInvoker(delegate { p4_1_state_player3.Text = "대기 중"; }));
                p4_1_state_player4.Invoke(new MethodInvoker(delegate { p4_1_state_player4.Text = "대기 중"; }));
                p4_1_state_player5.Invoke(new MethodInvoker(delegate { p4_1_state_player5.Text = "대기 중"; }));
            }
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
        #endregion

        #region RoomOut
        public override void RoomOut()
        {
            ShowMessageBox("방 나옴", "Room Out", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        public override void Kicked()
        {
            p3_title_label.Visible = false;
            p3_people_label.Visible = false;
            p3_people_tbx.Visible = false;
            p3_create_btn.Visible = false;
            p3_roomname_label.Visible = false;
            p3_roomname_tbx.Visible = false;
            backPanel();
            ShowMessageBox("강제 퇴장당함", "Room Out", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void p4_Out_btn_Click(object sender, EventArgs e)
        {
            client.RequestRoomOut("0");
            p4_chat_tbx.Text = "";
            p4_ready_btn.Text = "READY";
            p3_people_label.Visible = false;
            p3_people_tbx.Visible = false;
            p3_create_btn.Visible = false;
            p3_roomname_label.Visible = false;
            panel4_player_waitRoom.Visible = false;
            panel3_roomList.Visible = true;

            p4_player_change();
            p4_1_player_change();
        }

        private void p4_1_out_btn_Click(object sender, EventArgs e)
        {
            client.RequestRoomOut("0");
            p4_1_chat_tbx.Text = "";
            //p4_1_start_btn.Text = "READY";
            p3_people_label.Visible = false;
            p3_people_tbx.Visible = false;
            p3_create_btn.Visible = false;
            p3_roomname_label.Visible = false;
            panel4_1_owner_waitRoom.Invoke(new MethodInvoker(delegate { panel4_1_owner_waitRoom.Visible = false; }));
            panel3_roomList.Invoke(new MethodInvoker(delegate { panel3_roomList.Visible = true; }));
        }
        #endregion

        #region player(플레이어)
        private void p4_message_tbx_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                e.Handled = true;
                string content = p4_message_tbx.Text;
                client.username = p1_username_tbx.Text;
                if (content != string.Empty)
                {
                    client.RequestSendRoomChat(client.username, content);
                    p4_message_tbx.Text = "";
                }
            }
        }

        private void p4_ready_btn_Click(object sender, EventArgs e)
        {
            client.RequestGameReady();
            /*
            client.RequestReadyList();
            p4_Out_btn.Invoke(new MethodInvoker(delegate { p4_Out_btn.Visible = false; }));

            //p4_gameStart_btn.Visible = true;
            string player = p1_username_tbx.Text;
            if (player == p4_player2.Text)
                p4_w_state_player2.Text = "준비 완료";
            if (player == p4_player3.Text)
                p4_w_state_player3.Text = "준비 완료";
            if (player == p4_player4.Text)
                p4_w_state_player4.Text = "준비 완료";
            if (player == p4_player5.Text)
                p4_w_state_player5.Text = "준비 완료";
            
            */
            //Game_start = 2;
            //Q_AList.Clear();
        }
        /*
            // 플레이어의 준비하기 버튼 클릭 후 준비 상태 보냄
            client.RequestGameReady();

            panel4_player_waitRoom.Visible = false;
            panel6_Answer.Visible = true; //p6화면 확인 test
        }
        */
        private void p4_readyDone_btn_Click(object sender, EventArgs e)
        {
            
            // 플레이어가 준비 완료 버튼을 한 번 더 누르면 준비 상태 해지
            // 준비 완료 버튼 숨김
            /*
            p4_readyDone_btn.Invoke(new MethodInvoker(delegate { p4_readyDone_btn.Visible = false; }));
            client.RequestGameReady();
            */
            
        }

        private void p4_refesh_btn_Click(object sender, EventArgs e)
        {
            client.RequestPlayerList(roomname);
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
        
        private void panel4_player_waitRoom_VisibleChanged(object sender, EventArgs e)
        {
            if(panel4_player_waitRoom.Visible == true)
            {
                p4_ready_btn.Invoke(new MethodInvoker(delegate { p4_ready_btn.Visible = true; }));
                p4_w_state_player2.Invoke(new MethodInvoker(delegate { p4_w_state_player2.Text = "대기 중"; }));
                p4_w_state_player3.Invoke(new MethodInvoker(delegate { p4_w_state_player3.Text = "대기 중"; }));
                p4_w_state_player4.Invoke(new MethodInvoker(delegate { p4_w_state_player4.Text = "대기 중"; }));
                p4_w_state_player5.Invoke(new MethodInvoker(delegate { p4_w_state_player5.Text = "대기 중"; }));

                //client.RequestRoomList();
                //RoomList(serverRoomInfo);
                /*
                if(serverRoomInfo!=null)
                    foreach (string room in serverRoomInfo)
                    {
                        string[] roomInfo = room.Split(',');
                        string roomName = roomInfo[0];
                        string playerCount = roomInfo[1];
                        string roomMax = roomInfo[2];

                        //p4_roomInfo_label.Text = "플레이어 방";
                        p4_roomInfo_label.Invoke(new MethodInvoker(delegate { p4_roomInfo_label.Text = "플레이어 방"; }));
                        //p4_roomInfo_label.Invoke(new MethodInvoker(delegate { p4_roomInfo_label.Text = string.Format("{0} 님 {1} 방 접속 중", p1_username_tbx.Text, roomName); }));
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
                */
            }
            else
            {
                //p4_roomInfo_label.Invoke(new MethodInvoker(delegate { p4_roomInfo_label.Visible = false; }));
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



        //owner에서 start클릭 > 아무도 없을 경우 오류 작성 후 작동 x   -->   gameStart 함수에서 처리함.
        /*
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
        */
        #endregion
        #endregion

        public override void CurrentQuestioner(string username)
        {
            // 상태 라벨 true로 하기
            p5_player_turn_label.Invoke(new MethodInvoker(delegate { p5_player_turn_label.Visible = true; }));

            // 패널 안이라 위치에 차이가 있음 > player 라벨과 차이로 계산하여 다시 위치 설정
            int x = p5_1_player1.Location.X - 7;
            int y1 = p5_1_player1.Location.Y - 7;
            int y2 = p5_1_player2.Location.Y - 6;
            int y3 = p5_1_player3.Location.Y - 6;
            int y4 = p5_1_player4.Location.Y - 6;
            int y5 = p5_1_player5.Location.Y - 6;

            // turn 위치로 이동
            // p5 
            if (p5_player1.Text == username) p5_player_turn_label.Invoke(new MethodInvoker(delegate { p5_player_turn_label.Location = new Point(x, y1); }));
            else if (p5_player2.Text == username) p5_player_turn_label.Invoke(new MethodInvoker(delegate { p5_player_turn_label.Location = new Point(x, y2); }));
            else if (p5_player3.Text == username) p5_player_turn_label.Invoke(new MethodInvoker(delegate { p5_player_turn_label.Location = new Point(x, y3); }));
            else if (p5_player4.Text == username) p5_player_turn_label.Invoke(new MethodInvoker(delegate { p5_player_turn_label.Location = new Point(x, y4); }));
            else if (p5_player5.Text == username) p5_player_turn_label.Invoke(new MethodInvoker(delegate { p5_player_turn_label.Location = new Point(x, y5); }));

            // p5_1
            p5_1_player_turn_label.Invoke(new MethodInvoker(delegate { p5_1_player_turn_label.Visible = true; }));

            if (p5_1_player1.Text == username) p5_1_player_turn_label.Invoke(new MethodInvoker(delegate { p5_1_player_turn_label.Location = new Point(x, y1); }));
            else if (p5_1_player2.Text == username) p5_1_player_turn_label.Invoke(new MethodInvoker(delegate { p5_1_player_turn_label.Location = new Point(x, y2); }));
            else if (p5_1_player3.Text == username) p5_1_player_turn_label.Invoke(new MethodInvoker(delegate { p5_1_player_turn_label.Location = new Point(x, y3); }));
            else if (p5_1_player4.Text == username) p5_1_player_turn_label.Invoke(new MethodInvoker(delegate { p5_1_player_turn_label.Location = new Point(x, y4); }));
            else if (p5_1_player5.Text == username) p5_1_player_turn_label.Invoke(new MethodInvoker(delegate { p5_1_player_turn_label.Location = new Point(x, y5); }));

            // p5_2
            p5_2_player_turn_label.Invoke(new MethodInvoker(delegate { p5_2_player_turn_label.Visible = true; }));

            if (p5_player1.Text == username) p5_2_player_turn_label.Invoke(new MethodInvoker(delegate { p5_2_player_turn_label.Location = new Point(x, y1); }));
            else if (p5_2_player2.Text == username) p5_2_player_turn_label.Invoke(new MethodInvoker(delegate { p5_2_player_turn_label.Location = new Point(x, y2); }));
            else if (p5_2_player3.Text == username) p5_2_player_turn_label.Invoke(new MethodInvoker(delegate { p5_2_player_turn_label.Location = new Point(x, y3); }));
            else if (p5_2_player4.Text == username) p5_2_player_turn_label.Invoke(new MethodInvoker(delegate { p5_2_player_turn_label.Location = new Point(x, y4); }));
            else if (p5_2_player5.Text == username) p5_2_player_turn_label.Invoke(new MethodInvoker(delegate { p5_2_player_turn_label.Location = new Point(x, y5); }));

            // p6
            p6_player_turn_label.Invoke(new MethodInvoker(delegate { p6_player_turn_label.Visible = true; }));

            if (p6_player1.Text == username) p6_player_turn_label.Invoke(new MethodInvoker(delegate { p6_player_turn_label.Location = new Point(x, y1); }));
            else if (p6_player2.Text == username) p6_player_turn_label.Invoke(new MethodInvoker(delegate { p6_player_turn_label.Location = new Point(x, y2); }));
            else if (p6_player3.Text == username) p6_player_turn_label.Invoke(new MethodInvoker(delegate { p6_player_turn_label.Location = new Point(x, y3); }));
            else if (p6_player4.Text == username) p6_player_turn_label.Invoke(new MethodInvoker(delegate { p6_player_turn_label.Location = new Point(x, y4); }));
            else if (p6_player5.Text == username) p6_player_turn_label.Invoke(new MethodInvoker(delegate { p6_player_turn_label.Location = new Point(x, y5); }));

            // p6_2
            p6_2_player_turn_label.Invoke(new MethodInvoker(delegate { p6_2_player_turn_label.Visible = true; }));

            if (p6_2_player1.Text == username) p6_2_player_turn_label.Invoke(new MethodInvoker(delegate { p6_2_player_turn_label.Location = new Point(x, y1); }));
            else if (p6_2_player2.Text == username) p6_2_player_turn_label.Invoke(new MethodInvoker(delegate { p6_2_player_turn_label.Location = new Point(x, y2); }));
            else if (p6_2_player3.Text == username) p6_2_player_turn_label.Invoke(new MethodInvoker(delegate { p6_2_player_turn_label.Location = new Point(x, y3); }));
            else if (p6_2_player4.Text == username) p6_2_player_turn_label.Invoke(new MethodInvoker(delegate { p6_2_player_turn_label.Location = new Point(x, y4); }));
            else if (p6_2_player5.Text == username) p6_2_player_turn_label.Invoke(new MethodInvoker(delegate { p6_2_player_turn_label.Location = new Point(x, y5); }));
        }

        bool buzzer_on = false;
        int b_cnt1 = 5, b_cnt2 = 5, b_cnt3 = 5, b_cnt4 = 5, b_cnt5 = 5;
        //정답 버튼
   
        public override void SetBcount(int count)
        {
            b_cnt1 = b_cnt2 = b_cnt3 = b_cnt4 = b_cnt5 = count+1;
            buzzer_label_set();
        }
        static int btnstatus = 0;
        public override void LockByBuzzer()
        {
            p6_2_answer_tbx.Invoke(new MethodInvoker(delegate { p6_2_answer_tbx.Enabled = false; }));
            p6_2_buzzer_btn.Invoke(new MethodInvoker(delegate { p6_2_buzzer_btn.Enabled = false; }));
            p6_2_send_btn.Invoke(new MethodInvoker(delegate { p6_2_send_btn.Enabled = false; }));
            p6_answer_tbx.Invoke(new MethodInvoker(delegate { p6_answer_tbx.Enabled = false; }));
            p6_buzzer_btn.Invoke(new MethodInvoker(delegate { p6_buzzer_btn.Enabled = false; }));
            p6_send_btn.Invoke(new MethodInvoker(delegate { p6_send_btn.Enabled = false; }));
        }
        public override void UnlockByBuzzer()
        {
            p6_2_answer_tbx.Invoke(new MethodInvoker(delegate { p6_2_answer_tbx.Enabled = true; }));
            p6_2_buzzer_btn.Invoke(new MethodInvoker(delegate { p6_2_buzzer_btn.Enabled = true; }));
            p6_2_send_btn.Invoke(new MethodInvoker(delegate { p6_2_send_btn.Enabled = true; }));
            p6_answer_tbx.Invoke(new MethodInvoker(delegate { p6_answer_tbx.Enabled = true; }));
            p6_buzzer_btn.Invoke(new MethodInvoker(delegate { p6_buzzer_btn.Enabled = true; }));
            p6_send_btn.Invoke(new MethodInvoker(delegate { p6_send_btn.Enabled = true; }));
        }
        private void buzzer_label_set()
        {
            string p_name = p1_username_tbx.Text;
            if (p_name == p4_player1.Text)
            {
                b_cnt1--;
                if (b_cnt1 <= 0)
                {
                    p6_buzzer_btn.Text = "정답 ( 0 / 5 )";
                    p6_2_buzzer_btn.Text = "정답 ( 0 / 5 )";
                }

                else
                {
                    p6_buzzer_btn.Text = "정답 ( " + b_cnt1 + "/ 5 )";
                    p6_2_buzzer_btn.Text = "정답 ( " + b_cnt1 + "/ 5 )";
                }
            }
            else if (p_name == p4_player2.Text)
            {
                b_cnt2--;
                if (b_cnt2 <= 0)
                {
                    p6_buzzer_btn.Text = "정답 ( 0 / 5 )";
                    p6_2_buzzer_btn.Text = "정답 ( 0 / 5 )";
                }
                else
                {
                    p6_buzzer_btn.Text = "정답 ( " + b_cnt2 + "/ 5 )";
                    p6_2_buzzer_btn.Text = "정답 ( " + b_cnt2 + "/ 5 )";
                }
            }
            else if (p_name == p4_player3.Text)
            {
                b_cnt3--;
                if (b_cnt3 <= 0)
                {
                    p6_buzzer_btn.Text = "정답 ( 0 / 5 )";
                    p6_2_buzzer_btn.Text = "정답 ( 0 / 5 )";
                }
                else
                {
                    p6_buzzer_btn.Text = "정답 ( " + b_cnt3 + "/ 5 )";
                    p6_2_buzzer_btn.Text = "정답 ( " + b_cnt3 + "/ 5 )";
                }
            }
            else if (p_name == p4_player4.Text)
            {
                b_cnt4--;
                if (b_cnt4 <= 0)
                {
                    p6_buzzer_btn.Text = "정답 ( 0 / 5 )";
                    p6_2_buzzer_btn.Text = "정답 ( 0 / 5 )";
                }
                else
                {
                    p6_buzzer_btn.Text = "정답 ( " + b_cnt4 + "/ 5 )";
                    p6_2_buzzer_btn.Text = "정답 ( " + b_cnt4 + "/ 5 )";
                }
            }
            else if (p_name == p4_player5.Text)
            {
                b_cnt5--;
                if (b_cnt5 <= 0)
                {
                    p6_buzzer_btn.Text = "정답 ( 0 / 5 )";
                    p6_2_buzzer_btn.Text = "정답 ( 0 / 5 )";
                }
                else
                {
                    p6_buzzer_btn.Text = "정답 ( " + b_cnt5 + "/ 5 )";
                    p6_2_buzzer_btn.Text = "정답 ( " + b_cnt5 + "/ 5 )";
                }
            }
        }
        private void buzzer_Click(object sender, EventArgs e)
        {
            buzzer_on = true;
            if (b_cnt1 <= 0)
            {
                ShowMessageBox("부저 횟수 초과", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                buzzer_on = false;
                return;
            }
            if (b_cnt2 <= 0)
            {
                ShowMessageBox("부저 횟수 초과", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                buzzer_on = false;
                return;
            }
            if (b_cnt3 <= 0)
            {
                ShowMessageBox("부저 횟수 초과", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                buzzer_on = false; return;
            }
            if (b_cnt4 <= 0)
            {
                ShowMessageBox("부저 횟수 초과", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                buzzer_on = false; return;
            }
            if (b_cnt5 <= 0)
            {
                ShowMessageBox("부저 횟수 초과", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                buzzer_on = false; return;
            }
            //정답을 맞추는 사람만 라벨 변경 필요 > 출제자가 정답 전송 시 스코어 늘리기
            p6_timer_label.Invoke(new MethodInvoker(delegate { p6_timer_label.Visible = true; }));
            p6_2_timer_label.Invoke(new MethodInvoker(delegate { p6_2_timer_label.Visible = true; }));
            p6_timer_label.Invoke(new MethodInvoker(delegate { p6_timer_label.Text = "0"; }));
            p6_2_timer_label.Invoke(new MethodInvoker(delegate { p6_2_timer_label.Text = "0"; }));
            timer1.Start();
            client.RequestBuzzer();
            

            //폼을 정답 맞추는 것으로 바꿔야 함 - 턴 없애기, tbx 입력
            //버저를 누른 유저에게만 해당하도록 설정 필요
            p6_player_turn_label.Invoke(new MethodInvoker(delegate { p6_player_turn_label.Visible = false; }));
            p6_answer_tbx.Invoke(new MethodInvoker(delegate { p6_answer_tbx.ReadOnly = false; }));
            p6_answer_tbx.Invoke(new MethodInvoker(delegate { p6_answer_tbx.Text = ""; }));
            p6_answer_tbx.ForeColor = Color.CornflowerBlue;

            p6_2_player_turn_label.Invoke(new MethodInvoker(delegate { p6_2_player_turn_label.Visible = false; }));
            p6_2_answer_tbx.Invoke(new MethodInvoker(delegate { p6_2_answer_tbx.ReadOnly = false; }));
            p6_2_answer_tbx.Invoke(new MethodInvoker(delegate { p6_2_answer_tbx.Text = ""; }));
            p6_2_answer_tbx.ForeColor = Color.CornflowerBlue;

            //부저 제한 횟수 넘길 시, 오류 출력 필요 > 사람마다 횟수 계산

            buzzer_label_set();
        }

       
        private void timer1_Tick(object sender, EventArgs e)
        {   //시간 표시할 라벨     

            p6_timer_label.Invoke(new MethodInvoker(delegate { p6_timer_label.Text = (Convert.ToInt32(p6_timer_label.Text) + 1).ToString(); }));
            p6_2_timer_label.Invoke(new MethodInvoker(delegate { p6_2_timer_label.Text = (Convert.ToInt32(p6_timer_label.Text) + 1).ToString(); }));
            if (p6_timer_label.Text == "5")
            { 
                buzzer_on=false;
                timer1.Stop();
                string ans=p6_answer_tbx.Text;
                if (p6_2_answer_tbx.Visible)
                    ans = p6_2_answer_tbx.Text;
                client.RequestGuessAnswer(ans);  // 정답인지 확인
                //답 읽어오기
            }
            
        }

        public override void RefreshWins(string wins_arr)
        {
            string[] strings = wins_arr.Split(',');
            int[] score=new int[strings.Length];
            for(int i=0;i<strings.Length; i++)
            {
                score[i] = Convert.ToInt32(strings[i]);
            }
            switch (score.Length-1)
            {
                case 4:
                    p5_player5_score.Invoke(new MethodInvoker(delegate { p5_player5_score.Text = "점수 : " + score[4].ToString(); }));
                    p5_1_player5_score.Invoke(new MethodInvoker(delegate { p5_1_player5_score.Text = "점수 : " + score[4].ToString(); }));
                    p5_2_player5_score.Invoke(new MethodInvoker(delegate { p5_2_player5_score.Text = "점수 : " + score[4].ToString(); }));
                    p6_2_player5_score.Invoke(new MethodInvoker(delegate { p6_2_player5_score.Text = "점수 : " + score[4].ToString(); }));
                    p6_player5_score.Invoke(new MethodInvoker(delegate { p6_player5_score.Text = "점수 : " + score[4].ToString(); }));
                    goto case 0;
                case 3:
                    p5_player4_score.Invoke(new MethodInvoker(delegate { p5_player4_score.Text = "점수 : " + score[3].ToString(); }));
                    p5_1_player4_score.Invoke(new MethodInvoker(delegate { p5_1_player4_score.Text = "점수 : " + score[3].ToString(); }));
                    p5_2_player4_score.Invoke(new MethodInvoker(delegate { p5_2_player4_score.Text = "점수 : " + score[3].ToString(); }));
                    p6_2_player4_score.Invoke(new MethodInvoker(delegate { p6_2_player4_score.Text = "점수 : " + score[3].ToString(); }));
                    p6_player4_score.Invoke(new MethodInvoker(delegate { p6_player4_score.Text = "점수 : " + score[3].ToString(); }));
                    goto case 2;
                case 2:
                    p5_player3_score.Invoke(new MethodInvoker(delegate { p5_player3_score.Text = "점수 : " + score[2].ToString(); }));
                    p5_1_player3_score.Invoke(new MethodInvoker(delegate { p5_1_player3_score.Text = "점수 : " + score[2].ToString(); }));
                    p5_2_player3_score.Invoke(new MethodInvoker(delegate { p5_2_player3_score.Text = "점수 : " + score[2].ToString(); }));
                    p6_2_player3_score.Invoke(new MethodInvoker(delegate { p6_2_player3_score.Text = "점수 : " + score[2].ToString(); }));
                    p6_player3_score.Invoke(new MethodInvoker(delegate { p6_player3_score.Text = "점수 : " + score[2].ToString(); }));
                    goto case 1;
                case 1:
                    p5_player2_score.Invoke(new MethodInvoker(delegate { p5_player2_score.Text = "점수 : " + score[1].ToString(); }));
                    p5_1_player2_score.Invoke(new MethodInvoker(delegate { p5_1_player2_score.Text = "점수 : " + score[1].ToString(); }));
                    p5_2_player2_score.Invoke(new MethodInvoker(delegate { p5_2_player2_score.Text = "점수 : " + score[1].ToString(); }));
                    p6_2_player2_score.Invoke(new MethodInvoker(delegate { p6_2_player2_score.Text = "점수 : " + score[1].ToString(); }));
                    p6_player2_score.Invoke(new MethodInvoker(delegate { p6_player2_score.Text = "점수 : " + score[1].ToString(); }));
                    goto case 0;
                case 0:
                    p5_player1_score.Invoke(new MethodInvoker(delegate { p5_player1_score.Text = "점수 : " + score[0].ToString(); }));
                    p5_1_player1_score.Invoke(new MethodInvoker(delegate { p5_1_player1_score.Text = "점수 : " + score[0].ToString(); }));
                    p5_2_player1_score.Invoke(new MethodInvoker(delegate { p5_2_player1_score.Text = "점수 : " + score[0].ToString(); }));
                    p6_2_player1_score.Invoke(new MethodInvoker(delegate { p6_2_player1_score.Text = "점수 : " + score[0].ToString(); }));
                    p6_player1_score.Invoke(new MethodInvoker(delegate { p6_player1_score.Text = "점수 : " + score[0].ToString();}));
                    break;
            }

        }


        #region 랭킹
        public override void Ranking(string rank_arr)
        {
            p7_ranking_dgv.Invoke(new MethodInvoker(delegate { p7_ranking_dgv.Rows.Clear(); }));

            string[] id_and_wins = rank_arr.Split(',');
            string row;
            for (int i = 0; i < id_and_wins.Length - 1; i++)
            {
                row = "";
                row +="[[["+(i/2+1)+"위]]] "+"ID : " + id_and_wins[i] + "\t승리: " + id_and_wins[i + 1]
                    + "회\r\n";
               // p_rank_tbx.Invoke(new MethodInvoker(delegate { p_rank_tbx.AppendText( row); }));
                p7_ranking_dgv.Invoke(new MethodInvoker(delegate { p7_ranking_dgv.Rows.Add((i / 2 + 1) + " 위", id_and_wins[i], id_and_wins[i + 1] + " 점"); }));
                i++;
            }
        }

        private void p7_rank_btn_back_Click(object sender, EventArgs e)
        {
            panel7_rank.Invoke(new MethodInvoker(delegate { panel7_rank.Visible = false; }));
            panel3_roomList.Invoke(new MethodInvoker(delegate { panel3_roomList.Visible = true; }));
            p3_people_label.Visible = false;
            p3_people_tbx.Visible = false;
            p3_create_btn.Visible = false;
            p3_roomname_label.Visible = false;
            p3_roomname_tbx.Visible = false;
        }

        private void p3_rank_btn_Click(object sender, EventArgs e)
        {
            client.RequestGetRank();
            panel7_rank.Invoke(new MethodInvoker(delegate { panel7_rank.Visible = true; }));
            panel3_roomList.Invoke(new MethodInvoker(delegate { panel3_roomList.Visible = false; }));
        }
        #endregion

        #region 친구 목록

        public override void FriendList(List<string> friendList)
        {
            p8_friend_dgv.Invoke(new MethodInvoker(delegate { p8_friend_dgv.Rows.Clear(); }));

            for (int i = 0; i < friendList.Count; i++)
            {
                // 표 출력 예시 : [ (숫자) ] [ ID ] [ 초대하기 버튼 ]
                p8_friend_dgv.Invoke(new MethodInvoker(delegate { p8_friend_dgv.Rows.Add(i + 1, friendList[i]); }));
            }
        }

        private void p8_back_btn_Click(object sender, EventArgs e)
        {
            panel8_friend.Invoke(new MethodInvoker(delegate { panel8_friend.Visible = false; }));
            panel3_roomList.Invoke(new MethodInvoker(delegate { panel3_roomList.Visible = true; }));
            p3_people_label.Visible = false;
            p3_people_tbx.Visible = false;
            p3_create_btn.Visible = false;
            p3_roomname_label.Visible = false;
            p3_roomname_tbx.Visible = false;

        }

        private void p3_friend_list_btn_Click(object sender, EventArgs e) 
        {
            client.RequestFirendsList();
            panel8_friend.Invoke(new MethodInvoker(delegate { panel8_friend.Visible = true; }));
            panel3_roomList.Invoke(new MethodInvoker(delegate { panel3_roomList.Visible = false; }));
        }

        /// <summary>
        /// 친구 리스트
        /// 기능 1. 친구 방에 입장하기
        /// 기능 2. 해당 친구 삭제하기
        /// </summary>
        private void p8_friend_dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                if (e.ColumnIndex == p8_dgv_column3.Index)
                {
                    string fName = p8_friend_dgv.Rows[e.RowIndex].Cells[1].Value.ToString();
                    if (fName != string.Empty)
                    {
                        client.RequestJoinFriendRoom(fName);
                    }

                    //ShowMessageBox("1", "1", MessageBoxButtons.OK, MessageBoxIcon.Question);
                }
                if (e.ColumnIndex == p8_dgv_column4.Index)
                {
                    string fName = p8_friend_dgv.Rows[e.RowIndex].Cells[1].Value.ToString();
                    if (fName != string.Empty)
                    {
                        client.RequestFriendRemove(fName);
                    }
                    //ShowMessageBox("2", "2", MessageBoxButtons.OK, MessageBoxIcon.None);
                }
            }
        }

        public override void JoinFriendRoom(int flag)
        {
            if(flag == -1)
            {
                ShowMessageBox("친구가 참가 중인 방이 없습니다.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }else if(flag == -2)
            {
                ShowMessageBox("친구의 방이 이미 게임 중입니다.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }else if(flag == -3)
            {
                ShowMessageBox("친구의 방이 가득 찼습니다.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }else
                ShowMessageBox("친구를 초대하는데 성공했습니다.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public override void FriendRemove(bool sucess)
        {
            //if(sucess) RequestFriendList 정도 호출하면 될듯
            if (sucess == true)
            {
                client.RequestFirendsList();
                ShowMessageBox("친구가 삭제 되었습니다.", "Delete", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                ShowMessageBox("친구가 삭제 되지 않았습니다.", "Not Delete", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        // >>> 친구 추가 하기
        private void p4_player1_item_Click(object sender, EventArgs e)
        {
            client.RequestSendFriendRequest(p4_1_player1.Text);
        }

        private void p4_1_player2_item_Click(object sender, EventArgs e)
        {
            client.RequestSendFriendRequest(p4_1_player2.Text);
        }

        private void p4_1_player3_item_Click(object sender, EventArgs e)
        {
            client.RequestSendFriendRequest(p4_1_player3.Text);
        }

        private void p4_1_player4_item_Click(object sender, EventArgs e)
        {
            client.RequestSendFriendRequest(p4_1_player4.Text);
        }

        private void p4_1_player5_item_Click(object sender, EventArgs e)
        {
            client.RequestSendFriendRequest(p4_1_player5.Text);
        }


        public override void SendFriendRequest(bool success)
        {
            // 친구 요청을 보낼 때 없는 사용자이거나 비어 있는 라벨을 클릭해서 친구 요청을 보낸 경우
            // 친구 요청을 보내는 쪽 화면에 표시됨
 
            if (success == false)
            {
                ShowMessageBox("사용자를 찾을 수 없습니다.", "No", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                // test
                ShowMessageBox("친구 요청을 보냈습니다.", "Yes", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }


        public override void FriendRequest(string username)
        {
            // 친구 요청을 받은 쪽에서 보여짐

            var request_result = MessageBox.Show(string.Format("{0} 님이 친구 요청을 보냈습니다.\n수락하시겠습니까?", username), "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (request_result == DialogResult.Yes)
            {
                // 친구 요청 수락
                client.RequestAcceptFriend(username);
            }
            else
            {
                ShowMessageBox(string.Format("{0} 님의 친구 요청을 거절했습니다.", username), "Information", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }

        public override void AcceptFriend(bool success)
        {
            // 친구 요청을 보낸 쪽에서 보여짐
            /*
             * if(success == false) 사용자를 찾을 수 없습니다.
             */

            if(success==true)
            {
                ShowMessageBox("친구가 되었습니다.","Success",MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                ShowMessageBox("이미 친구가 되어 있습니다.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
        }

        #endregion



        #region 게임 진행 - panel5_Owner, 5_1_Owner_Answer, 5_2_Owner_Wait : 출제자 화면

        private void p5_send_btn_Click(object sender, EventArgs e)
        {
            // presenterchoice 화면과 연결됨 -> panel 5
            p5_input_label.Invoke(new MethodInvoker(delegate { p5_input_label.Text = p5_message_tbx.Text; }));
            client.RequestWordSelect(p5_input_label.Text);
        }

        // 게임 시작 후 출제자가 제시어 정하는 화면
        public override void PresenterChoice()
        {
            Changing();
            // RequestWordSelect() 을 보낼 수 있는 버튼 필요 -> send 버튼으로 지정
            //panel5_Owner.Visible = true;
            p5_message_tbx.Invoke(new MethodInvoker(delegate { p5_message_tbx.Text = ""; }));
            panel5_Owner.Invoke(new MethodInvoker(delegate { panel5_Owner.Visible = true; }));
            p6_2_solution_label.Invoke(new MethodInvoker(delegate { p6_2_solution_label.Text = "입력 중..."; }));
        }

        // 게임 시작 후 출제자가 질문을 기다리는 화면
        public override void PresenterWait()
        {
            Changing();

            panel5_2_Owner_Wait.Invoke(new MethodInvoker(delegate { panel5_2_Owner_Wait.Visible = true; }));
            p5_2_word_label.Invoke(new MethodInvoker(delegate { p5_2_word_label.Text = "정답 : " + p5_message_tbx.Text; }));
        }

        // 게임 시작 후 출제자가 질문에 대한 답변을 작성하는 화면
        public override void PresenterAnswer()
        {
            Changing();
            // RequestSendAnswer()를 보낼 수 있는 버튼 필요
            panel5_1_Owner_Answer.Invoke(new MethodInvoker(delegate { panel5_1_Owner_Answer.Visible = true; }));

            // 제시어를 출제자 화면에는 보여줌
            p5_1_answer_label.Invoke(new MethodInvoker(delegate { p5_1_answer_label.Text = p5_message_tbx.Text; }));
        }

        private void p5_1_yes_btn_Click(object sender, EventArgs e)
        {
            client.RequestSendAnswer("네");
        }

        private void p5_1_no_btn_Click(object sender, EventArgs e)
        {
            client.RequestSendAnswer("아니요");
        }

        private void p5_1_unknown_btn_Click(object sender, EventArgs e)
        {
            client.RequestSendAnswer("잘 모르겠습니다");
        }
        #endregion

        #region 게임 진행 - panel6_Answer : 플레이어(정답자) 화면

        public delegate void Delegateplus();

        private void p6_2_turn()
        {
            p6_2_player_turn_label.Invoke(new MethodInvoker(delegate { p6_2_player_turn_label.Visible = true; }));
            string p_name = p1_username_tbx.Text;
            if (p_name == p4_player1.Text)
                p6_2_player_turn_label.Location = new Point(34, 23);
            else if (p_name == p4_player2.Text)
                p6_2_player_turn_label.Location = new Point(34, 114);
            else if (p_name == p4_player3.Text)
                p6_2_player_turn_label.Location = new Point(34, 204);
            else if (p_name == p4_player4.Text)
                p6_2_player_turn_label.Location = new Point(34, 294);
            else if (p_name == p4_player5.Text)
                p6_2_player_turn_label.Location = new Point(34, 384);
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

        private void p6_2_current_player()
        {
            string p_name = p1_username_tbx.Text;
            if (p_name == p6_2_player1.Text)
            {       //테두리 추가시, 사용자 이름이랑 뒷배경색 안 나옴
                p6_2_player1.BackColor = Color.MediumSeaGreen;
                p6_2_player1_score.BackColor = Color.MediumSeaGreen;
            }
            else if (p_name == p6_2_player2.Text)
            {
                p6_2_player2.BackColor = Color.MediumSeaGreen;
                p6_2_player2_score.BackColor = Color.MediumSeaGreen;
            }
            else if (p_name == p6_2_player3.Text)
            {
                p6_2_player3.BackColor = Color.MediumSeaGreen;
                p6_2_player3_score.BackColor = Color.MediumSeaGreen;
            }
            else if (p_name == p6_2_player4.Text)
            {
                p6_2_player4.BackColor = Color.MediumSeaGreen;
                p6_2_player4_score.BackColor = Color.MediumSeaGreen;
            }
            else if (p_name == p6_2_player5.Text)
            {
                p6_2_player5.BackColor = Color.MediumSeaGreen;
                p6_2_player5_score.BackColor = Color.MediumSeaGreen;
            }
        }

        int turn_cnt = 0;   // 질문 횟수 계산

        // 자동 스크롤
        private void p5_1_QA_tbx_VisibleChanged(object sender, EventArgs e)
        {
            p5_1_QA_tbx.Invoke(new MethodInvoker(delegate {
                p5_1_QA_tbx.AppendText("");
                p5_1_QA_tbx.Select(p5_1_QA_tbx.Text.Length, 0); p5_1_QA_tbx.ScrollToCaret();
            }));

            p5_2_QA_tbx.Invoke(new MethodInvoker(delegate {
                p5_2_QA_tbx.AppendText("");
                p5_2_QA_tbx.Select(p5_2_QA_tbx.Text.Length, 0); p5_2_QA_tbx.ScrollToCaret();
            }));
        }

        private void p5_2_QA_tbx_VisibleChanged(object sender, EventArgs e)
        {
            p5_1_QA_tbx.Invoke(new MethodInvoker(delegate {
                p5_1_QA_tbx.AppendText("");
                p5_1_QA_tbx.Select(p5_1_QA_tbx.Text.Length, 0); p5_1_QA_tbx.ScrollToCaret();
            }));

            p5_2_QA_tbx.Invoke(new MethodInvoker(delegate {
                p5_2_QA_tbx.AppendText("");
                p5_2_QA_tbx.Select(p5_2_QA_tbx.Text.Length, 0); p5_2_QA_tbx.ScrollToCaret();
            }));
        }

        private void p6_QA_tbx_VisibleChanged(object sender, EventArgs e)
        {
            p6_QA_tbx.Invoke(new MethodInvoker(delegate {
                p6_QA_tbx.AppendText("");
                p6_QA_tbx.Select(p6_QA_tbx.Text.Length, 0); p6_QA_tbx.ScrollToCaret();
            }));
   
        }

        private void p6_2_QA_tbx_VisibleChanged(object sender, EventArgs e)
        {
            p6_2_QA_tbx.Invoke(new MethodInvoker(delegate {
                p6_2_QA_tbx.AppendText(""); p6_2_QA_tbx.Select(p6_2_QA_tbx.Text.Length, 0);
                p6_2_QA_tbx.ScrollToCaret();
            }));
        }

        private void p6_2_send_btn_Click(object sender, EventArgs e)
        {
            if (buzzer_on)
            {  // 부저 -> 정답 입력
                client.RequestGuessAnswer(p6_2_answer_tbx.Text);
                buzzer_on = false;
                timer1.Stop();
            }
        }

        private void p6_answer_tbx_KeyPress(object sender, KeyPressEventArgs e)
        {
            // 엔터 입력 시 send 버튼 클릭과 같은 이벤트
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                e.Handled = true;
                if (buzzer_on)
                {  // 부저 -> 정답 입력
                    client.RequestGuessAnswer(p6_answer_tbx.Text);
                    buzzer_on = false;
                    timer1.Stop();
                }
                else            // 일반 질문 입력
                    client.RequestSendQuestion("[ " + turn_cnt + " ] " + p1_username_tbx.Text + " : " + p6_answer_tbx.Text);
                p6_answer_tbx.Text = "";
            }

        }

        private void p5_message_tbx_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                e.Handled = true;
                p5_input_label.Invoke(new MethodInvoker(delegate { p5_input_label.Text = p5_message_tbx.Text; }));
                client.RequestWordSelect(p5_input_label.Text);
            }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            p4_1_player1_ballon.Invoke(new MethodInvoker(delegate { p4_1_player1_ballon.Visible = false; }));
            p4_1_player2_ballon.Invoke(new MethodInvoker(delegate { p4_1_player2_ballon.Visible = false; }));
            p4_1_player3_ballon.Invoke(new MethodInvoker(delegate { p4_1_player3_ballon.Visible = false; }));
            p4_1_player4_ballon.Invoke(new MethodInvoker(delegate { p4_1_player4_ballon.Visible = false; }));
            p4_1_player5_ballon.Invoke(new MethodInvoker(delegate { p4_1_player5_ballon.Visible = false; }));
            p4_player1_ballon.Invoke(new MethodInvoker(delegate { p4_player1_ballon.Visible = false; }));
            p4_player2_ballon.Invoke(new MethodInvoker(delegate { p4_player2_ballon.Visible = false; }));
            p4_player3_ballon.Invoke(new MethodInvoker(delegate { p4_player3_ballon.Visible = false; }));
            p4_player4_ballon.Invoke(new MethodInvoker(delegate { p4_player4_ballon.Visible = false; }));
            p4_player5_ballon.Invoke(new MethodInvoker(delegate { p4_player5_ballon.Visible = false; }));
            timer2.Stop();
            
        }

        private void p4_1_player1_ballon_VisibleChanged(object sender, EventArgs e)
        {
            p4_1_player1_ballon.Invoke(new MethodInvoker(delegate { p4_1_player1_ballon.BringToFront(); }));
            p4_1_player2_ballon.Invoke(new MethodInvoker(delegate { p4_1_player2_ballon.BringToFront(); }));
            p4_1_player3_ballon.Invoke(new MethodInvoker(delegate { p4_1_player3_ballon.BringToFront(); }));
            p4_1_player4_ballon.Invoke(new MethodInvoker(delegate { p4_1_player4_ballon.BringToFront(); }));
            p4_1_player5_ballon.Invoke(new MethodInvoker(delegate { p4_1_player5_ballon.BringToFront(); }));
            p4_player1_ballon.Invoke(new MethodInvoker(delegate { p4_player1_ballon.BringToFront(); }));
            p4_player2_ballon.Invoke(new MethodInvoker(delegate { p4_player2_ballon.BringToFront(); }));
            p4_player3_ballon.Invoke(new MethodInvoker(delegate { p4_player3_ballon.BringToFront(); }));
            p4_player4_ballon.Invoke(new MethodInvoker(delegate { p4_player4_ballon.BringToFront(); }));
            p4_player5_ballon.Invoke(new MethodInvoker(delegate { p4_player5_ballon.BringToFront(); }));
            if (p4_1_player1_ballon.Visible||p4_1_player2_ballon.Visible|| p4_1_player3_ballon.Visible ||
                p4_1_player4_ballon.Visible || p4_1_player5_ballon.Visible || p4_player1_ballon.Visible ||
                p4_player2_ballon.Visible || p4_player3_ballon.Visible || p4_player4_ballon.Visible ||
                p4_player5_ballon.Visible)
            {
                timer2.Start();
            }
       
        }

        private void panel5_Owner_VisibleChanged(object sender, EventArgs e)
        {
            this.ActiveControl = p5_message_tbx;    // 커서 포커싱 설정
        }




        // 게임 시작 후 질문자가 질문을 기다리는 화면 > 턴x
        public override void QuestionerWait()
        {
            Changing();
            
            panel4_player_waitRoom.Invoke(new MethodInvoker(delegate { panel4_player_waitRoom.Visible = false; }));
            panel6_Answer.Invoke(new MethodInvoker(delegate { panel6_Answer.Visible = false; }));
            panel6_2_Answer_Wait.Invoke(new MethodInvoker(delegate { panel6_2_Answer_Wait.Visible = true; }));

            // 타이머 안 보이게
            p6_timer_label.Invoke(new MethodInvoker(delegate { p6_timer_label.Visible = false; }));
            p6_2_timer_label.Invoke(new MethodInvoker(delegate { p6_2_timer_label.Visible = false; }));

            //질의응답 창 test를 위해 주석 처리
            p6_2_answer_tbx.Invoke(new MethodInvoker(delegate { p6_2_answer_tbx.Text = "( 질문 순서가 아닙니다. )"; }));
            p6_2_answer_tbx.Invoke(new MethodInvoker(delegate { p6_2_answer_tbx.ReadOnly = true; }));

            if(turn_cnt >= 21)   // 질문 20번 넘었을 때
                ShowMessageBox("질문 횟수가 20번이 넘었습니다...", "GameOver", MessageBoxButtons.OK, MessageBoxIcon.Stop);
        }

        // 게임 시작 후 질문자가 질문을 작성하는 화면 > 턴o
        public override void QuestionerQuestion()
        {
            Changing();
            panel4_player_waitRoom.Invoke(new MethodInvoker(delegate { panel4_player_waitRoom.Visible = false; }));
            panel6_2_Answer_Wait.Invoke(new MethodInvoker(delegate { panel6_2_Answer_Wait.Visible = false; }));
            panel6_Answer.Invoke(new MethodInvoker(delegate { panel6_Answer.Visible = true; }));

            // 타이머 안 보이게
            p6_timer_label.Invoke(new MethodInvoker(delegate { p6_timer_label.Visible = false; }));
            p6_2_timer_label.Invoke(new MethodInvoker(delegate { p6_2_timer_label.Visible = false; }));

            //사용자 턴에 따른 사용자 리스트 라벨 변경 > 사용자 누구? -> 테두리 색 변환
            if (turn_cnt < 20)
            {
                p6_answer_tbx.Invoke(new MethodInvoker(delegate { p6_answer_tbx.Text = ""; }));
                p6_answer_tbx.Invoke(new MethodInvoker(delegate { p6_answer_tbx.ReadOnly = false; }));  // 입력 받기 가능

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

            this.ActiveControl = p6_answer_tbx; // 커서 포커싱 설정
        }

        private void p6_send_btn_Click(object sender, EventArgs e)
        {
            if (buzzer_on)
            {  // 부저 -> 정답 입력
                client.RequestGuessAnswer(p6_answer_tbx.Text);
                buzzer_on=false;
                timer1.Stop();
            }
            else            // 일반 질문 입력
                client.RequestSendQuestion("[ " + p1_username_tbx.Text + " ] " + p6_answer_tbx.Text);
            p6_answer_tbx.Text = "";
        }
        #endregion

        //클라이언트에서 리퀘스트를 보내도 해당 요청을 처리하기 전에 서버에서 소켓 연결이 끊겨서 예외 처리로 넘어가게 됨.
        //그래서 여기서 처리하는 대신 서버 예외처리 하는 부분에서 처리하도록 바꿨어요
        /*
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            client.RequestExitGame();
        }
        */

    }
}