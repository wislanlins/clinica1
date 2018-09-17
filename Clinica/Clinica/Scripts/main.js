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

function esvaziarFormulario() {
    for (var i = 0; i < propriedadesPessoais.length; i++) {
        var prop = propriedadesPessoais[i];
        if ((prop === "rh") || (prop === "abo") || (prop === "sexo")) {
            $("input:radio[name=" + prop + "]").prop("checked", false);
        } else {
            var input = $("input[name=" + prop + "]");
            if (input !== undefined) {
                input.val("");
            }
            var select = $("select[name=" + prop + "]");
            if (select !== undefined) {
                select.val("");
            }
        }
    }
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
    $("#form-submit").html("Cadastrar");
}

function coletarDadosDoFormulario() {
    var dados = {};

    for (var i = 0; i < propriedadesPessoais.length; i++) {
        var prop = propriedadesPessoais[i];
        if ((prop === "rh") || (prop === "abo") || (prop === "sexo")) {
            dados[capitalize(prop)] = $("input:radio[name=" + prop + "]").prop("checked");
        } else {
            var input = $("input[name=" + prop + "]");
            if (input !== undefined) {
                if (input.val() !== undefined) {
                    dados[capitalize(prop)] = input.val();
                }
            }
            var select = $("select[name=" + prop + "]");
            if (select !== undefined) {
                if (select.val() !== undefined) {
                    dados[capitalize(prop)] = select.val();
                }
            }
        }
    }

    return dados;
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
            alert("Altura inválida");
            return;
        }
        if (!validarPeso($("input[name=peso]").val())) {
            alert("Peso inválido");
            return;
        }
        
        var dados = coletarDadosDoFormulario();
        // BUG Delete this debugging message whenever possible
        console.log(dados);
        // TODO Send stuff to database
        alert("Operação concluída!");
        window.location.reload();
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
                }
            });
        } else {
            alert('CPF inválido!')
            esvaziarFormulario();
        }
    });
});