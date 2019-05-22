using UnityEngine;
using SimpleFirebaseUnity.MiniJSON;

public class PlayerController : MonoBehaviour {

    [SerializeField]
    float regularMoveSpeed = 4f;
    float moveSpeed;
    float lowSpeed;

    Vector3 forward, right;
    Vector3 lookPos;

    Animator anim;
    
    //This was created as an array to avoid any potential conflicts with futures abilities, even if we use only one.
    public Collider[] attackHitBoxes;

    public GameObject light;
    public GameObject gun;
    public Joystick joystick;

    //These are public variables for easy changing in the unity editor.
    public int regularRangedDmg = 5;
    public int regularMeleeDmg = 5;
    public int startHealth = 100;
    public int lowSugarLimit = 50;
    public int highSugarLimit = 150;
    public int lowSugarDeath = 0;
    public int highSugarDeath = 200;

    //These differ from the public variables in that the actual damage or speed passed may differ from the base.
    int meleeDmg;
    int lowDmg;

    //These are used to pass to the database for additional stats.
    public int insulinUsed = 0;
    public float lowSugarTime = 0f;
    public float highSugarTime = 0f;

    //Used throughout the code to be used across all methods. Very important for update methods.
    bool runningBool;
    bool aimBool;
    int aim = 4;
    int check = 4;
    public int health;


    // Used this for initialization.
    void Start () {
        forward = Camera.main.transform.forward;
        forward.y = 0;
        forward = Vector3.Normalize(forward);
        right = Quaternion.Euler(new Vector3(0, 90, 0)) * forward;
        anim = GetComponent<Animator>();
        health = startHealth;
        lowSpeed = regularMoveSpeed / 2;
        meleeDmg = regularMeleeDmg;
        lowDmg = regularMeleeDmg / 2;
        moveSpeed = regularMoveSpeed;
        gun.GetComponent<ProjectileSpawner>().setDamage(regularRangedDmg);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetMouseButtonDown(1))
        {
            launchAttack(attackHitBoxes[0]);
        }

#if UNITY_ANDROID
        
        if(joystick.Vertical.Equals(0) && joystick.Horizontal.Equals(0))
        {
            Debug.Log("Idle Triggered");
            runningBool = false;
            movementAnimation(aim);
        }

        if (!joystick.Vertical.Equals(0) && !joystick.Horizontal.Equals(0))
        {
            Move();
            gun.GetComponent<ProjectileSpawner>().Target();
            gun.GetComponent<ProjectileSpawner>().Shoot();
            if (runningBool == false)
            {
                runningBool = true;
                movementAnimation(aim);
            }
        }

        int i = 0;
        while (i < Input.touchCount)
        {
            Touch t = Input.GetTouch(i);
            if (t.phase == TouchPhase.Began)
            {
                if (t.position.x > Screen.width / 3)
                {
                    launchAttack(attackHitBoxes[0]);
                }
            }
            ++i;
        }

#elif UNITY_WEBGL || UNITY_STANDALONE_WIN

        // The 'not' operator is used to ensure the animation isn't played from the start over and over.
        if (Input.GetKeyUp(KeyCode.W) && !Input.GetKey(KeyCode.S) && !Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D))
        {
            runningBool = false;
            movementAnimation(aim);
        }
        else if (!Input.GetKey(KeyCode.W) && Input.GetKeyUp(KeyCode.S) && !Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D))
        {
            runningBool = false;
            movementAnimation(aim);
        }
        else if (!Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.S) && Input.GetKeyUp(KeyCode.A) && !Input.GetKey(KeyCode.D))
        {
            runningBool = false;
            movementAnimation(aim);
        }
        else if (!Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.S) && !Input.GetKey(KeyCode.A) && Input.GetKeyUp(KeyCode.D))
        {
            runningBool = false;
            movementAnimation(aim);
        }else if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
        {
            Move();
            if (runningBool == false)
            {
                runningBool = true;
                movementAnimation(aim);
            }
        }
        
