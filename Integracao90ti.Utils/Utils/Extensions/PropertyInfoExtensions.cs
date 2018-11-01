using System.ComponentModel;

namespace Utils90.Extensions
{
    public static class PropertyInfoExtensions
    {
        public static string GetDescription(this System.Reflection.PropertyInfo value)
        {
            DescriptionAttribute[] da = (DescriptionAttribute[])value.GetCustomAttributes(typeof(DescriptionAttribute), false);

            string s = value.Name;

            if (da.Length > 0)
                s = da[0].Description;

            return s;
        }
    }
}
