using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
  public Transform dummyTarget;

  private Vector3 defaultPosition;
  private Transform target;

    private void Start()
    {
        defaultPosition = transform.position;
        target = null;
    }

    private void Update()
    {
		// kita beri debug dulu dengan GetKey karena script ini masih tahap awal
		if (Input.GetKey(KeyCode.Space))
		{
			// tiap pencet spasi, langsung jalanin Coroutine Move Position untuk testing saja
			FocusAtTarget(dummyTarget);
	    }

        if (Input.GetKey(KeyCode.R))
	    {
		    GoBackToDefault();
	    }
    }

	// belum dipakai
    private void FocusAtTarget(Transform targetTransform)
    {
		// ubah target
		target = targetTransform;

		// disini perlu ditambahkan kalkulasi posisi kamera dari target
		// dan fungsi untuk menggerakan kameranya
        StartCoroutine(MovePosition(targetTransform.position, 5));
    }
	
	// belum dipakai
    public void GoBackToDefault()
    {
      target = null;

      // disini perlu ditambahkan fungsi untukmengggerakan ke posisi default
      StartCoroutine(MovePosition(dummyTarget.position, 5));
    }

    private IEnumerator MovePosition(Vector3 target, float time)
    {
      float timer = 0;
      Vector3 start = transform.position;

      while (timer < time)
        {
          // pindahkan posisi camera secara bertahap menggunakan Lerp
					// Lerp ini kita tambahkan smoothing menggunakan SmoothStep
          transform.position = Vector3.Lerp(start, target, Mathf.SmoothStep(0.0f, 1.0f, timer/time));
					
					// di lakukan berulang2 tiap frame selama parameter time
          timer += Time.deltaTime;
          yield return new WaitForEndOfFrame();
        }
			
			// kalau proses pergerakan sudah selesai, kamera langsung dipaksa pindah
			// ke posisi target tepatnya agar tidak bermasalah nantinya
        transform.position = target;
    }
}
