using System;

namespace RIS_Common.Utils
{
    public static class MainUtil
    {
        public static int GetInt(object obj, int defaultValue)
        {
            if (obj != null)
            {
                if (obj is int)
                {
                    return (int)obj;
                }
                try
                {
                    return Convert.ToInt32(obj);
                }
                catch (Exception)
                {
                }
            }
            return defaultValue;
        }

	}
}
