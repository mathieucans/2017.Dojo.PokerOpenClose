using Microsoft.VisualStudio.TestTools.UnitTesting;
using NFluent;

namespace PokerOpenClosed
{
	[TestClass]
	public class SinglePairShould
	{
		[TestMethod]
		public void match_if_hand_contains_two_same_cards()
		{
			var hand = HandConverter.CreateHand("Kd Qd Kc 7s 8h");
			
			var singlePair = new SinglePair();

			Check.That(singlePair.Match(hand)).IsTrue();
		}

		[TestMethod]
		public void match_if_hand_contains_three_same_cards()
		{
			var hand = HandConverter.CreateHand("Kd Kd Kc 7s 8h");

			var singlePair = new SinglePair();

			Check.That(singlePair.Match(hand)).IsFalse();
		}

		[TestMethod]
		public void match_if_hand_contains_two_pairs()
		{
			var hand = HandConverter.CreateHand("Kd Qd Kc 7s Qh");

			var singlePair = new SinglePair();

			Check.That(singlePair.Match(hand)).IsFalse();
		}

		[TestMethod]
		public void dosent_match_if_hand_contains_no_same_cards()
		{
			var hand = HandConverter.CreateHand("Kd Qd Jc Ts 7h");

			var singlePair = new SinglePair();

			Check.That(singlePair.Match(hand)).IsFalse();
		}
	}
}