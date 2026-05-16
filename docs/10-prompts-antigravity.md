# blue atelier - prompts para antigravity

## 1. objetivo do documento

Este documento registra prompts para usar o **Antigravity** com economia e estratégia no desenvolvimento do **Blue Atelier**.

O Antigravity é limitado e expira rapidamente em poucas tarefas. Por isso, ele não será o engenheiro principal do projeto.

Papéis oficiais:

- **Codex** é o engenheiro principal do Blue Atelier.
- **Antigravity** é apoio estratégico para revisão, investigação e validação pontual.
- **Stitch** é apoio visual para ideação e refinamento de UI/UX.
- **GitHub** é a fonte de verdade do projeto.
- **ChatGPT** valida cada etapa pelo repositório remoto antes de liberar a próxima tarefa.

Regra operacional:

Nenhuma tarefa deve avançar para a próxima etapa sem documentação atualizada, validação possível, commit, push e revisão pelo fluxo definido.

## 2. princípios de uso

- Use o Antigravity apenas quando o ganho justificar o uso.
- Dê contexto suficiente, mas peça respostas objetivas.
- Não peça para ele refazer trabalho que o Codex pode fazer diretamente.
- Não peça para ele criar telas, código ou projeto sem tarefa aprovada.
- Não use o Antigravity para substituir validação humana do visual.
- Sempre peça relatório curto, com achados, riscos e próximos passos.
- Sempre reforce que o visual aprovado não pode ser alterado sem ordem explícita.

## 3. quando usar o antigravity

Use o Antigravity em situações estratégicas:

- revisar arquitetura antes de implementação importante;
- validar se uma tela implementada respeita o mapa de telas;
- comparar tela implementada com visual aprovado;
- verificar navegação entre áreas principais;
- revisar estrutura da solução .NET depois que ela existir;
- revisar dependências entre camadas;
- investigar bug difícil ou comportamento inconsistente;
- validar build, testes e execução local em tarefa crítica;
- revisar integração com SQLite, arquivos ou caminhos de rede;
- gerar relatório de validação antes de release local;
- auditar se o Codex cumpriu exatamente o escopo de uma tarefa.

## 4. quando não usar o antigravity

Não use o Antigravity para:

- tarefas pequenas que o Codex pode revisar sozinho;
- escrever documentação simples;
- criar código do app sem tarefa específica;
- criar projeto .NET antes da etapa aprovada;
- criar telas reais antes de visual aprovado;
- gerar CSS, Razor Components ou estrutura visual por conta própria;
- alterar design system;
- alterar prompts do Stitch sem necessidade explícita;
- mudar arquitetura, stack ou fluxo de trabalho;
- fazer refatorações amplas;
- substituir commit, push e validação pelo GitHub;
- aprovar visual sem revisão do usuário.

## 5. formato geral recomendado

Ao usar qualquer prompt, peça que o Antigravity responda neste formato:

```txt
Resumo:
Achados:
Riscos:
Recomendações:
Arquivos analisados:
Validações executadas:
O que não foi validado:
Próximos passos sugeridos:
```

Para economizar uso, peça no máximo 3 a 7 achados principais, exceto em revisão de release.

## 6. prompt - revisão geral da documentação do projeto

```txt
Objetivo:
Revisar a documentação atual do Blue Atelier e identificar inconsistências, lacunas e conflitos entre os documentos.

Contexto:
O Blue Atelier é um app Windows local, pessoal, visual, para organizar um atelier de impressão 3D. Codex é o engenheiro principal. Antigravity é apoio estratégico. Stitch é apoio visual. GitHub é a fonte de verdade.

O que o Antigravity deve verificar:
- Coerência entre descrição geral, regras do Codex, estado atual, planejamento, arquitetura, mapa de telas, design system e prompts.
- Se a documentação respeita uso pessoal, Windows local, SQLite, arquivos locais, caminhos de rede, favoritos, materiais e fila de impressão.
- Se há contradições sobre stack, visual, fluxo de trabalho ou responsabilidades das ferramentas.
- Se a próxima tarefa sugerida está correta.

O que ele não deve fazer:
- Não alterar arquivos.
- Não propor mudança de stack sem motivo forte.
- Não criar código.
- Não redesenhar visual.
- Não reescrever documentos inteiros.

Formato esperado de resposta:
Resumo curto, lista de inconsistências por severidade, sugestões objetivas e arquivos que precisam de ajuste.

Observações para economizar uso:
Priorizar inconsistências reais. Ignorar preferências de estilo pequenas.

Lembrete:
Não alterar visual aprovado sem ordem explícita. Qualquer sugestão visual deve respeitar o design system.
```

