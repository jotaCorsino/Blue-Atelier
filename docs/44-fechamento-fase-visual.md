# fechamento da fase visual

## objetivo

Registrar o encerramento organizado da fase de implementacao visual do Blue Atelier baseada nas referencias Stitch, consolidando a cobertura implementada, o escopo removido, os padroes visuais aprovados e as regras de preservacao para a proxima fase funcional.

Este documento nao define novas telas e nao autoriza alteracoes visuais. Ele serve como trilha de auditoria e ponto de partida para a fase funcional.

## objetivo da fase visual

A fase visual teve como objetivo traduzir as referencias do Stitch para Razor Components e CSS proprio, criando uma base navegavel, responsiva e visualmente aprovada para o app local Blue Atelier.

As prioridades da fase foram:

- validar a identidade visual do atelier digital;
- criar as telas centrais de colecoes, modelos, imagens, arquivos vinculados, favoritos, busca e configuracoes;
- preservar uma paleta clean, moderna e azulada;
- manter os dados como mockados;
- evitar persistencia real antes da aprovacao visual;
- remover areas que aumentavam o escopo sem necessidade imediata.

## referencias Stitch usadas

Referencias usadas diretamente em telas mantidas:

- `referencias-visuais/stitch/html/01-inicio.html`;
- `referencias-visuais/stitch/html/02-colecoes.html`;
- `referencias-visuais/stitch/html/03-detalhe-colecao.html`;
- `referencias-visuais/stitch/html/04-detalhe-modelo.html`;
- `referencias-visuais/stitch/html/05-galeria-modelo.html`;
- `referencias-visuais/stitch/html/06-visualizacao-imagem.html`;
- `referencias-visuais/stitch/html/07-arquivos-vinculados.html`;
- `referencias-visuais/stitch/html/12-favoritos.html`;
- `referencias-visuais/stitch/html/13-busca-global.html`;
- `referencias-visuais/stitch/html/14-configuracoes-gerais.html`;
- `referencias-visuais/stitch/html/15-configuracoes-caminhos.html`;
- `referencias-visuais/stitch/html/16-configuracoes-aparencia.html`;
- `referencias-visuais/stitch/html/17-modelo-pastas.html`;
- `referencias-visuais/stitch/html/18-backup-dados.html`.

Referencia usada como padrao reutilizavel, nao como tela:

- `referencias-visuais/stitch/html/19-estados-vazios-erros-offline.html`.

Referencias consultadas que sairam do escopo visual atual:

- `referencias-visuais/stitch/html/08-fila-impressao.html`;
- `referencias-visuais/stitch/html/09-arquivos-recentes.html`;
- `referencias-visuais/stitch/html/10-materiais.html`;
- `referencias-visuais/stitch/html/11-detalhe-material.html`.

O arquivo `referencias-visuais/stitch/design.md` permaneceu como referencia de design protegida durante toda a fase.

## telas implementadas

Telas aprovadas e mantidas:

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

## telas removidas do escopo

Foram removidas do escopo visual atual:

- Fila de Impressao;
- Arquivos Recentes;
- Materiais;
- Detalhe do Material.

Essas areas nao devem ser reintroduzidas sem nova decisao explicita do usuario.

## componentes compartilhados criados

Componentes compartilhados atuais:

- `AppCard`;
- `AppBadge`;
- `AppButton`;
- `AppIcon`;
- `AppStateBlock`.

O `AppStateBlock` foi criado a partir da referencia 19 para representar estados visuais reutilizaveis, como vazio, erro, offline, sem resultados, caminho indisponivel, loading e sincronizacao pendente.

## rotas existentes

Rotas existentes no app:

```txt
/
/colecoes
/colecoes/eldritch-horrors
/modelos
/colecoes/eldritch-horrors/modelos/cthulhu-idol
/colecoes/eldritch-horrors/modelos/cthulhu-idol/galeria
/colecoes/eldritch-horrors/modelos/cthulhu-idol/galeria/main-reference
/colecoes/eldritch-horrors/modelos/cthulhu-idol/arquivos
/favoritos
/busca
/configuracoes
/configuracoes/caminhos
/configuracoes/aparencia
/configuracoes/modelo-pastas
/configuracoes/backup
/not-found
```

## rotas removidas ou inexistentes

Rotas que nao existem no escopo atual:

```txt
/fila-impressao
/arquivos-recentes
/materiais
/materiais/resin-grey
/estados-vazios-erros-offline
```

## padroes visuais consolidados

Padroes consolidados:

- sidebar simplificada e persistente;
- topbar contextual preservada;
- paleta clean, moderna, azulada e menos colorida;
- azul como destaque principal;
- verdes, amarelos e vermelhos restritos a estados reais;
- cards clicaveis com hover consistente;
- tipografia de sistema moderna;
- capas, previews e imagens mockadas com proporcao controlada;
- grids responsivos com `min-width: 0` e quebras seguras;
- acoes visuais por icones quando apropriado;
- comportamento aprovado do menu de contexto em Favoritos;
- dados mockados como camada visual, sem persistencia.

