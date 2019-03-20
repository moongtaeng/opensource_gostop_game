using UnityEngine;
using System.Collections;
using FreeNet;

public class CCardPicture : MonoBehaviour {

	public CCard card { get; private set; }
	//겹치는구간판단 카드 겹치는 구간 말고 화면상에 보여지는 모든 이미지
	public SpriteRenderer sprite_renderer { get; private set; }

	public byte slot { get; private set; }
	BoxCollider box_collider; //충돌이 일어날수 있도록 하기.


	void Awake()
	{
		this.sprite_renderer = gameObject.GetComponentInChildren<SpriteRenderer>();
		this.box_collider = gameObject.GetComponent<BoxCollider>();
	}


	public void set_slot_index(byte slot)
	{
		this.slot = slot;
	}


	public void update_card(CCard card, Sprite image)
	{
		this.card = card;
		this.sprite_renderer.sprite = image;
	}


	public void update_backcard(Sprite back_image)
	{
		this.card = null;
		update_image(back_image);
	}


	public void update_image(Sprite image)
	{
		this.sprite_renderer.sprite = image;
	}


	public bool is_same(byte number)
	{
		return this.card.number == number;
	}


	public bool is_same(byte number, PAE_TYPE pae_type, byte position)
	{
		return this.card.is_same(number, pae_type, position);
	}

	public void enable_collider(bool flag)
	{
		this.box_collider.enabled = flag;
	}


	public bool is_back_card()
	{
		return this.card == null;
	}
}
