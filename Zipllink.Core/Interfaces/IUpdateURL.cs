using Zipllink.Core.DTOEntities;

namespace Zipllink.Core.Interfaces;
public interface IUpdateURL
{
    EntityUrlDTO Handle(EntityUrlDTO data);
}
