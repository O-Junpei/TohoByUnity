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
		if (Input.GetButton("Fire1"))
		{
			walkCheck = true;
			GetComponent<Rigidbody2D>().velocity =
				new Vector2(speed, GetComponent<Rigidbody2D>().velocity.y);
		}
		//マウスのクリックを離すと止まる
		else if (Input.GetButtonUp("Fire1") && walkCheck)
		{
			walkCheck = false;
			GetComponent<Rigidbody2D>().velocity = Vector2.zero;
		}
	}

	// テキスト表示
	void OnGUI()
	{
		// 説明テキスト
		GUI.TextField(new Rect(5, 5, 400, 40), "ゲーム画面上でマウスの左ボタンを押し続けてる間は歩く。ボタンを離すと止まる。");
		// リセットボタン
		if (GUI.Button(new Rect(5, 50, 110, 30), "リセットボタン"))
		{
			Application.LoadLevel(Application.loadedLevelName);
		}
	}
}
