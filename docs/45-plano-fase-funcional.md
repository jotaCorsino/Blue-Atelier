# plano da fase funcional

## objetivo

Planejar a proxima fase do Blue Atelier, levando o app gradualmente de telas mockadas para funcionalidade real com persistencia local.

Este documento e um plano. Nao implementa banco, servicos, migrations, telas novas ou funcionalidades reais.

## direcao geral

A fase funcional deve priorizar:

- base de dados local;
- arquitetura simples e testavel;
- preservacao total do visual aprovado;
- implementacao por blocos pequenos;
- validacao tecnica a cada passo;
- evolucao gradual do mock para dados reais.

## regra principal

A fase funcional deve implementar comportamento por baixo das telas aprovadas, sem redesenhar a interface.

Qualquer mudanca visual deve ser tratada como excecao e exigir aprovacao explicita do usuario.

## Bloco 1 - Arquitetura funcional minima

Objetivo: preparar a base funcional sem alterar telas.

Planejar:

- entidades principais do dominio;
- contratos/interfaces de repositorios;
- contratos de servicos de aplicacao;
- separacao clara entre UI, aplicacao, dominio, infraestrutura e persistencia;
- DTOs ou modelos de view quando forem uteis;
- fluxo de dados simples para telas existentes;
- estrategia para substituir dados mockados gradualmente;
- uso futuro de SQLite e EF Core sem acoplar UI diretamente ao banco.

Entidades candidatas:

- Colecao;
- Modelo;
- ImagemDoModelo;
- ArquivoVinculado;
- Favorito;
- LinkFavorito;
- PastaFavoritos;
- ConfiguracaoApp;
- CaminhoConfigurado;
- ModeloPastas;
- RegistroBackup.

Regras do bloco:

- nao instalar pacotes ainda se nao for necessario;
- nao criar banco ainda;
- nao alterar visual;
- criar testes unitarios para regras simples, quando houver regra;
- manter nomes e vocabulario em portugues no dominio do projeto.

## Bloco 2 - Banco local

Objetivo: criar a persistencia local inicial.

Planejar:

- SQLite como banco local;
- EF Core como ORM;
- `DbContext` em camada de persistencia;
- migrations controladas;
- seed inicial minimo;
- caminho local do banco;
- estrategia de backup futuro;
- configuracao de desenvolvimento e producao local;
- testes basicos de persistencia quando viavel.

Entregas futuras esperadas:

- pacote EF Core SQLite instalado;
- `BlueAtelierDbContext`;
- entidades mapeadas;
- primeira migration;
- seed inicial coerente com dados mockados atuais;
- comando de validacao documentado.

Cuidados:

- nao migrar todas as telas de uma vez;
- nao acoplar Razor Components ao DbContext;
- nao implementar backup real neste bloco;
- nao iniciar sistema de arquivos real junto com banco.

## Bloco 3 - Colecoes

Objetivo: tornar Colecoes funcionais preservando o visual atual.

Planejar funcionalidade real para:

- listar colecoes;
- criar colecao;
- editar colecao;
- excluir colecao;
- abrir detalhe da colecao;
- manter slug ou identificador estavel;
- preservar navegacao atual;
- preservar cards e layout aprovados.

Primeiro recorte recomendado:

- listar colecoes do banco;
- manter seed inicial com `Eldritch Horrors`;
- criar fluxo simples de criacao sem redesign.

Cuidados:

- exclusao deve ser confirmada antes de apagar;
- nao apagar arquivos reais;
- manter AppStateBlock disponivel para colecoes vazias.

## Bloco 4 - Modelos

Objetivo: tornar Modelos e Detalhe do Modelo funcionais.

Planejar funcionalidade real para:

- listar modelos;
- criar modelo;
- editar modelo;
- excluir modelo;
- associar modelo a colecao;
- persistir dados do `Model Info`;
- preservar materiais usados como lista simples de texto por enquanto;
- preservar visual aprovado.

Dados iniciais de modelo:

- nome;
- slug;
- colecao;
- etapa atual;
- progresso;
- tipo de arquivo;
- escala;
- tempo estimado;
- material sugerido;
- observacoes curtas.

Cuidados:

- nao recriar area Materiais;
- nao criar estoque;
- nao navegar para `/materiais`;
- nao mudar cards aprovados.

## Bloco 5 - Arquivos vinculados

Objetivo: registrar metadados de arquivos vinculados sem manipular arquivos reais de forma arriscada.

Planejar funcionalidade real para:

- registrar arquivos locais como metadados;
- vincular arquivos a modelos;
- classificar STL, imagens e documentos;
- armazenar caminho informado;
- mostrar caminho/status visual;
- abrir caminho local futuramente;
- usar AppStateBlock para caminho indisponivel.

Primeiro recorte recomendado:

- persistir registros de arquivos vinculados;
- nao copiar arquivos;
- nao mover arquivos;
- nao apagar arquivos;
- nao fazer leitura pesada do sistema de arquivos.

