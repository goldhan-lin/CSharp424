namespace Lab_1_3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string UserST = "";
            int gameTimes = 1000;
            int n_gessTimeLim = 7; //猜題次數限制
            Console.WriteLine("猜數字勝率分析 ({0})局 每局限猜{1}次", gameTimes, n_gessTimeLim);
            Console.WriteLine();
            for (int user = 1; user <= 3; user += 1)
            {
                int bingoTime = 0;
                int times = 0;
                for (times = 1; times <= gameTimes; times ++)
                {
                    Random rng = new Random();
                    int x = rng.Next(0, 99);  //答案
                    int n_min = 0;
                    int n_max = 99;
                    int n_ans = 101;
                    int n_gessTime = 0;
                    while (n_ans != x && n_gessTimeLim > n_gessTime)
                    {
                        //Console.WriteLine("({0},{1})", n_min, n_max, x);
                        //n_ans = int.Parse(Console.ReadLine());
                        n_gessTime++;
                        switch (user)
                        {
                            case 1: // user1 亂數猜
                                n_ans = rng.Next(n_min, n_max);
                                UserST = "亂猜法";
                                break;
                            case 2: // user2 中分
                                n_ans = ((n_max - n_min) / 2) + n_min;
                                UserST = "二分法";
                                break;
                            case 3: // user3 循序猜
                                n_ans = n_min;
                                UserST = "循序猜";
                                break;
                        }
                        //Console.WriteLine("USER{0} 第{1}局遊戲 第{2}次 猜{3} ({4},{5}) 答案是{6}", user, gameTimes, n_gessTime, n_ans, n_min,n_max, x);    
                        if (n_ans > n_max || n_ans < n_min)
                            Console.WriteLine("超出範圍{0}", n_ans);
                        else
                        {
                            if (n_ans != x)
                            {
                                if (n_ans > x)
                                    n_max = n_ans - 1;
                                else if (n_ans < x)
                                    n_min = n_ans + 1;
                                if (n_max == n_min)
                                {
                                    //Console.WriteLine("你輸了");
                                    break;
                                }
                            }
                            else
                                //Console.WriteLine("恭喜猜對了");
                                bingoTime = bingoTime + 1;
                        }
                    }
                }
                Console.WriteLine("user{0} 採{1} 勝率:{2:F4}", user, UserST, bingoTime * 1.0 / gameTimes);
            }
        }
    }
}
