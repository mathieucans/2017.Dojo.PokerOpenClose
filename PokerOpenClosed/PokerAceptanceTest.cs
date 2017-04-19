using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NFluent;

namespace PokerOpenClosed
{
	[TestClass]
	public class PokerAceptanceTest
	{
		[TestMethod]
		public void a_single_pair_wins_against_an_highcard_hand()
		{
			var an_highcard_hand = CreateHands("Kd Qd Tc 9s 7h");
			var a_single_pair_hand = CreateHands("Kd Qd Kc 7s 7h");

			var poker = new PokerSlover(new ICombinaison[]{new SinglePair(), new HighCard()});

			var result = poker.Slove(an_highcard_hand, a_single_pair_hand);

			Check.That(result.WinnerHand).Equals(a_single_pair_hand);
		}

		
		private Hand CreateHands(string cardstext)
		{
			var cards = cardstext.Split(' ').Select(s => CardConverter.Convert(s));
			return new Hand(cards);
		}
	}

	public class SinglePair : ICombinaison
	{
		public bool Match(Hand oneHand)
		{
			throw new System.NotImplementedException();
		}
	}

	public class HighCard : ICombinaison
	{
		public bool Match(Hand oneHand)
		{
			throw new System.NotImplementedException();
		}
	}
}
