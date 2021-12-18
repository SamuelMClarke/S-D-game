using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevator : MonoBehaviour
{
    [Header("Vertical")]
    public float ymax;
    public float ymin;
    public float yperiod;

    [Header("Horizontal")]
    public float xmax;
    public float xmin;
    public float xperiod;

    private Rigidbody2D rb;
    private float yinitial;
    private float xinitial;
    private float yamp;
    private float yshift;
    private float yperiodshift;
    private float xamp;
    private float xshift;
    private float xperiodshift;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        yinitial = rb.transform.position.y;
        xinitial = rb.transform.position.x;
        xamp = xmax - xmin;
        xshift = 0.5f * xamp;
        xperiodshift = Mathf.Acos(((2 * Mathf.PI) % (2 * Mathf.PI)) / xperiod);
        yamp = ymax - ymin;
        yshift = 0.5f * yamp;
        yperiodshift = Mathf.Asin(((2 * Mathf.PI) % (2 * Mathf.PI)) / yperiod);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void FixedUpdate()
    {
        rb.position = new Vector2(
            xinitial + xamp * Mathf.Cos((2 * Mathf.PI / xperiod) * (Time.time - xperiodshift)) + xshift,
            yinitial + yamp * Mathf.Sin((2 * Mathf.PI / yperiod) * (Time.time - yperiodshift)) + yshift
            );
    }
}
