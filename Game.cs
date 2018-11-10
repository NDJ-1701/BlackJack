using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace NBlackJack
{
    public partial class Game : Form
    {
        public Deck deck = new Deck();
        public Player player = new Player();
        public Dealer dealer = new Dealer();
        public List<Player> players = new List<Player>(); // index is seat number

        public Game()
        {
            InitializeComponent();

            // this attempts to update settings that would be thrown away when running a newer version of the program.
            // "UpdateSettings" is a setting that defaults to true, so if settings have been wiped then it will be true.
            // Update and then set to false. Settings files are saved in the windows AppData folder.
            if (Properties.Settings.Default.UpdateSettings)
            {
                Properties.Settings.Default.Upgrade();
                Properties.Settings.Default.UpdateSettings = false;
                Properties.Settings.Default.Save();
            }

            /// add players to player list
            players.Add(dealer); // seat number is order of addition the player list
            dealer.seatNumber = players.IndexOf(dealer); // unnecessary because we are adding them in order, but leaving here to prove a point.
            players.Add(player);
            player.seatNumber = players.IndexOf(player);

            /// set seat locations for each player.
            // add dealer seat to upper left (location is default 0,0)
            Controls.Add(dealer.seat);
            // add player seat to bottom left by taking form height and subtracting seat height
            player.seat.Location = new Point(0, this.ClientRectangle.Height - player.seat.Size.Height);
            Controls.Add(player.seat);

            Result_label.Text = "";
            UpdateTable();

            SaveScore(); // also prints existing score.
        }
        
        private void SaveScore(double modifier = 0)
        {
                double bank = Properties.Settings.Default.score;
                bank = bank + modifier;
                Properties.Settings.Default.score = bank;
                Bank_label.Text = "$" + String.Format("{0:0.00}", bank);
                Properties.Settings.Default.Save();
        }

        private bool UpdateScore(bool force = false) // returns true if a final score is released.
        {
            int dScore = dealer.Total();
            int pScore = player.Total();
            dealer.seat.SetTotal(dealer.Total());
            player.seat.SetTotal(player.Total());
            
            if (pScore >= 21 || dScore >= 21 || force) // all of this is super ugly. I would change it all if there were more than one player.
            {
                if (pScore == 21 && dScore < 21 && !force)
                {
                    // do nothing for this condition, dealer is still playing.
                }
                else
                {
                    double scoreModifier = 0.0;
                    if (pScore == 21 && dScore == 21 || dScore == pScore)
                    {
                        Result_label.Text = "PUSH";
                        scoreModifier += 1.0;
                    }
                    else if (pScore == 21)
                    {
                        Result_label.Text = "21!";
                        scoreModifier += 2.5;
                    }
                    else if (dScore == 21 || pScore > 21 || (dScore > pScore && dScore < 21))
                    {
                        Result_label.Text = "LOSS";
                    }
                    else if (dScore < pScore || dScore > 21)
                    {
                        Result_label.Text = "WIN";
                        scoreModifier += 2.0;
                    }
                    else
                        Result_label.Text = "Uhoh@#$2";

                    SaveScore(scoreModifier);

                    dealer.cards[0].shown = true;
                    dealer.seat.SetTotal(dealer.Total());
                    UpdateCardPictures();
                    Hit_button.Enabled = false;
                    Stand_button.Enabled = false;
                    return true;
                }
            }
            return false;
        }

        private void UpdateCardPictures()
        {
            int deckPos = deck.position;
            LastDealtCard_label.Text = (deckPos >= 0) ? deck[deckPos].Name() : "";

            // add cards from all players
            foreach (Player p in players)
            {
                p.seat.AddCards(p.cards);
            }
        }

        private void UpdateTable()
        {
            UpdateScore();
            UpdateCardPictures();
        }

        private void DealHand_button_Click(object sender, EventArgs e)
        {
            var newCards = new List<Hand>();
            for (int i = 0; i < players.Count; i++)
                newCards.Add(new Hand());
            for (int i = 0; i < (players.Count * 2); i++)
            {
                newCards[i % players.Count].Add(deck.NextCard());
            }
            dealer.cards = newCards[dealer.seatNumber];
            dealer.cards[0].shown = false;
            player.cards = newCards[player.seatNumber];

            Result_label.Text = "";
            Hit_button.Enabled = true;
            Stand_button.Enabled = true;
            UpdateTable();

            SaveScore(-1.0); // charge the player a buck for the hand.

            if (player.Total() == 21)
                Stand_button_Click(null, null);
        }

        private void Shuffle()
        {
            foreach (Player p in players)
                p.cards.Clear();
            Result_label.Text = "";
            LastDealtCard_label.Text = "";
            deck.Shuffle();
            UpdateTable();            
        }

        private void Shuffle_button_Click(object sender, EventArgs e)
        {
            Shuffle();
        }

        private void DealCard(int seat)
        {
            Card nextCard = deck.NextCard();
            Player p = players[seat];
            p.cards.Add(nextCard); // add card to players hand
            p.seat.AddCard(nextCard, p.cards.Count - 1); // display card

            LastDealtCard_label.Text = nextCard.Name();
        }

        private void Hit_button_Click(object sender, EventArgs e)
        {   
            DealCard(player.seatNumber);
            if (Result_label.Text.Equals("") && player.Total() == 21)
                Stand_button_Click(null, null); // score will update in stand
            else
                UpdateScore();
        }

        private void Stand()
        {
            if (UpdateScore()) // will update score and return true if there is already a result.
                return;
            int total = dealer.Total();
            if (total < 17)
            {
                DealCard(0);
                Stand(); // player still stands
                return;
            }
            if (total == 17)
            {
                if (dealer.HasAce())
                {
                    DealCard(0);
                    Stand(); // player still stands
                    return;
                }
            }

            UpdateScore(true); // dealer stands, force a result.
        }

        private void Stand_button_Click(object sender, EventArgs e)
        {
            dealer.cards[0].shown = true;
            UpdateCardPictures();

            Stand();
        }
    }
}
