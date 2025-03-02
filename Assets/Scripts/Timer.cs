using TMPro;
using UnityEngine;
using View;

public class Timer : MonoBehaviour
{
    [SerializeField] private TMP_Text _timerText;
    [SerializeField] private GameView _view;
    [SerializeField] private float _timer;

    private float _time;
    private bool _isCompleted;

    private void Start()
    {
        _time = _timer;
        _isCompleted = false;
    }

    public void Update()
    {
        if (_isCompleted) return;
        
        _time -= Time.deltaTime;
        if (_time > 0)
        {
            UpdateTime(_time);
        }

        if (_time <= 0)
        {
            _view.ShowResult(GameState.Lose);
            UpdateTime(0);
        }
    }

    public void Stop() => _isCompleted = true;

    private void UpdateTime(float value)
    {
        var minutes = Mathf.RoundToInt(value / 60);
        var seconds = Mathf.RoundToInt(value % 60);

        _timerText.text = value < 60
            ? $"0:{seconds}"
            : $"{minutes}:{seconds}";
    }
}
