using System.Net.Http.Headers;
using System.Net.Http.Json;
using MySISWeb.Models.Common;
using MySISWeb.Models.Login;

public class AuthService
{
    private readonly HttpClient _http;

    public AuthService(HttpClient http)
    {
        _http = http;
    }

    public async Task<UserData> Login(LoginRequest request)
    {
        _http.DefaultRequestHeaders.Clear();
        _http.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue("application/json"));

        var response = await _http.PostAsJsonAsync(
            "http://10.10.1.94/Web/v2/Rest.svc/Login",
            request);

        var result = await response.Content
            .ReadFromJsonAsync<ApiResponse<UserData>>();

        if (result == null || !result.IsSuccess || result.data == null || result.data.Count == 0)
            throw new Exception(result?.error ?? "Login failed");

        return result.data[0];
    }
}