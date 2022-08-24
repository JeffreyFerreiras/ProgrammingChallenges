using System;

namespace LeftRotation
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = { 1, 2, 3, 4, 5 };

            ShiftLeft(arr, 2, arr.Length);

            Console.WriteLine(string.Join(" ", arr));
        }

		private static int[] RotateLeft(int[] arr, int shift)
		{
			shift = shift % arr.Length;

			Array.Reverse(arr, 0, arr.Length);
			Array.Reverse(arr, 0, arr.Length - shift);

			return arr;
		}

        private static void ShiftLeft(int[] arr, int shift, int len)
        {
            var tail = new int[shift];

            for (int i = 0; i < shift; i++) //copy tail
            {
                tail[i] = arr[i];
            }

            for (int i = 0; i < len - shift; i++) //shift values in place
            {
                arr[i] = arr[i + shift];
            }

            for (int i = 0; i < tail.Length; i++) // copy tail to end
            {
                arr[i + (len - shift) % len] = tail[i];
            }
        }
    }
}
