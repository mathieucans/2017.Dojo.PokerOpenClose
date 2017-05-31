using System.Linq;
using PokerOpenCloseImpl;

namespace PokerOpenClosed
{
	public class HandStringConverter
	{
		internal static Hand CreateHand(string cardstext)
		{
			var cards = cardstext.Split(' ').Select(s => CardStringConverter.Convert(s));
			return new Hand(cards);
		}

		public static string ConvertBack(Hand hand)
		{
			return string.Join(" ", hand.Cards.Select(CardStringConverter.ConvertBack));
		}
	}
}