using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private float speed;

    [SerializeField]
    private float rSpeed;

    [SerializeField]
    private float currentSlot = 1;

    [SerializeField]
    GameObject leftLeg;
    [SerializeField]
    GameObject rightLeg;
    [SerializeField]
    GameObject leftArm;
    [SerializeField]
    GameObject rightArm;
    [SerializeField]
    GameObject limbPos1;
    [SerializeField]
    GameObject limbPos2;
    [SerializeField]
    GameObject limbPos3;
    [SerializeField]
    GameObject limbPos4;

    [SerializeField]
    GameObject leftLegVisual;
    [SerializeField]
    GameObject rightLegVisual;

    [SerializeField]
    Transform rightLegPos;
    [SerializeField]
    Transform leftLegPos;
    [SerializeField]
    Transform rightArmPos;

    bool limbAlreadyAttached = false;

    bool limbAlreadyDetached = false;

    bool armAttached = false;

    bool leftLegAttached = false;

    bool rightLegAttached = false;

    public bool canGrabFirstKey = false;

    public bool hasFirstKey = false;

    public bool cannotEnter = false;

    public bool canEnter = false;

    public Lever1 lever1;

    [SerializeField]
    GameObject lockedDoor2;

    // Start is called before the first frame update
    void Start()
    {
        rightLegPos.transform.position = rightLeg.transform.position;
        leftLegPos.transform.position = leftLeg.transform.position;
        rightArmPos.transform.position = rightArm.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        //character movement controller
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector2 movementDirection = new Vector2(horizontalInput, verticalInput);
        float inputMagnitude = Mathf.Clamp01(movementDirection.magnitude);
        movementDirection.Normalize();
        transform.Translate(movementDirection * speed * inputMagnitude * Time.deltaTime, Space.World);

        Vector2 direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, rSpeed * Time.deltaTime);

        if (limbAlreadyAttached == true)
        {
            currentSlot += 1;
            limbAlreadyAttached = false;
        }

        if (limbAlreadyDetached == true)
        {
            currentSlot -= 1;
            limbAlreadyDetached = false;
        }
        
        //altering speed of skeleton
        if (leftLegAttached == true || rightLegAttached == true)
        {
            speed = 2.5f;
        }

        if (leftLegAttached == true && rightLegAttached == true)
        {
            speed = 0f;
        }


        //attaching an arm
        if (Input.GetKeyDown(KeyCode.Q) && currentSlot == 1 && armAttached == false)
        {
            rightArm.transform.position = limbPos1.transform.position;
            limbAlreadyAttached = true;
            armAttached = true;
        }
        if (Input.GetKeyDown(KeyCode.Q) && currentSlot == 2 && armAttached == false)
        {
            rightArm.transform.position = limbPos2.transform.position;
            limbAlreadyAttached = true;
            armAttached = true;
        }
        if (Input.GetKeyDown(KeyCode.Q) && currentSlot == 3 && armAttached == false)
        {
            rightArm.transform.position = limbPos3.transform.position;
            limbAlreadyAttached = true;
            armAttached = true;
        }


        //attaching left leg
        if (Input.GetKeyDown(KeyCode.E) && currentSlot == 1 && leftLegAttached == false)
        {
            leftLeg.transform.position = limbPos1.transform.position;
            limbAlreadyAttached = true;
            leftLegAttached = true;
        }
        if (Input.GetKeyDown(KeyCode.E) && currentSlot == 2 && leftLegAttached == false)
        {
            leftLeg.transform.position = limbPos2.transform.position;
            limbAlreadyAttached = true;
            leftLegAttached = true;
        }
        if (Input.GetKeyDown(KeyCode.E) && currentSlot == 3 && leftLegAttached == false)
        {
            leftLeg.transform.position = limbPos3.transform.position;
            limbAlreadyAttached = true;
            leftLegAttached = true;
        }

        //attaching right leg
        if (Input.GetKeyDown(KeyCode.R) && currentSlot == 1 && rightLegAttached == false)
        {
            rightLeg.transform.position = limbPos1.transform.position;
            limbAlreadyAttached = true;
            rightLegAttached = true;
        }
        if (Input.GetKeyDown(KeyCode.R) && currentSlot == 2 && rightLegAttached == false)
        {
            rightLeg.transform.position = limbPos2.transform.position;
            limbAlreadyAttached = true;
            rightLegAttached = true;
        }
        if (Input.GetKeyDown(KeyCode.R) && currentSlot == 3 && rightLegAttached == false)
        {
            rightLeg.transform.position = limbPos3.transform.position;
            limbAlreadyAttached = true;
            rightLegAttached = true;
        }

        //removing limbs
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            rightLeg.transform.position = rightLegPos.transform.position;
            leftLeg.transform.position = leftLegPos.transform.position;
            rightArm.transform.position = rightArmPos.transform.position;

            rightLegAttached = false;
            armAttached = false;
            leftLegAttached = false;

            currentSlot = 1;

            speed = 5;
        }

        if (Input.GetKeyDown(KeyCode.Space) && canGrabFirstKey == true)
        {
            hasFirstKey = true;
            canGrabFirstKey = false;
        }

        if (Input.GetKeyDown(KeyCode.Space) && lever1.canBeSwitched == true)
        {
            lockedDoor2.SetActive(false);
            canEnter = true;
        }

        Debug.Log(canGrabFirstKey);

        if (leftLegAttached == true)
        {
            leftLegVisual.SetActive(false);
        }
        else 
        {
            leftLegVisual.SetActive(true);
        }

        if (rightLegAttached == true)
        {
            rightLegVisual.SetActive(false);
        }
        else 
        {
            rightLegVisual.SetActive(true);
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Key1")
        {
            canGrabFirstKey = true;
        }
        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Key1")
        {
            canGrabFirstKey = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Door" && hasFirstKey == false)
        {
            cannotEnter = true;
        }

        if (collision.gameObject.tag == "Door" && hasFirstKey == true)
        {
            canEnter = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Door" && hasFirstKey == false)
        {
            cannotEnter = false;
        }
    }
}
