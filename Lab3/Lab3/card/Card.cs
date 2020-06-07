using Lab3.card_types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3.card
{
    public abstract class Card
    {
        private long id;
        private OwnerType ownerType;
        private bool isBlocked;

        public Card(long id, OwnerType ownerType)
        {
            this.id = id;
            this.ownerType = ownerType;
            isBlocked = false;

        }

        public long Id
        {
            get { return id; }
        }

        public OwnerType OwnerType
        {
            get { return ownerType; }
        }

        public bool IsBlocked
        {
            get { return isBlocked; }
        }

        public void Block()
        {
            isBlocked = true;
        }

        public string OwnerToString()
        {
            if (this.ownerType == OwnerType.ORDINARY) return "Ordinary";
            else if (this.ownerType == OwnerType.PENSIONER) return "Pensioner";
            else return "Student";
        }
        
        public abstract bool Verify();
    }
}
