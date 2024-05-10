namespace ProductOfInts
{

    /*
     * You have an array of integers, and for each index you want to find the product of every integer except the integer at that index.
     */
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = {1, 7, 3, 4};
            int[] profucts = GetProductsOfAllIntsExceptAtIndex(arr);
            //[84, 12, 28, 21]
            int[] arr2 = { 3, 1, 2, 5, 6, 4 };
            int[]products2=GetProductsOfAllIntsExceptAtIndex(arr2);
            //[1, 3, 3, 6, 30, 180]
        }

        private static int[] GetProductsOfAllIntsExceptAtIndex(int[] arr)
        {
            int[] products = new int[arr.Length];

            int cachedProduct = 1;

            for(int i = 0; i < arr.Length; i++)
            {
                products[i] = cachedProduct;
                cachedProduct *= arr[i];
            }

            cachedProduct = 1;
            for(int i = arr.Length-1; i >= 0; i--)
            {
                products[i] *= cachedProduct;
                cachedProduct *= arr[i];
            }

            return products;
        }
    }
}
