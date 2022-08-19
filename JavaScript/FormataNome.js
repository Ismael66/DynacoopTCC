function formatarlabel(executionContext) {
    debugger
    var formContext = executionContext.getFormContext();
    var textovalor = formContext.getAttribute("name").getValue();
    if (textovalor != null) {
        var nomeformatado = formatar(textovalor);
        formContext.getAttribute("name").setValue(nomeformatado);
    }
}
function formatar(textovalor) {
    debugger
    return textovalor.toLowerCase()
        .split(' ')
        .map((word) => {
            return word[0].toUpperCase() + word.slice(1);
        }).join(' ')
}