using Zipllink.Core.DTOEntities;

namespace Zipllink.Core.Interfaces;
public interface IDeleteURL
{
    EntityUrlDTO Handle(EntityUrlDTO data);
}
