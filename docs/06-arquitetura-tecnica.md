# blue atelier — arquitetura técnica

## 1. objetivo do documento

Este documento define a arquitetura técnica oficial do **Blue Atelier**.

O Blue Atelier será um aplicativo Windows local, de uso pessoal, visual, completo e organizado em torno de coleções, modelos, galerias, arquivos, favoritos, materiais, fila de impressão, configurações e caminhos locais ou de rede.

Esta arquitetura orienta as próximas tarefas de implementação, mas ainda não cria código, projeto .NET, telas ou banco de dados.

## 2. visão técnica geral

O Blue Atelier será construído como um app local para Windows, com interface moderna baseada em componentes, dados persistidos em SQLite e arquivos mantidos fora do banco.

A arquitetura deve separar bem:

- interface visual;
- regras de domínio;
- casos de uso da aplicação;
- serviços internos;
- persistência em SQLite;
- integração com sistema de arquivos;
- integração com caminhos de rede;
- configurações locais.

O app deve funcionar sem depender de internet. A internet será usada apenas quando o usuário abrir links externos.

O banco SQLite guardará metadados, relações, caminhos, status, descrições, tags, favoritos, materiais, configurações e histórico. Imagens, arquivos 3D, fotos, documentos e projetos de slicer continuarão no sistema de arquivos.

## 3. stack oficial do projeto

A stack oficial do Blue Atelier será:

- **.NET MAUI Blazor Hybrid** para o app Windows local.
- **C#** como linguagem principal.
- **Razor Components** para a interface.
- **CSS próprio** para estilo visual, temas, mosaicos, cards e ajustes finos.
- **SQLite** como banco de dados local.
- **Entity Framework Core** como camada de acesso ao banco.
- **Serviços internos em C#** para regras de aplicação, banco, arquivos, caminhos de rede, configurações, temas e backup.
- **Testes automatizados em .NET** para domínio, serviços, persistência e regras críticas.

A versão exata do .NET deve ser confirmada apenas na tarefa de criação da solução, considerando a versão suportada instalada na máquina e o estado atual das ferramentas.

## 4. motivos para escolher .NET MAUI Blazor Hybrid

.NET MAUI Blazor Hybrid é a escolha oficial porque combina bem com as necessidades do Blue Atelier.

Motivos principais:

- Permite criar um app Windows local usando C# e .NET.
- Permite usar Razor Components para construir uma interface visual rica.
- Facilita a criação de mosaicos, galerias, cards e painéis.
- Permite usar CSS próprio para refinamento visual.
- Mantém a lógica principal em C#, sem dividir o app entre muitas tecnologias.
- Funciona bem para app pessoal, local-first e com banco SQLite.
- Permite acessar recursos do Windows por serviços internos.
- Permite evoluir com componentes reutilizáveis.
- Reduz a distância entre interface, regras de aplicação e persistência.

Essa escolha não transforma o Blue Atelier em um site. O app será local, instalado ou executado no Windows, usando Blazor dentro de uma aplicação .NET MAUI.

## 5. estrutura esperada da solução

A solução deve ser organizada em projetos pequenos e claros.

Estrutura esperada:

```txt
BlueAtelier.sln
├── src/
│   ├── BlueAtelier.App/
│   ├── BlueAtelier.Domain/
│   ├── BlueAtelier.Application/
│   ├── BlueAtelier.Infrastructure/
│   └── BlueAtelier.Persistence/
├── tests/
│   ├── BlueAtelier.Domain.Tests/
│   ├── BlueAtelier.Application.Tests/
│   └── BlueAtelier.Infrastructure.Tests/
└── docs/
```

Responsabilidades previstas:

- `BlueAtelier.App`: app .NET MAUI Blazor Hybrid, Razor Components, rotas, layout, estilos e composição da interface.
- `BlueAtelier.Domain`: entidades, enums, value objects e regras puras de domínio.
- `BlueAtelier.Application`: casos de uso, contratos de serviços, validações de aplicação e orquestração.
- `BlueAtelier.Infrastructure`: acesso ao sistema de arquivos, caminhos de rede, relógio, abertura de arquivos, integração com Windows e serviços técnicos.
- `BlueAtelier.Persistence`: contexto do banco, configurações do Entity Framework Core, migrations, repositórios e consultas.
- `tests`: testes automatizados separados por camada.

