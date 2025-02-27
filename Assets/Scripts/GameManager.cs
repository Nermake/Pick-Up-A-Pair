using System.Collections.Generic;
using Model;
using Presenter;
using UnityEngine;
using UnityEngine.SceneManagement;
using View;

public class GameManager : MonoBehaviour
{
    [SerializeField] private List<Sprite> _images;
    [SerializeField] private Sprite _defaultSprite;
    [SerializeField] private GameView _gameView;

    
    void Start()
    {
        var gameModel = new GameModel(_defaultSprite);
        var gamePresenter = new GamePresenter(gameModel, _gameView);

        gamePresenter.Initialize(_images);
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
