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

/**
 * Capitaliza uma string.
 */
function capitalize(s) {
    return s.charAt(0).toUpperCase() + s.slice(1);
}

/**
 * Esvazia o formulário da aplicação.
 */
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

/**
 * Preenche o formulário com os dados do paciente fornecido.
 *
 * @param dados  Um `javascript Map` cujas chaves são as propriedades pessoais como mostradas neste arquivo mas 
 *               capitalizadas e valores são os dados do paciente.
 */
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

/**
 * Gera um `Javascript Map` com os dados preenchidos no formulário.
 *
 * @return Gera um `Javascript Map` com os dados preenchidos no formulário, onde as chaves são as propriedades pessoais
 *         descritas neste arquivo e os valores são os valores preenchidos no formúlário.
 */
function coletarDadosDoFormulario() {
    var dados = {};

    for (var i = 0; i < propriedadesPessoais.length; i++) {
        var prop = propriedadesPessoais[i];
        if ((prop === "rh") || (prop === "abo") || (prop === "sexo")) {
            dados[capitalize(prop)] = $("input[name=" + prop + "]:checked").val();
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

    dados["Cpf"] = $("#cpf").val().replace(/\./g, "").replace("-", "");
    return dados;
}