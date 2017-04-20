using System.Linq;

namespace PokerOpenClosed
{
	public class SinglePair : ICombinaison
	{
		public bool Match(Hand hand)
		{
			return hand.Cards.GroupBy( c => c.CardValue).Count( g => g.Count() == 2) == 1;
		}

		public CardValue Rank(Hand hand)
		{
			return hand.Cards.GroupBy(c => c.CardValue).First(g => g.Count() == 2).Key;
		}
	}
}