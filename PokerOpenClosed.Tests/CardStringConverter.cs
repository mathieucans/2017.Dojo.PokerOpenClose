	using System;
	using System.Collections.Generic;
	using System.Linq;
	using PokerOpenCloseImpl;

namespace PokerOpenClosed
{
	internal class CardStringConverter
	{
		private static Dictionary<char, CardColor> _colors = new Dictionary<char, CardColor>
		{
			{'c', CardColor.Clovers},
			{'d', CardColor.Diamonds},
			{'h', CardColor.Hearts},
			{'s', CardColor.Spades},
		};

		private static Dictionary<char, CardValue> _values = new Dictionary<char, CardValue>
		{
			{'K', CardValue.King},
			{'Q', CardValue.Queen},
			{'J', CardValue.Jack},
			{'T', CardValue.Ten},
			{'9', CardValue.Nine},
			{'8', CardValue.Height},
			{'7', CardValue.Seven},
		};

		public static Card Convert(string s)
		{
			return new Card(_values[s[0]], _colors[s[1]]);
		}


		public static string ConvertBack(Card card)
		{
			return string.Format("{0}{1}",
				_values.First(s => s.Value == card.CardValue).Key,
				_colors.First(s => s.Value == card.CardColor).Key);
		}
	}
}