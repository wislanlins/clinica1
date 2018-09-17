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

function fMasc(objeto, mascara) {
    obj = objeto
    masc = mascara
    setTimeout("fMascEx()", 1)
}
function fMascEx() {
    obj.value = masc(obj.value)
}
function mCPF(cpf) {
    cpf = cpf.replace(/\D/g, "")
    cpf = cpf.replace(/(\d{3})(\d)/, "$1.$2")
    cpf = cpf.replace(/(\d{3})(\d)/, "$1.$2")
    cpf = cpf.replace(/(\d{3})(\d{1,2})$/, "$1-$2")
    return cpf
}
function mCEP(cep){
    cep=cep.replace(/D/g,"")                
    cep=cep.replace(/^(\d{5})(\d)/,"$1-$2") 
        return cep
    }
function mTel(tel) {
    tel = tel.replace(/\D/g, "")
    tel = tel.replace(/^(\d)/, "($1")
    tel = tel.replace(/(.{3})(\d)/, "$1)$2")
    if (tel.length == 9) {
        tel = tel.replace(/(.{1})$/, "-$1")
    } else if (tel.length == 10) {
        tel = tel.replace(/(.{2})$/, "-$1")
    } else if (tel.length == 11) {
        tel = tel.replace(/(.{3})$/, "-$1")
    } else if (tel.length == 12) {
        tel = tel.replace(/(.{4})$/, "-$1")
    } else if (tel.length > 12) {
        tel = tel.replace(/(.{4})$/, "-$1")
    }
    return tel;
}

function aplicarMascaras() {
    fMasc(document.getElementsByName("cpf")[0], mCPF);
    fMasc(document.getElementsByName("fixo")[0], mTel);
    fMasc(document.getElementsByName("celular")[0], mTel);
    fMasc(document.getElementsByName("cep")[0], mCEP);
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
        var acao = "Cadastrar";
        var inputCpf = $("input[name=cpf]");
        var cpf = inputCpf.val().replace(/\./g, "").replace("-", "");
        if (validarCpf(cpf)) {
            procurarPorCpf(cpf, function (dados) {
                console.log(dados);
                if (dados) {
                    preencherFormulario(dados);
                    aplicarMascaras();
                     acao = "Atualizar";
                } else {
                    alert('CPF não encontrado!');
                }
                $("#form-submit").html(acao);
            });
        } else {
            alert('CPF inválido!')
        }
        $("#form-submit").html(acao);
    });
});