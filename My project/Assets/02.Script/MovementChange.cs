using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MovementChange : MonoBehaviour
{
    [SerializeField] GameObject Watch;
    [SerializeField] GameObject DisWatch;
    public InputActionReference rightHandSelect;
    float rayDistance = 30.0f;

    private void Awake()
    {        
        rightHandSelect.action.started += OnRightHandSelect;
    }

    void Start()
    {
        Watch = GetComponent<GameObject>();
        DisWatch = GetComponent<GameObject>();
    }

    void Update()
    {
        ChangeWatch();
    }

    public void ChangeWatch()
    {
        Ray ray = new Ray(transform.position, transform.forward * rayDistance);
        RaycastHit hitData;

        if (Physics.Raycast(transform.position, transform.forward, out hitData, Mathf.Infinity, LayerMask.GetMask("Movement")))
        {
            Watch.SetActive(false);
            DisWatch.SetActive(true);
        }

        else
        {
            Watch.SetActive(true);
            DisWatch.SetActive(false);
        }


    }

    public void OnRightHandSelect(InputAction.CallbackContext context)
    {
        ChangeWatch();
    }
}
