using Lab3.card;
using Lab3.card_types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3.turnstile_system
{
    class Register
    {
        public int travelCoast = 4;
        private List<Pass> passes;
        private List<Card> cards;
        private List<Turnstile> turnstiles;
        private long cur_turnslive_id;
        private long cur_card_id;

        public Register()
        {
            passes = new List<Pass>();
            cards = new List<Card>();
            turnstiles = new List<Turnstile>();
            cur_turnslive_id = 1;
            cur_card_id = 1;
        }

        public void AddTurnstile()
        {
            turnstiles.Add(new Turnstile(cur_turnslive_id, this));
            cur_turnslive_id++;
        }

        public void AddPass(Pass pass)
        {
            passes.Add(pass);
        }

        public void CreateCumulativeCard(int balance)
        {
            cards.Add(new CumulativeCard(cur_card_id, balance, travelCoast));
            cur_card_id++;
        }

        public void CreateQuantityCard(OwnerType ownerType, QuantityType quantityType)
        {
            cards.Add(new QuantityCard(cur_card_id, ownerType, quantityType));
            cur_card_id++;
        }

        public void CreateTermCard(OwnerType ownerType, TermType termType)
        {
            cards.Add(new TermCard(cur_card_id, ownerType, termType));
            cur_card_id++;
        }

        public void BlockCard(long cardId)
        {
            GetCardByUniqueId(cardId).Block();
        }

        public void BlockCard(Card card)
        {
            card.Block();
        }

        public Card GetCardByUniqueId(long uniqueId)
        {
            foreach (Card card in cards)
            {
                if (card.Id == uniqueId)
                    return card;
            }
            return null;
        }

        public string GetCardInfo(long uniqueId)
        {
            Card card = GetCardByUniqueId(uniqueId);
            return "Card ID: " + card.Id + "\n" +
                    "Owner type: " + card.OwnerType.ToString() + "\n" +
                    card.ToString();
        }

        public void deleteBlockedCard()
        {
            foreach (Card card in cards)
                if (card.IsBlocked) cards.Remove(card);
        }


        public List<CumulativeCard> GetCumulativeCardList()
        {
            List<CumulativeCard> cumulativeCardList = new List<CumulativeCard>();
            foreach (Card card in cards)
            {
                if (card.GetType() == typeof(CumulativeCard)) cumulativeCardList.Add((CumulativeCard)card);
            }
            return null;
        }

        public List<CumulativeCard> GetQuantityCardList()
        {
            List<QuantityCard> quantityCardList = new List<QuantityCard>();
            foreach (Card card in cards)
            {
                if (card.GetType() == typeof(QuantityCard)) quantityCardList.Add((QuantityCard)card);
            }
            return null;
        }

        public List<CumulativeCard> GetTermCardList()
        {
            List<TermCard> termCardList = new List<TermCard>();
            foreach (Card card in cards)
            {
                if (card.GetType() == typeof(TermCard)) termCardList.Add((TermCard)card);
            }
            return null;
        }

        private string passesToString(List<Pass> cardPasses)
        {
            string info = "";
            foreach (Pass pass in cardPasses)
            {
                info += pass.ToString();
                info += "\n------------------------------------";
            }
            return info;
        }

        public string GetPassInfoForCard(long cardId)
        {
            List<Pass> cardPasses = passes.FindAll(pass => pass.CardId == cardId);
            return passesToString(cardPasses);
        }

        public string GetPassInfoForAllCards()
        {
            return passesToString(passes);
        }

        public string GetPassInfoForCumulativeCards()
        {
            List<Pass> cardPasses = passes.FindAll(pass => GetCardByUniqueId(pass.CardId).GetType() == typeof(CumulativeCard));
            return passesToString(cardPasses);
        }

        public string GetPassInfoForQuantityCards()
        {
            List<Pass> cardPasses = passes.FindAll(pass => GetCardByUniqueId(pass.CardId).GetType() == typeof(QuantityCard));
            return passesToString(cardPasses);
        }

        public string GetPassInfoForTermCards()
        {
            List<Pass> cardPasses = passes.FindAll(pass => GetCardByUniqueId(pass.CardId).GetType() == typeof(TermCard));
            return passesToString(cardPasses);
        }
    }
}
