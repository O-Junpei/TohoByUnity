using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {


	public float speed = 5.0f; //プレイヤーの速さ
	public Sprite[] walk; //プレイヤーの歩くスプライト配列
	int animIndex; //歩くアニメーションのインデックス
	bool walkCheck; //歩いているかのチェック


	// Use this for initialization
	void Start () {
		animIndex = 0;
		walkCheck = false;
	}
	
	// Update is called once per frame
	void Update () {
		//歩いていたら歩くアニメーションの再生
		if (walkCheck)
		{
			animIndex++;
			if (animIndex >= walk.Length)
			{
				animIndex = 0;
			}
			GetComponent<SpriteRenderer>().sprite = walk[animIndex];
		}


		//マウスをクリックしたら歩き出す
		// Up
		if (Input.GetKey("up"))
		{
			walkCheck = true;

			Vector2 v;
			v.x = 0;
			v.y = speed;

			//GetComponent<Rigidbody2D>().velocity = new Vector2(speed, GetComponent<Rigidbody2D>().velocity.x);
			GetComponent<Rigidbody2D>().velocity = v;

		}
		//マウスのクリックを離すと止まる
		else if (Input.GetKeyUp("up") && walkCheck)
		{
			walkCheck = false;
			GetComponent<Rigidbody2D>().velocity = Vector2.zero;
		}

		// Down
		else if (Input.GetKey("down"))
		{
			Vector2 v;
			v.x = 0;
			v.y = -speed;

			walkCheck = true;
			GetComponent<Rigidbody2D> ().velocity = v;


		}
		//マウスのクリックを離すと止まる
		else if (Input.GetKeyUp("down") && walkCheck)
		{
			walkCheck = false;
			GetComponent<Rigidbody2D>().velocity = Vector2.zero;
		}

		// Right
		else if (Input.GetKey("right"))
		{
			Vector2 v;
			v.x = speed;
			v.y = 0;

			walkCheck = true;
			GetComponent<Rigidbody2D> ().velocity = v;


		}
		//マウスのクリックを離すと止まる
		else if (Input.GetKeyUp("right") && walkCheck)
		{
			walkCheck = false;
			GetComponent<Rigidbody2D>().velocity = Vector2.zero;
		}

		// Left
		else if (Input.GetKey("left"))
		{
			Vector2 v;
			v.x = -speed;
			v.y = 0;

			walkCheck = true;
			GetComponent<Rigidbody2D> ().velocity = v;


		}
		//マウスのクリックを離すと止まる
		else if (Input.GetKeyUp("left") && walkCheck)
		{
			walkCheck = false;
			GetComponent<Rigidbody2D>().velocity = Vector2.zero;
		}

	}

	// テキスト表示
	void OnGUI()
	{
		// 説明テキスト
		GUI.TextField(new Rect(5, 5, 400, 40), "toho by Unity。");
		// リセットボタン
		if (GUI.Button(new Rect(5, 50, 110, 30), "リセットボタン"))
		{
			Application.LoadLevel(Application.loadedLevelName);
		}
	}
}
