using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BossEyeController : MonoBehaviour
{
    //Public Variables that can be changed.
    public int maxHealth = 300;
    public int health;
    public float roomWidth = 10f;
    public float roomHeight = 10f;
    public float moveSpeed = 1f;
    public float stageTransitionOne = 10f;
    public float stageTransitionTwo = 10f;
    public float stageTransitionThree = 10f;
    public float attackTransitionTime = 1f;
    public float rotateSpeed = 1f;
    public ProjectileSpawner gunFront;
    public ProjectileSpawner gunFrontLeft;
    public ProjectileSpawner gunFrontRight;
    public ProjectileSpawner gunLeft;
    public ProjectileSpawner gunRight;
    public ProjectileSpawner gunBack;
    public GameObject Nurse;
    
    //Stage and where the boss is in the room.
    private int currentStage = 0;
    private float xPosition;
    private float zPosition;
    //Assumes that boss is centered at start
    private float xArenaPosition;
    private float zArenaPosition;
    // Destination to head to using NavMeshAgent
    private Vector3 destination;
    private bool slidingLeft = false;
    private bool slidingRight = false;
    // Time elapsed in current stage
    private float timeElapsed = 0f;
    // The time for current stage
    private float timer = 0f;
    // the NavMeshAgent is for moving around the room.
    private NavMeshAgent nav;
    // Player's position for stages where boss is targeting player's position
    private Vector3 playerPos;
    // If the monster is moving then it wont change destination mid trip.
    private bool moving = false;
    // The player GameObject
    public GameObject player;
    // Script for starting the credit
    public CreditScript creditScript;
    public string userName = "DefaultUser";

    public Text txt;
    // At start will get all the nessesary componenets and make the appropriate calculations for movement.
    void Start()
    {
        health = maxHealth;
        xPosition = this.transform.position.x;
        zPosition = this.transform.position.z;
        xArenaPosition = roomHeight * 0.5f;
        zArenaPosition = roomWidth * 0.5f;
        currentStage = 0;
        nav = GetComponent<NavMeshAgent>();
        destination = this.transform.position;
        player = GameObject.FindGameObjectWithTag("Player");
        playerPos = player.transform.position;
        userName = userNameRememberer.FindObjectOfType<userNameRememberer>().userName;
    }

    void FixedUpdate()
    {
        // Auto setting the player object 
        player = GameObject.FindGameObjectWithTag("Player");
        playerPos = player.transform.position;
        timeElapsed += Time.deltaTime;
        // switches the timer based on which stage is currently selected
        switch (currentStage)
        {
            case 0:
                timer = stageTransitionOne;
                break;
            case 1:
                timer = stageTransitionTwo;
                break;
            case 2:
                timer = stageTransitionThree;
                break;
            default:
                Debug.Log("Not a valid stage");
                break;
        }
        // Change stages and resets timer if true
        if(timeElapsed > timer)
        {
            timeElapsed = 0;
            currentStage = UnityEngine.Random.Range(0, 3);
        }
        //Changes movement and attack patterns to current stage.
        Stage(currentStage);
        // Set destination to the what the stage tells it to.
        nav.SetDestination(destination);
        // Zero damage to check health is above 0
        takeDamage(0);
        
    }

    // Called for taking damage. Will check health and if 0 or less, will send completion data to firebase and kill the boss.
    public void takeDamage(int damage)
    {
        health = health - damage;
        if (health <= 0)
        {
            
            Save save = new Save();
            if(userName != "DefaultUser")
            {
                save.save("UserRecords\\" + userName, "{ \"lowSugarTime\" : \"" + player.GetComponent<PlayerController>().lowSugarTime.ToString() + "\"," +
                "\"highSugarTime\" : \"" + player.GetComponent<PlayerController>().highSugarTime.ToString() + "\"," +
                "\"insulinUsed\" : \"" + player.GetComponent<PlayerController>().insulinUsed.ToString() + "\"," +
                "\"Date\" : \"" + DateTime.Now.ToString() + "\"}");
            }
            Debug.Log("Eye Boss is dead");
            Instantiate(Nurse, new Vector3(playerPos.x + 5, 10, playerPos.z), Quaternion.identity);
            Color color = txt.color;
            color.a = 1.0f;
            txt.color = color;
            Destroy(gameObject);
        }
    }

    //Controls which stage is done.
    void Stage(int stageNo)
    {
        switch (stageNo)
        {
            //Center of room, spinning attack
            case 0:
                destination = new Vector3(xPosition, 1, zPosition);
                attackPattern(0);
                this.transform.Rotate(0, rotateSpeed * Time.deltaTime, 0);
                break;
            //Top wall sliding attack
            case 1:
                if(destination.x != xPosition + roomHeight * 0.5f){
                    destination = new Vector3(xPosition + roomHeight * 0.5f, 1, zPosition - roomWidth * 0.5f);
                }else if(slidingRight && !slidingLeft)
                {
                    destination = new Vector3(xPosition + roomHeight * 0.5f, 1, zPosition + roomWidth * 0.5f);
                }
                else if(slidingLeft && !slidingRight)
                {
                    destination = new Vector3(xPosition + roomHeight * 0.5f, 1, zPosition - roomWidth * 0.5f);
                } else
                {
                    Debug.Log("Sliding Fell through");
                    destination = new Vector3(xPosition + roomHeight * 0.5f, 1, zPosition - roomWidth * 0.5f);
                    slidingLeft = false;
                    slidingRight = true;
                }

                if(this.transform.position.x == destination.x)
                {
                    if(this.transform.position.z == destination.z)
                    {
                        slidingRight = !slidingRight;
                        slidingLeft = !slidingLeft;
                    }
                }
                this.transform.LookAt(playerPos);
                attackPattern(1);
                break;
            // Jumping between walls
            case 2:
                attackPattern(2);
                int wall = UnityEngine.Random.Range(0, 4);
                switch (wall)
                {
                    //North Wall
                    case 0:
                        if (!moving)
                        {
                            destination = new Vector3(xPosition + roomHeight * 0.5f, 1, zPosition);
                            moving = true;
                        } else if(this.transform.position.x == destination.x && this.transform.position.z == destination.z)
                        {
                            moving = false;
                        }  
                        break;
                    //East Wall
                    case 1:
                        if (!moving)
                        {
                            destination = new Vector3(xPosition, 1, zPosition + roomWidth * 0.5f);
                            moving = true;
                        }
                        else if (this.transform.position.x == destination.x && this.transform.position.z == destination.z)
                        {
                            moving = false;
                        }
                        break;
                    //South Wall
                    case 2:
                        if (!moving)
                        {
                            destination = new Vector3(xPosition - roomHeight * 0.5f, 1, zPosition);
                            moving = true;
                        } else if(this.transform.position.x == destination.x && this.transform.position.z == destination.z)
                        {
                            moving = false;
                        }  
                        break;
                    //West Wall
                    case 3:
                        if (!moving)
                        {
                            destination = new Vector3(xPosition, 1, zPosition - roomWidth * 0.5f);
                            moving = true;
                        }
                        else if (this.transform.position.x == destination.x && this.transform.position.z == destination.z)
                        {
                            moving = false;
                        }
                        break;
                    default:
                        Debug.Log("Not a valid Wall jump");
                        break;
                }
                break;
            default:
                Debug.Log("Not a valid stage");
                break;
        }
    }

    // Sets the attack pattern. Controls the projectile shooters, and their firerate.
    void attackPattern(int attackNo)
    {
        /**     Copy the following layout to change gun properties in each stage.
                gunFront.setAggro(true);
                gunFront.setFireRate(0.01f);
                gunFrontLeft.setAggro(true);
                gunFrontLeft.setFireRate(0.01f);
                gunFrontRight.setAggro(true);
                gunFrontRight.setFireRate(0.01f);
                gunLeft.setAggro(true);
                gunLeft.setFireRate(0.01f);
                gunRight.setAggro(true);
                gunRight.setFireRate(0.01f);
                gunBack.setAggro(true);
                gunBack.setFireRate(0.01f);
    */
        switch (attackNo)
        {
            // Spinning attack with + pattern
            case 0:
                gunFront.setAggro(true);
                gunFront.setFireRate(0.25f);
                gunFrontLeft.setAggro(false);
                gunFrontLeft.setFireRate(0.25f);
                gunFrontRight.setAggro(false);
                gunFrontRight.setFireRate(0.25f);
                gunLeft.setAggro(true);
                gunLeft.setFireRate(0.25f);
                gunRight.setAggro(true);
                gunRight.setFireRate(0.25f);
                gunBack.setAggro(true);
                gunBack.setFireRate(0.25f);
                break;
            // Wall attack with \|/ pattern
            case 1:
                gunFront.setAggro(true);
                gunFront.setFireRate(0.2f);
                gunFrontLeft.setAggro(true);
                gunFrontLeft.setFireRate(0.2f);
                gunFrontRight.setAggro(true);
                gunFrontRight.setFireRate(0.2f);
                gunLeft.setAggro(false);
                gunLeft.setFireRate(0.5f);
                gunRight.setAggro(false);
                gunRight.setFireRate(0.5f);
                gunBack.setAggro(false);
                gunBack.setFireRate(0.5f);
                break;
            // Jumping wall attack with -\|/-
            case 2:
                gunFront.setAggro(false);
                gunFront.setFireRate(0.5f);
                gunFrontLeft.setAggro(false);
                gunFrontLeft.setFireRate(0.5f);
                gunFrontRight.setAggro(false);
                gunFrontRight.setFireRate(0.5f);
                gunLeft.setAggro(true);
                gunLeft.setFireRate(0.2f);
                gunRight.setAggro(true);
                gunRight.setFireRate(0.2f);
                gunBack.setAggro(true);
                gunBack.setFireRate(0.2f);
                break;
            default:
                Debug.Log("Attack Pattern Error");
                break;

        }
    }
}
