using System.Collections.Generic;
using PokerOpenClosed;

namespace PokerOpenCloseImpl
{
    public class Full : ICombinaison
    {
        private Brelan _brelan;
        private SinglePair _pair;

        public Full()
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