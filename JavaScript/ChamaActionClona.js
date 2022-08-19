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
			if (response.ok) { console.log("Success"); }
		}
	).catch(function (error) {
		console.log(error.message);
	});
}