using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hw_09
{
    internal class Program
    {
        public delegate int[] MathDelegate(int[] arr);
        static void Main(string[] args)
        {
            Random rand = new Random();
            int[] arr = new int[10];
            for(int i = 0; i < arr.Length; i++)
            {
                arr[i] = rand.Next(1,100);
            }
            MathDelegate dg = new MathDelegate(GetEven);
            dg += GetOdd;
            dg += GetPrime;
            dg+=GetFibonacci;
            
           
                int[] temp = dg.Invoke(arr);
             

            Console.ReadKey();
        }

        public static int[] GetEven(int[] arr)
        {
            int count = 0;
            foreach(var i in arr)
            {
                if (i % 2 == 0) count++;
            }
            int[] res = new int[count];
            count = 0;
            for(int i=0; i<arr.Length; i++)
            {
                if (arr[i] % 2 == 0)
                {
                    res[count] = arr[i];
                    count++;
                }
            }
            foreach (int x in arr)
            {
                Console.WriteLine($"{x} ");
            }
            Console.Write();
            return arr;
        }

        public static int[] GetOdd(int[] arr)
        {
            int count = 0;
            foreach (var i in arr)
            {
                if (i % 2 == 1) count++;
            }
            int[] res = new int[count];
            count = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] % 2 == 1)
                {
                    res[count] = arr[i];
                    count++;
                }
            }
            foreach (int x in arr)
            {
                Console.Write($"{x} ");
            }
            Console.WriteLine();
            return arr;
        }

        public static int[] GetPrime(int[] arr)
        {
            int[] res = new int[arr.Length];
            for(int i=0; i < arr.Length; i++)
            {
                res[i] = arr[i];
            }
            for(int i=0; i < arr.Length; i++)
            {
                for(int j = 2; j < arr[i]; j++)
                {
                    if (arr[i]%j==0)res[i]=0;
                }
            }
            int count = 0;
            foreach(var i in res)
            {
                if (i == 0) continue;
                count++;
            }
            int[] _res = new int[count];
            for(int i=0; i <_res.Length; i++)
            {
                for(int j=0; j < res.Length; j++)
                {
                    if(arr[j]==0)continue;
                    _res[i] = res[j];
                }
            }
            foreach (int x in _res)
            {
                Console.Write($"{x} ");
            }
            Console.WriteLine();
            return _res;
        }

        private static bool IsPerfectSquare(int num)
        {
            int sq = (int)Math.Sqrt(num);
            return sq * sq == num;
        }

        public static int[] GetFibonacci(int[] arr)
        {
            int[] res = new int[arr.Length];
            for (int i = 0; i < arr.Length; i++)
            {
                res[i] = arr[i];
            }
            int count = 0;
            for(int i=0; i < arr.Length; i++)
            {
                if (IsPerfectSquare(arr[i] * arr[i] + 4) || IsPerfectSquare(arr[i] * arr[i] - 4))
                {
                    count++;
                }
                else res[i] = -1;
            }
            int[] _res = new int[count];
            for (int i = 0; i < _res.Length; i++)
            {
                for (int j = 0; j < res.Length; j++)
                {
                    if (arr[j] == -1) continue;
                    _res[i] = res[j];
                }
            }
            foreach (int x in _res)
            {
                Console.Write($"{x} ");
            }
            Console.WriteLine();
            return _res;
        }
    }
}
