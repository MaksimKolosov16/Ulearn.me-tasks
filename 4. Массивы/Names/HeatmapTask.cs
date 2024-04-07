using System.Linq;

namespace Names;

internal static class HeatmapTask
{
    private const int FirstDayInMonth = 2;
    private const int LastDayInMonth = 31;
    private const int FirstMonthInYear = 1;
    private const int LastMonthInYear = 12;

    public static HeatmapData GetBirthsPerDateHeatmap(NameData[] names)
    {
        var xLabels = GetDaysNumbers();

        var yLabels = GetMonthsNumbers();

        var heatmap = new double[xLabels.Length, yLabels.Length];

        var filledHeatmap = FillHeatmap(heatmap, names);

        return new HeatmapData(
            "Пример карты интенсивностей",
            filledHeatmap,
            xLabels,
            yLabels);
    }

    public static string[] GetDaysNumbers()
    {
        var arrayLength = LastDayInMonth - FirstDayInMonth + 1;

        var days = new string[arrayLength];

        for (var i = 0; i < arrayLength; i++)
            days[i] = (FirstDayInMonth + i).ToString();

        return days;
    }

    public static string[] GetMonthsNumbers()
    {
        var arrayLength = LastMonthInYear - FirstMonthInYear + 1;

        var months = new string[arrayLength];

        for (var i = 0; i < arrayLength; i++)
            months[i] = (FirstMonthInYear + i).ToString();

        return months;
    }

    public static double[,] FillHeatmap(double[,] heatmap, NameData[] nameDates)
    {
        foreach (var nameData in nameDates.Where(n => n.BirthDate.Day != 1))
        {
            var birthDate = nameData.BirthDate;
            heatmap[birthDate.Day - FirstDayInMonth, birthDate.Month - FirstMonthInYear]++;
        }

        return heatmap;
    }
}