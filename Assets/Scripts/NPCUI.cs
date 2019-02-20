using UnityEngine;
using System.Collections;

public class NPCUI : MonoBehaviour
{
    public GUISkin guiSkin; // choose a guiStyle (Important!)
    public GameObject NPC; //choose the NPC name
    public string text = "HP: "; //default text
    protected HealthScript script;

    public Color color = Color.white;   // choose font color/size
    public int fontSize = 10;
    public float offsetX = 0;
    public float offsetY = 0.5f;

    float boxW = 150f;
    float boxH = 20f;

    public bool messagePermanent = true;

    public float messageDuration { get; set; }

    Vector2 boxPosition;
    void Start()
    {
        if (messagePermanent)
        {
            messageDuration = 1;
        }
    }
    void Update()
    {
        script = NPC.GetComponentInChildren<HealthScript>() as HealthScript;
        text = "HP: " + script.currentHealth;
        boxW = fontSize * 15;
        boxH = fontSize * 2;
    }
    void OnGUI()
    {
        if (messageDuration > 0)
        {
            if (!messagePermanent) // if you set this to false, you can simply use this script as a popup messenger, just set messageDuration to a value above 0
            {
                messageDuration -= Time.deltaTime;
            }

            GUI.skin = guiSkin;
            boxPosition = Camera.main.WorldToScreenPoint(transform.position + new Vector3(0, 0.5f, 0));
            Vector3 NPCPos = Camera.main.WorldToViewportPoint(transform.position);
            if (NPCPos.x >= 0 && NPCPos.x <= 1 && NPCPos.y >= 0 && NPCPos.y <= 1&& NPCPos.y >=0 && NPCPos.z>=0 )
            {
                boxPosition.y = Screen.height - boxPosition.y - 130;
                boxPosition.x -= boxW * 0.1f;

                guiSkin.box.fontSize = this.fontSize;

                GUI.contentColor = color;

                Vector2 content = guiSkin.box.CalcSize(new GUIContent(text));

                GUI.Box(new Rect(boxPosition.x, boxPosition.y, content.x, content.y), text);
            }
        }
    }
}