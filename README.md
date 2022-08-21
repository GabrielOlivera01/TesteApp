# TesteApp

## Objetivo do Projeto:

Criação de um app para controle de tarefas onde seja possivel adicionar tarefas, editar tarefas, marcar tarefas como concluídas e excluir tarefas, utilizando Blazor WebAssemby, API RESTfull e Entity Framework Core.

### Site:

O Site é um projeto web Blazor WebAssembly App.

Na página principal podemos fazer o gerenciamento das tarefas, essa página conta com duas listas, sendo uma de tarefas pendentes e a outra de tarefas concluídas, temos também um campo de texto e um botão.

O campo de texto e botão servem para criar uma nova tarefa, colocando o nome da tarefa e clicando no botão adicionar, a tarefa criada irá para a lista de tarefas pendentes.

Na lista de tarefas pendentes, para cada tarefa adicionada temos um checkbox para marcar a tarefa como concluída, um campo de texto no qual fica o nome que foi atribuído a tarefa inicialmente, um botão para editar que nos leva para uma página na qual podemos alterar o nome da tarefa, e outro botão para excluir que remove a tarefa da lista de tarefas pendentes.

Já na lista de tarefas concluídas ficam apenas as tarefas que foram marcadas como concluídas ao clicar no checkbox.


### API:

A API é um projeto web ASP.NET Core Web API.

O Site vai fazer as requisições para os endpoints da API que por sua vez irá executar as operações solicitadas.


Verbo Http|Descrição|Endpoint
---|---|---
GET|Trazer uma lista com todas as tarefas o Blazor faz uma requisição para o endpoint|api/Tarefas
GET|Trazer uma lista com todas as tarefas concluídas o Blazor faz uma requisição para o endpoint|api/Tarefas/Concluidas
GET|Trazer uma tarefa pelo id o Blazor faz uma requisição para o endpoint passando o id da tarefa|api/Tarefas/{id}
POST|Inserir uma nova tarefa o Blazor faz uma requisição para o endpoint|api/Tarefas
PUT|Editar uma tarefa o Blazor faz uma requisição para o endpoint passando o id da tarefa|api/Tarefas/{id}
PUT|Marcar uma tarefa como concluída o Blazor faz uma requisição para o endpoint passando o id da tarefa|api/Tarefas/ConcluirTarefa/{id}
DELETE|Para excluir uma tarefa o Blazor faz uma requisição para o endpoint oassando o id da tarefa|api/Tarefas/{id}
