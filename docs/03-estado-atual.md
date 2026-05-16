# blue atelier — estado atual

## status geral

Projeto com base documental inicial concluída, referências visuais do Stitch catalogadas, solução base .NET MAUI Blazor Hybrid criada e fundação visual compartilhada iniciada.

A direção visual exportada do Stitch foi aprovada como base visual protegida para o Blue Atelier. A fundação visual agora possui layout base, sidebar, topbar, tokens CSS, temas claro/escuro e componentes compartilhados, mas ainda não converte a tela inicial completa do Stitch.

## repositório remoto

```txt
https://github.com/jotaCorsino/Blue-Atelier.git
```

## última tarefa realizada

Criação da fundação visual compartilhada do app, com layout base, sidebar fixa, topbar discreta, tokens CSS, temas claro/escuro, componentes base e placeholder visual usando a nova estrutura.

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
- A direção visual do Stitch foi aprovada como base visual do Blue Atelier.
- Os HTMLs exportados em `referencias-visuais/stitch/html/` são referência visual protegida.
- As imagens exportadas em `referencias-visuais/stitch/imagens/` são referência visual protegida.
- O arquivo `referencias-visuais/stitch/design.md` deve orientar a preservação do estilo aprovado.
- A anotação `referencias-visuais/stitch/anotacoes/direcao-visual-aprovada.md` reforça que o visual moderno, minimalista, neutro e confortável deve ser preservado.
- O documento `docs/15-referencias-visuais-stitch.md` cataloga as referências visuais aprovadas.
- O Codex não pode redesenhar, reinterpretar, simplificar ou alterar o visual aprovado sem autorização explícita do usuário.
- A solução base foi criada no arquivo `BlueAtelier.sln`.
- A estrutura inicial usa pastas em letras minúsculas dentro de `src/` e `tests/`.
- Os projetos criados são `BlueAtelier.App`, `BlueAtelier.Domain`, `BlueAtelier.Application`, `BlueAtelier.Infrastructure`, `BlueAtelier.Persistence` e `BlueAtelier.Tests`.
- O app inicial usa .NET MAUI Blazor Hybrid com Razor Components.
- O projeto `BlueAtelier.App` foi restringido para Windows local usando `net10.0-windows10.0.19041.0`.
- Arquivos obrigatórios do template MAUI, como `MauiProgram.cs`, `MainPage.xaml` e `App.xaml`, foram preservados com os nomes gerados pelo template.
- A tela inicial atual é apenas um placeholder de estruturação e não recria o visual aprovado do Stitch.
- O banco SQLite, EF Core, migrations, entidades completas, serviços reais, sistema de arquivos, caminhos de rede e telas finais ainda não foram implementados.
- A estrutura da solução foi documentada em `docs/16-estrutura-da-solucao.md`.
- A fundação visual foi iniciada após a criação da solução base.
- O CSS visual foi reorganizado em `src/blueatelier.app/wwwroot/css/`.
- Os tokens visuais iniciais foram definidos em `src/blueatelier.app/wwwroot/css/tokens.css`.
- Os temas claro e escuro foram definidos em `src/blueatelier.app/wwwroot/css/themes.css`.
- O layout base foi definido em `src/blueatelier.app/Components/Layout/MainLayout.razor`.
- A sidebar foi criada em `src/blueatelier.app/Components/Layout/AppSidebar.razor`.
- A topbar foi criada em `src/blueatelier.app/Components/Layout/AppTopbar.razor`.
- Os componentes base `AppCard`, `AppBadge` e `AppButton` foram criados em `src/blueatelier.app/Components/Shared/`.
- A Home atual virou um placeholder visual da fundação, sem implementar o dashboard real.
- As cores roxas padrão do template MAUI foram substituídas por azul coerente com o Blue Atelier.
- A fundação visual foi documentada em `docs/17-fundacao-visual.md`.
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

- Implementar a tela inicial real do Blue Atelier com base em `referencias-visuais/stitch/html/01-inicio.html` e na fundação visual criada.
- Manter os HTMLs, imagens e `design.md` do Stitch protegidos contra alterações não autorizadas.
- Validar o repositório remoto após o push desta tarefa.

## arquivos alterados ou criados na última tarefa

