# blue atelier - detalhe da Colecao

## 1. objetivo da tela Detalhe da Colecao

A tela Detalhe da Colecao apresenta a visao de uma colecao especifica do atelier.

Ela serve para reunir modelos, referencias, links, notas e acoes visuais relacionadas a uma linha de trabalho.

Nesta etapa, a tela usa dados mockados e nao implementa banco, servicos reais, abertura real de pasta ou criacao real de modelo.

## 2. referencia visual usada

Referencia principal:

```txt
referencias-visuais/stitch/html/03-detalhe-colecao.html
```

Referencias de apoio:

```txt
referencias-visuais/stitch/design.md
referencias-visuais/stitch/imagens/03-detalhe-colecao.png
docs/15-referencias-visuais-stitch.md
docs/17-fundacao-visual.md
docs/19-tela-colecoes.md
```

A tela foi traduzida para Razor Components e CSS proprio. O HTML exportado pelo Stitch nao foi alterado nem copiado como codigo final.

## 3. rota implementada

Rota visual implementada:

```txt
/colecoes/eldritch-horrors
```

A tela de Colecoes recebeu navegacao visual minima para permitir abrir essa rota a partir do card `Eldritch Horrors`.

## 4. arquivos alterados ou criados

Arquivos de implementacao envolvidos:

- `src/blueatelier.app/Components/Pages/DetalheColecao.razor`
- `src/blueatelier.app/Components/Pages/Colecoes.razor`
- `src/blueatelier.app/Components/Layout/AppTopbar.razor`
- `src/blueatelier.app/wwwroot/css/app.css`

Arquivos de documentacao envolvidos:

- `docs/03-estado-atual.md`
- `docs/04-proximos-documentos.md`
- `docs/21-detalhe-colecao.md`

## 5. secoes implementadas

A tela Detalhe da Colecao contem:

- navegacao de retorno para Colecoes;
- cabecalho da colecao `Eldritch Horrors`;
- status, tags, descricao curta e metadados visuais;
- area visual/banner/capa em CSS;
- acoes visuais para editar colecao, abrir pasta e criar novo modelo;
- mosaico de modelos da colecao;
- painel de links e referencias;
- galeria/referencias visuais mockadas;
- bloco de notas da colecao.

## 6. dados mockados usados

Modelos exibidos:

- Cthulhu Idol;
- Deep One Bust;
- Tentacle Beast;
- Ancient Cultist;
- Forgotten Horror;
- Abyssal Statue.

Links exibidos:

- MyMiniFactory collection;
- Painting references;
- Resin settings.

Tags exibidas:

- horror;
- creatures;
- busts;
- dark painting.

## 7. acoes visuais provisorias

Acoes presentes na tela:

- `Editar colecao`;
- `Open Folder`;
- `New Model`;
- affordance visual `Editar` nos cards de modelos.

Essas acoes sao apenas visuais/provisorias. Nenhuma persistencia, abertura real de pasta ou criacao real de modelo foi implementada.

## 8. o que ainda e provisorio

- todos os dados da tela sao mockados;
- links nao abrem destinos reais;
- galeria usa representacoes visuais em CSS;
- botoes nao executam acoes reais;
- edicao de colecao/modelo e apenas uma affordance visual;
- progresso e status dos modelos nao sao persistidos.

## 9. o que ainda nao foi implementado

Ainda nao foram implementados:

- Detalhe do Modelo;
- edicao real de colecao;
- edicao real de modelo;
- abertura real de pasta;
- criacao real de modelo;
- galeria real;
- banco SQLite;
- EF Core;
- migrations;
- servicos reais;
- sistema de arquivos real;
- busca real;
- fila de impressao real.

## 10. validacoes executadas

Validacoes de referencia:

- `referencias-visuais/stitch/design.md` foi respeitado.
- `referencias-visuais/stitch/html/03-detalhe-colecao.html` foi usado como referencia principal.
- `referencias-visuais/stitch/imagens/03-detalhe-colecao.png` foi usada como referencia visual, quando disponivel.
- Nenhum HTML do Stitch foi alterado.
- Nenhuma imagem do Stitch foi alterada.
- Nenhum `design.md` do Stitch foi alterado.

Validacoes tecnicas:

- `dotnet restore BlueAtelier.sln` executado com sucesso.
- `dotnet build BlueAtelier.sln` executado com sucesso.
- `dotnet test BlueAtelier.sln --no-build` executado com sucesso.

Validacoes de escopo:

- Home permaneceu preservada.
- Colecoes permaneceu preservada.
- Nenhuma funcionalidade real de edicao foi implementada.
- Nenhum banco, EF Core, migration, servico real ou sistema de arquivos real foi implementado.
- Tailwind, Bootstrap externo, CDN e imagens remotas nao foram usados como base do app.

## 11. confirmacao de aprovacao visual manual

O usuario validou visualmente a tela Detalhe da Colecao no estado atual.

A tela Detalhe da Colecao esta aprovada e deve ser preservada nas proximas tarefas.

## 12. proxima etapa sugerida

Implementar a tela de Detalhe do Modelo com base em:

```txt
referencias-visuais/stitch/html/04-detalhe-modelo.html
```

A proxima etapa deve preservar Home, Colecoes, Detalhe da Colecao e a fundacao visual ja aprovadas.
