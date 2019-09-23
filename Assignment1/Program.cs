using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment1
{
    class Program
    {
        static void Main(string[] args)
        {
            int a = 1, b = 22;
            Console.WriteLine("Question 1");
            printSelfDividingNumbers(a, b);
            Console.WriteLine("Question 2");
            int n2 = 5;
            printSeries(n2);
            int n3 = 5;
            printTriangle(n3);
            int[] J = new int[] { 1, 3,5 };
            int[] S = new int[] { 1, 3, 3,5, 2, 2, 2, 2, 2 };
            int r4 = numJewelsInStones(J, S);
            Console.WriteLine(r4);
            int[] arr1 = new int[] { 1, 2, 5, 6, 7, 8, 9 };
            int[] arr2 = new int[] { 1, 2, 3, 4, 5 };
            int[] r5 = getLargestCommonSubArray(arr1, arr2);
            foreach (int i in r5)
            {
                Console.Write(i);
            }
            Console.WriteLine();

            Console.WriteLine("Question 6 .... \n");
            solvePuzzle();
            Console.ReadKey();

        }
        public static void printSelfDividingNumbers(int x, int y)
        {
            try
            {
                if (x > y)
                {
                    throw new Exception();
                }
                /* To find Self Dividing Numbers in the range x to y we run a for loop
                 * staring from x till y to call isSelfDiving function which checks if the 
                 * number is Self Dividing */
                for (int i = x; i<=y; i++)
                {
                    isSelfDividing(i);
                }
            }
            
            catch
            {
                /* We are not throwing any spedicif Exceptions keeping in mind that input is giving 
                 */
                Console.WriteLine("Exception occured while computing printSelfDividingNumbers()");
                if (x > y)
                {
                    Console.WriteLine("Cannot Compute because x = " + x + " is greater than y = " + y);
                }
            }
        }
        public static void isSelfDividing(int x)
        {
            try
            {
                int num = x;
                while(num!=0)
                {
                    int ldigit = num%10;
                    if (ldigit == 0 || x % ldigit != 0)
                    {
                        break;
                    }
                    num = num / 10;
                    if (num == 0)
                    {
                        Console.WriteLine("{0}", x);
                    }
                }
            }
            catch {
                Console.WriteLine("Error occured in isSelfDividing()");
                
            }
        }
        public static void printSeries(int x)
        {
            try
            {
               // Console.WriteLine(x);
                for (int i = 1; i <= x; i++)
                {
                    for (int j = 1; j <= i;j++)
                {
                        Console.WriteLine(i);
                }              
                }
                
            }
            catch {
                Console.WriteLine("Error in printSeries()");
            }
        }
        public static void printTriangle(int x)
        {
            int c = x;
            for (int i = 0; i < x; i++)
            {
                for (int j = 0; j < i; j++)
                {
                    Console.Write(" ");  
                }
                for (int k = 0; k < (2*c)-1; k++)
                {
                    Console.Write("*");
                }
                Console.WriteLine();
                c--;
            }
        }
        public static int numJewelsInStones(int[] J,int[] S)
        {
            int count = 0;
            foreach (int number1 in J)
            {
                foreach (int number2 in S)
                {
                    if (number1 == number2)
                    {
                        count++;
                    }
                }
            }
            return count;
        }

        public static int[] getLargestCommonSubArray(int[] a, int[] b)
        {
            try
            {
                if (a.Length > b.Length)
                {
                    int[] temper = b;
                    b = a;
                    a = temper;
                }
                List<int> final = new List<int>();
                for (int i = 0; i < a.Length; i++)
                {
                    List<int> temp = new List<int>();
                    for (int j = 0; j < b.Length; j++)
                    {
                        if (a[i] == b[j])
                        {
                            for (int k = 0; k < (a.Length - i); k++)
                            {
                                if (a[i + k] == b[j + k])
                                {
                                    temp.Add(a[i + k]);
                                }
                                else
                                {
                                    break;
                                }
                            }
                            if (temp.ToArray().Length >= final.ToArray().Length)
                            {
                                final = temp;
                                temp = new List<int>();
                            }
                        }
                    }
                }
                return final.ToArray();
            }
            catch
            {
                Console.WriteLine("Exception occured while computing getLargestCommonSubArray()");
            }

            return null; // return the actual array
        }
        public static void solvePuzzle()
        {
            try
            {
                Console.WriteLine("Enter First String : ");
                string str1 = Console.ReadLine();
                str1 = str1.ToLower();
                int str1len = str1.Length;
                Console.WriteLine("Enter Second String : ");
                string str2 = Console.ReadLine();
                str2 = str2.ToLower();
                int str2len = str2.Length;
                Console.WriteLine("Enter Third String : ");
                string str3 = Console.ReadLine();
                str3 = str3.ToLower();
                int str3len = str3.Length;
                Console.WriteLine("{0}  {1}  {2}", str1len, str2len, str3len);
                int biggerstr = Math.Max(str2len, str1len);
                if (str3len > biggerstr + 1)
                {
                    throw new Exception("Result String cannot be this long");
                }
                string fin = str1.ToLower() + str2.ToLower() + str3.ToLower();
                char[] unele = getUniqueElements(fin);
                Console.WriteLine(unele[0]);
                int abc = 1;
                Console.WriteLine("Waiting for Correct Match..!!!");
                while (abc == 1)
                {

                    int[] assign = assignRandom(unele);
                    while (assign[Array.IndexOf(unele, str1[0])] == 0 || assign[Array.IndexOf(unele, str2[0])] == 0)
                    {
                        assign = assignRandom(unele);
                    }
                    double val1 = getSum(str1.ToLower(), unele, assign);
                    double val2 = getSum(str2.ToLower(), unele, assign);
                    double val3 = getSum(str3.ToLower(), unele, assign);
                    if (val1 + val2 == val3)
                    {
                        Console.WriteLine("[{0}]", string.Join(", ", unele));
                        Console.WriteLine("[{0}]", string.Join(", ", assign));
                        Console.Write(str1); Console.Write(val1); Console.WriteLine();
                        Console.Write(str2); Console.Write(val2); Console.WriteLine();
                        Console.Write(str3); Console.Write(val3); Console.WriteLine();
                        abc = 0;
                    }
                }
                Console.ReadKey();

            }
            catch (Exception e)
            {

                Console.WriteLine(e);
                Console.ReadLine();
            }
        }
        public static char[] getUniqueElements(string finalstr)
        {
            var hash = new HashSet<char>(finalstr.ToArray());
            return hash.ToArray();
        }
        public static int[] assignRandom(char[] uniel)
        {
            //Console.WriteLine("In assign Random");
            char[] Uniqelements = uniel;
            int noOfEle = Uniqelements.Length;
            int[] UniqVal = new int[noOfEle];
            Random random = new Random();
            HashSet<int> randomNumbers = new HashSet<int>();
            for (int i = 0; i < noOfEle; i++)
            {
                while (!randomNumbers.Add(random.Next(0, 10))) ;
            }
            return randomNumbers.ToArray();
        }

        public static double getSum(string s, char[] uniquele, int[] assigned)
        {

            try
            {
                int len = s.Length;
                double sum = 0;
                for (int i = 0; i < len; i++)
                {

                    sum += assigned[Array.IndexOf(uniquele, s[i])] * Math.Pow(10, len - 1 - i);
                }

                return sum;
            }
            catch
            {
                Console.WriteLine("Error while generating random values");
                return 0;
            }



        }

    }
}
