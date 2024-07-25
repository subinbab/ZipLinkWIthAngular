using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Ziplink.Application.URL.CreateURL;
using Ziplink.Application.URL.DeleteURL;
using Ziplink.Application.URL.ReadURL;
using Ziplink.Application.URL.UpdateURL;
using Ziplink.Infrastructure.EFRepository;
using Zipllink.Core.Interfaces;

namespace Ziplink.API.DI;

public class AddSerivices
{
    public void Initialize(IServiceCollection services)
    {
        services.AddScoped(typeof(ICreateURL),typeof(CreateURL));
        services.AddScoped(typeof(IUpdateURL), typeof(UpdateURL));
        services.AddScoped(typeof(IDeleteURL), typeof(DeleteURL));
        services.AddScoped(typeof(IReadURL), typeof(ReadURL));
        services.AddScoped(typeof(IZiplinkRepository<>), typeof(ZipilinkRepository<>));
    }
}