## 7. prompt - revisão da arquitetura técnica

```txt
Objetivo:
Revisar a arquitetura técnica oficial do Blue Atelier antes de iniciar ou alterar estrutura de projeto.

Contexto:
A stack oficial é .NET MAUI Blazor Hybrid, C#, SQLite, Entity Framework Core, Razor Components, CSS próprio e serviços internos. O app é local, pessoal e Windows.

O que o Antigravity deve verificar:
- Se a separação entre App, Domain, Application, Infrastructure e Persistence está clara.
- Se as dependências entre camadas fazem sentido.
- Se SQLite e EF Core são adequados para o escopo.
- Se os serviços previstos cobrem arquivos, rede, configurações, temas, favoritos, galeria e fila.
- Se há riscos técnicos antes da criação da solução.

O que ele não deve fazer:
- Não criar projeto .NET.
- Não instalar dependências.
- Não mudar a stack oficial.
- Não implementar camadas.
- Não alterar documentos sem aprovação.

Formato esperado de resposta:
Resumo, pontos fortes, riscos técnicos, ajustes recomendados e decisão: aprovado, aprovado com ressalvas ou precisa revisão.

Observações para economizar uso:
Focar em riscos que podem causar retrabalho técnico.

Lembrete:
Não alterar visual aprovado sem ordem explícita. Arquitetura não deve redefinir UI/UX.
```

## 8. prompt - revisão do mapa de telas

```txt
Objetivo:
Revisar se o mapa de telas cobre todos os fluxos necessários do Blue Atelier.

Contexto:
O app terá início, coleções, modelos, galeria, arquivos, fila de impressão, arquivos recentes, materiais, favoritos, busca e configurações.

O que o Antigravity deve verificar:
- Se as telas principais e secundárias estão cobertas.
- Se a navegação coleção > modelo > detalhes está clara.
- Se ações, estados vazios, erros, offline e sucesso aparecem onde precisam.
- Se áreas opcionais foram tratadas.
- Se mosaicos, listas, tabelas e formulários estão atribuídos corretamente.

O que ele não deve fazer:
- Não criar telas.
- Não gerar componentes.
- Não escolher visual final.
- Não alterar design system.
- Não adicionar fluxo fora do escopo pessoal do app.

Formato esperado de resposta:
Achados por tela, lacunas de navegação, riscos de UX e sugestões curtas de ajuste.

Observações para economizar uso:
Priorizar telas que geram dependência de implementação.

Lembrete:
Não alterar visual aprovado sem ordem explícita. Revisar fluxo, não redesenhar.
```

## 9. prompt - revisão do design system

```txt
Objetivo:
Revisar se o design system do Blue Atelier é implementável, coerente e protegido contra mudanças futuras indevidas.

Contexto:
O visual deve ser moderno, minimalista, neutro, confortável, inspirado em mosaicos visuais, com azul apenas como destaque e temas claro/escuro.

O que o Antigravity deve verificar:
- Se paleta, tipografia, espaçamentos, bordas e sombras são coerentes.
- Se o uso do azul está restrito a ação e destaque.
- Se tema claro e escuro são consistentes.
- Se cards, mosaicos, listas, formulários, estados e ícones têm orientação suficiente.
- Se há regras claras para proteção do visual aprovado.

O que ele não deve fazer:
- Não alterar paleta.
- Não criar CSS.
- Não gerar componentes.
- Não propor aparência corporativa.
- Não substituir aprovação visual do usuário.

Formato esperado de resposta:
Resumo, inconsistências visuais, pontos que precisam de detalhe antes da implementação e riscos de interpretação pelo Codex.

Observações para economizar uso:
Não sugerir refinamentos cosméticos sem impacto prático.

Lembrete:
Não alterar visual aprovado sem ordem explícita. Qualquer recomendação deve preservar a identidade já definida.
```

