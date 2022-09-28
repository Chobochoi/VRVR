using UnityEngine;
using Amazon;
using Amazon.CognitoIdentity;
using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DataModel;


public class AWSStartProgram : MonoBehaviour
{
    CognitoAWSCredentials credentials;
    AmazonDynamoDBClient DBClient;
    DynamoDBContext DBContext;


    private void Awake()
    {
        UnityInitializer.AttachToGameObject(this.gameObject);
        credentials = new CognitoAWSCredentials("ap-northeast-2:7a03932f-576e-4943-b95e-219d293e2774", RegionEndpoint.APNortheast2);
        DBClient = new AmazonDynamoDBClient(credentials, RegionEndpoint.APNortheast2);
        DBContext = new DynamoDBContext(DBClient);

        SaveObject();


    }

    [DynamoDBTable("SmartStoreDB")]
    public class Object
    {
        [DynamoDBHashKey]
        public string userID { get; set; }
        [DynamoDBProperty]
        public string objectName { get; set; }
        public int countNum { get; set; }
    }

    void SaveObject()
    {
        Object object1 = new Object
        {
            objectName = "objcet2",
            countNum = 2,
        };
        DBContext.SaveAsync(object1, (result) =>
        {
            if (result.Exception == null)
            {
                Debug.Log("Success!");
            }
            else
            {
                Debug.Log(result.Exception);
            }
        });
    }
}
