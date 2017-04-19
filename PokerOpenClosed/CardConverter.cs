	using System.Collections.Generic;

namespace PokerOpenClosed
{
	class CardConverter
	{
		private static Dictionary<char,CardColor> _colors = new Dictionary<char, CardColor>
		{
			{ 'c', CardColor.Clovers},
			{ 'd', CardColor.Diamonds},
			{ 'h', CardColor.Hearts},
			{ 's', CardColor.Spades},
		};
		private static Dictionary<char, CardValue> _values = new Dictionary<char, CardValue>
		{
			{ 'K', CardValue.King },
			{ 'Q', CardValue.Queen },
			{ 'J', CardValue.Jack},
			{ 'T', CardValue.Ten },
			{ '9', CardValue.Nine },
			{ '8', CardValue.Height },
			{ '7', CardValue.Seven },
		};

		public static Card Convert(string s)
		{
			return new Card(_values[s[0]], _colors[s[1]]);
		}

		
	}
}