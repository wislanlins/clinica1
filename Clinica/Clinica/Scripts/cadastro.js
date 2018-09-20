// 707.137.020-60
// 310.669.270-73

function procurarPorCpf(cpf, callback) {
    $.get("/Patient/Cadastro/" + cpf, callback);
}

function enviarDadosNovos(dados, callback) {
    $.ajax({
        type: "POST",
        url: "/Patient/Cadastro/" + dados["Cpf"],
        data: dados,
        success: callback,
        dataType: "json"
    });
}