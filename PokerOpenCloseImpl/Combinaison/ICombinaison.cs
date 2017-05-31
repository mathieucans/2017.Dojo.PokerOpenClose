using System.Collections.Generic;

namespace PokerOpenCloseImpl.Combinaison
{
	public interface ICombinaison
	{
		bool Match(Hand hand);
		IEnumerable<CardValue> Rank(Hand hand);
	}
}