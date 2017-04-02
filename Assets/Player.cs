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

		//動く判定
		int isUp = 0;
		int isDown = 0;
		int isRight = 0;
		int isLeft = 0;

		if (Input.GetKey ("up")) {
			isUp = 1;
		}
		if (Input.GetKey ("down")) {
			isDown = 1;
		}
		if (Input.GetKey ("right")) {
			isRight = 1;
		}
		if (Input.GetKey ("left")) {
			isLeft = 1;
		}
		if (isUp == 1 || isDown == 1 || isRight == 1 || isLeft == 1) {
			walkCheck = true;
		} else {
			walkCheck = false;
		}
		moveChara (isUp,isDown,isRight,isLeft);

	}

	//受け取った値によってキャラを動かすかどうか
	void moveChara(int isUp,int isDown,int isRight,int isLeft){

		Vector2 v;
		v.y = speed * (isUp-isDown);
		//v.y = -speed * isDown;
		v.x = speed * (isRight-isLeft);
		//v.x = -speed * isLeft;

		GetComponent<Rigidbody2D> ().velocity = v;
	}

	/*

	// テキスト表示
	void OnGUI()
	{
		// 説明テキスト
		GUI.TextField(new Rect(5, 5, 400, 40), "toho by Unity。");
		// リセットボタン
		if (GUI.Button(new Rect(5, 50, 110, 30), "リセットボタン"))
		{
			//Application.LoadLevel(Application.loadedLevelName);
		}
	}*/
}
