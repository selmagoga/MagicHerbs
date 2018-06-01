using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlantPickupAndApperance : MonoBehaviour {
    public GameObject target;
    public GameObject Charactertarget;

    public GameObject quantityChanger;

    public string componentName;
    public float minDistBetweenPPandM = 1f; //min dist between character and object
    private bool plantWasPicked = false;
    Animation otherAnimator;
    // Use this for initialization
    void Start () {
        TextChanger.obiectLovit = "";
        otherAnimator = Charactertarget.GetComponent<Animation>();
    }

    void FixedUpdate()
    {
        if (!plantWasPicked)
        {
            Ray ray;
            RaycastHit hit;

            ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Vector3.Distance(target.transform.position, Charactertarget.transform.position) <= minDistBetweenPPandM)
            {
                //Do whatever to snap them together
                TextChanger.textDisplaying = true;
                TextChanger.obiectLovit = "Right Click Mouse to Collect " + componentName + " Plant!";
                if (otherAnimator.IsPlaying("skill"))
                {
                    plantWasPicked = true;
                    Debug.Log("PICKED!!!");
                    GetComponent<Renderer>().enabled = false;
                    target.SetActive(false);


                    QuantityChanger quan = quantityChanger.GetComponent<QuantityChanger>(); //quantity incrementer collection
                    quan.incrementQuantity();
                }
            }
            int minDist = 20;
            if (Physics.Raycast(ray, out hit, 20) && !plantWasPicked)
            {
                if (target.name == hit.collider.name)
                {
                    TextChanger.obiectLovit = componentName;
                    Debug.Log(TextChanger.obiectLovit);
                    TextChanger.textDisplaying = true;
                }

            }
        }
    }

        //// Update is called once per frame
        //void FixedUpdate()
        //{
        //    if (!plantWasPicked)
        //    {
        //        if (TextChanger.textDisplaying && TextChanger.masterObjectName == target.name)
        //        {
        //            if (!TextChanger.textDisplaying)
        //                TextChanger.obiectLovit = "";
        //            //when mouse hover, text with plant type appears	
        //            Ray ray;
        //            RaycastHit hit;

        //            ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        //            if (Vector3.Distance(target.transform.position, Charactertarget.transform.position) <= minDistBetweenPPandM)
        //            {
        //                //Do whatever to snap them together
        //                TextChanger.obiectLovit = "Right Click Mouse to Collect " + componentName + " Plant!";
        //                if (otherAnimator.IsPlaying("skill"))
        //                {
        //                    plantWasPicked = true;
        //                    TextChanger.obiectLovit = "";
        //                    Debug.Log("PICKED!!!");
        //                    GetComponent<Renderer>().enabled = false;
        //                    target.SetActive(false);
        //                }
        //            }
        //            if (Physics.Raycast(ray, out hit, 20))
        //            {
        //                if (target.name == hit.collider.name)
        //                {
        //                    TextChanger.obiectLovit = componentName;
        //                    Debug.Log(TextChanger.obiectLovit);
        //                    TextChanger.textDisplaying = true;
        //                }
        //                else
        //                {
        //                    TextChanger.obiectLovit = "";
        //                }

        //            }
        //            else
        //            {
        //                TextChanger.obiectLovit = "";
        //            }

        //        }
        //    }

        //}

    }
