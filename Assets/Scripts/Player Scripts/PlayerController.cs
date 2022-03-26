using UnityEngine;
using TMPro;

public class PlayerController : MonoBehaviour
{
    Rigidbody playerRb;
    Animator playerAnimator;
    //
    [SerializeField] float speed;
    [SerializeField] float horizontalSpeed;
    [SerializeField] float xRange;
    [SerializeField] TMP_Text startText;
    [SerializeField] TMP_Text levelText;
    //
    bool firstClick = false;

    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        playerAnimator = GetComponent<Animator>();
    }

    void Update()
    {
        if (!firstClick && !GameManager.Instance.isGamePlayable && Input.GetMouseButton(0))
            ClickToPlayGame();
        //
        ClampPlayerHorizontalPosition();
    }

    void FixedUpdate()
    {
        if (GameManager.Instance.isGamePlayable)
            MoveHorizontalAndForward();
        //
        if (!GameManager.Instance.isGamePlayable)
        {
            ResetRunAnimation();
            AudioManager.Instance.StopWalkingSound();
        }
    }

    private void ClickToPlayGame()
    {
        Destroy(levelText);
        Destroy(startText);
        GameManager.Instance.SetGamePlayable();
        AudioManager.Instance.PlayWalkingSound();
        StartCoroutine(TimeManager.Instance.CountDown());
        firstClick = true;
    }

    private void ClampPlayerHorizontalPosition()
    {
        if (transform.position.x < -xRange)
            transform.position = new Vector3(-xRange, transform.position.y, transform.position.z);
        //
        else if (transform.position.x > xRange)
            transform.position = new Vector3(xRange, transform.position.y, transform.position.z);
    }

    private void MoveHorizontalAndForward()
    {
        playerAnimator.SetBool("CanRun", true);
        float horizontalInput = Input.GetAxis("Horizontal");
        Vector3 forwardMove = Vector3.forward * speed * Time.deltaTime;
        Vector3 horizontalMove = Vector3.right * horizontalInput * horizontalSpeed * Time.deltaTime;
        playerRb.MovePosition(transform.position + forwardMove + horizontalMove);
    }

    private void ResetRunAnimation()
    {
        playerAnimator.SetBool("CanRun", false);   
    }


}
