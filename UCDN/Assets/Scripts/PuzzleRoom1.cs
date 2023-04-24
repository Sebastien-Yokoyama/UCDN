using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleRoom1 : MonoBehaviour
{

    public GameObject LeverPanel = null;
    public GameObject movingDoor;
    public GameObject pivotRed;
    public GameObject pivotGreen;
    public GameObject pivotYellow;
    public GameObject pivotBlue;

    bool RedHere;
    bool GreenHere;
    bool YellowHere;
    bool BlueHere;

    bool red;
    bool green;
    bool yellow;
    bool blue;


    void Start()
    {
        LeverPanel.SetActive(false);

        RedHere = false;
        GreenHere = false;
        YellowHere = false;
        BlueHere = false;

    }

    void Update()
    {
        LeverPull();
        PuzzleFunc();
        leverPivot(red, pivotRed);
        leverPivot(green, pivotGreen);
        leverPivot(yellow, pivotYellow);
        leverPivot(blue, pivotBlue);

    }

    private void LeverPull()
    {
        if (RedHere && Input.GetKeyDown(KeyCode.E))
        {
            red = true;
            
        }
        if (GreenHere && Input.GetKeyDown(KeyCode.E))
        {
            green = true;
        }
        if (YellowHere && Input.GetKeyDown(KeyCode.E))
        {
            yellow = true;
        }
        if (BlueHere && Input.GetKeyDown(KeyCode.E))
        {
            blue = true;
        }
    }

    private void leverPivot(bool color, GameObject pivot)
    {
        if (color)
        {
            if (pivot.transform.localEulerAngles.z <= 60)
            {
                pivot.transform.Rotate(new Vector3(0f, 0f, 30f) * Time.deltaTime);
            }
        }
        else if (color == false)
        {
            if (pivot.transform.localEulerAngles.z >= 1)
            {
                pivot.transform.Rotate(new Vector3(0f, 0f, -30f) * Time.deltaTime);
            }
        }
     
    }

    private void PuzzleFunc()
    {
        if(red)
        {
            if (yellow)
            {
                if (green)
                {
                    if (blue)
                    { 
                      if (movingDoor.transform.position.y < 8)
                      {
                        movingDoor.transform.Translate(0f, 5f * Time.deltaTime, 0f);
                      }
                        
                    }
                }
                else if (blue)
                {
                    reset();
                }
            }
            else if (green || blue)
            {
                reset();
            }

        }
        else if( green || yellow || blue)
        {
            reset();
        }


    }
    
    private void reset()
    {
        red = false;
        green = false;
        yellow = false;
        blue = false;
    }



    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("RedLever"))
        {
            LeverPanel.SetActive(true);
            RedHere = true;
            if (red)
            {
                LeverPanel.SetActive(false);
            }

        }
        if (other.gameObject.CompareTag("GreenLever"))
        {
            LeverPanel.SetActive(true);
            GreenHere = true;
            if (green)
            {
                LeverPanel.SetActive(false);
            }
        }
        if (other.gameObject.CompareTag("YellowLever"))
        {
            LeverPanel.SetActive(true);
            YellowHere = true;
            if (yellow)
            {
                LeverPanel.SetActive(false);
            }
        }
        if (other.gameObject.CompareTag("BlueLever"))
        {
            LeverPanel.SetActive(true);
            BlueHere = true;
            if (blue)
            {
                LeverPanel.SetActive(false);
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("RedLever"))
        {
            LeverPanel.SetActive(false);
            RedHere = false;
        }
        if (other.gameObject.CompareTag("GreenLever"))
        {
            LeverPanel.SetActive(false);
            GreenHere = false;
        }
        if (other.gameObject.CompareTag("YellowLever"))
        {
            LeverPanel.SetActive(false);
            YellowHere = false;
        }
        if (other.gameObject.CompareTag("BlueLever"))
        {
            LeverPanel.SetActive(false);
            BlueHere = false;
        }
    }






    /*Ray ray;

    // Start is called before the first frame update
    void Start()
    {
        ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        CheckForColliders();
    }

    // Update is called once per frame
    void Update()
    {
        CheckForColliders();
    }

    void CheckForColliders()
    {
        if (Physics.Raycast(ray, out RaycastHit hitinfo))
        {
            if (hitinfo.transform.tag=="RedLever")
            {
                Debug.Log("Hit something!");
            }
        }
    }*/
}
