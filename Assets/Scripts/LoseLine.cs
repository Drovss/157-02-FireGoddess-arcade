using UnityEngine;
using UnityEngine.Events;

public class LoseLine : MonoBehaviour
{
    public UnityEvent LoseEvent;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Enemy>())
        {
            LoseEvent.Invoke();
        }
    }
}
