using FHS.Entities.Dto.Dict;

namespace FHS.Entities.Dto.Features
{
    public interface IIncome
    {
        string? Description { get; set; }
        DictIncomeCategory? DictIncomeCategory { get; set; }
        int? DictIncomeCategoryId { get; set; }
        string? Name { get; set; }
        DateTime? Time { get; set; }
        double? Value { get; set; }
    }
}