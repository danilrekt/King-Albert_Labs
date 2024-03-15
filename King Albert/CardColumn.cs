using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace King_Albert
{
    public partial class CardColumn : UserControl
    {
        public CardColumn()
        {
            InitializeComponent();

            _dif = (int)(40);
        }

        private int _dif;
        private int _current = 0;

        private Stack<Card> _cards = new Stack<Card>();

        public void AddCard(Card card)
        {
            _cards.Push(card);
            AddToView(card);
            card.MouseDown += Card_MouseDown;
            card.LastCardColumn = this;
            card.LastCardPlace = CardPlaces.Column;
            card.MouseMove += CardMouseMove;
            card.MouseUp += CardMouseUp;
        }

        public bool CanAddCard(Card card)
        {
            if (!_cards.TryPeek(out var topCard))
            {
                return true; //пусто 
            }

            if (topCard.IsBlackSuit() == card.IsBlackSuit())
                return false; //одинаковый цвет

            if (card.Rank == topCard.Rank - 1) //на 1 меньше
                return true;

            return false;
        }

        public void AddCards(List<Card> cards)
        {
            foreach (Card card in cards)
            {
                AddCard(card);
            }
        }

        private void RemoveFromView(Control control)
        {
            panel1.Controls.Remove(control);
            _current -= _dif;
        }
        private void AddToView(Control control)
        {
            panel1.Controls.Add(control);
            control.Location = new Point(0, _current);
            control.BringToFront();
            _current += _dif;
        }

        private Control _empty;
        public void PreRemoveCard(Card card)
        {
            RemoveFromView(card);
            card.MouseMove -= CardMouseMove;
        }

        public void CancelRemoveCard(Card card)
        {
            AddToView(card);
            card.MouseMove += CardMouseMove;
        }

        public void CompleteRemoveCard(Card card)
        {
            card.MouseDown -= Card_MouseDown;
            _cards.Pop();
        }


        public event CardMouseDownHanler CardMouseDown;
        //не вызывается дизайнером
        private void Card_MouseDown(object? sender, MouseEventArgs e)
        {
            CardMouseDown?.Invoke(_cards.Peek(), e);
        }

        private void CardMouseMove(object? sender, MouseEventArgs e)
        {
            var card = sender as Card;
            this.OnMouseMove(new MouseEventArgs(MouseButtons.None, 0, e.X + card.Location.X, e.Y + card.Location.Y, e.Delta));
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            this.OnMouseMove(e);
        }

        public event CardMouseUpHanler CardPut;

        private void CardMouseUp(object sender, MouseEventArgs e)
        {
            CardPut?.Invoke(CardPutPlaceType.Column, this);
        }

        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            CardPut?.Invoke(CardPutPlaceType.Other, null);
        }
    }
}
