namespace Utilities
{
    public static class Extensions
    {
        public static string ToStringExtended<T>(this T[] array)
        {
            var str = "";
            for (var i = 0; i < array.Length; i++)
            {
                str += array[i].ToString();
                if (i < array.Length - 1)
                {
                    str += ",";
                }
            }
            return str;
        }
    }
}
