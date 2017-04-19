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
			var an_highcard_hand = HandConverter.CreateHand("Kd Qs Tc 9s 7h");
			var a_single_pair_hand = HandConverter.CreateHand("Kd Qd Kc 7s 8h");

			var poker = new PokerSlover(new ICombinaison[]{new SinglePair(), new HighCard()});

			var result = poker.Slove(an_highcard_hand, a_single_pair_hand);

			Check.That(result.WinnerHand).Equals(a_single_pair_hand);
			Check.That(MessageBuilder(result)).Equals("Kd Qd Kc 7s 8h wins with pair of kings");
		}

		[TestMethod]
		public void a_single_pair_of_queen_wins_against_single_pair_of_jack_hand()
		{
			var a_single_pair_of_jacks = HandConverter.CreateHand("Kd Jd Jc 9s 7h");
			var a_single_pair_of_queens = HandConverter.CreateHand("Qd Qc Kc 7s 8h");

			var poker = new PokerSlover(new ICombinaison[] { new SinglePair(), new HighCard() });

			var result = poker.Slove(a_single_pair_of_queens, a_single_pair_of_jacks);

			Check.That(result.WinnerHand).Equals(a_single_pair_of_queens);
			Check.That(MessageBuilder(result)).Equals("Qd Qc Kc 7s 8h wins with pair of queens");
		}

		private string MessageBuilder(Winner result)
		{
			return string.Format("{0} wins with pair of kings",
				HandConverter.ConvertBack(result.WinnerHand));
		}
	}
}
