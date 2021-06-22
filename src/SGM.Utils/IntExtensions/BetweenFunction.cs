namespace SGM.Utils.IntExtensions
{
    public static class BetweenFunction
    {
        public static bool Between(this int value, int minValue, int maxValue)
        {
            return value >= minValue && value <= maxValue;
        }

        public static bool Between(this int? value, int minValue, int maxValue)
        {
            return value.HasValue && value >= minValue && value <= maxValue;
        }
    }
}