using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PP2_Matias
{
	internal class Player
	{
		private List<Card> Hand;

		public Player()
		{
			Hand = new List<Card>();
		}

		public List<Card> GetHand()
		{
			return Hand;
		}

		public int CheckHand()
		{
			int value = 0;
			int numAces = 0;

			foreach (Card card in Hand)
			{
				value += card.GetCardValue();
				if (card.GetCardValue() == 1)
				{
					numAces++;
				}
			}

			while (numAces > 0 && value + 10 <= 21)
			{
				value += 10;
				numAces--;
			}

			return value;
		}

		public void AddCard(Card card)
		{
			Hand.Add(card);
		}
	}
}
