using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.IO;
using System.Security.Policy;
using System.Runtime.InteropServices.ComTypes;
using System.Drawing;

namespace client
{
    public partial class Client
    {
        private IPAddress serverIP;
        public IPAddress ServerIP { set { serverIP = value; } get { return serverIP; } }

        private StreamReader sreader;
        private StreamWriter swriter;
        private NetworkStream sstream;

        public ClientForm parentForm;

        public string username = "None";
        private bool activate = false;
        public bool Activate { get { return activate; } } //현재 클라이언트가 서버와 접속중인지

        public Client(ClientForm parentForm)
        {
            this.parentForm = parentForm;
        }

        //실행하는 컴퓨터의 ip 주소를 반환
        private string GetMyIP()
        {
            IPHostEntry host = Dns.GetHostEntry(Dns.GetHostName());
            string myIP = string.Empty;
            for (int i = 0; i < host.AddressList.Length; i++)
            {
                if (host.AddressList[i].AddressFamily == AddressFamily.InterNetwork)
                {
                    myIP = host.AddressList[i].ToString();
                    break;
                }
            }

            return myIP;
        }

        //서버와 접속을 시작한다.
        public bool Start(IPAddress newServerIp)
        {
            try
            {
                serverIP = newServerIp;

                //만약 입력된 IP가 127.0.0.1 이면 로컬 연결이므로 clientIP, serverIP 모두 127.0.0.1로
                IPAddress clientIP = IPAddress.Parse("127.0.0.1");
                if (!serverIP.ToString().Equals("127.0.0.1")) clientIP = IPAddress.Parse(GetMyIP());

                //서버에 내 IP를 보냄. 딱히 쓰이는 곳은 없고 로그 출력할 때만 쓰임
                TcpClient client = new TcpClient();
                client.Connect(serverIP, 5000);
                swriter = new StreamWriter(client.GetStream());
                swriter.WriteLine(clientIP);
                sstream=client.GetStream();

                //서버-클라이언트 연결 시작

                sreader = new StreamReader(client.GetStream());
                swriter.AutoFlush = true;

                Thread thread = new Thread(Connecting);
                thread.IsBackground = true;
                thread.Start();

                activate = true;
            }
            catch (Exception ex)
            {
                activate = false;
            }
            return activate;
        }

        //서버에 요청을 보낸다.
        private void SendRequest(string header, string content)
        {
            swriter.WriteLine(header + "|" + content);
        }
        
        //응답을 대기하는 부분. 스레드로 실행됨
        private void Connecting()
        {
            while (true)
            {
                string msg = sreader.ReadLine();
                ResponseProcess(msg);
            }
        }

        private string Img_to_string(Image image)
        {
            MemoryStream ms = new MemoryStream();
            image.Save(ms, image.RawFormat);
            byte[] imgbyte = ms.ToArray();
            string imgstring = Convert.ToBase64String(imgbyte);
            return imgstring;
        }

