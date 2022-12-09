using System;
using System.Threading;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;

namespace TTTClient
{
    class Program
    {
        static char[] arr = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' }; // 보드판 위치지정
        static char[] rearr = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' }; // 새로운 보드판 위치지정
        static int turn = 0; // 턴 횟수
        static int player; // 플레이어
        static int choice; // egg 선택
        static int start; // 게임 시작
        static int end = 0; // 게임 종료
        static Random stRand = new Random(); // mult모드 랜덤숫자

        static void Main()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("게임 시작 전 모드를 선택하여주세요.");
                Console.WriteLine("\n 싱글 모드 : 1");
                Console.WriteLine(" 멀티 모드 : 2");
                Console.WriteLine(" 서버 접속 : 3");
                Console.WriteLine(" 게임 종료 : 4");
                Console.Write("\n 입력 : ");
                start = int.Parse(Console.ReadLine());

                if (start == 1)
                {
                    Single(); break; // 싱글플레이
                }
                else if (start == 2)
                {
                    Mult(); break; // 멀티플레이
                }
                else if (start == 3)
                {
                    ServerTTC(); break; // 서버접속
                }
                else if (start == 4)
                {
                    break; // 게임종료
                }
            }
        }
        public static void Single()
        {
            do
            {
                Console.Clear();
                Console.WriteLine("Player1 = X / Player2 = O");
                Console.WriteLine("\n1~9의 숫자를 쓰고, 보드판의 숫자를 쓰고 Enter을 누르세요");
                Console.WriteLine("\n");
                if (player % 2 == 0)
                {
                    Console.WriteLine("Player1 순서");
                }
                else
                {
                    Console.WriteLine("Player2 순서");
                }
                Console.WriteLine("\n");
                ShowMap();
                Console.Write("\n 입력 : ");

                choice = int.Parse(Console.ReadLine());
                if (choice < 10 && choice != 0)
                    if (arr[choice] != 'X' && arr[choice] != 'O')
                    {
                        if (player % 2 == 0)
                        {
                            arr[choice] = 'X';
                            player++;

                            player++;
                            COM();
                        }
                    }
                    else
                    {
                        Console.WriteLine("잘못된 숫자나, 중복된 숫자를 입력하셨습니다.", choice, arr[choice]);
                        Console.WriteLine("\n");
                        Console.WriteLine("2초뒤에 다시 눌러주세요");
                        Thread.Sleep(2000);
                    }
                end = Win();
            }
            while (end != 1 && end != -1);
            Console.Clear();
            ShowMap();
            if (end == 1)
            {
                Console.WriteLine("Player {0} 가 이겼습니다", (player % 2) + 1);
            }
            else
            {
                Console.WriteLine("비겼습니다");
            }
            Console.ReadLine();
            Restart();
        }
        public static void Mult()
        {
            do
            {
                Console.Clear();
                Console.WriteLine("Player1 = X / Player2 = O");
                Console.WriteLine("\n1~9의 숫자를 쓰고, 보드판의 숫자를 쓰고 Enter을 누르세요");
                Console.WriteLine("\n");
                if (player % 2 == 0)
                {
                    Console.WriteLine("Player2 순서");
                }
                else
                {
                    Console.WriteLine("Player1 순서");
                }
                Console.WriteLine("\n");
                ShowMap();
                Console.Write("\n 입력 : ");

                choice = int.Parse(Console.ReadLine());
                if (choice < 10 && choice != 0)
                    if (arr[choice] != 'X' && arr[choice] != 'O')
                    {
                        if (player % 2 == 0)
                        {
                            arr[choice] = 'O';
                            player++;
                        }
                        else
                        {
                            arr[choice] = 'X';
                            player++;
                        }
                    }
                    else
                    {
                        Console.WriteLine("잘못된 숫자나, 중복된 숫자를 입력하셨습니다.", choice, arr[choice]);
                        Console.WriteLine("\n");
                        Console.WriteLine("2초뒤에 다시 눌러주세요");
                        Thread.Sleep(2000);
                    }
                end = Win();
            }
            while (end != 1 && end != -1);
            Console.Clear();
            ShowMap();
            if (end == 1)
            {
                Console.WriteLine("Player {0} 가 이겼습니다", (player % 2) + 1);
            }
            else
            {
                Console.WriteLine("비겼습니다");
            }
            Console.ReadLine();
            Restart();
        }
        public static void ShowMap()
        {
            Console.WriteLine("     |     |      ");
            Console.WriteLine("  {0}  |  {1}  |  {2}", arr[1], arr[2], arr[3]);
            Console.WriteLine("_____|_____|_____ ");
            Console.WriteLine("     |     |      ");
            Console.WriteLine("  {0}  |  {1}  |  {2}", arr[4], arr[5], arr[6]);
            Console.WriteLine("_____|_____|_____ ");
            Console.WriteLine("     |     |      ");
            Console.WriteLine("  {0}  |  {1}  |  {2}", arr[7], arr[8], arr[9]);
            Console.WriteLine("     |     |      ");
            turn++;
        }
        public static void COM()
        {
            int s = stRand.Next(1, 10);
            if (arr[s] != '0' && arr[s] != 'X')
            {
                arr[s] = 'O';
            }
            if (s == 1 && arr[1] != '0' && arr[1] != 'X')
            {
                arr[1] = 'O';
            }
            else if (s == 2 && arr[2] != '0' && arr[2] != 'X')
            {
                arr[2] = 'O';
            }
            else if (s == 3 && arr[3] != '0' && arr[3] != 'X')
            {
                arr[3] = 'O';
            }
            else if (s == 4 && arr[4] != '0' && arr[4] != 'X')
            {
                arr[4] = 'O';
            }
            else if (s == 5 && arr[5] != '0' && arr[5] != 'X')
            {
                arr[5] = 'O';
            }
            else if (s == 6 && arr[6] != '0' && arr[6] != 'X')
            {
                arr[6] = 'O';
            }
            else if (s == 7 && arr[7] != '0' && arr[7] != 'X')
            {
                arr[7] = 'O';
            }
            else if (s == 8 && arr[8] != '0' && arr[8] != 'X')
            {
                arr[8] = 'O';
            }
            else if (s == 9 && arr[9] != '0' && arr[9] != 'X')
            {
                arr[9] = 'O';
            }
            else
            {
                COM();
            }
        }
        public static int Win()
        {
            // x축 우승
            if (arr[1] == arr[2] && arr[2] == arr[3])
            {
                return 1;
            }
            else if (arr[4] == arr[5] && arr[5] == arr[6])
            {
                return 1;
            }
            else if (arr[6] == arr[7] && arr[7] == arr[8])
            {
                return 1;
            }
            // y축 우승
            else if (arr[1] == arr[4] && arr[4] == arr[7])
            {
                return 1;
            }
            else if (arr[2] == arr[5] && arr[5] == arr[8])
            {
                return 1;
            }
            else if (arr[3] == arr[6] && arr[6] == arr[9])
            {
                return 1;
            }
            // 대각선 우승
            else if (arr[1] == arr[5] && arr[5] == arr[9])
            {
                return 1;
            }
            else if (arr[3] == arr[5] && arr[5] == arr[7])
            {
                return 1;
            }
            // 비김
            else if (arr[1] != '1' && arr[2] != '2' && arr[3] != '3' && arr[4] != '4' && arr[5] != '5' && arr[6] != '6' && arr[7] != '7' && arr[8] != '8' && arr[9] != '9')
            {
                return -1;
            }
            else
            {
                return 0;
            }
        }
        public static void Restart()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("싱글게임을 다시 하시겠습니까?");
                Console.WriteLine("\n 다시 시작 : 1");
                Console.WriteLine(" 게임 종료 : 2");
                Console.Write("\n 입력 : ");
                start = Convert.ToInt32(Console.ReadLine());

                if (start == 1)
                {
                    arr = rearr;
                    turn = 0;
                    Main(); break;
                }
                else if (start == 2)
                {
                    break;
                }
            }
        }
        public static void ServerTTC()
        {
            Console.Clear();
            var ipep = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 10000);
            using (Socket client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp))
            {
                client.Connect(ipep);
                new Task(() =>
                {
                    try
                    {
                        while (true)
                        {
                            ShowMap();
                            Console.WriteLine("\n");
                            Console.Write("입력 : ");
                            var binary = new Byte[1024];
                            client.Receive(binary);
                            var data = Encoding.ASCII.GetString(binary).Trim('\0');
                            if (String.IsNullOrEmpty(data))
                            {
                                continue;
                            }
                            Console.Clear();
                            Console.WriteLine("My egg = X / enemy egg = O");
                            Console.WriteLine("\n1~9의 숫자를 쓰고, 보드판의 숫자를 쓰고 Enter을 누르세요");
                            Console.WriteLine("\n");
                            if (data == "1" & arr[1] != '0' && arr[1] != 'X')
                            {
                                arr[1] = 'O';
                            }
                            else if (data == "2" && arr[2] != '0' && arr[2] != 'X')
                            {
                                arr[2] = 'O';
                            }
                            else if (data == "3" && arr[3] != '0' && arr[3] != 'X')
                            {
                                arr[3] = 'O';
                            }
                            else if (data == "4" && arr[4] != '0' && arr[4] != 'X')
                            {
                                arr[4] = 'O';
                            }
                            else if (data == "5" && arr[5] != '0' && arr[5] != 'X')
                            {
                                arr[5] = 'O';
                            }
                            else if (data == "6" && arr[6] != '0' && arr[6] != 'X')
                            {
                                arr[6] = 'O';
                            }
                            else if (data == "7" && arr[7] != '0' && arr[7] != 'X')
                            {
                                arr[7] = 'O';
                            }
                            else if (data == "8" && arr[8] != '0' && arr[8] != 'X')
                            {
                                arr[8] = 'O';
                            }
                            else if (data == "9" && arr[9] != '0' && arr[9] != 'X')
                            {
                                arr[9] = 'O';
                            }
                            else
                            {

                            }
                        }
                    }
                    catch (SocketException)
                    {

                    }
                }).Start();
                while (true)
                {
                    var msg = Console.ReadLine();
                    client.Send(Encoding.ASCII.GetBytes(msg + "\r\n")); // 본인입력
                    if ("EXIT".Equals(msg, StringComparison.OrdinalIgnoreCase))
                    {
                        break;
                    }
                    if (msg == "1" && arr[1] != '0' && arr[1] != 'X')
                    {
                        arr[1] = 'X';
                    }
                    else if (msg == "2" && arr[2] != '0' && arr[2] != 'X')
                    {
                        arr[2] = 'X';
                    }
                    else if (msg == "3" && arr[3] != '0' && arr[3] != 'X')
                    {
                        arr[3] = 'X';
                    }
                    else if (msg == "4" && arr[4] != '0' && arr[4] != 'X')
                    {
                        arr[4] = 'X';
                    }
                    else if (msg == "5" && arr[5] != '0' && arr[5] != 'X')
                    {
                        arr[5] = 'X';
                    }
                    else if (msg == "6" && arr[6] != '0' && arr[6] != 'X')
                    {
                        arr[6] = 'X';
                    }
                    else if (msg == "7" && arr[7] != '0' && arr[7] != 'X')
                    {
                        arr[7] = 'X';
                    }
                    else if (msg == "8" && arr[8] != '0' && arr[8] != 'X')
                    {
                        arr[8] = 'X';
                    }
                    else if (msg == "9" && arr[9] != '0' && arr[9] != 'X')
                    {
                        arr[9] = 'X';
                    }
                    else
                    {

                    }
                }
                Console.WriteLine($"Discinnected");
            }
            Console.WriteLine("Press ANY key...");
        }
    }
}