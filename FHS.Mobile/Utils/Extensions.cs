using FHS.Mobile.Components.Presentation;
using FHS.Mobile.Enum;

namespace FHS.Mobile.Utils;

public static class Extensions
{
    public static Tendency? Reverse(this Tendency? tendency)
    {
        return tendency switch
        {
            Tendency.Growing => Tendency.Decreasing,
            Tendency.Decreasing => Tendency.Growing,
            _ => Tendency.None,
        };
    }

    public static string MapTendencyToIcon(this Tendency? tendency)
    {
        return tendency switch
        {
            Tendency.Growing => AppIcons.TendencyGrowing,
            Tendency.Decreasing => AppIcons.TendencyDecreasing,
            _ => AppIcons.TendencyNone,
        };
    }

    public static string MapTendencyToColor(this Tendency? tendency)
    {
        return tendency switch
        {
            Tendency.Growing => MainTheme.TendencyGrowingColor,
            Tendency.Decreasing => MainTheme.TendencyDecreasingColor,
            _ => AppIcons.TendencyNone,
        };
    }
}
