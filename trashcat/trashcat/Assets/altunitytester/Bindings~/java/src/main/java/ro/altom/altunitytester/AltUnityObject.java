package ro.altom.altunitytester;

import lombok.Getter;
import ro.altom.altunitytester.Commands.ObjectCommand.*;
import ro.altom.altunitytester.position.Vector2;
import ro.altom.altunitytester.position.Vector3;
import ro.altom.altunitytester.AltUnityDriver.By;
import ro.altom.altunitytester.Commands.FindObject.AltFindObjectsParameters;
import ro.altom.altunitytester.Commands.FindObject.AltFindObject;

@Getter
public class AltUnityObject {
    /**
     * Access to this variable will be removed in the future.
     *
     * As of version 1.3.0 use getter getName()
     */
    public String name;

    /**
     * Access to this variable will be removed in the future.
     *
     * As of version 1.3.0 use getter getId()
     */
    public int id;

    /**
     * Access to this variable will be removed in the future.
     *
     * As of version 1.3.0 use getter getX()
     */
    public int x;

    /**
     * Access to this variable will be removed in the future.
     *
     * As of version 1.3.0 use getter getY()
     */
    public int y;

    /**
     * Access to this variable will be removed in the future.
     *
     * As of version 1.3.0 use getter getZ()
     */
    public int z;
    /**
     * Access to this variable will be removed in the future.
     *
     * As of version 1.3.0 use getter getMobileY()
     */
    public int mobileY;

    /**
     * Access to this variable will be removed in the future.
     *
     * As of version 1.3.0 use getter getType()
     */
    public String type;

    /**
     * Access to this variable will be removed in the future.
     *
     * As of version 1.3.0 use getter isEnabled()
     */
    public boolean enabled;

    /**
     * Access to this variable will be removed in the future.
     *
     * As of version 1.3.0 use getter getWorldX()
     */
    public float worldX;

    /**
     * Access to this variable will be removed in the future.
     *
     * As of version 1.3.0 use getter getWorldY()
     */
    public float worldY;

    /**
     * Access to this variable will be removed in the future.
     *
     * As of version 1.3.0 use getter getWorldZ()
     */
    public float worldZ;

    /**
     * Access to this variable will be removed in the future.
     *
     * As of version 1.3.0 use getter getIdCamera()
     */
    public int idCamera;
    @Deprecated
    public int parentId;
    public int transformParentId;
    public int transformId;

    public AltBaseSettings getAltBaseSettings() {
        return altBaseSettings;
    }

    public void setAltBaseSettings(AltBaseSettings altBaseSettings) {
        this.altBaseSettings = altBaseSettings;
    }

    private transient AltBaseSettings altBaseSettings;

    public AltUnityObject(String name, int id, int x, int y, int z, int mobileY, String type, boolean enabled,
            float worldX, float worldY, float worldZ, int idCamera, int parentId, int transformId) {
        this.name = name;
        this.id = id;
        this.x = x;
        this.y = y;
        this.z = z;
        this.mobileY = mobileY;
        this.type = type;
        this.enabled = enabled;
        this.worldX = worldX;
        this.worldY = worldY;
        this.worldZ = worldZ;
        this.idCamera = idCamera;
        this.transformId = transformId;
        this.parentId = parentId;
        this.transformParentId = parentId;
    }

    public AltUnityObject(String name, int id, int x, int y, int z, int mobileY, String type, boolean enabled,
            float worldX, float worldY, float worldZ, int idCamera, int parentId, int transformParentId,
            int transformId) {
        this(name, id, x, y, z, mobileY, type, enabled, worldX, worldY, worldZ, idCamera, transformParentId,
                transformId);
        this.transformParentId = transformParentId;
    }

    public AltUnityObject getParent() {
        AltFindObjectsParameters altFindObjectsParameters = new AltFindObjectsParameters.Builder(By.PATH,
                "//*[@id=" + this.id + "]/..").build();
        return new AltFindObject(altBaseSettings, altFindObjectsParameters).Execute();
    }

    public Vector2 getScreenPosition() {
        return new Vector2(this.x, this.y);
    }

