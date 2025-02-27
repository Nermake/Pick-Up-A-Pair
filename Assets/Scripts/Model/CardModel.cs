using UnityEngine;

namespace Model
{
    public class CardModel
    {
        public int Id { get; private set; }
        public Sprite CardSprite { get; private set; }
        public Sprite DefaultSprite { get; private set; }
        
        public bool IsOpened;

        public CardModel(int id, Sprite cardSprite, Sprite defaultSprite)
        {
            Id = id;
            CardSprite = cardSprite;
            DefaultSprite = defaultSprite;
            IsOpened = false;
        }
    }
}