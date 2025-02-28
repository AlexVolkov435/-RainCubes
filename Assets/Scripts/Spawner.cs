using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private int _pollCount = 3;
    [SerializeField] private bool _autoExpand = false;
    [SerializeField] private Cube _cubePrefab;

    private PollMono<Cube> _poll;
    private Rigidbody _rb;

    private void OnEnable()
    {
        Cube.ObjectDisabled += CreateCube;
    }

    private void OnDisable()
    {
        Cube.ObjectDisabled -= CreateCube;
    }

    private void Awake()
    {
        _rb = _cubePrefab.GetComponent<Rigidbody>();
        _poll = new PollMono<Cube>(_cubePrefab, _pollCount, transform);
        _poll._autoExpand = _autoExpand;
    }

    private void Start()
    {
        CreateCube();
    }

    public void CreateCube()
    {
        var positon = new Vector3(transform.position.x + GenerateRandom(), transform.position.y + GenerateRandom(), transform.position.z + GenerateRandom());
        var cube = _poll.GetFreeElement();
        cube.transform.position = positon;

        SetSpeed();
    }

    private int GenerateRandom()
    {
        int startRandom = 2;
        int finishRandom = 6;

        return Random.Range(startRandom, finishRandom);
    }

    private void SetSpeed()
    {
        var speedCube = _rb.velocity;
        speedCube.y = 0.0f;
        _rb.velocity = speedCube;
    }
}
