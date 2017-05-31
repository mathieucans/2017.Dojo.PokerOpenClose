using Microsoft.VisualStudio.TestTools.UnitTesting;
using NFluent;
using PokerOpenCloseImpl;

namespace PokerOpenClosed
{
    [TestClass]
    public class DoublePairShould
    {
        [TestMethod]
        public void match_if_cards_contains_two__pairs()
        {
            var hand = HandStringConverter.CreateHand("Kd Qd Kc Qs 8h");

            var doublePair = new DoublePair();

            Check.That(doublePair.Match(hand)).IsTrue();
        }

        [TestMethod]
        public void doesnot_match_if_cards_contains_one_single_pair()
        {
            var hand = HandStringConverter.CreateHand("9d Qd Kc Qs 8h");

            var doublePair = new DoublePair();

            Check.That(doublePair.Match(hand)).IsFalse();
        }

        [TestMethod]
        public void rank_should_equals_the_pair_value_and_ordered_by_power()
        {
            var hand = HandStringConverter.CreateHand("7h 7d Qd Tc Ts");

            var singlePair = new DoublePair();

            Check.That(singlePair.Rank(hand)).ContainsExactly(CardValue.Ten, CardValue.Seven, CardValue.Queen);
        }

    }
}