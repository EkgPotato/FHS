using MudBlazor;

namespace FHS.Mobile.Components.Presentation
{
    public static class MainTheme
    {
        public static MudTheme GetMainTheme() => new()
        {
            PaletteLight = new PaletteLight()
            {
                Primary = PrimaryCol,
                Secondary = SecondaryCol,
            },
        };

        public static readonly string PrimaryCol = "#1E88E5";
        public static readonly string SecondaryCol = "#429EBD";
        public static readonly string ThirdCol = "#9FE7F5";
        public static readonly string PrimaryContrastCol = "#F7AD19";
        public static readonly string SecondaryContrastCol = "#F27F0C";

        public static readonly string IncomeColor = "#A0D468";
        public static readonly string ExpenseColor = "#ED5565";

        public static readonly string ContrastColor = "#FFFBFA";
        public static readonly string SecondaryContrastColor = "#EBEBEB";
    }
}
