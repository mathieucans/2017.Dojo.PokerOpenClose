namespace PokerOpenCloseImpl
{
	public class Card
	{
		public CardValue CardValue { get; private set; }
		public CardColor CardColor { get; private set; }

		public	Card(CardValue cardValue, CardColor cardColor)
		{
			CardValue = cardValue;
			CardColor = cardColor;
		}
	}
}