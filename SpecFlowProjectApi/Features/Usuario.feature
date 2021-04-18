#language: pt-br
Funcionalidade: Usuário
Listar usuários cadastrados

Cenario: Cadastrar usuário
	Dado que o usuário foi criado
	Quando eu faço um 'POST' para o endpoint de usuários
	Então o statusCode deve ser 201
	E uma mensagem de sucesso e o id do usuarios são retornados

@CadastraUsuario
Cenário: Cadastrar usuário com email já utilizado
	Dado que já exista um usuário
	Quando eu faço um 'POST' para o endpoint de usuários
	Então o statusCode deve ser 400
	E uma mensagem deve ser retornada 'Este email já está sendo usado'

@UsuarioNull
Cenario: Pegar usuários
	#Dado que eu faco uma requisicao 'GET' para o endpoint de usuários
	Quando eu faço um 'GET' para o endpoint de usuários
	Então o statusCode deve ser 200
	E uma lista deve ser preenchida

@CadastraUsuario
Cenário: Atualizar Usuário
	Dado os dados desse usuário foram atualizados
	Quando eu faço um 'PUT' para o endpoint de usuários
	Então o statusCode deve ser 200
	E uma mensagem deve ser retornada 'Registro alterado com sucesso'