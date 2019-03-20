using UnityEngine;
using System.Collections;

public class CCardCollision : MonoBehaviour
{
	public delegate void TouchFunc(CCardPicture card_picture);
	public TouchFunc callback_on_touch = null;

	void Update()
	{
		if (Input.GetMouseButtonDown(0))
		{
			RaycastHit hit;
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

			if (Physics.Raycast(ray, out hit))
			{
				GameObject obj = hit.transform.gameObject;
				if (!obj.CompareTag("card"))
				{
					return;
				}

				CCardPicture card_picture = obj.GetComponent<CCardPicture>();
				if (card_picture == null)
				{
					return;
				}

				if (this.callback_on_touch != null)
				{
					this.callback_on_touch(card_picture);
				}

			}
		}
	}
}