Essa estrutura pode ser ajustada na implementação se houver motivo técnico claro, mas qualquer mudança deve ser registrada na documentação.

## 6. separação entre interface, domínio, aplicação, infraestrutura e persistência

### interface

A interface deve cuidar de exibir dados, receber ações do usuário e chamar casos de uso da aplicação.

Ela não deve conter regras de negócio complexas, acesso direto ao banco ou manipulação direta de arquivos.

### domínio

O domínio deve representar os conceitos centrais do atelier.

Exemplos:

- coleção;
- modelo;
- galeria;
- imagem;
- arquivo vinculado;
- link;
- favorito;
- material;
- item da fila de impressão;
- configuração;
- caminho de rede.

O domínio deve conter regras simples e estáveis, como geração de slug, status permitidos, validação de relações e estados de produção.

### aplicação

A camada de aplicação deve coordenar ações do usuário.

Exemplos:

- criar coleção;
- editar modelo;
- adicionar imagem à galeria;
- marcar link como favorito;
- enviar arquivo para fila de impressão;
- testar caminho de rede;
- salvar configuração;
- buscar itens globalmente.

Essa camada deve conversar com interfaces de repositórios e serviços, sem depender diretamente da interface visual.

### infraestrutura

A infraestrutura deve implementar integrações com o ambiente local.

Exemplos:

- abrir arquivo no Windows;
- abrir pasta no Explorador de Arquivos;
- testar se um caminho existe;
- copiar arquivo;
- verificar caminho de rede;
- obter metadados de arquivo;
- gravar logs locais;
- lidar com backup.

### persistência

A persistência deve cuidar do SQLite e do Entity Framework Core.

Ela deve implementar repositórios, contexto de banco, migrations, consultas e mapeamentos.

O restante do app não deve depender diretamente de detalhes internos do banco.

## 7. camadas do projeto

Fluxo esperado entre camadas:

```txt
interface
↓
aplicação
↓
domínio
↓
contratos de serviços e repositórios
↓
infraestrutura / persistência
```

Regras:

- A interface chama a aplicação.
- A aplicação usa domínio e contratos.
- O domínio não depende de interface, banco ou sistema de arquivos.
- Infraestrutura e persistência implementam contratos definidos pela aplicação.
- Serviços técnicos não devem ficar espalhados por componentes visuais.
- Regras visuais devem ficar na interface e no design system.

## 8. entidades principais previstas

Entidades iniciais previstas:

- `Collection`: coleção ou linha de miniaturas.
- `ModelItem`: modelo, miniatura, peça, busto, base, kit ou estudo.
- `GalleryImage`: imagem vinculada a coleção ou modelo.
- `LinkedFile`: arquivo ou pasta vinculada.
- `LinkItem`: link global ou específico.
- `FavoriteItem`: favorito global ou fixado.
- `Material`: material ou utensílio do atelier.
- `ModelMaterial`: vínculo entre modelo e material.
- `PrintQueueItem`: item da fila de impressão.
- `ChecklistItem`: item de checklist de produção.
- `ProductionHistoryEntry`: histórico de produção.
- `Tag`: tag reutilizável.
- `AppSetting`: configuração simples.
- `PathSetting`: caminho local ou de rede configurado.
- `FolderTemplate`: modelo de pastas para coleções e modelos.
- `RecentFileEntry`: arquivo acessado, vinculado ou alterado recentemente.

Enums e tipos previstos:

- status de coleção;
- status de modelo;
- status de fila de impressão;
- tipo de imagem;
- tipo de arquivo;
- categoria de link;
- tipo de material;
- tipo de caminho;
- tema visual;
- densidade da interface.

A modelagem detalhada deve ficar no documento `docs/12-modelagem-do-banco.md`.

## 9. serviços principais previstos

Serviços internos previstos:

