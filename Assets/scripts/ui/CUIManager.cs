﻿using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public enum UI_PAGE
{
	PLAY_ROOM,
	POPUP_CHOICE_CARD,
	POPUP_GO_STOP,
	POPUP_ASK_SHAKING,
	POPUP_SHAKING_CARDS,
	POPUP_ASK_KOOKJIN,
	POPUP_GAME_RESULT
}

public class CUIManager : CSingletonMonobehaviour<CUIManager>
{
	Dictionary<UI_PAGE, GameObject> ui_objects;

	void Awake()
	{
		this.ui_objects = new Dictionary<UI_PAGE, GameObject>();
		this.ui_objects.Add(UI_PAGE.POPUP_CHOICE_CARD, transform.FindChild("popup_choice_card").gameObject);
		this.ui_objects.Add(UI_PAGE.POPUP_GO_STOP, transform.FindChild("popup_gostop").gameObject);
		this.ui_objects.Add(UI_PAGE.POPUP_ASK_SHAKING, transform.FindChild("popup_shaking").gameObject);
		this.ui_objects.Add(UI_PAGE.POPUP_SHAKING_CARDS, transform.FindChild("popup_shaking_cards").gameObject);
		this.ui_objects.Add(UI_PAGE.POPUP_ASK_KOOKJIN, transform.FindChild("popup_kookjin").gameObject);
		this.ui_objects.Add(UI_PAGE.POPUP_GAME_RESULT, transform.FindChild("popup_result").gameObject);
	}


	public GameObject get_uipage(UI_PAGE page)
	{
		return this.ui_objects[page];
	}


	public void show(UI_PAGE page)
	{
		this.ui_objects[page].SetActive(true);
	}


	public void hide(UI_PAGE page)
	{
		this.ui_objects[page].SetActive(false);
	}
}
