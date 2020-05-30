using UnityEngine;

public class CharAnimController : MonoBehaviour
{
    private Animator _anim;
    private Rigidbody2D _body;
    void Start()
    {
        _anim = GetComponent<Animator>();
        _body = GetComponent<Rigidbody2D>();
        
    }

    void Update()
    {       
            _anim.SetFloat("speed", Mathf.Abs(_body.velocity.x));
            _anim.SetFloat("verticalVelocity", _body.velocity.y);
    
    }
}
