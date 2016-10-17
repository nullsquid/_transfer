using UnityEngine;
using System.Collections;

public interface IReceiver {

    void Exit();

    void Connect(string ID);

    void Run(string programID);

    void Sleep();
}
