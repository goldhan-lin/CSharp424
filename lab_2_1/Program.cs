namespace LAB_2_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter Number:");
            int n_pNum = int.Parse(Console.ReadLine());
            int[] a_apid = new int[n_pNum];
            int[] a_bpid = new int[n_pNum];
            //default
            Console.Write("{0,12}.", "ID");
            for (int i = 0; i < a_apid.Length; i++)
            {
                a_apid[i]=i;
                a_bpid[i] = i;
                Console.Write("{0,3} .", a_apid[i]);
            }

            //shuffle
            Random rng = new Random();
            Console.WriteLine();
            Console.Write("{0,12}.", "Contactee");
            for (int i = 0; i < a_bpid.Length; i++)
            {
                //swap
                int j =rng.Next(i,a_bpid.Length);
                int tmp=a_bpid[i];
                a_bpid[i]=a_bpid[j];
                a_bpid[j]=tmp;
                Console.Write("{0,3} .", a_bpid[i]);
            }
            Console.WriteLine();
            //
            Console.WriteLine("Enter ID for infected:");
            int n_ifdId0 = int.Parse(Console.ReadLine());
            int n_ifdId1 = n_ifdId0;
            Console.WriteLine();
            bool l_find=false;
            while (l_find == false)    
            { 
                Console.Write("{0}  ,", n_ifdId1);
                for (int i = 0; i < a_apid.Length ; i++)
                {
                    if ( a_apid[i]== n_ifdId1)
                    {
                        n_ifdId1 = a_bpid[i];
                        if (n_ifdId1 == n_ifdId0)
                            l_find = true;
                        break;    
                    }
                
                }
            }
        }
    }
}