- `CollectionService`: criação, edição, arquivamento, listagem e busca de coleções.
- `ModelService`: criação, edição, status, checklist e histórico de modelos.
- `GalleryService`: vínculo de imagens, definição de capa e filtros de galeria.
- `FileCatalogService`: cadastro, validação e metadados de arquivos vinculados.
- `FileSystemService`: abertura, cópia, movimentação e verificação de arquivos e pastas.
- `NetworkPathService`: teste e status de caminhos de rede.
- `PrintQueueService`: controle da fila de impressão e envio para destino configurado.
- `LinkService`: links globais e específicos.
- `FavoriteService`: favoritos globais e barra rápida.
- `MaterialService`: cadastro e vínculo de materiais.
- `SettingsService`: leitura e gravação de configurações.
- `ThemeService`: tema claro, escuro, automático, cor de destaque e densidade.
- `SearchService`: busca global.
- `BackupService`: exportação, importação e backup do banco e configurações.
- `SlugService`: criação de slugs consistentes.
- `RecentFilesService`: registro e consulta de arquivos recentes.

Serviços devem ser pequenos, testáveis e focados em uma responsabilidade clara.

## 10. estratégia de banco SQLite

O SQLite será o banco local do Blue Atelier.

Estratégia:

- Usar um arquivo de banco local, em pasta controlada pelo app ou configurada pelo usuário.
- Usar Entity Framework Core para acesso ao banco.
- Usar migrations para evoluir o schema de forma controlada.
- Guardar apenas metadados e relações.
- Não armazenar arquivos pesados no banco.
- Usar índices em campos de busca, slugs, status, tags e relações frequentes.
- Ter estratégia de backup manual antes de alterações importantes.
- Evitar complexidade de multiusuário, permissões ou sincronização online.

Dados que devem ficar no banco:

- títulos;
- descrições;
- slugs;
- status;
- tags;
- links;
- caminhos;
- relações entre entidades;
- configurações;
- histórico;
- timestamps;
- favoritos;
- metadados de arquivos.

Dados que não devem ficar no banco:

- imagens originais;
- STL;
- OBJ;
- 3MF;
- BLEND;
- CTB;
- projetos de slicer;
- fotos finais;
- vídeos;
- documentos pesados.

Observação importante: SQLite é adequado para o uso pessoal e local do Blue Atelier, mas alterações futuras de schema devem ser planejadas com cuidado, pois algumas mudanças exigem rebuild de tabela nas migrations.

## 11. estratégia de sistema de arquivos

O sistema de arquivos é parte central do app.

Estratégia:

- O app deve organizar arquivos reais em pastas reais do Windows.
- O banco deve guardar os caminhos e metadados.
- O app deve criar estruturas de pastas para coleções e modelos quando autorizado.
- O usuário deve poder configurar o modelo padrão de pastas.
- O app deve abrir arquivos e pastas usando recursos do Windows.
- O app deve detectar arquivos ausentes.
- O app deve evitar operações destrutivas sem confirmação.
- O app deve preservar arquivos fora do banco.

O documento específico `docs/13-sistema-de-arquivos.md` deve detalhar:

- nomes de pastas;
- regras de slug;
- extensões aceitas;
- categorias de arquivo;
- cópia e movimentação;
- tratamento de conflitos;
- caminhos locais e de rede.

## 12. estratégia para caminhos de rede

O Blue Atelier deve suportar caminhos locais, unidades mapeadas e caminhos UNC.

Exemplos:

```txt
D:\atelier-3d\
Z:\atelier-3d\
\\atelier-notebook\fila-impressao\
\\desktop-atelier\arquivos-3d\
\\192.168.18.50\atelier-3d\
```

Estratégia:

- Caminhos de rede serão cadastrados nas configurações.
- Cada caminho terá nome, tipo, endereço, status, último teste e observação.
- O app deve testar acessibilidade sob demanda.
- Caminho offline não deve travar o app.
- A tela inicial pode exibir aviso quando um caminho importante estiver offline.
- A fila de impressão deve verificar o destino antes de copiar arquivos.
- O app deve diferenciar erro de caminho inexistente, offline ou sem permissão quando possível.

O app não deve depender de rede para abrir ou consultar dados locais.

## 13. estratégia para configurações

Configurações serão tratadas como parte central do app.

Categorias previstas:

- caminhos principais;
- caminhos de rede;
- modelo padrão de pastas;
- tema;
- tamanho de cards;
- densidade da interface;
- programas padrão;
- backup;
- importação e exportação.

