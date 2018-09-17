let propriedadesPessoais = [
    "name",
    "dtNascimento",
    "sexo",
    "profissao",
    "fixo",
    "celular",
    "cep",
    "estado",
    "cidade",
    "logradouro",
    "numEndereco",
    "planoDeSaude",
    "altura",
    "peso",
    "alergias",
    "medicamento",
    "abo",
    "rh"
]

function capitalize(s) {
    return s.charAt(0).toUpperCase() + s.slice(1);
}

function preencherFormulario(dados) {
    var limite = propriedadesPessoais.length;
    for (var i = 0; i < limite; i++) {
        var prop = propriedadesPessoais[i];
        if (((prop === "rh") || (prop === "abo") || (prop === "sexo")) && (dados[capitalize(prop)] !== undefined)) {
            $("input:radio[value=" + dados[capitalize(prop)] + "]").prop('checked', true);
        } else {
            var input = $("input[name=" + prop + "]");
            if (input !== undefined) {
                input.val(dados[capitalize(prop)]);
            }
            var select = $("select[name=" + prop + "]");
            if (select !== undefined) {
                select.val(dados[capitalize(prop)]);
            }
        }
    }
}



$(document).ready(function () {
    $('.cep').mask('00000-000', { reverse: true });
    $('.cpf').mask('000.000.000-00', { reverse: true });
    $('.fixo').mask('(00) 0000-0000', { reverse: false });
    $('.celular').mask('(00) 00000-0000', { reverse: false });

    $("#form-submit").click(function () {        
        inputCpf = $("input[name=cpf]");
        if (!validarCpf(inputCpf.val().replace(/\./g, "").replace("-", ""))) {
            alert("Digite o CPF corretamente");
            return;
        }
        if (!validarDataDeNascimento($("input[name=dtNascimento]").val())) {
            alert("Data inválida");
            return;
        }
        if (!validarAltura($("input[name=altura]").val())) { 
            alert("Peso inválido");
            return;
        }
        if (!validarPeso($("input[name=peso]").val())) {
            alert("Peso inválido");
            return;
        }


        alert("Operação concluída!");
    });

    $("#cpfSearch").click(function () {
        var inputCpf = $("input[name=cpf]");
        var cpf = inputCpf.val().replace(/\./g, "").replace("-", "");
        if (validarCpf(cpf)) {
            procurarPorCpf(cpf, function (dados) {
                console.log(dados);
                if (dados) {
                    preencherFormulario(dados);
                    aplicarMascaras();
                    $("#form-submit").html("Atualizar");
                } else {
                    alert('CPF não encontrado!');
                    $("#form-submit").html("Cadastrar");
                }
            });
        } else {
            alert('CPF inválido!')
            $("#form-submit").html("Cadastrar");
        }
    });
});