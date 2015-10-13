using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class playerControllor : MonoBehaviour {

    public Text countText;
    public Text winText;
    public float speed;
    private Rigidbody rb;
    private int count;
	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
        count = 0;
        SetCountText();
        winText.text = "";
	} 
	
	// Update is called once per frame
	void Update () {
	
	}

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 moveMent = new Vector3(moveHorizontal, 0, moveVertical);

        rb.AddForce(moveMent*speed);
    }

    void OnTriggerEnter(Collider other)
    {
        // Destroy(other.gameObject);
        if (other.gameObject.CompareTag("PickUp"))
        {
            other.gameObject.SetActive(false);
            count++;
            SetCountText();
        }
    }

    void SetCountText()
    {
        countText.text = "Count : " + count.ToString();
        if (count >= 8)
        {
            winText.text = "You Win!";
        }
    }
}