## 10. prompt - validação visual de tela implementada

```txt
Objetivo:
Validar visualmente uma tela já implementada pelo Codex.

Contexto:
A tela deve seguir o mapa de telas, o design system e, se existir, a referência visual aprovada. O Antigravity deve atuar como revisor, não como designer principal.

O que o Antigravity deve verificar:
- Se a tela respeita layout, hierarquia, espaçamento e componentes previstos.
- Se textos não estão cortados ou sobrepostos.
- Se o azul aparece apenas como destaque.
- Se tema claro e escuro funcionam, quando existirem.
- Se estados vazios, erro e offline aparecem corretamente.
- Se a tela não parece dashboard corporativo.

O que ele não deve fazer:
- Não redesenhar a tela.
- Não alterar visual por iniciativa própria.
- Não implementar correções sem autorização.
- Não aprovar tela sem apontar evidência.

Formato esperado de resposta:
Resultado da validação, evidências analisadas, problemas encontrados, severidade e recomendação de aprovar ou corrigir.

Observações para economizar uso:
Validar apenas a tela da tarefa atual e os estados diretamente relacionados.

Lembrete:
Não alterar visual aprovado sem ordem explícita. Revisão visual não autoriza mudança automática.
```

## 11. prompt - comparação entre tela implementada e visual aprovado

```txt
Objetivo:
Comparar uma tela implementada com a referência visual aprovada pelo usuário.

Contexto:
O visual aprovado é protegido. Codex não pode alterar layout, cores, espaçamentos, tipografia, componentes, hierarquia ou comportamento visual sem autorização explícita.

O que o Antigravity deve verificar:
- Diferenças entre referência aprovada e tela implementada.
- Mudanças em layout, proporção, cards, mosaicos, botões, navegação e estados.
- Uso indevido de cores, especialmente azul.
- Quebras de responsividade em janela desktop.
- Se alguma mudança técnica alterou aparência sem permissão.

O que ele não deve fazer:
- Não justificar mudança visual não autorizada.
- Não propor novo design.
- Não corrigir diretamente sem tarefa aprovada.
- Não considerar a tela aprovada se houver divergência visual relevante.

Formato esperado de resposta:
Tabela curta com item comparado, status, diferença encontrada, severidade e ação recomendada.

Observações para economizar uso:
Comparar apenas áreas visíveis na referência e na tela atual.

Lembrete:
Não alterar visual aprovado sem ordem explícita. O objetivo é proteger o visual, não reinventar.
```

## 12. prompt - revisão de navegação do app

```txt
Objetivo:
Revisar se a navegação implementada ou planejada do Blue Atelier está clara, consistente e alinhada ao mapa de telas.

Contexto:
A navegação principal deve ter início, coleções, modelos, fila de impressão, arquivos recentes, materiais, favoritos, busca e configurações.

O que o Antigravity deve verificar:
- Se a navegação lateral está estável.
- Se a barra superior apoia busca e ações contextuais.
- Se a hierarquia coleção > modelo > detalhes funciona.
- Se voltar, abrir contexto e acessar detalhes são previsíveis.
- Se favoritos rápidos e busca global não confundem a navegação.

O que ele não deve fazer:
- Não alterar rotas.
- Não criar novas áreas sem aprovação.
- Não mudar visual da navegação.
- Não sugerir menu complexo ou administrativo.

Formato esperado de resposta:
Fluxos testados, problemas de navegação, pontos de confusão e recomendações objetivas.

Observações para economizar uso:
Testar apenas os fluxos centrais da tarefa atual.

Lembrete:
Não alterar visual aprovado sem ordem explícita. Navegação aprovada também é camada protegida.
```

