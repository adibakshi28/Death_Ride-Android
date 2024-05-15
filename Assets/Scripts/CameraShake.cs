using UnityEngine;
using System.Collections;

public class CameraShake: MonoBehaviour {

	public float shake_decay=0.002f,shake_intensity=0.3f;

	private bool shaked = false;

	Vector3 originPosition;
	Quaternion originRotation;

	void Start(){
		originPosition = transform.position;
		originRotation = transform.rotation;
	}
		
	public void Update(){
		if (shake_intensity > 0) {
			transform.position = originPosition + Random.insideUnitSphere * shake_intensity;
			transform.rotation = new Quaternion (
				originRotation.x + Random.Range (-shake_intensity, shake_intensity) * .2f,
				originRotation.y + Random.Range (-shake_intensity, shake_intensity) * .2f,
				originRotation.z + Random.Range (-shake_intensity, shake_intensity) * .2f,
				originRotation.w + Random.Range (-shake_intensity, shake_intensity) * .2f);
			shake_intensity -= shake_decay;
			shaked = true;
		} 
		else {
			transform.position = originPosition;
			transform.rotation = originRotation;
			if (shaked) {
				this.enabled = false;
			}
		}

	}

}
