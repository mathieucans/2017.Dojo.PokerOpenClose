using System.Collections.Generic;

namespace PokerOpenClosed
{
	public class Hand
	{
		public IEnumerable<Card> Cards { get; private set; }

		public Hand(IEnumerable<Card> cards)
		{
			Cards = cards;
		}
	}
}