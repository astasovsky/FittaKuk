using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private bool isLeft;
    [SerializeField] private GameObject playerMan;
    [SerializeField] private GameObject playerWoman;
    [SerializeField] private float leftLimit;
    [SerializeField] private float rightLimit;

    private const float Dumping = 1.5f;
    private const float OffsetX = 2f;
    private Transform _transform;
    private Transform _player;
    private int _lastX;

    public void SetGenderMale()
    {
        _player = playerMan.transform;
    }

    public void SetGenderFemale()
    {
        _player = playerWoman.transform;
    }

    public void HideCursor()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Awake()
    {
        _transform = transform;
    }

    private void Start()
    {
        _player = playerMan.transform;
        _lastX = Mathf.RoundToInt(_player.position.x);

        Vector3 position = _transform.position;
        float positionX = isLeft ? _player.position.x - OffsetX : _player.position.x + OffsetX;
        _transform.position = new Vector3(positionX, position.y, position.z);
    }

    private void Update()
    {
        Vector3 position;
        if (_player)
        {
            int currentX = Mathf.RoundToInt(_player.position.x);
            if (currentX > _lastX)
            {
                isLeft = false;
            }
            else if (currentX < _lastX)
            {
                isLeft = true;
            }

            _lastX = Mathf.RoundToInt(_player.position.x);
            float targetPositionX = isLeft ? _player.position.x - OffsetX : _player.position.x + OffsetX;
            position = _transform.position;
            Vector3 target = new Vector3(targetPositionX, position.y, position.z);
            Vector3 currentPosition = Vector3.Lerp(position, target, Dumping * Time.deltaTime);
            _transform.position = currentPosition;
        }

        position = _transform.position;
        _transform.position = new Vector3(Mathf.Clamp(position.x, leftLimit, rightLimit), position.y, position.z);
    }
}