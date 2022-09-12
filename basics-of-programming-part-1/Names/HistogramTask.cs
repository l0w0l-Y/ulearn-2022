using System.Linq;

namespace Names
{
    internal static class HistogramTask
    {
        public static HistogramData GetBirthsPerDayHistogram(NameData[] names, string name)
        {
            var birthCount = new double[31];
            foreach (var nameData in names.Where(person => person.Name == name))
            {
                birthCount[nameData.BirthDate.Day - 1]++;
            }

            birthCount[0] = 0;

            return new HistogramData(
                $"Рождаемость людей с именем '{name}'",
                Enumerable.Range(1, 31).Select(n => n.ToString()).ToArray(),
                birthCount);
        }
    }
}