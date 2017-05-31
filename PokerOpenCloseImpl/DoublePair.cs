using System.Collections.Generic;
using System.Linq;
using PokerOpenClosed;

namespace PokerOpenCloseImpl
{
    public class DoublePair : ICombinaison
    {
        public bool Match(Hand hand)
        {
           return hand.Cards.GroupBy(c => c.CardValue).Count(g => g.Count() == 2) == 2;
        }

        public IEnumerable<CardValue> Rank(Hand hand)
        {
            var listOfDifferentCards = hand.Cards.GroupBy(c => c.CardValue).Select(g => g.Key).ToList();
            var listOfPair = (hand.Cards.GroupBy(c => c.CardValue).Where(g => g.Count() == 2).Select( g => g.Key)).ToList();
            listOfPair.Sort();
            foreach (var pairValue in listOfPair)
            {
                listOfDifferentCards.Remove(pairValue);
            }
            listOfDifferentCards.Sort();

            var result = new List<CardValue>();
            result.AddRange(listOfPair);
            result.AddRange(listOfDifferentCards);

            return result;
        }
    }
}