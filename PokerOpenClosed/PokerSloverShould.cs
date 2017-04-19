using System.Collections;
using System.Collections.Generic;
using FakeItEasy;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NFluent;

namespace PokerOpenClosed
{
	[TestClass]
	public class PokerSloverShould
	{
		[TestMethod]
		public void return_the_hands_that_has_the_greater_combinaison()
		{
			var combinaisonOrder = A.CollectionOfFake<ICombinaison>(3);
			var pokerSolver = new PokerSlover(combinaisonOrder);
			var oneHand = new Hand(A.Dummy<IEnumerable<Card>>());
			var otherHand = new Hand(A.Dummy<IEnumerable<Card>>());
			A.CallTo(() => combinaisonOrder[0].Match(oneHand)).Returns(true);
			A.CallTo(() => combinaisonOrder[2].Match(otherHand)).Returns(true);

			var winner = pokerSolver.Slove(oneHand, otherHand);

			Check.That(winner.WinnerHand).Equals(oneHand);
		}

		[TestMethod]
		public void return_the_most_valuable_card_in_case_of_equality_combinaison()
		{
			var combinaisonOrder = A.CollectionOfFake<ICombinaison>(3);
			var pokerSolver = new PokerSlover(combinaisonOrder);
			var oneHand = new Hand(A.Dummy<IEnumerable<Card>>());
			var otherHand = new Hand(A.Dummy<IEnumerable<Card>>());
			A.CallTo(() => combinaisonOrder[1].Match(oneHand)).Returns(true);
			A.CallTo(() => combinaisonOrder[1].Match(otherHand)).Returns(true);
			A.CallTo(() => combinaisonOrder[1].Rank(oneHand)).Returns(CardValue.Jack);
			A.CallTo(() => combinaisonOrder[1].Rank(otherHand)).Returns(CardValue.Queen);

			var winner = pokerSolver.Slove(oneHand, otherHand);

			Check.That(winner.WinnerHand).Equals(otherHand);
			Check.That(winner.Rank).Equals(CardValue.Queen);
		}
	}
}