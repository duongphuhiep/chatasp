namespace WebApplication
{
    /// <summary>
    /// Contains all the constant, so that we could avoid "magic string" as much as possible
    /// </summary>
    public static class Global
    {
        public static readonly string BASIC_AUTH_COOKIE = nameof(BASIC_AUTH_COOKIE);
        public static string BYE = nameof(BYE);
        public static string LOGGED_USER_ONLY = nameof(LOGGED_USER_ONLY);
    }
}