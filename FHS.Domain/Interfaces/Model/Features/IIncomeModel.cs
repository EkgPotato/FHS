namespace FHS.Domain.Interfaces.Model.Features
{
    public interface IIncomeModel
    {
        string? Description { get; set; }
        int? DictIncomeCategoryId { get; set; }
        string? Name { get; set; }
        DateTime? Time { get; set; }
        double? Value { get; set; }
    }
}