if (typeof (Tarefa) == "undefined") { Tarefa = {} }
if (typeof (Tarefa.Account) == "undefined") { Tarefa.Account = {} }

var formContext;

Tarefa.Account = {

    OnLoad: executionContext => {

        formContext = executionContext.getFormContext();

        let eIntegrado = formContext.getAttribute("log2_integracao").getValue();

        if (eIntegrado) {
            formContext.getControl("name").setDisabled(true);
            formContext.getControl("parentcontactid").setDisabled(true);
            formContext.getControl("parentaccountid").setDisabled(true);
            formContext.getControl("purchasetimeframe").setDisabled(true);
            formContext.getControl("transactioncurrencyid").setDisabled(true);
            formContext.getControl("budgetamount").setDisabled(true);
            formContext.getControl("purchaseprocess").setDisabled(true);
            formContext.getControl("msdyn_forecastcategory").setDisabled(true);
            formContext.getControl("description").setDisabled(true);
            formContext.getControl("currentsituation").setDisabled(true);
            formContext.getControl("customerneed").setDisabled(true);
            formContext.getControl("proposedsolution").setDisabled(true);
        }
        else {
            formContext.getControl("name").setDisabled(false);
            formContext.getControl("parentcontactid").setDisabled(false);
            formContext.getControl("parentaccountid").setDisabled(false);
            formContext.getControl("purchasetimeframe").setDisabled(false);
            formContext.getControl("transactioncurrencyid").setDisabled(false);
            formContext.getControl("budgetamount").setDisabled(false);
            formContext.getControl("purchaseprocess").setDisabled(false);
            formContext.getControl("msdyn_forecastcategory").setDisabled(false);
            formContext.getControl("description").setDisabled(false);
            formContext.getControl("currentsituation").setDisabled(false);
            formContext.getControl("customerneed").setDisabled(false);
            formContext.getControl("proposedsolution").setDisabled(false);
        }

    }
    
}