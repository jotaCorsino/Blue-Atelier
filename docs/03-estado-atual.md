# blue atelier - estado atual

## status geral

O projeto Blue Atelier mudou de direcao e teve o escopo visual atual simplificado.

O app mantem a base .NET MAUI Blazor Hybrid, a fundacao visual aprovada, a paleta clean/azulada e as telas principais de organizacao de colecoes e modelos. As areas de Fila de Impressao, Arquivos Recentes, Materiais e Detalhe do Material foram removidas do escopo atual.

Telas mantidas no estado atual:

- Home;
- Colecoes;
- Detalhe da Colecao;
- Modelos;
- Detalhe do Modelo;
- Galeria do Modelo;
- Visualizacao de Imagem;
- Arquivos Vinculados;
- Favoritos;
- Busca;
- Configuracoes Gerais;
- Configuracoes de Caminhos;
- Configuracoes de Aparencia.

A Home, Colecoes, Detalhe da Colecao, Modelos, Detalhe do Modelo, Galeria do Modelo, Visualizacao de Imagem, Arquivos Vinculados, Favoritos, Busca, Configuracoes Gerais, Configuracoes de Caminhos, Configuracoes de Aparencia, sidebar, topbar, tipografia, responsividade e paleta visual atual foram validados visualmente pelo usuario e estao aprovados.

O visual aprovado esta protegido. O Codex nao deve redesenhar, reinterpretar, simplificar ou alterar a identidade visual aprovada sem autorizacao explicita do usuario.

## repositorio remoto

```txt
https://github.com/jotaCorsino/Blue-Atelier.git
```

## ultima tarefa concluida

A ultima tarefa concluida consolidou a implementacao da tela Configuracoes de Aparencia:

- implementacao da tela Configuracoes de Aparencia;
- criacao da rota `/configuracoes/aparencia`;
- uso da referencia `referencias-visuais/stitch/html/16-configuracoes-aparencia.html`;
- uso da imagem `referencias-visuais/stitch/imagens/16-configuracoes-aparencia.png`;
- padronizacao do layout entre `/configuracoes`, `/configuracoes/caminhos` e `/configuracoes/aparencia`;
- navegacao secundaria consistente nas telas de Configuracoes;
- item `Geral` ativo em `/configuracoes`;
- item `Caminhos` ativo em `/configuracoes/caminhos`;
- item `Aparencia` ativo em `/configuracoes/aparencia`;
- titulo, descricao, navegacao e conteudo alinhados entre as paginas de Configuracoes;
- tudo visual/mockado;
- nenhuma preferencia real;
- nenhuma persistencia;
- nenhuma reintroducao das areas removidas;
- preservacao das paginas mantidas;
- aprovacao visual manual pelo usuario.

## decisoes ja tomadas

- O app se chama Blue Atelier.
- O app sera Windows local, de uso pessoal e completo.
- A stack oficial e .NET MAUI Blazor Hybrid, C#, SQLite, Entity Framework Core, Razor Components e CSS proprio.
- A arquitetura separa interface, dominio, aplicacao, infraestrutura e persistencia.
- Arquivos pesados devem permanecer no sistema de arquivos.
- Caminhos locais e de rede fazem parte do escopo futuro do app.
- Caminho de rede offline deve ser tratado como condicao normal.
- Remover vinculo no app nao deve apagar arquivo real.
- Stitch e fonte de referencia visual aprovada, mas nao e fonte final de codigo.
- Antigravity e apoio estrategico; Codex e o engenheiro principal do projeto.
- GitHub e a fonte de verdade apos cada commit e push.

## mudanca de escopo

Nao fazem mais parte do escopo visual atual:

- Fila de Impressao;
- Arquivos Recentes;
- Materiais;
- Detalhe do Material.

Tambem nao existem no estado atual:

- fila real;
- historico real de arquivos recentes;
- cadastro real de materiais;
- estoque real;
- baixa real de material;
- detalhe de material;
- navegacao para `/materiais`;
- persistencia real.

Materiais agora aparecem apenas como uma lista local/mockada dentro do Detalhe do Modelo, indicando materiais usados naquele modelo. Essa lista nao representa estoque, nao abre pagina propria e nao navega para uma area de Materiais.

## referencias visuais protegidas

Estes arquivos permanecem protegidos:

