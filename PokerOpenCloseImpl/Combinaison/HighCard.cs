using System.Collections.Generic;

namespace PokerOpenCloseImpl.Combinaison
{
	public class HighCard : ICombinaison
	{
		public bool Match(Hand hand)
		{
			return true;
		}

		public IEnumerable<CardValue> Rank(Hand oneHand)
		{
			return new [] {CardValue.Height};
		}
	}
}