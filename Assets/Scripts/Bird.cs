using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Bird : MonoBehaviour
{
    private Vector3 _initPos;
    private bool _wasLaunched;
    private float _timeSittingAround;
    
    private void Awake()
    {
        _initPos = transform.position;
    }

    private void Update()
    {
        GetComponent<LineRenderer>().SetPosition(0, transform.position);
        GetComponent<LineRenderer>().SetPosition(1, _initPos);
        
        
        if (_wasLaunched 
            && GetComponent<Rigidbody2D>().velocity.magnitude <= 0.1f)
        {
            _timeSittingAround += Time.deltaTime;
        }
        if (transform.position.y > 5 
            || transform.position.x > 12
            || transform.position.x < -12
            || _timeSittingAround > 3)
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);

    }

    private void OnMouseDown()
    {
        GetComponent<SpriteRenderer>().color = Color.red;
        GetComponent<LineRenderer>().enabled = true;
    }

    private void OnMouseUp()
    {
        GetComponent<SpriteRenderer>().color = Color.white;

        Vector2 directionToInitPos = _initPos - transform.position;
        GetComponent<Rigidbody2D>().AddForce(directionToInitPos * 500);
        GetComponent<Rigidbody2D>().gravityScale = 1;

        _wasLaunched = true;
        GetComponent<LineRenderer>().enabled = false;

    }

    private void OnMouseDrag()
    {
        Vector3 newPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        // should be fine for 3d
        // transform.position = newPos;
        transform.position = new Vector3(newPos.x, newPos.y);
    }
}