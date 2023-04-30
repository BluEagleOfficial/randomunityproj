using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Wyperian : MonoBehaviour
{

    //look at gameobjects slowly
    public static bool isPlaying(Animator anim, string stateName, int animLayer)
    {
        if (anim.GetCurrentAnimatorStateInfo(animLayer).IsName(stateName) &&
        anim.GetCurrentAnimatorStateInfo(animLayer).normalizedTime < 1.0f)
            return true;
        else
            return false;
    }
    public static bool isPlayingTag(Animator anim, string stateName, int animLayer)
    {
        if (anim.GetCurrentAnimatorStateInfo(animLayer).IsTag(stateName) &&
        anim.GetCurrentAnimatorStateInfo(animLayer).normalizedTime < 1.0f)
            return true;
        else
            return false;
    }
    public static Quaternion lookAtSlowly(Transform t, Vector3 target, float speed)
    {
        Vector3 relativePos = target - t.position;
        Quaternion toRotation = Quaternion.LookRotation(relativePos);
        return Quaternion.Lerp(t.rotation, toRotation, speed * Time.deltaTime);
    }

    //character controller using transforms
    public static void CharacterController(Transform player, Transform Camera
        , float speedofplayer, float speedofcamera)
    {
        if (Input.GetKey(KeyCode.W))
        {
            player.position = new Vector3(player.position.x, player.position.y, player.localPosition.z + 0.05f);
        }
        float x = Input.GetAxis("Mouse X") * speedofcamera;
        float y = Input.GetAxis("Mouse Y") * speedofcamera;


        player.Rotate(0, x, 0);
        Camera.Rotate(y * -1, 0, 0);
    }
    public static void CharacterControllerRigidbody(Rigidbody player, Transform Camera
        , float speedofplayer, float speedofcamera)
    {
        float h = Input.GetAxis("Horizontal") * speedofplayer * 0.01f;
        float v = Input.GetAxis("Vertical") * speedofplayer * 0.01f;
        float x = Input.GetAxis("Mouse X") * speedofcamera;
        float y = Input.GetAxis("Mouse Y") * speedofcamera;
        player.AddRelativeForce(h, 0, v);
        if (player.velocity.magnitude > 10)
        {
            player.velocity = player.velocity.normalized * 10;
        }
        player.transform.Rotate(0, x, 0);
        Camera.Rotate(y * -1, 0, 0);
    }

    //add gravity to rigidbody
    public static void gravity(Rigidbody rb, float gravity)
    {
        rb.AddForce(Vector3.down * gravity * Time.deltaTime * 1000f);
    }

    //jump for rigidbody
    public static void jump(Rigidbody rb, float jumpforce)
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(Vector3.up * jumpforce);
        }

    }
    public static GameObject FindClosestEnemy(string tag, Transform transform)
    {
        GameObject[] gos;
        gos = GameObject.FindGameObjectsWithTag(tag);
        GameObject closest = null;
        float distance = Mathf.Infinity;
        Vector3 position = transform.position;
        foreach (GameObject go in gos)
        {
            Vector3 diff = go.transform.position - position;
            float curDistance = diff.sqrMagnitude;
            if (curDistance < distance)
            {
                //dont pick if its yourself
                if (go.transform != transform)
                {
                    closest = go;
                    distance = curDistance;
                }
            }
        }
        return closest;
    }
    public static bool IsNullOrDestroyed(System.Object obj)
    {
        if (object.ReferenceEquals(obj, null)) return true;
        if (obj is UnityEngine.Object) return (obj as UnityEngine.Object) == null;
        return false;
    }
}