// 707.137.020-60
// 310.669.270-73

function procurarPorCpf(cpf, callback) {
    $.get("/Patient/Cadastro/" + cpf, callback);
}

function enviarDadosNovos(dados, callback) {
    $.post("/Patient/Cadastro/" + dados["Cpf"]).done(callback).fail(function () {
        alert("Erro no servidor!");
    });
}