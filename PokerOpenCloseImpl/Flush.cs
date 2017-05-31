using System.Collections.Generic;
using PokerOpenClosed;

namespace PokerOpenCloseImpl
{
    public class Flush : ICombinaison
    {
        private Brelan _brelan;
        private SinglePair _pair;

        public Flush()
        {
            _brelan = new Brelan();
            _pair = new SinglePair();
        }
        public bool Match(Hand hand)
        {
            return _brelan.Match(hand) && _pair.Match(hand);
        }

        public IEnumerable<CardValue> Rank(Hand hand)
        {
            return _brelan.Rank(hand);
        }
    }
}