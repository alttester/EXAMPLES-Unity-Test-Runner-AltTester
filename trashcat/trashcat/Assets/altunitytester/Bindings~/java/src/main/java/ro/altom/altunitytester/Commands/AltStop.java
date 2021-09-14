package ro.altom.altunitytester.Commands;

import ro.altom.altunitytester.AltBaseSettings;

import java.io.IOException;

public class AltStop extends AltBaseCommand {
    public AltStop(AltBaseSettings altBaseSettings) {
        super(altBaseSettings);
    }

    public void Execute() {
        logger.info("Closing connection with server.");
        SendCommand("closeConnection");
        try {
            altBaseSettings.in.close();
            altBaseSettings.out.close();
            altBaseSettings.socket.close();
        } catch (IOException e) {
            logger.error("Could not close the socket.", e);
        }
    }
}
