﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NBlackJack
{
    public partial class Game : Form
    {
        public Deck deck;
        public Player player;
        public Dealer dealer;
        public List<Player> players = new List<Player>();

        public Game()
        {
            InitializeComponent();

            deck = new Deck();
            dealer = new Dealer();
            player = new Player();
            players.Add(dealer);
            players.Add(player);
            Result_label.Text = "";
            UpdateTable();
        }

        private bool UpdateScore(bool force = false) // returns true if a final score is released.
        {
            int dScore = dealer.Score();
            int pScore = player.Score();
            DealerTotal_label.Text = (dScore > 0) ? dScore.ToString() : "";
            PlayerTotal_label.Text = (pScore > 0) ? pScore.ToString() : "";
            
            if (pScore >= 21 || dScore >= 21 || force) // all of this is super ugly. I would change it all if there were more than one player.
            {
                if (pScore == 21 && dScore < 21 && !force)
                {
                    // do nothing for this condition, dealer is still playing.
                }
                else
                {
                    if (pScore == 21 && dScore == 21 || dScore == pScore)
                        Result_label.Text = "PUSH";
                    else if (pScore == 21)
                        Result_label.Text = "21!";
                    else if (dScore == 21 || pScore > 21 || (dScore > pScore && dScore < 21))
                        Result_label.Text = "LOSS";
                    else if (dScore < pScore || dScore > 21)
                        Result_label.Text = "WIN";
                    else
                        Result_label.Text = "Uhoh@#$2";

                    dealer.cards[0].shown = true;
                    UpdateCardPictures();
                    UpdateCardStrings();
                    Hit_button.Enabled = false;
                    Stand_button.Enabled = false;
                    return true;
                }
            }
            return false;
        }

        private void UpdateCardStrings()
        {
            DealerCards_label.Text = String.Join(", ", dealer.cards.Names());
            PlayerCards_label.Text = String.Join(", ", player.cards.Names());
            int deckPos = deck.position;
            LastDealtCard_label.Text = (deckPos >= 0) ? deck[deckPos].Name() : "";
        }

        private List<PictureBox> visibleCards = new List<PictureBox>();
        private PictureBox blankCard = new CardPicture();
        private void AddCard(Card card, int cardNum, int seatNum)
        {
            var cardPic = (card.shown)? card.Picture() : blankCard;
            cardPic.Location = new Point(100 + 24 * cardNum, 50 + 208 * seatNum);
            Controls.Add(cardPic);
            cardPic.BringToFront();
            visibleCards.Add(cardPic);
            LastDealtCard_label.Text = card.Name();
        }

        private void UpdateCardPictures()
        {
            // remove old cards
            foreach (PictureBox card in visibleCards)
            {
                Controls.Remove(card);
            }
            visibleCards.Clear();

            // add cards from all players
            foreach(Player p in players)
            {
                for (int cardNum = 0; cardNum < p.cards.Count; cardNum++)
                {
                    AddCard(p.cards[cardNum],cardNum, p.seatNumber);
                }
            }
        }

        private void UpdateTable()
        {
            UpdateScore();
            UpdateCardPictures();
            UpdateCardStrings();
        }

        private void DealHand()
        {
            // in real life they are probably handed out one at a time,
            // I don't think this makes a difference (even for counters) because they are dealt upside down
            // until the last card which is the dealer's non-hole card.
            player.Hand(deck.NextCard(), deck.NextCard()); 
            dealer.Hand(deck.NextCard(false), deck.NextCard());
            Result_label.Text = "";
            Hit_button.Enabled = true;
            Stand_button.Enabled = true;
            UpdateTable();
            if (player.Score() == 21)
                Stand_button_Click(null, null);
        }

        private void DealHand_button_Click(object sender, EventArgs e)
        {
            DealHand();
        }

        private void Shuffle()
        {
            foreach (Player p in players)
                p.cards.Clear();
            Result_label.Text = "";
            deck.Shuffle();
            UpdateTable();            
        }

        private void Shuffle_button_Click(object sender, EventArgs e)
        {
            Shuffle();
        }

        private void Hit(int seat)
        {
            Card nextCard = deck.NextCard();
            Player p = players[seat];
            p.cards.Add(nextCard);
            AddCard(nextCard, p.cards.Count - 1, seat);
            UpdateScore();
        }

        private void Hit_button_Click(object sender, EventArgs e)
        {
            Hit(player.seatNumber);
            if (Result_label.Text.Equals("") && player.Score() == 21)
                Stand_button_Click(null, null);
        }

        private void Stand()
        {
            if (UpdateScore()) // will update score and return true if there is already a result.
                return;
            int total = dealer.Score();
            if (total < 17)
            {
                Hit(0);
                Stand();
                return;
            }
            if (total == 17)
            {
                if (dealer.HasAce())
                {
                    Hit(0);
                    Stand();
                    return;
                }
            }

            UpdateScore(true); // force a result, dealer stands.
        }

        private void Stand_button_Click(object sender, EventArgs e)
        {
            dealer.cards[0].shown = true;
            UpdateCardStrings();
            UpdateCardPictures();

            if (!UpdateScore())
                Stand();
        }
    }
}