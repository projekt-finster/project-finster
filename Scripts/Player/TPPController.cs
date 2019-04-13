// SKRYPT ZROBIONY PRZEZ: tabulator

using UnityEngine;

public class TPPController : MonoBehaviour
{

    private const float Y_CLAMP_MIN_VALUE = 30f; // minimalny kąt nachylenia kamery
    private const float Y_CLAMP_MAX_VALUE = 80f; // maksymalny kąt nachylenia kamery

    private Camera playerCamera;
    /* Nie wiem jak rozwiążemy problem aktywnej kamery*/
    /* (do cutscenek czy na okazję zmiany postaci)    */
    /* więc na razie zostawiam ją na private.         */
    private Rigidbody rb;

    private Transform cameraLookAt; // obiekt na który patrzy kamera
    private Transform cameraTransform; // pozycja kamery
    private float currentCameraX = 0f;
    private float currentCameraY = 0f;
    private float moveX = 0f;
    private float moveY = 0f;

    private float distanceToPlayer = 2.0f; // w przyszłości będzie można go zmieniać przyciskiem lub scrollwheelem
    private float offsetYValue = 1.0f;

    // w przyszłości zastąpimy te zmienne statystykami
    private float movementSpeed = 15f;
    private float jumpForce = 150f;

    private void Start()
    {
        playerCamera = GetComponent<Camera>();
        cameraTransform = transform;
        cameraLookAt = GameObject.FindGameObjectWithTag("Player").transform; // skrypt wyszukuje obiekt z tagiem "Player", jest to placeholder do debugowania
        rb = cameraLookAt.GetComponent<Rigidbody>();
        Cursor.lockState = CursorLockMode.Locked; // tutaj zlockuje kursor, w przyszłości się to wywali
    }

    private void Update()
    {
        getInput(); // funkcja odpowiedzialna za zczytanie inputu od gracza
        movePlayer(); // funkcja odpowiedzialna za poruszanie się gracza
    }

    private void LateUpdate()
    {
        moveCamera(); // funkcja odpowiedzialna za rotację kamery
    }

    #region MOVEMENT_FUNCTIONS

    private void getInput()
    {
        currentCameraX += Input.GetAxisRaw("Mouse X");
        currentCameraY += Input.GetAxisRaw("Mouse Y");

        currentCameraY = Mathf.Clamp(currentCameraY, Y_CLAMP_MIN_VALUE, Y_CLAMP_MAX_VALUE);

        moveX = Input.GetAxisRaw("Horizontal");
        moveY = Input.GetAxisRaw("Vertical");
    }

    private void moveCamera()
    {
        Vector3 offset = new Vector3(0f, 0f, -distanceToPlayer);
        Vector3 offsetY = new Vector3(0f, offsetYValue, 0f);
        Quaternion rotation = Quaternion.Euler(currentCameraY, currentCameraX, 0f);
        cameraTransform.position = cameraLookAt.position + rotation * offset;
        cameraTransform.LookAt(cameraLookAt.position + offsetY);
        cameraLookAt.rotation = Quaternion.Euler(0f, currentCameraX, 0f);
    }

    private void movePlayer()
    {
        cameraLookAt.Translate(Vector3.forward * moveY * movementSpeed * Time.fixedDeltaTime);
        cameraLookAt.Translate(Vector3.right * moveX * movementSpeed * Time.fixedDeltaTime);
        if (Input.GetButtonDown("Jump") && !cameraLookAt.GetComponent<Statistics>().jumped) { Jump(); }
    }

    private void Jump()
    {
        rb.AddForce(0, jumpForce, 0);
        cameraLookAt.GetComponent<Statistics>().jumped = true;
    }

    #endregion
}
