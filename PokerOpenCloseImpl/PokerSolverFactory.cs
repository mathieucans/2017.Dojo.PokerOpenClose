using PokerOpenClosed;

namespace PokerOpenCloseImpl
{
    public class PokerSolverFactory
    {
        private ICombinaison[] _combinaisonOrder =
        {
            new Flush(), 
            new Brelan(),
            new DoublePair(),
            new SinglePair(),
            new HighCard(),
        };

        public PokerSlover CreatePokerSlover()
        {
            var poker = new PokerSlover(_combinaisonOrder);
            return poker;
        }
    }
}