Estratégia:

- Configurações simples podem ser guardadas em tabela própria no SQLite.
- Configurações estruturadas podem usar entidades específicas, como `PathSetting` e `FolderTemplate`.
- Configurações devem ser acessadas por `SettingsService`.
- Alterações de configuração devem ser validadas antes de salvar.
- Caminhos devem poder ser testados sem obrigar o usuário a salvar primeiro.
- Configurações visuais devem respeitar o design system aprovado.

## 14. estratégia para temas claro e escuro

O app deve ter tema claro, tema escuro e, se aprovado, tema automático.

Estratégia:

- Usar CSS próprio com variáveis de tema.
- Separar tokens visuais de componentes.
- Centralizar cores, fundos, bordas, sombras e textos no design system.
- Aplicar tema pela configuração do usuário.
- Evitar cores espalhadas diretamente nos componentes.
- Manter a cor azul como destaque moderado.
- Testar telas principais nos dois temas antes de aprovar visual.

O documento `docs/08-design-system.md` será a fonte principal para decisões visuais.

Depois de aprovado, o visual não deve ser alterado pelo Codex sem ordem explícita.

## 15. estratégia para favoritos

Favoritos serão tratados como atalhos globais do atelier.

Estratégia:

- Permitir favoritos globais independentes de coleção ou modelo.
- Permitir links específicos marcados como favoritos.
- Permitir, se aprovado, favoritar coleções, modelos ou materiais.
- Separar favorito de link quando necessário, para permitir favoritos de tipos diferentes.
- Ter barra rápida de favoritos.
- Ter página completa de favoritos.
- Permitir busca, categorias, edição e remoção.

Favoritos devem abrir links externos no navegador padrão ou navegar para itens internos do app, conforme o tipo.

## 16. estratégia para galeria e imagens

Galerias serão visuais e baseadas em arquivos externos.

Estratégia:

- Imagens permanecem no sistema de arquivos.
- O banco guarda caminho, título, descrição, tags, tipo e relação com coleção ou modelo.
- A galeria pode existir em coleção e modelo.
- Uma imagem pode ser definida como capa.
- A tela deve lidar com imagem ausente.
- O app deve permitir abrir a imagem no visualizador padrão.
- Filtros por tipo devem ser rápidos e simples.

Tipos de imagem previstos:

- referência;
- render;
- pintura;
- processo;
- foto final;
- paleta;
- textura;
- outro.

Miniaturas, cache ou otimização de imagens podem ser planejados depois, se o desempenho exigir.

## 17. estratégia para fila de impressão

A fila de impressão será uma área operacional, não um controlador direto da impressora.

Estratégia:

- Cada item da fila aponta para um modelo e, quando possível, para um arquivo vinculado.
- O item guarda caminho do arquivo pronto e destino configurado.
- O status da fila deve ser persistido.
- A fila deve registrar tentativas e observações.
- O app deve copiar arquivo para pasta local ou de rede quando solicitado.
- O app deve testar destino antes de copiar.
- O app deve registrar falha quando caminho estiver offline ou arquivo estiver ausente.
- O app deve evitar sobrescrever arquivos sem confirmação.

Status previstos:

- aguardando fatiamento;
- pronto para enviar;
- enviado;
- imprimindo;
- impresso;
- falhou;
- cancelado;
- arquivado.

## 18. estratégia para testes

Testes devem acompanhar as áreas de maior risco.

Prioridades:

- regras de domínio;
- geração de slugs;
- transições de status;
- serviços de aplicação;
- validação de caminhos;
- serviços de arquivos com abstrações testáveis;
- persistência SQLite;
- busca global;
- fila de impressão;
- backup e restauração.

Estratégia:

- Começar com testes unitários para domínio e aplicação.
- Usar testes de integração para SQLite quando a persistência existir.
- Usar diretórios temporários para testes de sistema de arquivos.
- Simular caminhos offline quando possível.
- Não exigir testes visuais antes da existência de telas.
- Criar checklist manual para fluxos que dependem do Windows.

Quando houver interface implementada, devem existir validações visuais manuais e, se fizer sentido, automações leves para fluxos críticos.

## 19. estratégia para build e execução local

