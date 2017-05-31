using Microsoft.VisualStudio.TestTools.UnitTesting;
using NFluent;
using PokerOpenCloseImpl;

namespace PokerOpenClosed
{
    [TestClass]
    public class FullShould
    {
        private Full _full = new Full();

        [TestMethod]
        public void match_if_cards_contains_three_same_cards_and_a_pair()
        {
            var hand = HandStringConverter.CreateHand("Ks Kd Kc Qs Qh");

            Check.That(_full.Match(hand)).IsTrue();
        }

        [TestMethod]
        public void not_match_if_cards_contains_three_same_cards()
        {
            var hand = HandStringConverter.CreateHand("Ks Kd Kc 7s Qh");

            Check.That(_full.Match(hand)).IsFalse();
        }

        [TestMethod]
        public void rank_should_equals_the_brelan_value_and_then_pair_value()
        {
            var hand = HandStringConverter.CreateHand("7h 7d Td 7c Ts");

            Check.That(_full.Rank(hand)).ContainsExactly(CardValue.Seven, CardValue.Ten);

        }

    }
}