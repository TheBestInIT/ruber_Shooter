using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class playerControl : MonoBehaviour
{
    [SerializeField] float speed =10;
    private PlayerInput playerInput;
    private InputAction moveAction;
    private InputAction rotateAction;
    public GameObject controlledObject;
    public GameObject PlayerHead;
    public GameObject PlayerHeadX;

    #region MyRegion
    
    public float rotationSpeed = 5f;
    private float verticalRotation = 0f;
    private float verticalRotation2 = 0f;
    
    #endregion

    
    public Animator animator;
    private Vector3 lastPosition;
    public GameObject parentPos; 
    
    void Start()
    {
        playerInput = GetComponent<PlayerInput>();
        moveAction = playerInput.actions.FindAction("Move");
        rotateAction = playerInput.actions.FindAction("Screen Rotation");
        lastPosition = parentPos.transform.position;
        //animator = GetComponent<Animator>();

   
    }

    void Update()
    {
        PlayerMove();
        PlayerRotation();
        isMovePlayAnim();
    }

    #region MoveRotatinAnim
    
    void PlayerMove()
    {
        Vector2 direction = moveAction.ReadValue<Vector2>().normalized;
        controlledObject.transform.Translate(new Vector3(direction.x,0,direction.y) * speed * Time.deltaTime, Space.Self);
       //PlayerHead.transform.Translate(new Vector3(direction.x,0,direction.y) * speed * Time.deltaTime, Space.Self);
    }
    void PlayerRotation()
    {
        Vector2 rotate = rotateAction.ReadValue<Vector2>();  
        verticalRotation -= rotate.y * rotationSpeed;
        verticalRotation = Mathf.Clamp(verticalRotation, -80f, 80f);
        
       transform.localEulerAngles = new Vector3(verticalRotation, transform.localEulerAngles.y, 0f);
        
        PlayerHead.transform.localEulerAngles = new Vector3(verticalRotation, transform.localEulerAngles.y, 0f);

        
       
        controlledObject.transform.Rotate(Vector3.up, rotate.x * rotationSpeed);
        
        //loj
    }

    private void isMovePlayAnim()
    {
        Vector3 currentPosition = parentPos.transform.position;
        float moveDistance = Vector3.Distance(currentPosition, lastPosition);

        if (moveDistance > 0.01f) // Припустимо, що це відстань руху для активації анімації
        {
            animator.Play("Character");
        }
        else
        {
           animator.Play("CharacterStay");
        }

        lastPosition = currentPosition;
    }
    #endregion
}

