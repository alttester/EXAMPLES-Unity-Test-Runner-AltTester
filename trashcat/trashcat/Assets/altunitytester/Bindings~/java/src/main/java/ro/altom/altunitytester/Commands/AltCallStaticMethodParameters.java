package ro.altom.altunitytester.Commands;

public class AltCallStaticMethodParameters{
    public static class Builder{
        private String typeName;
        private String methodName;
        private String parameters;
        private String typeOfParameters;
        private String assembly;
        public Builder(String typeName,String methodName,String parameters){
            this.typeName=typeName;
            this.methodName=methodName;
            this.parameters=parameters;
        }
        public Builder withAssembly(String assembly){
            this.assembly=assembly;
            return this;
        }
        public Builder withTypeOfParameters(String typeOfParameters){
            this.typeOfParameters=typeOfParameters;
            return this;
        }
        public AltCallStaticMethodParameters build(){
            AltCallStaticMethodParameters altCallStaticMethodParameters=new AltCallStaticMethodParameters();
            altCallStaticMethodParameters.assembly=this.assembly;
            altCallStaticMethodParameters.methodName=this.methodName;
            altCallStaticMethodParameters.parameters=this.parameters;
            altCallStaticMethodParameters.typeName=this.typeName;
            altCallStaticMethodParameters.typeOfParameters=this.typeOfParameters;
            return altCallStaticMethodParameters;
        }
    }

    private AltCallStaticMethodParameters() {
    }

    public String getTypeName() {
        return typeName;
    }

    public void setTypeName(String typeName) {
        this.typeName = typeName;
    }

    public String getMethodName() {
        return methodName;
    }

    public void setMethodName(String methodName) {
        this.methodName = methodName;
    }

    public String getParameters() {
        return parameters;
    }

    public void setParameters(String parameters) {
        this.parameters = parameters;
    }

    public String getTypeOfParameters() {
        return typeOfParameters;
    }

    public void setTypeOfParameters(String typeOfParameters) {
        this.typeOfParameters = typeOfParameters;
    }

    public String getAssembly() {
        return assembly;
    }

    public void setAssembly(String assembly) {
        this.assembly = assembly;
    }

    private String typeName;
    private String methodName;
    private String parameters;
    private String typeOfParameters;
    private String assembly;
}