Durante desenvolvimento:

- Executar o app localmente no Windows.
- Usar build de Debug para desenvolvimento.
- Usar build de Release para validação de empacotamento.
- Confirmar a versão do .NET e workloads necessários antes de criar o projeto.
- Registrar comandos reais no documento `docs/11-comandos-codex.md`.
- Validar build em cada tarefa que alterar código.

Para entrega local futura:

- Avaliar publicação como MSIX quando houver maturidade.
- Avaliar publicação sem instalador se for mais simples para uso pessoal.
- Documentar pré-requisitos, como runtime necessário.
- Manter instruções claras de execução e backup.

O empacotamento não deve ser tratado agora. Ele pertence a uma fase posterior.

## 20. limites do Codex em relação ao visual

O Codex é o engenheiro principal de implementação do projeto, mas não tem liberdade para alterar visual aprovado.

Limites:

- Não alterar layout aprovado sem autorização.
- Não alterar cores aprovadas sem autorização.
- Não alterar espaçamentos aprovados sem autorização.
- Não alterar tipografia aprovada sem autorização.
- Não trocar componentes visuais aprovados sem autorização.
- Não mudar hierarquia visual aprovada sem autorização.
- Não redesenhar telas por iniciativa própria.
- Não implementar tela antes de existir orientação visual suficiente.

Quando a tarefa envolver visual, Codex deve:

- ler o design system;
- respeitar o mapa de telas;
- implementar apenas o que foi pedido;
- fornecer evidência visual quando houver tela;
- registrar mudanças no estado atual.

## 21. uso econômico de Antigravity e Stitch

### Stitch

Stitch deve ser usado apenas para ideação visual estratégica.

Uso adequado:

- explorar layout da tela inicial;
- explorar tela de coleção;
- explorar tela do modelo;
- explorar área de favoritos;
- explorar configurações;
- comparar estilos de mosaico e cards.

Stitch não deve ser usado como fonte final de código.

### Antigravity

Antigravity deve ser usado com economia, em momentos estratégicos.

Uso adequado:

- revisar tarefas maiores;
- ajudar em validações;
- explorar problemas difíceis;
- revisar arquitetura ou fluxos;
- apoiar quando houver muito contexto de implementação.

Antigravity não deve substituir o Codex como engenheiro principal do projeto.

O fluxo padrão continua sendo:

1. documentação orienta;
2. Codex implementa uma tarefa pequena;
3. Codex valida;
4. Codex atualiza estado atual;
5. Codex faz commit e push;
6. usuário solicita validação externa antes da próxima tarefa.

## 22. próximos passos depois da arquitetura

Próxima tarefa sugerida:

```txt
docs/07-mapa-de-telas.md
```

Esse documento deve definir:

- telas principais;
- navegação;
- hierarquia visual esperada;
- conteúdo de cada tela;
- ações disponíveis;
- estados vazios;
- estados de erro;
- relação entre tela inicial, coleções, modelos, favoritos, materiais, fila de impressão, busca e configurações.

Depois do mapa de telas, a sequência recomendada é:

1. criar `docs/08-design-system.md`;
2. criar `docs/09-prompts-stitch.md`;
3. criar `docs/10-prompts-antigravity.md`;
4. criar `docs/11-comandos-codex.md`;
5. criar `docs/12-modelagem-do-banco.md`;
6. criar `docs/13-sistema-de-arquivos.md`;
7. criar `docs/14-checklist-de-validacao.md`;
8. só então iniciar a criação controlada da solução .NET.

## 23. referências técnicas consultadas

- [Microsoft Learn — .NET MAUI BlazorWebView e Blazor Hybrid](https://learn.microsoft.com/en-us/dotnet/maui/user-interface/controls/blazorwebview)
- [Microsoft Learn — migrations no Entity Framework Core](https://learn.microsoft.com/en-us/ef/core/managing-schemas/migrations/)
- [Microsoft Learn — limitações do provider SQLite no Entity Framework Core](https://learn.microsoft.com/en-us/ef/core/providers/sqlite/limitations)
- [Microsoft Learn — publicação de apps .NET MAUI no Windows](https://learn.microsoft.com/en-us/dotnet/maui/windows/deployment/overview)
