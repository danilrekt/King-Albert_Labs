using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;

namespace King_Albert
{
    public partial class Reserv : UserControl
    {
        public Reserv()
        {
            InitializeComponent();
        }

        List<Card> _cards = new List<Card>();

        public void Fill(Card[] cards)
        {
            _cards.AddRange(cards);
            panel1.Controls.AddRange(cards);

            int nextOffset = 0;
            foreach (Card card in _cards)
            {
                card.MouseDown += Card_MouseDown;
                card.MouseMove += Card_MouseMove;
                card.MouseUp += Card_MouseUp;
                card.LastCardPlace = CardPlaces.Reserv;
                card.LastCardColumn = null;

                card.Location = new Point(nextOffset, 0);
                nextOffset += 50;
            }

            BringCardsToFront();
        }

        private void BringCardsToFront()
        {
            foreach (Control card in _cards)
            {
                card.BringToFront();
            }
        }

        int _preremoveOffset;
        public void PreRemoveCard(Card card)
        {
            card.MouseDown -= Card_MouseDown;
            card.MouseUp -= Card_MouseUp;
            card.MouseMove -= Card_MouseMove;

            _preremoveOffset = card.Location.X;
            panel1.Controls.Remove(card);
            _cards.Remove(card);
        }

        public void CanselRemoveCard(Card card)
        {
            panel1.Controls.Add(card);
            _cards.Insert(_preremoveOffset / 50, card);
            card.Location = new Point(_preremoveOffset, 0);
            BringCardsToFront();

            card.MouseDown += Card_MouseDown;
            card.MouseUp += Card_MouseUp;
            card.MouseMove += Card_MouseMove;
        }

        public void CompleteRemoveCard(Card card)
        {
            //var empty = panel1.Controls[_emptyIdx];
            //empty.Hide();

            
        }

        private void Card_MouseDown(object? sender, MouseEventArgs e)
        {
            //this.OnMouseDown(e);
            var card = sender as Card;
            CardMouseDown.Invoke(card!, e);
        }

        private void Card_MouseMove(object? sender, MouseEventArgs e)
        {
            var card = sender as Card;
            panel1_MouseMove(panel1, new MouseEventArgs(MouseButtons.None, 0, e.X + card.Location.X, e.Y + card.Location.Y, e.Delta));
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            this.OnMouseMove(e);
        }

        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            this.OnMouseUp(e);
        }

        private void Card_MouseUp(object? sender, MouseEventArgs e)
        {
            this.OnMouseUp(e);
        }

        public event CardMouseDownHanler CardMouseDown;
    }
}