## 13. prompt - revisão de estrutura do projeto .NET

```txt
Objetivo:
Revisar a estrutura da solução .NET depois que ela for criada pelo Codex.

Contexto:
A solução esperada inclui projetos para App, Domain, Application, Infrastructure, Persistence e testes.

O que o Antigravity deve verificar:
- Se os projetos e pastas seguem a arquitetura oficial.
- Se nomes de projetos, namespaces e responsabilidades estão coerentes.
- Se a solução compila conforme esperado.
- Se não há código de interface nas camadas erradas.
- Se documentação e estrutura real estão alinhadas.

O que ele não deve fazer:
- Não reorganizar a solução sem tarefa aprovada.
- Não criar features.
- Não trocar .NET MAUI Blazor Hybrid por outra stack.
- Não misturar responsabilidades entre camadas.

Formato esperado de resposta:
Resumo da estrutura, desvios encontrados, riscos de manutenção e recomendações por prioridade.

Observações para economizar uso:
Focar na estrutura criada na tarefa, não revisar todo o projeto sem necessidade.

Lembrete:
Não alterar visual aprovado sem ordem explícita. Estrutura técnica não deve mexer em UI sem autorização.
```

## 14. prompt - revisão de camadas e dependências

```txt
Objetivo:
Verificar se as camadas do app respeitam dependências limpas e responsabilidades corretas.

Contexto:
A interface chama aplicação. A aplicação usa domínio e contratos. Domínio não depende de interface, banco ou sistema de arquivos. Infraestrutura e persistência implementam contratos.

O que o Antigravity deve verificar:
- Referências entre projetos.
- Uso indevido de EF Core fora da persistência.
- Acesso direto a arquivo ou Windows dentro de componentes visuais.
- Regras de domínio espalhadas na interface.
- Serviços com responsabilidades grandes demais.

O que ele não deve fazer:
- Não refatorar tudo.
- Não criar abstrações prematuras.
- Não mudar arquitetura aprovada.
- Não mover arquivos sem tarefa clara.

Formato esperado de resposta:
Achados por camada, dependência problemática, impacto e correção sugerida.

Observações para economizar uso:
Analisar somente os arquivos alterados na tarefa ou os projetos tocados.

Lembrete:
Não alterar visual aprovado sem ordem explícita. Refatoração de camada não deve mudar comportamento visual.
```

## 15. prompt - validação de build local

```txt
Objetivo:
Validar build local do Blue Atelier em uma etapa crítica.

Contexto:
O app será Windows local em .NET MAUI Blazor Hybrid. Build deve ser validado nas tarefas que criarem ou alterarem código.

O que o Antigravity deve verificar:
- Comando de build executado.
- Erros e warnings relevantes.
- Dependências ou workloads ausentes.
- Se a solução correta foi usada.
- Se o resultado permite continuar a tarefa.

O que ele não deve fazer:
- Não instalar ferramentas sem autorização.
- Não alterar código para silenciar erro sem entender causa.
- Não mudar stack.
- Não ignorar warning importante.

Formato esperado de resposta:
Comando executado, resultado, erros principais, causa provável e ação recomendada.

Observações para economizar uso:
Usar este prompt apenas quando build for parte central da tarefa.

Lembrete:
Não alterar visual aprovado sem ordem explícita. Correção de build não deve redesenhar tela.
```

## 16. prompt - validação de testes

```txt
Objetivo:
Validar testes automatizados relevantes do Blue Atelier.

Contexto:
Os testes devem cobrir domínio, aplicação, persistência, serviços de arquivos, caminhos de rede, busca, fila e backup conforme forem implementados.

O que o Antigravity deve verificar:
- Comando de teste executado.
- Testes que passaram, falharam ou foram ignorados.
- Falhas reais e causas prováveis.
- Cobertura mínima da tarefa atual.
- Lacunas críticas de teste antes do próximo passo.

O que ele não deve fazer:
- Não criar muitos testes fora do escopo.
- Não alterar implementação sem autorização.
- Não apagar teste falhando.
- Não aceitar teste frágil como validação final.

Formato esperado de resposta:
Resumo dos testes, falhas, riscos, testes faltantes e recomendação de correção.

Observações para economizar uso:
Rodar e revisar apenas testes relacionados à tarefa, salvo revisão de release.

Lembrete:
Não alterar visual aprovado sem ordem explícita. Testes não devem justificar mudança visual.
```

