using FHS.Entities.Dto.Dict;

namespace FHS.Entities.Dto.Features;

public sealed class Income : BaseEntity, IIncome
{
    public string? Name { get; set; }
    public double? Value { get; set; }
    public DateTime? Time { get; set; }
    public string? Description { get; set; }
    public DictIncomeCategory? DictIncomeCategory { get; set; }

    public int? DictIncomeCategoryId { get; set; }
}