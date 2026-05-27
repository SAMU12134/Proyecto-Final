using UnityEngine;

public class CroucSistem : MonoBehaviour
{
    private bool activo;

    private CharacterController controller;
    private Vector3 originalCenter;
    private float originalHeight;

    public float crouchHeight = 1f;
    public float crouchCenterY = 0.4f;
    public float speed = 2f;

    private void Start()
    {
        controller = GetComponent<CharacterController>();
        originalCenter = controller.center;
        originalHeight = controller.height;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            activo = !activo;
            
        }

        if (activo)
        {
            
            controller.height = Mathf.Lerp(controller.height, crouchHeight, speed * Time.deltaTime);
            controller.center = Vector3.Lerp(controller.center, new Vector3(0, crouchCenterY, 0), speed * Time.deltaTime);
        }
        else
        {
            
            controller.height = Mathf.Lerp(controller.height, originalHeight, speed * Time.deltaTime);
            controller.center = Vector3.Lerp(controller.center, originalCenter, speed * Time.deltaTime);
        }


    }
    
}
