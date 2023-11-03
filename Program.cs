using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PP2_Matias
{
	internal class Program
	{
		static void Main(string[] args)
		{
			StartGame();
			Console.ReadKey();
		}

		static void StartGame()
		{
			DeckOfCards deck = new DeckOfCards(true);
			Player player = new Player();
			Player computer = new Player();

			DealInitialCards(deck, player, computer);
			PlayerTurn(deck, player);
			ComputerTurn(deck, computer);
			DisplayResults(player, computer);
		}

		static void DealInitialCards(DeckOfCards deck, Player player, Player computer)
		{
			player.AddCard(deck.drawACard());
			player.AddCard(deck.drawACard());
			computer.AddCard(deck.drawACard());
			computer.AddCard(deck.drawACard());
		}

		static void PlayerTurn(DeckOfCards deck, Player player)
		{
			while (player.CheckHand() < 21)
			{
				Console.WriteLine("Player's Hand:");
				foreach (Card card in player.GetHand())
				{
					Console.WriteLine($"The Card is the {card.GetCardFace()} of {card.GetCardSuit()}");
				}

				Console.WriteLine($"Player's Hand Value: {player.CheckHand()}");
				Console.WriteLine("Do you want to (H)it or (S)tand?");
				string choice = Console.ReadLine().ToUpper();

				if (choice == "H")
				{
					player.AddCard(deck.drawACard());
				}
				else if (choice == "S")
				{
					break;
				}
			}
		}

		static void ComputerTurn(DeckOfCards deck, Player computer)
		{
			while (computer.CheckHand() < 17)
			{
				computer.AddCard(deck.drawACard());
			}
		}

		static void DisplayResults(Player player, Player computer)
		{
			int playerValue = player.CheckHand();
			int computerValue = computer.CheckHand();

			Console.WriteLine("\nComputer's Hand:");
			foreach (Card card in computer.GetHand())
			{
				Console.WriteLine($"The Card is the {card.GetCardFace()} of {card.GetCardSuit()}");
			}
			Console.WriteLine($"Computer's Hand Value: {computerValue}\n");

			if (playerValue > 21)
			{
				Console.WriteLine("Player busts. Computer wins.");
			}
			else if (computerValue > 21)
			{
				Console.WriteLine("Computer busts. Player wins.");
			}
			else if (playerValue > computerValue)
			{
				Console.WriteLine("Player wins!");
			}
			else if (playerValue < computerValue)
			{
				Console.WriteLine("Computer wins.");
			}
			else
			{
				Console.WriteLine("It's a tie!");
			}
		}
	}
}
