using Zipllink.Core.DTOEntities;

namespace Zipllink.Core.Interfaces;
public interface ICreateURL
{
    EntityUrlDTO Handle(EntityUrlDTO data);
}
