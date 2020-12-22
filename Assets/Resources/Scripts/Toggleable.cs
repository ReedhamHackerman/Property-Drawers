using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Toggleable<T>
{
    public bool toogle = true;
    
    public T myValue;
    public bool GetValue(out T myInt)
    {
        
        myInt = myValue;
        return toogle;
    }
   

}
