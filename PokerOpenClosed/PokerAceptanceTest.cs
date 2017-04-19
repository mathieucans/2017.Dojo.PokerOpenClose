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
			var an_highcard_hand = HandConverter.CreateHand("Kd Qd Tc 9s 7h");
			var a_single_pair_hand = HandConverter.CreateHand("Kd Qd Kc 7s 8h");

			var poker = new PokerSlover(new ICombinaison[]{new SinglePair(), new HighCard()});

			var result = poker.Slove(an_highcard_hand, a_single_pair_hand);

			Check.That(result.WinnerHand).Equals(a_single_pair_hand);
			Check.That(MessageBuilder(result)).Equals("Kd Qd Kc 7s 8h wins with pair of kings");
		}

		private string MessageBuilder(Winner result)
		{
			return string.Format("{0} wins with pair of",
				HandConverter.ConvertBack(result.WinnerHand));
		}
	}
}
