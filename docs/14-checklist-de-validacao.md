# blue atelier - checklist de validação

## 1. objetivo do checklist

Este documento define critérios de validação para cada tipo de tarefa do **Blue Atelier**.

O objetivo é garantir que cada etapa futura tenha critérios claros para saber se foi concluída corretamente antes de avançar.

Este checklist deve ser usado por:

- Codex, ao concluir uma tarefa;
- ChatGPT, ao validar o repositório remoto;
- usuário, ao aprovar ou reprovar a próxima etapa;
- Antigravity, quando for usado como apoio estratégico de revisão.

Este documento não cria código, projeto .NET, telas, CSS, banco ou arquivos reais do app.

## 2. regra geral de validação

Toda tarefa deve ser validada antes de ser considerada concluída.

Regra geral:

1. Confirmar que a tarefa solicitada foi entendida.
2. Confirmar que os documentos obrigatórios foram lidos.
3. Confirmar que apenas o escopo solicitado foi alterado.
4. Confirmar que `docs/03-estado-atual.md` foi atualizado.
5. Confirmar que `docs/04-proximos-documentos.md` foi atualizado quando necessário.
6. Executar validações documentais, técnicas, visuais, build ou testes conforme o tipo da tarefa.
7. Executar `git status`.
8. Adicionar somente os arquivos corretos.
9. Criar commit próprio.
10. Fazer push para o repositório remoto.
11. Informar o resultado ao usuário.

Nenhuma tarefa deve avançar para a próxima etapa sem commit, push e validação pelo fluxo combinado.

Regras obrigatórias consolidadas:

- tarefa documental não pode criar código;
- tarefa de implementação deve executar build quando possível;
- tarefa com testes deve executar testes relevantes;
- tarefa visual deve fornecer evidência visual futura;
- visual aprovado não pode ser alterado sem autorização;
- arquivos pesados não podem ir para o SQLite;
- remover vínculo não pode apagar arquivo real;
- caminho de rede offline não pode travar o app;
- commit e push são obrigatórios;
- GitHub é fonte de verdade;
- ChatGPT valida o repositório remoto;
- usuário aprova a próxima etapa.

## 3. validação de tarefa documental

Tarefas documentais criam ou atualizam documentos do projeto.

Validar:

- O documento pedido foi criado ou atualizado.
- Nenhum código do aplicativo foi criado.
- Nenhum projeto .NET foi criado.
- Nenhuma tela real foi criada.
- Nenhum CSS real foi criado.
- O texto está claro, simples e operacional.
- O documento respeita decisões anteriores.
- Não houve alteração de stack sem pedido.
- Não houve alteração visual.
- `docs/03-estado-atual.md` registra a tarefa concluída.
- `docs/04-proximos-documentos.md` foi atualizado se a tarefa criou novo documento.

Reprovar se:

- A tarefa documental criou código do app.
- O documento ignora regras já aprovadas.
- O escopo foi ampliado sem autorização.
- O commit mistura documentação com implementação.

## 4. validação de arquitetura

Tarefas de arquitetura devem preservar a stack e a separação de responsabilidades já definidas.

Validar:

- A stack oficial foi respeitada.
- A arquitetura continua baseada em .NET MAUI Blazor Hybrid, C#, SQLite, Entity Framework Core, Razor Components e CSS próprio.
- A separação entre interface, domínio, aplicação, infraestrutura e persistência está clara.
- O documento ou implementação não mistura responsabilidades.
- A arquitetura considera arquivos locais e caminhos de rede.
- O SQLite continua limitado a metadados, caminhos e relações.
- O visual aprovado não foi alterado.
- Decisões novas foram registradas no estado atual.

Reprovar se:

- A stack foi trocada sem autorização.
- A arquitetura incentiva guardar arquivos pesados no banco.
- A interface passa a acessar diretamente banco ou sistema de arquivos sem camada adequada.

## 5. validação de UI/UX planejada

Tarefas de UI/UX planejada descrevem fluxos, telas e experiência sem implementar telas reais.

Validar:

- O mapa de telas foi respeitado.
- A navegação lateral mantém as áreas principais.
- A hierarquia coleção > modelo > detalhes continua clara.
- As ações principais de cada tela foram descritas.
- Estados vazios, erro, offline, sucesso e carregamento foram considerados.
- Mosaicos, listas, tabelas e formulários foram usados conforme a função de cada área.
- A proposta evita aparência de dashboard corporativo.
- Não foi criado código, Razor Component ou CSS.
- O visual aprovado permanece protegido.

