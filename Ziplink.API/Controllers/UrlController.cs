using log4net;
using System.Net.Sockets;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Zipllink.Core.Interfaces;
using AutoMapper;
using Zipllink.Core.DTOEntities;

namespace Ziplink.API.Controllers;
[Route("api/[controller]")]
[ApiController]
public class UrlController : ControllerBase
{
    private static readonly ILog _logger = LogManager.GetLogger(typeof(UrlController));
    private readonly ICreateURL _createURL;
    private readonly IUpdateURL _updateURL;
    private readonly IDeleteURL _deleteURL;
    private readonly IReadURL _readURL;
    private readonly IMapper _mapper;
    public UrlController(ICreateURL createUrl, IReadURL readURL, IDeleteURL deleteURL, IUpdateURL update, IMapper mapper)
    {
        _createURL = createUrl;
        _updateURL = update;
        _deleteURL = deleteURL;
        _readURL = readURL;
        _mapper = mapper;
    }
    [HttpPost("RedirectUrl")]
    public IActionResult RedirectUrl(string url)
    {
        if (!string.IsNullOrEmpty(url))
        {
            var data = new EntityUrlDTO
            {
                url = url
            };
            var redirectUrl = _readURL.HandleByUrl(data);
            return Ok(redirectUrl);
        }
        else
        {
            return BadRequest();
        }

    }
    [HttpPost("AddUrl")]
    public IActionResult AddURL(EntityUrlDTO urlClient)
    {
        var data = new EntityUrlDTO();
        if (ModelState.IsValid)
        {

            data.url = urlClient.url;
            // Fetch client's IP address
            // Get IP Address
            var ipAddress = HttpContext.Connection.RemoteIpAddress?.ToString();

            // Get User Agent
            var userAgent = HttpContext.Request.Headers["User-Agent"].ToString();

            // Example response including IP and User Agent
            var response = new
            {
                IpAddress = ipAddress,
                UserAgent = userAgent
            };
            data.clientIp = (response.IpAddress == null ? "" : response.IpAddress);
            var result = _createURL.Handle(data);

            _logger.Debug($"User Request from {ipAddress} ip address to shorten url {urlClient.url}");
            return Ok(data);
        }
        else
        {
            data.generatedUrl = "Invalid link";
            return Ok(data);
        }
    }
}
