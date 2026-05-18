# blue atelier - fila de impressao

## objetivo da tela

A tela Fila de Impressao organiza visualmente os modelos e arquivos prontos, pendentes ou em andamento para impressao.

Nesta etapa, a tela e apenas visual e usa dados mockados. Ela prepara a experiencia futura da fila real, mas ainda nao executa nenhuma acao de impressao, leitura de arquivo, reordenacao persistida ou integracao com sistema de arquivos.

## referencia visual usada

Referencia principal:

```txt
referencias-visuais/stitch/html/08-fila-impressao.html
```

A implementacao tambem respeita:

- `referencias-visuais/stitch/design.md`
- `docs/15-referencias-visuais-stitch.md`
- `docs/17-fundacao-visual.md`
- `docs/26-ajustes-responsividade-layout.md`
- `docs/28-ajustes-arquivos-vinculados-layout.md`

## rota implementada

```txt
/fila-impressao
```

O item Fila de Impressao da sidebar foi habilitado para navegar para essa rota.

## arquivos alterados ou criados

Implementacao:

- `src/blueatelier.app/Components/Pages/FilaImpressao.razor`
- `src/blueatelier.app/Components/Layout/AppSidebar.razor`
- `src/blueatelier.app/Components/Layout/AppTopbar.razor`
- `src/blueatelier.app/Components/Shared/AppIcon.razor`
- `src/blueatelier.app/wwwroot/css/app.css`
- `src/blueatelier.app/wwwroot/css/tokens.css`
- `src/blueatelier.app/wwwroot/css/themes.css`

Documentacao:

- `docs/03-estado-atual.md`
- `docs/04-proximos-documentos.md`
- `docs/29-fila-impressao.md`

## secoes implementadas

- cabecalho da tela com titulo, descricao e status geral da fila;
- acoes visuais para adicionar, importar, reordenar e limpar concluidos;
- filtros visuais/provisorios;
- cards laterais de resumo;
- tabela/lista de itens na fila;
- estados visuais por item;
- aviso visual de condicao de arquivo/caminho;
- acoes visuais por item.

## dados mockados usados

Itens de exemplo:

- `cthulhu-idol-ready.ctb`
- `ancient-cultist.ctb`
- `dungeon-tiles.ctb`
- `abyssal-statue.ctb`
- `tentacle-beast.ctb`
- `dragon-bust.ctb`

Cada item exibe dados mockados de:

- modelo ou arquivo;
- colecao relacionada;
- destino;
- material ou resina;
- impressora;
- tempo estimado;
- prioridade;
- posicao ou data;
- status visual.

## acoes visuais provisorias

A tela apresenta acoes visuais para:

- adicionar item a fila;
- importar arquivo;
- reordenar fila;
- limpar concluidos;
- iniciar item;
- pausar item;
- editar item;
- remover item.

Essas acoes ainda nao executam nenhuma regra real.

## filtros visuais/provisorios

Filtros exibidos:

- Todos;
- Prontos;
- Em impressao;
- Pausados;
- Concluidos;
- Com erro.

Os filtros sao apenas visuais nesta etapa.

## estados visuais da fila

Estados representados:

- Em impressao;
- Pronto;
- Pausado;
- Concluido;
- Arquivo ausente;
- Com erro, quando aplicavel.

Apos revisao visual, os badges foram recalibrados para uma direcao mais limpa e azulada, evitando excesso de cores concorrentes. Verde, amarelo e vermelho ficaram reservados para estados reais de sistema.

## o que ainda e provisorio

- dados exibidos;
- filtros;
- acoes de item;
- metricas laterais;
- status da fila;
- impressoras;
- tempos estimados;
- prioridades;
- avisos de arquivo ou rede.

## o que ainda nao foi implementado

- fila real de impressao;
- leitura real de arquivos;
- abertura real de arquivo;
- inicio real de impressao;
- pausa real;
- reordenacao real;
- limpeza real de concluidos;
- persistencia;
- banco SQLite;
- EF Core;
- migrations;
- servicos reais;
- sistema de arquivos real.

## validacoes executadas

- `referencias-visuais/stitch/design.md` foi respeitado.
- `referencias-visuais/stitch/html/08-fila-impressao.html` foi usado como referencia.
- Home permaneceu preservada.
- Colecoes permaneceu preservada.
- Detalhe da Colecao permaneceu preservado.
- Detalhe do Modelo permaneceu preservado.
- Galeria do Modelo permaneceu preservada.
- Visualizacao de Imagem permaneceu preservada.
- Arquivos Vinculados permaneceu preservado.
- `/fila-impressao` abre corretamente.
- A tabela da Fila de Impressao esta alinhada.
- Os cards laterais ficaram mais compactos.
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

A tela Fila de Impressao foi validada visualmente pelo usuario e aprovada no estado atual.

Tambem foram aprovados:

- alinhamento da tabela Itens na Fila;
- compactacao dos cards laterais;
- recalibracao visual de badges/status;
- preservacao das telas anteriores;
- preservacao da fundacao visual aprovada.

## proxima etapa sugerida

Implementar a tela Arquivos Recentes com base em:

```txt
referencias-visuais/stitch/html/09-arquivos-recentes.html
```
