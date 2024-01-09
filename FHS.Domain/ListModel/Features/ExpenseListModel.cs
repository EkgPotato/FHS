using FHS.Entities.ListModel.Base;

namespace FHS.Entities.ListModel.Features;

public sealed class ExpenseListModel : BaseListModel
{
    public string? Name { get; set; }

    public string? Value { get; set; }

    public string? Time { get; set; }

    public string? CategoryName { get; set; }
}