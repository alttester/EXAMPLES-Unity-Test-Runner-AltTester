package ro.altom.altunitytester.Commands.UnityCommand;

import ro.altom.altunitytester.AltBaseSettings;
import ro.altom.altunitytester.AltUnityDriver;
import ro.altom.altunitytester.Commands.AltBaseCommand;

/**
 * Delete from games player pref a key
 */
public class AltFloatGetKeyPlayerPref extends AltBaseCommand {
    /**
     * @param keyName Key to be deleted
     */
    private String keyName;

    public AltFloatGetKeyPlayerPref(AltBaseSettings altBaseSettings, String keyName) {
        super(altBaseSettings);
        this.keyName = keyName;
    }

    public float Execute() {
        SendCommand("getKeyPlayerPref", keyName, String.valueOf(AltUnityDriver.PlayerPrefsKeyType.FloatType));
        String data = recvall();
        return Float.parseFloat(data);
    }
}
