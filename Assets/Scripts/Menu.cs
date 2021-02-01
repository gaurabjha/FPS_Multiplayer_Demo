using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour
{
    public string MenuName;
    //[HideInInspector]
    public bool open = true;

    public void Open()
    {
        this.gameObject.SetActive(true);
        open = true;
    }
    public void Close()
    {
        this.gameObject.SetActive(false);
        open = false;
    }
}