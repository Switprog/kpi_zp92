using Lab3.card_types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3.card
{
    public class QuantityCard : Card // по количеству поездок
    {
        private int travelLeft;
        private QuantityType quantityType;

        public QuantityCard(long id, OwnerType ownerType, QuantityType quantityType) :
            base(id, ownerType)
        {
            this.quantityType = quantityType;
            if (quantityType == QuantityType.FOUR) this.travelLeft = 4;
            else if (quantityType == QuantityType.TEN) this.travelLeft = 10;
            else if (quantityType == QuantityType.TWENTY) this.travelLeft = 20;
        }


        public override bool Verify()
        {
            bool isVerified = false;
            if (travelLeft > 0)
            {
                travelLeft--;
                isVerified = true;
            }
            return isVerified;
        }
        
        public override string ToString()
            {
                return "Card type: quantity card\n" +
                        "Travels left: " + travelLeft + "\n";
            }
        }
}
