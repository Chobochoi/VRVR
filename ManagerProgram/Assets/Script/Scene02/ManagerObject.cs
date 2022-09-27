using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ManagerObject : MonoBehaviour
{
   
    GameObject Target;
    public Text targetNameText;
    public Text targetSizeText;
    float targetScaleX;
    float targetScaleY;
    float targetScaleZ;

    public Slider scaleBar;
    public Slider XBar;
    public Slider YBar;
    public Slider ZBar;

    public float scale;

    public InputField scaleInput;
    public InputField xInput;
    public InputField yInput;
    public InputField zInput;

    public Text targetRotateText;
    float targetRotateX;
    float targetRotateY;
    float targetRotateZ;

    public Text targetColorText;



    public Camera camera;
    public UIController UI;


    public int countInstances = 0;

    Material OutLine;
    Renderer renderer;
    List<Material> materialList = new List<Material>();


    void Start()
    {
        OutLine = new Material(Shader.Find("Custom/OutLine"));
    } 
    void Update()
    {
        CreateAndDeleteObject();
        ChangeObject();
    }

    void CreateAndDeleteObject()
    {
        if(Input.GetMouseButtonDown(0) && UI.UserModCheck == false && UI.ChangeModCheck == false)
        {
            Ray ray = camera.ScreenPointToRay(Input.mousePosition);
            RaycastHit Hit;
            Debug.DrawRay(ray.origin, ray.direction * 100f, Color.blue, 1f);
            
            if(Physics.Raycast(ray,out Hit)  )
            {
                if(Hit.transform.CompareTag("Object") && GameManager.instance.selectObjectNumber == 0)
                {
                    Destroy(Hit.transform.gameObject);
                }
                
                else if(Hit.transform.CompareTag("Floor") && GameManager.instance.selectObjectNumber != 0 )
                {
                    countInstances++;
                    string selectObj = GameManager.instance.selectObjectNumber.ToString();
                    Vector3 hitpos = Hit.point;
                    hitpos.y = 0.3f;

                    GameObject obj = Resources.Load(selectObj) as GameObject;
                    GameObject instance = Instantiate(obj, hitpos, Hit.transform.rotation);
                    instance.name = "Object" + countInstances;

                    ObjectController OC = instance.GetComponent<ObjectController>();
                    OC.value = countInstances;


                }
                else if(!Hit.transform.CompareTag("Floor") && GameManager.instance.selectObjectNumber != 0)
                {
                    renderer = Hit.transform.GetComponent<Renderer>();

                    materialList.Clear();
                    materialList.AddRange(renderer.sharedMaterials);
                    materialList.Add(OutLine);

                    renderer.materials = materialList.ToArray();
                }
                else
                {
                    return;
                }
            }
        }
    }

    public void ChangeObject()
    {
        if(Input.GetMouseButtonDown(0) && UI.UserModCheck == false && UI.ChangeModCheck == true)
        {
            Ray ray = camera.ScreenPointToRay(Input.mousePosition);
            RaycastHit Hit;
            Debug.DrawRay(ray.origin, ray.direction * 100f, Color.blue, 1f);
            if(Physics.Raycast(ray, out Hit))
            {
                Target = Hit.collider.gameObject;
                GameManager.instance.selectedObj = Target;
                targetNameText.text = Target.name;

                targetScaleX = Hit.transform.localScale.x;
                targetScaleY = Hit.transform.localScale.y;
                targetScaleZ = Hit.transform.localScale.z;
                targetSizeText.text = "크   기 : x = " + targetScaleX + ", y = " + targetScaleY + ", z = " + targetScaleZ; 

                targetRotateX = Hit.transform.eulerAngles.x;
                targetRotateY = Hit.transform.eulerAngles.y;
                targetRotateZ = Hit.transform.eulerAngles.z;
                targetRotateText.text = "회   전 : x = " + targetRotateX + ", y = " + targetRotateY + ", z = " + targetRotateZ; 
            }
        }
    }

    public void ChangeScaleObject()
    {
        scale = scaleBar.value;
        scaleInput.text = scale.ToString();

        Target.transform.localScale = new Vector3(scale, scale, scale);
        targetScaleX = Target.transform.localScale.x;
        targetScaleY = Target.transform.localScale.y;
        targetScaleZ = Target.transform.localScale.z;
        targetSizeText.text = "크   기 : x = " + targetScaleX + ", y = " + targetScaleY + ", z = " + targetScaleZ;


    }
    public void ChangeXRotate()
    { 
        targetRotateX = XBar.value;
        xInput.text = targetRotateX.ToString();

        Target.transform.eulerAngles = new Vector3(targetRotateX, targetRotateY, targetRotateZ);
        targetRotateText.text = "회   전 : x = " + targetRotateX + ", y = " + targetRotateY + ", z = " + targetRotateZ;
    }
    public void ChangeYRotate()
    {
        targetRotateY = YBar.value;
        yInput.text = targetRotateY.ToString();

        Target.transform.eulerAngles = new Vector3(targetRotateX, targetRotateY, targetRotateZ);
        targetRotateText.text = "회   전 : x = " + targetRotateX + ", y = " + targetRotateY + ", z = " + targetRotateZ;
    }
    public void ChangeZRotate()
    {
        targetRotateZ = ZBar.value;
        zInput.text = targetRotateZ.ToString();

        Target.transform.eulerAngles = new Vector3(targetRotateX, targetRotateY, targetRotateZ);
        targetRotateText.text = "회   전 : x = " + targetRotateX + ", y = " + targetRotateY + ", z = " + targetRotateZ;
    }

    public void ScaleInput()
    {
        string a = scaleInput.text;
        scale = float.Parse(a);

        Target.transform.localScale = new Vector3(scale, scale, scale);
        targetScaleX = Target.transform.localScale.x;
        targetScaleY = Target.transform.localScale.y;
        targetScaleZ = Target.transform.localScale.z;
        targetSizeText.text = "크   기 : x = " + targetScaleX + ", y = " + targetScaleY + ", z = " + targetScaleZ;
    }

    public void XInput()
    {
        string a = xInput.text;
        targetRotateX = float.Parse(a);

        Target.transform.eulerAngles = new Vector3(targetRotateX, targetRotateY, targetRotateZ);
        targetRotateText.text = "회   전 : x = " + targetRotateX + ", y = " + targetRotateY + ", z = " + targetRotateZ;
    }

    public void YInput()
    {
        string a = yInput.text;
        targetRotateX = float.Parse(a);

        Target.transform.eulerAngles = new Vector3(targetRotateX, targetRotateY, targetRotateZ);
        targetRotateText.text = "회   전 : x = " + targetRotateX + ", y = " + targetRotateY + ", z = " + targetRotateZ;
    }

    public void ZInput()
    {
        string a = zInput.text;
        targetRotateX = float.Parse(a);

        Target.transform.eulerAngles = new Vector3(targetRotateX, targetRotateY, targetRotateZ);
        targetRotateText.text = "회   전 : x = " + targetRotateX + ", y = " + targetRotateY + ", z = " + targetRotateZ;
    }

}
