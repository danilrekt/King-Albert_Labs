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
    public partial class CardFinishStack : UserControl
    {
        public CardFinishStack()
        {
            InitializeComponent();
        }

        private Stack<Card> _cards = new Stack<Card>();

        public bool IsFull { get; private set; } = false;

        public bool CanAddCard(Card card)
        {
            if(!_cards.TryPeek(out var topCard))
            {
                //пустой стек

                if (card.Rank == 14)
                    return true; 

                else return false;
            }

            if(card.Rank == topCard.Rank-1) //карта на 1 меньше
                return true;

            return false;
        }

        public void AddCard(Card card)
        {
            _cards.Push(card);
            
            panel1.Controls.Add(card);
            card.Location = new Point(0, 0);
            card.BringToFront();

            card.MouseMove += Card_MouseMove;
            card.MouseUp += Card_MouseUp;

            if(card.Rank == 2) { 
                IsFull = true;
                StackIsFull?.Invoke();
            }
        }

        public event Action StackIsFull;

        private void Card_MouseMove(object? sender, MouseEventArgs e)
        {
            this.OnMouseMove(e);
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            this.OnMouseMove(e);
        }

        private void Card_MouseUp(object? sender, MouseEventArgs e)
        {
            this.OnMouseUp(e);
        }

        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            this.OnMouseUp(e);
        }
    }
}
