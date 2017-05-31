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
            return hand.CountAllPair() == _pairCount;
        }

        public IEnumerable<CardValue> Rank(Hand hand)
        {
            var listOfDifferentCards = hand.GetListOfDifferentValues();
            var listOfpairValue = hand.GetListOfPairValues();
            return listOfpairValue.Concat(listOfDifferentCards.RemoveAll(listOfpairValue));
        }
    }
}