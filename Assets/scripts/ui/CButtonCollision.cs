using UnityEngine;
using System.Collections;

public class CButtonCollision : MonoBehaviour {

	void Update()
	{
		if (Input.GetMouseButtonDown(0)) //마우스 커서를 입력했을때만
		{
			RaycastHit hit;
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition); //마우스위치의 스크린에서 ray발사

			if (Physics.Raycast(ray, out hit)) //ray를 발사하여 일직선으로 나가다 충돌하면 그정보를 hit 에입력
			{
				GameObject obj = hit.transform.gameObject;
				CUIButton button = obj.GetComponent<CUIButton>();
				if (button != null)
				{
					button.on_touch(); //버튼터치했다고 인식
				}
			}
		}
	}
}
