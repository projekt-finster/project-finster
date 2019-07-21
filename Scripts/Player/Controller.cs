//SKRYPT ZROBIONY PRZEZ: tabulator
// w ramach jakichkolwiek pytań pisać na discordzie jestem praktycznie zawsze xd

using UnityEngine;

public class Controller : MonoBehaviour
{
    private bool doMove; // boolean odpowiedzialny za włączanie/wyłączenie możliwości ruchu postaci

    private const float Y_CLAMP_MIN_VALUE = 20f; // minimalny kąt nachylenia kamery
    private const float Y_CLAMP_MAX_VALUE = 80f; // maksymalny kąt nachylenia kamery

    private Rigidbody rb;
    public Transform cameraLookAt; // obiekt na który patrzy kamera
    private PlayerStatistics player; // odniesienie do statystyk gracza
    private Animator animator; // odniesienie do animatora (jeszcze nie używane)
    private Transform cameraTransform; // pozycja kamery

    // zmienne odpowiedzialne za zczytywanie inputu gracza
    private float currentCameraX = 0f;
    private float currentCameraY = 0f;
    private float moveX = 0f;
    private float moveY = 0f;

    // zmienne odpowiedzialne za offset kamery, pobierane przy void Update()
    private float distanceToPlayer; // dystans do gracza
    private float offsetYValue; // o ile wyżej ma być kamera od punktu odniesienia (pozycji gracza która znajduje się przy stopach)

    private void Awake()
    {
        doMove = true;
        cameraTransform = transform;
        player = cameraLookAt.GetComponent<PlayerStatistics>();
        rb = cameraLookAt.GetComponent<Rigidbody>();
        animator = cameraLookAt.GetComponentInChildren<Animator>();
        Cursor.lockState = CursorLockMode.Locked; // tutaj zlockuje kursor, w przyszłości się to wywali
    }

    #region UPDATE_FUNCTIONS

    private void Update()
    {
        getInput(); // funkcja odpowiedzialna za zczytanie inputu od gracza
        if (Input.GetButtonDown("Fire1")) { FindObjectOfType<GameManager>().playerInteraction(); } // to zostaw bez zmian logicznych bo jest potrzebne do interakcji
        distanceToPlayer = FindObjectOfType<GameManager>().offsetFromPlayer;
        offsetYValue = FindObjectOfType<GameManager>().offsetY;
    }

    private void FixedUpdate()
    {
        movePlayer(); // funkcja odpowiedzialna za poruszanie się gracza
    }

    private void LateUpdate()
    {
        moveCamera(); // funkcja odpowiedzialna za rotację kamery
    }

    #endregion

    #region MOVEMENT_FUNCTIONS

    private void getInput()
    {
        if (doMove)
        {
            currentCameraX += Input.GetAxisRaw("Mouse X");
            currentCameraY += Input.GetAxisRaw("Mouse Y");

            currentCameraY = Mathf.Clamp(currentCameraY, Y_CLAMP_MIN_VALUE, Y_CLAMP_MAX_VALUE);

            moveX = Input.GetAxisRaw("Horizontal");
            moveY = Input.GetAxisRaw("Vertical");

            if (Input.GetButtonDown("Jump") && !player.jumped && doMove == true) { jump(); }
        }
    }

    private void moveCamera() 
    {
        Vector3 offset = new Vector3(0f, 0f, -distanceToPlayer);
        Vector3 offsetY = new Vector3(0f, offsetYValue, 0f);
        Quaternion rotation = Quaternion.Euler(currentCameraY, currentCameraX, 0f);
        cameraTransform.position = cameraLookAt.position + rotation * offset;
        cameraTransform.LookAt(cameraLookAt.position + offsetY);
    }

    private void movePlayer() // zmienne takie jak szybkośc czy siła skoku są zbierane z GameManagera w którym jest do tego odpowiednia zmienna, identyczna dla każdego humanoida
    {
        Vector3 direction = ((cameraLookAt.transform.forward * moveY) + (cameraLookAt.transform.right * moveX));
        if (moveX != 0 || moveY != 0) { cameraLookAt.rotation = Quaternion.Euler(0f, currentCameraX, 0f); }
        rb.MovePosition(cameraLookAt.transform.position + (direction * player.movementSpeed * Time.fixedDeltaTime));
    }

    private void jump()
    {
        rb.AddForce(0, player.jumpForce, 0);
        player.jumped = true;
    }

    #endregion

    public void freezePlayer(bool freeze) // funkcja którą mogę wywołać gdzie tylko chcę żeby unieruchomić gracza (jeśli chcesz zmień na virtual)
    {
        if (freeze) { doMove = false; }
        else { doMove = true; }
    }

}
