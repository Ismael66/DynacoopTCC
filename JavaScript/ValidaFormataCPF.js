function validacaoCpf(executionContext) {
    const formContext = typeof executionContext.getFormContext === "function" ? executionContext.getFormContext() : executionContext;
    const valorCpf = executionContext.getEventSource().getValue();
    const labelCpf = executionContext.getEventSource().getName();
    if (isCpfValido(valorCpf)) {
        formContext.getControl(labelCpf).clearNotification("error.cpf");
        formContext.getAttribute(labelCpf).setValue(valorCpf.replace(/(\d{3})(\d{3})(\d{3})(\d{2})/, "$1.$2.$3-$4"));
    }
    else {
        formContext.getControl(labelCpf).setNotification("CPF invalido!", "error.cpf");
    } 
}

function isCpfValido(campoCpf) {
    if (!campoCpf) { return false; }
    campoCpf = campoCpf.replace(/\D/g, "");
    if (!campoCpf || campoCpf.length != 11 ||
        campoCpf == "00000000000" ||
        campoCpf == "11111111111" ||
        campoCpf == "22222222222" ||
        campoCpf == "33333333333" ||
        campoCpf == "44444444444" ||
        campoCpf == "55555555555" ||
        campoCpf == "66666666666" ||
        campoCpf == "77777777777" ||
        campoCpf == "88888888888" ||
        campoCpf == "99999999999") {
        return false;
    }
    const cpf = [];
    for (let i = 0; i < campoCpf.length; i++) {
        cpf[i] = parseInt(campoCpf[i]);
    }
    if (resto(calculaDigitoCpf(10, cpf)) === cpf[9]
        && resto(calculaDigitoCpf(11, cpf)) === cpf[10]) {
        return true;
    }
    else {
        return false;
    }

}
function resto(soma) {
    const resto = soma % 11;
    if (resto >= 2) {
        return 11 - resto;
    }
    else {
        return 0;
    }
}

function calculaDigitoCpf(control, cpf) {
    let soma = 0;
    const maximo = control - 1;
    for (let i = 0; i < maximo; i++, control--) {
        soma += parseInt(cpf[i]) * control;
    }
    return soma;
}