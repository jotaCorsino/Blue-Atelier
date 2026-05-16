# blue atelier — estado atual

## status geral

Projeto com base documental inicial concluída, pronto para iniciar a fase visual com Stitch para criação do primeiro conceito visual geral do Blue Atelier.

## repositório remoto

```txt
https://github.com/jotaCorsino/Blue-Atelier.git
```

## última tarefa realizada

Criação do checklist de validação do Blue Atelier, definindo critérios para validar tarefas documentais, arquitetura, UI/UX planejada, design system, prompts, comandos, banco, sistema de arquivos, solução .NET, camadas, domínio, SQLite, migrations, serviços, arquivos, rede, fila, configurações, busca, favoritos, materiais, galeria, telas, visual, temas, estados, testes, build, commit, push e release local.

## decisões já tomadas

- O app se chamará Blue Atelier.
- Será um app Windows local.
- Será de uso pessoal e exclusivo do atelier.
- Não será comercializado.
- O app deve ser completo, não apenas um MVP.
- A navegação principal deve ser visual, em formato de mosaico.
- O app deve organizar coleções, modelos, galerias, links, arquivos, materiais, favoritos, configurações e fila de impressão.
- O app deve facilitar organização real de pastas no computador.
- O app deve suportar caminhos locais e caminhos de rede.
- O app deve ter área de configurações para caminhos, rede, tema, backups e modelo padrão de pastas.
- O app deve ter área de favoritos globais, estilo favoritos do navegador.
- A stack oficial será .NET MAUI Blazor Hybrid, C#, SQLite, Entity Framework Core, Razor Components e CSS próprio.
- A arquitetura deve separar interface, domínio, aplicação, infraestrutura e persistência.
- Arquivos pesados devem ficar no sistema de arquivos; o banco SQLite deve guardar metadados, caminhos, relações e estados.
- Antigravity deve ser usado com economia em momentos estratégicos, enquanto o Codex permanece como engenheiro principal.
- O mapa de telas oficial foi definido em `docs/07-mapa-de-telas.md`.
- A hierarquia principal de navegação será coleção > modelo > detalhes do modelo.
- Coleções, modelos e galerias devem priorizar mosaicos visuais; arquivos, fila, caminhos e configurações podem usar listas, tabelas e formulários.
- O design system oficial foi definido em `docs/08-design-system.md`.
- A linguagem visual deve ser moderna, minimalista, neutra, confortável e inspirada em mosaicos visuais.
- O azul deve ser usado apenas como cor de destaque e ação, sem dominar a interface.
- O app deve ter tema claro e tema escuro coerentes.
- O Stitch será usado apenas para ideação visual e refinamento de UI/UX, não como fonte final de código.
- Os prompts para Stitch foram registrados em `docs/09-prompts-stitch.md`.
- O Antigravity será usado apenas como apoio estratégico, não como engenheiro principal do projeto.
- Os prompts para Antigravity foram registrados em `docs/10-prompts-antigravity.md`.
- Os comandos operacionais do Codex foram registrados em `docs/11-comandos-codex.md`.
- A modelagem do banco SQLite foi definida em `docs/12-modelagem-do-banco.md`.
- O banco SQLite deve guardar apenas metadados, relações, caminhos, status, tags, links, favoritos, materiais, configurações e histórico.
- Arquivos pesados devem permanecer fora do banco, no sistema de arquivos.
- A documentação do sistema de arquivos foi definida em `docs/13-sistema-de-arquivos.md`.
- O app deve funcionar como camada visual e operacional sobre arquivos reais do Windows.
- Remover vínculo no app não deve excluir o arquivo real.
- Caminhos de rede offline devem ser tratados como condição normal e não podem travar o app.
- Arquivos e pastas ausentes devem permanecer registrados até correção ou remoção explícita do vínculo.
- Operações perigosas, como mover, sobrescrever ou excluir arquivos reais, devem exigir confirmação futura.
- O checklist de validação foi definido em `docs/14-checklist-de-validacao.md`.
- A base documental inicial do projeto foi concluída.
- Toda tarefa futura deve ser validada conforme o checklist aplicável antes de avançar.
- Tarefas de implementação devem executar build quando possível.
- Tarefas com testes devem executar testes relevantes.
- Tarefas visuais futuras devem fornecer evidência visual.
- GitHub permanece como fonte de verdade e ChatGPT valida cada etapa pelo repositório remoto.
- Nenhuma tarefa deve avançar sem commit, push e validação.
- O desenvolvimento será feito uma tarefa por vez.
- O Codex será usado como engenheiro de implementação.
- O visual aprovado não pode ser alterado pelo Codex sem autorização explícita.
- Ao final de cada tarefa, o Codex deve atualizar documentação, fazer commit e push.

## pendências atuais

- Iniciar fase visual com Stitch para criação do primeiro conceito visual geral do Blue Atelier.
- Validar o repositório remoto após o push desta tarefa.

## arquivos alterados na última tarefa

- `docs/03-estado-atual.md`
- `docs/04-proximos-documentos.md`
- `docs/14-checklist-de-validacao.md`

## validações executadas na última tarefa

- Leitura obrigatória dos documentos `docs/01-descricao-geral-do-app.md`, `docs/02-regras-de-desenvolvimento-com-codex.md`, `docs/03-estado-atual.md` e `docs/04-proximos-documentos.md`.
- Leitura obrigatória do documento `docs/05-planejamento-de-desenvolvimento.md`.
- Leitura obrigatória do documento `docs/06-arquitetura-tecnica.md`.
- Leitura obrigatória do documento `docs/07-mapa-de-telas.md`.
- Leitura obrigatória do documento `docs/08-design-system.md`.
- Leitura obrigatória do documento `docs/09-prompts-stitch.md`.
- Leitura obrigatória do documento `docs/10-prompts-antigravity.md`.
- Leitura obrigatória do documento `docs/11-comandos-codex.md`.
- Leitura obrigatória do documento `docs/12-modelagem-do-banco.md`.
- Leitura obrigatória do documento `docs/13-sistema-de-arquivos.md`.
- Revisão documental do checklist de validação criado.
- Atualização do índice de próximos documentos.
- Verificação de status do Git antes das alterações.

## próxima tarefa sugerida

Iniciar a fase visual com Stitch para criação do primeiro conceito visual geral do Blue Atelier.

Essa etapa deve usar o prompt mestre de `docs/09-prompts-stitch.md`, respeitar `docs/07-mapa-de-telas.md` e `docs/08-design-system.md`, e gerar uma primeira proposta visual para avaliação do usuário antes de qualquer implementação de tela.
