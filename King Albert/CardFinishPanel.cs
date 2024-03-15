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
    public partial class CardFinishPanel : UserControl
    {
        public CardFinishPanel()
        {
            InitializeComponent();
        }

        private void CardFinishPanel_Load(object sender, EventArgs e)
        {
            cardFinishStack1.StackIsFull += cardFinishStack_Full;
            cardFinishStack2.StackIsFull += cardFinishStack_Full;
            cardFinishStack3.StackIsFull += cardFinishStack_Full;
            cardFinishStack4.StackIsFull += cardFinishStack_Full;
        }

        private void cardFinishStack_MouseMove(object sender, MouseEventArgs e)
        {
            var cardStack = sender as Control;
            this.OnMouseMove(new MouseEventArgs(MouseButtons.None, 0, e.X + cardStack.Location.X, e.Y + cardStack.Location.Y, e.Delta));
        }

        public event CardMouseUpHanler CardPut;
        private void cardFinishStack_MouseUp(object sender, MouseEventArgs e)
        {
            CardPut?.Invoke(CardPutPlaceType.Finish, sender as CardFinishStack);
        }

        private void cardFinishStack_Full()
        {
            if (cardFinishStack1.IsFull ||
                cardFinishStack2.IsFull ||
                cardFinishStack3.IsFull ||
                cardFinishStack4.IsFull
                )
            {
                Win?.Invoke();
            }
        }

        public event Action Win;
    }
}
