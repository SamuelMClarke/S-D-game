using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevator : MonoBehaviour
{
    [Header("Vertical")]
    public float ymax;
    public float ymin;
    public float yspeed;

    private Rigidbody2D rb;
    private float yinitial;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        yinitial = rb.position.y;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void FixedUpdate()
    {
        rb.position = new Vector2(
              rb.position.x,
               yinitial + ((ymax - ymin) * Mathf.Sin(yspeed * Time.frameCount)));

    }
}
