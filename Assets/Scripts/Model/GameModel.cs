using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

namespace Model
{
    public class GameModel
    {
        private readonly Sprite _defaultSprite;
        
        private int _count;
        private int _counter;
        
        public List<CardModel> Cards { get; }
        

        public GameModel(Sprite defaultSprite)
        {
            Cards = new List<CardModel>();
            _defaultSprite = defaultSprite;
        }

        public void Initialize(List<Sprite> images)
        {
            _count = images.Count;
            
            for (var i = 0; i < _count; i++)
            {
                Cards.Add(new CardModel(i, images[i], _defaultSprite));
                Cards.Add(new CardModel(i, images[i], _defaultSprite));
            }
            
            ShuffleCards();
        }

        private void ShuffleCards()
        {
            var random = new Random();
            var count = Cards.Count;
            
            while (count > 1)
            {
                count--;
                
                var k = random.Next(count + 1);
                (Cards[k], Cards[count]) = (Cards[count], Cards[k]);
            }
        }

        public bool CheckMatch(CardModel card1, CardModel card2)
        {
            return card1.Id == card2.Id;
        }

        public bool AllCardsOpened()
        {
            _counter++;
            return _counter == _count;
        }
    }
}