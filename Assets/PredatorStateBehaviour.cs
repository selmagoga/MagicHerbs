using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PredatorStateBehaviour : MonoBehaviour {
    public GameObject wizardTarget;
   
    public float minDist2Attack;
    public int attackDamage = 10;
    // Use this for initialization
    private int health = 100;
    private bool alive = true;
    string animationAttackName;
    string animationWalkkName;
    string animationDeathName;
    string animationIdleName;


    //health bar
    public Image healthBar;

    public Image entireHealthBar;

    public float  walkingSpeed = 0.1f;
    private Animation animation;
    void Start () {
        animation = GetComponent<Animation>();
        animationAttackName = "attack";
        animationWalkkName = "walk";
        animationIdleName = "free";
        animationDeathName = "death";
        foreach (AnimationState state in animation)
        {
            if (state.name == "attack01")
            {
                animationAttackName = "attack01";
            }
            if (state.name == "run")
            {
                animationWalkkName = "run";
            }
            if (state.name == "dead")
            {
                animationDeathName = "dead";
            }
            if (state.name == "idle01")
            {
                animationDeathName = "idle01";
            }
        }
    }

    
    public void damageHealth(int damage)
    {
        health -= damage;
        healthBar.fillAmount = (float)health / 100f;

        if (health < 0)
            health = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (animation.IsPlaying(animationDeathName))
        {
            alive = false;
            entireHealthBar.enabled = false;
            healthBar.enabled = false;
        }
        else {
            if (alive)
            {
                if (health <= 0)
                {
                 
                  animation.Play(animationDeathName);
                }
                else {
                    if (Vector3.Distance(wizardTarget.transform.position, this.transform.position) < minDist2Attack)
                    {

                        //rotate towards player
                        Vector3 targetDir = wizardTarget.transform.position - transform.position;
                        // The step size is equal to speed times frame time.
                        float step = 5f * Time.deltaTime;
                        Vector3 newDir = Vector3.RotateTowards(transform.forward, targetDir, step, 0.0f);
                        newDir[1] = 0f;
                        // Move our position a step closer to the target.
                        transform.rotation = Quaternion.LookRotation(newDir);

                        if ((Vector3.Distance(wizardTarget.transform.position, this.transform.position) < 2.5f))
                        {
                            Debug.Log(health);
                            if (animation.IsPlaying(animationAttackName))
                            {

                            }else
                            {
                                animation.Play(animationAttackName);
                                playerController phealth = GameObject.FindObjectOfType<playerController>();
                                phealth.damageHealth(attackDamage);
                            }
                        }
                        else {
                            if (Vector3.Distance(wizardTarget.transform.position, this.transform.position) < minDist2Attack / 1.5)
                            {
                               
                               animation.Play(animationWalkkName);
                               
                                transform.Translate(0, 0, walkingSpeed);
                            }
                        }
                    }
                    else
                    {
                        animation.Play(animationIdleName);
                    }
                }
            }
        }
    }
}