Reprovar se:

- A tarefa cria tela real quando era apenas planejamento.
- A UX contradiz o mapa de telas.
- O fluxo ignora arquivos locais, rede, favoritos, materiais ou fila de impressão.

## 6. validação de design system

Tarefas de design system devem preservar a linguagem visual oficial do Blue Atelier.

Validar:

- O visual permanece moderno, minimalista, neutro e confortável.
- O azul continua sendo apenas cor de destaque.
- Tema claro e tema escuro seguem a paleta definida.
- Tipografia, espaçamentos, bordas e sombras permanecem coerentes.
- Cards, mosaicos, listas, formulários e estados visuais seguem as diretrizes.
- Acessibilidade básica foi considerada.
- Não há aparência de sistema administrativo pesado.
- Regras de proteção do visual aprovado continuam explícitas.

Reprovar se:

- O design vira paleta dominada por azul.
- O visual aprovado é alterado sem autorização.
- A proposta cria um design system paralelo.

## 7. validação de prompts para Stitch

Prompts para Stitch devem servir apenas para ideação visual e refinamento de UI/UX.

Validar:

- Os prompts deixam claro que Stitch não é fonte final de código.
- Cada prompt tem objetivo visual, contexto, layout, elementos obrigatórios, estilo, o que evitar e observações de UX.
- O prompt mestre resume o app inteiro.
- Os prompts pedem visual neutro, moderno, confortável e com azul apenas como destaque.
- Os prompts evitam dashboard corporativo, SaaS, CRM, landing page e sistema pesado.
- As regras para avaliar saídas do Stitch estão registradas.
- O visual aprovado fica protegido contra alterações futuras sem autorização.

Reprovar se:

- O prompt pede código final ao Stitch.
- O prompt contradiz o design system.
- O prompt incentiva aparência corporativa ou comercial.

## 8. validação de prompts para Antigravity

Prompts para Antigravity devem economizar uso e focar revisão estratégica.

Validar:

- O documento reforça que Codex é o engenheiro principal.
- Antigravity aparece apenas como apoio estratégico.
- Cada prompt define objetivo, contexto, o que verificar, o que não fazer e formato de resposta.
- O uso do Antigravity é limitado a revisão, investigação, validação e apoio em problemas difíceis.
- O documento reforça que ele não deve alterar visual aprovado sem ordem explícita.
- O fluxo de GitHub como fonte de verdade está claro.
- Commit, push e validação continuam obrigatórios.

Reprovar se:

- Antigravity vira substituto do Codex.
- O prompt autoriza alteração visual sem aprovação.
- O prompt incentiva refatoração ampla ou tarefa fora de escopo.

## 9. validação de comandos para Codex

Comandos para Codex devem orientar tarefas futuras de forma operacional.

Validar:

- O papel do Codex está claro.
- O checklist antes de começar está completo.
- Os documentos obrigatórios estão listados.
- O fluxo para identificar a próxima tarefa em `docs/03-estado-atual.md` está descrito.
- Existem modelos de prompt para documentação, implementação, bug e validação.
- Existem regras para commits e push.
- O documento reforça uma tarefa por vez.
- O documento proíbe código em tarefa documental.
- O documento proíbe alterar visual aprovado sem autorização.

Reprovar se:

- O comando permite pular leitura obrigatória.
- O comando permite avançar sem commit e push.
- O comando permite mudar stack ou visual sem pedido explícito.

## 10. validação de modelagem do banco

Modelagem do banco deve manter o SQLite leve e orientado a metadados.

Validar:

- As entidades principais estão definidas.
- Os relacionamentos estão coerentes com coleção, modelo, galeria, arquivos, links, favoritos, materiais e fila.
- Enums principais foram definidos.
- Índices recomendados foram registrados.
- Arquivos pesados estão explicitamente fora do banco.
- Caminhos são tratados como texto e metadados.
- Arquivos ausentes e caminhos offline são estados esperados.
- Soft delete, arquivamento e backup foram considerados.
- Migrations futuras seguem Entity Framework Core.

Reprovar se:

