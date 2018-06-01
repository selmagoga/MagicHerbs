using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//[RequireComponent(typeof(PlayerMotor))]
public class playerController : MonoBehaviour {
    public LayerMask movementMask;
    Camera cam;
    PlayerMotor motor;
    // Use this for initialization
    public Animation animation;
    public int attackDamage = 40;
    private float health = 100f;
    private bool alive = true;

    public Text sendOrderText;

    //health bar
    public Image healthBar;
    public Image entireHealthBar;


    void Start () {
        cam = Camera.main;
        motor = GetComponent<PlayerMotor>();
        animation = GetComponent<Animation>();
    }
     
    public float normalSpeed = 2f;
    public float fastSpeed = 4f;
    public int howFastLifeIncreases = 2;

    float lengthOfLerp = 0.00001f;
    // Update is called once per frame
    void LateUpdate()
    {
        //movement
        if (!RecipeeIngredients.gameEnded)
        {
            if (!alive && !animation.IsPlaying("death"))
            {
                RecipeeIngredients.gameEnded = true;
                sendOrderText.text = "YOU LOOSE!!";
                sendOrderText.enabled = true;
                Time.timeScale = 0;

            }
            if (animation.IsPlaying("death"))
            {
                alive = false;

            }
            else {
                if (alive)
                {
                    if (health == 0)
                    {
                        animation.Play("death");
                    }

                    else {
                        float movingSpeed = normalSpeed;

                        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.Keypad0))//if (Input.GetMouseButtonDown(0))
                        {

                            if (Input.GetKey(KeyCode.Keypad0))
                            {
                                movingSpeed = fastSpeed;
                            }

                            var x = Input.GetAxis("Horizontal") * Time.deltaTime * 150.0f * movingSpeed;
                            var z = Input.GetAxis("Vertical") * Time.deltaTime * 3.0f * movingSpeed;

                            transform.Rotate(0, x, 0);
                            transform.Translate(0, 0, z);
                            //transform.Translate(liLR * Time.deltaTime* movingSpeed, 0f, liW * Time.deltaTime* movingSpeed);
                            animation.Play("walk");
                            //Ray ray = cam.ScreenPointToRay(Input.mousePosition);
                            //RaycastHit hit;

                            //if(Physics.Raycast(ray, out hit))
                            //{
                            //    //Debug.Log("Hello world");
                            //   // motor.MoveToPoint(hit.point);
                            //}
                        }
                        else
                        {
                            if (Input.GetMouseButtonDown(1))
                                animation.Play("skill");
                            else
                            {

                                if (Input.GetMouseButtonDown(0))
                                {
                                    if (!animation.IsPlaying("attack"))
                                    {
                                        animation.Play("attack");
                                        //attack inamic
                                        GameObject inamic = FindClosestEnemy();
                                        Debug.Log("e ok");
                                        Debug.Log(inamic);
                                        if (inamic != null)
                                        {

                                            Debug.Log("nu e ok");
                                            PredatorStateBehaviour phealth = inamic.GetComponent<PredatorStateBehaviour>();
                                            phealth.damageHealth(attackDamage);
                                        }

                                    }
                                }
                                else
                                {
                                    if (!animation.IsPlaying("attack") && !animation.IsPlaying("skill"))
                                    {
                                        animation.Play("free");
                                        if (health < 100)
                                        {

                                            healthBar.fillAmount = Mathf.Lerp(health / 100f, 1f, 0.3f * Time.deltaTime);

                                            health = healthBar.fillAmount * 100;
                                        }
                                    }

                                }
                            }
                        }
                    }
                }
            }
        }
    }
    public void damageHealth(int damage)
    {
      
        health -= damage;
        healthBar.fillAmount = (float)health / 100f; //make halth bar fill automatically
        if (health < 0)
            health = 0;
    }

    float distMinimaLovituraInamic = 8f;
    GameObject FindClosestEnemy(){
        // Find all game objects with tag Enemy
        GameObject[] gos;
        gos = GameObject.FindGameObjectsWithTag("Enemy");
        GameObject closest = null;
        double distance = Mathf.Infinity;
        Vector3 position = transform.position;
        Debug.Log("YO "+transform.position);
        Debug.Log(gos.GetLength(0));
        // Iterate through them and find the closest one

        foreach (GameObject go in gos)  {
            Debug.Log("EL " + go.transform.position);
            Vector3 diff = (go.transform.position - position);
            Debug.Log("DIFF "+ diff.sqrMagnitude);
            double curDistance = diff.sqrMagnitude;
            if (curDistance<distance && curDistance<=distMinimaLovituraInamic) {
                closest = go;
                distance = curDistance;
            }
        }
        return closest;    
    }

}

