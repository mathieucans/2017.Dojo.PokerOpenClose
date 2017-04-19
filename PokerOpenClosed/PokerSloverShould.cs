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
			var cominaisonFinder = A.Fake<ICombinaisonFinder>();
			var pokerSolver = new PokerSlover();
			var oneHand = new Hand(A.Dummy<IEnumerable<Card>>());
			var otherHand = new Hand(A.Dummy<IEnumerable<Card>>());
			
			var winner = pokerSolver.Slove(oneHand, otherHand);

			Check.That(winner.WinnerHand).Equals(oneHand);
		}		
	}

	public interface ICombinaisonFinder
	{
	}
}