- Imagens originais, STL, OBJ, 3MF, BLEND, CTB ou projetos de slicer entram no banco.
- Remover vínculo implica apagar arquivo real.
- Caminho de rede offline quebra consultas locais.

## 11. validação de sistema de arquivos

Sistema de arquivos deve tratar arquivos reais do Windows com segurança.

Validar:

- A pasta principal do atelier está prevista.
- Estruturas padrão de coleção e modelo estão definidas.
- Regras de nomes, slugs e extensões aceitas estão claras.
- Caminhos locais, unidades mapeadas e caminhos UNC são aceitos.
- Arquivo ausente permanece registrado.
- Pasta ausente permanece registrada.
- Caminho de rede offline não trava o app.
- Remover vínculo não apaga arquivo real.
- Operações de mover, sobrescrever e excluir exigem confirmação futura.
- Arquivos pesados continuam fora do SQLite.

Reprovar se:

- O app apaga arquivo real sem autorização explícita.
- O app remove vínculo e exclui arquivo automaticamente.
- Caminho offline é tratado como erro fatal.

## 12. validação de criação da solução .NET

Quando a solução .NET for criada, ela deve ser mínima, alinhada à arquitetura e sem features fora do escopo.

Validar:

- A solução foi criada com a stack oficial.
- O app é voltado para Windows local.
- A solução compila, quando o ambiente permitir.
- Nenhuma tela final foi criada sem etapa visual aprovada.
- Nenhum banco físico definitivo foi criado sem tarefa específica.
- A estrutura respeita `src/`, `tests/` e `docs/`, se adotada conforme arquitetura.
- O README ou documentação de execução foi atualizado, se solicitado.
- `docs/03-estado-atual.md` registra comandos e validações.

Reprovar se:

- A solução usa stack diferente sem autorização.
- A criação da solução já implementa features fora do escopo.
- A solução não compila e o erro não é registrado.

## 13. validação de estrutura de projetos

Estrutura de projetos deve refletir a arquitetura oficial.

Validar:

- Existe separação clara entre App, Domain, Application, Infrastructure e Persistence, se essa estrutura for criada.
- Projetos de teste ficam separados em `tests/`.
- Namespaces seguem padrão do projeto.
- Pastas não misturam interface com persistência ou infraestrutura.
- A solução não contém projetos desnecessários.
- Arquivos gerados automaticamente não viram lugar de regra de negócio indevida.
- Referências entre projetos fazem sentido.

Reprovar se:

- Domain depende de App, banco ou infraestrutura.
- Componentes visuais acessam diretamente o SQLite.
- Serviços de arquivo ficam espalhados em telas.

## 14. validação de camadas e dependências

As camadas devem manter dependências previsíveis.

Fluxo esperado:

```txt
interface
↓
aplicação
↓
domínio
↓
contratos
↓
infraestrutura / persistência
```

Validar:

- Interface chama casos de uso ou serviços de aplicação.
- Aplicação coordena regras e serviços.
- Domínio contém regras puras e não depende de tecnologia.
- Infraestrutura implementa acesso a arquivos, Windows e rede.
- Persistência implementa SQLite, EF Core, migrations e consultas.
- Dependências não formam ciclos.
- Abstrações são criadas quando houver necessidade real.

Reprovar se:

- Domínio importa EF Core, MAUI ou Blazor.
- Interface executa manipulação direta de arquivos sem serviço.
- Camadas foram criadas apenas como enfeite sem responsabilidade clara.

## 15. validação de entidades de domínio

Entidades de domínio devem representar conceitos reais do atelier.

Validar:

- Entidades seguem a modelagem aprovada.
- Nomes estão coerentes com `Collection`, `ModelItem`, `GalleryImage`, `LinkedFile`, `Material`, `PrintQueueItem` e demais entidades.
- Campos obrigatórios são validados.
- Status e enums são coerentes.
- Slugs seguem regra definida.
- Relações principais existem.
- Arquivamento é preferido a exclusão real.
- Nenhuma entidade guarda conteúdo pesado de arquivo.

Reprovar se:

- Entidade mistura UI, banco e sistema de arquivos.
- Entidade armazena imagem ou arquivo binário.
- Relações centrais da modelagem foram ignoradas.

## 16. validação de SQLite/EF Core

Persistência SQLite deve ser simples, local e confiável.

Validar:

