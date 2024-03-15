namespace King_Albert
{
    public delegate void CardMouseDownHanler(Card card, MouseEventArgs e);

    public enum CardPutPlaceType
    {
        Column,
        Finish,
        Other
    }

    public delegate void CardMouseUpHanler(CardPutPlaceType placeType, object? place);

    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            var creator = new CardCreator();
            var oldCards = creator.CreateCards();

            var cards = new List<Card>();

            for (int i = 0; i < 52; i++)
            {
                var idx = Random.Shared.Next(0, oldCards.Count);
                var card = oldCards[idx];
                oldCards.RemoveAt(idx);
                cards.Add(card);
            }

            int skip = 0;
            for (int i = 1; i <= 9; i++)
            {
                CardColumn cardColumn = new CardColumn();
                //cardColumn.BackColor = Color.Green;
                cardColumn.Margin = new Padding(10, 0, 0, 0);
                cardColumn.Size = new Size(90, ColumnsPanel.Height);
                ColumnsPanel.Controls.Add(cardColumn);

                cardColumn.AddCards(cards.Skip(skip).Take(i).ToList());

                cardColumn.CardMouseDown += Card_MouseDown;
                cardColumn.MouseMove += CardColumn_MouseMove;
                cardColumn.CardPut += Card_MouseUpFinally;

                skip += i;
            }

            ColumnsPanel.MouseMove += flowLayoutPanel1_MouseMove;

            reserv1.Fill(cards.Skip(skip).ToArray());

            //this.BackColor = Color.Gray;
            //reserv1.BackColor = Color.White;
            //ColumnsPanel.BackColor = Color.White;

            reserv1.MouseMove += Reserv_MouseMove;
            reserv1.CardMouseDown += Card_MouseDown;

            cardFinishPanel1.MouseMove += CardFinishPanel_MouseMove;
            cardFinishPanel1.CardPut += Card_MouseUpFinally;

            cardFinishPanel1.Win += OnWin;

        }


        private Card? _card;
        private void Card_MouseDown(Card card, MouseEventArgs e)
        {
            _card = card;
            if (card.LastCardPlace == CardPlaces.Reserv)
            {
                reserv1.PreRemoveCard(card);
            }
            else
            {
                card.LastCardColumn.PreRemoveCard(card);
            }

            this.Controls.Add(card);

            card.Location = e.Location;

            card.BringToFront();
        }

        private void Reserv_MouseMove(object? sender, MouseEventArgs e)
        {
            var reserv = sender as Reserv;
            CardInHandMove(reserv, new MouseEventArgs(MouseButtons.None, 0, e.X + reserv.Location.X, e.Y + reserv.Location.Y, e.Delta));
        }

        private void Form1_MouseMove(object? sender, MouseEventArgs e)
        {
            CardInHandMove(sender, e);
        }

        private void CardInHandMove(object? sender, MouseEventArgs e)
        {
            if (_card is null)
                return;

            _card.Location = new Point(e.Location.X + 5, e.Location.Y + 5);
        }

        private void CardColumn_MouseMove(object? sender, EventArgs e)
        {
            var column = sender as CardColumn;
            var em = e as MouseEventArgs;
            flowLayoutPanel1_MouseMove(ColumnsPanel, new MouseEventArgs(MouseButtons.None, 0, em.X + column.Location.X, em.Y + column.Location.Y, em.Delta));
        }

        private void flowLayoutPanel1_MouseMove(object? sender, EventArgs e)
        {
            var lp = sender as FlowLayoutPanel;
            var em = e as MouseEventArgs;
            CardInHandMove(sender, new MouseEventArgs(MouseButtons.None, 0, em.X + lp.Location.X, em.Y + lp.Location.Y, em.Delta));
        }

        private void PutCardBackToLastPlace(Card card)
        {
            if (card.LastCardPlace == CardPlaces.Column)
            {
                _card.LastCardColumn.CancelRemoveCard(card);
            }
            else if (card.LastCardPlace == CardPlaces.Reserv)
            {
                reserv1.CanselRemoveCard(card);
            }
        }

        private void CompleteRemoveCardFromLastPlace(Card card)
        {
            if (card.LastCardPlace == CardPlaces.Column)
            {
                card.LastCardColumn.CompleteRemoveCard(card);
            }
            else if (card.LastCardPlace == CardPlaces.Reserv)
            {
                reserv1.CompleteRemoveCard(card);
            }
        }

        private void Card_MouseUpFinally(CardPutPlaceType placeType, object? place)
        {
            if (_card is null) return;

            if(placeType == CardPutPlaceType.Finish)
            {
                var finishStack = place as CardFinishStack;
                if(finishStack.CanAddCard(_card))
                {
                    CompleteRemoveCardFromLastPlace(_card);
                    finishStack.AddCard(_card);
                }
                else
                {
                    PutCardBackToLastPlace(_card);
                }
            }
            else if(placeType == CardPutPlaceType.Column)
            {
                var cardColumn = place as CardColumn;
                if (cardColumn.CanAddCard(_card))
                {
                    CompleteRemoveCardFromLastPlace(_card);
                    cardColumn.AddCard(_card);
                }
                else
                {
                    PutCardBackToLastPlace(_card);
                }
            }
            else
            {
                PutCardBackToLastPlace(_card);
            }

            _card = null;
        }

        private void ColumnsPanel_MouseUp(object sender, MouseEventArgs e)
        {
            Card_MouseUpFinally(CardPutPlaceType.Other, null);
        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            Card_MouseUpFinally(CardPutPlaceType.Other, null);
        }

        private void Reserv1_MouseUp(object sender, MouseEventArgs e)
        {
            Card_MouseUpFinally(CardPutPlaceType.Other, null);
        }

        private void Form1_MouseLeave(object sender, EventArgs e)
        {
            if (_card is null)
                return;

            //позиция мыши не успевает обновиться (может показывать, что она внутри формы, когда она не внутри формы)
            var lastmp = Control.MousePosition;
            Point mp;

            //ждать, когда позиция мыши обновится
            do
            {
                Thread.Sleep(50);
                mp = Control.MousePosition;
            } while (lastmp == mp);


            var dl = this.DesktopLocation;

            var dlr = new Point(dl.X + this.Width, dl.Y + this.Height);

            if (mp.X <= dl.X || mp.X >= dlr.X || mp.Y <= dl.Y || mp.Y >= dlr.Y || Control.MouseButtons != MouseButtons.Left)
            {
                Card_MouseUpFinally(CardPutPlaceType.Other, null);
            }

        }

        private void CardFinishPanel_MouseMove(object? sender, MouseEventArgs e)
        {
            var lp = sender as CardFinishPanel;
            var em = e as MouseEventArgs;
            CardInHandMove(sender, new MouseEventArgs(MouseButtons.None, 0, em.X + lp.Location.X, em.Y + lp.Location.Y, em.Delta));
        }

        private void OnWin()
        {
            MessageBox.Show("Выигрыш есть - можно поесть");
        }
    }
}
