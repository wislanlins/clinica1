describe('Validações', function() {
    describe('CPF', function() {
        it('Não deve validar um CPF com todos os dígitos iguais a zero', function(done) {
            if (validarCpf("00000000000") === false) {
                done();
            } else {
                done(new Error("CPF '00000000000' deveria ser inválido"));
            }
        });

        it('Deve validar um CPF válido mesmo que não esteja ligado a ninguém', function(done) {
            if (validarCpf("31066927073")) {
                done();
            } else {
                done(new Error("CPF '31066927073' deveria ser válido"));
            }
        });
    });

    describe('Datas', function() {
        it('Não deve aceitar uma data em um formato errado.', function(done) {
            if (validarDataDeNascimento("25/05") === false) {
                done();
            } else {
                done(new Error("Data '25/05' deveria ser um formato inválido"));
            }
        });

        it('Não deve passar uma data inexistente.', function(done){
            if (validarDataDeNascimento("30/02/2003") === false) {
                done();
            } else {
                done(new Error("Dia 30/02 não existe"));
            }
        });

        it('Deve aceitar anos bissextos.', function(done){
            if (validarDataDeNascimento("29/02/2012") === true) {
                done();
            } else {
                done(new Error("Dia 29/02/2012 existiu!"));
            }
        });
    });

    describe('Peso e altura', function() {
        it('Não pode aceitar "abc" como altura ou peso', function(done) {
            let alturaValida = validarAltura("abc");
            let pesoValido =  validarPeso("abc");
            if (alturaValida && pesoValido) {
                done(new Error("Errou duas vezes!"));
            } else if (alturaValida) {
                done(new Error("Validou string como altura válida"));
            } else if (pesoValido) {
                done(new Error("Validou string como peso válido"));
            } else {
                done();
            }
        }); 

        it('Não pode aceitar valores negativos como medida', function(done) {
            let entrada = "-3";
            let alturaValida = validarAltura(entrada);
            let pesoValido =  validarPeso(entrada);
            if (alturaValida && pesoValido) {
                done(new Error("Errou duas vezes!"));
            } else if (alturaValida) {
                done(new Error("Utilizou valor negativo como altura válida"));
            } else if (pesoValido) {
                done(new Error("Utilizou valor negativo como peso válido"));
            } else {
                done();
            }
        });    

        it('Não pode receber unidades de medida na entrada', function(done) {
            let alturaValida = validarAltura("175cm");
            let pesoValido =  validarPeso("65kg");
            if (alturaValida && pesoValido) {
                done(new Error("Errou duas vezes! "));
            } else if (alturaValida) {
                done(new Error("Validou string com unidade de medida como altura válida"));
            } else if (pesoValido) {
                done(new Error("Validou string com unidade de medida como peso válido"));
            } else {
                done();
            }
        }); 
    });
});

describe("Máscaras", function(){
    describe("CPF", function() {
        it("Consegue mascarar um CPF", function(done) {
            let masked = mCPF("12345678912"); 
            if (masked === "123.456.789-12") {
                done();
            } else {
                done(new Error("CPF mascarado de forma errada."));
            }
        });
    });

    describe("CEP", function() {
        it("Consegue mascarar um CEP", function(done) {
            let masked = mCEP("71000000"); 
            if (masked === "71000-000") {
                done();
            } else {
                done(new Error("CEP mascarado de forma errada."));
            }
        });
    });

    describe("Telefone", function() {
        it("Consegue mascarar um telefone fixo", function(done) {
            let masked = mTel("6232149876"); 
            if (masked === "(62) 3214-9876") {
                done();
            } else {
                done(new Error("Telefone fixo mascarado de forma errada: " + masked));
            }
        });
        
        it("Consegue mascarar um telefone celular", function(done) {
            let masked = mTel("62982149876"); 
            if (masked === "(62) 98214-9876") {
                done();
            } else {
                done(new Error("Telefone celular mascarado de forma errada: " + masked));
            }
        });
    });
});