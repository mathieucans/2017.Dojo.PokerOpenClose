using Microsoft.VisualStudio.TestTools.UnitTesting;
using NFluent;
using PokerOpenCloseImpl;

namespace PokerOpenClosed
{
    [TestClass]
    public class FlushShould
    {
        private Flush _flush = new Flush();

        [TestMethod]
        public void match_if_cards_contains_three_same_cards_and_a_pair()
        {
            var hand = HandStringConverter.CreateHand("Ks Kd Kc Qs Qh");

            Check.That(_flush.Match(hand)).IsTrue();
        }

        [TestMethod]
        public void not_match_if_cards_contains_three_same_cards()
        {
            var hand = HandStringConverter.CreateHand("Ks Kd Kc 7s Qh");

            Check.That(_flush.Match(hand)).IsFalse();
        }

        [TestMethod]
        public void rank_should_equals_the_brelan_value_and_then_pair_value()
        {
            var hand = HandStringConverter.CreateHand("7h 7d Td 7c Ts");

            Check.That(_flush.Rank(hand)).ContainsExactly(CardValue.Seven, CardValue.Ten);

        }

    }
}