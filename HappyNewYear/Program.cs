namespace HappyNewYear
{
    class Firework
    {
        private readonly int startPosX;
        private readonly int startPosY;
        public int ColorNum { get; set; }
        public int PositionX {  get; set; }
        public int PositionY { get; set; }
        public int DenoteY { get; set; }
        public int[,] Board { get; }
        public Firework(int[,] board, int StartPosX, int StartPosY, int color) 
        {
            Board = board;
            startPosX = StartPosX;
            startPosY = StartPosY;
            ColorNum = color;
            PositionX = StartPosX;
            PositionY = StartPosY;
            Random random = new Random();
            DenoteY = random.Next(5, 15);
        }
        public void Explode()
        {
            //Exploding
            /*
               ↖ ↑ ↗
             ← ← O → →
               ↙ ↓ ↘
            3 -> Center
            4 - > UpArrow
            5-> LeftUpArrow
            6 -> RightUpArrow
            7 -> LeftArrow
            8 -> RightArrow
            9 -> DownArrow
            10 -> LeftDownArrow
            11 -> RightDownArrow
            */
            //First layer
            Board[PositionY, PositionX] = 3; //Center
            
            Board[PositionY - 2, PositionX] = 4; //UpArrow
            Board[PositionY - 2, PositionX - 2 ] = 5; //UpLeftArrow
            Board[PositionY - 2, PositionX + 2 ] = 6; //UpRightArrow
            
            Board[PositionY, PositionX - 2] = 7; //LeftArrow 
            Board[PositionY, PositionX + 2] = 8; //Rightrrow

            Board[PositionY  + 2, PositionX] = 9; //DownArrow
            Board[PositionY  + 2, PositionX  - 2] = 10; //DownLeftArrow
            Board[PositionY  + 2, PositionX  + 2] = 11; //DownRightArrow
            Thread.Sleep(1000);
            //Second layer
            Board[PositionY - 4, PositionX] = 4; //UpArrow
            Board[PositionY - 4, PositionX - 4] = 5; //UpLeftArrow
            Board[PositionY - 4, PositionX + 4] = 6; //UpRightArrow

            Board[PositionY, PositionX - 4] = 7; //LeftArrow
            Board[PositionY, PositionX + 4] = 8; //RightArrow

            Board[PositionY + 4, PositionX] = 9; //DownArrow
            Board[PositionY + 4, PositionX - 4] = 10; //DownLeftArrow
            Board[PositionY + 4, PositionX + 4] = 11; //DownRightArrow
            Thread.Sleep(1000);
            //Final
            Board[PositionY, PositionX] = 0; //Center

            Board[PositionY - 2, PositionX] = 0; //UpArrow
            Board[PositionY - 2, PositionX - 2] = 0; //UpLeftArrow
            Board[PositionY - 2, PositionX + 2] = 0; //UpRightArrow

            Board[PositionY - 4, PositionX] = 0; //UpArrow2
            Board[PositionY - 4, PositionX - 4] = 0; //UpLeftArrow2
            Board[PositionY - 4, PositionX + 4] = 0; //UpRightArrow2

            Board[PositionY, PositionX - 2] = 0; //LeftArrow 
            Board[PositionY, PositionX - 4] = 0; //LeftArrow
            Board[PositionY, PositionX + 2] = 0; //Rightrrow
            Board[PositionY, PositionX + 4] = 0; //RightArrow

            Board[PositionY + 2, PositionX] = 0; //DownArrow
            Board[PositionY + 2, PositionX - 2] = 0; //DownLeftArrow
            Board[PositionY + 2, PositionX + 2] = 0; //DownRightArrow

            Board[PositionY + 4, PositionX] = 0; //DownArrow2
            Board[PositionY + 4, PositionX - 4] = 0; //DownLeftArrow2
            Board[PositionY + 4, PositionX + 4] = 0; //DownRightArrow2
        }
        public void Fire()
        {
            Board[PositionY, PositionX] = 2;
            Board[PositionY--, PositionX] = 1;
            while (PositionY >= DenoteY)
            {
                //Board[PositionY-=2, PositionX] = 0;
                Board[PositionY+1, PositionX] = 0;
                Board[PositionY, PositionX] = 0;
                PositionY--;
                Board[PositionY, PositionX] = 2;
                Board[PositionY+1, PositionX] = 1;
                Thread.Sleep(500);
            }
            Board[PositionY, PositionX] = 3;
            Board[PositionY + 1, PositionX] = 0;
            Thread explode = new Thread(() => {
                Explode();
            });
            explode.Start();
        }
        public void BeginFiring()
        {
            Thread firing = new Thread(() => {
                Fire();
            });
            firing.Start();
        }
    }
    internal class Program
    {
        static void PrintText()
        {
            /*
                ╔ , ╗ , ╚ , ╝ , ═ , ║ , ╠ , ╣ , ╦ , ╩ , ╬ 
                text = "Happy New Year"
            */
            Console.WriteLine("╔═╗   ╔═╗  ╔═══════╗  ╔═════╗  ╔═════╗  ╔═╗  ╔═╗");
            Console.WriteLine("║ ║   ║ ║  ║ ╔═══╗ ║  ║ ╔═╗ ║  ║ ╔═╗ ║  ║ ║  ║ ║");
            Console.WriteLine("║ ╚═══╝ ║  ║ ╚═══╝ ║  ║ ╚═╝ ║  ║ ╚═╝ ║  ║ ╚══╝ ║");
            Console.WriteLine("║ ╔═══╗ ║  ║ ╔═══╗ ║  ║ ╔═══╝  ║ ╔═══╝  ╚═╗  ╔═╝");
            Console.WriteLine("║ ║   ║ ║  ║ ║   ║ ║  ║ ║      ║ ║        ║  ║  ");
            Console.WriteLine("╚═╝   ╚═╝  ╚═╝   ╚═╝  ╚═╝      ╚═╝        ╚══╝  ");
            Console.WriteLine();
            Console.WriteLine("╔═══════╗  ╔═══════╗  ╔═╗  ╔═╗  ╔═╗");
            Console.WriteLine("║ ╔═══╗ ║  ║ ╔═════╝  ║ ║  ║ ║  ║ ║");
            Console.WriteLine("║ ║   ║ ║  ║ ╚═════╗  ║ ║  ║ ║  ║ ║");
            Console.WriteLine("║ ║   ║ ║  ║ ╔═════╝  ║ ║  ║ ║  ║ ║");
            Console.WriteLine("║ ║   ║ ║  ║ ╚═════╗  ║ ╚══╝ ╚══╝ ║");
            Console.WriteLine("╚═╝   ╚═╝  ╚═══════╝  ╚═══════════╝");
            Console.WriteLine();
            Console.WriteLine("╔═╗  ╔═╗  ╔═══════╗  ╔═══════╗  ╔═════╗");
            Console.WriteLine("║ ║  ║ ║  ║ ╔═════╝  ║ ╔═══╗ ║  ║ ╔═╗ ║");
            Console.WriteLine("║ ╚══╝ ║  ║ ╚═════╗  ║ ╚═══╝ ║  ║ ╚═╝ ║");
            Console.WriteLine("╚═╗  ╔═╝  ║ ╔═════╝  ║ ╔═══╗ ║  ║  ═══╣");
            Console.WriteLine("  ║  ║    ║ ╚═════╗  ║ ║   ║ ║  ║ ╔═╗ ║");
            Console.WriteLine("  ╚══╝    ╚═══════╝  ╚═╝   ╚═╝  ╚═╝ ╚═╝");
        }
        static void PrintCopyright()
        {
            Console.WriteLine("(C) 2023 Luu Thai Hung. All rights reserved.");
        }
        static void InitFireworks(int[,] Board, int attempts)
        {
            Random random = new Random();
            for (int i = 1; i <= attempts; i++)
            {
                int randomX = random.Next(5, 95);
                int randomY = random.Next(20, 24);
                int randomcolor = random.Next(0,2);
                int colornum = 0;
                Firework fw = new Firework(Board, randomX, randomY, colornum);
                fw.BeginFiring();
                Thread.Sleep(random.Next(1000, 2000));
            }
            
        }
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            PrintText();
            Console.WriteLine("Fireworks in C#");
            Console.Write("Input number of fireworks: ");
            int attempts = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Press any key to start!");
            Console.ReadKey();
            //Thread.Sleep(2000);
            Console.Clear();
            int width = 100; int height = 25; //height = y, width = x
            int[,] Board = new int[height, width];
            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    Board[i, j] = 0;
                }
            }
            Thread spawnfw = new Thread(() =>
            {
                InitFireworks(Board, attempts);
            });
            spawnfw.Start();
            while (true)
            {
                PrintText();
                for (int i = 0; i < height; i++)
                {
                    for (int j = 0; j < width; j++)
                    {
                        switch (Board[i, j])
                        {
                            case 0:
                                Console.Write(" ");
                                break;
                            case 1:
                                Console.Write("|");
                                break;
                            case 2:
                                Console.Write("*");
                                break;
                            case 3:
                                Console.Write("O");
                                break;
                            case 4:
                                Console.Write("|");
                                break;
                            case 5:
                                Console.Write("\\");
                                break;
                            case 6:
                                Console.Write("/");
                                break;
                            case 7:
                                Console.Write("-");
                                break;
                            case 8:
                                Console.Write("-");
                                break;
                            case 9:
                                Console.Write("|");
                                break;
                            case 10:
                                Console.Write("/");
                                break;
                            case 11:
                                Console.Write("\\");
                                break;
                        }
                    }
                    Console.WriteLine();
                }
                PrintCopyright();
                Thread.Sleep(500);
                Console.Clear();
            }
        }
    }
}