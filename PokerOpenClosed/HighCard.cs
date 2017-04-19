namespace PokerOpenClosed
{
	public class HighCard : ICombinaison
	{
		public bool Match(Hand hand)
		{
			return true;
		}

		public CardValue Rank(Hand oneHand)
		{
			return CardValue.Height;
		}
	}
}