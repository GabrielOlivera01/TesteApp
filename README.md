# TesteApp

Verbo Http|Ação|Endpoint
---|---|---
GET|Trazer uma lista com todas as tarefas o Blazor faz uma requisição para o endpoint|api/Tarefas
GET|Trazer uma lista com todas as tarefas concluídas o Blazor faz uma requisição para o endpoint|api/Tarefas/Concluidas
GET|Trazer uma tarefa pelo id o Blazor faz uma requisição para o endpoint passando o id da tarefa|api/Tarefas/{id}
POST|Inserir uma nova tarefa o Blazor faz uma requisição para o endpoint|api/Tarefas
PUT|Editar uma tarefa o Blazor faz uma requisição para o endpoint passando o id da tarefa|api/Tarefas/{id}
PUT|Marcar uma tarefa como concluída o Blazor faz uma requisição para o endpoint passando o id da tarefa|api/Tarefas/ConcluirTarefa/{id}
DELETE|Para excluir uma tarefa o Blazor faz uma requisição para o endpoint oassando o id da tarefa|api/Tarefas/{id}
