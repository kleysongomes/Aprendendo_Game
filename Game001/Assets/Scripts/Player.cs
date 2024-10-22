using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed;

    private Rigidbody2D rig;
    private Vector2 _direction;

    public Vector2 direction
    {
        get { return _direction; }
        set { _direction = value; }
    }

    private void Start()
    {
        rig = GetComponent<Rigidbody2D>();
    }

    //Aqui fica os inputs
    void Update()
    {
        _direction = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
    }

    //Aqui fica tudo sobre fisica e afins
    private void FixedUpdate()
    {
        rig.MovePosition(rig.position + _direction * speed * Time.fixedDeltaTime);
    }
}
