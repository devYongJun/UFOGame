using UnityEngine;
using UnityEngine.UI;

public class RecordCell : MonoBehaviour
{
    public Image bg;
    public Text rankText;
    public Text idText;
    public Text scoreText;

    public void Init(string userId, int rank, int score, bool me)
    {
        idText.text = userId;
        rankText.text = rank.ToString();
        scoreText.text = score.ToString();

        bg.color = me ? Color.yellow : Color.white;
    }
}