Cuidados:

- caminho offline deve ser condicao normal;
- remover vinculo no app nao deve apagar arquivo real;
- leitura real de arquivos deve vir em etapa posterior e isolada.

## Bloco 6 - Galeria

Objetivo: associar imagens ao modelo com persistencia basica.

Planejar funcionalidade real para:

- associar imagens ao modelo;
- listar imagens;
- definir imagem principal;
- abrir visualizacao de imagem;
- persistir metadados basicos;
- preservar galeria e viewer aprovados.

Dados iniciais:

- modelo;
- titulo;
- caminho local;
- tipo;
- ordem;
- flag de imagem principal;
- observacao curta.

Cuidados:

- nao processar imagens pesadas no primeiro recorte;
- nao alterar layout da galeria;
- usar AppStateBlock para galeria vazia futuramente.

## Bloco 7 - Busca

Objetivo: substituir busca mockada por busca real simples.

Planejar busca real para:

- colecoes;
- modelos;
- arquivos vinculados;
- favoritos;
- notas futuras.

Primeiro recorte recomendado:

- busca em banco por nome/titulo;
- resultados agrupados por tipo;
- navegacao para telas existentes;
- sem indexador externo;
- sem leitura de arquivos reais.

Cuidados:

- manter tela atual;
- usar AppStateBlock para sem resultados;
- evoluir ranking/relevancia depois.

## Bloco 8 - Favoritos

Objetivo: tornar favoritos persistidos localmente.

Planejar funcionalidade real para:

- favoritos de colecoes, modelos, imagens e arquivos;
- links favoritos;
- pastas de favoritos;
- criar link;
- editar link;
- excluir link;
- renomear pasta;
- persistir ordem futuramente;
- alterar favicon futuramente.
- manter o comportamento aprovado do menu de contexto.

Primeiro recorte recomendado:

- salvar links favoritos;
- listar links persistidos;
- criar/editar/excluir via menu existente;
- manter favicons mockados ou iniciais.

Cuidados:

- nao implementar drag and drop real no primeiro recorte;
- nao baixar favicon automaticamente ainda;
- nao abrir navegador via API nativa ate haver decisao especifica.
- preservar o fechamento do menu ao clicar fora e o comportamento de clique interno ja aprovado.

## Bloco 9 - Configuracoes

Objetivo: tornar configuracoes persistidas por etapas.

Planejar funcionalidade real para:

- caminhos locais;
- caminhos de rede;
- aparencia;
- modelo de pastas;
- backup/dados;
- dados do app futuramente.

Ordem sugerida:

1. Persistir caminhos como texto.
2. Persistir preferencias simples de aparencia, sem aplicar tema real inicialmente.
3. Persistir modelo de pastas.
4. Planejar backup real depois da estrutura de banco estabilizada.
5. Criar Dados do App apenas quando houver necessidade real.

Cuidados:

- nao aplicar tudo de uma vez;
- nao testar caminho real no primeiro recorte;
- nao criar backup real antes do banco estar estavel;
- preservar navegacao secundaria aprovada.

## Bloco 10 - Estados do sistema

Objetivo: aplicar `AppStateBlock` em cenarios reais quando os dados deixarem de ser mockados.

Planejar uso real para:

- colecoes vazias;
- modelos vazios;
- busca sem resultados;
- erro de caminho;
- caminho de rede offline;
- carregamento;
- sincronizacao pendente futura;
- erro de arquivo vinculado.

Cuidados:

- aplicar aos poucos;
- nao criar pagina de demonstracao;
- nao usar estados para esconder erro tecnico;
- manter mensagens claras, curtas e acionaveis.

## regras obrigatorias da fase funcional

- nao redesenhar telas aprovadas;
- nao alterar CSS visual sem autorizacao explicita;
- nao alterar layout das paginas aprovadas;
- implementar por blocos pequenos;
- validar build/test a cada bloco;
- manter documentacao atualizada;
- priorizar arquitetura limpa;
- manter nomes e vocabulario em portugues no dominio do projeto;
- evitar overengineering;
- preferir implementacao simples e testavel;
- nao reintroduzir Fila de Impressao, Arquivos Recentes, Materiais ou Detalhe do Material;
- nao implementar recursos fora do escopo;
- nao misturar muitas areas no mesmo commit;
- separar mudancas visuais de mudancas funcionais.

## primeira etapa pratica sugerida

Iniciar o Bloco 1, somente apos aprovacao do usuario.

Primeira tarefa recomendada:

- revisar entidades planejadas;
- propor modelos de dominio minimos;
- definir contratos de repositorio e servico;
- nao instalar pacotes ainda;
- nao criar banco ainda;
- nao alterar telas.

## validacao esperada por bloco

Cada bloco deve executar:

```txt
dotnet restore BlueAtelier.sln
dotnet build BlueAtelier.sln
dotnet test BlueAtelier.sln --no-build
```

Quando houver mudanca funcional real, adicionar ou atualizar testes apropriados.
