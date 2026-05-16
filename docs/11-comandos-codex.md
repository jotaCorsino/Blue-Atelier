# blue atelier - comandos para codex

## 1. papel do Codex no projeto

O Codex é o engenheiro principal do **Blue Atelier**.

Responsabilidades:

- ler a documentação antes de alterar qualquer arquivo;
- trabalhar uma tarefa por vez;
- executar apenas o escopo pedido pelo usuário;
- manter a documentação viva;
- implementar, revisar e validar mudanças quando a fase de código começar;
- respeitar a stack oficial;
- respeitar o visual aprovado;
- atualizar `docs/03-estado-atual.md` ao final de cada tarefa;
- fazer commit e push ao final de cada tarefa.

O Codex não decide sozinho a próxima fase. A próxima tarefa vem do usuário, do `docs/03-estado-atual.md` e da validação do ChatGPT sobre o repositório remoto.

## 2. checklist obrigatório antes de começar qualquer tarefa

Antes de qualquer alteração, o Codex deve confirmar:

- O repositório correto é o Blue Atelier.
- A tarefa atual foi entendida.
- A tarefa é documental, técnica, visual, implementação, correção ou validação.
- Os documentos obrigatórios foram lidos.
- O escopo não pede código quando a tarefa é documental.
- A tarefa não pede alteração visual sem autorização.
- A tarefa não muda stack oficial.
- O estado atual do Git foi verificado.
- A próxima tarefa sugerida em `docs/03-estado-atual.md` foi considerada.

Se houver conflito entre documentos e pedido do usuário, o Codex deve parar e explicar o conflito antes de alterar arquivos.

## 3. documentos que o Codex deve ler sempre

Em qualquer tarefa, ler sempre:

```txt
docs/01-descricao-geral-do-app.md
docs/02-regras-de-desenvolvimento-com-codex.md
docs/03-estado-atual.md
docs/04-proximos-documentos.md
```

Quando existirem, ler também os documentos relacionados à etapa:

```txt
docs/05-planejamento-de-desenvolvimento.md
docs/06-arquitetura-tecnica.md
docs/07-mapa-de-telas.md
docs/08-design-system.md
docs/09-prompts-stitch.md
docs/10-prompts-antigravity.md
docs/11-comandos-codex.md
docs/12-modelagem-do-banco.md
docs/13-sistema-de-arquivos.md
docs/14-checklist-de-validacao.md
```

Regra prática:

- Tarefa documental: ler documentos base e documentos anteriores.
- Tarefa de arquitetura: ler descrição geral, planejamento e arquitetura.
- Tarefa de UI/UX: ler mapa de telas, design system e prompts do Stitch.
- Tarefa de implementação: ler arquitetura, mapa de telas, design system e documentos técnicos da área.
- Tarefa de banco: ler arquitetura e modelagem do banco.
- Tarefa de arquivos ou rede: ler arquitetura e sistema de arquivos.
- Tarefa visual: ler mapa de telas, design system e referência visual aprovada.

## 4. como identificar a próxima tarefa pelo `docs/03-estado-atual.md`

O Codex deve abrir `docs/03-estado-atual.md` e localizar:

- `última tarefa realizada`;
- `pendências atuais`;
- `arquivos alterados na última tarefa`;
- `validações executadas na última tarefa`;
- `próxima tarefa sugerida`.

A seção `próxima tarefa sugerida` indica o próximo documento ou etapa provável.

Se o usuário disser apenas `continue`, o Codex deve:

1. Ler os documentos obrigatórios.
2. Confirmar qual é a próxima tarefa sugerida em `docs/03-estado-atual.md`.
3. Executar apenas essa próxima tarefa se ela estiver clara e ainda não estiver concluída.
4. Não pular etapas.
5. Não criar código se a próxima tarefa for documental.

## 5. formato padrão de prompt para nova tarefa

Modelo recomendado para o usuário ou ChatGPT enviar ao Codex:

```txt
Você está trabalhando no projeto Blue Atelier.

Antes de qualquer alteração, leia obrigatoriamente estes arquivos:

- docs/01-descricao-geral-do-app.md
- docs/02-regras-de-desenvolvimento-com-codex.md
- docs/03-estado-atual.md
- docs/04-proximos-documentos.md
- [documentos específicos da etapa]

Nesta tarefa, [crie / atualize / implemente / valide] [escopo].

Regras importantes:

- trabalhar apenas nesta tarefa;
- não criar código se a tarefa for documental;
- não alterar visual aprovado sem autorização;
- não mudar stack oficial;
- atualizar docs/03-estado-atual.md;
- executar validações possíveis;
- fazer commit e push.

Ao finalizar:

1. execute git status;
2. adicione os arquivos alterados;
3. faça commit com a mensagem: [mensagem];
4. faça push para o repositório remoto;
5. informe resumo, arquivos alterados, validações, commit e push.
```

