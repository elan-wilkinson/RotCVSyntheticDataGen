using UnityEngine;
using System.IO;

public class Randomizer : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] Light light;
    [SerializeField] float lightMin, lightMax;
    [SerializeField] string writePath;
    Camera mainCam;
    [SerializeField] Material carMat;
    [SerializeField] GameObject[] roadObjs;
    void Start()
    {
        mainCam = Camera.main;
    }
    int dirIdx = 0;
    string lab = string.Empty;
    [SerializeField] float domeDist = 1.0f;
    int roadIdx = 0;
    // Update is called once per frame
    void Update()
    {
        // ----------------------------------------------------------------- Randomizer 1 -----------------------------------------------------------------------------
        /*
        transform.eulerAngles = new Vector3(Random.Range(0, 360.0f), Random.Range(0, 360.0f), Random.Range(0, 360.0f));
        light.transform.eulerAngles = new Vector3(Random.Range(0, 360.0f), Random.Range(0, 360.0f), Random.Range(0, 360.0f));
        light.intensity = Random.Range(lightMin, lightMax);

        Quaternion objectRotation = transform.rotation;

        Quaternion cameraInverseRotation = Quaternion.Inverse(mainCam.transform.rotation);

        Quaternion relativeRotation = cameraInverseRotation * objectRotation;

        Vector3 eulerRotation = relativeRotation.eulerAngles;

        WriteRotationToFile(eulerRotation);
        */ //--------------------------------------------------------------------------------------------------------------------------------------------------------------------
           // ----------------------------------------------------------------- Randomizer 2 -----------------------------------------------------------------------------
        /*
     light.transform.eulerAngles = new Vector3(Random.Range(0, 360.0f), Random.Range(0, 360.0f), Random.Range(0, 360.0f));
     light.intensity = Random.Range(lightMin, lightMax);
     carMat.color = new Color(Random.Range(0, 1.0f), Random.Range(0, 1.0f), Random.Range(0, 1.0f));
     dirIdx = Random.Range(0, 5);
     switch (dirIdx)
     {
         case 0:
             transform.eulerAngles = Vector3.zero;
             lab = "forward";
             break;
         case 1:
             transform.eulerAngles = new Vector3(0, 90, 0);
             lab = "left";
             break;
         case 2:
             transform.eulerAngles = new Vector3(0, 270, 0);
             lab = "right";
             break;
         case 3:
             transform.eulerAngles = new Vector3(0, 180, 0);
             lab = "right";
             break;
         default:
             lab = "top";
             int topDir = Random.Range(0, 4);
             switch (topDir)
             {
                 case 0:
                     transform.eulerAngles = new Vector3(90, 180, 0);
                     break;
                 case 1:
                     transform.eulerAngles = new Vector3(0, 270, 90);
                     break;
                 case 2:
                     transform.eulerAngles = new Vector3(270, 270,90);
                     break;
                 default:
                     transform.eulerAngles = new Vector3(180, 270, 90);
                     break;
             }
             break;
     }
        WriteRotationToFile(lab);
        */
        //--------------------------------------------------------------------------------------------------------------------------------
          // ----------------------------------------------------------------- Randomizer 3 -----------------------------------------------------------------------------
        
     light.transform.eulerAngles = new Vector3(Random.Range(0, 360.0f), Random.Range(0, 360.0f), Random.Range(0, 360.0f));
     light.intensity = Random.Range(lightMin, lightMax);
     carMat.color = new Color(Random.Range(0, 1.0f), Random.Range(0, 1.0f), Random.Range(0, 1.0f));
        // Random azimuthal angle (0 to 2 * PI)
        float theta = Random.Range(0f, 2f * Mathf.PI);

        // Random polar angle (0 to PI/2)
        float phi = Random.Range(0f, Mathf.PI / 2f);

        // Convert spherical to Cartesian coordinates
        float x = domeDist * Mathf.Sin(phi) * Mathf.Cos(theta);
        float y = domeDist * Mathf.Cos(phi);
        float z = domeDist * Mathf.Sin(phi) * Mathf.Sin(theta); // domeDist * Mathf.Cos(phi);

        mainCam.transform.position = new Vector3(x, y, z);
        mainCam.transform.LookAt(this.transform.position, Vector3.up);
        roadObjs[roadIdx].SetActive(false);
        roadIdx = Random.Range(0, 4);
        roadObjs[roadIdx].SetActive(true);
        Quaternion objectRotation = transform.rotation;

        Quaternion cameraInverseRotation = Quaternion.Inverse(mainCam.transform.rotation);

        Quaternion relativeRotation = cameraInverseRotation * objectRotation;

        Vector3 eulerRotation = relativeRotation.eulerAngles;

        WriteRotationToFile(eulerRotation);


        //--------------------------------------------------------------------------------------------------------------------------------

    }

    int files = 0;
    void WriteRotationToFile(string label)
    {
        string dataLine = label;

        string filePath = Path.Join(writePath, files.ToString() + ".txt");
        files++;


        using (StreamWriter writer = new StreamWriter(filePath))
        {
            writer.WriteLine(dataLine);
        }
    }
        void WriteRotationToFile(Vector3 eulerRotation)
    {
        string dataLine = 
                          eulerRotation.x.ToString("F4") + "," +
                          eulerRotation.y.ToString("F4") + "," +
                          eulerRotation.z.ToString("F4");

        string filePath = Path.Join(writePath, files.ToString() + ".txt");
        files++;


        using (StreamWriter writer = new StreamWriter(filePath))
        {
            writer.WriteLine(dataLine); 
        }
    }

}
