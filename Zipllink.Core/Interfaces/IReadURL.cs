using Zipllink.Core.DTOEntities;

namespace Zipllink.Core.Interfaces;
public interface IReadURL
{
    EntityUrlDTO Handle(int id);
    List<EntityUrlDTO> HandleList();
    EntityUrlDTO HandleByUrl(EntityUrlDTO data);
}
