using System.Collections.Generic;
using Presenter;
using UnityEngine;
using UnityEngine.UI;

namespace View
{
    public class GameView : MonoBehaviour
    {
        [SerializeField] private ResultPanel _resultPanel;
        [SerializeField] private Timer _timer;
        [field: SerializeField] public List<CardView> CardViews { get; private set; }
        
        public List<Button> Buttons { get; private set; }

        public void Initialize(CardPresenter[] presenters)
        {
            Buttons = new List<Button>();
            
            for (var i = 0; i < CardViews.Count; i++)
            {
                CardViews[i].SetPresenter(presenters[i]);
                Buttons.Add(CardViews[i].GetComponent<Button>());
            }
        }

        public void ShowResult(GameState state)
        {
            _resultPanel.gameObject.SetActive(true);

            if (state == GameState.Win)
            {
                _resultPanel.Text.text = "You Win!";
                _timer.Stop();
            }
            if (state == GameState.Lose)
            {
                _resultPanel.Text.text = "You Lose!";
            }
        }
    }

    public enum GameState
    {
        None,
        Win,
        Lose
    }
}