- EF Core é usado conforme arquitetura.
- SQLite armazena apenas metadados, relações, caminhos, status e configurações.
- Enums são persistidos de forma legível, se a decisão for manter texto.
- Índices importantes foram criados quando necessários.
- Consultas principais funcionam para coleções, modelos, arquivos, favoritos e fila.
- Caminhos são salvos como texto.
- Arquivos pesados não entram no banco.
- Backup do banco foi considerado.

Reprovar se:

- Conteúdo de arquivo é salvo no SQLite.
- Consultas dependem de caminho de rede estar online.
- Repositórios ou contexto vazam indevidamente para a interface.

## 17. validação de migrations

Migrations devem evoluir o banco de forma controlada.

Validar:

- A migration corresponde a uma mudança pequena e clara.
- O nome da migration descreve a alteração.
- A migration foi revisada antes de aplicar.
- Banco novo é criado corretamente.
- Banco existente é atualizado corretamente, quando aplicável.
- Alterações destrutivas têm backup ou plano de recuperação.
- Limitações do SQLite foram consideradas.
- Testes de persistência foram executados quando existirem.

Reprovar se:

- A migration mistura várias mudanças sem relação.
- A migration apaga dados sem plano.
- A migration cria coluna para armazenar arquivo pesado.

## 18. validação de serviços internos

Serviços internos devem ser pequenos, claros e testáveis.

Validar:

- Cada serviço tem responsabilidade definida.
- Serviços de arquivo, rede, banco, configurações, tema, favoritos, galeria, busca e fila seguem a arquitetura.
- Componentes visuais não concentram regras técnicas.
- Serviços retornam erros tratáveis pela interface.
- Operações perigosas exigem confirmação futura.
- Serviços usam abstrações quando necessário para testes.
- Logs ou mensagens de erro são úteis, quando existirem.

Reprovar se:

- Um serviço vira classe gigante para tudo.
- Serviço apaga ou move arquivo sem autorização.
- Serviço bloqueia o app por caminho de rede offline.

## 19. validação de arquivos e caminhos

Fluxos de arquivos devem preservar dados reais.

Validar:

- Arquivos são vinculados por caminho.
- Metadados são persistidos no banco.
- Arquivos pesados permanecem no sistema de arquivos.
- Arquivo ausente continua visível.
- Pasta ausente continua visível.
- Copiar caminho não exige arquivo existir.
- Abrir arquivo valida existência.
- Copiar arquivo não sobrescreve sem confirmação.
- Mover arquivo exige confirmação.
- Remover vínculo não exclui arquivo real.

Reprovar se:

- Arquivo real é apagado ao remover vínculo.
- Arquivo pesado é importado para o SQLite.
- Caminho inválido causa travamento.

## 20. validação de caminhos de rede

Caminhos de rede devem ser tolerantes a falhas.

Validar:

- Caminhos UNC são aceitos.
- Unidades mapeadas são aceitas.
- Caminhos por IP são aceitos.
- Status online, offline, inválido e sem permissão são tratados.
- Último teste é registrado quando aplicável.
- Rede offline não bloqueia uso local.
- Fila de impressão testa destino antes de copiar.
- A interface futura mostra aviso claro, sem alarme exagerado.

Reprovar se:

- O app trava tentando acessar rede offline.
- O app exige rede para abrir dados locais.
- O app apaga ou limpa registros por falha temporária de rede.

## 21. validação de fila de impressão

A fila de impressão organiza arquivos e status, sem controlar impressora diretamente.

Validar:

- Item da fila aponta para modelo e arquivo quando possível.
- Status segue `PrintQueueStatus`.
- Origem e destino são registrados.
- Destino pode ser local ou de rede.
- Destino offline gera aviso ou falha recuperável.
- Arquivo ausente permanece na fila com status claro.
- Cópia para destino não sobrescreve sem confirmação.
- Histórico de tentativa é registrado quando implementado.
- A fila não tenta controlar a impressora.

Reprovar se:

- A fila remove item automaticamente por falha.
- A fila sobrescreve arquivo no destino sem confirmar.
- A fila depende da rede para carregar a tela.

## 22. validação de configurações

Configurações devem ser completas, claras e seguras.

Validar:

- Caminhos locais podem ser cadastrados.
- Caminhos de rede podem ser cadastrados.
- Caminhos podem ser testados sem salvar, se implementado.
- Modelo padrão de pastas pode ser definido sem alterar pastas antigas automaticamente.
- Tema e densidade respeitam o design system.
- Backup tem caminho configurável.
- Configurações são persistidas no SQLite ou estrutura definida.
- Alterações perigosas exigem confirmação.

