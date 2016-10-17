using UnityEngine;
using System.Collections;

public class DeviceGetter : MonoBehaviour {

	public static IReceiver GetDevice()
    {
        return new Terminal();
    }
}
