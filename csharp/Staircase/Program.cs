using System.Text;

namespace Staircase
{
    class Program
    {
        /* Example
             #
            ##
           ###
          ####
         #####
        ######

        Input Format

        A single integer denoting the size of the staircase.

        Output Format

        Print a staircase of size  using # symbols and spaces.

        Note: The last line must have 0 spaces in it.
                */

        static void Main(String[] args)
        {

            try
            {
                //SOLUTION.
                int number = Convert.ToInt32(Console.ReadLine());

                StringBuilder floor = new(number*number);
                for(int i = 1; i < number + 1; i++)
                {
                    floor.Append(' ', number - i);
                    floor.Append('#', i);
                    if(number != i) floor.Append(Environment.NewLine);
                }
                Console.WriteLine(floor);
                Console.ReadLine();
            }
            catch(ArgumentException e)
            {
                Console.Write(e);
            }
        }
    }
}
