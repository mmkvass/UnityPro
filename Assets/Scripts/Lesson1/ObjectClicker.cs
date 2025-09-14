using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

[RequireComponent(typeof(Camera))]
public class ObjectClicker : MonoBehaviour
{
    private Camera _camera;


    void Awake()
    {
        _camera = GetComponent<Camera>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = _camera.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out RaycastHit hitinfo))
            {
                if(hitinfo.collider.TryGetComponent(out IClickable clickable))
                {
                    clickable.OnClick();
                }
            }
        }
    }
}
