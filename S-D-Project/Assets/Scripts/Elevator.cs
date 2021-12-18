using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevator : MonoBehaviour
{
    [Header("Vertical")]
    public float ymax;
    public float ymin;
    public float yspeed;

    [Header("Horizontal")]
    public float xmax;
    public float xmin;
    public float xspeed;

    private Rigidbody2D rb;
    private float yinitial;
    private float xinitial;
    private float xchange;
    private float ychange;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        yinitial = rb.transform.position.y;
        xinitial = rb.transform.position.x;
        ychange = ymax - ymin;
        xchange = xmax - xmin;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void FixedUpdate()
    {
        rb.position = new Vector2(
            xinitial + (xchange*(Mathf.Sin(xspeed * (Time.time - Mathf.Asin(xspeed)))) + xchange),
            yinitial + (ychange*(Mathf.Sin(yspeed * (Time.time - Mathf.Asin(yspeed)))) + ychange));
    }
}
