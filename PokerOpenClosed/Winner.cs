namespace PokerOpenClosed
{
	public class Winner
	{
		public Winner(Hand hand, CardValue rank)
		{
			WinnerHand = hand;
			Rank = rank;
		}

		public Hand WinnerHand { get; private set; }
		public CardValue Rank { get; private set; }
	}
}