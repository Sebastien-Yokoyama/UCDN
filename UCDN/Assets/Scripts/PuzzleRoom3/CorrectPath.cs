using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CorrectPath : MonoBehaviour
{
    public GameObject floor1;
    public GameObject floor2;
    public GameObject floor3;
    public GameObject floor4;
    public GameObject floor5;
    public GameObject floor6;
    public GameObject floor7;

   // bool path1;
    bool path2;
    bool path3;
    bool path4;
    bool path5;
    bool path6;
  //  bool path7;

    // Start is called before the first frame update
    void Start()
    {
        correctPath();
    }

    // Update is called once per frame
    void Update()
    {
        correctPath();
    }


    void correctPath()
    {

        if (path3 && !path2)
        {
            if (floor3.transform.position.z < -8)
            {
                floor3.transform.Translate(0f, 0f, -20f * Time.deltaTime);
            }
        }
        if (path4 && !path3)
        {
            if (floor4.transform.position.z < -8)
            {
                floor4.transform.Translate(0f, 0f, -20f * Time.deltaTime);
            }
        }
        if (path5 && (!path3 || !path4))
        {
            if (floor5.transform.position.z < -8)
            {
                floor5.transform.Translate(0f, 0f, -20f * Time.deltaTime);
            }
        }
        if (path6 && !path5)
        {
            if (floor6.transform.position.z < -8)
            {
                floor6.transform.Translate(0f, 0f, -20f * Time.deltaTime);
            }
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        /*if (other.gameObject.CompareTag("Room3Path1"))
        {
            path1 = true;

        }*/
        if (other.gameObject.CompareTag("Room3Path2"))
        {
            path2 = true;

        }
        if (other.gameObject.CompareTag("Room3Path3"))
        {
            path3 = true;

        }
        if (other.gameObject.CompareTag("Room3Path4"))
        {
            path4 = true;

        }
        if (other.gameObject.CompareTag("Room3Path5"))
        {
            path5 = true;

        }
        if (other.gameObject.CompareTag("Room3Path6"))
        {
            path6 = true;

        }
        /* if (other.gameObject.CompareTag("Room3Path7"))
         {
             path7 = true;

         }*/
        if (other.gameObject.CompareTag("Room3Reset"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);

        }

    }
}
