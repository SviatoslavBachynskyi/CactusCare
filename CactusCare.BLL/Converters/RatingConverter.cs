using System;

namespace CactusCare.BLL.Converters
{
    public static class RatingConverter
    {
        public static float ConvertToFiveStarScale(int sourceMember)
        {
            if (sourceMember < 1 || sourceMember > 10) throw new Exception();
            return sourceMember / 2.0f;
        }
    }
}