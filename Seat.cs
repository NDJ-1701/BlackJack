using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NBlackJack
{
    public partial class Seat : UserControl
    {
        private List<PictureBox> visibleCards = new List<PictureBox>();
        private PictureBox blankCard = new CardPicture();

        public Seat()
        {
            InitializeComponent();
        }
        public void AddCard(Card card, int cardNum)
        { 
            var cardPic = (card.shown) ? card.Picture() : blankCard;
            cardPic.Location = new Point(24 * cardNum, 0);
            Hand_panel.Controls.Add(cardPic);
            cardPic.BringToFront();
            visibleCards.Add(cardPic);

            PlayerCards_label.Text += ((cardNum == 0)? "" : ", ") + card.Name();
        }

        public void AddCards(Hand cards)
        {
            // remove old cards
            ClearCards();

            for (int cardNum = 0; cardNum < cards.Count; cardNum++)
            {
                AddCard(cards[cardNum], cardNum);
            }
        }

        public void ClearCards()
        {
            foreach (PictureBox card in visibleCards)
            {
                Hand_panel.Controls.Remove(card);
            }
            visibleCards.Clear();
            PlayerCards_label.Text = "";
        }

        public void SetTotal(int total)
        {
            PlayerTotal_label.Text = (total == 0)? "" : total.ToString();
        }
    }
}
