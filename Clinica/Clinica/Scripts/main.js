$(document).ready(function () {
    $('.cep').mask('00000-000', { reverse: true });
    $('.cpf').mask('000.000.000-00', { reverse: true });
    $('.fixo').mask('(00) 0000-0000', { reverse: false });
    $('.celular').mask('(00) 00000-0000', { reverse: false });

    $("#form-submit").click(function () {        
        var inputCpf = $("input[name=cpf]");
        if (!validarCpf(inputCpf.val().replace(/\./g, "").replace("-", ""))) {
            alert("Digite o CPF corretamente");
            return;
        }
        if (!validarDataDeNascimento($("input[name=dtNascimento]").val())) {
            alert("Data inválida");
            return;
        }
        if (!validarAltura($("input[name=altura]").val())) { 
            alert("Altura inválida");
            return;
        }
        if (!validarPeso($("input[name=peso]").val())) {
            alert("Peso inválido");
            return;
        }
        
        var dados = coletarDadosDoFormulario();
        console.log(dados["Cpf"]);
        enviarDadosNovos(dados, function () {
            alert("Operação concluída!");
            window.location.reload();
        });
    });

    $("#cpfSearch").click(function () {
        var inputCpf = $("input[name=cpf]");
        var cpf = inputCpf.val().replace(/\./g, "").replace("-", "");
        if (validarCpf(cpf)) {
            procurarPorCpf(cpf, function (dados) {
                if (dados) {
                    preencherFormulario(dados);
                    aplicarMascaras();
                    $("#form-submit").html("Atualizar");
                } else {
                    alert('CPF não encontrado!');
                    esvaziarFormulario();
                    $("#form-submit").html("Cadastrar");
                }
            });
        } else {
            alert('CPF inválido!')
            esvaziarFormulario();
            $("#form-submit").html("Cadastrar");
        }
    });
});