## 17. prompt - revisão de integração com SQLite

```txt
Objetivo:
Revisar implementação ou planejamento da persistência SQLite do Blue Atelier.

Contexto:
SQLite guarda metadados, caminhos, relações, estados, tags, links, favoritos, materiais, configurações e histórico. Arquivos pesados ficam fora do banco.

O que o Antigravity deve verificar:
- Entidades e relações implementadas.
- Uso correto de Entity Framework Core.
- Migrations e criação de banco.
- Índices importantes.
- Ausência de arquivos pesados no banco.
- Tratamento de caminhos como metadados.

O que ele não deve fazer:
- Não mudar schema sem tarefa aprovada.
- Não inserir dados reais do usuário.
- Não armazenar imagens ou arquivos no banco.
- Não reescrever persistência inteira.

Formato esperado de resposta:
Achados de modelagem, riscos de migration, problemas de performance local e recomendações.

Observações para economizar uso:
Focar nas entidades ou migrations alteradas na tarefa.

Lembrete:
Não alterar visual aprovado sem ordem explícita. Persistência não deve mudar UI sem necessidade aprovada.
```

## 18. prompt - revisão de sistema de arquivos

```txt
Objetivo:
Revisar serviços e fluxos ligados a arquivos e pastas locais do Windows.

Contexto:
O Blue Atelier funciona como camada visual sobre arquivos reais. O app deve abrir, validar, copiar e organizar arquivos sem apagar nada indevidamente.

O que o Antigravity deve verificar:
- Criação de pastas apenas em caminhos configurados.
- Validação de existência de arquivos e pastas.
- Tratamento de arquivos ausentes.
- Cópia, abertura e listagem de arquivos.
- Proteção contra operações destrutivas.
- Compatibilidade com caminhos longos e extensões relevantes.

O que ele não deve fazer:
- Não apagar arquivos.
- Não mover arquivos sem confirmação.
- Não criar estrutura fora do caminho configurado.
- Não ignorar arquivo ausente.

Formato esperado de resposta:
Riscos por operação, comportamento esperado, casos de erro e validações recomendadas.

Observações para economizar uso:
Revisar apenas serviços ou fluxos de arquivo tocados na tarefa.

Lembrete:
Não alterar visual aprovado sem ordem explícita. Estados visuais de arquivo ausente devem seguir o design system.
```

## 19. prompt - revisão de caminhos de rede

```txt
Objetivo:
Revisar suporte a caminhos de rede, unidades mapeadas e pastas compartilhadas.

Contexto:
O app deve lidar com caminhos como D:\atelier-3d\, Z:\atelier-3d\ e \\servidor\pasta\. Rede offline é condição normal.

O que o Antigravity deve verificar:
- Aceitação de caminhos locais, unidades mapeadas e UNC.
- Teste de acessibilidade.
- Registro de status online, offline ou não testado.
- Comportamento quando destino da fila está indisponível.
- Mensagens e estados para rede offline.
- Ausência de travamento quando rede falha.

O que ele não deve fazer:
- Não exigir rede para usar dados locais.
- Não bloquear todo o app por caminho offline.
- Não tentar consertar rede da máquina.
- Não alterar configurações externas do Windows sem autorização.

Formato esperado de resposta:
Casos testados, comportamento observado, riscos e ajustes necessários.

Observações para economizar uso:
Simular ou revisar apenas cenários principais de caminho offline e online.

Lembrete:
Não alterar visual aprovado sem ordem explícita. Alerta offline deve seguir o design system.
```

## 20. prompt - revisão da fila de impressão

