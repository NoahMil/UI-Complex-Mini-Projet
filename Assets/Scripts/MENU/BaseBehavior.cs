using System;
using UnityEngine;
using System.Collections;

namespace MENU
{
    public class BaseBehavior : MonoBehaviour
    {
        protected Coroutine Invoke(Action action, float time)
        {
            return StartCoroutine(InvokeAfterTime(action, time));
        }

        private IEnumerator InvokeAfterTime(Action action, float time)
        {
            yield return new WaitForSeconds(time);
            
            action?.Invoke();
        }
        
    }
}
