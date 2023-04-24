using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartParticle : MonoBehaviour
{
    [SerializeField]
	[Tooltip("発生させるエフェクト(パーティクル)")]
	private ParticleSystem particle;

    [SerializeField]
	[Tooltip("キャラクターのアニメーション(アニメーター)")]
	private Animator anim;

    //効果音
    private AudioSource se;

    // Start is called before the first frame update
    void Start()
    {
        //変数の初期化
        anim=GetComponent<Animator>();
        AudioSource[] audioSources =GetComponents<AudioSource>();
        se = GetComponent<AudioSource>();
        se=audioSources[0];
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //接触判定の関数
    private void OnCollisionEnter(Collision other) {
        if(other.gameObject.tag=="Ball"){
            se.PlayOneShot(se.clip);
            ParticleSystem newParticle = Instantiate(particle);
			// パーティクルの発生場所をこのスクリプトをアタッチしているGameObjectの場所にする。
			newParticle.transform.position = this.transform.position;
			// パーティクルを発生させる。
			newParticle.Play();
			// インスタンス化したパーティクルシステムのGameObjectを削除する。(任意)
			// ※第一引数をnewParticleだけにするとコンポーネントしか削除されない。
			Destroy(newParticle.gameObject, 5.0f);
            anim.SetBool("is_Hit",true);
        }
    }
}
