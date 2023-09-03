using UnityEngine;
using OneSignalSDK;

public class OneSignalController
{
    public void Initialized()
    {
        OneSignal.Default.Initialize("34f92bbf-8645-4d13-9352-6260e5848577");
    }
}
