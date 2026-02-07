class FindTheFreq
{
    public void FindFrequency()
    {
        int[] arr = {1,2,3,2,1,4,2};
        Dictionary<int,int> dict = new Dictionary<int, int>();
        foreach(int num in arr)
        {
            if(dict.ContainsKey(num))
            {
                dict[num]++;
            }
            else
            {
                dict[num] = 1;
            }
        }
        foreach(var kvp in dict)
        {
            Console.WriteLine($"{kvp.Key}: {kvp.Value}");
        }
    }
}