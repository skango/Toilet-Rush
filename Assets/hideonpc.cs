using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class hideonpc : MonoBehaviour
{
    public UnityEvent pcEvent;

    private void Start()
    {
        if (!Application.isMobilePlatform)
        {
            gameObject.SetActive(false);
            pcEvent.Invoke();
        }
    }

   
}