```txt
Objetivo:
Revisar a fila de impressão do Blue Atelier como fluxo operacional.

Contexto:
A fila não controla a impressora. Ela organiza modelos e arquivos prontos, destino local ou de rede, status e histórico.

O que o Antigravity deve verificar:
- Status da fila e transições.
- Relação com modelo e arquivo vinculado.
- Cópia para destino configurado.
- Tratamento de arquivo ausente.
- Tratamento de destino offline.
- Registro de histórico e falhas.
- Proteção contra sobrescrita.

O que ele não deve fazer:
- Não tentar integrar impressora diretamente.
- Não copiar arquivos reais sem autorização.
- Não remover itens automaticamente.
- Não alterar status sem ação explícita.

Formato esperado de resposta:
Fluxos validados, riscos operacionais, casos de erro e recomendações de teste.

Observações para economizar uso:
Focar no fluxo da tarefa atual: adicionar item, enviar, falhar, marcar impresso ou validar destino.

Lembrete:
Não alterar visual aprovado sem ordem explícita. Fila deve parecer ferramenta leve, não sistema industrial.
```

## 21. prompt - revisão de configurações

```txt
Objetivo:
Revisar a área de configurações e os serviços relacionados.

Contexto:
Configurações controlam caminhos locais, caminhos de rede, tema, modelo de pastas, programas padrão e backup.

O que o Antigravity deve verificar:
- Persistência das configurações.
- Validação antes de salvar.
- Teste de caminhos sem obrigar salvar.
- Aplicação de tema dentro do design system.
- Segurança de backup, importação e exportação.
- Clareza das configurações que afetam arquivos.

O que ele não deve fazer:
- Não alterar design system.
- Não criar opções visuais livres demais.
- Não sobrescrever configurações reais sem backup.
- Não mudar caminhos do usuário sem autorização.

Formato esperado de resposta:
Resumo por categoria de configuração, riscos, validações feitas e recomendações.

Observações para economizar uso:
Revisar somente as configurações alteradas na tarefa.

Lembrete:
Não alterar visual aprovado sem ordem explícita. Configurações de aparência apenas aplicam opções aprovadas.
```

## 22. prompt - investigação de bug difícil

```txt
Objetivo:
Investigar um bug difícil, recorrente ou confuso sem espalhar mudanças pelo projeto.

Contexto:
Codex continua como engenheiro principal. Antigravity deve ajudar a entender causa raiz, reduzir hipóteses e sugerir correção segura.

O que o Antigravity deve verificar:
- Passos para reproduzir.
- Área afetada.
- Logs, mensagens de erro e comportamento observado.
- Alterações recentes relacionadas.
- Hipóteses de causa raiz.
- Menor correção possível.

O que ele não deve fazer:
- Não aplicar refatoração ampla.
- Não corrigir sintomas sem causa provável.
- Não alterar visual.
- Não tocar áreas fora do bug.
- Não apagar dados.

Formato esperado de resposta:
Reprodução, causa provável, evidências, correção mínima sugerida, riscos e teste de confirmação.

Observações para economizar uso:
Fornecer erro, arquivo, tela e passos antes de chamar o Antigravity.

Lembrete:
Não alterar visual aprovado sem ordem explícita. Correção de bug não autoriza redesenho.
```

## 23. prompt - auditoria de tarefa feita pelo codex

```txt
Objetivo:
Auditar se uma tarefa feita pelo Codex cumpriu exatamente o pedido, sem criar escopo extra.

Contexto:
Cada tarefa do Blue Atelier deve ser pequena, documentada, validada, commitada e enviada ao GitHub.

O que o Antigravity deve verificar:
- Escopo solicitado.
- Arquivos alterados.
- Se houve criação de código, tela ou CSS quando não deveria.
- Se documentação de estado foi atualizada.
- Se validações foram executadas.
- Se commit e push foram feitos.
- Se visual aprovado foi preservado.

O que ele não deve fazer:
- Não alterar os arquivos auditados.
- Não aprovar mudança fora do escopo.
- Não sugerir tarefa nova antes de fechar problemas da atual.
- Não ignorar falta de commit ou push.

Formato esperado de resposta:
Checklist de conformidade, desvios encontrados, impacto e decisão: aprovado, aprovado com ressalvas ou reprovar.

Observações para economizar uso:
Use este prompt apenas em tarefas importantes ou quando houver dúvida sobre escopo.

Lembrete:
Não alterar visual aprovado sem ordem explícita. Qualquer alteração visual não solicitada deve ser apontada.
```

