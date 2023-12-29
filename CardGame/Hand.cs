﻿namespace CardGame
{
    internal interface IHand
    {
        void AddHand(Card card);
        int Size();
        Card PickupCard(int index);
        Card[] ShowCards();
        void SetPlayer(Player player);
        Player GetPlayer();

    }
    internal class Hand : IHand
    {
        public ICard CurrentCard { get; set; }
        private IList<Card> Cards = new List<Card>();
        private IList<Card> OrderedCards;

        public Player? Player { get; set; }
        public void AddHand(Card card)
        {
            Cards.Add(card);
            OrderedCards = Cards.OrderBy(p => p.Rank).ThenBy(p => p.Suit).ToList();
        }
        public int Size() 
        {
            return OrderedCards.Count;
        }

        public Card PickupCard(int index)
        {
            var card =  OrderedCards[index-1];
            OrderedCards.RemoveAt(index-1);
            CurrentCard = card;
            return card;
        }

        public Card[] ShowCards()
        {  
            return OrderedCards.ToArray();
        }

        public void SetPlayer(Player player)
        {
            Player = player;
        }
        public Player GetPlayer()
        {
            return Player;
        }
    }
}
