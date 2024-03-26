namespace Challenge.Utilities
{
    public class Tools
    {
        public static string ByteToString(Byte[] bytes)
        {
            return $"data:image/png;base64,{Convert.ToBase64String(bytes)}";
        }
    }
}
