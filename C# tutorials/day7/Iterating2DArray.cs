using System;
using System.Runtime.CompilerServices;

class Iterating2DArray
{
    public void Iterate01()
    {
        int[,] matrix =
        {
            {1, 2},
            {3, 4}
        };

        for(int i = 0; i < matrix.GetLength(0); i++){
            for(int j = 0; j < matrix.GetLength(1); j++){
                Console.WriteLine(matrix[i, j]);
            }
        }
    }

    public void Iterate02()
    {
        int[][] jagged = new int[2][];
        jagged[0] = new int[] { 1, 2 };
        jagged[1] = new int[] { 3, 4, 5 };

        for(int i = 0; i < jagged.Length; i++){
            for(int j = 0; j < jagged[i].Length; j++){
                Console.WriteLine(jagged[i][j]);
            }
        }
    }


    public void Clear01()
    {
        int[] data = new int[]{1,3,4};
        Array.Clear(data, 0, data.Length);
        for(int i = 0; i < data.Length; i++){
            Console.WriteLine(data[i]);
        }
    }
    public void Copy01()
    {
        int[] src = {1,2,3};
        int[] dest = new int[3];
        Array.Copy(src, dest,3);
        Array.Copy(src,dest,2);
        for(int i = 0; i < dest.Length; i++){
            Console.WriteLine(dest[i]);
        }
    }

    public void Resize01()
    {
        int[] nums = new int[]{1,2};
        Array.Resize(ref nums, 4);
        Array.Resize(ref nums, 1);
        for(int i = 0; i < nums.Length; i++){
            Console.WriteLine(nums[i]);
        }
    }
    

    public void IndexOf01()
    {
        int[] data = {1, 2, 3, 4, 5};
        int index = Array.IndexOf(data, 3);
        Console.WriteLine(index);
    }

    public void Exists01()
    {
        int[] data = {1, 2, 3, 4, 5};
        bool exists = Array.Exists(data, element => element == 3);
        Console.WriteLine(exists);
    }
}