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
            Console.WriteLine("Question 1...!!!");
            int a = 1, b = 22;
            printSelfDividingNumbers(a, b);
            Console.WriteLine("Question 2...!!!");
            int n2 = 5;
            printSeries(n2);
            int n3 = 5;
            Console.WriteLine("Question 3...!!!");
            printTriangle(n3);
            int[] J = new int[] { 1, 3,5 };
            int[] S = new int[] { 1, 3, 3,5, 2, 2, 2, 2, 2 };
            Console.WriteLine("Question 4...!!!");
            int r4 = numJewelsInStones(J, S);
            Console.WriteLine("Number of Jewels : {0}", r4);
            int[] arr1 = new int[] { 1, 2, 5, 6, 7, 8, 9 };
            int[] arr2 = new int[] { 1, 2, 3, 4, 5 };
            Console.WriteLine("Question 4...!!!");
            int[] r5 = getLargestCommonSubArray(arr1, arr2);
            Console.WriteLine("The Largest Common Array is");
            // Printing Largest Common Array Using foreach
            foreach (int i in r5)
            {
                Console.Write(i);
            }
            Console.WriteLine();

            Console.WriteLine("Question 6 .... \n");
            solvePuzzle();
            Console.ReadKey();

        }

        /*
* x – starting range, integer (int)
* y – ending range, integer (int)
* 
* summary      : This method prints all the self-dividing numbers between x and y. 
* A self-dividing number is a number that is divisible by every digit it contains.
* 128 is a self-dividing number because 128 % 1 == 0, 128 % 2 == 0 and 128 % 8 == 0
* For example 1, 22 will print all the self.-dividing numbers between 1 and 22 i.e. 
* 1, 2, 3, 4, 5, 6, 7, 8, 9, 11, 12, 15, 22
* Tip: Write a method isSelfDividing() to compute if a number is self-dividing or not.
*
* returns      : N/A
* return type  : void
*
*/
        public static void printSelfDividingNumbers(int x, int y)
        {
            try
            {
                // Throwing an exception if first element is greater than second.
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
                /* We are not throwing any spedicfic Exceptions keeping in mind that input given by user satisfy the condition
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
                    //Here we are fetching the last digit using percentile and then comparing if it equal to zero or percetile is zero to break the loop
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

        /*
* n – number of terms of the series, integer (int)
* 
* summary        : This method prints the following series till n terms:
* 1, 2, 2, 3, 3, 3, 4, 4, 4, 4, 5, 5, 5, 5, 5, 6, 6 …. n terms
* For example, if n = 5, output will be
* 1, 2, 2, 3, 3
*
* returns        : N/A
* return type    : void
*/

        public static void printSeries(int x)
        {
            try
            {
               // used nested for loop to traverse and check values in the series.
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

        /*
* n – number of lines for the pattern, integer (int)
* 
* summary      : This method prints an inverted triangle using *
* For example n = 5 will display the output as: 
*********
 *******
  *****
   ***
    *

*
* returns      : N/A
* return type  : void
*/

        public static void printTriangle(int x)
        {
            int c = x;
            //used for nested for loops to print * and give spaces before printing pattern.
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
        /*
* a – array of elements, integer (int)
* 
* summary      : You're given an array J representing the types of stones that are 
* jewels, and S representing the stones you have.  Each element in S is a type of 
* stone you have.  You want to know how many of the stones you have are also jewels.
* The elements in J are guaranteed distinct.
* The function should return an integer.
* For example:
* J = [1,3], S = [1,3,3,2,2,2,2,2] will return the output: 
* 3 (since 1, 3, 3 are jewels)
* and
* J = [2], S = [0,0] will return the output: 
* 0
*
* returns      : Integer
* return type  : int
*/
       
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

        /*
* a – array of elements, integer (int)
* 
* summary      : This method finds the largest common contiguous subarray from two 
* sorted arrays. The given arrays are sorted in ascending order. If there are multiple 
* arrays with the same length, then return the last array having the maximum length.
* The function should return the array.
* For example:
* a = [1,2,5,6,7,8,9], b = [1,2,3,4,5] will return the output: 
* [1,2]
* and
* a = [1,2,3,4,5,6,7,8,9], b = [1,2,5,7,8,9,10] will return the output: 
* [7,8,9]
* and
* a = [1,2,3,4,5,6], b = [1,2,5,6,7,8,9] will return the output: 
* [5,6]
*
* returns      : Array of integers
* return type  : int[]
*/

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

        /*
* 
* summary      : At a recent college reunion meeting of one of the instructors of this 
* class, his friend was wearing the t-shirt shown in the picture above. It was a gift
* from his niece. Appropriate assignment of numbers to each digit solves the puzzle 
* above. In this question, write a general method to solve puzzles such as the above.
* The method should ask the user for the two input strings (e.g. uber, cool) and the 
* output string (e.g. uncle) and identify a set of number assignments that solve the 
* puzzle and print out the numbers.
*
* Tip: There is no need to search for algorithms. It is fine to brute force all 
* possible combinations. However, for full credit, use maximal organization of your
* code into the appropriate methods (e.g. a method to collect inputs, a method to
* identify unique characters in the strings, a method to test the currently assigned
* values etc).
*
* returns      : nothing
* return type  : void
*/
        public static void solvePuzzle()
        {
            try
            {
                //Initially we are reading 3 string from console to work with
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
                //Just to check if the result string is too long .
                int biggerstr = Math.Max(str2len, str1len);
                if (str3len > biggerstr + 1)
                {
                    throw new Exception("Result String cannot be this long");
                }
                //Concatenated string is created
                string fin = str1.ToLower() + str2.ToLower() + str3.ToLower();
                char[] unele = getUniqueElements(fin);
                Console.WriteLine(unele[0]);
                int abc = 1;
                Console.WriteLine("Waiting for Correct Match..!!!");
                while (abc == 1)
                {

                    //Random brute force is applied on to check each random combinations.
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
            //Here we are obtaining unique set of elements from concatenated string.
            var hash = new HashSet<char>(finalstr.ToArray());
            return hash.ToArray();
        }
        public static int[] assignRandom(char[] uniel)
        {
            //Here we are assigning random values to each element in the unique array which we will use to solve of equation.
            char[] Uniqelements = uniel;
            int noOfEle = Uniqelements.Length;
            //Random function is used to assign random values
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
                //Here we are generating sum of each String given according to place values and their assigned random values.
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
