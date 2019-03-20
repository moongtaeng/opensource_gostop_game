using System;
using System.Collections;
using System.Collections.Generic;

public class CCardManager
{
    public List<CCard> cards { get; private set; }

	public CCardManager()
	{
		this.cards = new List<CCard>();
	}


    public void make_all_cards()
    {
        // Generate cards.
        Queue<PAE_TYPE> total_pae_type = new Queue<PAE_TYPE>();
        // 1
        total_pae_type.Enqueue(PAE_TYPE.KWANG);
        total_pae_type.Enqueue(PAE_TYPE.TEE);
        total_pae_type.Enqueue(PAE_TYPE.PEE);
        total_pae_type.Enqueue(PAE_TYPE.PEE);

        // 2
        total_pae_type.Enqueue(PAE_TYPE.YEOL);
        total_pae_type.Enqueue(PAE_TYPE.TEE);
        total_pae_type.Enqueue(PAE_TYPE.PEE);
        total_pae_type.Enqueue(PAE_TYPE.PEE);

        // 3
        total_pae_type.Enqueue(PAE_TYPE.KWANG);
        total_pae_type.Enqueue(PAE_TYPE.TEE);
        total_pae_type.Enqueue(PAE_TYPE.PEE);
        total_pae_type.Enqueue(PAE_TYPE.PEE);

        // 4
        total_pae_type.Enqueue(PAE_TYPE.YEOL);
        total_pae_type.Enqueue(PAE_TYPE.TEE);
        total_pae_type.Enqueue(PAE_TYPE.PEE);
        total_pae_type.Enqueue(PAE_TYPE.PEE);

        // 5
        total_pae_type.Enqueue(PAE_TYPE.YEOL);
        total_pae_type.Enqueue(PAE_TYPE.TEE);
        total_pae_type.Enqueue(PAE_TYPE.PEE);
        total_pae_type.Enqueue(PAE_TYPE.PEE);

        // 6
        total_pae_type.Enqueue(PAE_TYPE.YEOL);
        total_pae_type.Enqueue(PAE_TYPE.TEE);
        total_pae_type.Enqueue(PAE_TYPE.PEE);
        total_pae_type.Enqueue(PAE_TYPE.PEE);

        // 7
        total_pae_type.Enqueue(PAE_TYPE.YEOL);
        total_pae_type.Enqueue(PAE_TYPE.TEE);
        total_pae_type.Enqueue(PAE_TYPE.PEE);
        total_pae_type.Enqueue(PAE_TYPE.PEE);

        // 8
        total_pae_type.Enqueue(PAE_TYPE.KWANG);
        total_pae_type.Enqueue(PAE_TYPE.YEOL);
        total_pae_type.Enqueue(PAE_TYPE.PEE);
        total_pae_type.Enqueue(PAE_TYPE.PEE);

        // 9
        total_pae_type.Enqueue(PAE_TYPE.YEOL);
        total_pae_type.Enqueue(PAE_TYPE.TEE);
        total_pae_type.Enqueue(PAE_TYPE.PEE);
        total_pae_type.Enqueue(PAE_TYPE.PEE);

        // 10
        total_pae_type.Enqueue(PAE_TYPE.YEOL);
        total_pae_type.Enqueue(PAE_TYPE.TEE);
        total_pae_type.Enqueue(PAE_TYPE.PEE);
        total_pae_type.Enqueue(PAE_TYPE.PEE);

        // 11
        total_pae_type.Enqueue(PAE_TYPE.KWANG);
        total_pae_type.Enqueue(PAE_TYPE.PEE);
        total_pae_type.Enqueue(PAE_TYPE.PEE);
        total_pae_type.Enqueue(PAE_TYPE.PEE);

        // 12
        total_pae_type.Enqueue(PAE_TYPE.KWANG);
        total_pae_type.Enqueue(PAE_TYPE.YEOL);
        total_pae_type.Enqueue(PAE_TYPE.TEE);
        total_pae_type.Enqueue(PAE_TYPE.PEE);

		this.cards.Clear();
        for (byte number = 0; number < 12; ++number)
        {
            for (byte pos = 0; pos < 4; ++pos)
            {
                this.cards.Add(new CCard(number, total_pae_type.Dequeue(), pos));
            }
        }
    }


    void set_allcard_status()
    {
        // 카드 속성 설정.
        // 고도리.
        apply_card_status(1, PAE_TYPE.YEOL, 0, CARD_STATUS.GODORI);
        apply_card_status(3, PAE_TYPE.YEOL, 0, CARD_STATUS.GODORI);
        apply_card_status(7, PAE_TYPE.YEOL, 1, CARD_STATUS.GODORI);

        // 청단, 홍단, 초단
        apply_card_status(5, PAE_TYPE.TEE, 1, CARD_STATUS.CHEONG_DAN);
        apply_card_status(8, PAE_TYPE.TEE, 1, CARD_STATUS.CHEONG_DAN);
        apply_card_status(9, PAE_TYPE.TEE, 1, CARD_STATUS.CHEONG_DAN);

        apply_card_status(0, PAE_TYPE.TEE, 1, CARD_STATUS.HONG_DAN);
        apply_card_status(1, PAE_TYPE.TEE, 1, CARD_STATUS.HONG_DAN);
        apply_card_status(2, PAE_TYPE.TEE, 1, CARD_STATUS.HONG_DAN);

        apply_card_status(3, PAE_TYPE.TEE, 1, CARD_STATUS.CHO_DAN);
        apply_card_status(4, PAE_TYPE.TEE, 1, CARD_STATUS.CHO_DAN);
        apply_card_status(6, PAE_TYPE.TEE, 1, CARD_STATUS.CHO_DAN);

        // 쌍피.
        apply_card_status(10, PAE_TYPE.PEE, 1, CARD_STATUS.TWO_PEE);
        apply_card_status(11, PAE_TYPE.PEE, 3, CARD_STATUS.TWO_PEE);

        // 국진.
        apply_card_status(8, PAE_TYPE.YEOL, 0, CARD_STATUS.KOOKJIN);
    }


    void apply_card_status(
        byte number, PAE_TYPE pae_type, byte position,
        CARD_STATUS status)
    {
        CCard card = find_card(number, pae_type, position);
        card.set_card_status(status);
    }


    public void shuffle()
    {
        CHelper.Shuffle<CCard>(this.cards);

		set_allcard_status();
    }


	public CCard find_card(byte number, PAE_TYPE pae_type, byte position)
	{
		return this.cards.Find(obj => obj.is_same(number, pae_type, position));
	}
    
    public void fill_to(Queue<CCard> target)
    {
        this.cards.ForEach(obj => target.Enqueue(obj));
    }
}
