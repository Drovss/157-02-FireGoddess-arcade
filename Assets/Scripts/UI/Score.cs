using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class Score : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _scoreText;

    private int _score = 0;

    public UnityEvent<int> SaveScoreEvent;

    private void OnEnable()
    {
        Enemy.UpScoreAction += UpScore;
    }

    private void OnDisable()
    {
        Enemy.UpScoreAction -= UpScore;
    }

    public void UpScore(int size)
    {
        _score += size;
        _scoreText.SetText(_score.ToString());
    }

    public void SaveScore()
    {
        SaveScoreEvent.Invoke(_score);
    }
}
