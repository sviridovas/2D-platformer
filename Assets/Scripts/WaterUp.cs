using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterUp : MonoBehaviour
{
    [SerializeField] private float waterSpeed = 0.2f;
    
    void Update()
    {
        transform.Translate(new Vector2(0f, waterSpeed * Time.deltaTime));
    }
}
