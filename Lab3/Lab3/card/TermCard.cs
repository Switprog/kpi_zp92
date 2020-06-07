using Lab3.card_types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3.card
{
    public class TermCard : Card // со сроком действия
    {
        private TermType termType;
        private DateTime finalDate;

        public TermCard(long id, OwnerType ownerType, TermType termType) :
            base(id, ownerType)
        {
            this.termType = termType;
            if (termType == TermType.DAY) this.finalDate = DateTime.Now.AddDays(1);
            else if (termType == TermType.WEEK) this.finalDate = DateTime.Now.AddDays(7);
            else if (termType == TermType.MONTH) this.finalDate = DateTime.Now.AddMonths(1);
        }

        public override bool Verify()
        {
            return DateTime.Now < finalDate;
        }
        
        public override string ToString()
        {
            return "Card type: term card\n" +
                    "Expiration date: " + finalDate.ToString() + "\n";
        }
    }
}
