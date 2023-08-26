using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LauncherController : MonoBehaviour
{
	public Collider bola; // referensi ke bola
	public KeyCode input; // tombol input untuk aktivasi launch
	public float force; // besar gaya yang diberikan saat launch
	
	// hanya dapat membaca input saat bersentuhan dengan bola saja
	private void OnCollisionStay(Collision collision)
	{
		if (collision.collider == bola)
		{
			ReadInput(bola);
		}
	}
	
	// baca input
	private void ReadInput(Collider collider)
	{
		if (Input.GetKey(input))
		{
			// dorong bola ke atas dengan menggunakan gaya dorong dngn besaran tertentu
			collider.GetComponent<Rigidbody>().AddForce(Vector3.forward * force);
		}
	}
}
