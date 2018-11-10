using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NBlackJack
{
    public class Player
    {
        public Hand cards = new Hand();
        public Seat seat = new Seat(); // this will contain the displays of the player state (cards etc)
        public int seatNumber = 1;
        public bool alreadyLost = false;
        public string name = "Player";

        public int Total()
        {
            int aces = 0;
            int total = 0;
            foreach(Card card in cards)
            {
                if (!card.shown)
                    continue;
                if (card.value == 1)
                {
                    aces++;
                    continue;
                }
                total += card.value;
            }
            if (aces > 0)
            {
                // aces besides the first are all 1 (because two at 11 would lose)
                for (int i = 1; i < aces; i++)
                    total++;
                // the last ace is either 1 or 11, whichever is better
                if (total + 11 > 21)
                    total++;
                else
                    total += 11;
            }
            return total;
        }
    }

    public class Dealer : Player // until something changes, there's no reason this isn't just a player with a set dealer flag.
    {
        public Dealer()
        {
            seatNumber = 0;
            name = "Dealer";
        }

        public bool HasAce()
        {
            foreach (Card c in cards)
            {
                if (c.value == 1) // this would be an ace.
                    return true;
            }
            return false;
        }
    }
}
