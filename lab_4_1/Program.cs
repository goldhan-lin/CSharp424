namespace LAB_4_1
{
    class Game
    {
        private int secretNumber;
        private Player player;
        private int high;
        private int low;
        private bool win;

        public Game() { }
        public Game(Player Player1)
        {
            player = Player1;
        }
        public void Run()
        {
            high = 99;
            low = 0;
            win = true;
            int n_a = 101;
            Random rng = new Random();
            secretNumber = rng.Next(low, high);
            while (n_a != secretNumber)
            {
                n_a = this.player.Next(low, high);
                Console.WriteLine("({0},{1}) 猜 {2}", high, low, n_a);
                if (n_a != secretNumber)
                {
                    if (n_a > secretNumber)
                        high = n_a - 1;
                    else if (n_a < secretNumber)
                        low = n_a + 1;
                    if (high == low)
                    {
                        //Console.WriteLine("你輸了");
                        win = false;
                        Console.WriteLine("你輸了");
                        break;
                    }
                 
                }
                else
                {
                    win = true;
                    Console.WriteLine("你win了");
                }
            }
    
        }
    }
    class Player
    {
        public string Name { get; set; }
        public virtual int Next(int min, int max)
        {
            Random rng = new Random();
            return rng.Next(min, max);
        }

    }
    class HumanPlayer : Player
    {
        public HumanPlayer() { }
        public HumanPlayer(string name)
        {
            Name = name;
        }
        public override int Next(int min, int max)
        {
            int n_ans = 0;
            while (true)
            {
                Console.WriteLine("({0},{1})", min, max);
                n_ans = int.Parse(Console.ReadLine());
                if (n_ans > max || n_ans < min)
                    Console.WriteLine("超出範圍{0}", n_ans);
                else
                    break;
            }
            return n_ans;

        }

    }
    class NaiveAi : Player
    {
        public NaiveAi() { }
        public override int Next(int min, int max)
        {
            return min;
        }
    }
    class BinarySearchPlayer : NaiveAi
    {
        public BinarySearchPlayer() { }
        public override int Next(int min, int max)
        {
            return (int) ((min+max)/2);
        }
    }
    class SuperPlayer : NaiveAi
    {
        public override int Next(int min, int max)
        {
            return (int)((min + max) / 2);
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            //Player han = new HumanPlayer("HAN");
            //Player han = new BinarySearchPlayer();
            Player han = new NaiveAi();
            Game game1 = new Game(han);
            game1.Run();
        }
    }
}

