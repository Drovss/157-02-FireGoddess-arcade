using System;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public static Action<int> UpScoreAction;
    public static Action<GameObject> ReturnElementAction;

    public void ReturnElement()
    {        
        if (ReturnElementAction != null)
        {
            ReturnElementAction(gameObject);
        }
        UpScore();
    }

    private void UpScore()
    {
        if (UpScoreAction != null)
        {
            UpScoreAction(3);
        }
    }
}
