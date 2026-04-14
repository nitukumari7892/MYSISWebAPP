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

        // ✅ PASS IN HEADERS (as API expects)
        var httpRequest = new HttpRequestMessage(
            HttpMethod.Get,
            "https://mysis.sisersys.com:8444/Web/v3/Rest.svc/Login"
        );

        httpRequest.Headers.Add("UserName", request.UserName);
        httpRequest.Headers.Add("Password", request.Password);

        var response = await _http.SendAsync(httpRequest);

        var json = await response.Content.ReadFromJsonAsync<ApiResponse<UserData>>();

        if (json == null || json.status != "true" || json.data == null || json.data.Count == 0)
            throw new Exception(json?.error ?? "Invalid user credential");

        return json.data[0];
    }
}