## 6. formato padrão de resposta ao concluir tarefa

Ao concluir uma tarefa, responder em português com:

```txt
Tarefa concluída:
Resumo:
Arquivos alterados:
Validações executadas:
Pendências:
Commit:
Push:
Próxima tarefa sugerida:
```

Se algo não foi possível validar, informar claramente.

Se o push falhar, não dizer que foi concluído. Explicar o erro e o estado atual.

## 7. regras para tarefas de documentação

Em tarefas documentais:

- Não criar código do app.
- Não criar projeto .NET.
- Não criar telas reais.
- Não criar CSS.
- Não instalar dependências.
- Não alterar documentos fora do escopo, salvo `docs/03-estado-atual.md` e `docs/04-proximos-documentos.md` quando solicitado.
- Usar linguagem simples, clara e operacional.
- Registrar decisões sem antecipar implementação.
- Manter a documentação coerente com os documentos anteriores.

Validação mínima:

- conferir se o documento foi criado;
- conferir títulos principais;
- conferir se todos os itens pedidos aparecem;
- revisar `docs/03-estado-atual.md`;
- revisar `docs/04-proximos-documentos.md`, quando alterado;
- executar `git status`.

## 8. regras para tarefas de arquitetura

Em tarefas de arquitetura:

- Respeitar a stack oficial: .NET MAUI Blazor Hybrid, C#, SQLite, Entity Framework Core, Razor Components e CSS próprio.
- Não trocar stack sem pedido explícito.
- Separar interface, domínio, aplicação, infraestrutura e persistência.
- Não criar código antes da tarefa de criação da solução.
- Não transformar decisões técnicas em visual final.
- Registrar riscos, dependências e limites.

Validação mínima:

- verificar se as camadas estão coerentes;
- verificar se dependências respeitam a arquitetura;
- verificar se a documentação de estado foi atualizada;
- quando houver código no futuro, executar build e testes aplicáveis.

## 9. regras para tarefas de UI/UX

Em tarefas de UI/UX:

- Ler `docs/07-mapa-de-telas.md`.
- Ler `docs/08-design-system.md`.
- Ler `docs/09-prompts-stitch.md` quando envolver ideação visual.
- Não criar tela real se a tarefa for apenas planejamento.
- Não definir design final sem aprovação.
- Não criar design system paralelo.
- Não transformar o app em dashboard corporativo, CRM, SaaS ou painel administrativo pesado.
- Usar azul apenas como destaque.

Validação mínima:

- conferir coerência com mapa de telas;
- conferir coerência com design system;
- registrar limitações e pontos que ainda precisam de aprovação;
- não alterar visual aprovado sem autorização.

## 10. regras para tarefas de implementação

Em tarefas de implementação:

- Implementar apenas o escopo pedido.
- Ler arquitetura, mapa de telas, design system e documentos técnicos da área.
- Não misturar várias fases em uma única tarefa.
- Não refatorar amplamente sem pedido.
- Não alterar visual aprovado sem autorização.
- Criar ou alterar testes quando o risco justificar.
- Executar build e testes possíveis.
- Atualizar documentação de estado.

Se a implementação tocar interface:

- seguir o design system;
- fornecer evidência visual quando a tela existir;
- verificar tema claro e escuro quando aplicável;
- verificar texto cortado, sobreposição e responsividade dentro do Windows.

## 11. regras para tarefas que envolvem visual aprovado

Visual aprovado é camada protegida.

O Codex nunca deve alterar sem autorização explícita:

- layout;
- cores;
- espaçamentos;
- tipografia;
- bordas;
- sombras;
- hierarquia visual;
- tamanho de cards;
- densidade;
- comportamento de navegação;
- componentes visuais;
- estados visuais.

Mudanças permitidas sem nova aprovação visual:

- correção técnica sem impacto visual;
- ajuste interno sem mudança de aparência;
- teste;
- correção de bug que preserva o visual.

Mudanças que exigem autorização:

- redesenho;
- troca de posição de áreas;
- mudança de paleta;
- alteração de tema;
- alteração de cards, mosaicos, listas ou formulários;
- mudança de navegação;
- alteração de estados vazios, erro, offline ou sucesso.