- `docs/03-estado-atual.md`
- `docs/04-proximos-documentos.md`
- `docs/17-fundacao-visual.md`
- `src/blueatelier.app/BlueAtelier.App.csproj`
- `src/blueatelier.app/Components/_Imports.razor`
- `src/blueatelier.app/Components/Layout/MainLayout.razor`
- `src/blueatelier.app/Components/Layout/AppSidebar.razor`
- `src/blueatelier.app/Components/Layout/AppTopbar.razor`
- `src/blueatelier.app/Components/Shared/AppCard.razor`
- `src/blueatelier.app/Components/Shared/AppBadge.razor`
- `src/blueatelier.app/Components/Shared/AppButton.razor`
- `src/blueatelier.app/Components/Pages/Home.razor`
- `src/blueatelier.app/wwwroot/css/tokens.css`
- `src/blueatelier.app/wwwroot/css/themes.css`
- `src/blueatelier.app/wwwroot/css/app.css`
- `src/blueatelier.app/wwwroot/index.html`
- `src/blueatelier.app/Resources/AppIcon/appicon.svg`
- `src/blueatelier.app/Resources/AppIcon/appiconfg.svg`
- `src/blueatelier.app/Resources/Splash/splash.svg`

## validações executadas na última tarefa

- Leitura obrigatória dos documentos `docs/01-descricao-geral-do-app.md`, `docs/02-regras-de-desenvolvimento-com-codex.md`, `docs/03-estado-atual.md` e `docs/04-proximos-documentos.md`.
- Leitura obrigatória do documento `docs/05-planejamento-de-desenvolvimento.md`.
- Leitura obrigatória do documento `docs/06-arquitetura-tecnica.md`.
- Leitura obrigatória do documento `docs/07-mapa-de-telas.md`.
- Leitura obrigatória do documento `docs/08-design-system.md`.
- Leitura obrigatória do documento `docs/14-checklist-de-validacao.md`.
- Leitura obrigatória do documento `docs/15-referencias-visuais-stitch.md`.
- Leitura obrigatória do documento `docs/16-estrutura-da-solucao.md`.
- Leitura obrigatória de `referencias-visuais/stitch/readme.md`.
- Leitura de `referencias-visuais/stitch/design.md`.
- Leitura de `referencias-visuais/stitch/anotacoes/direcao-visual-aprovada.md`.
- Leitura obrigatória de `referencias-visuais/stitch/html/01-inicio.html`.
- Criação do layout base do app.
- Criação da sidebar fixa com os itens principais previstos.
- Criação da topbar discreta com busca visual provisória.
- Criação dos componentes base `AppCard`, `AppBadge` e `AppButton`.
- Criação de tokens CSS iniciais.
- Criação de tema claro.
- Criação de tema escuro.
- Substituição visual do placeholder técnico anterior por placeholder visual usando a nova estrutura.
- Substituição das cores roxas padrão do template MAUI por azul coerente com o Blue Atelier.
- Confirmação de que nenhum HTML do Stitch foi alterado.
- Confirmação de que nenhuma imagem do Stitch foi alterada.
- Confirmação de que nenhuma tela completa do Stitch foi convertida.
- Execução de `dotnet restore BlueAtelier.sln` com sucesso.
- Execução de `dotnet build BlueAtelier.sln` com sucesso, 0 avisos e 0 erros.
- Execução de `dotnet test BlueAtelier.sln --no-build` com sucesso, 1 teste aprovado.
- Evidência visual descrita: placeholder com shell do app, sidebar fixa, topbar discreta, cards, badges e botões base.

## próxima tarefa sugerida

Implementar a tela inicial real do Blue Atelier com base em `referencias-visuais/stitch/html/01-inicio.html` e na fundação visual criada.

Essa etapa deve respeitar `docs/06-arquitetura-tecnica.md`, `docs/07-mapa-de-telas.md`, `docs/08-design-system.md`, `docs/14-checklist-de-validacao.md`, `docs/15-referencias-visuais-stitch.md`, `docs/16-estrutura-da-solucao.md` e `docs/17-fundacao-visual.md`. A implementação futura não pode redesenhar ou reinterpretar o visual aprovado sem autorização explícita.
