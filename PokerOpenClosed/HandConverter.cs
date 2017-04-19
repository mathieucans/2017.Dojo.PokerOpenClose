using System.Linq;

namespace PokerOpenClosed
{
	public class HandConverter
	{
		internal static Hand CreateHand(string cardstext)
		{
			var cards = cardstext.Split(' ').Select(s => CardConverter.Convert(s));
			return new Hand(cards);
		}
	}
}