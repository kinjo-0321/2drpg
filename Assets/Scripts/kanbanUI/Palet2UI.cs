using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Palet2UI : MonoBehaviour
{
    public void Plate2Open()
    {
        gameObject.SetActive(true);
    }

    public void Plate2Close()
    {
        gameObject.SetActive(false);
    }
}
