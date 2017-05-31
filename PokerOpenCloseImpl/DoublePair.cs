using System.Collections.Generic;
using System.Linq;
using PokerOpenClosed;

namespace PokerOpenCloseImpl
{
    public class DoublePair : ICombinaison
    {
        public bool Match(Hand hand)
        {
           return hand.CountAllPair() == 2;
        }

        public IEnumerable<CardValue> Rank(Hand hand)
        {
            var listOfDifferentCards = hand.GetListOfDifferentCardValues();
            var listOfpairValue = hand.GetListOfPairValues();
            return listOfpairValue.Concat(listOfDifferentCards.RemoveAll(listOfpairValue));
        }
    }
}