namespace CactusCare.BLL.Converters
{
    public static class RatingConverter
    {
        public static float ConvertToFiveStarScale(this int sourceMember)
        {
            switch (sourceMember)
            {
                case 1:
                    return 0.5f;
                case 2:
                    return 1.0f;
                case 3:
                    return 1.5f;
                case 4:
                    return 2.0f;
                case 5:
                    return 2.5f;
                case 6:
                    return 3.0f;
                case 7:
                    return 3.5f;
                case 8:
                    return 4.0f;
                case 9:
                    return 4.5f;
                case 10:
                    return 5.0f;
                default:
                    return 0.0f;
            }
        }
    }
}