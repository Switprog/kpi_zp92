using Lab3.card;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3.turnstile_system
{
    class Turnstile
    {
        private long id;
        private Register register;

        public Turnstile(long id, Register register)
        {
            this.id = id;
            this.register = register;
        }

        private void blockIfExpired(Card card)
        {
            if (card.GetType() == typeof(QuantityCard) || card.GetType() == typeof(TermCard))
                card.Block();
        }

        public string Warn(Card card)
        {
            return "Check documents if person is " + card.OwnerToString();
        }

        public bool Pass(Card card)
        {
            if (register.GetCardByUniqueId(card.Id) == null)
            {
                register.BlockCard(card);
                return false;
            }
            bool pass = card.Verify();

            if (!pass) blockIfExpired(card);

            Console.WriteLine(Warn(card));

            register.AddPass(new Pass(pass, id, card.Id));
            return pass;
        }
    }
}
