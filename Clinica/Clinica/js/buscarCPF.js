let pessoasCadastradas = [
    {
        "cpf": "70713702060",
        "name": "João da Silva",        
        "dtNascimento": "02/01/1995",
        "sexo": "m",
        "profissao": "Marceneiro",
        "fixo": "(61) 3461-4066",
        "celular": "(61) 99687-1312",
        "cep": "72420-220",
        "estado": "al",
        "cidade": "maceio",
        "logradouro": "CH",
        "numEndereco": "15",
        "planoDeSaude": "amil",
        "altura": "173",
        "peso": "46",
        "alergias": "dipirona",
        "medicamento": "rupinol",
        "abo": "o",
        "rh":"positivo"

    }, {
        "cpf": "62299974016",
        "name": "Neymar Júnior",
        "dtNascimento": "09/02/1995",
        "sexo": "m",
        "profissao": "Atleta",
        "celular": "(61) 99687-1112",
        "cep": "72820-200",
        "estado": "rj",
        "cidade": "Rio de Janeiro",
        "logradouro": "CS",
        "numEndereco": "405",
        "planoDeSaude": "interlife",
        "altura": "187",
        "peso": "65",
        "alergias": "paracetamol",
        "medicamento": "rivotril",
        "abo": "a",
        "rh": "negativo"
    }, {
        "cpf": "31066927073",
        "name": "Michele Akemi",
        "dtNascimento": "22/11/1995",
        "sexo": "f",
        "profissao": "Professora",
        "fixo": "(61) 3000-4066",
        "celular": "(61) 99767-1312",
        "cep": "70000-220",
        "estado": "df",
        "cidade": "ceilandia",
        "logradouro": "rua",
        "numEndereco": "96",
        "planoDeSaude": "amil",
        "altura": "160",
        "peso": "89",
        "alergias": "frutos do mar",
        "medicamento": "",
        "abo": "ab",
        "rh": "negativo"
    }
];

// 707.137.020-60
// 310.669.270-73

function procurarPorCpf(cpf) {
    var limite = pessoasCadastradas.length;
    var saida = null;
    for (var i = 0; i < limite; i++) {
        if (pessoasCadastradas[i]['cpf'] === cpf) {
            saida = pessoasCadastradas[i];
            break;
        }
    }
    return saida;
}