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
    public Slider speedBar;

    public float scale;

    public InputField scaleInput;
    public InputField xInput;
    public InputField yInput;
    public InputField zInput;
    public InputField speedInput;

    public Text targetRotateText;
    float targetRotateX;
    float targetRotateY;
    float targetRotateZ;
    float targetSpeed;

    public Text targetSpeedText;



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
                    ObjectController OC = instance.GetComponent<ObjectController>();

                    OC.prefabTypeNum = GameManager.instance.selectObjectNumber;
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
            if(Physics.Raycast(ray, out Hit) )
            {
                if (Hit.transform.CompareTag("Object"))
                {
                    Target = Hit.collider.gameObject;
                    GameManager.instance.selectedObj = Target;
                    targetNameText.text = Target.name;

                    GameManager.instance.objectPositionX = Hit.transform.position.x;
                    GameManager.instance.objectPositionY = Hit.transform.position.y;
                    GameManager.instance.objectPositionZ = Hit.transform.position.z;

                    targetScaleX = Hit.transform.localScale.x;
                    targetScaleY = Hit.transform.localScale.y;
                    targetScaleZ = Hit.transform.localScale.z;
                    targetSizeText.text = "크   기 : x = " + targetScaleX + ", y = " + targetScaleY + ", z = " + targetScaleZ;

                    targetRotateX = Hit.transform.eulerAngles.x;
                    targetRotateY = Hit.transform.eulerAngles.y;
                    targetRotateZ = Hit.transform.eulerAngles.z;
                    targetRotateText.text = "회   전 : x = " + targetRotateX + ", y = " + targetRotateY + ", z = " + targetRotateZ;

                    ObjectController TargetSpeed = Target.GetComponent<ObjectController>();
                    targetSpeed = TargetSpeed.speed;
                    targetSpeedText.text = "속   도 : " + targetSpeed;
                }
            }
        }
    }

    public void ChangeScaleObject()
    {
        scale = scaleBar.value;
        scaleInput.text = scale.ToString();
        GameManager.instance.objectScale = scale;


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
        GameManager.instance.objectRotateX = targetRotateX;

        Target.transform.eulerAngles = new Vector3(targetRotateX, targetRotateY, targetRotateZ);
        targetRotateText.text = "회   전 : x = " + targetRotateX + ", y = " + targetRotateY + ", z = " + targetRotateZ;
    }
    public void ChangeYRotate()
    {
        targetRotateY = YBar.value;
        yInput.text = targetRotateY.ToString();
        GameManager.instance.objectRotateY = targetRotateY;

        Target.transform.eulerAngles = new Vector3(targetRotateX, targetRotateY, targetRotateZ);
        targetRotateText.text = "회   전 : x = " + targetRotateX + ", y = " + targetRotateY + ", z = " + targetRotateZ;
    }
    public void ChangeZRotate()
    {
        targetRotateZ = ZBar.value;
        zInput.text = targetRotateZ.ToString();
        GameManager.instance.objectRotateZ = targetRotateZ;

        Target.transform.eulerAngles = new Vector3(targetRotateX, targetRotateY, targetRotateZ);
        targetRotateText.text = "회   전 : x = " + targetRotateX + ", y = " + targetRotateY + ", z = " + targetRotateZ;
    }

    public void ChangeSpeed()
    {
        ObjectController TargetSpeed = Target.GetComponent<ObjectController>();
        targetSpeed = speedBar.value;
        speedInput.text = targetSpeed.ToString();
        GameManager.instance.objectRotateSpeed = targetSpeed;

        TargetSpeed.speed = targetSpeed;
        targetSpeedText.text = "속   도 : " + targetSpeed;

    }

    public void ScaleInput()
    {
        string a = scaleInput.text;
        scale = float.Parse(a);
        GameManager.instance.objectScale = scale;

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
        GameManager.instance.objectRotateX = targetRotateX;

        Target.transform.eulerAngles = new Vector3(targetRotateX, targetRotateY, targetRotateZ);
        targetRotateText.text = "회   전 : x = " + targetRotateX + ", y = " + targetRotateY + ", z = " + targetRotateZ;
    }

    public void YInput()
    {
        string a = yInput.text;
        targetRotateY = float.Parse(a);
        GameManager.instance.objectRotateY = targetRotateY;

        Target.transform.eulerAngles = new Vector3(targetRotateX, targetRotateY, targetRotateZ);
        targetRotateText.text = "회   전 : x = " + targetRotateX + ", y = " + targetRotateY + ", z = " + targetRotateZ;
    }

    public void ZInput()
    {
        string a = zInput.text;
        targetRotateZ = float.Parse(a);
        GameManager.instance.objectRotateZ = targetRotateZ;

        Target.transform.eulerAngles = new Vector3(targetRotateX, targetRotateY, targetRotateZ);
        targetRotateText.text = "회   전 : x = " + targetRotateX + ", y = " + targetRotateY + ", z = " + targetRotateZ;
    }

    public void SpeedInput()
    {
        string a = speedInput.text;
        targetSpeed = float.Parse(a);
        GameManager.instance.objectRotateSpeed = targetSpeed;

        ObjectController TargetSpeed = Target.GetComponent<ObjectController>();
        TargetSpeed.speed = targetSpeed;

    }

}
