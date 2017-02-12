using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerController : MonoBehaviour
{

	public float speed;
	public Text countText;
	public Text winText;
    public GameObject pickup0, pickup1, pickup2, pickup3, pickup4, pickup5, pickup6;

	private Rigidbody rb;
	private int count;
    private int pickupAtivo;
    private ArrayList pickedup;
    private bool ganhou;

	void Start()
	{
		rb = GetComponent<Rigidbody>();
		count = 0;
        ganhou = false;
        winText.enabled = false;

        pickup0.SetActive(false);
        pickup1.SetActive(false);
        pickup2.SetActive(false);
        pickup3.SetActive(false);
        pickup4.SetActive(false);
        pickup5.SetActive(false);
        pickup6.SetActive(false);
        pickedup = new ArrayList();

        AtivarPickup();
    }

    void AtivarPickup()
    {
        int n;

        do
        {
            n = Random.Range(0, 7);
        } while (pickedup.Contains(n) && n == 7);

        switch (n)
        {
            case 0:
                pickup0.SetActive(true);
                pickupAtivo = 0;
                break;
            case 1:
                pickup1.SetActive(true);
                pickupAtivo = 1;
                break;
            case 2:
                pickup2.SetActive(true);
                pickupAtivo = 2;
                break;
            case 3:
                pickup3.SetActive(true);
                pickupAtivo = 3;
                break;
            case 4:
                pickup4.SetActive(true);
                pickupAtivo = 4;
                break;
            case 5:
                pickup5.SetActive(true);
                pickupAtivo = 5;
                break;
            case 6:
                pickup6.SetActive(true);
                pickupAtivo = 6;
                break;
        }
    }

	void FixedUpdate()
	{
		float moveHorizontal = Input.GetAxis("Horizontal");
		float moveVertical = Input.GetAxis("Vertical");

		Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        if (!ganhou)
		    rb.AddForce(movement * speed);
	}

    void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.CompareTag("Pick Up"))
		{
			other.gameObject.SetActive(false);
			count = count + 1;
            countText.text = "Itens encontrados: "+count.ToString();
            pickedup.Add(pickupAtivo);

            if (count >= 5) // Mudar para o valor de objetos que deve encontrar!
            {
                winText.enabled = true;
                ganhou = true;
            }
            else
            {
                AtivarPickup();
            }
		}
	}

}