## 12. regras para tarefas de banco SQLite

Em tarefas de banco:

- Ler `docs/06-arquitetura-tecnica.md`.
- Ler `docs/12-modelagem-do-banco.md`, quando existir.
- Guardar no SQLite apenas metadados, relações, caminhos, status, tags, links, favoritos, materiais, configurações e histórico.
- Não armazenar arquivos pesados no banco.
- Não armazenar imagens originais no banco.
- Usar Entity Framework Core conforme arquitetura.
- Planejar migrations com cuidado.
- Criar índices quando houver busca frequente.
- Testar criação e leitura do banco quando implementado.

Arquivos pesados devem permanecer no sistema de arquivos:

```txt
.stl
.obj
.3mf
.blend
.ctb
.lychee
.chitubox
.png
.jpg
.jpeg
.webp
.pdf
```

## 13. regras para tarefas de sistema de arquivos

Em tarefas de sistema de arquivos:

- Ler `docs/13-sistema-de-arquivos.md`, quando existir.
- Tratar arquivos reais do Windows com cuidado.
- Não apagar arquivos sem autorização explícita.
- Não mover arquivos sem confirmação quando houver risco.
- Criar pastas apenas em caminhos configurados.
- Validar existência de arquivos e pastas.
- Identificar arquivo ausente sem quebrar a tela.
- Manter caminhos no banco como metadados.
- Preservar arquivos fora do banco.

Operações perigosas devem exigir confirmação futura:

- mover arquivo;
- sobrescrever arquivo;
- remover vínculo;
- excluir arquivo real;
- importar dados por cima dos existentes.

## 14. regras para caminhos locais e de rede

O app deve suportar caminhos locais, unidades mapeadas e caminhos UNC.

Exemplos:

```txt
D:\atelier-3d\
Z:\atelier-3d\
\\atelier-notebook\fila-impressao\
\\desktop-atelier\arquivos-3d\
\\192.168.18.50\atelier-3d\
```

Regras:

- Caminho offline é condição normal.
- Caminho de rede offline não deve travar o app.
- O app deve funcionar localmente mesmo com rede indisponível.
- A fila deve testar destino antes de copiar arquivo.
- Configurações devem mostrar último teste quando existir.
- Mensagens de rede devem ser claras e não alarmistas.
- Não alterar configurações do Windows sem autorização.

## 15. regras para fila de impressão

A fila de impressão organiza arquivos e modelos prontos para impressão. Ela não controla a impressora diretamente.

Regras:

- Cada item deve apontar para modelo e arquivo quando possível.
- Cada item deve guardar status, caminho do arquivo e destino.
- O destino pode ser local ou de rede.
- Testar destino antes de copiar arquivo.
- Registrar falhas e histórico.
- Não sobrescrever arquivo sem confirmação.
- Não remover item automaticamente.
- Não bloquear toda a fila se um destino estiver offline.

Status previstos:

```txt
aguardando fatiamento
pronto para enviar
enviado
imprimindo
impresso
falhou
cancelado
arquivado
```

## 16. regras para configurações

Configurações são parte central do app.

Áreas previstas:

- caminhos principais;
- caminhos de rede;
- modelo padrão de pastas;
- tema;
- tamanho de cards;
- densidade;
- programas padrão;
- backup;
- importação e exportação.

Regras:

- Validar configuração antes de salvar.
- Permitir testar caminho sem salvar.
- Não mudar caminho do usuário sem autorização.
- Não criar personalização visual fora do design system.
- Não alterar visual aprovado pela tela de configurações.
- Backup e importação devem ser tratados com cuidado.

## 17. regras para testes

Quando houver código, testes devem acompanhar risco e impacto.

Prioridades:

- regras de domínio;
- geração de slug;
- transições de status;
- serviços de aplicação;
- persistência SQLite;
- serviços de arquivos;
- caminhos locais e de rede;
- fila de impressão;
- busca global;
- backup e restauração.

Regras:

- Rodar testes relevantes antes do commit.
- Informar se não há testes ainda.
- Não apagar teste falhando para passar build.
- Não criar testes fora do escopo sem necessidade.
- Usar diretórios temporários para testes de arquivo quando possível.

## 18. regras para validação visual futura

Quando houver telas implementadas, fornecer evidência visual.

Evidências possíveis:

- screenshot da tela alterada;
- screenshot em tema claro;
- screenshot em tema escuro;
- screenshot de estado vazio;
- screenshot de erro ou offline;
- descrição de rota ou caminho para abrir a tela;
- resumo das ações testadas.

