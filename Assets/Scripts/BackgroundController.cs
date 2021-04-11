using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class BackgroundController : MonoBehaviour
{
    private Transform _camera;
    // Start is called before the first frame update
    void Start()
    {
        _camera = GameObject.FindWithTag("MainCamera").transform;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    private void Move()
    {
        gameObject.transform.position = new Vector3(_camera.position.x,_camera.position.y,20f);
    }
}
