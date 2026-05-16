# blue atelier - fundacao visual

## 1. objetivo da fundacao visual

Este documento registra a fundacao visual compartilhada criada para o **Blue Atelier** dentro do projeto .NET MAUI Blazor Hybrid.

O objetivo desta etapa foi preparar uma base reutilizavel para as proximas telas, sem implementar o dashboard final, sem converter todos os HTMLs do Stitch e sem alterar as referencias visuais aprovadas.

Esta fundacao cria:

- layout base do app;
- sidebar fixa;
- topbar discreta;
- area principal de conteudo;
- tokens CSS iniciais;
- tema claro;
- tema escuro;
- componentes visuais base;
- placeholder visual usando a nova estrutura.

## 2. arquivos criados ou alterados

Arquivos principais alterados:

```txt
src/blueatelier.app/Components/Layout/MainLayout.razor
src/blueatelier.app/Components/Layout/AppSidebar.razor
src/blueatelier.app/Components/Layout/AppTopbar.razor
src/blueatelier.app/Components/Shared/AppCard.razor
src/blueatelier.app/Components/Shared/AppBadge.razor
src/blueatelier.app/Components/Shared/AppButton.razor
src/blueatelier.app/Components/Pages/Home.razor
src/blueatelier.app/Components/_Imports.razor
src/blueatelier.app/wwwroot/css/tokens.css
src/blueatelier.app/wwwroot/css/themes.css
src/blueatelier.app/wwwroot/css/app.css
src/blueatelier.app/wwwroot/index.html
src/blueatelier.app/BlueAtelier.App.csproj
src/blueatelier.app/Resources/AppIcon/appicon.svg
src/blueatelier.app/Resources/AppIcon/appiconfg.svg
src/blueatelier.app/Resources/Splash/splash.svg
```

Arquivos de documentacao atualizados:

```txt
docs/03-estado-atual.md
docs/04-proximos-documentos.md
docs/17-fundacao-visual.md
```

O arquivo antigo `src/blueatelier.app/wwwroot/app.css` foi substituido pela estrutura em `wwwroot/css/`.

## 3. componentes base criados

### MainLayout

Arquivo:

```txt
src/blueatelier.app/Components/Layout/MainLayout.razor
```

Define o shell principal:

- sidebar lateral;
- workspace principal;
- topbar;
- area de conteudo `@Body`.

### AppSidebar

Arquivo:

```txt
src/blueatelier.app/Components/Layout/AppSidebar.razor
```

Define a navegacao lateral fixa com os itens:

- Inicio;
- Colecoes;
- Modelos;
- Fila de Impressao;
- Arquivos Recentes;
- Materiais;
- Favoritos;
- Busca;
- Configuracoes.

Nesta etapa, apenas `Inicio` aponta para uma rota real. Os outros itens sao visuais e ficam preparados para rotas futuras.

### AppTopbar

Arquivo:

```txt
src/blueatelier.app/Components/Layout/AppTopbar.razor
```

Define a barra superior discreta com:

- campo de busca visual provisoria;
- indicador de status da fundacao visual.

A busca ainda nao executa nenhuma acao real.

### AppCard

Arquivo:

```txt
src/blueatelier.app/Components/Shared/AppCard.razor
```

Componente base para superficies visuais com:

- borda suave;
- sombra discreta;
- cabecalho opcional;
- conteudo via `ChildContent`.

### AppBadge

Arquivo:

```txt
src/blueatelier.app/Components/Shared/AppBadge.razor
```

Componente base para status curtos.

Tons iniciais:

- `neutral`;
- `accent`;
- `success`;
- `warning`;
- `error`.

### AppButton

Arquivo:

```txt
src/blueatelier.app/Components/Shared/AppButton.razor
```

Componente base para botoes visuais.

Variantes iniciais:

- `primary`;
- `ghost`.

## 4. tokens CSS definidos

Arquivo:

```txt
src/blueatelier.app/wwwroot/css/tokens.css
```

Tokens iniciais:

- familia de fonte;
- tamanhos de fonte;
- altura de linha;
- largura da sidebar;
- escala de espacamento;
- raios de borda;
- sombras;
- azul de destaque;
- tons de sucesso;
- tons de aviso;
- tons de erro.

O azul foi definido a partir da referencia aprovada:

```txt
#0058be
```

## 5. estrategia de tema claro

Arquivo:

```txt
src/blueatelier.app/wwwroot/css/themes.css
```

O tema claro usa:

