using System.Collections.Generic;
using System.Linq;

namespace PokerOpenCloseImpl
{
	public class Hand
	{
		public IEnumerable<Card> Cards { get; }

		public Hand(IEnumerable<Card> cards)
		{
			Cards = cards;
		}

	    public IList<CardValue> GetListOfDifferentValues()
	    {
	        var result = Cards.GroupBySameValue().Select(g => g.Key).ToList();
            result.Sort();
	        return result;
	    }

    }
}