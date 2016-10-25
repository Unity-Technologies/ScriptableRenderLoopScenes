#pragma strict

var updateInterval = 0.5;
private var lastInterval : double; // Last interval end time
private var frames = 0; // Frames over current interval

function Start() {
    lastInterval = Time.realtimeSinceStartup;
    frames = 0;
    Random.seed = 13;
}

function Update() {
    ++frames;
    var timeNow = Time.realtimeSinceStartup;
    if (timeNow > lastInterval + updateInterval)
    {
        var ms : float = (timeNow - lastInterval) / frames * 1000.0f;
        GetComponent.<GUIText>().text = ms.ToString("f2") + "ms, unity " + Application.unityVersion + ", gfx " + SystemInfo.graphicsDeviceVersion;
        frames = 0;
        lastInterval = timeNow;
    }
}