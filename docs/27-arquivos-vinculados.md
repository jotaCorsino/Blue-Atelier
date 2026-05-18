# blue atelier - arquivos vinculados

## 1. objetivo da tela Arquivos Vinculados

A tela Arquivos Vinculados apresenta os arquivos associados ao modelo `Cthulhu Idol`, dentro da colecao `Eldritch Horrors`.

Ela serve para organizar visualmente arquivos 3D, arquivos de fatiamento, referencias, notas e documentos ligados ao modelo.

Nesta etapa, a tela usa apenas dados mockados. Nenhuma leitura real de arquivo, abertura real, vinculacao real, remocao real, banco, servico real ou persistencia foi implementada.

## 2. referencia visual usada

Referencia principal:

```txt
referencias-visuais/stitch/html/07-arquivos-vinculados.html
```

Referencias de apoio:

```txt
referencias-visuais/stitch/design.md
referencias-visuais/stitch/imagens/07-arquivos-vinculados.png
docs/15-referencias-visuais-stitch.md
docs/17-fundacao-visual.md
docs/23-detalhe-modelo.md
docs/26-ajustes-responsividade-layout.md
```

A tela foi traduzida para Razor Components e CSS proprio. O HTML exportado pelo Stitch nao foi alterado nem copiado como codigo final.

## 3. rota implementada

Rota visual implementada:

```txt
/colecoes/eldritch-horrors/modelos/cthulhu-idol/arquivos
```

## 4. arquivos alterados ou criados

Arquivos de implementacao envolvidos:

- `src/blueatelier.app/Components/Pages/ArquivosVinculados.razor`
- `src/blueatelier.app/Components/Pages/DetalheModelo.razor`
- `src/blueatelier.app/Components/Layout/AppSidebar.razor`
- `src/blueatelier.app/Components/Layout/AppTopbar.razor`
- `src/blueatelier.app/Components/Shared/AppIcon.razor`
- `src/blueatelier.app/wwwroot/css/app.css`

Arquivos de documentacao envolvidos:

- `docs/03-estado-atual.md`
- `docs/04-proximos-documentos.md`
- `docs/27-arquivos-vinculados.md`
- `docs/28-ajustes-arquivos-vinculados-layout.md`

## 5. secoes implementadas

A tela Arquivos Vinculados contem:

- navegacao de retorno para `Cthulhu Idol`;
- cabecalho com capa visual do modelo;
- contexto `Cthulhu Idol / Eldritch Horrors`;
- resumo com metricas de arquivos;
- acoes visuais;
- filtros visuais/provisorios;
- lista/grid de arquivos vinculados agrupados por secao;
- status visual de arquivos encontrados, ausentes, offline e prontos;
- paineis laterais de pasta vinculada, caminho de rede offline, resumo e notas.

## 6. dados mockados usados

Arquivos mockados:

- `cthulhu-idol.stl`;
- `cthulhu-idol-supported.lys`;
- `cthulhu-idol-ready.ctb`;
- `painting-notes.md`;
- `stone-texture-reference.jpg`;
- `resin-profile.txt`;
- `print-settings.pdf`;
- `final-photo-reference.png`.

Categorias mockadas:

- Modelos 3D;
- Fatiamento;
- Referencias;
- Notas;
- Outros.

Status mockados:

- Encontrado;
- Ausente;
- Rede offline;
- Pronto.

## 7. acoes visuais provisorias

Acoes principais da tela:

- `Vincular arquivo`;
- `Vincular pasta`;
- `Abrir pasta do modelo`;
- `Organizar arquivos`.

Acoes por arquivo:

- abrir arquivo;
- editar vinculo;
- remover vinculo.

As acoes por arquivo usam icones, `title` nativo e `aria-label`. Todas as acoes continuam apenas visuais/provisorias.

## 8. filtros visuais/provisorios

Filtros presentes na tela:

- Todos;
- Modelos 3D;
- Fatiamento;
- Referencias;
- Notas;
- Outros.

Os filtros sao apenas visuais/provisorios. Nenhuma filtragem real, busca real ou estado persistido foi implementado.

## 9. navegacao a partir do Detalhe do Modelo

A tela Detalhe do Modelo recebeu um acesso visual para os arquivos vinculados.

Esse acesso navega para:

```txt
/colecoes/eldritch-horrors/modelos/cthulhu-idol/arquivos
```

A mudanca foi minima e preservou a aparencia aprovada do Detalhe do Modelo.

## 10. o que ainda e provisorio

- todos os dados exibidos;
- metricas do resumo;
- status dos arquivos;
- filtros;
- acoes principais;
- acoes por arquivo;
- paineis laterais;
- capa visual em CSS;
- caminhos exibidos.

## 11. o que ainda nao foi implementado

Ainda nao foram implementados:

- leitura real de arquivos;
- abertura real de arquivo;
- vinculacao real de arquivo;
- vinculacao real de pasta;
- remocao real de vinculo;
- verificacao real de arquivo ausente;
- verificacao real de caminho de rede offline;
- sistema de arquivos real;
- banco SQLite;
- EF Core;
- migrations;
- servicos reais;
- persistencia.

## 12. validacoes executadas

Validacoes de referencia:

- `referencias-visuais/stitch/design.md` foi respeitado.
- `referencias-visuais/stitch/html/07-arquivos-vinculados.html` foi usado como referencia principal.
- `referencias-visuais/stitch/imagens/07-arquivos-vinculados.png` foi usada como referencia visual, quando disponivel.
- Nenhum HTML do Stitch foi alterado.
- Nenhuma imagem do Stitch foi alterada.
- Nenhum `design.md` do Stitch foi alterado.

Validacoes tecnicas:

- `dotnet restore BlueAtelier.sln` executado com sucesso.
- `dotnet build BlueAtelier.sln` executado com sucesso.
- `dotnet test BlueAtelier.sln --no-build` executado com sucesso.

Validacoes de escopo:

- Home permaneceu preservada.
- Colecoes permaneceram preservadas.
- Detalhe da Colecao permaneceu preservado.
- Detalhe do Modelo permaneceu preservado.
- Galeria do Modelo permaneceu preservada.
- Visualizacao de Imagem permaneceu preservada.
- Nenhuma funcionalidade real foi implementada.
- Nenhum banco, EF Core, migration, servico real ou sistema de arquivos real foi implementado.
- Tailwind, Bootstrap externo, CDN e imagens remotas nao foram usados como base do app.

## 13. confirmacao de aprovacao visual manual

O usuario validou visualmente a tela Arquivos Vinculados no estado atual.

A tela Arquivos Vinculados esta aprovada e deve ser preservada nas proximas tarefas.

## 14. proxima etapa sugerida

Implementar a tela de Fila de Impressao com base em:

```txt
referencias-visuais/stitch/html/08-fila-impressao.html
```

A proxima etapa deve preservar Home, Colecoes, Detalhe da Colecao, Detalhe do Modelo, Galeria do Modelo, Visualizacao de Imagem, Arquivos Vinculados e a fundacao visual ja aprovadas.
