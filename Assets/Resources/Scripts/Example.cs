using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;


//[RequireComponent(typeof(Button))]
public class Example : MonoBehaviour
{
    public Vector2Event vect2Event;
    public FloatEvent floatEvent;
    public float floatTimer = 2;
    public AnimationCurve animCurve;

    public void ButtonClicked()
    {
        StartCoroutine(ButtonEffects());
       
    }



    public IEnumerator ButtonEffects()
    {
        float timePassed = 0;
        if(timePassed<=floatTimer)
        {
            timePassed += Time.deltaTime;
            float y = animCurve.Evaluate(Mathf.Clamp01(timePassed / floatTimer));
            floatEvent.Invoke(y);
            vect2Event.Invoke(Vector3.one * y);
            yield return null;
        }
    }


  
   
    [System.Serializable]
    public class Vector2Event : UnityEvent<Vector3> { }
    [System.Serializable]
    public class FloatEvent : UnityEvent<float> { }
}
