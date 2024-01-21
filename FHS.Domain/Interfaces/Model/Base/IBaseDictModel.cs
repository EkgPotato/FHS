namespace FHS.Entities.Interfaces.Model.Base
{
    public interface IBaseDictModel : IBaseModel
    {
        DateTime CratedDate { get; set; }
        string? Name { get; set; }
        DateTime UpdatedDate { get; set; }
    }
}