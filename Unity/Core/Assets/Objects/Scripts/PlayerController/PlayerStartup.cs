using UnityEngine;
using UnityEngine.UI;

public class PlayerStartup : MonoBehaviour
{

    [SerializeField]
    float regularMoveSpeed = 4f;
    float moveSpeed;

    float playerX;
    float playerY;
    float playerZ;

    public int startHealth = 100;
    public int lowSugarLimit = 50;
    public int highSugarLimit = 150;
    public int lowSugarDeath = 0;
    public int highSugarDeath = 200;

    public int health;

    Vector3 forward, right;
    Vector3 lookPos;

    Animator anim;

    public Joystick joystick;
    bool runningBool;
    bool cutscene = false;
    float timer = 0;
    public Image FadeImage;
    Color tmp;

    public Text text;
    // Use this for initialization
    void Start()
    {
        forward = Camera.main.transform.forward;
        forward.y = 0;
        forward = Vector3.Normalize(forward);
        right = Quaternion.Euler(new Vector3(0, 90, 0)) * forward;
        anim = GetComponent<Animator>();
        moveSpeed = regularMoveSpeed;
        playerX = transform.position.x;
        playerY = transform.position.y;
        playerZ = transform.position.z;
        health = startHealth;
        tmp = FadeImage.GetComponent<SpriteRenderer>().color;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (cutscene == false)
        {
            CutScene();
        }
        if (cutscene == true)
        {

#if UNITY_ANDROID
        if(joystick.Vertical.Equals(0) && joystick.Horizontal.Equals(0))
        {
            Debug.Log("Idle Triggered");
            runningBool = false;
            movementAnimation();
        }

        if (!joystick.Vertical.Equals(0) && !joystick.Horizontal.Equals(0))
        {
            Move();
            if (runningBool == false)
            {
                runningBool = true;
                movementAnimation();
            }
        }

#elif UNITY_WEBGL || UNITY_STANDALONE_WIN


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

#endif
        }
    }

    void Move()
    {
        if (cutscene == true)
        {
#if UNITY_ANDROID
        Vector3 direction = new Vector3(joystick.Horizontal, 0, joystick.Vertical);
        Vector3 rightMovement = right * moveSpeed * Time.deltaTime * joystick.Horizontal;
        Vector3 upMovement = forward * moveSpeed * Time.deltaTime * joystick.Vertical;
#elif UNITY_WEBGL || UNITY_STANDALONE_WIN
            Vector3 direction = new Vector3(Input.GetAxis("HorizontalKey"), 0, Input.GetAxis("VerticalKey"));
            Vector3 rightMovement = right * moveSpeed * Time.deltaTime * Input.GetAxis("HorizontalKey");
            Vector3 upMovement = forward * moveSpeed * Time.deltaTime * Input.GetAxis("VerticalKey");
#endif

            Vector3 heading = Vector3.Normalize(rightMovement + upMovement);

            transform.forward = heading;
            transform.position += rightMovement;
            transform.position += upMovement;
        }
    }

    private void movementAnimation()
    {
        if (runningBool == true)
        {
            anim.SetTrigger("Run");
        }
        else
        {
            anim.SetTrigger("Idle");
        }
    }

    private void CutScene()
    {
        timer = timer + 1 * Time.deltaTime;
        if (timer > 8 && timer < 16)
        {
            anim.SetTrigger("sitUp");

            if (timer > 14)
            {
                Color color = text.color;
                color.a = 1.0f;
                text.color = color;
            }
        }
        else if (timer > 18)
        {
            cutscene = true;
        }
    }
    
    public void useItem(GameObject item)
    {
        Debug.Log("using Item: " + item.name);
        health = health + item.GetComponent<ItemController>().healthChange;
    }

}
