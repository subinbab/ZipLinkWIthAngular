using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using log4net;
using Microsoft.Extensions.Configuration;
using Ziplink.Infrastructure;
using Ziplink.Infrastructure.EFRepository;
using Zipllink.Core.DTOEntities;
using Zipllink.Core.Entities;
using Zipllink.Core.Interfaces;

namespace Ziplink.Application.URL.CreateURL;
public class CreateURL : ICreateURL
{
    private readonly IZiplinkRepository<EntityUrl> _repo;
    private readonly IMapper _mapper;
    private static readonly ILog _logger = LogManager.GetLogger(typeof(CreateURL));
    private readonly IConfiguration _config;

    public CreateURL(IZiplinkRepository<EntityUrl> repo, IMapper mapper, IConfiguration config)
    {
        _repo = repo;
        _mapper = mapper;
        _config = config;
    }
    public EntityUrlDTO Handle(EntityUrlDTO data)
    {
        try
        {
            var charLengthString = _config.GetSection("Appsettings")["urllength"];
            if (string.IsNullOrEmpty(charLengthString) || !int.TryParse(charLengthString, out int charLength))
            {
                throw new InvalidOperationException("Invalid URL length in configuration.");
            }

            // Generate URL link
            var generatedUrl = GenerateUrlLink(charLength);
            data.generatedUrl = generatedUrl;

            // Read base URL from configuration and construct shorten URL
            var baseUrl = _config.GetSection("Appsettings")["baseurl"];
            data.shortenurl = (baseUrl == null ? "" : baseUrl.ToString()) + generatedUrl;
            var mapper = _mapper.Map<EntityUrl>(data);
            if (mapper == null)
            {
                throw new ArgumentNullException();
            }
            else
            {
                var result = _repo.Add(mapper);
                _repo.Save();
                _logger.Debug("Created URL");
                // this shouldbe changed to a valid return data
                return data;
            }

        }
        catch (Exception ex)
        {
            _logger.Error(ex);
            throw new ArgumentNullException();
        }
    }
    private static string GenerateUrlLink(int length)
    {
        try
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            Random random = new Random();
            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }
        catch (Exception ex)
        {
            return ex.Message;
        }
    }
}
