using NetCheckout.Demo;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.XR.Interaction.Toolkit;

public class CheckoutManager : MonoBehaviour
{

    public bool locked;
    public DemoCheckout checkout;
    public DemoItem item;

    public static CheckoutManager selected;

    private Vector3 originalPosition;

    [SerializeField]
    XRSimpleInteractable interactable;

    void Start()
    {
        originalPosition = transform.position;

        interactable.hoverEntered.AddListener(Enter);
        interactable.hoverExited.AddListener(Exit);
        interactable.selectEntered.AddListener(Click);
    }


    void Update()
    {

    }

    private void Enter(HoverEnterEventArgs arg)
    {
        Vector3 dir = Camera.main.transform.position - transform.position;
        transform.position += dir.normalized * 1.3f;
    }

    private void Exit(HoverExitEventArgs arg)
    {
        transform.position = originalPosition;
    }

    private void Click(SelectEnterEventArgs arg)
    {
        if (EventSystem.current.IsPointerOverGameObject())
            return;
        Debug.Log("dddd1");

        if (locked)
        {
            Buy();
            Debug.Log("dddd2");
        }


        else { Select(); }
    }

    private void OnMouseEnter()
    {
        Debug.Log("enter");

        // zoom in
        Vector3 dir = Camera.main.transform.position - transform.position;
        transform.position += dir.normalized * 1.3f;
    }

    private void OnMouseExit()
    {
        Debug.Log("exit");

        // reset zoom
        transform.position = originalPosition;
    }

    public void OnMouseUpAsButton()
    {
        Debug.Log("onmouse");

        if (EventSystem.current.IsPointerOverGameObject())
            return;
        Debug.Log("dddd1");

        if (locked) 
        {
            Buy();
        Debug.Log("dddd2");
        }


        else { Select(); }

    }

    public void Buy()
    {
        string header = string.Format("Buy {0} for ${1}?", item.name, item.price);
        checkout.SetOrderWindowHeader(header);
        checkout.SetOrderWindowImage(1, item.icon);
        checkout.BuyItem(item, OnUnlock);
        Debug.Log("dddd3");
    }

    public void Select()
    {
        if (selected)
            selected.Unselect();

        selected = this;
    }

    public void Unselect()
    {
        selected = null;


    }

    private void OnUnlock(bool success, object data)
    {
        if (success)
        {
            Debug.Log("Order ID: " + data.ToString());
            locked = false;
            Select();
        }
        else
            Debug.LogError(data.ToString());
    }
}
