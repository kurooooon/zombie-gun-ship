using UnityEngine;
using System.Collections;

/// <summary>
/// Scene manager. シーンの切り替え用マネージャークラス
/// </summary>
public class SceneManager : BaseSingleton<SceneManager>
{
	private Texture2D _texture;
	private float _fadeAlpha = 0;
	private bool _isFading = false; 
	private Color _textureColor;
	
	/// <summary>
	/// Sets the color. トランジション時の色を指定
	/// </summary>
	/// <param name="color">Color.</param>
	public void setColor(Color color)
	{
		_textureColor = color;
		_textureColor.a = _fadeAlpha;
	}
	
	public void Awake ()
	{ 
		if (this != instance)
		{
			Destroy (this);
			return;
		}
		
		DontDestroyOnLoad (this.gameObject);
	}
	
	public void OnGUI ()
	{
		if (!this._isFading)
			return; 
		
		if (_texture == null)
		{
			//texture 
			_texture = new Texture2D (32, 32, TextureFormat.RGB24, false);
			_texture.ReadPixels (new Rect (0, 0, 32, 32), 0, 0, false);
			_texture.SetPixel (0, 0, Color.white);
			_texture.Apply ();
		}
		
		//透明度を更新して黒テクスチャを描画
		GUI.color = new Color (0, 0, 0, _fadeAlpha);
		GUI.DrawTexture (new Rect (0, 0, Screen.width, Screen.height),  _texture);
	}
	
	/// <summary>
	/// Changes the scene. トランジション後にシーンの切り替えを実行
	/// </summary>
	/// <param name="scene">Scene.</param>
	/// <param name="duration">Duration.</param>
	public void changeScene(string scene, float duration)
	{
		//		if (_texture != null)
		//		{
		//			Destroy(_texture);
		//			_texture = null;
		//		}
		//		drawTexture();
		
		if (_textureColor != null)
			GUI.color = _textureColor;
		
		//start tansition
		StartCoroutine (_changeScene (scene, duration));
	}
	
	private IEnumerator _changeScene (string scene, float duration)
	{
		//start fadeout
		this._isFading = true;
		float time = 0;
		while (time <= duration) 
		{
			_fadeAlpha = Mathf.Lerp (0f, 1f, time / duration);     
			time += Time.deltaTime;
			yield return 0;
		}
		
		//シーン切替
		Application.LoadLevel(scene);
		
		//start fadein 
		time = 0; 
		while (time <= duration)
		{
			_fadeAlpha = Mathf.Lerp (1f, 0f, time / duration);
			time += Time.deltaTime;
			yield return 0;
		}
		
		this._isFading = false;
	}
	
	private void drawTexture()
	{
		if (!this._isFading)
			return; 
		
		if (_texture == null)
		{
			//texture 
			_texture = new Texture2D (32, 32, TextureFormat.RGB24, false);
			_texture.ReadPixels (new Rect (0, 0, 32, 32), 0, 0, false);
			_texture.SetPixel (0, 0, Color.white);
			_texture.Apply ();
		}
		
		if (_textureColor == null)
			GUI.color = new Color(0, 0, 0, _fadeAlpha);
		else
			GUI.color = _textureColor;
		GUI.DrawTexture (new Rect(0, 0, Screen.width, Screen.height),  _texture);
	}
}