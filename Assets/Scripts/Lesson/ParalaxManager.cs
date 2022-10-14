using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParalaxManager
{
    private const float _coef = .3f;
    private readonly Camera _camera;
    private readonly Transform _backTransform;

    private readonly Vector3 _cameraStartPosition;
    private readonly Vector3 _backStartPosition;

    public ParalaxManager(Camera camera, Transform backTransform) 
    {
        _camera = camera;
        _backTransform = backTransform;

        _cameraStartPosition = camera.transform.position;
        _backStartPosition = backTransform.position;
    }

    public void Update()
    {
        _backTransform.position = _backStartPosition + (_camera.transform.position - _cameraStartPosition) * _coef;
    }
}
