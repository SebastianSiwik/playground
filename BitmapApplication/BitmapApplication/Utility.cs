using System;

namespace BitmapApplication
{
    public static class Utility
    {
        public static string ClearDirectory(this string fileName)
        {
            int lastIndex = fileName.LastIndexOf('\\');
            return fileName.Substring(lastIndex + 1);
        }
        public static string ClearProgramName(this string fileName)
        {
            int lastIndex = fileName.LastIndexOf('|');
            return fileName.Substring(lastIndex + 2);
        }
        public static byte Max(params byte[] numbers)
        {
            byte max = numbers[0];
            for(int i = 1; i < numbers.Length; i++)
            {
                max = Math.Max(numbers[i], numbers[i - 1]);
            }
            return max;
        }
        public static byte Min(params byte[] numbers)
        {
            byte min = numbers[0];
            for (int i = 1; i < numbers.Length; i++)
            {
                min = Math.Min(numbers[i], numbers[i - 1]);
            }
            return min;
        }
    }
}
