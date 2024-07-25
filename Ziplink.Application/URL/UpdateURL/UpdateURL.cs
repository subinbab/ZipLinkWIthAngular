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

namespace Ziplink.Application.URL.UpdateURL;
public class UpdateURL : IUpdateURL
{
    private readonly IZiplinkRepository<EntityUrl> _repo;
    private readonly IMapper _mapper;
    private static readonly ILog _logger = LogManager.GetLogger(typeof(UpdateURL));

    public UpdateURL(IZiplinkRepository<EntityUrl> repo, IMapper mapper)
    {
        _repo = repo;
        _mapper = mapper;
    }
    public EntityUrlDTO Handle(EntityUrlDTO data)
    {
        try
        {
            var mapper = _mapper.Map<EntityUrl>(data);
            if (mapper == null)
            {
                throw new ArgumentNullException();
            }
            else
            {
                _repo.Update(mapper);
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
}
