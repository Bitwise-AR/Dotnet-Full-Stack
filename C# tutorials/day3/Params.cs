// Order of parameters: req, default, params

class Params
{
    public static int Sum(params int[] nums)
    {
        int total = 0;

        foreach (int num in nums)
        {
            total += num;
        }

        return total;
    }

    public static int Sum2(int a = 10, params int[] nums)
    {
        int total = 0;

        foreach (int num in nums)
        {
            total += num;
        }

        total += a;
        return total;
    }
}