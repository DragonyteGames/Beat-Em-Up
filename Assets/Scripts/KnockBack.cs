using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class KnockBack : MonoBehaviour
{
    [SerializeField]
    private Rigidbody2D rb2D;

    [SerializeField]
    private float strength = 5, delay = 0.15f;

    public UnityEvent OnBegin, OnDone;

    public void PlayKnockBack(GameObject sender)
    {
        StopAllCoroutines();
        OnBegin?.Invoke();
        Vector2 direction = (transform.position - sender.transform.position).normalized;
        rb2D.AddForce(direction * strength, ForceMode2D.Impulse);
        StartCoroutine(Reset());
    }

    private IEnumerator Reset()
    {
        yield return new WaitForSeconds(delay);
        rb2D.velocity = Vector2.zero;
        OnDone?.Invoke();
    }

}
