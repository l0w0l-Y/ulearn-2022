using System;
using System.Linq;

namespace Names
{
    internal static class HeatmapTask
    {
        public static HeatmapData GetBirthsPerDateHeatmap(NameData[] names)
        {
            var date = new double[30, 12];
            foreach (var n in names)
            {
                if (n.BirthDate.Day != 1)
                    date[n.BirthDate.Day - 2, n.BirthDate.Month - 1]++;
            }

            return new HeatmapData(
                "Пример карты интенсивностей",
                date,
                Enumerable.Range(2, 30).Select(n => n.ToString()).ToArray(),
                Enumerable.Range(1, 12).Select(n => n.ToString()).ToArray());
        }
    }
}