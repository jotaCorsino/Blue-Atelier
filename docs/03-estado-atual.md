# blue atelier - estado atual

## status geral

O projeto Blue Atelier mudou de direcao e teve o escopo visual atual simplificado.

O app mantem a base .NET MAUI Blazor Hybrid, a fundacao visual aprovada, a paleta clean/azulada e as telas principais de organizacao de colecoes e modelos. A fase visual baseada nas referencias Stitch foi concluida. As areas de Fila de Impressao, Arquivos Recentes, Materiais e Detalhe do Material foram removidas do escopo atual.

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
- Configuracoes de Aparencia;
- Modelo de Pastas;
- Backup/Dados.

A Home, Colecoes, Detalhe da Colecao, Modelos, Detalhe do Modelo, Galeria do Modelo, Visualizacao de Imagem, Arquivos Vinculados, Favoritos, menu de contexto de Favoritos, Busca, Configuracoes Gerais, Configuracoes de Caminhos, Configuracoes de Aparencia, Modelo de Pastas, Backup/Dados, sidebar, topbar, tipografia, responsividade e paleta visual atual foram validados visualmente pelo usuario e estao aprovados.

Tambem existe um padrao visual reutilizavel para estados do sistema, baseado na referencia Stitch 19. Esse padrao nao e uma tela navegavel e nao cria rota propria.

O visual aprovado esta protegido. O Codex nao deve redesenhar, reinterpretar, simplificar ou alterar a identidade visual aprovada sem autorizacao explicita do usuario.

A fase funcional avancou e o Bloco 2 foi consolidado com a base inicial de banco local em infraestrutura. Essa etapa adicionou EF Core, SQLite, `DbContext`, migration inicial, seed minimo e testes de persistencia, sem alterar o visual aprovado.

O Bloco 3 foi consolidado no primeiro recorte de Colecoes. A tela `/colecoes` passou a listar dados reais do banco local por meio de repositorio e servico de aplicacao, preservando o visual aprovado e mantendo CRUD visual, filtros reais e detalhe completo fora deste recorte.

O Recorte 2 do Bloco 3 foi consolidado para conectar o Detalhe da Colecao aos dados reais da colecao por slug. A rota `/colecoes/{slug}` carrega dados basicos da colecao pelo servico de aplicacao.

O Recorte 3 do Bloco 3 foi consolidado para conectar a lista interna de modelos do Detalhe da Colecao aos dados reais do banco local. A tela continua preservando o visual aprovado, enquanto links, referencias, notas e acoes visuais continuam mockados.

O Bloco 4 foi consolidado no Recorte 1 de Modelos. A tela geral `/modelos` passou a listar modelos reais do banco local, preservando o visual aprovado e mantendo filtros, ordenacao e botoes visuais como mockados.

O Recorte 2 do Bloco 4 foi consolidado para conectar o Detalhe do Modelo aos dados reais do banco local por slug de colecao e slug de modelo. A rota parametrizada `/colecoes/{colecaoSlug}/modelos/{modeloSlug}` preserva a rota aprovada do `Cthulhu Idol`, mantendo galeria, arquivos vinculados, links, referencias, notas editaveis e acoes visuais como mockados.

O Bloco 5 foi consolidado no Recorte 1 de Arquivos Vinculados. A secao `Linked Files` do Detalhe do Modelo passou a listar metadados reais de arquivos vinculados ao modelo pelo banco local, sem ler, validar, abrir, copiar, mover ou apagar arquivos reais.

## repositorio remoto

```txt
https://github.com/jotaCorsino/Blue-Atelier.git
```

## ultima tarefa concluida

A ultima tarefa concluida consolidou o Bloco 5 - Arquivos Vinculados, recorte 1:

