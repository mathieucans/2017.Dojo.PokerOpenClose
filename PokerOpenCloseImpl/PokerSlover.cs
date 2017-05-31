using System;
using System.Collections.Generic;
using System.Linq;
using PokerOpenCloseImpl.Combinaison;

namespace PokerOpenCloseImpl
{
	public class PokerSlover
	{
		private readonly List<ICombinaison> _combinaisonOrder;

		public PokerSlover(IEnumerable<ICombinaison> combinaisonOrder)
		{
			_combinaisonOrder = new List<ICombinaison>(combinaisonOrder);
		}

		public Winner Slove(params Hand[] hands)
		{
			var matchingCombinaisons = hands.Select(hand => new HandAndCombinaison(hand, _combinaisonOrder));

			var winningCombinaison = matchingCombinaisons.Max();

			return new Winner(winningCombinaison.Hand, winningCombinaison.Combinaison.Rank(winningCombinaison.Hand).FirstOrDefault());
		}

		class HandAndCombinaison : IComparable
		{
			private readonly List<ICombinaison> _combinaisonOrder;

			public Hand Hand { get; private set; }
			public ICombinaison Combinaison { get; private set; }

			public HandAndCombinaison(Hand hand, List<ICombinaison> combinaisonOrder)
			{
				_combinaisonOrder = combinaisonOrder;
				Hand = hand;
				Combinaison = combinaisonOrder.First(y => y.Match(hand));
			}

			public int CompareTo(object obj)
			{
				var otherHand = ((HandAndCombinaison)obj);
				var otherHandIndex = _combinaisonOrder.IndexOf(otherHand.Combinaison);
				var myHandIndex = _combinaisonOrder.IndexOf(Combinaison);
			    var result = otherHandIndex.CompareTo(myHandIndex);
                var otherRankIterator = otherHand.Combinaison.Rank(otherHand.Hand).GetEnumerator();
                var myRankIterator = Combinaison.Rank(Hand).GetEnumerator();
                while (result == 0 && otherRankIterator.MoveNext() && myRankIterator.MoveNext())
                {
                    result = otherRankIterator.Current.CompareTo(myRankIterator.Current);

                }

                return result;
			}
		}
	}
}