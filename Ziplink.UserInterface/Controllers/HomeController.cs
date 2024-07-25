using System.Diagnostics;
using System.Net.Http;
using System.Net.Sockets;
using Microsoft.AspNetCore.Mvc;
using Ziplink.UserInterface.Models;
using Ziplink.UserInterface.Services;

namespace Ziplink.UserInterface.Controllers;
public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly ApiService _apiService;
    private readonly HttpClient _httpClient;
    public HomeController(ILogger<HomeController> logger, ApiService apiService, HttpClient httpClient)
    {
        _logger = logger;
        _apiService = apiService;
        _httpClient = httpClient;
    }

    [HttpGet]
    public async Task<IActionResult> Index(string url)
    {
        if (!string.IsNullOrEmpty(url))
        {
            // Call the RedirectUrl API method
            var redirectUrl = await _apiService.RedirectUrlAsync(url);
            return Redirect(redirectUrl);
        }
        else
        {
            return View();
        }
    }
    [HttpPost]
    public JsonResult AddURL(URLClient urlClient)
    {

        try
        {
            // Example of sending a POST request with HttpClient
            var response = _apiService.AddURLAsync(urlClient);
            return Json(response);

        }
        catch (Exception ex)
        {
            // Handle exceptions
            ViewData["Error"] = $"Exception occurred: {ex.Message}";
            return Json("invalid url");
        }
    }
}
