using System.Collections.Generic;
using System.Linq;

namespace PokerOpenClosed
{
	public class SinglePair : ICombinaison
	{
		public bool Match(Hand hand)
		{
			return hand.Cards.GroupBy( c => c.CardValue).Count( g => g.Count() == 2) == 1;
		}

		public IEnumerable<CardValue> Rank(Hand hand)
		{
			var listOfDifferentCards = hand.Cards.GroupBy(c => c.CardValue).Select(g => g.Key).ToList();
			var pairValue = (hand.Cards.GroupBy(c => c.CardValue).First(g => g.Count() == 2).Key);
			listOfDifferentCards.Remove(pairValue);
			listOfDifferentCards.Sort();

			var result = new List<CardValue>();
			result.Add(pairValue);
			result.AddRange(listOfDifferentCards);

			return result;


		}
	}
}