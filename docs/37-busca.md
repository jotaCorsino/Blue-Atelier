# busca

## objetivo

Registrar a implementacao da tela Busca no Blue Atelier, consolidando uma area visual para encontrar modelos, colecoes, imagens, arquivos vinculados e links favoritos.

## referencia visual usada

A tela foi implementada com base na referencia de busca global disponivel no Stitch:

```txt
referencias-visuais/stitch/html/13-busca-global.html
referencias-visuais/stitch/imagens/13-busca-global.png
referencias-visuais/stitch/design.md
```

Observacao: o caminho `referencias-visuais/stitch/html/13-busca.html` nao existe no workspace. A referencia equivalente presente e catalogada e `13-busca-global.html`.

## rota implementada

```txt
/busca
```

## arquivos alterados ou criados

Implementacao:

- `src/blueatelier.app/Components/Pages/Busca.razor`
- `src/blueatelier.app/Components/Layout/AppSidebar.razor`
- `src/blueatelier.app/Components/Layout/AppTopbar.razor`
- `src/blueatelier.app/wwwroot/css/app.css`

Documentacao:

- `docs/03-estado-atual.md`
- `docs/04-proximos-documentos.md`
- `docs/37-busca.md`

## estrutura da tela

A tela Busca contem:

- cabecalho com titulo, descricao curta e resumo visual;
- campo principal de busca;
- sugestoes rapidas;
- filtros visuais/provisorios;
- cards de modelos relacionados;
- lista de resultados mockados;
- painel/resumo visual de busca.

## campo principal de busca

O campo principal usa placeholder:

```txt
Buscar no atelier...
```

Ele e apenas visual/mockado. O botao `Buscar` tambem e apenas visual e nao executa nenhuma consulta real.

## filtros visuais/provisorios

Filtros exibidos:

- Todos;
- Modelos;
- Colecoes;
- Imagens;
- Arquivos vinculados;
- Links favoritos.

Os filtros nao alteram resultados reais e nao possuem persistencia.

## sugestoes rapidas

Sugestoes mockadas usadas:

- Cthulhu;
- Eldritch;
- pintura;
- referencia;
- STL;
- pedra;
- wash.

## resultados mockados usados

Resultados usados na tela:

- `Cthulhu Idol`;
- `Eldritch Horrors`;
- `Main reference`;
- `cthulhu-idol.stl`;
- `painting-notes.md`;
- `Dark Paint Guide`;
- `Inspiration Board`;
- `Stone texture`;
- `Abyssal Statue`.

## navegacoes visuais habilitadas

Alguns resultados apontam para telas reais ja existentes:

- `Cthulhu Idol` navega para `/colecoes/eldritch-horrors/modelos/cthulhu-idol`;
- `Eldritch Horrors` navega para `/colecoes/eldritch-horrors`;
- `Main reference` navega para `/colecoes/eldritch-horrors/modelos/cthulhu-idol/galeria/main-reference`;
- `cthulhu-idol.stl` navega para `/colecoes/eldritch-horrors/modelos/cthulhu-idol/arquivos`.

Itens sem tela real permanecem como affordance visual.

## painel/resumo visual

O resumo visual exibe totais mockados por tipo:

- resultados;
- modelos;
- imagens;
- links.

Tambem mostra um aviso de que a busca ainda e visual, sem indice real e sem leitura de arquivos.

## o que ainda e provisorio

- campo de busca;
- botao de busca;
- filtros;
- sugestoes rapidas;
- resultados;
- score/relevancia visual;
- resumo por tipo;
- navegacoes para itens sem tela real.

## o que ainda nao foi implementado

- busca real;
- indexacao;
- banco de dados;
- EF Core;
- migrations;
- servicos reais;
- persistencia;
- sistema de arquivos real;
- leitura de arquivos reais;
- filtros reais;
- ranking real de resultados.

## areas removidas fora do escopo

As areas abaixo continuam fora do escopo atual e nao foram reintroduzidas:

- Fila de Impressao;
- Arquivos Recentes;
- Materiais;
- Detalhe do Material.

As rotas abaixo continuam inexistentes:

```txt
/fila-impressao
/arquivos-recentes
/materiais
/materiais/resin-grey
```

## validacoes executadas

- Confirmado que `referencias-visuais/stitch/design.md` foi respeitado.
- Confirmado que `referencias-visuais/stitch/html/13-busca-global.html` foi usado como referencia equivalente.
- Confirmado que `referencias-visuais/stitch/imagens/13-busca-global.png` foi consultada.
- Confirmado que `/busca` abre corretamente.
- Confirmado que a sidebar navega para `/busca`.
- Confirmado que Busca aparece como tela visual/mockada.
- Confirmado que o campo principal de busca aparece na tela.
- Confirmado que filtros visuais, sugestoes rapidas e resultados mockados aparecem na tela.
- Confirmado que as navegacoes visuais apontam para telas existentes quando aplicavel.
- Confirmado que Favoritos permaneceu preservada.
- Confirmado que a barra de links favoritos permaneceu preservada.
- Confirmado que nenhuma area removida foi reintroduzida.
- Confirmado que nenhum HTML, imagem ou `design.md` do Stitch foi alterado.
- Confirmado que nenhuma busca real foi implementada.
- Confirmado que nenhuma indexacao real foi implementada.
- Confirmado que nenhuma persistencia real foi implementada.
- `dotnet restore BlueAtelier.sln` executado com sucesso.
- `dotnet build BlueAtelier.sln` executado com sucesso.
- `dotnet test BlueAtelier.sln --no-build` executado com sucesso.

## aprovacao visual manual

A tela Busca foi validada visualmente pelo usuario e esta aprovada.

## proxima etapa sugerida

A proxima etapa deve ser definida apos conferencia das referencias visuais disponiveis.

O arquivo abaixo nao existe no workspace no estado atual:

```txt
referencias-visuais/stitch/html/14-configuracoes.html
```
