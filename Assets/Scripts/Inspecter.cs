using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inspecter : MonoBehaviour
{
    

    public void InspecterStart()
    {
        gameObject.SetActive(true);
    }
    public void InspecterEnd()
    {
        gameObject.SetActive(false);
    }

}
