# blue atelier - tela de colecoes

## 1. objetivo da tela de Colecoes

A tela de Colecoes organiza visualmente linhas, temas e grupos de modelos do atelier.

Ela e a segunda tela real implementada no Blue Atelier, apos a Home, e fica acessivel pela rota:

```txt
/colecoes
```

Nesta etapa, a tela usa dados mockados e nao implementa persistencia, filtros reais, busca real ou navegacao para detalhe de colecao.

## 2. referencia visual usada

Referencia principal:

```txt
referencias-visuais/stitch/html/02-colecoes.html
```

Referencias de apoio:

```txt
referencias-visuais/stitch/design.md
referencias-visuais/stitch/imagens/02-colecoes.png
docs/15-referencias-visuais-stitch.md
docs/17-fundacao-visual.md
```

A tela foi traduzida para Razor Components e CSS proprio. O HTML exportado pelo Stitch nao foi copiado como codigo final.

## 3. arquivos alterados ou criados

Arquivos de implementacao envolvidos:

- `src/blueatelier.app/Components/Layout/AppSidebar.razor`
- `src/blueatelier.app/Components/Layout/AppTopbar.razor`
- `src/blueatelier.app/Components/Pages/Colecoes.razor`
- `src/blueatelier.app/wwwroot/css/app.css`

Arquivos de documentacao envolvidos:

- `docs/03-estado-atual.md`
- `docs/04-proximos-documentos.md`
- `docs/19-tela-colecoes.md`

## 4. secoes implementadas

A tela de Colecoes contem:

- cabecalho com titulo `Colecoes`;
- subtitulo curto explicando a organizacao de linhas, temas e grupos de modelos;
- filtros visuais em formato de pills;
- ordenacao visual provisoria;
- mosaico de colecoes;
- cards com area visual/capa;
- titulo, descricao, quantidade de modelos, status, tags e data de atualizacao;
- acao visual discreta por card;
- estado vazio preparado, mas nao exibido no estado atual.

## 5. dados mockados usados

Colecoes exibidas:

- Eldritch Horrors;
- Sci-Fi Marines;
- Fantasy Adventurers;
- Dragon Busts;
- Tavern Dioramas;
- Ancient Ruins;
- Painting Studies;
- Miniature Bases.

Filtros visuais:

- Todas;
- Em andamento;
- Prontas;
- Pausadas;
- Arquivadas.

Opcoes de ordenacao visual:

- Atualizadas recentemente;
- Nome;
- Quantidade de modelos;
- Status.

## 6. alteracao na sidebar

A sidebar foi atualizada para que o item Colecoes navegue para:

```txt
/colecoes
```

O item Inicio continua navegando para:

```txt
/
```

Os demais itens permanecem visuais/provisorios e nao implementam telas reais nesta etapa.

## 7. alteracao na topbar contextual

A topbar passou a identificar a rota `/colecoes`.

Quando a tela de Colecoes esta ativa, a topbar exibe:

- busca visual com placeholder `Buscar colecoes...`;
- botao secundario `Importar pasta`;
- botao primario `+ Nova colecao`.

Esses elementos sao visuais/provisorios. Nenhuma busca real, importacao real ou criacao real de colecao foi implementada.

## 8. o que ainda e provisorio

- filtros sao visuais e nao filtram dados reais;
- ordenacao e visual e nao altera a lista;
- busca local e visual/provisoria;
- botoes nao executam acoes reais;
- cards nao abrem detalhe de colecao;
- dados sao mockados;
- capas sao representacoes visuais em CSS, nao arquivos reais.

## 9. o que ainda nao foi implementado

Ainda nao foram implementados:

- Detalhe da Colecao;
- criacao real de colecao;
- edicao real de colecao;
- importacao real de pasta;
- filtros persistidos;
- busca real;
- banco SQLite;
- EF Core;
- migrations;
- servicos reais;
- sistema de arquivos real;
- integracao com caminhos locais ou de rede.

## 10. validacoes executadas

Validacoes de referencia:

- `referencias-visuais/stitch/design.md` foi respeitado.
- `referencias-visuais/stitch/html/02-colecoes.html` foi usado como referencia principal.
- `referencias-visuais/stitch/imagens/02-colecoes.png` foi usada como referencia visual, quando disponivel.
- Nenhum HTML do Stitch foi alterado.
- Nenhuma imagem do Stitch foi alterada.

Validacoes tecnicas:

- `dotnet restore BlueAtelier.sln` executado com sucesso.
- `dotnet build BlueAtelier.sln` executado com sucesso.
- `dotnet test BlueAtelier.sln --no-build` executado com sucesso.

Validacoes de escopo:

- somente a tela de Colecoes foi adicionada como nova tela real;
- nenhuma tela de detalhe foi implementada;
- nenhum banco, EF Core, migration, servico real ou sistema de arquivos real foi implementado;
- Tailwind, Bootstrap externo, CDN e imagens remotas nao foram usados como base do app.

## 11. confirmacao de aprovacao visual manual

O usuario validou visualmente a tela de Colecoes no estado atual do working tree.

A tela de Colecoes esta aprovada e deve ser tratada como referencia protegida para as proximas tarefas.

## 12. proxima etapa sugerida

Implementar a tela de Detalhe da Colecao com base em:

```txt
referencias-visuais/stitch/html/03-detalhe-colecao.html
```

A proxima etapa deve preservar a tela de Colecoes aprovada e nao alterar o visual sem autorizacao explicita.
