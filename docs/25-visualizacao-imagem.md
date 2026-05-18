# blue atelier - visualizacao de imagem

## objetivo da tela

A tela Visualizacao de Imagem apresenta uma imagem ou referencia visual individual da galeria de um modelo, mantendo contexto de colecao, modelo, categoria, metadados e acoes visuais futuras.

Nesta etapa, a tela e apenas visual. Ela usa dados mockados e representacao em CSS, sem ler arquivos reais e sem persistencia.

## referencia visual usada

Referencia principal:

```txt
referencias-visuais/stitch/html/06-visualizacao-imagem.html
```

Tambem foram respeitados:

- `referencias-visuais/stitch/design.md`
- `referencias-visuais/stitch/imagens/06-visualizacao-imagem.png`, quando disponivel
- `docs/15-referencias-visuais-stitch.md`
- `docs/17-fundacao-visual.md`
- `docs/22-ajustes-ux-identidade-visual.md`
- `docs/24-galeria-modelo.md`

## rota implementada

```txt
/colecoes/eldritch-horrors/modelos/cthulhu-idol/galeria/main-reference
```

## arquivos alterados ou criados

Implementacao:

- `src/blueatelier.app/Components/Layout/AppSidebar.razor`
- `src/blueatelier.app/Components/Layout/AppTopbar.razor`
- `src/blueatelier.app/Components/Pages/GaleriaModelo.razor`
- `src/blueatelier.app/Components/Pages/VisualizacaoImagem.razor`
- `src/blueatelier.app/Components/Shared/AppIcon.razor`
- `src/blueatelier.app/wwwroot/css/app.css`

Documentacao:

- `docs/03-estado-atual.md`
- `docs/04-proximos-documentos.md`
- `docs/25-visualizacao-imagem.md`
- `docs/26-ajustes-responsividade-layout.md`

## secoes implementadas

- navegacao de retorno para a Galeria;
- barra compacta de anterior/proxima com contador visual;
- area principal de visualizacao com mock em CSS;
- painel de informacoes da imagem;
- dados de modelo, colecao, categoria, origem, status e atualizacao;
- acoes visuais provisorias;
- tags e notas rapidas;
- miniaturas de navegacao visual.

## dados mockados usados

- titulo: Main reference;
- modelo: Cthulhu Idol;
- colecao: Eldritch Horrors;
- categoria: Referencias;
- contador: 1 de 8;
- origem: Pasta de referencias;
- status: Referencia principal;
- tags: pedra, desgaste, estatua, pintura;
- miniaturas mockadas: Printed front view, Primer test, Green base coat e Final angle.

## acoes visuais provisorias

- Editar informacoes;
- Definir como capa;
- Abrir arquivo;
- Remover da galeria;
- Anterior;
- Proxima.

Todas as acoes sao visuais/provisorias. Nenhuma delas executa operacao real.

## navegacao a partir da Galeria do Modelo

A tela Galeria do Modelo passou a permitir acesso visual para a nova rota pelo item `Main reference`.

A alteracao foi minima e preservou a aparencia aprovada da Galeria do Modelo.

## o que ainda e provisorio

- dados exibidos;
- miniaturas;
- contador de imagens;
- acoes de edicao;
- definicao de capa;
- abertura de arquivo;
- remocao da galeria;
- navegacao anterior/proxima.

## o que ainda nao foi implementado

- leitura real de imagem;
- abertura real de arquivo;
- remocao real;
- edicao real;
- definicao real de capa;
- persistencia;
- banco SQLite;
- EF Core;
- migrations;
- servicos reais;
- sistema de arquivos real.

## validacoes executadas

- `referencias-visuais/stitch/design.md` foi respeitado.
- `referencias-visuais/stitch/html/06-visualizacao-imagem.html` foi usado como referencia.
- Home permaneceu preservada.
- Colecoes permaneceu preservada.
- Detalhe da Colecao permaneceu preservado.
- Detalhe do Modelo permaneceu preservado.
- Galeria do Modelo permaneceu preservada.
- Visualizacao de Imagem foi aprovada visualmente.
- Nenhum HTML do Stitch foi alterado.
- Nenhuma imagem do Stitch foi alterada.
- Nenhum `design.md` do Stitch foi alterado.
- Nenhuma funcionalidade real foi implementada.
- Nenhum banco, EF Core, migration, servico real ou sistema de arquivos real foi implementado.
- Nenhum CDN, Tailwind, Bootstrap ou biblioteca externa foi usado.
- `dotnet restore BlueAtelier.sln` executado com sucesso.
- `dotnet build BlueAtelier.sln` executado com sucesso.
- `dotnet test BlueAtelier.sln --no-build` executado com sucesso.

## confirmacao de aprovacao visual manual

O usuario validou visualmente a tela Visualizacao de Imagem, a navegacao a partir da Galeria do Modelo e a preservacao das telas ja aprovadas.

Tambem foram aprovados o refinamento da barra anterior/proxima e a correcao de distorcao de capas, thumbnails e imagens mockadas.

## proxima etapa sugerida

Implementar a tela de Arquivos Vinculados com base em:

```txt
referencias-visuais/stitch/html/07-arquivos-vinculados.html
```

Essa proxima etapa deve preservar todas as telas ja aprovadas e continuar usando dados mockados ate a etapa propria de persistencia e sistema de arquivos.
