/**
 * Retorna verdadeiro se a string fornecida for um CPF válido.
 * Ou falso caso contrário.
 */
function validarCpf(entrada) {
    var Soma;
    var Resto;
    Soma = 0;
    if (entrada == "00000000000") return false;

    for (i = 1; i <= 9; i++) Soma = Soma + parseInt(entrada.substring(i - 1, i)) * (11 - i);
    Resto = (Soma * 10) % 11;

    if ((Resto == 10) || (Resto == 11)) Resto = 0;
    if (Resto != parseInt(entrada.substring(9, 10))) return false;

    Soma = 0;
    for (i = 1; i <= 10; i++) Soma = Soma + parseInt(entrada.substring(i - 1, i)) * (12 - i);
    Resto = (Soma * 10) % 11;

    if ((Resto == 10) || (Resto == 11)) Resto = 0;
    if (Resto != parseInt(entrada.substring(10, 11))) return false;
    return true;
}
/**
 * Retorna verdadeiro se a string fornecida for um peso válido,
 * isto é, se o peso for positivo.
 * Ou falso caso contrário.
 */
function validarPeso(entrada) {
    peso = parseInt(entrada);
    if (peso == NaN) {
        return false;
    } else if (peso <= 0) {
        return false;
    }
    return true;
}

/**
 * Retorna verdadeiro se a string fornecida for uma altura válida,
 * isto é, se ela for positiva e  menor que 300cm.
 * Ou falso caso contrário.
 */
function validarAltura(entrada) {
    altura = parseInt(entrada);
    if (altura == NaN) {
        return false;
    }
    return (altura > 0) && (altura < 300);
}

function verificarDataExiste(dia, mes, ano) {
    var bissexto = 0;
    if ((ano > 1900) && (ano < 2100)) {
        switch (mes) {
            case 1:
            case 3:
            case 5:
            case 7:
            case 8:
            case 10:
            case 12:
                if (dia <= 31) {
                    return true;
                }
                break
            case 4:
            case 6:
            case 9:
            case 11:
                if (dia <= 30) {
                    return true;
                }
                break
            case 2:					/* Validando ano Bissexto / fevereiro / dia */
                if ((ano % 4 == 0) || (ano % 100 == 0) || (ano % 400 == 0)) {
                    bissexto = 1;
                }
                if ((bissexto == 1) && (dia <= 29)) {
                    return true;
                }
                if ((bissexto != 1) && (dia <= 28)) {
                    return true;
                }
                break

        }
    }
    return false;
}

function validarDataDeNascimento(entrada) {
    var data = entrada.split('/');
    var dia = parseInt(data[0]);
    var mes = parseInt(data[1]);
    var ano = parseInt(data[2]);

     // Verifica se a data foi digitada corretamente
    if (!verificarDataExiste(dia, mes, ano)) {
        return false;
    }

    // Verifica se a data não é maior do que a do dia de hoje
    return Date.now() > new Date(ano, mes - 1, dia);
}