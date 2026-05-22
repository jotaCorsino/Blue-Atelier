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

A fase funcional foi iniciada e o Bloco 1 foi consolidado com foco em arquitetura funcional minima. Essa etapa criou base de dominio e contratos sem alterar o visual aprovado e sem implementar persistencia.

## repositorio remoto

```txt
https://github.com/jotaCorsino/Blue-Atelier.git
```

## ultima tarefa concluida

A ultima tarefa concluida consolidou o Bloco 1 da fase funcional em modo arquitetural:

- criacao de entidades simples de dominio;
- criacao de enums basicos;
- criacao de contratos/interfaces de repositorio;
- criacao de testes unitarios simples para entidades do dominio;
- criacao do documento `docs/46-bloco-1-arquitetura-funcional.md`;
- aprovacao do Bloco 1 pelo usuario;
- nenhuma tela alterada;
- nenhum CSS visual alterado;
- nenhuma funcionalidade implementada;
- nenhum banco, EF Core, SQLite, `DbContext` ou migration criado;
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

- SQLite;
- EF Core;
- migrations;
- servicos reais;
- sistema de arquivos real;
- busca real;
- filtros reais persistidos;
- configuracoes reais;
- edicao real de colecoes, modelos ou cards;
- persistencia real.

## arquivos alterados ou criados na ultima tarefa

Implementacao:

- entidades de dominio em `src/blueatelier.domain/Entidades`;
- enums de dominio em `src/blueatelier.domain/enums`;
- contratos de repositorio em `src/blueatelier.domain/Contratos`;
- testes de dominio em `tests/blueatelier.tests/domain`.

Documentacao:

- `docs/03-estado-atual.md`
- `docs/04-proximos-documentos.md`
- `docs/46-bloco-1-arquitetura-funcional.md`

## validacoes executadas na ultima tarefa

- `referencias-visuais/stitch/design.md` permanece protegido.
- Nenhum HTML do Stitch foi alterado.
- Nenhuma imagem do Stitch foi alterada.
- Nenhum `design.md` do Stitch foi alterado.
- O Bloco 1 foi implementado sem integracao visual.
- As entidades base de dominio foram criadas no projeto `BlueAtelier.Domain`.
- Os enums base foram criados sem dependencia de banco.
- Os contratos de repositorio foram criados sem implementacao concreta.
- Testes simples de dominio foram adicionados em `tests/blueatelier.tests/domain/EntidadesDominioTests.cs`.
- Nenhum pacote novo foi instalado.
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
- Nenhuma funcionalidade real foi implementada.
- Nenhuma persistencia real foi implementada.
- Nenhum banco SQLite foi criado.
- Nenhum EF Core foi implementado.
- Nenhum `DbContext` foi criado.
- Nenhuma migration foi criada.
- Nenhum servico real foi implementado.
- Nenhum CDN, Tailwind, Bootstrap ou biblioteca externa foi usado.
- Nenhuma tela aprovada foi alterada.
- Nenhuma funcionalidade real foi implementada nesta etapa.
- `dotnet restore BlueAtelier.sln` executado com sucesso.
- `dotnet build BlueAtelier.sln` executado com sucesso.
- `dotnet test BlueAtelier.sln --no-build` executado com sucesso.

## proxima tarefa sugerida

Iniciar o Bloco 2 - Banco local, somente apos autorizacao explicita do usuario.

O Bloco 2 deve planejar SQLite, EF Core, `DbContext`, migrations e seed inicial de forma progressiva, sem alterar o visual aprovado. A proxima tarefa deve preservar Home, Colecoes, Detalhe da Colecao, Modelos, Detalhe do Modelo, Galeria do Modelo, Visualizacao de Imagem, Arquivos Vinculados, Favoritos, Busca, Configuracoes Gerais, Configuracoes de Caminhos, Configuracoes de Aparencia, Modelo de Pastas, Backup/Dados e a fundacao visual ja aprovadas. Nao reintroduzir Fila de Impressao, Arquivos Recentes, Materiais ou Detalhe do Material sem nova decisao explicita do usuario.
