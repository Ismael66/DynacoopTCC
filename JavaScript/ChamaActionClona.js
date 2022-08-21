function clonabotao(executionContext) {
    var formContext = typeof executionContext.getFormContext === "function" ? executionContext.getFormContext() : executionContext;
    var idopportunidade = formContext.data.entity.getId().replace("{", "").replace("}", "");

    var execute_new_ActionClonaOportunidadee_Request = {
        // Parameters
        idoportunidade: idopportunidade, // Edm.String

        getMetadata: function () {
            return {
                boundParameter: null,
                parameterTypes: {
                    idoportunidade: { typeName: "Edm.String", structuralProperty: 1 }
                },
                operationType: 0, operationName: "new_ActionClonaOportunidadee"
            };
            console.log(execute_new_ActionClonaOportunidadee_Request);
        }
    };

    Xrm.WebApi.online.execute(execute_new_ActionClonaOportunidadee_Request).then(
        function success(response) {
            if (response.ok) {
                console.log("Success");
                var alertStrings = { confirmButtonLabel: "Ok", text: "Uma nova oportunidade foi originada a partir do registro atual", title: "Oportunidade clonada" };
                var alertOptions = { height: 120, width: 260 };
                Xrm.Navigation.openAlertDialog(alertStrings, alertOptions).then(
                    function (success) {
                        console.log("Alert dialog closed");
                    },
                    function (error) {
                        console.log(error.message);
                    }
                );
            }
            else {
                var alertStrings = { confirmButtonLabel: "Ok", text: "Erro ao clonar oportunidade", title: "Algo deu errado" };
                var alertOptions = { height: 120, width: 260 };
                Xrm.Navigation.openAlertDialog(alertStrings, alertOptions).then(
                    function (success) {
                        console.log("Alert dialog closed");
                    },
                    function (error) {
                        console.log(error.message);
                    }
                );
            }
        }
    ).catch(function (error) {
        console.log(error.message);
    });
}