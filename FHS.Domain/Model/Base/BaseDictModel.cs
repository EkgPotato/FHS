namespace FHS.Entities.Model;

public abstract class BaseDictModel : BaseModel
{
    public string? Name { get; set; }

    public DateTime CratedDate { get; set; }

    public DateTime UpdatedDate { get; set; }
}