- criacao do repositorio concreto `ArquivoVinculadoRepositorio`;
- criacao do servico de aplicacao `ArquivoVinculadoServico`;
- criacao do modelo de aplicacao `ArquivoVinculadoResumo`;
- seed idempotente de metadados de arquivos para o `Cthulhu Idol`;
- conexao da secao `Linked Files` do Detalhe do Modelo com dados reais do banco local;
- nenhum arquivo real lido, copiado, movido, aberto ou apagado;
- galeria, imagens, links, referencias, notas editaveis, favoritos e acoes visuais mantidos mockados;
- nenhum CSS visual alterado;
- nenhum CRUD visual implementado;
- nenhuma reintroducao das areas removidas.

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
- componente `AppStateBlock` para estados visuais reutilizaveis;
- entidades base de dominio em `src/blueatelier.domain/Entidades`;
- enums base de dominio em `src/blueatelier.domain/enums`;
- contratos de repositorio em `src/blueatelier.domain/Contratos`;
- base inicial de banco local em `src/blueatelier.infrastructure/Persistencia`;
- EF Core e SQLite no projeto `BlueAtelier.Infrastructure`;
- `BlueAtelierDbContext`;
- migration inicial `InitialCreate`;
- seed inicial minimo em `BlueAtelierSeed`;
- testes de persistencia SQLite;
- repositorio concreto `ColecaoRepositorio`;
- repositorio concreto `ModeloRepositorio`;
- repositorio concreto `ArquivoVinculadoRepositorio`;
- servico de aplicacao `ColecaoServico`;
- servico de aplicacao `ModeloServico`;
- servico de aplicacao `ArquivoVinculadoServico`;
- modelo de aplicacao `ColecaoResumo`;
- modelo de aplicacao `ColecaoDetalhe`;
- modelo de aplicacao `ModeloResumoColecao`;
- modelo de aplicacao `ModeloResumo`;
- modelo de aplicacao `ModeloDetalhe`;
- modelo de aplicacao `ArquivoVinculadoResumo`;
- inicializador `BlueAtelierBancoInicializador` para migration e seed;
- seed de colecoes suficiente para manter a tela `/colecoes` visualmente proxima do estado aprovado;
- tokens e temas CSS em `wwwroot/css/`;
- Home aprovada e com cards de colecao navegaveis;
- tela de Colecoes aprovada e conectada a listagem real do banco local;
- tela de Detalhe da Colecao aprovada e conectada a dados basicos reais da colecao por slug;
- lista interna de modelos do Detalhe da Colecao conectada a modelos reais do banco local;
- tela Modelos em `/modelos` aprovada e conectada a listagem real de modelos do banco local;
- tela de Detalhe do Modelo aprovada e conectada a dados basicos reais do modelo por slug;
- secao `Linked Files` do Detalhe do Modelo conectada a metadados reais de arquivos vinculados no banco local;
- tela Galeria do Modelo aprovada;
- tela Visualizacao de Imagem aprovada;
- tela Arquivos Vinculados aprovada;
- tela Favoritos aprovada;
- tela Busca aprovada;
- tela Configuracoes Gerais aprovada;
- tela Configuracoes de Caminhos aprovada;
- tela Configuracoes de Aparencia aprovada;
- tela Modelo de Pastas aprovada;
- tela Backup/Dados aprovada;
- rota `/favoritos`;
- rota `/busca`;
- rota `/configuracoes`;
- rota `/configuracoes/caminhos`;
- rota `/configuracoes/aparencia`;
- rota `/configuracoes/modelo-pastas`;
- rota `/configuracoes/backup`;
- sidebar com Favoritos navegando para `/favoritos`;
- sidebar com Busca navegando para `/busca`;
- sidebar com Configuracoes navegando para `/configuracoes`;
- favoritos gerais mockados com navegacoes visuais para telas existentes;
- barra de links favoritos estilo Chrome;
- pastas e links favoritos mockados;
- menu de contexto visual/provisorio para a barra de links favoritos;
- menu de contexto de Favoritos fechando ao clicar fora, preservando cliques internos, troca por outro favorito no botao direito e fechamento ao selecionar uma opcao;
- busca visual/mockada com campo principal, filtros, sugestoes rapidas, resultados e resumo visual;
- Configuracoes Gerais visual/mockada com composicao fiel ao Stitch, navegacao secundaria, paineis de caminhos, rede, aparencia e programas padrao;
- Configuracoes de Caminhos visual/mockada com navegacao secundaria corrigida, diretorios principais e descoberta de rede;
- Configuracoes de Aparencia visual/mockada com selecao de tema, densidade da interface, cor de destaque e acoes visuais;
- Backup/Dados visual/mockada com paineis de backup manual, backup automatico, exportacao/importacao e restauracao;
- layout padronizado entre Configuracoes Gerais, Configuracoes de Caminhos, Configuracoes de Aparencia, Modelo de Pastas e Backup/Dados;
- navegacao secundaria de Configuracoes com `Backup` apontando para `/configuracoes/backup`;
- navegacao secundaria de Configuracoes com `Modelo de Pastas` apontando para `/configuracoes/modelo-pastas`;
- tela Modelo de Pastas visual/mockada com cards `Colecao` e `Modelo`, pre-visualizacao do caminho e acao `Salvar Alteracoes`;
- padrao reutilizavel de estados do sistema com variantes visuais de vazio, erro, offline, sem resultados, caminho indisponivel, loading e sincronizacao pendente;
- responsividade revisada nas paginas de Configuracoes;
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

