using UnityEngine;
using System.Collections;

public class ObjSizeModifier : MonoBehaviour {

	public float maxHeight=300,minHeight=75,speed=5;

	private int direction = 1;

	void Update () {
			Vector3 temp= transform.localScale;
			temp.y = temp.y + (Time.deltaTime * direction * speed);
			transform.localScale = temp;

			if(transform.localScale.y >= maxHeight) {
				direction *= -1;
				temp = transform.localScale;
				temp.y = maxHeight;
				transform.localScale = temp;
			} 
			else if (transform.localScale.y <= minHeight){
				direction *= -1; 
				temp = transform.localScale;
				temp.y = minHeight;
				transform.localScale = temp;
			}
	}
}
