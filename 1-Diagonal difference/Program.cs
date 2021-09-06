using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1_Diagonal_difference
{
    class Program
    {
        static void Main(string[] args)
        {
            /* INPUT MATRIX SIZE */
            int size;
            Console.Write("Input size of the matrix: ");
            string sized = Console.ReadLine();

            /* INPUT VALIDATION */
            bool check = int.TryParse(sized, out size);
            bool valid = check && size > 0;
            while (!valid) 
            {
                Console.WriteLine("Invalid Input, Try again...");
                Console.Write("Input size of the matrix: ");
                sized = Console.ReadLine();
                check = int.TryParse(sized, out size);
                valid = check && size > 0;
            }
            size = Convert.ToInt32(sized);

            /* CREATE THE MATRIX */
            int[,] matrix = new int[size, size];

            /* VALUES OF THE MATRIX */
            for (int i = 0; i < size; ++i)
            {
                bool complete = false;
                while (!complete)
                {
                    Console.Write(string.Format("{0} Row/s Value [-100 to 100] and Seperated by Space: ", i+1));
                    string[] input = Console.ReadLine().Split(' ');

                    // CONSTRAINTS -100 <= ELEMENTS IN THE MATRIX <= 100
                    for (int y = 0; y < input.Length; y++)
                    {
                        if ((-100 >= Int32.Parse(input[y])) || (100 <= Int32.Parse(input[y])))
                        {
                            input[y] = "";
                        }
                        else { input[y] = input[y]; }
                    }

                    // CHECKING IF THE VALUES ARE SAME WITH THE SIZE OF THE MATRIX
                    if (input.Count() != size)
                    {
                       Console.WriteLine("INVALID/OUT OF RANGE INPUT, Please try again...");
                       continue;
                    }

                    for (int j = 0; j < size; ++j)
                    {
                        if (!int.TryParse(input[j], out matrix[i, j]))
                        {
                            complete = false;
                            Console.WriteLine("INVALID/OUT OF RANGE INPUT, Please try again...");
                            break;
                        }
                        complete = true;
                    }

                }
            }
            // OUTPUT
            Console.WriteLine("Output: " + DiagonalDifference(matrix, size));
            Console.WriteLine("Press Any Key to Quit.");
            Console.ReadKey();
        }

        /* FUNCTION FOR SOLVING THE DIAGONAL DIFFERENCE */
        public static int DiagonalDifference(int[,] matrix, int size)
        {
            // INITIALIZW THE SUM OF THE DIAGONALS
            int d1 = 0, d2 = 0;

            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    // SUM OF PRIMARY DIAGONAL
                    if (i == j)
                        d1 += matrix[i, j];

                    // SUM OF THE SECONDARY DIAGONAL
                    if (i == size - j - 1)
                        d2 += matrix[i, j];
                }
            }
            // THE DIFFERENCE OF TWO DIAGONAL IN ABSOLUTE VALUE
            return Math.Abs(d1 - d2);
        }

    }
}
