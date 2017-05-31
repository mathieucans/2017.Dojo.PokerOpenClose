using System.Collections.Generic;
using System.Linq;

namespace PokerOpenClosed
{
	public class Hand
	{
		public IEnumerable<Card> Cards { get; }

		public Hand(IEnumerable<Card> cards)
		{
			Cards = cards;
		}

	    public int CountAllPair()
	    {
	        return Cards.GroupBySameValue().SelectAllPair().Count();

	    }

	    public IList<CardValue> GetListOfDifferentCardValues()
	    {
	        var result = Cards.GroupBySameValue().Select(g => g.Key).ToList();
            result.Sort();
	        return result;
	    }

	    public IEnumerable<CardValue> GetListOfPairValues()
	    {
	        var listOfPairValues = Cards.GroupBySameValue().SelectAllPair().Select(g => g.Key).ToList();
            listOfPairValues.Sort();
	        return listOfPairValues;
	    }
	}
}