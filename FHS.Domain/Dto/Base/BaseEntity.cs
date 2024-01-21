using FHS.Domain.Interfaces.Dto.Base;

namespace FHS.Entities.Dto;

public abstract class BaseEntity : IBaseEntity
{
    public int Id { get; set; }

    public DateTime CratedDate { get; set; }

    public DateTime UpdatedDate { get; set; }
}