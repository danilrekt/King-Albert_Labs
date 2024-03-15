using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace King_Albert
{
    public class CardCreator
    {
        Dictionary<char, Suit> keyValuePairs = new Dictionary<char, Suit>()
        {
            { 'c', Suit.Clubs },
            { 's', Suit.Spades },
            { 'd', Suit.Diamonds },
            { 'h', Suit.Hearts }
        };

        List<string> ranks = new()
        {   "2", "3","4","5","6","7","8","9", "10", "J", "Q", "K", "A"
        };

        public List<Card> CreateCards()
        {
            var cards = new List<Card>();

            var files = Directory.GetFiles("Cards");

            var cardRanks = new List<int>();

            foreach (var fullFileStr in files)
            {
                var fileStr = Path.GetFileName(fullFileStr);
                string withoutExt = Path.GetFileNameWithoutExtension(fileStr);

                var suit = keyValuePairs[withoutExt[0]];
                var rankStr = withoutExt[1..];
                int rank = ranks.IndexOf(rankStr)+2; //"2" = 2ой ранг
                var image = Image.FromFile(fullFileStr);
                var card = new Card(suit, rank, image);

                cardRanks.Add(card.Rank);

                card.Size = new Size(90,120);

                cards.Add(card);
            }

            return cards;
        }
    }
}
