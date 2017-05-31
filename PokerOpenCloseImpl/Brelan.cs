using System.Collections.Generic;
using System.Linq;
using PokerOpenClosed;

namespace PokerOpenCloseImpl
{
    public class Brelan : ICombinaison
    {
        public bool Match(Hand hand)
        {
            return DoesContainsThreeSameCards(hand);
        }

        public IEnumerable<CardValue> Rank(Hand hand)
        {
            var listOfDifferentCards = hand.GetListOfDifferentValues();
            var listOfpairValue = GetListOfBrelanValues(hand);
            return listOfpairValue.Concat(listOfDifferentCards.RemoveAll(listOfpairValue));
        }

        private bool DoesContainsThreeSameCards(Hand hand)
        {
            return hand.Cards.GroupBySameValue().Any(s => s.Count() == 3); 
        }

        public IEnumerable<CardValue> GetListOfBrelanValues(Hand hand)
        {
            var listOfBrelanValues = hand.Cards.GroupBySameValue()
                .Where(g => g.Count() == 3)
                .Select(g => g.Key).ToList();
            return listOfBrelanValues;
        }
    }
}