﻿if (typeof Customizacao === "undefined") {
    Customizacao = {};
}
Customizacao.ViaCep =
{
    chamaAction: (executionContext) => {
        const formContext = typeof executionContext.getFormContext === "function" ? executionContext.getFormContext() : executionContext;
        const cep = formContext.getAttribute("address1_postalcode").getValue();
        Customizacao.ViaCep.notificacaoCampo(formContext, "address1_postalcode");

        if (Customizacao.ViaCep.validaCep(cep)) {
            Xrm.Utility.showProgressIndicator("Preenchendo campos, aguarde...");

            var parameters = {};
            parameters.Cep = cep;

            var req = new XMLHttpRequest();
            req.open("POST", Xrm.Utility.getGlobalContext().getClientUrl() + "/api/data/v9.2/new_ActionTestViaCep", true);
            req.setRequestHeader("OData-MaxVersion", "4.0");
            req.setRequestHeader("OData-Version", "4.0");
            req.setRequestHeader("Content-Type", "application/json; charset=utf-8");
            req.setRequestHeader("Accept", "application/json");
            req.onreadystatechange = function () {
                if (this.readyState === 4) {
                    req.onreadystatechange = null;
                    if (this.status === 200 || this.status === 204) {
                        var result = JSON.parse(this.response);
                        var dadosCep = JSON.parse(result["DadosCep"]);
                        console.log(dadosCep);
                        if ("erro" in dadosCep) {
                            Customizacao.ViaCep.notificacaoCampo(formContext, "address1_postalcode", "Cep inválido");
                            Xrm.Utility.closeProgressIndicator();
                        }
                        else {
                            Customizacao.ViaCep.preencheCamposEndereco(formContext, dadosCep);
                        }
                    } else {
                        console.log(this.responseText);
                        Xrm.Utility.closeProgressIndicator();
                    }
                }
            };
            req.send(JSON.stringify(parameters));
        }
        else {
            Customizacao.ViaCep.notificacaoCampo(formContext, "address1_postalcode", "Cep inválido");
        }
    },

    preencheCamposEndereco: (formContext, dadosCep) => {
        formContext.getAttribute("address1_city").setValue(dadosCep.localidade);
        formContext.getAttribute("address1_stateorprovince").setValue(dadosCep.uf);
        formContext.getAttribute("address1_country").setValue("Brasil");
        formContext.getAttribute("address1_line1").setValue(dadosCep.complemento);
        formContext.getAttribute("address1_line2").setValue(dadosCep.ddd);
        formContext.getAttribute("address1_line3").setValue(dadosCep.ibge);
        formContext.getAttribute("address1_city").setValue(dadosCep.localidade);
        Xrm.Utility.closeProgressIndicator();
    },

    validaCep: (cep) => {
        if (cep) {
            cep = cep.replace(/\D/g, '');
            const validacaoCEP = /^[0-9]{8}$/;
            if (cep && validacaoCEP.test(cep)) {
                return true;
            }
        }
        return false;
    },

    notificacaoCampo: (formContext, campo, mensagem = null) => {
        const id = "cepInvalido";

        if (mensagem !== null)
            formContext.getControl(campo).setNotification(mensagem, id);
        else
            formContext.getControl(campo).clearNotification(id);
    }
}