Reprovar se:

- Configuração altera arquivos reais sem confirmação.
- Configuração visual permite quebrar o design system aprovado.
- Caminho do usuário é trocado automaticamente.

## 23. validação de busca global

Busca global deve localizar itens importantes sem virar fluxo pesado.

Validar:

- Busca encontra coleções.
- Busca encontra modelos.
- Busca encontra tags.
- Busca encontra links.
- Busca encontra arquivos.
- Busca encontra materiais.
- Busca encontra notas, descrições ou histórico quando implementado.
- Resultados são agrupados por tipo.
- Resultado de arquivo mostra status de ausente ou caminho offline.
- Busca não depende de arquivo ou rede estar acessível.

Reprovar se:

- Busca só pesquisa uma área quando deveria ser global.
- Busca quebra ao encontrar arquivo ausente.
- Busca fica lenta sem plano de índice ou otimização.

## 24. validação de favoritos

Favoritos devem funcionar como atalhos pessoais do atelier.

Validar:

- Favoritos globais podem representar links externos.
- Favoritos podem apontar para itens internos, se aprovado.
- Barra rápida de favoritos respeita itens fixados.
- Favorito externo abre no navegador padrão.
- Favorito interno navega para o item correto.
- Favorito inválido ou arquivado é tratado com estado claro.
- Categorias e busca ajudam a localizar favoritos.
- Visual de favoritos segue o design system.

Reprovar se:

- Favorito mistura link externo e item interno sem distinção.
- Favorito removido quebra a barra rápida.
- Favoritos viram área visual fora do padrão aprovado.

## 25. validação de materiais

Materiais devem ser úteis sem virar controle de estoque complexo, salvo tarefa futura.

Validar:

- Material tem nome e tipo.
- Marca, cor, fornecedor, link e observação são opcionais.
- Materiais podem ser vinculados a modelos.
- `ModelMaterial` registra vínculo e uso, quando implementado.
- Busca e filtros funcionam conforme escopo.
- Link de compra abre corretamente.
- Favoritar material respeita regras de favoritos, se aprovado.
- Materiais arquivados não somem sem histórico.

Reprovar se:

- A tela vira estoque complexo sem pedido.
- Material excluído quebra modelo relacionado.
- Link externo é tratado como dado obrigatório.

## 26. validação de galeria

Galeria deve ser visual e baseada em arquivos externos.

Validar:

- Imagens ficam no sistema de arquivos.
- Banco guarda caminho e metadados.
- Tipos de imagem seguem `ImageType`.
- Imagem pode ser vinculada a coleção ou modelo.
- Imagem pode ser definida como capa.
- Imagem ausente mostra placeholder futuro.
- Remover imagem da galeria remove vínculo, não arquivo real.
- Mosaico permanece estável.
- Filtros por tipo funcionam quando implementados.

Reprovar se:

- Imagem original é salva no SQLite.
- Galeria quebra com imagem ausente.
- Definir capa altera arquivo real sem necessidade.

## 27. validação de tela implementada

Quando uma tela real for implementada, deve ser validada funcional e visualmente.

Validar:

- A tela corresponde ao mapa de telas.
- A tela respeita o design system.
- A tela não cria áreas fora do escopo.
- A navegação funciona.
- A ação principal está visível.
- Estados vazios foram considerados.
- Erros e offline foram considerados quando relevantes.
- Dados exibidos vêm das camadas corretas.
- Visual aprovado foi preservado.
- Evidência visual foi fornecida.

Reprovar se:

- A tela muda visual aprovado sem autorização.
- A tela acessa banco ou arquivos de forma indevida.
- A tela implementa features extras.

## 28. validação visual

Validação visual deve conferir aparência, consistência e proteção do visual aprovado.

Validar:

- Não há textos cortados.
- Não há sobreposição de elementos.
- Mosaicos têm proporção estável.
- Cards mantêm hierarquia visual.
- Botões são legíveis.
- Estados visuais são claros.
- Azul é usado com moderação.
- Interface evita aparência corporativa pesada.
- Navegação lateral e barra superior estão coerentes.
- Visual aprovado não foi alterado sem autorização.

