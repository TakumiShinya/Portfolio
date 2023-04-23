using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockBreak : MonoBehaviour
{

    [SerializeField]
    private ScoreManager myScore;
    [SerializeField]
    private BlockManager myBlock;
    [SerializeField]
    private SoundManager mysound;
    [SerializeField]
    private float[] probs = new float[4];
    [SerializeField]
	[Tooltip("発生させるエフェクト(パーティクル)")]
	private ParticleSystem particle;

    [SerializeField]
    private int life;

    [SerializeField]
    private float moveSpeed;
    private Rigidbody rigidbody;
    private Transform myTrans;
    // Start is called before the first frame update
    void Start()
    {
        myScore = GameObject.Find("GameManager").GetComponent<ScoreManager>();
        myBlock = GameObject.Find("GameManager").GetComponent<BlockManager>();
        probs[0] = 0.30f;
        probs[1] = 0.40f;
        probs[2] = 0.30f;
        probs[3] = 0.30f;
        moveSpeed=0.03f;
        if(this.gameObject.tag=="Block")life=1;
        if(this.gameObject.tag=="MetalBlock")life=3;
        if(this.gameObject.tag=="BossBlock")life=25;
    }

    // Update is called once per frame
    void Update()
    {
        myTrans = this.transform;

        if(myBlock.isPressJump&&this.gameObject.tag != "BossBlock"){
            Vector3 pos =myTrans.position;
            pos.z-=moveSpeed;
            myTrans.position= pos;
        }

    }

    private void OnCollisionEnter(Collision other) {
        if(other.gameObject.tag=="Floor"){
            Debug.Log("消えた！");
            ScoreManager.score-=10;
            Destroy(this.gameObject);
        }
        if(other.gameObject.tag=="Ball"||other.gameObject.tag=="CopyBall"){
            life--;
            if(this.gameObject.tag=="BossBlock")ScoreManager.score+=100;
            if(life>0){
                SoundManager.PlayReflectSE();
            }
            if(life==0){
                switch(this.gameObject.tag){
                    case "Block":
                    SoundManager.PlayDestroySE();
                    break;
                    case "BossBlock":
                    SoundManager.PlayExploSE();
                    break;
                }
                ParticleSystem newParticle = Instantiate(particle);
			    // パーティクルの発生場所をこのスクリプトをアタッチしているGameObjectの場所にする。
                Vector3 v=this.transform.position;
			    newParticle.transform.position = new Vector3(v.x, 1, v.z);
			    // パーティクルを発生させる。
			    newParticle.Play();
			    // インスタンス化したパーティクルシステムのGameObjectを削除する。(任意)
			    // ※第一引数をnewParticleだけにするとコンポーネントしか削除されない。
			    Destroy(newParticle.gameObject, 2.0f);
                switch(myBlock.EncountCulc(probs)){
                case 0:
                GameObject bItem = GameObject.Find("BallItem");
                GameObject bCopy = Instantiate(bItem, new Vector3( v.x, 1, v.z), Quaternion.Euler(-90,0,0));
                rigidbody = bCopy.GetComponent<Rigidbody>();
                rigidbody.AddForce(transform.forward * 300);
                break;
                case 1:
                GameObject sItem = GameObject.Find("ScoreItem");
                GameObject sCopy = Instantiate(sItem, new Vector3( v.x, 1, v.z), Quaternion.Euler(-90,0,0));
                rigidbody = sCopy.GetComponent<Rigidbody>();
                rigidbody.AddForce(transform.forward * 300);
                break;
                case 2:
                GameObject barItem = GameObject.Find("BarItem");
                GameObject barCopy = Instantiate(barItem, new Vector3( v.x, 1, v.z), Quaternion.Euler(-90,0,0));
                rigidbody = barCopy.GetComponent<Rigidbody>();
                rigidbody.AddForce(transform.forward * 300);
                break;
                default:
                break;
                }
                if(this.gameObject.tag=="Block")ScoreManager.score+=100;
                if(this.gameObject.tag=="MetalBlock")ScoreManager.score+=300;
                if(this.gameObject.tag=="BossBlock")ScoreManager.score+=1000;
                Destroy(this.gameObject);
            }
        }
    }
}
