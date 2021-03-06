﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using NFluent;
using PokerOpenCloseImpl;
using PokerOpenCloseImpl.Combinaison;

namespace PokerOpenClosed
{
    [TestClass]
	public class SinglePairShould
	{
		[TestMethod]
		public void match_if_hand_contains_two_same_cards()
		{
			var hand = HandStringConverter.CreateHand("Kd Qd Kc 7s 8h");
			
			var singlePair = new SinglePair();

			Check.That(singlePair.Match(hand)).IsTrue();
		}

		[TestMethod]
		public void match_if_hand_contains_three_same_cards()
		{
			var hand = HandStringConverter.CreateHand("Kd Kd Kc 7s 8h");

			var singlePair = new SinglePair();

			Check.That(singlePair.Match(hand)).IsFalse();
		}

		[TestMethod]
		public void match_if_hand_contains_two_pairs()
		{
			var hand = HandStringConverter.CreateHand("Kd Qd Kc 7s Qh");

			var singlePair = new SinglePair();

			Check.That(singlePair.Match(hand)).IsFalse();
		}

		[TestMethod]
		public void dosent_match_if_hand_contains_no_same_cards()
		{
			var hand = HandStringConverter.CreateHand("Kd Qd Jc Ts 7h");

			var singlePair = new SinglePair();

			Check.That(singlePair.Match(hand)).IsFalse();
		}

		[TestMethod]
		public void rank_should_equals_the_pair_value()
		{
			var hand = HandStringConverter.CreateHand("7h Kd Qd Tc Ts");

			var singlePair = new SinglePair();

			Check.That(singlePair.Rank(hand)).ContainsExactly(CardValue.Ten, CardValue.King, CardValue.Queen, CardValue.Seven);

		}


	}
}