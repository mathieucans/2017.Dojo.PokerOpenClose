using System.Collections.Generic;
using System.Linq;
using PokerOpenClosed;

namespace PokerOpenCloseImpl
{
    public class Pair : ICombinaison
    {
        private readonly int _pairCount;

        public Pair(int pairCount)
        {
            _pairCount = pairCount;
        }

        public bool Match(Hand hand)
        {
            return CountAllPair(hand) == _pairCount;
        }

        public IEnumerable<CardValue> Rank(Hand hand)
        {
            var listOfDifferentCards = hand.GetListOfDifferentValues();
            var listOfpairValue = GetListOfPairValues(hand);
            return listOfpairValue.Concat(listOfDifferentCards.RemoveAll(listOfpairValue));
        }

        private int CountAllPair(Hand hand)
        {
            return hand.Cards.GroupBySameValue().SelectAllPair().Count();
        }

        public IEnumerable<CardValue> GetListOfPairValues(Hand hand)
        {
            var listOfPairValues = hand.Cards.GroupBySameValue().SelectAllPair().Select(g => g.Key).ToList();
            listOfPairValues.Sort();
            return listOfPairValues;
        }

    }
}