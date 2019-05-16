using UnityEngine;

public class PlayerController : MonoBehaviour {

    [SerializeField]
    float regularMoveSpeed = 4f;
    float moveSpeed;
    float lowSpeed;

    Vector3 forward, right;
    Vector3 lookPos;

    Animator anim;

    public Collider[] attackHitBoxes;
    public GameObject light;
    public GameObject gun;
    public int regularRangedDmg = 5;
    public int regularMeleeDmg = 5;
    int meleeDmg;
    int lowDmg;
    public int startHealth = 100;
    public int lowSugarLimit = 50;
    public int highSugarLimit = 150;
    public int lowSugarDeath = 0;
    public int highSugarDeath = 200;

    bool runningBool;
    int aim = 4;
    int check = 4;
    int health;

    // Use this for initialization
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
        if (Input.GetKeyUp(KeyCode.W) && !Input.GetKey(KeyCode.S) && !Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D))
        {
            runningBool = false;
            movementAnimation();
        }
        else if (!Input.GetKey(KeyCode.W) && Input.GetKeyUp(KeyCode.S) && !Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D))
        {
            runningBool = false;
            movementAnimation();
        }
        else if (!Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.S) && Input.GetKeyUp(KeyCode.A) && !Input.GetKey(KeyCode.D))
        {
            runningBool = false;
            movementAnimation();
        }
        else if (!Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.S) && !Input.GetKey(KeyCode.A) && Input.GetKeyUp(KeyCode.D))
        {
            runningBool = false;
            movementAnimation();
        }
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
        {
            Move();
            if (runningBool == false)
            {
                runningBool = true;
                movementAnimation();
            }
        }
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
            check = aim;
            aimAnimation(aim);
        }
        if (Input.GetMouseButtonUp(0))
        {
            aimAnimation(4);
        }
        checkHealth();
    }
    void Move()
    {
        Vector3 direction = new Vector3(Input.GetAxis("HorizontalKey"), 0, Input.GetAxis("VerticalKey"));
        Vector3 rightMovement = right * moveSpeed * Time.deltaTime * Input.GetAxis("HorizontalKey");
        Vector3 upMovement = forward * moveSpeed * Time.deltaTime * Input.GetAxis("VerticalKey");

        Vector3 heading = Vector3.Normalize(rightMovement + upMovement);

        transform.forward = heading;
        transform.position += rightMovement;
        transform.position += upMovement;
    }
    void checkHealth()
    {
        if (health > lowSugarLimit && health < highSugarLimit)
        {
            moveSpeed = regularMoveSpeed;
            meleeDmg = regularMeleeDmg;
        } else if (health < lowSugarLimit)
        {
            moveSpeed = lowSpeed;
            meleeDmg = regularMeleeDmg;
        } else if (health > highSugarLimit)
        {
            moveSpeed = regularMoveSpeed;
            meleeDmg = lowDmg;
        } else if (health > highSugarDeath)
        {
            gameOver();
        } else if (health < lowSugarDeath)
        {
            gameOver();
        }
    }

    void gameOver()
    {
        Debug.Log("Player has died");
    }

    public void takeDamage(int damage)
    {
        health = health + damage;
    }

    private void launchAttack(Collider col)
    {
        anim.SetTrigger("Attack");
        movementAnimation();
        var cols = Physics.OverlapBox(col.bounds.center, col.bounds.extents, col.transform.rotation, LayerMask.GetMask("HitBox"));
        foreach(Collider c in cols)
        {
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

    private void movementAnimation()
    {
        if (runningBool == true)
        {
            anim.SetTrigger("Run");
        } else
        {
            anim.SetTrigger("Idle");
        }
    }

    private void aimAnimation(int aimAngle)
    {
        if (runningBool == true)
        {
            if (aimAngle == 0)
            {
                anim.SetTrigger("Aim Right Run");
            }
            else if (aimAngle == 1)
            {
                anim.SetTrigger("Aim Backward Run");
            }
            else if (aimAngle == 2)
            {
                anim.SetTrigger("Aim Left Run");
            }
            else if (aimAngle == 3)
            {
                anim.SetTrigger("Aim Forward Run");
            }
            else if (aimAngle == 4)
            {
                movementAnimation();
            }
        }
        else
        {
            if (aimAngle == 0)
            {
                anim.SetTrigger("Aim Right");
            }
            else if (aimAngle == 1)
            {
                anim.SetTrigger("Aim Backward");
            }
            else if (aimAngle == 2)
            {
                anim.SetTrigger("Aim Left");
            }
            else if (aimAngle == 3)
            {
                anim.SetTrigger("Aim Forward");
            }
            else if (aimAngle == 4)
            {
                movementAnimation();
            }
        }
    }

}
