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
        public int seatNumber = 1;
        public bool alreadyLost = false;

        public int Score()
        {
            int aces = 0;
            int score = 0;
            foreach(Card card in cards)
            {
                if (!card.shown)
                    continue;
                if (card.value == 1)
                {
                    aces++;
                    continue;
                }
                score += card.value;
            }
            if (aces > 0)
            {
                // aces besides the first are all 1 (because two at 11 would lose)
                for (int i = 1; i < aces; i++)
                    score++;
                // the last ace is either 1 or 11, whichever is better
                if (score + 11 > 21)
                    score++;
                else
                    score += 11;
            }
            return score;
        }

        public void Hand(params Card[] hand) // for replacing player's hand.
        {
            cards = new Hand();
            foreach(Card c in hand)
            {
                cards.Add(c);
            }
        }
    }

    public class Dealer : Player // until something changes, there's no reason this isn't just a player with a set dealer flag.
    {
        public Dealer()
        {
            seatNumber = 0;
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
