class MergeTwoSortedArray
{
    public void Merge01()
    {
        int[] arr1 = {1, 3, 5};
        int[] arr2 = {2, 4, 6};
        int[] merged = new int[arr1.Length + arr2.Length];
        int i = 0, j = 0, k = 0;
        while (i < arr1.Length && j < arr2.Length)
        {
            if(arr1[i] < arr2[j])
            {
                merged[k] = arr1[i];
                i++;
            }
            else
            {
                merged[k] = arr2[j];
                j++;
            }
            k++;
        }

        if(i < arr1.Length)
        {
            Array.Copy(arr1, i, merged, k, arr1.Length - i);
        }
        if(j < arr2.Length)
        {
            Array.Copy(arr2, j, merged, k, arr2.Length - j);
        }

        foreach(int num in merged)
        {
            Console.WriteLine(num);
        }
    }
}