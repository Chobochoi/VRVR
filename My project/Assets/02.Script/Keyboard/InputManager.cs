using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class InputManager : MonoBehaviour
{
    [SerializeField]
    TMP_InputField[] inputFields;

    public TMP_InputField currentInputField;

    private void Update()
    {
        foreach (TMP_InputField item in inputFields)
        {
            if (item.isFocused)
                currentInputField = item;
        }
    }
}
