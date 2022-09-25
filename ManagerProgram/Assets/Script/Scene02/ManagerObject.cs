using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerObject : MonoBehaviour
{
   
    GameObject Target;
    public Camera camera;
    public UIController UI;
    public int selectNum = 0;

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
    }

    void CreateAndDeleteObject()
    {
        if(Input.GetMouseButtonDown(0) && UI.UserModCheck == false)
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
                
                else if(Hit.transform.CompareTag("Floor") && GameManager.instance.selectObjectNumber != 0)
                {
                    string selectObj = GameManager.instance.selectObjectNumber.ToString();
                    Vector3 hitpos = Hit.point;
                    hitpos.y = 0.3f;

                    GameObject obj = Resources.Load(selectObj) as GameObject;
                    GameObject instance = Instantiate(obj, hitpos, Hit.transform.rotation);
            
                }
                else if(!Hit.transform.CompareTag("Floor") && GameManager.instance.selectObjectNumber != 0)
                {
                    renderer = Hit.transform.GetComponent<Renderer>();

                    materialList.Clear();
                    materialList.AddRange(renderer.sharedMaterials);
                    materialList.Add(OutLine);

                    renderer.materials = materialList.ToArray();
                }
            }
        }
    }
    public void SelectObject(int number)
    {
        selectNum = number; 
        GameManager.instance.selectObjectNumber = selectNum;
    }
    

}
