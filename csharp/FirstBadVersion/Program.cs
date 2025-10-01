// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");



var firstBadVersion = FirstBadVersion(2126753390);
Console.WriteLine($"{firstBadVersion} {1702766719}");
bool IsBadVersion(int version)
{
    return version >= 1702766719;
}

int FirstBadVersion(int n)
{
    int low = 1;
    int high = n;
    int mid = 0;
    while (low <= high)
    {
        mid = low + (high - low) / 2; ;

        if (IsBadVersion(mid))
        {
            high = mid - 1;
        }
        else
        {
            low = mid + 1;
        }
    }

    return low;
}