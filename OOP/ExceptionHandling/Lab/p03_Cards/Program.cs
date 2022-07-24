using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace p03_Cards
{
    public class Program
    {
        static void Main(string[] args)
        {
            string[] cardsStrings = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries);

            List<Card> cards = new List<Card>();



            for (int i = 0; i < cardsStrings.Length; i++)
            {
                string face = cardsStrings[i].Split(" ")[0];
                string suit = cardsStrings[i].Split(" ")[1];

                try
                {
                    Card card = new Card(face, suit);

                    cards.Add(card);
                }
                catch (ArgumentException)
                {
                    Console.WriteLine("Invalid card!");
                }
            }

            Console.WriteLine(String.Join(" ", cards));
        }
    }

    public class Card
    {
        private readonly string[] validFaces = 
            new string[] {  "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K", "A" };

        private readonly string[] validSuits = new string[] { "S", "H", "D", "C" };

        private string face;
        private string suit;

        public Card(string face, string suit)
        {
            this.Face = face;
            this.Suit = suit;
        }

        public string Face 
        { 
            get => face;
            set
            {
                if (!validFaces.Contains(value))
                {
                    throw new ArgumentException("Invalid face of card");
                }

                face = value;
            }
        }

        public string Suit 
        { 
            get => suit;
            set
            {
                if (!validSuits.Contains(value))
                {
                    throw new ArgumentException("Invalid suit of card");
                }

                suit = value;
            }
        }

        private string GetCardSuitChar()
        {
            switch (Suit)
            {
                case "S":
                    return "♠";
                case "H":
                    return "♥";
                case "D":
                    return "♦";
                case "C":
                    return "♣";
                default:
                    throw new ArgumentException("Invalid suit");
            }
        }

        public override string ToString()
        {
            return $"[{this.Face}{GetCardSuitChar()}]";
        }
    }
}
