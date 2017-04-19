using System;
using System.Collections.Generic;
using System.Linq;

namespace PokerOpenClosed
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

			return new Winner(winningCombinaison.Hand);
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
				var other = ((HandAndCombinaison)obj);
				var otherIndex = _combinaisonOrder.IndexOf(other.Combinaison);
				var myIndex = _combinaisonOrder.IndexOf(Combinaison);
				var result = otherIndex.CompareTo(
					myIndex);
				if (otherIndex == myIndex)
				{
					result = other.Combinaison.Rank(other.Hand).CompareTo(Combinaison.Rank(Hand));
				}


				return result;
			}
		}
	}
}