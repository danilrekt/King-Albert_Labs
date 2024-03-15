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
    public enum Suit
    {
        Diamonds, //к
        Hearts, // к
        Spades, // ч
        Clubs // ч
    }

    public enum CardPlaces
    {
        Column,
        Reserv
    }

    public partial class Card : UserControl
    {
        public Suit Suit { get; private set; }
        public int Rank { get; private set; } //"2" 2 ... 14 "туз"

        public CardPlaces LastCardPlace { get; set; }
        public CardColumn? LastCardColumn { get; set; }

        public bool IsBlackSuit()
        {
            if (Suit == Suit.Spades || Suit == Suit.Clubs)
                return true;

            return false;
        }

        public Card(Suit suit, int rank, Image image)
        {
            InitializeComponent();

            Suit = suit;
            Rank = rank;
            pictureBox1.Image = image;
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            var pic = sender as PictureBox;
            pic.Capture = false;
            this.OnMouseDown(e);
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            this.OnMouseMove(e);
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            this.OnMouseUp(e);
        }
    }
}
