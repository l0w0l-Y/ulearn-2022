namespace Pluralize
{
	public static class PluralizeTask
	{
		public static string PluralizeRubles(int count)
		{
			if (count % 100 >= 5 && count % 100 <= 20) return "рублей";
			if (count % 10 == 1) return "рубль";
			if (count % 10 >= 2 && count % 10 <=4) return "рубля";
			return "рублей";
		}
	}
}