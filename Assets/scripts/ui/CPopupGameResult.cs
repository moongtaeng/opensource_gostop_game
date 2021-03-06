﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using FreeNet;

public class CPopupGameResult : MonoBehaviour {

	Sprite win_sprite;
	Sprite lose_sprite;

	Image win_lose;
	Text score;
	Text money;
	Text double_val;
	Text final_score;

	void Awake()
	{
		this.win_sprite = Resources.Load<Sprite>("images/win");
		this.lose_sprite = Resources.Load<Sprite>("images/lose");

		transform.FindChild("bg").GetComponent<Button>().onClick.AddListener(this.on_touch);
		this.win_lose = transform.FindChild("title").GetComponent<Image>();
		this.score = transform.FindChild("score").GetComponent<Text>();
		this.money = transform.FindChild("money").GetComponent<Text>();
		this.double_val = transform.FindChild("double").GetComponent<Text>();
		this.final_score = transform.FindChild("final_score").GetComponent<Text>();
	}


	void on_touch()
	{
		CUIManager.Instance.hide(UI_PAGE.POPUP_GAME_RESULT);

		CPacket send = CPacket.create((short)PROTOCOL.READY_TO_START);
		CNetworkManager.Instance.send(send);
	}


	public void refresh(byte is_win,
		int money,
		int score,
		int double_val,
		int final_score)
	{
		if (is_win == 1)
		{
			this.win_lose.sprite = this.win_sprite;
		}
		else
		{
			this.win_lose.sprite = this.lose_sprite;
		}

		this.score.text = score.ToString();
		this.money.text = money.ToString();
		this.double_val.text = double_val.ToString();
		this.final_score.text = final_score.ToString();
	}
}
