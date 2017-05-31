using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;

namespace PokerOpenClosed
{
	public class SinglePair : ICombinaison
	{
		public bool Match(Hand hand)
		{
		    return hand.CountAllPair() == 1;
		}

	    public IEnumerable<CardValue> Rank(Hand hand)
		{
			var listOfDifferentCards = hand.GetListOfDifferentCardValues();
		    var listOfpairValue = hand.GetListOfPairValues();
		    return listOfpairValue.Concat(listOfDifferentCards.RemoveAll(listOfpairValue));
		}
	}
}