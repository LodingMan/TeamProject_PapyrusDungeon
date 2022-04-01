using UnityEngine;

public class PassageScript : MonoBehaviour
{
    public MeshRenderer renderer;
    public int passageNumber = 0;
    void Start()
    {
        renderer = GetComponent<MeshRenderer>();
    }



    public void InitPassageNumber(int num)
    {
        if (gameObject.tag == "Up")
        {
            passageNumber = num + 200;
        }
        else if (gameObject.tag == "Right")
        {
            passageNumber = num + 100;
        }

    }

}