Critérios:

- textos não cortados;
- elementos sem sobreposição;
- mosaicos estáveis;
- cards proporcionais;
- botões legíveis;
- azul usado com moderação;
- estados visuais claros;
- tema claro e escuro coerentes;
- visual aprovado preservado.

## 19. regras para commits

Cada tarefa concluída deve gerar um commit próprio.

Antes do commit:

```bash
git status
git diff --stat
git diff --cached --stat
```

Mensagem deve seguir o tipo da tarefa:

```txt
docs: descreve documentação
feat: descreve feature
fix: descreve correção
refactor: descreve ajuste interno
test: descreve teste
chore: descreve tarefa auxiliar
```

Regras:

- Não misturar tarefas diferentes no mesmo commit.
- Não commitar arquivo fora do escopo.
- Não commitar código em tarefa documental.
- Não commitar visual alterado sem autorização.
- Conferir arquivos staged antes de commitar.

## 20. regras para push

Ao final da tarefa:

```bash
git push origin main
```

Se a branch principal não for `main`, verificar a branch correta antes.

Regras:

- Push é obrigatório ao final da tarefa.
- GitHub é a fonte de verdade.
- ChatGPT valida o repositório remoto.
- O usuário aprova a próxima tarefa.
- Se o push falhar, informar erro e não declarar conclusão completa.

## 21. checklist final antes de responder ao usuário

Antes da resposta final:

- Documento ou código pedido foi criado ou atualizado?
- `docs/03-estado-atual.md` foi atualizado?
- `docs/04-proximos-documentos.md` foi atualizado quando necessário?
- Nenhum código foi criado em tarefa documental?
- Stack oficial foi preservada?
- Visual aprovado foi preservado?
- Validações possíveis foram executadas?
- `git status` foi executado antes do stage?
- Arquivos corretos foram adicionados?
- Commit foi criado?
- Push foi concluído?
- Estado final do Git está limpo?
- Próxima tarefa sugerida foi registrada?

## 22. modelo de comando genérico para continuar

Use este modelo quando o usuário pedir apenas `continue`:

```txt
Você está trabalhando no projeto Blue Atelier.

Leia obrigatoriamente:

- docs/01-descricao-geral-do-app.md
- docs/02-regras-de-desenvolvimento-com-codex.md
- docs/03-estado-atual.md
- docs/04-proximos-documentos.md
- docs/11-comandos-codex.md

Identifique em docs/03-estado-atual.md a próxima tarefa sugerida.

Execute apenas essa próxima tarefa, respeitando:

- uma tarefa por vez;
- não criar código se a tarefa for documental;
- não criar telas antes da etapa aprovada;
- não alterar visual aprovado sem autorização;
- não mudar stack oficial;
- atualizar docs/03-estado-atual.md;
- atualizar docs/04-proximos-documentos.md se a tarefa criar novo documento;
- executar validações possíveis;
- fazer commit;
- fazer push.
```

## 23. modelo de comando para tarefa documental

```txt
Você está trabalhando no projeto Blue Atelier.

Antes de qualquer alteração, leia os documentos obrigatórios indicados na tarefa e os documentos anteriores relacionados.

Nesta tarefa, crie ou atualize apenas documentação.

Não crie código do aplicativo.
Não crie projeto .NET.
Não crie telas reais.
Não crie CSS.
Não altere visual aprovado.
Não mude a stack oficial.

Atualize docs/03-estado-atual.md registrando a tarefa concluída.
Atualize docs/04-proximos-documentos.md se um novo documento for criado.

Ao finalizar:

1. execute git status;
2. adicione os arquivos alterados;
3. faça commit com a mensagem solicitada;
4. faça push para origin/main;
5. informe resumo, arquivos, validações, commit e push.
```

## 24. modelo de comando para tarefa de implementação

```txt
Você está trabalhando no projeto Blue Atelier.

Antes de alterar código, leia:

- docs/01-descricao-geral-do-app.md
- docs/02-regras-de-desenvolvimento-com-codex.md
- docs/03-estado-atual.md
- docs/06-arquitetura-tecnica.md
- docs/07-mapa-de-telas.md
- docs/08-design-system.md
- docs/11-comandos-codex.md
- documento técnico específico da área

Implemente apenas a tarefa solicitada.

Respeite:

- stack oficial;
- camadas do projeto;
- visual aprovado;
- escopo pequeno;
- testes relevantes;
- build local quando aplicável;
- atualização de docs/03-estado-atual.md;
- commit e push.

Não faça refatorações amplas.
Não altere visual aprovado sem autorização.
Não implemente features extras.
```