## 24. prompt - geração de relatório de validação

```txt
Objetivo:
Gerar um relatório objetivo de validação de uma etapa do Blue Atelier.

Contexto:
O relatório deve apoiar a decisão de avançar ou corrigir antes da próxima tarefa. GitHub é a fonte de verdade.

O que o Antigravity deve verificar:
- Tarefa validada.
- Commit analisado.
- Arquivos alterados.
- Documentação atualizada.
- Build, testes ou revisão documental executados.
- Evidências visuais quando houver tela.
- Pendências e riscos.

O que ele não deve fazer:
- Não criar documentação nova sem pedido.
- Não alterar código.
- Não substituir validação do usuário.
- Não liberar próxima tarefa sem commit, push e revisão.

Formato esperado de resposta:
Relatório com status geral, evidências, achados, riscos, pendências e recomendação final.

Observações para economizar uso:
Pedir relatório apenas ao fim de etapas maiores ou antes de decisões importantes.

Lembrete:
Não alterar visual aprovado sem ordem explícita. O relatório deve registrar qualquer risco visual.
```

## 25. prompt - revisão antes de release local

```txt
Objetivo:
Revisar o Blue Atelier antes de uma versão local de uso real.

Contexto:
O app é pessoal, Windows local, com SQLite, arquivos reais, caminhos de rede, temas, favoritos, materiais, galerias e fila de impressão.

O que o Antigravity deve verificar:
- Build em modo adequado.
- Testes automatizados relevantes.
- Fluxos principais manuais.
- Banco SQLite e migrações.
- Backup e restauração.
- Caminhos locais e de rede.
- Fila de impressão.
- Tema claro e escuro.
- Evidências visuais.
- Documentação de execução local.

O que ele não deve fazer:
- Não empacotar release sem tarefa aprovada.
- Não mudar visual na reta final.
- Não adicionar features novas.
- Não ignorar falhas conhecidas.
- Não alterar dados reais sem backup.

Formato esperado de resposta:
Checklist de release, bloqueadores, riscos aceitáveis, evidências e recomendação: liberar, liberar com ressalvas ou corrigir antes.

Observações para economizar uso:
Usar este prompt somente em marcos importantes, não em tarefas pequenas.

Lembrete:
Não alterar visual aprovado sem ordem explícita. Release deve preservar aparência aprovada.
```

## 26. checklist antes de chamar o antigravity

Antes de gastar uma chamada no Antigravity, confirmar:

- A tarefa atual está bem definida?
- O Codex já fez a análise inicial?
- O repositório local está limpo ou as mudanças são conhecidas?
- Há commit ou diff claro para revisar?
- A dúvida não pode ser resolvida lendo a documentação?
- A saída esperada está definida?
- O Antigravity recebeu instrução para não alterar visual aprovado?

Se a resposta for não para vários itens, preparar melhor o contexto antes de usar.

## 27. regra final

O Antigravity deve ajudar a reduzir risco, não aumentar escopo.

O fluxo oficial permanece:

1. Documentação orienta a tarefa.
2. Codex executa a tarefa pequena.
3. Codex valida o que for possível.
4. Codex atualiza `docs/03-estado-atual.md`.
5. Codex faz commit.
6. Codex faz push para GitHub.
7. ChatGPT valida o repositório remoto.
8. O usuário aprova seguir para a próxima tarefa.

Stitch ajuda a imaginar o visual. Antigravity ajuda a revisar pontos estratégicos. Codex constrói e mantém o projeto.
