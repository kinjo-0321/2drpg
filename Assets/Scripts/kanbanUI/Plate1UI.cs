using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plate1UI : MonoBehaviour
{
    [SerializeField] playercontroller player;
    public void Plate1Open()
    {
        gameObject.SetActive(true);
    }

    public void Plate1Close()
    {
        gameObject.SetActive(false);
    }
}
