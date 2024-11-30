using UnityEngine;
using System.IO;
using System.Text;

public class Randomizer : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] Light light;
    [SerializeField] float lightMin, lightMax;
    [SerializeField] string writePath;
    Camera mainCam;
    [SerializeField] Material carMat;
    [SerializeField] GameObject[] roadObjs;
    [SerializeField] Material backgroundMaterial;
    [SerializeField] GameObject[] tables;
    
    void Start()
    {
        mainCam = Camera.main;
    }
    int dirIdx = 0;
    string lab = string.Empty;
    [SerializeField] float[] domeDist;
    int roadIdx = 0;
    // Update is called once per frame
    StringBuilder sb = new();
    int count = 0;
    int tableIdx = 0;

    void Update()
    {
        // ----------------------------------------------------------------- Randomizer 1 -----------------------------------------------------------------------------

        tables[tableIdx].SetActive(false);
        tableIdx = Random.Range(0, 4);
        tables[tableIdx].SetActive(true);
        float tableYRot = Random.Range(0, 360.0f);
        tables[tableIdx].transform.eulerAngles = new Vector3(0, tableYRot, 0);
        // Random azimuthal angle (0 to 2 * PI)
        float theta = Random.Range(0f, 2f * Mathf.PI);

        // Random polar angle (0 to PI/2)
        float phi = Random.Range(0f, Mathf.PI / 2f);

        // Convert spherical to Cartesian coordinates
        float dome_Dist = Random.Range(domeDist[0], domeDist[1]);
        float x = dome_Dist * Mathf.Sin(phi) * Mathf.Cos(theta);
        float y = dome_Dist * Mathf.Cos(phi);
        float z = dome_Dist * Mathf.Sin(phi) * Mathf.Sin(theta); // domeDist * Mathf.Cos(phi);
        float zDist = Random.Range(-0.9f, 0.44f);
        float xDist = Random.Range(-0.45f, 0.45f);
        mainCam.transform.position = new Vector3(x, y, z);
        mainCam.transform.LookAt(this.transform.position, Vector3.up);


        light.transform.eulerAngles = new Vector3(Random.Range(0, 360.0f), Random.Range(0, 360.0f), Random.Range(0, 360.0f));
        light.intensity = Random.Range(lightMin, lightMax);
        light.colorTemperature = Random.Range(5154.0f, 20000.0f);
        float lightAngle = Vector3.Angle(light.transform.forward, Vector3.up);
        if (lightAngle < 90.0f)
            light.transform.Rotate(0, 180.0f, 0);
        mainCam.transform.Translate(Vector3.up * zDist);
        mainCam.transform.Translate(Vector3.right * xDist);
        Quaternion relativeRotation = Quaternion.Inverse(this.transform.rotation) * mainCam.transform.rotation;
      
        Vector3 eulerRotation = relativeRotation.eulerAngles;
        sb.Append(eulerRotation.x.ToString("F4") + "," +
                          eulerRotation.y.ToString("F4") + "," +
                          eulerRotation.z.ToString("F4") + "\n");
       
        if (count == 20000)
        {
            string filePath = Path.Join(writePath, files.ToString() + ".txt");


            using (StreamWriter writer = new StreamWriter(filePath))
            {
                writer.WriteLine(sb.ToString());
            }
        }
        count++;
        //WriteRotationToFile(eulerRotation);

        //--------------------------------------------------------------------------------------------------------------------------------------------------------------------
        // ----------------------------------------------------------------- Randomizer 2 -----------------------------------------------------------------------------
        /*
     light.transform.eulerAngles = new Vector3(Random.Range(0, 360.0f), Random.Range(0, 360.0f), Random.Range(0, 360.0f));
     light.intensity = Random.Range(lightMin, lightMax);
        float zDist = Random.Range(-2.366f, 1.84f);
        float xDist = Random.Range(-1.85f, 1.85f);
        transform.position = new Vector3(xDist, 0.622f, zDist);
     carMat.color = new Color(Random.Range(0, 1.0f), Random.Range(0, 1.0f), Random.Range(0, 1.0f));
     dirIdx = Random.Range(0, 6);
        float rotRand = 10.0f;
        Vector3 randAddition = new Vector3(Random.Range(0, rotRand), Random.Range(0, rotRand), Random.Range(0, rotRand));
        backgroundMaterial.color = new Color(Random.Range(0, 1.0f), Random.Range(0, 1.0f), Random.Range(0, 1.0f));
        switch (dirIdx)
     {
         case 0:
                transform.eulerAngles = Vector3.zero + randAddition;
                lab = "front\n";
                break;
         case 1:
             transform.eulerAngles = new Vector3(0, 90, 0) + randAddition;
                lab = "left\n";
             break;
         case 2:
             transform.eulerAngles = new Vector3(0, 270, 0) + randAddition;
                lab = "right\n";
             break;
         case 3:
             transform.eulerAngles = new Vector3(0, 180, 0) + randAddition;
                lab = "back\n";
             break;
         case 4:
             lab = "top\n";
             int topDir = Random.Range(0, 4);
             switch (topDir)
             {
                 case 0:
                     transform.eulerAngles = new Vector3(90, 180, 0) + randAddition;
                        break;
                 case 1:
                     transform.eulerAngles = new Vector3(0, 270, 90) + randAddition;
                        break;
                 case 2:
                     transform.eulerAngles = new Vector3(270, 270,90) + randAddition;
                        break;
                 default:
                     transform.eulerAngles = new Vector3(180, 270, 90) + randAddition;
                        break;
                }
                break;
            default:
                lab = "bottom\n";
                int bottomDir = Random.Range(0, 4);
                switch (bottomDir)
                {
                    case 0:
                        transform.eulerAngles = new Vector3(90, 0, 0) + randAddition;
                        break;
                    case 1:
                        transform.eulerAngles = new Vector3(0, -90, -90) + randAddition;
                        break;
                    case 2:
                        transform.eulerAngles = new Vector3(-90, -90, -90) + randAddition;
                        break;
                    default:
                        transform.eulerAngles = new Vector3(-180, -90, -90) + randAddition;
                        break;
                }
                break;
        }
        sb.Append(lab);
        if (count == 19999)
        {
            string filePath = Path.Join(writePath, files.ToString() + ".txt");


            using (StreamWriter writer = new StreamWriter(filePath))
            {
                writer.WriteLine(sb.ToString());
            }
        }
        count++;
        */
        //--------------------------------------------------------------------------------------------------------------------------------
        // ----------------------------------------------------------------- Randomizer 3 -----------------------------------------------------------------------------
        /*
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

        */
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
