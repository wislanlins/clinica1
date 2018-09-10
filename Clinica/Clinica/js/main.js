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

function preencherFormulario(dados) {
    var limite = propriedadesPessoais.length;
    for (var i = 0; i < limite; i++) {
        var prop = propriedadesPessoais[i];
        if (((prop === "rh") || (prop === "abo") || (prop === "sexo")) && (dados[prop] !== undefined)) {
            $("input:radio[value=" + dados[prop] + "]").prop('checked', true);
        } else {
            var input = $("input[name=" + prop + "]");
            if (input !== undefined) {
                input.val(dados[prop]);
            }
            var select = $("select[name=" + prop + "]");
            if (select !== undefined) {
                select.val(dados[prop]);
            }
        }
    }
}

$(document).ready(function () {
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
        var acao = "Cadastrar";
        var inputCpf = $("input[name=cpf]");
        var cpf = inputCpf.val().replace(/\./g, "").replace("-", "");
        if (validarCpf(cpf)) {
            dados = procurarPorCpf(cpf);
            if (dados !== null) {
                preencherFormulario(dados);
                acao = "Atualizar";
            } else {
                alert('CPF não encontrado!');
            }
        } else {
            alert('CPF inválido!')
        }
        $("#form-submit").html(acao);
    });
});