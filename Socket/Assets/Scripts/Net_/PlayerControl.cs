using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class PlayerControl : NetworkBehaviour
{
    public static PlayerControl instance;
    List<Color> PlayerColor = new List<Color>() { Color.yellow, Color.blue, Color.black, Color.red, Color.green, Color.grey };

    RaycastHit HitInfo;
    bool IsJump = true;
    bool IsNormal = true;

    public bool IsAttack = true;
    public float NomalTime = 1.5f;
    public string MyName;
    public const int maxHp = 100;
    public int Hp;

    //[SyncVar(hook = "aCmdStart")]
    public int Group;


    public GameObject[] bodyPart;
    public GameObject[] playerCamera;

    public GameObject weapon;
    public GameObject rayBox;
    public Slider playerSlider;


    public static PlayerControl Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new PlayerControl();
            }
            return instance;
        }
    }


    void Awake()
    {
        instance = this;


    }
    void Start()
    {

        // Group = Random.Range(0, PlayerColor.Count);
        StartCoroutine(StartGame());

        //判断是否为本地
    }

    //  public override void OnStartLocalPlayer()   //只会在本地角色被创建时使用


    [Command]
    void CmdStart(int gp)
    {
        if (this.name != "Player(Clone)")
        {
            return;
        }
        Color RanColor = PlayerColor[gp];
        this.transform.name = gp.ToString();
        MyName = this.name;
        foreach (GameObject part in bodyPart)
        {
            part.GetComponent<MeshRenderer>().material.color = RanColor;
        }
    }

    [ClientRpc]
    void RpcStart(int gp)
    {

        if (this.name != "Player(Clone)")
        {
            return;
        }

        Color RanColor = PlayerColor[gp];
        this.transform.name = gp.ToString();
        MyName = this.name;
        foreach (GameObject part in bodyPart)
        {
            part.GetComponent<MeshRenderer>().material.color = RanColor;
        }
    }

    void Update()
    {
        if (!isLocalPlayer)  //判断是否为本地
        {
            foreach (GameObject camera0 in playerCamera)
            {
                camera0.SetActive(false);
            }

            return;
        }

        PlayerMove();
        CheckBarrier();
        PlayerAttack();
    }


    void PlayerMove()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        playerSlider.transform.forward = new Vector3(0, 0, 1);

        transform.Rotate(Vector3.up * h * 120 * Time.deltaTime);
        transform.Translate(Vector3.forward * v * 3 * Time.deltaTime);
        // transform.rotation = Quaternion.LookRotation(Vector3.forward, Vector3.up);
        if (Input.GetButtonDown("Jump"))
        {
            if (IsJump)
            {
                PlayerJump();
            }
        }

    }

    void CheckBarrier()
    {
        Ray myray = new Ray(rayBox.transform.position, rayBox.transform.forward);

        if (Physics.Raycast(myray, out HitInfo, 2.5f))
        {
            if (HitInfo.transform.name == transform.name)
            {
                IsAttack = false;
            }

            Debug.DrawLine(myray.origin, HitInfo.point, Color.red);

        }
        else IsAttack = true;
    }

    void PlayerAttack()
    {
        if (IsAttack)
        {
            if (Input.GetMouseButton(0))
            {
                this.GetComponent<Animator>().SetBool("Continue", true);

            }
            if (Input.GetMouseButtonDown(0))
            {
                if (IsNormal)
                {
                    StartCoroutine(NormalAttack(NomalTime));
                }

            }
            if (Input.GetMouseButtonUp(0))
            {
                this.GetComponent<Animator>().SetBool("Continue", false);

            }

        }
    }

    IEnumerator NormalAttack(float time)
    {
        this.GetComponent<Animator>().SetBool("Normal", true);
        IsNormal = false;
        yield return new WaitForSeconds(time);
        this.GetComponent<Animator>().SetBool("Normal", false);
        IsNormal = true;
    }

    IEnumerator PlayerJump()
    {
        IsJump = false;
        //transform.Translate(new Vector3(Input.GetAxis("Horizontal")*distance, 2, Input.GetAxis("Vertical")*distance));
        GetComponent<Rigidbody>().velocity += new Vector3(0, 5, 0);
        GetComponent<Rigidbody>().AddForce(Vector3.up * 2);
        yield return new WaitForSeconds(1.6f);
        IsJump = true;
    }

    IEnumerator StartGame()
    {
        yield return new WaitForSeconds(10);
        Group = Random.Range(0, PlayerColor.Count);
        // if (this.name == "Player(Clone)")
        {
            if (isServer)
            {

                RpcStart(Group);
            }
            else
                CmdStart(Group);

        }
    }

}