#endif

        if (light.transform.localRotation.eulerAngles.y <= 135 && light.transform.localRotation.eulerAngles.y > 45)
        {
            aim = 0;
        } else if (light.transform.localRotation.eulerAngles.y <= 225 && light.transform.localRotation.eulerAngles.y > 135)
        {
            aim = 1;
        } else if (light.transform.localRotation.eulerAngles.y <= 315 && light.transform.localRotation.eulerAngles.y > 225)
        {
            aim = 2;
        } else if (light.transform.localRotation.eulerAngles.y <= 45 || light.transform.localRotation.eulerAngles.y > 315)
        {
            aim = 3;
        }
        if (Input.GetMouseButton(0) && check != aim)
        {
            aimBool = true;
            check = aim;
            movementAnimation(aim);
        }
        if (Input.GetMouseButtonUp(0))
        {
            aimBool = false;
            movementAnimation(aim);
            check = 4;
        }
        checkHealth();
    }

    // This method contains the actual transform movement.
    void Move()
    {
#if UNITY_ANDROID
        Vector3 direction = new Vector3(joystick.Horizontal, 0, joystick.Vertical);
        Vector3 rightMovement = right * moveSpeed * Time.deltaTime * joystick.Horizontal;
        Vector3 upMovement = forward * moveSpeed * Time.deltaTime * joystick.Vertical;
#elif UNITY_WEBGL || UNITY_STANDALONE_WIN
        // "HorizontalKey" and "VerticalKey" are defined in edit > Project Settings > input
        Vector3 direction = new Vector3(Input.GetAxis("HorizontalKey"), 0, Input.GetAxis("VerticalKey"));
        Vector3 rightMovement = right * moveSpeed * Time.deltaTime * Input.GetAxis("HorizontalKey");
        Vector3 upMovement = forward * moveSpeed * Time.deltaTime * Input.GetAxis("VerticalKey");
    #endif

        Vector3 heading = Vector3.Normalize(rightMovement + upMovement);

        transform.forward = heading;
        transform.position += rightMovement;
        transform.position += upMovement;
    }

    // This is called in the update to check the debuffs for damage ranges
    void checkHealth()
    {
        if (health > lowSugarLimit && health < highSugarLimit)
        {
            moveSpeed = regularMoveSpeed;
            meleeDmg = regularMeleeDmg;
        }
        else if (health < lowSugarLimit)
        {
            lowSugarTime += Time.deltaTime;
            moveSpeed = lowSpeed;
            meleeDmg = regularMeleeDmg;
        } else if (health > highSugarLimit)
        {
            highSugarTime += Time.deltaTime;
            moveSpeed = regularMoveSpeed;
            meleeDmg = lowDmg;
        }
    }

   // Passes damage to health
    public void takeDamage(int damage)
    {
        Debug.Log("Taking Damage");
        health = health + damage;
    }

    // Runs through all attacks and checks the collider for enemy colliders.
    public void launchAttack(Collider col)
    {
        anim.SetTrigger("Attack");
        movementAnimation(aim);
        var cols = Physics.OverlapBox(col.bounds.center, col.bounds.extents, col.transform.rotation, LayerMask.GetMask("HitBox"));
        foreach(Collider c in cols)
        {
            //Checks to ensure the player does not collide with their own collider.
            if (c.transform.parent.parent == transform)
            {
                continue;
            }
            int damage = 0;
            switch (col.name)
            {
                case "MeleeCollider":
                    damage = meleeDmg;
                    break;
                default:
                    Debug.Log("Collider Unknown");
                    break;
            }
            c.SendMessageUpwards("takeDamage",damage);
        }
    }

    private void movementAnimation(int aimAngle)
    {
        if (runningBool == true && aimBool == false)
        {
            anim.SetTrigger("Run");
        }
        else if (runningBool == false && aimBool == false)
        {
            anim.SetTrigger("Idle");
        }
        else if (runningBool == true && aimBool == true)
        {
            switch (aimAngle)
            {
                case 0:
                    anim.SetTrigger("Aim Right Run");
                    break;
                case 1:
                    anim.SetTrigger("Aim Backward Run");
                    break;
                case 2:
                    anim.SetTrigger("Aim Left Run");
                    break;
                case 3:
                    anim.SetTrigger("Aim Forward Run");
                    break;
            }
        }
        else if (runningBool == false && aimBool == true)
        {
            switch (aimAngle)
            {
                case 0:
                    anim.SetTrigger("Aim Right");
                    break;
                case 1:
                    anim.SetTrigger("Aim Backward");
                    break;
                case 2:
                    anim.SetTrigger("Aim Left");
                    break;
                case 3:
                    anim.SetTrigger("Aim Forward");
                    break;
            }
        }
    }

    // Uses the item sent to it from Item controller script. If the item is insulin then increment counter for completion data.
    public void useItem(ItemController item)
    {
        Debug.Log("using Item: " + item.getName());
        if(item.getName() == "insulin")
        {
            insulinUsed++;
        }
        health = health + item.GetComponent<ItemController>().healthChange;
    }

}