- fundo neutro off-white;
- superficies brancas;
- bordas suaves;
- texto principal escuro;
- texto secundario cinza;
- azul apenas para destaque, foco ou acao.

Esses valores seguem a direcao do `design.md` exportado do Stitch.

## 6. estrategia de tema escuro

O tema escuro foi preparado com:

- fundo escuro neutro;
- sidebar mais escura;
- cards em superficie escura;
- bordas discretas;
- texto principal claro;
- texto secundario cinza;
- azul preservado como destaque.

Nesta etapa, o tema escuro responde a `prefers-color-scheme: dark` e tambem pode ser ativado futuramente com `data-theme="dark"`.

Ainda nao ha alternador de tema implementado.

## 7. como a sidebar foi estruturada

A sidebar segue a referencia do Stitch:

- largura base de `260px`;
- marca Blue Atelier no topo;
- navegacao vertical;
- item ativo com fundo suave;
- item ativo com barra azul lateral;
- icones textuais provisórios;
- comportamento compacto em janelas menores.

Os itens futuros ainda nao possuem paginas reais.

## 8. como a topbar foi estruturada

A topbar segue a referencia do Stitch:

- altura discreta;
- busca visual na esquerda;
- indicador de status na direita;
- fundo com leve transparencia;
- borda inferior suave;
- sem excesso de acoes.

A busca ainda e apenas visual.

## 9. o que foi inspirado no Stitch

Inspiracoes usadas:

- sidebar fixa de `01-inicio.html`;
- topbar com busca discreta;
- cards com superficie elevada;
- sombra suave;
- bordas arredondadas;
- espacamento generoso;
- azul apenas como destaque;
- tema escuro do `01-inicio.html`;
- tokens e personalidade visual do `design.md`;
- regra de nao transformar o app em dashboard corporativo.

O HTML do Stitch nao foi copiado para dentro do app. A estrutura foi traduzida manualmente para Razor Components e CSS proprio.

## 10. o que ainda nao foi implementado

Ainda nao foi implementado:

- tela inicial real;
- dashboard completo;
- mosaicos reais;
- dados reais;
- rotas das demais telas;
- navegacao completa;
- alternador de tema;
- busca real;
- banco SQLite;
- entidades completas;
- servicos reais;
- sistema de arquivos;
- fila de impressao real;
- configuracoes reais.

## 11. limites para proximas tarefas visuais

Proximas tarefas visuais devem:

- respeitar `referencias-visuais/stitch/design.md`;
- respeitar `referencias-visuais/stitch/html/01-inicio.html`;
- usar os componentes e tokens criados nesta fundacao;
- evitar duplicar estilos sem necessidade;
- nao alterar HTMLs ou imagens do Stitch;
- nao redesenhar identidade visual aprovada;
- implementar uma tela por vez;
- gerar evidencia visual quando possivel.

O Codex nao deve mudar sidebar, topbar, tokens principais, cards ou uso do azul sem autorizacao explicita.

## 12. validacoes executadas

Validacoes da tarefa:

- `referencias-visuais/stitch/design.md` foi lido.
- `referencias-visuais/stitch/html/01-inicio.html` foi consultado como referencia.
- Nenhum HTML do Stitch foi alterado.
- Nenhuma imagem do Stitch foi alterada.
- Nenhuma tela completa foi convertida.
- A Home atual e apenas placeholder visual.
- Nao foi implementado banco SQLite.
- Nao foram implementadas entidades completas.
- Nao foram implementados servicos reais.
- Nao foi implementado sistema de arquivos.
- Nao foi implementada fila de impressao real.
- `dotnet restore BlueAtelier.sln` foi executado com sucesso.
- `dotnet build BlueAtelier.sln` foi executado com sucesso, com 0 avisos e 0 erros.
- `dotnet test BlueAtelier.sln --no-build` foi executado com sucesso, com 1 teste aprovado.
- Evidencia visual descrita: a Home provisoria usa o shell com sidebar fixa, topbar discreta, cards, badges e botoes base.

Observacao:

O restore e o build podem exigir permissao fora do sandbox para ler o `NuGet.Config` do usuario.

## 13. proxima etapa sugerida

A proxima etapa sugerida e implementar a tela inicial real do Blue Atelier com base em:

```txt
referencias-visuais/stitch/html/01-inicio.html
```

Essa implementacao deve usar a fundacao visual criada nesta tarefa e ainda deve evitar converter todas as telas do Stitch de uma vez.