## 25. modelo de comando para correção de bug

```txt
Você está trabalhando no projeto Blue Atelier.

Corrija apenas o bug descrito.

Antes de alterar arquivos:

- leia os documentos obrigatórios;
- identifique área afetada;
- tente reproduzir ou entender a causa;
- verifique alterações recentes relacionadas;
- preserve visual aprovado;
- preserve stack oficial.

Ao corrigir:

- aplique a menor alteração segura;
- não refatore fora do escopo;
- adicione ou ajuste teste se fizer sentido;
- execute validações relacionadas;
- atualize docs/03-estado-atual.md;
- faça commit e push.
```

## 26. modelo de comando para validação

```txt
Você está trabalhando no projeto Blue Atelier.

Valide a tarefa, commit ou área indicada.

Verifique:

- documentação obrigatória;
- escopo solicitado;
- arquivos alterados;
- build, se houver código;
- testes, se existirem;
- evidência visual, se houver tela;
- preservação do visual aprovado;
- atualização de docs/03-estado-atual.md;
- commit e push.

Não altere arquivos, salvo se a tarefa pedir correção.

Responda com:

- status da validação;
- achados;
- riscos;
- pendências;
- recomendação.
```

## 27. modelo de atualização do `docs/03-estado-atual.md`

Ao final de cada tarefa, atualizar:

```txt
## última tarefa realizada

[Descrição curta e clara do que foi feito.]

## decisões já tomadas

- [Adicionar apenas decisões novas, se houver.]

## pendências atuais

- [Remover a tarefa concluída.]
- [Manter pendências ainda abertas.]
- [Adicionar nova pendência se necessário.]

## arquivos alterados na última tarefa

- `[arquivo 1]`
- `[arquivo 2]`

## validações executadas na última tarefa

- [Documentos lidos.]
- [Revisões feitas.]
- [Build/testes, se houver.]
- [Git status executado.]

## próxima tarefa sugerida

Criar ou executar:

[próxima tarefa ou próximo documento]

[Descrição curta da próxima tarefa.]
```

## 28. modelo de registro de tarefa concluída

Registro resumido para resposta final:

```txt
Tarefa concluída:
[Nome da tarefa]

Resumo:
[O que foi feito]

Arquivos alterados:
- [arquivo 1]
- [arquivo 2]

Validações executadas:
- [validação 1]
- [validação 2]

Commit:
[hash] [mensagem]

Push:
Concluído para origin/main.

Próxima tarefa sugerida:
[próxima tarefa]
```

## 29. o que o Codex nunca deve fazer

O Codex nunca deve:

- trabalhar em mais de uma tarefa por vez;
- criar código quando a tarefa for documental;
- criar projeto .NET antes da etapa aprovada;
- criar telas antes da etapa aprovada;
- alterar visual aprovado sem autorização;
- mudar stack oficial sem pedido explícito;
- fazer refatoração ampla sem pedido;
- apagar documentação sem autorização;
- apagar arquivos reais do usuário;
- mover arquivos reais sem confirmação;
- ignorar `docs/03-estado-atual.md`;
- deixar de fazer commit ao final de tarefa concluída;
- deixar de fazer push ao final de tarefa concluída;
- dizer que o push foi concluído se ele falhou;
- usar Stitch como fonte final de código;
- usar Antigravity como engenheiro principal;
- avançar para próxima tarefa sem validação do ChatGPT e aprovação do usuário.

## 30. fluxo oficial de trabalho

Fluxo oficial:

1. Usuário solicita uma tarefa ou diz `continue`.
2. Codex lê a documentação obrigatória.
3. Codex identifica o escopo e a próxima tarefa.
4. Codex verifica o estado do Git.
5. Codex executa apenas a tarefa solicitada.
6. Codex valida o que for possível.
7. Codex atualiza `docs/03-estado-atual.md`.
8. Codex atualiza `docs/04-proximos-documentos.md`, se necessário.
9. Codex executa `git status`.
10. Codex adiciona os arquivos alterados.
11. Codex cria commit com mensagem adequada.
12. Codex faz push para GitHub.
13. Codex informa resumo, arquivos, validações, commit e push.
14. ChatGPT valida o repositório remoto.
15. Usuário aprova a próxima tarefa.

Regra final:

O Blue Atelier deve evoluir devagar, uma tarefa por vez, com documentação viva, commits pequenos, push obrigatório e visual protegido.
