using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public MaxSpeed maxSpeedText;
    public static PlayerMovement Instance;

    [SerializeField] private float speed = 1000;

    [HideInInspector] public Vector2 move;
    [HideInInspector] public Rigidbody2D Rigidbody { get; private set; }
    [HideInInspector] public SpriteRenderer Curtain { get; private set; }

    [HideInInspector] public float lastVelocity;

    private LevelManager _levelManager;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        Rigidbody = GetComponent<Rigidbody2D>();
        _levelManager = GetComponent<LevelManager>();
    }

    private void FixedUpdate()
    {
        MovePlayer();
        Text();
    }

    private void Update()
    {
        CaptureInput();
    }

    private void MovePlayer()
    {
        Rigidbody.AddForce(move * speed * Time.deltaTime);
        Rigidbody.linearVelocity = Vector3.ClampMagnitude(Rigidbody.linearVelocity, 90);
        lastVelocity = Mathf.Abs(Rigidbody.linearVelocity.x);
    }

    private void Text()
    {
        if (lastVelocity >= 89f)
        {
            maxSpeedText.ShowSpeedText();
        }
        else
        {
            maxSpeedText.HideSpeedText();
        }
    }

    private void CaptureInput()
    {
        move = new Vector2(Input.GetAxisRaw("Horizontal"), 0);
    }
}
