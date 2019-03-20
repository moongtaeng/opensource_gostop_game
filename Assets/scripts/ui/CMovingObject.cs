using UnityEngine;
using System.Collections;

public class CMovingObject : MonoBehaviour {

	public Vector3 begin;
	public Vector3 to;
	public float duration = 0.1f;

	SpriteRenderer sprite_renderer;

	void Awake()
	{
		this.sprite_renderer = gameObject.GetComponentInChildren<SpriteRenderer>();
	}


	public void run()
	{
		StopAllCoroutines();
		StartCoroutine(run_moving());
	}

    IEnumerator run_moving()
    {
        this.sprite_renderer.sortingOrder = CSpriteLayerOrderManager.Instance.Order;

        float begin_time = Time.time;
        while (Time.time - begin_time <= duration)
        {
            float t = (Time.time - begin_time) / duration;

            float x = easeInExpo(begin.x, to.x, t); //덱의 크기에 따라 뒤집 패의 사이즈 변경 시작값부터 끝값까지 정해진 시간동안 가속
            float y = easeInExpo(begin.y, to.y, t);
            transform.position = new Vector3(x, y, begin.z); //새로운 값

            yield return 0;
        }

        transform.position = to;
    }

    public static float easeInExpo(float start, float end, float value)
    {
        end -= start;
        return end * Mathf.Pow(2, 10 * (value - 1)) + start;
    }
}
