using FHS.Entities.Interfaces.Model.Base;

namespace FHS.Entities.Model;

public abstract class BaseDictModel : BaseModel, IBaseDictModel
{
    public string? Name { get; set; }

    public DateTime CratedDate { get; set; }

    public DateTime UpdatedDate { get; set; }
}