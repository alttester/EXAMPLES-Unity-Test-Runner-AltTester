package ro.altom.altunitytester.Commands.UnityCommand;

import ro.altom.altunitytester.AltBaseSettings;
import ro.altom.altunitytester.Commands.AltBaseCommand;

/**
 * Delete entire player pref of the game
 */
public class AltDeletePlayerPref extends AltBaseCommand {
    public AltDeletePlayerPref(AltBaseSettings altBaseSettings) {
        super(altBaseSettings);
    }

    public void Execute() {
        SendCommand("deletePlayerPref");
        String data = recvall();
        validateResponse("Ok", data);
    }
}
