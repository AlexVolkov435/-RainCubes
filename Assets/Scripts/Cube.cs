using System.Collections;
using UnityEngine;
using System;

public class Cube : MonoBehaviour
{
    [SerializeField] private Transform _checkPoint;

    private Color _defaultColor = Color.yellow;
    private int _countTouch = 0;
    private int _livetime;

    static public event Action ObjectDisabled;

    private void OnEnable()
    {
        GetComponent<MeshRenderer>().material.color = _defaultColor;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (Physics.Raycast(_checkPoint.position, Vector3.down, out RaycastHit hitInfo, 4) == false)
            return;
        if (hitInfo.transform.TryGetComponent(out Surface surface) == false)
            return;
        DetermineTypePlatform(surface);
    }

    private void DetermineTypePlatform(Surface surface)
    {
        int FirstTouch = 1;

        if (surface.Type == SurfaceType.Patform1)
        {
            _countTouch++;

            if (_countTouch == FirstTouch)
            {
                Set—olor(Color.red);
            }
        }

        if (surface.Type == SurfaceType.Patform2)
        {
            Debug.Log("Patform2");
            _countTouch = Reset—ounter();
            _countTouch++;

            if (_countTouch == FirstTouch)
            {
                Set—olor(Color.blue);
            }
        }

        if (surface.Type == SurfaceType.Patform3)
        {
            _countTouch = Reset—ounter();
            _countTouch++;

            if (_countTouch == FirstTouch)
            {
                Set—olor(Color.green);
            }
        }
    }

    private void Set—olor(Color color)
    {
        GetComponent<MeshRenderer>().material.color = color;
        StartCoroutine(nameof(LiveRoutine));
    }

    private int Reset—ounter()
    {
        return 0;
    }

    private IEnumerator LiveRoutine()
    {
        int startRandom = 2;
        int finishRandom = 6;

        _livetime = UnityEngine.Random.Range(startRandom, finishRandom);

        yield return new WaitForSeconds(_livetime);

        Deactivate();
    }

    private void Deactivate()
    {
        ObjectDisabled?.Invoke();
        gameObject.SetActive(false);
    }
}
