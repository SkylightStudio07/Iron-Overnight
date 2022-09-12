using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineRendererTest : MonoBehaviour
{
    private LineRenderer linerenderer;

    // Start is called before the first frame update
    void Start()
    {
        linerenderer = GetComponent<LineRenderer>();
        linerenderer.SetColors(Color.red, Color.yellow);
        linerenderer.SetWidth(0.1f, 0.1f);

        linerenderer.SetPosition(0, transform.position);
        linerenderer.SetPosition(1, transform.position + new Vector3(0, 5, 0));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
