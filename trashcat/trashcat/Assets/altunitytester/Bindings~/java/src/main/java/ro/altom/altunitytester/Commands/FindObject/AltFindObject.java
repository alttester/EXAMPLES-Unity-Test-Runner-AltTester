package ro.altom.altunitytester.Commands.FindObject;

import ro.altom.altunitytester.AltBaseSettings;
import ro.altom.altunitytester.AltUnityDriver;
import ro.altom.altunitytester.AltUnityObject;

/**
 * Builder for finding the first object in the scene that respects the given
 * criteria. It's no longer possible to search for object by name giving a path
 * in the hierarchy. For searching by name, use searching by path.
 */
public class AltFindObject extends AltBaseFindObject {
    private AltFindObjectsParameters altFindObjectsParameters;

    /**
     * @param altFindObjectsParameters the properties parameter for finding the
     *                                 objects in a scene.
     */
    public AltFindObject(AltBaseSettings altBaseSettings, AltFindObjectsParameters altFindObjectsParameters) {
        super(altBaseSettings);
        this.altFindObjectsParameters = altFindObjectsParameters;
    }

    public AltUnityObject Execute() {
        if (altFindObjectsParameters.isEnabled() && altFindObjectsParameters.getBy() == AltUnityDriver.By.NAME) {
            String cameraPath = SetPath(altFindObjectsParameters.getCameraBy(),
                    altFindObjectsParameters.getCameraPath());
            SendCommand("findActiveObjectByName", altFindObjectsParameters.getValue(),
                    altFindObjectsParameters.getCameraBy().toString(), cameraPath,
                    String.valueOf(altFindObjectsParameters.isEnabled()));
        } else {
            String path = SetPath(altFindObjectsParameters.getBy(), altFindObjectsParameters.getValue());
            String cameraPath = SetPath(altFindObjectsParameters.getCameraBy(),
                    altFindObjectsParameters.getCameraPath());
            SendCommand("findObject", path, altFindObjectsParameters.getCameraBy().toString(), cameraPath,
                    String.valueOf(altFindObjectsParameters.isEnabled()));
        }
        return ReceiveAltUnityObject();
    }
}
