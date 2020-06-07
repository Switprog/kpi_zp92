using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3.turnstile_system
{
    class Pass
    {
        private DateTime passDate;
        private bool passed;
        private long turnstileId;
        private long cardId;

        public Pass(bool passed, long turnstileId, long cardId)
        {
            this.passed = passed;
            this.turnstileId = turnstileId;
            this.cardId = cardId;
            passDate = DateTime.Now;
        }

        public long CardId
        {
            get { return cardId; }
        }
        
        public override string ToString()
        {
            return "\nCard id: " + cardId +
                    "\nPass date: " + passDate +
                    "\nPass result: " + passed +
                    "\nTurnstileSystem id: " + turnstileId + "\n";
        }
    }
}
