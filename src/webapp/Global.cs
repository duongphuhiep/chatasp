namespace WebApplication
{
    /// <summary>
    /// Contains all the constant, so that we could avoid "magic string" as much as possible
    /// </summary>
    public static class Global
    {
        public static readonly string AUTH_USER_COOKIE = nameof(AUTH_USER_COOKIE);
        public static string BYE = nameof(BYE);
        public static string LOGGED_USER = nameof(LOGGED_USER);
    }
}