using UnityEngine;
using PixelCrushers.DialogueSystem;

public class CustomProximitySelector : ProximitySelector
{
    private string displayMessage = "";

    protected override void Update()
    {
        base.Update();

        displayMessage = "";

        if (currentUsable != null)
        {
            var targetSelector = currentUsable.GetComponent<ProximitySelector>();
            if (targetSelector != null)
            {
                displayMessage = targetSelector.defaultUseMessage;
            }
            else
            {
                displayMessage = defaultUseMessage;
            }
        }
    }

    public override void OnGUI()
    {
        if (!string.IsNullOrEmpty(displayMessage))
        {
            var screenPos = new Rect(Screen.width / 2 - 100, Screen.height - 100, 200, 30);
            GUIStyle style = new GUIStyle(GUI.skin.label)
            {
                alignment = TextAnchor.MiddleCenter,
                fontSize = 20,
                normal = { textColor = Color.yellow }
            };

            GUI.Label(screenPos, displayMessage, style);
        }
    }
}