- migrations futuras alem da inicial;
- servicos reais das demais areas;
- sistema de arquivos real;
- busca real;
- filtros reais persistidos;
- configuracoes reais;
- edicao real de colecoes, modelos ou cards;
- CRUD visual de colecoes;
- CRUD visual de modelos;
- CRUD real do detalhe do modelo pela UI;
- galeria real, imagens reais, links reais, referencias reais e notas reais editaveis do modelo;
- tela geral de Arquivos Vinculados conectada ao banco local;
- leitura, validacao, abertura, copia, movimentacao ou exclusao real de arquivos;
- integracao real de links, referencias e notas no Detalhe da Colecao;
- integracao das demais telas com persistencia real.

## arquivos alterados ou criados na ultima tarefa

Implementacao:

- repositorio de colecoes em `src/blueatelier.infrastructure/Repositorios`;
- repositorio de modelos em `src/blueatelier.infrastructure/Repositorios`;
- repositorio de arquivos vinculados em `src/blueatelier.infrastructure/Repositorios`;
- servico de aplicacao de colecoes em `src/blueatelier.application`;
- servico de aplicacao de modelos em `src/blueatelier.application`;
- servico de aplicacao de arquivos vinculados em `src/blueatelier.application`;
- inicializador de banco em `src/blueatelier.infrastructure/Persistencia`;
- registro de dependencias em `src/blueatelier.infrastructure/DependencyInjection.cs`;
- conexao da tela `/colecoes` ao servico em `src/blueatelier.app/Components/Pages/Colecoes.razor`;
- conexao dos cards internos do Detalhe da Colecao ao servico de modelos em `src/blueatelier.app/Components/Pages/DetalheColecao.razor`;
- conexao da tela `/modelos` ao servico de modelos em `src/blueatelier.app/Components/Pages/Modelos.razor`;
- conexao da tela Detalhe do Modelo ao servico de modelos em `src/blueatelier.app/Components/Pages/DetalheModelo.razor`;
- conexao da secao `Linked Files` do Detalhe do Modelo ao servico de arquivos vinculados em `src/blueatelier.app/Components/Pages/DetalheModelo.razor`;
- inicializacao do banco no app em `src/blueatelier.app/MauiProgram.cs`;
- testes de colecoes em `tests/blueatelier.tests/infrastructure`.
- testes de modelos em `tests/blueatelier.tests/infrastructure`.

Documentacao:

- `docs/03-estado-atual.md`
- `docs/04-proximos-documentos.md`
- `docs/48-bloco-3-colecoes.md`
- `docs/49-bloco-4-modelos.md`
- `docs/50-bloco-5-arquivos-vinculados.md`

## validacoes executadas na ultima tarefa

