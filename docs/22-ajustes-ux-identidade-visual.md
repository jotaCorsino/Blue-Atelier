# blue atelier - ajustes de UX e identidade visual

## 1. motivo dos ajustes

O usuario validou o app visualmente, mas solicitou ajustes obrigatorios de UX e identidade visual antes de avancar.

Os ajustes tiveram como objetivo melhorar clareza de interacao, modernizar detalhes visuais e preparar o app para edicao futura sem implementar funcionalidades reais.

## 2. melhoria do hover dos cards

O hover dos cards clicaveis foi reforcado.

O novo comportamento usa:

- leve elevacao;
- borda/glow discreto com azul de destaque;
- sombra mais perceptivel;
- mudanca sutil de fundo;
- cursor pointer;
- transicao suave.

O ajuste foi aplicado em cards clicaveis da Home, Colecoes e Detalhe da Colecao.

## 3. regra de card inteiro clicavel

Na tela de Colecoes, o card inteiro passou a ser o elemento clicavel.

O card `Eldritch Horrors` navega para:

```txt
/colecoes/eldritch-horrors
```

Essa regra melhora a ergonomia e evita depender de um botao pequeno para abrir a colecao.

## 4. substituicao do rotulo "Acoes"

O rotulo generico `Acoes` foi removido dos cards de Colecoes.

Ele foi substituido por rotulos mais claros:

- `Ver colecao`, quando existe rota visual implementada;
- `Em breve`, quando a rota ainda nao foi implementada.

O card inteiro continua sendo a interacao principal.

## 5. padronizacao dos icones da sidebar

A sidebar deixou de usar abreviacoes de duas letras como icones.

Foi criado o componente:

```txt
src/blueatelier.app/Components/Shared/AppIcon.razor
```

Ele usa SVG inline simples, sem biblioteca externa, CDN ou Font Awesome.

Foram criados icones para:

- Inicio;
- Colecoes;
- Modelos;
- Fila de Impressao;
- Arquivos Recentes;
- Materiais;
- Favoritos;
- Busca;
- Configuracoes;
- edicao;
- pasta;
- seta.

## 6. affordances visuais para edicao futura

Foram adicionados sinais visuais de que o app permitira edicao no futuro.

Exemplos:

- affordance `Editar` nos cards de colecao;
- affordance `Editar` nos cards de modelos da tela Detalhe da Colecao;
- botao `Editar colecao` no Detalhe da Colecao.

Esses elementos ainda nao salvam dados, nao abrem formulario real e nao implementam persistencia.

## 7. atualizacao tipografica

A tipografia foi atualizada nos tokens CSS para uma stack moderna e segura de sistema.

Stack principal:

```txt
Inter, "Segoe UI Variable Text", "Segoe UI", system-ui, -apple-system, BlinkMacSystemFont, sans-serif
```

Stack para titulos:

```txt
Inter, "Segoe UI Variable Display", "Segoe UI", system-ui, sans-serif
```

Como `Inter` pode nao estar instalada, o app cai naturalmente para `Segoe UI Variable` ou `Segoe UI` no Windows.

Tambem foram ajustados tokens de tamanho, line-height e sombras de hover.

## 8. arquivos alterados

Arquivos de implementacao envolvidos:

- `src/blueatelier.app/Components/Layout/AppSidebar.razor`
- `src/blueatelier.app/Components/Pages/Colecoes.razor`
- `src/blueatelier.app/Components/Pages/DetalheColecao.razor`
- `src/blueatelier.app/Components/Shared/AppIcon.razor`
- `src/blueatelier.app/wwwroot/css/app.css`
- `src/blueatelier.app/wwwroot/css/tokens.css`

Arquivos de documentacao envolvidos:

- `docs/03-estado-atual.md`
- `docs/04-proximos-documentos.md`
- `docs/22-ajustes-ux-identidade-visual.md`

## 9. o que ainda e apenas visual/provisorio

Ainda sao apenas visuais/provisorios:

- edicao de colecoes;
- edicao de modelos;
- abertura de pasta;
- criacao de novo modelo;
- filtros;
- busca;
- navegacao para cards sem rota implementada;
- integracao com arquivos;
- persistencia de status, tags, progresso e notas.

Nenhuma funcionalidade real de edicao foi implementada nesta etapa.

## 10. validacoes executadas

- `referencias-visuais/stitch/design.md` foi respeitado.
- Home permaneceu preservada.
- Colecoes permaneceu preservada.
- Detalhe da Colecao permaneceu coerente com a referencia aprovada.
- Nenhum HTML do Stitch foi alterado.
- Nenhuma imagem do Stitch foi alterada.
- Nenhum `design.md` do Stitch foi alterado.
- Nenhum banco SQLite foi criado.
- Nenhum EF Core foi implementado.
- Nenhuma migration foi criada.
- Nenhum servico real foi implementado.
- Nenhum sistema de arquivos real foi implementado.
- Nenhuma persistencia real de edicao foi implementada.
- Nenhum CDN, Tailwind, Bootstrap ou biblioteca externa foi usado.
- `dotnet restore BlueAtelier.sln` executado com sucesso.
- `dotnet build BlueAtelier.sln` executado com sucesso.
- `dotnet test BlueAtelier.sln --no-build` executado com sucesso.

## 11. confirmacao de aprovacao visual manual

O usuario validou visualmente:

- Home;
- Colecoes;
- Detalhe da Colecao;
- hover dos cards;
- cards clicaveis;
- substituicao do texto generico `Acoes`;
- icones padronizados da sidebar;
- affordances visuais de edicao futura;
- atualizacao tipografica;
- fundacao visual atual.

Esse estado visual aprovado deve ser preservado nas proximas tarefas.
