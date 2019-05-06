using UnityEngine;

public class PlayerController : MonoBehaviour {

    [SerializeField]
    float moveSpeed = 4f;

    Vector3 forward, right;
    Vector3 lookPos;

    public Collider[] attackHitBoxes;

	// Use this for initialization
	void Start () {
        forward = Camera.main.transform.forward;
        forward.y = 0;
        forward = Vector3.Normalize(forward);
        right = Quaternion.Euler(new Vector3(0, 90, 0)) * forward;
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.F))
        {
            launchAttack(attackHitBoxes[0]);
        }
        if (Input.GetMouseButtonDown(1))
        {
            launchAttack(attackHitBoxes[1]);
        }
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
        {
            Move();
        }

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        RaycastHit hit;

        if(Physics.Raycast(ray, out hit, 100))
        {
            lookPos = hit.point;
        }

        Vector3 lookDir = lookPos - transform.position;
        lookDir.y = 0;

        transform.LookAt(transform.position + lookDir, Vector3.up);
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

    private void launchAttack(Collider col)
    {
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
                    damage = 2;
                    break;
                case "LongCollider":
                    damage = 3;
                    break;
                default:
                    Debug.Log("Collider Unknown");
                    break;
            }
            c.SendMessageUpwards("takeDamage",damage);
        }
    }

}
