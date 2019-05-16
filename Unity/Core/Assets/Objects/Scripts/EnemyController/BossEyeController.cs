using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

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
    //Private variables that can't be changed
    private int currentStage = 0;
    private float xPosition;
    private float zPosition;
    //Assumeing that the boss starts in the middle of the room
    private float xArenaPosition;
    private float zArenaPosition;
    private Vector3 destination;
    private bool slidingLeft = false;
    private bool slidingRight = false;
    private float timeElapsed = 0f;
    private float timer = 0f;
    private NavMeshAgent nav;
    private Vector3 playerPos;
    private bool moving = false;
    private GameObject player;


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
    }


    void FixedUpdate()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerPos = player.transform.position;
        timeElapsed += Time.deltaTime;
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
                Debug.Log("FuckyWucky in the TimeyWimey");
                break;
        }
        if(timeElapsed > timer)
        {
            timeElapsed = 0;
            currentStage = Random.Range(0, 3);
            Debug.Log("Changing stage to: " + currentStage);
        }
        Stage(currentStage);

        nav.SetDestination(destination);
        
    }

    public void takeDamage(int damage)
    {
        health = health - damage;
        if (health <= 0)
        {
            Debug.Log("Eye Boss is dead");
            Destroy(gameObject, 0);
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
            case 2:
                attackPattern(2);
                int wall = Random.Range(0, 4);
                Debug.Log("Going to wall: " + wall);
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
                        Debug.Log("UWU I MADE A CUMY WUMY ON THE WALLY UWU");
                        break;
                }
                break;
            default:
                Debug.Log("UHOH, I MADE A FUCKY WUCKY");
                break;
        }
    }

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
