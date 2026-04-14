namespace MySISWeb.Models.Login
{
    public class LoginRequest
    {
            public string UserName { get; set; }   // ✅ FIX
            public string Password { get; set; }
            public string AppType { get; set; } = "portal"; // ✅ REQUIRED
            }
}