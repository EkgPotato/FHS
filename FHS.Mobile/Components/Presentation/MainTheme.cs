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
        public static readonly string PrimaryContrastCol = "#F7AD19";
        public static readonly string SecondaryContrastCol = "#F27F0C";

        public static readonly string PrimaryLightColor = "#FFFBFA";
        public static readonly string SecondaryLightColor = "#F3F3F3";

        public static readonly string PrimaryDarkColor = "#6A6A6A";
        public static readonly string SecondaryDarkColor = "#646464";

        public static string TendencyGrowingColor = "#A0D468";
        public static string TendencyDecreasingColor = "#ED5565";
        public static string TendencyNoneColor = PrimaryCol;

        public static readonly string IncomeColor = "#A0D468";
        public static readonly string ExpenseColor = "#ED5565";
    }
}