```txt
referencias-visuais/stitch/design.md
referencias-visuais/stitch/html/
referencias-visuais/stitch/imagens/
```

Regras vigentes:

- nao alterar HTMLs exportados do Stitch;
- nao alterar imagens exportadas do Stitch;
- nao alterar `design.md`;
- nao redesenhar telas aprovadas;
- nao transformar a interface em dashboard corporativo;
- nao usar Tailwind, Bootstrap externo, CDN ou imagens remotas como base do app.

## estado da implementacao

Implementado:

- solucao `BlueAtelier.sln`;
- projeto .NET MAUI Blazor Hybrid para Windows;
- projetos de camada em `src/`;
- projeto de testes em `tests/`;
- layout base em `MainLayout.razor`;
- sidebar em `AppSidebar.razor`;
- topbar em `AppTopbar.razor`;
- componentes base `AppCard`, `AppBadge` e `AppButton`;
- componente `AppIcon` com icones SVG inline;
- tokens e temas CSS em `wwwroot/css/`;
- Home aprovada e com cards de colecao navegaveis;
- tela de Colecoes aprovada;
- tela de Detalhe da Colecao aprovada;
- tela Modelos em `/modelos` aprovada;
- tela de Detalhe do Modelo aprovada;
- tela Galeria do Modelo aprovada;
- tela Visualizacao de Imagem aprovada;
- tela Arquivos Vinculados aprovada;
- tela Favoritos aprovada;
- tela Busca aprovada;
- tela Configuracoes Gerais aprovada;
- tela Configuracoes de Caminhos aprovada;
- tela Configuracoes de Aparencia aprovada;
- rota `/favoritos`;
- rota `/busca`;
- rota `/configuracoes`;
- rota `/configuracoes/caminhos`;
- rota `/configuracoes/aparencia`;
- sidebar com Favoritos navegando para `/favoritos`;
- sidebar com Busca navegando para `/busca`;
- sidebar com Configuracoes navegando para `/configuracoes`;
- favoritos gerais mockados com navegacoes visuais para telas existentes;
- barra de links favoritos estilo Chrome;
- pastas e links favoritos mockados;
- menu de contexto visual/provisorio para a barra de links favoritos;
- busca visual/mockada com campo principal, filtros, sugestoes rapidas, resultados e resumo visual;
- Configuracoes Gerais visual/mockada com composicao fiel ao Stitch, navegacao secundaria, paineis de caminhos, rede, aparencia e programas padrao;
- Configuracoes de Caminhos visual/mockada com navegacao secundaria corrigida, diretorios principais e descoberta de rede;
- Configuracoes de Aparencia visual/mockada com selecao de tema, densidade da interface, cor de destaque e acoes visuais;
- layout padronizado entre Configuracoes Gerais, Configuracoes de Caminhos e Configuracoes de Aparencia;
- navegacao do card Cthulhu Idol para `/colecoes/eldritch-horrors/modelos/cthulhu-idol`;
- sidebar com Models ativo nas rotas de modelos;
- hover global de cards clicaveis;
- affordances visuais de edicao futura;
- tipografia moderna com stack de sistema;
- paleta visual mais clean, moderna, azulada e menos colorida;
- azul como cor principal de destaque;
- refinamento visual da barra anterior/proxima da Visualizacao de Imagem;
- correcao global de proporcao para capas, thumbnails, previews e imagens mockadas;
- ajuste de layout do Detalhe do Modelo para acompanhar melhor telas largas;
- paineis laterais responsivos da tela Arquivos Vinculados;
- acoes da lista de arquivos como icones com `title` e `aria-label`;
- capa/imagem principal da tela Arquivos Vinculados bem encaixada no header.

Removido do estado atual:

- tela Fila de Impressao;
- tela Arquivos Recentes;
- tela Materiais;
- Detalhe do Material;
- navegacao da sidebar para as areas removidas;
- logicas especificas da topbar para as areas removidas;
- CSS especifico das paginas removidas.

Ainda nao implementado:

- SQLite;
- EF Core;
- migrations;
- entidades completas;
- servicos reais;
- sistema de arquivos real;
- busca real;
- filtros reais persistidos;
- configuracoes reais;
- edicao real de colecoes, modelos ou cards;
- persistencia real.

