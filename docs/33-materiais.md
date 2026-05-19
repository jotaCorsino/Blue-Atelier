# blue atelier - materiais

## objetivo da tela Materiais

A tela Materiais apresenta um inventario visual do atelier para resinas, tintas, primers, ferramentas e consumiveis.

Nesta etapa, a tela e apenas visual e usa dados mockados. Ela prepara o controle futuro de estoque e uso de materiais, mas ainda nao cadastra, baixa, atualiza ou persiste nenhum dado real.

## referencia visual usada

Referencia principal:

```txt
referencias-visuais/stitch/html/10-materiais.html
```

Tambem foram respeitados:

- `referencias-visuais/stitch/design.md`
- `referencias-visuais/stitch/imagens/10-materiais.png`
- `docs/15-referencias-visuais-stitch.md`
- `docs/17-fundacao-visual.md`
- `docs/30-ajustes-paleta-visual.md`
- `docs/32-arquivos-recentes.md`

## rota implementada

```txt
/materiais
```

## arquivos alterados ou criados

Implementacao:

- `src/blueatelier.app/Components/Layout/AppSidebar.razor`
- `src/blueatelier.app/Components/Layout/AppTopbar.razor`
- `src/blueatelier.app/Components/Pages/Materiais.razor`
- `src/blueatelier.app/wwwroot/css/app.css`

Documentacao:

- `docs/03-estado-atual.md`
- `docs/04-proximos-documentos.md`
- `docs/33-materiais.md`
- `docs/34-ajustes-layout-responsividade.md`

## secoes implementadas

A tela contem:

- cabecalho com titulo `Materiais`;
- descricao curta sobre controle visual de resinas, tintas, primers, ferramentas e consumiveis;
- status/resumo visual discreto;
- acoes visuais;
- filtros visuais;
- cards compactos de resumo;
- aviso de controle mockado;
- grid de cards de materiais;
- status visual por material;
- affordance visual de abrir detalhes.

## dados mockados usados

Materiais exibidos:

- Resin Grey;
- ABS-Like Clear;
- Primer Black;
- Deep Green Paint;
- Purple Wash;
- Isopropyl Alcohol;
- Nitrile Gloves;
- Sanding Sticks;
- Hobby Knife;
- UV Resin.

Cada card exibe:

- nome;
- categoria;
- quantidade/estoque mockado;
- unidade;
- status visual;
- uso relacionado;
- ultima atualizacao mockada;
- indicador visual de estoque;
- acao visual para abrir detalhes.

## acoes visuais provisorias

Acoes principais:

- Novo material;
- Importar lista;
- Organizar categorias;
- Registrar uso.

As acoes ainda sao apenas visuais e nao executam cadastro, importacao, organizacao real, baixa de material ou persistencia.

## filtros visuais/provisorios

Filtros exibidos:

- Todos;
- Resinas;
- Tintas;
- Primers;
- Ferramentas;
- Consumiveis;
- Baixo estoque.

Os filtros nao executam filtragem real nesta etapa.

## navegacao pela sidebar

O item Materiais/Materials da sidebar foi habilitado para navegar para:

```txt
/materiais
```

O item fica ativo nessa rota.

## status visuais dos materiais

Estados representados:

- Em estoque;
- Baixo estoque;
- Acabando;
- Esgotado.

Os estados seguem a paleta aprovada: azul como destaque principal e cores de sistema usadas de forma discreta quando indicam alerta, ausencia ou esgotamento.

## o que ainda e provisorio

- dados exibidos;
- quantidades;
- unidades;
- categorias;
- status;
- acoes;
- filtros;
- resumo visual;
- indicador de estoque;
- affordance de abrir detalhes.

## o que ainda nao foi implementado

- tela Detalhe do Material;
- estoque real;
- cadastro real;
- importacao real de lista;
- baixa real de material;
- leitura real de arquivos;
- banco SQLite;
- EF Core;
- migrations;
- servicos reais;
- sistema de arquivos real;
- persistencia.

## validacoes executadas

- `referencias-visuais/stitch/design.md` foi respeitado.
- `referencias-visuais/stitch/html/10-materiais.html` foi usado como referencia.
- `referencias-visuais/stitch/imagens/10-materiais.png` foi consultada.
- Home permaneceu preservada.
- Colecoes permaneceu preservada.
- Detalhe da Colecao permaneceu preservado.
- Detalhe do Modelo permaneceu preservado.
- Galeria do Modelo permaneceu preservada.
- Visualizacao de Imagem permaneceu preservada.
- Arquivos Vinculados permaneceu preservado.
- Fila de Impressao permaneceu preservada.
- Modelos permaneceu preservado.
- Arquivos Recentes permaneceu preservado.
- `/materiais` abre corretamente.
- O item Materiais/Materials da sidebar navega para `/materiais`.
- As tags dos materiais tem contraste legivel.
- As tags dos materiais nao ficam atras do icone/elemento central.
- Os cards de materiais nao cortam conteudo importante.
- A paleta clean/azulada foi preservada.
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

O usuario validou visualmente a tela Materiais no estado atual.

Tambem foram aprovados:

- rota `/materiais`;
- navegacao pela sidebar;
- cards de materiais mockados;
- filtros visuais;
- acoes visuais provisorias;
- contraste das tags de categoria;
- correcoes de layout e responsividade;
- preservacao das telas ja aprovadas;
- preservacao da paleta clean, moderna, azulada e menos colorida.

## proxima etapa sugerida

Implementar a tela Detalhe do Material com base em:

```txt
referencias-visuais/stitch/html/11-detalhe-material.html
```
