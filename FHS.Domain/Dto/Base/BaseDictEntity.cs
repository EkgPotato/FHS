using FHS.Domain.Interfaces.Dto.Base;

namespace FHS.Entities.Dto;

public abstract class BaseDictEntity : BaseEntity, IBaseDictEntity
{
    public string? Name { get; set; }

    public string? Color { get; set; }
}