using UnityEngine;
using System.Collections;

public class CDelayedDeactive : MonoBehaviour {


	public float delay;


	void OnEnable()
	{
		StopAllCoroutines();
		StartCoroutine(delayed_deactive());
	}


	IEnumerator delayed_deactive()
	{
		yield return new WaitForSeconds(this.delay);
		gameObject.SetActive(false);
	}
}
//시간의 연속적으로 이어주는효과
