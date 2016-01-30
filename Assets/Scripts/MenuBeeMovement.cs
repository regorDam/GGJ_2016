using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MenuBeeMovement : MonoBehaviour
{
    [Range(1, 4)]
    public int idPlayer = 1;

    [Range(1, 3)]
    public int type = 1;

    public float maxTiltY;
    public float rotSpeed;
    public float speed;

    void Update()
    {
        float inputx = Input.GetAxis("Horizontal" + idPlayer);
        float inputy = Input.GetAxis("Vertical" + idPlayer);
        Vector3 input = new Vector3(inputx, inputy, 0.0f);

        if (inputx != 0 || inputy != 0)
        {
            transform.position += input * speed * Time.deltaTime;

            //float tilt = Mathf.Clamp(Vector3.AngleBetween(transform.position, transform.position + new Vector3), -maxTiltY, maxTiltY);
            //transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
            transform.LookAt(transform.position + new Vector3(inputx, inputy, 0.0f) );
        }

        Debug.Log(transform.position + ", " + (transform.position + new Vector3(inputx, inputy, 0.0f) * 99.9f));
    }

    void OnCollisionEnter(Collision col)
    {
        GameObject other = col.gameObject;
        if (other.tag.Equals("MenuHoneyComb"))
        {
            SceneManager.LoadScene("Game");
        }
    }

    public int GetIdPlayer()
    {
        return idPlayer;
    }
}
