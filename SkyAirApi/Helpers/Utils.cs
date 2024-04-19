namespace SkyAirApi.Helpers
{
    public static class Utils
    {
        public static string GenerateAlpaNumericCode
            (string prefix,int id)
        {
            string result = prefix;
            if (id >= 10)
            {
                result += "0";
            }else if (id<10)
            {
                result += "00";
            }
            result += id;
            return result;
        }
    }
}