Evidências futuras:

- screenshot da tela;
- screenshot de estado vazio;
- screenshot de erro ou offline quando relevante;
- screenshot em tema claro e escuro quando existirem.

## 29. validação de tema claro

Tema claro deve ser confortável e neutro.

Validar:

- Fundo claro segue paleta aprovada.
- Superfícies são legíveis.
- Texto tem contraste suficiente.
- Bordas são discretas.
- Sombras são sutis.
- Azul aparece apenas em ação, foco, link ou seleção.
- Cards e mosaicos valorizam imagens.
- Estados de erro, sucesso e offline são legíveis.

Reprovar se:

- Tema claro fica branco agressivo demais.
- Azul domina a interface.
- Texto fica com baixo contraste.

## 30. validação de tema escuro

Tema escuro deve ser confortável para uso prolongado.

Validar:

- Fundo escuro não é preto absoluto agressivo.
- Superfícies têm separação clara.
- Texto principal é legível sem brilho excessivo.
- Texto secundário é legível.
- Azul permanece moderado.
- Estados de erro e offline são claros.
- Imagens continuam protagonistas.
- Componentes não somem por falta de contraste.

Reprovar se:

- Tema escuro vira paleta azul escura dominante.
- Contraste fica agressivo ou fraco demais.
- Estados visuais perdem leitura.

## 31. validação de estados vazios

Estados vazios devem orientar a próxima ação.

Validar:

- Mensagem é curta e clara.
- A ação principal faz sentido.
- Estado vazio não parece erro.
- Coleções sem dados sugerem criar coleção.
- Coleção sem modelos sugere criar modelo.
- Galeria vazia sugere adicionar imagem.
- Fila vazia explica que arquivos prontos aparecerão ali.
- Favoritos vazios sugerem adicionar link ou item.
- Materiais vazios sugerem cadastrar material.

Reprovar se:

- Estado vazio culpa o usuário.
- Estado vazio não oferece próximo passo.
- Estado vazio ocupa espaço demais ou parece landing page.

## 32. validação de erros e offline

Erros e offline devem ser claros, úteis e não alarmistas.

Validar:

- Erro explica o que aconteceu.
- Erro sugere próxima ação.
- Detalhe técnico fica disponível apenas quando útil.
- Caminho de rede offline é tratado como condição normal.
- Arquivo ausente permanece registrado.
- Pasta ausente permanece registrada.
- Offline não bloqueia uso local.
- Usuário pode tentar novamente ou abrir configurações.
- Mensagens não culpam o usuário.

Reprovar se:

- Erro trava a aplicação inteira sem necessidade.
- Offline apaga registros ou vínculos.
- Mensagem é vaga demais para agir.

## 33. validação de testes

Quando houver código, testes devem acompanhar risco e impacto.

Validar:

- Testes relevantes foram executados.
- Falhas foram corrigidas ou registradas.
- Testes cobrem domínio quando regras forem alteradas.
- Testes cobrem persistência quando banco for alterado.
- Testes cobrem serviços de arquivos quando operações forem implementadas.
- Testes cobrem caminhos de rede com simulação ou caso controlado quando possível.
- Testes não dependem de dados reais do usuário.
- Diretórios temporários são usados para testes de arquivo.

Reprovar se:

- Teste falhando foi ignorado.
- Teste foi apagado para passar build.
- Tarefa de código relevante não rodou testes sem justificativa.

## 34. validação de build

Build deve ser executado em tarefas de implementação sempre que possível.

Validar:

- Comando de build correto foi executado.
- Resultado foi registrado.
- Erros foram corrigidos ou explicados.
- Warnings relevantes foram avaliados.
- Build usa a solução correta.
- Ambiente ou workload ausente foi informado claramente.
- Tarefa documental não tentou executar build desnecessário.

Reprovar se:

- Código foi alterado e build possível não foi executado.
- Build falhou e a tarefa foi declarada concluída.
- Erros de build foram escondidos.

## 35. validação de commit

Cada tarefa concluída deve ter commit próprio.

Validar:

- `git status` foi executado antes do stage.
- Apenas arquivos da tarefa foram adicionados.
- `git diff --cached --name-only` ou conferência equivalente foi usada.
- Mensagem de commit segue a tarefa.
- Commit não mistura tarefas diferentes.
- Commit não inclui código em tarefa documental.
- Commit não inclui alteração visual não autorizada.

