namespace PokerOpenClosed
{
	public interface ICombinaison
	{
		bool Match(Hand hand);
		CardValue Rank(Hand oneHand);
	}
}