## arquivos alterados ou criados na ultima tarefa

Implementacao:

- `src/blueatelier.app/Components/Pages/Configuracoes.razor`
- `src/blueatelier.app/Components/Pages/ConfiguracoesCaminhos.razor`
- `src/blueatelier.app/Components/Pages/ConfiguracoesAparencia.razor`
- `src/blueatelier.app/wwwroot/css/app.css`

Documentacao:

- `docs/03-estado-atual.md`
- `docs/04-proximos-documentos.md`
- `docs/38-configuracoes-gerais.md`
- `docs/39-configuracoes-caminhos.md`
- `docs/40-configuracoes-aparencia.md`

## validacoes executadas na ultima tarefa

- `referencias-visuais/stitch/design.md` permanece protegido.
- Nenhum HTML do Stitch foi alterado.
- Nenhuma imagem do Stitch foi alterada.
- Nenhum `design.md` do Stitch foi alterado.
- `referencias-visuais/stitch/html/16-configuracoes-aparencia.html` foi usado como referencia.
- `referencias-visuais/stitch/imagens/16-configuracoes-aparencia.png` foi usado como referencia visual.
- `/configuracoes` existe como rota.
- `/configuracoes/caminhos` existe como rota.
- `/configuracoes/aparencia` existe como rota.
- A sidebar navega para `/configuracoes`.
- A topbar reconhece rotas iniciadas por `configuracoes` sem reintroduzir logicas antigas.
- A tela Configuracoes Gerais abre corretamente.
- A tela Configuracoes de Caminhos abre corretamente.
- A tela Configuracoes de Aparencia abre corretamente.
- A navegacao secundaria marca `Geral` em `/configuracoes`.
- A navegacao secundaria marca `Caminhos` em `/configuracoes/caminhos`.
- A navegacao secundaria marca `Aparencia` em `/configuracoes/aparencia`.
- A navegacao secundaria esta padronizada nas telas de Configuracoes.
- Titulo, descricao, navegacao e conteudo principal estao alinhados entre as paginas de Configuracoes.
- Os temas, swatches, controles de densidade e acoes da tela Aparencia sao apenas visuais/mockados.
- Nenhuma configuracao real foi implementada.
- Nenhum salvamento real foi implementado.
- Nenhuma aplicacao real de tema foi implementada.
- `/favoritos` permanece preservada.
- `/busca` permanece preservada.
- A barra de links favoritos permanece preservada.
- `/fila-impressao` nao existe mais como rota.
- `/arquivos-recentes` nao existe mais como rota.
- `/materiais` nao existe mais como rota.
- `/materiais/resin-grey` nao existe mais como rota.
- A sidebar nao mostra mais Fila de Impressao.
- A sidebar nao mostra mais Arquivos Recentes.
- A sidebar nao mostra mais Materiais.
- A topbar nao possui mais logica especifica dessas areas.
- O CSS nao mantem blocos grandes mortos dessas paginas.
- O Detalhe do Modelo ainda possui `Model Info`.
- O Detalhe do Modelo ainda possui lista simples de materiais usados.
- Nenhuma funcionalidade real foi implementada.
- Nenhuma persistencia real foi implementada.
- Nenhum banco SQLite foi criado.
- Nenhum EF Core foi implementado.
- Nenhuma migration foi criada.
- Nenhum servico real foi implementado.
- Nenhum CDN, Tailwind, Bootstrap ou biblioteca externa foi usado.
- `dotnet restore BlueAtelier.sln` executado com sucesso.
- `dotnet build BlueAtelier.sln` executado com sucesso.
- `dotnet test BlueAtelier.sln --no-build` executado com sucesso.

## proxima tarefa sugerida

Implementar Modelo de Pastas com base em:

```txt
referencias-visuais/stitch/html/17-modelo-pastas.html
```

A proxima tarefa deve preservar Home, Colecoes, Detalhe da Colecao, Modelos, Detalhe do Modelo, Galeria do Modelo, Visualizacao de Imagem, Arquivos Vinculados, Favoritos, Busca, Configuracoes Gerais, Configuracoes de Caminhos, Configuracoes de Aparencia e a fundacao visual ja aprovadas. Nao reintroduzir Fila de Impressao, Arquivos Recentes, Materiais ou Detalhe do Material sem nova decisao explicita do usuario.
