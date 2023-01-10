﻿using LabaTeam1.Model.InternalLogic;
using Model.Cards;
using Modlel.Cards;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace Model.Players_logic
{
    public class Bot : IPlayer, IAddHealth, IPlayerForAnalyzingMove, IGetPointsPerGame
    {
        public List<ICard> CardsInHands { get; set; }
        public bool IsAttack { get; set; }
        public int GlobalRating { get; set; }

        private int health;
        private int pointsPerGame;

        public Bot(List<ICard> cardsOfOneGame)
        {
            CardsInHands = cardsOfOneGame;
            pointsPerGame = 0;
            health = Constants.DEFAULT_HEALTH; 
        }
        public Bot() { }

        public void TakeTheCardInHands(ICard card)
        {
            CardsInHands.Add(card);
        }
        public void AddPointsPerGame()
        {
            pointsPerGame += Constants.POINTS_FOR_WINNING;
        }
        public int GetPointsPerGame() => pointsPerGame;
        public void AddHealth(ICard card)
        {
            health += card.Power;
        }
        public void ReduceHealth(ICard card)
        {
            health -= card.Power;
        }
        public int GetHealth() => health;

        private ICard ChooseCardFromHand()
        {
            Random random = new Random();
            int index = random.Next(CardsInHands.Count);
            var card = CardsInHands[index];
            return card;
        }

        public List<ICard> PutCardFromHandOnTheTable()
        {
            List<ICard> cardsFromMove = new List<ICard>();
            ICard cardFromMove;
            
            while (true)
            {
                cardFromMove = (ChooseCardFromHand());
                if (typeof(Creature).IsInstanceOfType(cardFromMove))
                    break;
            }
            
            CardsInHands.Remove(cardFromMove);
            cardsFromMove.Add(cardFromMove);

            Random random = new Random();
            int value = random.Next(0, 1);

            // вынести из класса
            if (value == 1)
                while (true)
                {
                    cardFromMove = (ChooseCardFromHand());
                    if (typeof(ImprovesPowerSpell).IsInstanceOfType(cardFromMove) || 
                        typeof(ImprovesProtectionSpell).IsInstanceOfType(cardFromMove) || 
                        (typeof(HealsPlayerSpell).IsInstanceOfType(cardFromMove)))
                        break;
                }
            CardsInHands.Remove(cardFromMove);
            cardsFromMove.Add(cardFromMove);

            return cardsFromMove;
        }

        
    }
}
