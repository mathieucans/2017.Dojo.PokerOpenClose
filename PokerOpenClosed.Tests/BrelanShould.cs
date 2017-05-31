using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NFluent;
using PokerOpenCloseImpl;
using PokerOpenCloseImpl.Combinaison;

namespace PokerOpenClosed
{
    [TestClass]
    public class BrelanShould
    {
        private Brelan _brelan = new Brelan();

        [TestMethod]
        public void match_if_cards_contains_three_same_cards()
        {
            var hand = HandStringConverter.CreateHand("Kd Kd Kc Qs 8h");

            Check.That(_brelan.Match(hand)).IsTrue();
        }

        [TestMethod]
        public void doesnot_match_if_cards_contains_one_single_pair()
        {
            var hand = HandStringConverter.CreateHand("9d Qd Kc Qs 8h");

            Check.That(_brelan.Match(hand)).IsFalse();
        }

        [TestMethod]
        public void rank_should_equals_the_brelan_value_and_ordered_by_power()
        {
            var hand = HandStringConverter.CreateHand("7h 7d Qd 7c Ts");

            Check.That(_brelan.Rank(hand)).ContainsExactly(CardValue.Seven, CardValue.Queen, CardValue.Ten);

        }
    }
}