- `referencias-visuais/stitch/design.md` permanece protegido.
- Nenhum HTML do Stitch foi alterado.
- Nenhuma imagem do Stitch foi alterada.
- Nenhum `design.md` do Stitch foi alterado.
- O Bloco 3 - Colecoes, recorte 3, foi consolidado.
- O Bloco 4 - Modelos, recorte 1, foi consolidado.
- O Bloco 4 - Modelos, recorte 2, foi consolidado.
- O Bloco 5 - Arquivos Vinculados, recorte 1, foi consolidado.
- O repositorio `ColecaoRepositorio` implementa `IColecaoRepositorio`.
- O repositorio `ModeloRepositorio` implementa `IModeloRepositorio`.
- O servico `ColecaoServico` retorna `ColecaoResumo`, sem expor entidade de dominio para Razor.
- O servico `ColecaoServico` retorna `ColecaoDetalhe` para detalhe por slug, sem expor entidade de dominio para Razor.
- O servico `ModeloServico` retorna `ModeloResumoColecao`, `ModeloResumo` e `ModeloDetalhe`, sem expor entidade de dominio para Razor.
- O servico `ArquivoVinculadoServico` retorna `ArquivoVinculadoResumo`, sem expor entidade de dominio para Razor.
- O inicializador `BlueAtelierBancoInicializador` executa migration e seed.
- O seed de colecoes foi ampliado de forma idempotente para manter a tela visualmente preenchida.
- `/colecoes` lista dados reais do banco local via servico de aplicacao.
- `/colecoes/{slug}` carrega dados basicos reais da colecao via servico de aplicacao.
- `/colecoes/{slug}` carrega modelos reais da colecao via servico de aplicacao.
- `/modelos` lista modelos reais do banco local via servico de aplicacao.
- `/colecoes/{colecaoSlug}/modelos/{modeloSlug}` carrega dados basicos reais do modelo via servico de aplicacao.
- A secao `Linked Files` do Detalhe do Modelo carrega metadados reais de arquivos vinculados via servico de aplicacao.
- A navegacao por slug para `Eldritch Horrors` foi preservada.
- A navegacao do card `Cthulhu Idol` na tela Modelos foi preservada para `/colecoes/eldritch-horrors/modelos/cthulhu-idol`.
- Os cards internos do Detalhe da Colecao preservam classes CSS e passam a usar dados reais de nome, etapa, status e progresso.
- Os cards da tela Modelos preservam classes CSS e passam a usar dados reais de nome, colecao, etapa/status, progresso e material/escala.
- A contagem visual de modelos no Detalhe da Colecao usa a quantidade real carregada.
- Links, referencias e notas do Detalhe da Colecao continuam mockados.
- Filtros, ordenacao e botoes visuais da tela Modelos continuam mockados.
- Galeria, imagens, links, referencias, notas editaveis, favoritos e acoes visuais do Detalhe do Modelo continuam mockados.
- Nenhum arquivo real foi lido, copiado, movido, aberto ou apagado.
- Nenhum formulario, modal ou CRUD visual foi implementado.
- Nenhum CSS visual foi alterado.
- A sidebar permanece preservada.
- A topbar permanece preservada.
- `/configuracoes` existe como rota.
- `/configuracoes/caminhos` existe como rota.
- `/configuracoes/aparencia` existe como rota.
- `/configuracoes/modelo-pastas` existe como rota.
- `/configuracoes/backup` existe como rota.
- A sidebar navega para `/configuracoes`.
- A topbar reconhece rotas iniciadas por `configuracoes` sem reintroduzir logicas antigas.
- A tela Configuracoes Gerais abre corretamente.
- A tela Configuracoes de Caminhos abre corretamente.
- A tela Configuracoes de Aparencia abre corretamente.
- A tela Modelo de Pastas abre corretamente.
- A tela Backup/Dados abre corretamente.
- A navegacao secundaria marca `Geral` em `/configuracoes`.
- A navegacao secundaria marca `Caminhos` em `/configuracoes/caminhos`.
- A navegacao secundaria marca `Aparencia` em `/configuracoes/aparencia`.
- A navegacao secundaria marca `Modelo de Pastas` em `/configuracoes/modelo-pastas`.
- A navegacao secundaria marca `Backup` em `/configuracoes/backup`.
- A navegacao secundaria esta padronizada nas telas de Configuracoes.
- O item `Dados do App` nao aponta para `/configuracoes/backup`.
- A responsividade de `/configuracoes`, `/configuracoes/caminhos`, `/configuracoes/aparencia`, `/configuracoes/modelo-pastas` e `/configuracoes/backup` permanece preservada.
- Nenhuma tela aprovada foi redesenhada.
- Somente a listagem de `/colecoes` foi integrada ao banco local.
- Os mocks das demais telas permanecem intactos.
- Nenhuma criacao real de pastas foi implementada.
- Nenhuma leitura real de diretorios foi implementada.
- Nenhuma gravacao real de configuracao foi implementada.
- Nenhum backup real foi implementado.
- Nenhuma exportacao real foi implementada.
- Nenhuma importacao real foi implementada.
- Nenhuma restauracao real foi implementada.
- Nenhuma exclusao real de dados foi implementada.
- Nenhuma logica real de erro, offline, retry, loading ou sincronizacao foi implementada.
- `/favoritos` permanece preservada.
- O menu de contexto de Favoritos permanece com fechamento ao clicar fora e sem alteracao visual.
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
- Nenhuma funcionalidade real de UI foi implementada.
- Nenhum CRUD visual foi implementado.
- `ColecaoRepositorio` e `ModeloRepositorio` foram implementados como repositorios concretos.
- `ColecaoServico` e `ModeloServico` foram implementados como servicos de aplicacao para os recortes atuais.
- Nenhum CDN, Tailwind, Bootstrap ou biblioteca externa foi usado.
- Nenhuma tela aprovada foi alterada.
- Nenhuma funcionalidade real de UI foi implementada nesta etapa.
- `dotnet restore BlueAtelier.sln` executado com sucesso.
- `dotnet build BlueAtelier.sln` executado com sucesso.
- `dotnet test BlueAtelier.sln --no-build` executado com sucesso.

## proxima tarefa sugerida

Continuar o Bloco 5 - Arquivos Vinculados, somente apos revisao e aprovacao do usuario.

O proximo recorte de Arquivos Vinculados deve evoluir a funcionalidade de forma progressiva, sem redesenhar a interface e sem manipular arquivos reais sem decisao explicita. A proxima tarefa deve preservar Home, Colecoes, Detalhe da Colecao, Modelos, Detalhe do Modelo, Galeria do Modelo, Visualizacao de Imagem, Arquivos Vinculados, Favoritos, Busca, Configuracoes Gerais, Configuracoes de Caminhos, Configuracoes de Aparencia, Modelo de Pastas, Backup/Dados e a fundacao visual ja aprovadas. Nao reintroduzir Fila de Impressao, Arquivos Recentes, Materiais ou Detalhe do Material sem nova decisao explicita do usuario.
