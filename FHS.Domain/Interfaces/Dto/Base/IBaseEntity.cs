namespace FHS.Domain.Interfaces.Dto.Base
{
    public interface IBaseEntity
    {
        DateTime CratedDate { get; set; }
        int Id { get; set; }
        DateTime UpdatedDate { get; set; }
    }
}