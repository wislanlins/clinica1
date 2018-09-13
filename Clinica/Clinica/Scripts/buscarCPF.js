// 707.137.020-60
// 310.669.270-73

function procurarPorCpf(cpf, callback) {
    $.get("/Patient/Cadastro/" + cpf, callback);
}