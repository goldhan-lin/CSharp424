namespace LAB_3_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the Number of rows :");
            int n_rows = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter the Number of cols :");
            int n_cols = int.Parse(Console.ReadLine());
            int[,] a = new int[n_rows, n_cols];
            Console.WriteLine("{0},{1}  ", a.GetLength(0), a.GetLength(1));
            Random rng = new Random();
            for (int i = 0; i < a.Length; i++)
            {
                int x = i / n_cols;
                int y = i % n_cols;
                a[x, y] = i;
            }
            //洗牌
            shuffle2D(ref a);
            Display2d(a);
            Console.WriteLine("matrix after performing row exchanges based on the first column :");
            sort2d(ref a, 0);
            Display2d(a);
        }
        static void Display2d(int[,] A)
        {
            for (int i = 0; i < A.GetLength(0); i++)
            {
                for (int j = 0; j < A.GetLength(1); j++)
                {
                    Console.Write("{0,7}", A[i, j]);
                }
                Console.WriteLine();
            }
        }
        static void shuffle2D(ref int[,] A)
        {
            Random rng = new Random();
            for (int i = 0; i < A.Length; i++)
            {
                int j = rng.Next(i, A.Length - 1);
                int x = i / A.GetLength(1);
                int y = i % A.GetLength(1);
                int tmp = A[x, y];
                int k = j / A.GetLength(1);
                int l = j % A.GetLength(1);
                A[x, y] = A[k, l];
                A[k, l] = tmp;
            }
        }
        static void sort2d(ref int[,] A,int N_cols)
        { 
            int[] B = new int[A.GetLength(1)];
            int[,] C = new int[A.GetLength(0), A.GetLength(1)];
            for (int i = 0; i < B.Length; i++)
            {
                B[i]=A[i, N_cols];
            }
            Array.Sort(B);
            int nokrow = 0;
            for (int i = 0;i<B.Length;i++) 
            {
                int ans = B[i];
                for (int j = 0; j < A.GetLength(0); j++)
                {
                    if (ans == A[j, N_cols])
                    {
                        for (int k = 0; k < A.GetLength(1); k++)
                        {
                            C[nokrow, k] = A[j, k];
                        }
                        nokrow++;
                    }
                }
            }
            //copy
            for (int i = 0; i < A.GetLength(0); i++)
            {
                for (int j = 0; j < A.GetLength(1); j++)
                    A[i,j]=C[i,j];
            }
        }
        
    
    }
}
