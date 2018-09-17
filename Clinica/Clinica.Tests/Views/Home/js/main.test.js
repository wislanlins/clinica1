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
});