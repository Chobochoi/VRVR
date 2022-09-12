using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class KeyboardButtonController : MonoBehaviour
{
    [SerializeField] Image containerBorderImage;
    [SerializeField] Image containerFillImage;
    [SerializeField] Image containerIcon;
    [SerializeField] TextMeshProUGUI containerText;
    [SerializeField] TextMeshProUGUI containerActionText;
    InputManager inputManager;
    private void Start()
    {
        inputManager = GameObject.FindGameObjectWithTag("InputField").GetComponent<InputManager>();

        Debug.Log(inputManager);
        SetContainerBorderColor(ColorDataStore.GetKeyboardBorderColor());
        SetContainerFillColor(ColorDataStore.GetKeyboardFillColor());
        SetContainerTextColor(ColorDataStore.GetKeyboardTextColor());
        SetContainerActionTextColor(ColorDataStore.GetKeyboardActionTextColor());
    }

    public void SetContainerBorderColor(Color color) => containerBorderImage.color = color;
    public void SetContainerFillColor(Color color) => containerFillImage.color = color;
    public void SetContainerTextColor(Color color) => containerText.color = color;
    public void SetContainerActionTextColor(Color color)
    {
        containerActionText.color = color;
        containerIcon.color = color;
    }

    public void AddLetter()
    {
        if (GameManager.Instance != null)
        {
            GameManager.Instance.AddLetter(containerText.text);
        }
        else
        {            
            inputManager.currentInputField.text += containerText.text;
        }
    }
    public void DeleteLetter()
    {
        if (GameManager.Instance != null)
        {
            GameManager.Instance.DeleteLetter();
        }

        else
        {
            if (inputManager.currentInputField.text.Length != 0)
            {
                inputManager.currentInputField.text = inputManager.currentInputField.text.Remove(inputManager.currentInputField.text.Length - 1, 1);
            }
            Debug.Log("Last char deleted");
        }
    }
    public void SubmitWord()
    {
        if (GameManager.Instance != null)
        {
            GameManager.Instance.SubmitWord();
        }
        else
        {
            Debug.Log("Submitted successfully!");
        }
    }
}