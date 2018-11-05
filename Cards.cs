using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Drawing;

namespace NBlackJack
{
    public class CardPicture : PictureBox
    {
        public CardPicture(string name = "Back") // default is a blank card
        {
            Bitmap bmp = new Bitmap(System.Reflection.Assembly.GetEntryAssembly().
                GetManifestResourceStream("NBlackJack.cardImages." + name + ".png"));

            Size = new Size(73, 98);
            Image = bmp;
            Name = "card"; // in case later we want to scan screen for card control types; currently I'm saving them for deletion.
        }
    }
    public class Card
    {
        public string rank;
        public string suit;        
        public int value;
        private PictureBox picture;  // only initialize pictures if they are shown, otherwise wasteful.
        public bool shown;

        public Card(bool show = true)
        {
            shown = show;
        }

        public string Name()
        {
            return rank + suit;
        }

        public PictureBox Picture()
        {
            if (picture == null)
            {
                picture = new CardPicture(Name());
            }

            return picture;
        }
    }

    public class Hand : List<Card>
    {
        public string[] Names()
        {
            var names = new List<string>();
            for (int i = 0; i < Count; i++)
            {
                if (this[i].shown)
                    names.Add(this[i].Name());
            }                
            return names.ToArray();
        }
    }

    public class Deck : List<Card>
    {
        public int position = -1; // This will be the index of the last card dealt
        public Deck() // construct new deck.
        {
            for (int i = 1; i <= 13; i++) // ranks
            {
                for (int j = 0; j < 4; j++) // suits
                {
                    string rank = (i == 1) ? "A" : (i == 11) ? "J" : (i == 12) ? "Q" : (i == 13) ? "K" : i.ToString();
                    string suit = (j == 0) ? "s" : (j == 1) ? "h" : (j == 2) ? "c" : "d";
                    int value = (i > 10) ? 10 : i;
                    Card card = new Card
                    {
                        rank = rank,
                        suit = suit,
                        value = value
                    };
                    Add(card);
                }
                Shuffle();
            }
        }

        private static Random rng = new Random();
        public void Shuffle() // from https://stackoverflow.com/a/1262619
        {
            int n = Count;
            var list = this;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                Card value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
            position = -1;
        }

        public Card NextCard(bool show = true)
        {
            if (position == Count - 1) // last card is index is 51 for one deck
            {
                position = -1; // this should be prevented by shuffling before the end of the deck, as we will loop through dealt cards in same order.
            }
            position++;
            Card c = this[position];
            c.shown = show;
            return c;
        }

        public List<Card> CardsObserved() // who knows, this may be useful at some point
        {
            var observed = new List<Card>();
            for (int i = 0; i < position; i++)
            {
                observed.Add(this[i]);
            }

            return observed;
        }
    }   
}
