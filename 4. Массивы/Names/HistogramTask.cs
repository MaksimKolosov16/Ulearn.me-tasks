using System;
using System.Linq;

namespace Names;

internal static class HistogramTask
{
    private const int AmountOfDaysInMonth = 31;
    
    public static HistogramData GetBirthsPerDayHistogram(NameData[] names, string name)
    {
        var xLabels = GetDays();

        var yLabels = GetBirthsPerDay(names, name);

        return new HistogramData(
            $"Рождаемость людей с именем '{name}'",
            xLabels,
            yLabels);
    }

    public static string[] GetDays()
    {
        var days = new string[AmountOfDaysInMonth];

        for (var i = 0; i < days.Length; i++)
            days[i] = (i + 1).ToString();

        return days;
    }
    
    public static double[] GetBirthsPerDay(NameData[] names, string name)
    {
        var birthsCounts = new double[AmountOfDaysInMonth];

        var withRequiredName = names
            .Where(n => n.BirthDate.Day != 1 && n.Name == name);
            
        foreach (var nameData in withRequiredName)
            birthsCounts[nameData.BirthDate.Day - 1]++;

        return birthsCounts;
    }
}