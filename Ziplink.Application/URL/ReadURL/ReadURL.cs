using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using log4net;
using Ziplink.Infrastructure.EFRepository;
using Zipllink.Core.DTOEntities;
using Zipllink.Core.Entities;
using Zipllink.Core.Interfaces;

namespace Ziplink.Application.URL.ReadURL;
public class ReadURL : IReadURL
{
    private readonly IZiplinkRepository<EntityUrl> _repo;
    private readonly IMapper _mapper;
    private static readonly ILog _logger = LogManager.GetLogger(typeof(ReadURL));
    public ReadURL(IZiplinkRepository<EntityUrl> repo, IMapper mapper)
    {
        _repo = repo;
        _mapper = mapper;
    }
    public EntityUrlDTO HandleByUrl(EntityUrlDTO data)
    {
        try
        {


            var result = _repo.Get().Result.ToList();

            _logger.Debug("Created URL");
            var mapper = _mapper.Map<EntityUrlDTO>(result.Where(c=>c.generatedUrl.Equals(data.url)).FirstOrDefault());
            // this shouldbe changed to a valid return data
            return mapper;


        }
        catch (Exception ex)
        {
            _logger.Error(ex);
            throw new ArgumentNullException();
        }
    }
    public EntityUrlDTO Handle(int id)
    {
        try
        {


            var result = _repo.GetById(id);
            _logger.Debug("Created URL");
            var mapper = _mapper.Map<EntityUrlDTO>(result.Result);
            // this shouldbe changed to a valid return data
            return mapper;


        }
        catch (Exception ex)
        {
            _logger.Error(ex);
            throw new ArgumentNullException();
        }
    }
    public List<EntityUrlDTO> HandleList()
    {
        try
        {

            var result = _repo.Get();
            _logger.Debug("Created URL");
            var mapper = _mapper.Map<List<EntityUrlDTO>>(result.Result);
            // this shouldbe changed to a valid return data
            return mapper;


        }
        catch (Exception ex)
        {
            _logger.Error(ex);
            throw new ArgumentNullException();
        }
    }
}
