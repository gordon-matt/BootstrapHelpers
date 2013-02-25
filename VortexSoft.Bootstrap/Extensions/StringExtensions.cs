using System.Text;

namespace VortexSoft.Bootstrap.Extensions
{
    internal static class StringExtensions
    {
        internal static string SpacePascal(this string pascalText)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < pascalText.Length; i++)
            {
                char a = pascalText[i];
                if (char.IsUpper(a) && i + 1 < pascalText.Length && !char.IsUpper(pascalText[i + 1]))
                {
                    if (sb.Length > 0)
                    { sb.Append(' '); }
                    sb.Append(a);
                }
                else { sb.Append(a); }
            }

            return sb.ToString();
        }
    }
}