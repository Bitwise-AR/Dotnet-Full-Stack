using DALExtract;
using System.Text;

namespace BLExtract
{
    public class BLExtr
    {
        public List<string> Reverse()
        {
            Students d = new Students();
            var names = d.getNames();

            List<string> rev = new List<string>();
            foreach (var name in names)
            {
                rev.Add(ReverseString(name));
            }
            return rev;
        }

        public static string ReverseString(string input)
        {
            StringBuilder reversed = new StringBuilder(input.Length);
            for (int i = input.Length - 1; i >= 0; i--)
            {
                reversed.Append(input[i]);
            }
            return reversed.ToString();
        }
    }
}
