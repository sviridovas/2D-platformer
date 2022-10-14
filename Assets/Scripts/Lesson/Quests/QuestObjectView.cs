using System;
using UnityEngine;

public class QuestObjectView : MonoBehaviour
{
    [SerializeField] 
    private SpriteRenderer _spriteRenderer;
    
    [SerializeField] 
    private Color _completedColor;
    
    [SerializeField] 
    private int _id;

    public int Id => _id;
    
    private Color _defaultColor;

    public Action<Player> OnLevelObjectContact;

    private void OnTriggerEnter2D(Collider2D collider)
    {
        var levelObject = collider.gameObject.GetComponent<Player>();
        OnLevelObjectContact?.Invoke(levelObject);
    }
    
    private void Awake()
    {
        _defaultColor = _spriteRenderer.color;
    }

    public void ProcessComplete()
    {
        _spriteRenderer.color = _completedColor;
    }
  
    public void ProcessActivate()
    {
        _spriteRenderer.color = _defaultColor;
    }
}
