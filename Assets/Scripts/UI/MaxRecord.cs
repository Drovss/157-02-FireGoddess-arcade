using TMPro;
using UnityEngine;

public class MaxRecord : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _recordText;

    private int _record = 0;

    private void Start()
    {
        Print();
    }

    public void Print()
    {
        ReadOnSaveRecord();

        _recordText.SetText(_record.ToString());
    }

    public void SaveNewRecord(int newScore)
    {
        if (newScore == 0)
        {
            return;
        }

        ReadOnSaveRecord();

        if (newScore > _record)
        {
            _record = newScore;
        }

        PlayerPrefs.SetInt("Record", _record);
    }

    private void ReadOnSaveRecord()
    {
        if (PlayerPrefs.HasKey("Record"))
        {
            _record = PlayerPrefs.GetInt("Record");
        }
    }   
}
