using UnityEngine;

public class Zooming : MonoBehaviour
{
    public Transform player1;
    public Transform player2;

    public Camera main;

    // Start is called before the first frame update
    void Start()
    {
        main = GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        var dist = Vector3.Distance(player1.position, player2.position);

        var camSize = dist / 5f;

        camSize = Mathf.Clamp(dist, 6, 12);

        main.orthographicSize = camSize;

        transform.position = (Vector3.Lerp(player1.position + transform.forward * -20, player2.position + transform.forward * -20, 0.5f));
    }
}