## padrao de Configuracoes

O modulo de Configuracoes foi consolidado com:

- header comum;
- navegacao secundaria consistente;
- conteudo principal alinhado;
- item ativo por rota;
- layout responsivo entre telas;
- preservacao da sidebar principal apontando para `/configuracoes`.

Rotas do modulo:

```txt
/configuracoes
/configuracoes/caminhos
/configuracoes/aparencia
/configuracoes/modelo-pastas
/configuracoes/backup
```

A navegacao secundaria usa:

- `Geral -> /configuracoes`;
- `Caminhos -> /configuracoes/caminhos`;
- `Aparencia -> /configuracoes/aparencia`;
- `Backup -> /configuracoes/backup`;
- `Modelo de Pastas -> /configuracoes/modelo-pastas`;
- `Dados do App -> visual/mockado futuro`.

## padrao de estados do sistema

A referencia 19 nao virou pagina.

Ela foi consolidada como padrao reutilizavel por meio de:

- `src/blueatelier.app/Components/Shared/AppStateBlock.razor`;
- estilos `app-state-*` em `src/blueatelier.app/wwwroot/css/app.css`;
- icones genericos em `AppIcon`.

Esse padrao deve ser aplicado futuramente dentro das telas reais quando houver:

- lista vazia;
- busca sem resultados;
- caminho indisponivel;
- erro de arquivo ou operacao;
- rede offline;
- loading;
- sincronizacao pendente.

## correcoes comportamentais aprovadas

A fase visual tambem consolidou correcoes comportamentais pontuais, sem redesenho e sem funcionalidade real.

Na tela `/favoritos`, o menu de contexto da barra de links favoritos foi ajustado para:

- fechar automaticamente ao clicar fora dele;
- permanecer aberto ao clicar dentro do menu;
- trocar para outro favorito quando o usuario usa o botao direito em outro item;
- fechar ao selecionar uma opcao;
- preservar o visual aprovado da tela Favoritos, da barra de links e do menu.

Essa correcao foi feita como comportamento de interface aprovado. Ela nao implementa persistencia, edicao real, criacao real de links, exclusao real ou integracao real com navegador/sistema operacional.

## limitacoes atuais

O app ainda esta em fase visual/mockada.

Limitacoes atuais:

- dados nao persistem;
- nao ha banco local;
- nao ha EF Core;
- nao ha migrations;
- nao ha servicos reais;
- nao ha leitura real de arquivos;
- nao ha manipulacao real do sistema de arquivos;
- nao ha busca real;
- nao ha favoritos reais;
- nao ha configuracoes reais;
- nao ha backup real;
- nao ha edicao real de colecoes ou modelos.

## o que ainda e mockado

Ainda sao mockados:

- colecoes;
- modelos;
- dados de Model Info;
- materiais usados no modelo;
- galeria;
- visualizacao de imagem;
- arquivos vinculados;
- favoritos;
- links favoritos;
- busca;
- configuracoes;
- caminhos;
- aparencia;
- modelo de pastas;
- backup/dados;
- estados do sistema.

## o que nao foi implementado

Nao foi implementado:

- SQLite;
- EF Core;
- DbContext;
- migrations;
- repositorios reais;
- servicos reais;
- persistencia local;
- criacao real de colecoes;
- edicao real de modelos;
- vinculo real de arquivos;
- leitura real de imagens;
- favoritos persistidos;
- busca indexada;
- configuracoes persistidas;
- backup/exportacao/importacao/restauracao reais.

## validacoes tecnicas realizadas ate aqui

Durante a fase visual, foram executados repetidamente:

```txt
dotnet restore BlueAtelier.sln
dotnet build BlueAtelier.sln
dotnet test BlueAtelier.sln --no-build
```

A cada consolidacao aprovada, o build e os testes foram mantidos verdes antes de commit e push.

Nesta auditoria final, esses comandos devem ser executados novamente para confirmar que a documentacao criada nao alterou o estado tecnico do app.

## riscos de alterar visual sem permissao

Alterar visual sem autorizacao pode:

- quebrar telas ja aprovadas manualmente;
- desalinha-las das referencias Stitch validadas;
- reintroduzir areas removidas;
- comprometer responsividade ja ajustada;
- misturar fase visual e fase funcional;
- gerar retrabalho em paleta, layout e navegacao;
- dificultar a implementacao funcional progressiva.

## regra de preservacao visual

Para a proxima fase:

- nao redesenhar telas aprovadas;
- nao alterar CSS visual sem autorizacao explicita;
- nao alterar layout aprovado;
- nao mexer em sidebar/topbar sem necessidade tecnica clara;
- nao reintroduzir Fila de Impressao, Arquivos Recentes, Materiais ou Detalhe do Material;
- implementar funcionalidade por baixo do visual existente;
- validar build/test a cada bloco;
- atualizar documentacao a cada consolidacao.

## proxima fase sugerida

Iniciar a fase funcional do Blue Atelier pela arquitetura funcional minima e pela base de persistencia local, somente apos aprovacao do usuario.
