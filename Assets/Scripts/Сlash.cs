using UnityEngine;

public class Ñlash : MonoBehaviour
{
    private int _countCollisions = 0;
    private int _firstTouch = 1;

    private bool _isPlatform1 = false;
    private bool _isPlatform2 = false;
    private bool _isPlatform3 = false;

    private void OnCollisionEnter(Collision collision)
    {
        _countCollisions = 0;

        if (collision.gameObject.tag == "Platvorm1")
        {
            _isPlatform1 = true;
        }

        if (collision.gameObject.tag == "Platvorm2")
        {
            _isPlatform2 = true;
        }

        if (collision.gameObject.tag == "Platvorm3")
        {
            _isPlatform3 = true;
        }

        _countCollisions++;
    }

    private void FixedUpdate()
    {
        Change();
    }

    private void Change()
    {
        if (_countCollisions == _firstTouch && _isPlatform1)
        {
            GetComponent<Renderer>().material.color = Color.red;
            Kill();
            _isPlatform1 = false;
        }

        if (_countCollisions == _firstTouch && _isPlatform2)
        {
            GetComponent<Renderer>().material.color = Color.blue;
            Kill();
            _isPlatform2 = false;
        }

        if (_countCollisions == _firstTouch && _isPlatform3)
        {
            GetComponent<Renderer>().material.color = Color.green;
            Kill();
            _isPlatform3 = false;
        }
    }

    private void Kill()
    {
        int startValue = 2;
        int finishValue = 6;

        Destroy(gameObject, Random.Range(startValue, finishValue));
    }
}
