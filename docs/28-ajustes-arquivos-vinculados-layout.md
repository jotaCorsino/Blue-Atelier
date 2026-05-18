# blue atelier - ajustes da tela Arquivos Vinculados

## 1. motivo dos ajustes

Apos a primeira implementacao da tela Arquivos Vinculados, o usuario identificou pontos visuais que precisavam de refinamento antes da consolidacao:

- paineis laterais invadiam a area principal em algumas larguras;
- acoes por arquivo estavam textuais e deveriam ser icones;
- a capa principal precisava permanecer visivel, mas melhor encaixada no layout;
- o icone de remover vinculo precisava comunicar remocao de forma mais clara;
- botoes de acao precisavam de `title` nativo alem de `aria-label`.

Os ajustes foram limitados a composicao visual, responsividade e acessibilidade basica dos botoes.

## 2. correcao da sobreposicao dos paineis laterais

O layout da tela Arquivos Vinculados foi ajustado para manter a area principal e o painel lateral em colunas bem definidas.

Foram aplicadas regras para:

- usar grid responsivo;
- manter `min-width: 0` nos blocos principais;
- preservar espaco entre lista e painel lateral;
- impedir sobreposicao entre conteudo principal e resumo lateral;
- mover os paineis laterais para baixo em larguras menores.

## 3. troca das acoes de texto por icones

As acoes por arquivo deixaram de usar texto visivel.

Foram mantidas apenas acoes compactas por icone para:

- abrir arquivo;
- editar vinculo;
- remover vinculo.

Os botoes continuam visuais/provisorios e nao executam operacoes reais.

## 4. adicao de `title` e `aria-label`

Os botoes de acao por arquivo receberam `title` nativo e mantiveram `aria-label`.

Titulos aplicados:

- `Abrir arquivo`;
- `Editar vinculo`;
- `Remover vinculo`.

Essa decisao melhora a identificacao da acao ao passar o mouse e preserva acessibilidade basica sem adicionar biblioteca externa.

## 5. troca do icone de remover

O icone anterior de remover vinculo foi substituido por um icone de lixeira no componente `AppIcon`.

Nome do icone:

```txt
trash
```

O botao de remocao tambem recebeu hover discreto com tom de erro, mantendo o estilo minimalista do app.

## 6. refinamento da capa/imagem principal

A capa principal foi mantida na tela e reposicionada dentro do cabecalho.

O ajuste buscou:

- integrar a capa ao bloco superior;
- alinhar capa, titulo, contexto e metricas;
- evitar que a capa parecesse solta no canto superior;
- eliminar espaco vazio grande abaixo;
- preservar proporcao visual com `aspect-ratio`;
- usar `overflow: hidden`;
- manter `background-size: cover`;
- manter `background-position: center`;
- preservar a leitura clara da tela.

## 7. correcao de espacamento, alinhamento e hierarquia visual

Foram ajustados:

- gap geral da tela;
- alinhamento da capa com o bloco de titulo;
- espacamento entre header e secoes seguintes;
- tamanho da capa;
- espacamento dos cards de resumo;
- comportamento responsivo do header em janelas menores.

O resultado preserva a hierarquia:

- contexto do modelo no topo;
- metricas logo abaixo do titulo;
- acoes e filtros em seguida;
- lista de arquivos e resumo lateral como area principal de trabalho.

## 8. arquivos alterados

Arquivos alterados ou criados na etapa:

- `src/blueatelier.app/Components/Pages/ArquivosVinculados.razor`
- `src/blueatelier.app/Components/Pages/DetalheModelo.razor`
- `src/blueatelier.app/Components/Layout/AppSidebar.razor`
- `src/blueatelier.app/Components/Layout/AppTopbar.razor`
- `src/blueatelier.app/Components/Shared/AppIcon.razor`
- `src/blueatelier.app/wwwroot/css/app.css`
- `docs/03-estado-atual.md`
- `docs/04-proximos-documentos.md`
- `docs/27-arquivos-vinculados.md`
- `docs/28-ajustes-arquivos-vinculados-layout.md`

## 9. regras de responsividade aplicadas

- paineis laterais nao podem sobrepor a lista;
- em telas menores, paineis laterais quebram para baixo;
- capa mantem proporcao estavel;
- capa nao invade topbar nem conteudo;
- lista de arquivos se adapta para coluna unica em telas menores;
- botoes de acao continuam compactos;
- filtros e acoes principais podem ocupar largura total em telas estreitas.

## 10. validacoes executadas

- `referencias-visuais/stitch/design.md` foi respeitado.
- `referencias-visuais/stitch/html/07-arquivos-vinculados.html` foi usado como referencia.
- Home permaneceu preservada.
- Colecoes permaneceu preservada.
- Detalhe da Colecao permaneceu preservado.
- Detalhe do Modelo permaneceu preservado.
- Galeria do Modelo permaneceu preservada.
- Visualizacao de Imagem permaneceu preservada.
- A tela Arquivos Vinculados foi aprovada visualmente.
- Paineis laterais nao se sobrepoem.
- A capa/imagem principal esta bem encaixada no layout.
- Acoes da lista usam icones.
- Botoes de acao possuem `title` e `aria-label`.
- Nenhum HTML do Stitch foi alterado.
- Nenhuma imagem do Stitch foi alterada.
- Nenhum `design.md` do Stitch foi alterado.
- Nenhuma funcionalidade real foi implementada.
- Nenhum banco, EF Core, migration, servico real ou sistema de arquivos real foi implementado.
- Nenhum CDN, Tailwind, Bootstrap ou biblioteca externa foi usado.
- `dotnet restore BlueAtelier.sln` executado com sucesso.
- `dotnet build BlueAtelier.sln` executado com sucesso.
- `dotnet test BlueAtelier.sln --no-build` executado com sucesso.

## 11. confirmacao de aprovacao visual manual

O usuario validou visualmente:

- a tela Arquivos Vinculados;
- a capa principal bem encaixada;
- os paineis laterais sem sobreposicao;
- as acoes por icones;
- o icone de remocao;
- os botoes com `title` e `aria-label`;
- a preservacao das telas ja aprovadas.
