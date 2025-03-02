using System.Collections.Generic;
using Model;
using UnityEngine;
using View;

namespace Presenter
{
    public class GamePresenter
    {
        private GameModel _model;
        private GameView _view;
        private List<CardPresenter> _cardPresenters;
        private CardPresenter _firstCard;
        private CardPresenter _secondCard;
        private GameState _state;

        public GamePresenter(GameModel model, GameView view)
        {
            _model = model;
            _view = view;
        }
        
        public void Initialize(List<Sprite> images)
        {
            _model.Initialize(images);
            _cardPresenters = new List<CardPresenter>();

            for (int i = 0; i < _model.Cards.Count; i++)
            {
                var cardPresenter = new CardPresenter(_model.Cards[i], _view.CardViews[i], this);
                _cardPresenters.Add(cardPresenter);
            }

            _view.Initialize(_cardPresenters.ToArray());
        }

        public void OnCardClicked(CardPresenter cardPresenter)
        {
            if (_firstCard == null)
            {
                _firstCard = cardPresenter;
            }
            else
            {
                _secondCard = cardPresenter;
            }
        }

        public void CheckPair()
        {
            if (_secondCard == null) return;
            
            if (_model.CheckMatch(_firstCard.GetModel(), _secondCard.GetModel()))
            {
                if (_model.AllCardsOpened())
                {
                    _view.ShowResult(GameState.Win);
                }
            }
            else
            {
                _firstCard.HideCard();
                _secondCard.HideCard();
            }

            _firstCard = null;
            _secondCard = null;

            UnlockClick();
        }

        public void LockClick()
        {
            foreach (var button in _view.Buttons)
            {
                button.interactable = false;
            }
        }

        public void UnLockClick()
        {
            foreach (var button in _view.Buttons)
            {
                button.interactable = true;
            }
        }
        
        private void UnlockClick()
        {
            foreach (var button in _view.Buttons)
            {
                button.interactable = true;
            }
        }
    }
}