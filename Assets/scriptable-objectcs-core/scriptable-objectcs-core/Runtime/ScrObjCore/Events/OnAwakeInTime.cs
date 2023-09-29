using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class OnAwakeInTime : MonoBehaviour
{
    public float waitTimeBeforeEvenInvoke;
    public UnityEvent onAwakeEvent;
    private void Awake()
    {
        StartCoroutine(WaitAndInvokeEvent());
    }

    IEnumerator WaitAndInvokeEvent()
    {
        yield return new WaitForSeconds(waitTimeBeforeEvenInvoke);
        onAwakeEvent?.Invoke();
    }
}
