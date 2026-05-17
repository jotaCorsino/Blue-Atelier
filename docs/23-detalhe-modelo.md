# blue atelier - detalhe do Modelo

## 1. objetivo da tela Detalhe do Modelo

A tela Detalhe do Modelo apresenta uma visao organizada de um modelo especifico dentro de uma colecao.

Ela concentra capa visual, status, progresso, checklist, acoes visuais, arquivos vinculados, materiais, galeria/referencias e notas do modelo.

Nesta etapa, a tela usa dados mockados e nao implementa banco, servicos reais, abertura real de pasta, envio real para fila ou edicao real.

## 2. referencia visual usada

Referencia principal:

```txt
referencias-visuais/stitch/html/04-detalhe-modelo.html
```

Referencias de apoio:

```txt
referencias-visuais/stitch/design.md
referencias-visuais/stitch/imagens/04-detalhe-modelo.png
docs/15-referencias-visuais-stitch.md
docs/17-fundacao-visual.md
docs/21-detalhe-colecao.md
docs/22-ajustes-ux-identidade-visual.md
```

A tela foi traduzida para Razor Components e CSS proprio. O HTML exportado pelo Stitch nao foi alterado nem copiado como codigo final.

## 3. rota implementada

Rota visual implementada:

```txt
/colecoes/eldritch-horrors/modelos/cthulhu-idol
```

## 4. arquivos alterados ou criados

Arquivos de implementacao envolvidos:

- `src/blueatelier.app/Components/Pages/DetalheModelo.razor`
- `src/blueatelier.app/Components/Pages/DetalheColecao.razor`
- `src/blueatelier.app/Components/Layout/AppSidebar.razor`
- `src/blueatelier.app/Components/Layout/AppTopbar.razor`
- `src/blueatelier.app/Components/Shared/AppIcon.razor`
- `src/blueatelier.app/wwwroot/css/app.css`

Arquivos de documentacao envolvidos:

- `docs/03-estado-atual.md`
- `docs/04-proximos-documentos.md`
- `docs/23-detalhe-modelo.md`

## 5. secoes implementadas

A tela Detalhe do Modelo contem:

- navegacao de retorno para `Eldritch Horrors`;
- cabecalho do modelo `Cthulhu Idol`;
- colecao relacionada;
- status, tags, descricao curta e progresso;
- area visual/capa principal em CSS;
- acoes visuais;
- informacoes do modelo;
- checklist visual/provisorio;
- arquivos vinculados;
- galeria/referencias visuais mockadas;
- materiais;
- notas do modelo.

## 6. dados mockados usados

Modelo exibido:

- Cthulhu Idol.

Colecao exibida:

- Eldritch Horrors.

Informacoes do modelo:

- Current stage: Painting;
- Progress: 70%;
- File type: STL / CTB;
- Scale: 75 mm;
- Estimated time: 6h 40m;
- Suggested material: Resin grey.

Checklist:

- Arquivo conferido;
- Suportes adicionados;
- Fatiado;
- Impresso;
- Lavado;
- Curado;
- Primer;
- Pintura.

Arquivos vinculados:

- `cthulhu-idol.stl`;
- `cthulhu-idol-supported.lys`;
- `cthulhu-idol-ready.ctb`;
- `painting-notes.md`.

Materiais:

- Resin grey;
- Primer black;
- Deep green paint;
- Purple wash.

Links:

- Dark Paint Guide;
- Inspiration Board.

## 7. acoes visuais provisorias

Acoes presentes na tela:

- `Editar modelo`;
- `Abrir pasta`;
- `Enviar para fila`;
- `Adicionar referencia`.

Essas acoes sao apenas visuais/provisorias. Nenhuma persistencia, abertura real de pasta, envio real para fila, upload real de referencia ou edicao real foi implementada.

## 8. navegacao a partir do Detalhe da Colecao

O card `Cthulhu Idol` na tela Detalhe da Colecao passou a navegar para:

```txt
/colecoes/eldritch-horrors/modelos/cthulhu-idol
```

A mudanca foi minima e preservou a aparencia aprovada do Detalhe da Colecao.

## 9. o que ainda e provisorio

- todos os dados da tela sao mockados;
- capa e thumbnails usam representacoes em CSS;
- botoes nao executam acoes reais;
- checklist nao persiste estado;
- arquivos vinculados nao abrem arquivos reais;
- materiais nao possuem cadastro real;
- links nao abrem destinos reais;
- galeria nao usa imagens reais.

## 10. o que ainda nao foi implementado

Ainda nao foram implementados:

- Galeria do Modelo;
- visualizacao de imagem;
- arquivos vinculados reais;
- edicao real de modelo;
- abertura real de pasta;
- envio real para fila;
- upload real de referencia;
- banco SQLite;
- EF Core;
- migrations;
- servicos reais;
- sistema de arquivos real;
- busca real;
- fila de impressao real.

## 11. validacoes executadas

Validacoes de referencia:

- `referencias-visuais/stitch/design.md` foi respeitado.
- `referencias-visuais/stitch/html/04-detalhe-modelo.html` foi usado como referencia principal.
- `referencias-visuais/stitch/imagens/04-detalhe-modelo.png` foi usada como referencia visual, quando disponivel.
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
- Detalhe da Colecao permaneceu preservado.
- Nenhuma funcionalidade real foi implementada.
- Nenhum banco, EF Core, migration, servico real ou sistema de arquivos real foi implementado.
- Tailwind, Bootstrap externo, CDN e imagens remotas nao foram usados como base do app.

## 12. confirmacao de aprovacao visual manual

O usuario validou visualmente a tela Detalhe do Modelo no estado atual.

A tela Detalhe do Modelo esta aprovada e deve ser preservada nas proximas tarefas.

## 13. proxima etapa sugerida

Implementar a tela de Galeria do Modelo com base em:

```txt
referencias-visuais/stitch/html/05-galeria-modelo.html
```

A proxima etapa deve preservar Home, Colecoes, Detalhe da Colecao, Detalhe do Modelo e a fundacao visual ja aprovadas.
