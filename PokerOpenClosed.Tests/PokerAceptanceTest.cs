using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NFluent;

namespace PokerOpenClosed
{
	[TestClass]
	public class PokerAceptanceTest
	{
		private ICombinaison[] _combinaisonOrder = new ICombinaison[]{new SinglePair(), new HighCard()};

		[TestMethod]
		public void a_single_pair_wins_against_an_highcard_hand()
		{
			var an_highcard_hand = HandConverter.CreateHand("Kd Qs Tc 9s 7h");
			var a_single_pair_hand = HandConverter.CreateHand("Kd Qd Kc 7s 8h");

			var poker = new PokerSlover(_combinaisonOrder);

			var result = poker.Slove(an_highcard_hand, a_single_pair_hand);

			Check.That(result.WinnerHand).Equals(a_single_pair_hand);
			Check.That(MessageBuilder(result)).Equals("Kd Qd Kc 7s 8h wins with a pair of kings");
		}

		[TestMethod]
		public void a_single_pair_of_queen_wins_against_single_pair_of_jack_hand()
		{
			var a_single_pair_of_jacks = HandConverter.CreateHand("Kd Jd Jc 9s 7h");
			var a_single_pair_of_queens = HandConverter.CreateHand("Qd Qc Kc 7s 8h");

			var poker = new PokerSlover(_combinaisonOrder);

			var result = poker.Slove(a_single_pair_of_queens, a_single_pair_of_jacks);

			Check.That(result.WinnerHand).Equals(a_single_pair_of_queens);
			Check.That(MessageBuilder(result)).Equals("Qd Qc Kc 7s 8h wins with a pair of queens");
		}
		
		[TestMethod]
		public void a_single_pair_of_queen_with_an_king_wins_against_single_pair_of_quuen_hand_with_a_Jack()
		{
			var a_single_pair_with_a_jacks = HandConverter.CreateHand("Qh Qs Jc 9s 7h");
			var a_single_pair_with_a_king = HandConverter.CreateHand("Qd Qc Kc 7s 8h");

			var poker = new PokerSlover(_combinaisonOrder);

			var result = poker.Slove(a_single_pair_with_a_jacks, a_single_pair_with_a_king);

			Check.That(result.WinnerHand).Equals(a_single_pair_with_a_king);
			Check.That(MessageBuilder(result)).Equals("Qd Qc Kc 7s 8h wins with a pair of queens");
		}


		private string MessageBuilder(Winner result)
		{
			return string.Format("{0} wins with a pair of {1}s",
				HandConverter.ConvertBack(result.WinnerHand),
				result.Rank.ToString().ToLower());
		}
	}
}