Reprovar se:

- Não há commit.
- O commit inclui arquivos fora do escopo.
- A mensagem não descreve a tarefa.

## 36. validação de push

Push é obrigatório ao final da tarefa.

Validar:

- Push foi feito para o remoto correto.
- Branch correta foi usada, normalmente `main`.
- O hash do commit local está no remoto.
- GitHub continua sendo fonte de verdade.
- Se o push falhou, isso foi informado ao usuário.
- ChatGPT poderá validar o repositório remoto.

Reprovar se:

- A tarefa foi declarada concluída sem push.
- Push falhou e foi omitido.
- Push foi feito para branch errada sem explicação.

## 37. validação antes de release local

Antes de uma versão local de uso real, a validação deve ser mais rigorosa.

Validar:

- Build em modo adequado foi executado.
- Testes automatizados relevantes passaram.
- Fluxos principais foram testados manualmente.
- Banco SQLite foi criado e acessado.
- Backup e restauração foram avaliados.
- Caminhos locais foram testados.
- Caminhos de rede offline foram testados.
- Galeria, favoritos, materiais e fila foram verificados.
- Tema claro e tema escuro foram conferidos.
- Documentação de execução local está atualizada.
- Visual aprovado foi preservado.

Reprovar se:

- Há falha de build.
- Há perda de dados conhecida.
- Há risco de apagar arquivos reais.
- Não há backup antes de operação arriscada.

## 38. checklist final para aprovar tarefa

Antes de aprovar uma tarefa, confirmar:

- O escopo pedido foi concluído.
- Nada fora do escopo foi criado.
- Documentos obrigatórios foram lidos.
- `docs/03-estado-atual.md` foi atualizado.
- `docs/04-proximos-documentos.md` foi atualizado quando necessário.
- Nenhum código foi criado em tarefa documental.
- Stack oficial foi preservada.
- Visual aprovado foi preservado.
- Arquivos pesados continuam fora do SQLite.
- Vínculos não apagam arquivos reais.
- Caminhos offline não travam o app.
- Build foi executado quando havia implementação.
- Testes relevantes foram executados quando existiam.
- Evidência visual foi fornecida quando havia tela.
- Commit foi criado.
- Push foi concluído.
- Próxima tarefa sugerida foi registrada.

Se todos os itens aplicáveis estiverem corretos, a tarefa pode ser aprovada.

## 39. critérios para reprovar tarefa

Uma tarefa deve ser reprovada se ocorrer qualquer problema crítico.

Critérios de reprovação:

- Código criado em tarefa documental.
- Projeto .NET criado antes da etapa aprovada.
- Tela real criada antes de visual aprovado.
- Visual aprovado alterado sem autorização.
- Stack oficial alterada sem autorização.
- Arquivo pesado salvo no SQLite.
- Arquivo real apagado sem autorização explícita.
- Remover vínculo apaga arquivo real.
- Caminho de rede offline trava o app.
- Build falha em tarefa de implementação e a falha não é resolvida.
- Testes relevantes falham e são ignorados.
- Commit não foi criado.
- Push não foi concluído.
- Escopo foi ampliado sem aprovação.
- `docs/03-estado-atual.md` não foi atualizado.

Quando uma tarefa for reprovada, a próxima ação deve ser corrigir a tarefa atual, não iniciar a próxima.

## 40. formato de relatório de validação

Formato recomendado para validar uma tarefa:

```txt
Status geral:
[Aprovada / Aprovada com ressalvas / Reprovada]

Tarefa validada:
[Nome ou descrição da tarefa]

Resumo:
[O que foi entregue]

Arquivos analisados:
- [arquivo 1]
- [arquivo 2]

Validações executadas:
- [validação 1]
- [validação 2]

Achados:
- [achado 1]
- [achado 2]

Riscos:
- [risco 1]
- [risco 2]

Pendências:
- [pendência 1]
- [pendência 2]

Commit:
[hash e mensagem]

Push:
[Concluído / Falhou / Não aplicável]

Decisão:
[Pode avançar / Corrigir antes de avançar]

Próxima etapa sugerida:
[Próxima tarefa aprovada ou sugestão]
```

Relatórios de validação devem ser objetivos. O foco é decidir se a tarefa atual está pronta para aprovação e se o projeto pode avançar com segurança.
