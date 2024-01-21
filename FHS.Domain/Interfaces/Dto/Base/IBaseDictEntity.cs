using FHS.Entities.Interfaces.Model.Base;

namespace FHS.Domain.Interfaces.Dto.Base
{
    public interface IBaseDictEntity : IBaseEntity
    {
        string? Color { get; set; }
        string? Name { get; set; }
    }
}
