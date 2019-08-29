using System;
using System.Collections.Generic;
using System.IO;

namespace Terraria
{
    public enum EventID
    {
        Key_Fn = 100,
    }

    public class EventCenter
    {
        public static EventCenter instance = new EventCenter();

        public static void FireEvent(EventID id, Entity ent)
        {

        }
        public static void FireKeyEvent(EventID id, int key)
        {
            try
            {
                String cmd = String.Format("OnKeyEvent({0})", key);
                Debug.Log("Key Press :" + cmd);
                Main.instance.L.DoString(cmd);
            }
            catch
            {
                Debug.Log("KeyEvent Error!");
            }
        }
    }
}
