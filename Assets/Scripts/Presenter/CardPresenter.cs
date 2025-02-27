using Model;
using View;

namespace Presenter
{
    public class CardPresenter
    {
        private CardModel _model;
        private CardView _view;
        private GamePresenter _gamePresenter;

        public CardPresenter(CardModel model, CardView view, GamePresenter gamePresenter)
        {
            _model = model;
            _view = view;
            _gamePresenter = gamePresenter;

            _view.SetSprite(_model.DefaultSprite);
        }

        public void OnCardClicked()
        {
            if (!_model.IsOpened)
            {
                _view.FlipCard();
                
                _gamePresenter.OnCardClicked(this);
            }
        }
        
        public void CheckPair() => _gamePresenter.CheckPair();
        public void HideCard() => _view.HideCard();
        public void LockClick() => _gamePresenter.LockClick();

        public void ShowCard()
        {
            _model.IsOpened = !_model.IsOpened;

            _view.SetSprite(_model.IsOpened ? _model.CardSprite : _model.DefaultSprite);
        }

        public CardModel GetModel() => _model;
    }
}