using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class ErrorMessage : MonoBehaviour
{
    public string message;
    public TMP_Text banner;

    private void Update()
    {
        banner.text = message;
    }
}
