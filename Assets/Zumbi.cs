using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zumbi : MonoBehaviour {

	public float velocidade = 0.35f;
	Rigidbody rb;
	Animator animator;
	bool vivo = true;

	GameObject jogador;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody>();
		animator = GetComponent<Animator>();

		jogador = GameObject.Find("Jogador");
	}
	
	// Update is called once per frame
	void Update () {
		if (vivo)
		{
			transform.LookAt(jogador.transform);
			transform.eulerAngles = new Vector3(
				0,
				transform.rotation.eulerAngles.y,
				0
			);

			rb.velocity = transform.forward * velocidade;
		}
	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("Projétil"))
		{
			animator.SetTrigger("Die");
			vivo = false;
		}
	}
}
