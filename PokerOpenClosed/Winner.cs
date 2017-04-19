namespace PokerOpenClosed
{
	public class Winner
	{
		public Winner(Hand hand)
		{
			WinnerHand = hand;
		}

		public Hand WinnerHand { get; set; }
	}
}