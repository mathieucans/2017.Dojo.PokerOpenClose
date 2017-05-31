using System.Collections.Generic;
using System.Linq;

namespace PokerOpenClosed
{
    public static class CardsManipulation
    {
        public static IEnumerable<IGrouping<CardValue, Card>> GroupBySameValue(this IEnumerable<Card> cards)
        {
            return cards.GroupBy(c => c.CardValue);
        }

        public static IEnumerable<IGrouping<CardValue, Card>> SelectAllPair(this IEnumerable<IGrouping<CardValue, Card>> cardGroups)
        {
            return cardGroups.Where(g => g.Count() == 2);
        }

        public static IEnumerable<CardValue> RemoveAll(
            this IEnumerable<CardValue> source,
            IEnumerable<CardValue> toRemove)
        {
            var result = source.ToList();
            foreach (var cardValue in toRemove)
            {
                result.Remove(cardValue);
            }
            return result;
        }
    }
}