using System.Linq;

namespace PokerOpenClosed
{
	public class SinglePair : ICombinaison
	{
		public bool Match(Hand hand)
		{
			return hand.Cards.GroupBy( c => c.CardValue).Count( g => g.Count() == 2) == 1;
		}

		public CardValue Rank(Hand oneHand)
		{
			throw new System.NotImplementedException();
		}
	}
}