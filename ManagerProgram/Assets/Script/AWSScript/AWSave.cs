using UnityEngine;
using Amazon;
using Amazon.CognitoIdentity;
using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DataModel;



public class AWSave : MonoBehaviour
{
    CognitoAWSCredentials credentials;
    AmazonDynamoDBClient DBClient;
    DynamoDBContext DBContext;

    private void Awake()
    {
        UnityInitializer.AttachToGameObject(this.gameObject);

        Amazon.AWSConfigs.HttpClient = Amazon.AWSConfigs.HttpClientOption.UnityWebRequest;
        credentials = new CognitoAWSCredentials("ap-northeast-2:7a03932f-576e-4943-b95e-219d293e2774", RegionEndpoint.APNortheast2);
        DBClient = new AmazonDynamoDBClient(credentials, RegionEndpoint.APNortheast2);
        DBContext = new DynamoDBContext(DBClient);
    }

    [DynamoDBTable("SmartStoreDB")]
    public class Object
    {
        [DynamoDBHashKey]
        public string userID { get; set; }
        [DynamoDBProperty]
        public int storeNum { get; set; }
        [DynamoDBProperty]
        public string storeName { get; set; }
        [DynamoDBProperty]
        public int objectCount { get; set; }
        [DynamoDBProperty]
        public string instanceName { get; set; }
        [DynamoDBProperty]
        public int countNum { get; set; }
        [DynamoDBProperty]
        public int prefabTypeNum { get; set; }
        [DynamoDBProperty]
        public float objectPositionX { get; set; }
        [DynamoDBProperty]
        public float objectPositionY { get; set; }
        [DynamoDBProperty]
        public float objectPositionZ { get; set; }
        [DynamoDBProperty]
        public float objectRotateX { get; set; }
        [DynamoDBProperty]
        public float objectRotateY { get; set; }
        [DynamoDBProperty]
        public float objectRotateZ { get; set; }
        [DynamoDBProperty]
        public float objectScale { get; set; }
        [DynamoDBProperty]
        public float objectRotateSpeed { get; set; }
    }

    public void SaveObject(int a)
    {
        Object object1 = new Object
        {
            userID = GameManager.instance.userID,
            storeNum = GameManager.instance.storeNum,
            storeName = GameManager.instance.storeName,
            instanceName = GameManager.instance.objectName,
            objectCount = GameManager.instance.objectCount,
            countNum = GameManager.instance.value,
            prefabTypeNum = GameManager.instance.prefabTypeNum,
            objectScale = GameManager.instance.objectScale,
            objectPositionX = GameManager.instance.objectPositionX,
            objectPositionY = GameManager.instance.objectPositionY,
            objectPositionZ = GameManager.instance.objectPositionZ,
            objectRotateX = GameManager.instance.objectRotateX,
            objectRotateY = GameManager.instance.objectRotateY,
            objectRotateZ = GameManager.instance.objectPositionZ,
            objectRotateSpeed = GameManager.instance.objectRotateSpeed,
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
