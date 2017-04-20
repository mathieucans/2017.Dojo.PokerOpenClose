using System.Collections.Generic;

namespace PokerOpenClosed
{
	public interface ICombinaison
	{
		bool Match(Hand hand);
		IEnumerable<CardValue> Rank(Hand oneHand);
	}
}