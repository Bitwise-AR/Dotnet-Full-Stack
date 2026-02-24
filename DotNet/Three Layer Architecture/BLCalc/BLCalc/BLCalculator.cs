using DALCalc;

namespace BLCalc
{
    public class BLCalculator
    {
        public int BLAdd(int a, int b)
        {
            DalCalculator d = new DalCalculator();
            int sum = d.DALAdd(a, b);
            return sum - 1;
        }
    }
}