    public Vector3 getWorldPosition() {
        return new Vector3(this.worldX, this.worldY, this.worldZ);
    }

    public String getComponentProperty(AltGetComponentPropertyParameters altGetComponentPropertyParameters) {
        return new AltGetComponentProperty(altBaseSettings, this, altGetComponentPropertyParameters).Execute();
    }

    public String getComponentProperty(String assemblyName, String componentName, String propertyName) {
        AltGetComponentPropertyParameters altGetComponentPropertyParameters = new AltGetComponentPropertyParameters.Builder(
                componentName, propertyName).withAssembly(assemblyName).build();
        return getComponentProperty(altGetComponentPropertyParameters);
    }

    public String getComponentProperty(String componentName, String propertyName) {
        return getComponentProperty("", componentName, propertyName);
    }

    public String setComponentProperty(AltSetComponentPropertyParameters altSetComponentPropertyParameters) {
        return new AltSetComponentProperty(altBaseSettings, this, altSetComponentPropertyParameters).Execute();
    }

    public String setComponentProperty(String assemblyName, String componentName, String propertyName, String value) {
        AltSetComponentPropertyParameters altSetComponentPropertyParameters = new AltSetComponentPropertyParameters.Builder(
                componentName, propertyName, value).withAssembly(assemblyName).build();
        return setComponentProperty(altSetComponentPropertyParameters);
    }

    public String setComponentProperty(String componentName, String propertyName, String value) {
        return setComponentProperty("", componentName, propertyName, value);
    }

    public String callComponentMethod(AltCallComponentMethodParameters altCallComponentMethodParameters) {
        return new AltCallComponentMethod(altBaseSettings, this, altCallComponentMethodParameters).Execute();
    }

    public String callComponentMethod(String assemblyName, String componentName, String methodName, String parameters,
            String typeOfParameters) {
        AltCallComponentMethodParameters altCallComponentMethodParameters = new AltCallComponentMethodParameters.Builder(
                componentName, methodName, parameters).withTypeOfParameters(typeOfParameters).withAssembly(assemblyName)
                        .build();
        return callComponentMethod(altCallComponentMethodParameters);
    }

    public String callComponentMethod(String componentName, String methodName, String parameters) throws Exception {
        return callComponentMethod("", componentName, methodName, parameters, "");
    }

    public String getText() {
        return new AltGetText(altBaseSettings, this).Execute();
    }

    public AltUnityObject setText(String text) {
        return new AltSetText(altBaseSettings, this, text).Execute();
    }

    @Deprecated()
    public AltUnityObject clickEvent() {
        return sendActionAndEvaluateResult("clickEvent");
    }

    public AltUnityObject pointerUp() {
        return sendActionAndEvaluateResult("pointerUpFromObject");
    }

    public AltUnityObject pointerDown() {
        return sendActionAndEvaluateResult("pointerDownFromObject");
    }

    public AltUnityObject pointerEnter() {
        return sendActionAndEvaluateResult("pointerEnterObject");
    }

    public AltUnityObject pointerExit() {
        return sendActionAndEvaluateResult("pointerExitObject");
    }

    /**
     * Tap current object.
     * 
     * @return The clicked object
     */
    public AltUnityObject tap() {
        return sendActionAndEvaluateResult("tapObject", "1");
    }

    @Deprecated
    public AltUnityObject doubleTap() {
        return sendActionAndEvaluateResult("tapObject", "2");
    }

    /**
     * Tap current object
     * 
     * @param parameters Tap parameters
     * @return The tapped object
     */
    public AltUnityObject tap(AltTapClickElementParameters parameters) {
        return new AltTapElement(altBaseSettings, this, parameters).Execute();
    }

    /**
     * Click current object.
     * 
     * @param parameters Click parameters
     * @return The clicked object
     */
    public AltUnityObject click(AltTapClickElementParameters parameters) {
        return new AltClickElement(altBaseSettings, this, parameters).Execute();
    }

    private AltUnityObject sendActionAndEvaluateResult(String command, String... parameters) {
        return new AltSendActionAndEvaluateResult(altBaseSettings, this, command, parameters).Execute();
    }
}
