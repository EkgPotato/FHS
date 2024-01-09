namespace FHS.Entities.Dto;

public abstract class BaseEntity
{
    public int Id { get; set; }

    public DateTime CratedDate { get; set; }

    public DateTime UpdatedDate { get; set; }
}