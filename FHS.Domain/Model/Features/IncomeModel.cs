namespace FHS.Entities.Model.Features;

public sealed class IncomeModel : BaseModel
{
    public string? Name { get; set; }

    public double? Value { get; set; }

    public DateTime? Time { get; set; }

    public int? DictIncomeCategoryId { get; set; }

    public string? Description { get; set; }
}