        //Server - chat_server에서 보낸 응답을 처리
        private void ResponseProcess(string msg)
        {
            string[] response = msg.Split('|');
            string header = response[0];
            if (response.Length < 2)
                return;
            string content = response[1];

            if (header.Equals("NONE"))
            {
                parentForm.ShowMessageBox(content, "Error", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
            else if (header.Equals("GETROOM"))
            {
                parentForm.ViewRoom(int.Parse(content));
            }
            else if (header.Equals("SIGNIN"))
            {
                parentForm.SignIn(content);
            }
            else if (header.Equals("SIGNUP"))
            {
                parentForm.SignUp(content.Equals("1"));
            }
            else if (header.Equals("SIGNOUT"))
            {
                parentForm.SignOut();
            }
            else if (header.Equals("ROOMLIST"))
            {
                if (!content.Equals(string.Empty))
                {
                    List<string> roomList = content.Split(':').ToList();
                    parentForm.RoomList(roomList);
                }
                else
                {
                    parentForm.RoomList(new List<string>());
                }

            }
            else if (header.Equals("ROOMCREATE"))
            {
                parentForm.RoomCreate(content.Equals("1"));
            }
            else if (header.Equals("ROOMJOIN"))
            {
                parentForm.RoomJoin(content);
            }
            else if (header.Equals("ROOMOUT"))
            {
                parentForm.RoomOut();
            }
            else if (header.Equals("KICK"))
            {
                parentForm.Kicked();
            }
            else if (header.Equals("ROOMCHAT"))
            {
                if (!content.Equals(string.Empty))
                {
                    List<string> roomChatList = content.Split(',').ToList();
                    parentForm.RoomChat(roomChatList);
                }
                else
                {
                    parentForm.RoomChat(new List<string>());
                }
            }
            else if (header.Equals("WHISPER"))
            {
                parentForm.Whisper(content);
            }
            else if (header.Equals("PLAYERLIST"))
            {
                // 받아 온 content가 비어있지 않다면, 접속된 유저 이름 가져옴
                if (string.IsNullOrEmpty(content) == false)
                {
                    string[] lines = content.Split(',');
                    List<string> playerList = new List<string>();
                    List<Image> imageList = new List<Image>();

                    for(int i=0; i< lines.Length; i++)
                    {
                        string[] line = lines[i].Split(':');

                        playerList.Add(line[0]);
                        byte[] imgbyte = Convert.FromBase64String(line[1]);
                        using (MemoryStream ms = new MemoryStream(imgbyte))
                        {
                            Image image = Image.FromStream(ms);
                            imageList.Add(image);
                        }
                    }
                    parentForm.PlayerList(playerList, imageList);
                }
            }
            else if (header.Equals("SENDFRIENDREQUEST"))
            {
                parentForm.SendFriendRequest(!content.Equals("-1"));
            }
            else if (header.Equals("FRIENDREQUEST"))
            {
                parentForm.FriendRequest(content);
            }
            else if (header.Equals("ACCEPTFRIEND"))
            {
                parentForm.AcceptFriend(!content.Equals("-1"));
            }
            else if (header.Equals("FRIENDSLIST"))
            {
                if (content == string.Empty) parentForm.FriendList(new List<string>());
                else
                {
                    string[] friendArr = content.Split(',');
                    parentForm.FriendList(friendArr.ToList());
                }
            }
            else if (header.Equals("JOINFRIENDROOM"))
            {
                parentForm.JoinFriendRoom(int.Parse(content));
            }
            else if (header.Equals("FRIENDREMOVE"))
            {
                parentForm.FriendRemove(!content.Equals("-1"));
            }
            else if (header.Equals("GAMESTART"))
            {
                if (content.Equals("0"))
                {
                    parentForm.GameStartFail();
                }
            }
            else if (header.Equals("GAMEREADY"))
            {
                parentForm.GameReady(content.Equals("1"));
            }
            else if (header.Equals("FORCEGAMEOVER"))
            {
                int flag = 0;
                if (int.TryParse(content, out flag)) parentForm.ForceGameOver(int.Parse(content));
                else parentForm.ForceGameOver(0);
            }
            else if (header.Equals("READYLIST"))
            {
                string[] readyArr = content.Split(',');
                parentForm.ReadyList(readyArr.ToList());
            }
            else if (header.Equals("CURRENTQUESTIONER"))
            {
                parentForm.CurrentQuestioner(content);
            }
            else if (header.Equals("SETBCOUNT"))
            {
                parentForm.SetBcount(Convert.ToInt32(content));
            }
            else if (header.Equals("GETWINS"))
            {
                parentForm.RefreshWins(content);
            }
            else if (header.Equals("RANKING"))
            {
                parentForm.Ranking(content);
            }
            else if (header.Equals("IMG"))
            {
                string[] img = content.Split(',');
                int num = Convert.ToInt32((string)img[0]);
                byte[] imgbyte = Convert.FromBase64String(img[1]);
                using(MemoryStream ms = new MemoryStream(imgbyte))
                {
                    Image image=Image.FromStream(ms);
                    parentForm.GetImg(image, num);
                }
            }
            else if (header.Equals("GAMESCREEN"))
            {
                if (content.Equals("OWNERWAIT"))
                {
                    parentForm.OwnerWait();
                }
                else if (content.Equals("PLAYERWAIT"))
                {
                    parentForm.PlayerWait();
                }
                else if (content.Equals("PRESENTERCHOICE"))
                {
                    parentForm.PresenterChoice();
                }
                else if (content.Equals("PRESENTERWAIT"))
                {
                    parentForm.PresenterWait();
                }
                else if (content.Equals("PRESENTERWANSWER"))
                {
                    parentForm.PresenterAnswer();
                }
                else if (content.Equals("QUESTIONERWAIT"))
                {
                    parentForm.QuestionerWait();
                }
                else if (content.Equals("QUESTIONERQUESTION"))
                {
                    parentForm.QuestionerQuestion();
                }
                else if (content.Equals("LOCKBYBUZZER"))
                {
                    parentForm.LockByBuzzer();
                }
                else if (content.Equals("UNLOCKBUZZER"))
                {
                    parentForm.UnlockByBuzzer();
                }
                
            }
        }
    }
}
