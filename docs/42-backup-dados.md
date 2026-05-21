# backup dados

## objetivo

Registrar a implementacao da tela Backup/Dados no Blue Atelier, consolidando uma area visual/mockada para backup, exportacao, importacao e restauracao de dados sem executar nenhuma operacao real.

## referencia visual usada

A tela foi implementada com base em:

```txt
referencias-visuais/stitch/html/18-backup-dados.html
referencias-visuais/stitch/imagens/18-backup-dados.png
referencias-visuais/stitch/design.md
```

A implementacao preserva a paleta clean/azulada aprovada do Blue Atelier e o layout padronizado do modulo de Configuracoes.

## rota implementada

```txt
/configuracoes/backup
```

As rotas abaixo continuam preservadas:

```txt
/configuracoes
/configuracoes/caminhos
/configuracoes/aparencia
/configuracoes/modelo-pastas
```

## arquivos alterados ou criados

Implementacao:

- `src/blueatelier.app/Components/Pages/ConfiguracoesBackup.razor`
- `src/blueatelier.app/Components/Pages/Configuracoes.razor`
- `src/blueatelier.app/Components/Pages/ConfiguracoesCaminhos.razor`
- `src/blueatelier.app/Components/Pages/ConfiguracoesAparencia.razor`
- `src/blueatelier.app/Components/Pages/ConfiguracoesModeloPastas.razor`
- `src/blueatelier.app/Components/Shared/AppIcon.razor`
- `src/blueatelier.app/wwwroot/css/app.css`

Documentacao:

- `docs/03-estado-atual.md`
- `docs/04-proximos-documentos.md`
- `docs/38-configuracoes-gerais.md`
- `docs/39-configuracoes-caminhos.md`
- `docs/40-configuracoes-aparencia.md`
- `docs/41-modelo-pastas.md`
- `docs/42-backup-dados.md`

## estrutura da tela

A tela Backup/Dados contem:

- cabecalho comum com titulo `Backup e Dados` e descricao curta;
- navegacao secundaria de Configuracoes;
- coluna principal com backup manual, destino e exportacao/importacao;
- coluna lateral com backup automatico, restauracao e historico mockado;
- avisos visuais sobre limites da operacao futura;
- estados visuais de backup concluido, frequencia e retencao.

## organizacao da navegacao secundaria

A navegacao secundaria do modulo de Configuracoes esta padronizada:

- `Geral` aponta para `/configuracoes`;
- `Caminhos` aponta para `/configuracoes/caminhos`;
- `Aparencia` aponta para `/configuracoes/aparencia`;
- `Backup` aponta para `/configuracoes/backup`;
- `Modelo de Pastas` aponta para `/configuracoes/modelo-pastas`;
- `Dados do App` permanece como item visual/mockado ou futuro.

Em `/configuracoes/backup`, o item ativo e `Backup`.

O item `Dados do App` nao aponta para `/configuracoes/backup`, evitando dois links diferentes para a mesma tela.

## secoes implementadas

Foram implementadas visualmente:

- `Backup Manual`;
- destino de backup mockado;
- `Exportar e Importar`;
- `Backup Automatico`;
- seletor visual de frequencia;
- seletor visual de retencao;
- `Restaurar`;
- historico visual de backups recentes.

## cards e paineis de backup

Os paineis de backup exibem:

- status mockado de ultimo backup;
- destino mockado em `D:\atelier-3d\backups\`;
- acao visual `Fazer backup agora`;
- acoes visuais `Alterar` e `Abrir` para o destino;
- toggle visual de backup automatico;
- opcoes visuais de frequencia diaria, semanal e mensal;
- lista mockada de backups disponiveis para restauracao.

## cards e paineis de dados do app

A referencia trata backup e dados dentro da mesma area. Nesta etapa, os dados do app aparecem como parte das secoes de exportacao, importacao e restauracao, sem criar rota propria para `Dados do App`.

O item `Dados do App` permanece preparado na navegacao secundaria como area futura, mas nao navega para a tela de Backup.

## acoes visuais/mockadas

As acoes exibidas sao apenas affordances visuais:

- `Fazer backup agora`;
- `Alterar`;
- `Abrir`;
- `Exportar Banco (.sqlite)`;
- `Exportar Configuracoes`;
- `Importar Dados`;
- `Restaurar`.

Nenhuma dessas acoes executa backup, exportacao, importacao, restauracao, abertura de pasta, leitura de arquivos ou gravacao real.

## status visuais/mockados

Foram usados estados visuais mockados para:

- ultimo backup concluido;
- frequencia de backup automatico;
- quantidade de backups mantidos;
- tamanhos de backups recentes;
- aviso de restauracao futura.

## fidelidade ao Stitch

A tela segue a composicao principal da referencia:

- cabecalho e descricao;
- navegacao secundaria dentro do modulo de Configuracoes;
- paineis principais de backup e dados;
- acoes visuais organizadas por card;
- historico de backups recentes;
- aviso contextual sobre restauracao.

A adaptacao feita foi inserir a referencia dentro do esqueleto padronizado do modulo de Configuracoes, preservando a navegacao secundaria e os alinhamentos ja aprovados nas telas anteriores.

## o que ainda e provisorio

- caminho de destino do backup;
- datas e tamanhos dos backups;
- status de backup concluido;
- frequencia e retencao;
- lista de backups recentes;
- todos os botoes e seletores.

## o que ainda nao foi implementado

- backup real;
- exportacao real de dados;
- importacao real de dados;
- restauracao real;
- exclusao real de dados;
- limpeza real de cache;
- leitura real de arquivos;
- gravacao real de arquivos;
- persistencia;
- banco de dados;
- EF Core;
- migrations;
- servicos reais;
- APIs nativas.

## areas removidas fora do escopo

As areas abaixo continuam fora do escopo atual e nao foram reintroduzidas:

- Fila de Impressao;
- Arquivos Recentes;
- Materiais;
- Detalhe do Material.

As rotas abaixo continuam inexistentes:

```txt
/fila-impressao
/arquivos-recentes
/materiais
/materiais/resin-grey
```

## validacoes executadas

- Confirmado que `referencias-visuais/stitch/design.md` foi respeitado.
- Confirmado que `referencias-visuais/stitch/html/18-backup-dados.html` foi usado como referencia.
- Confirmado que `referencias-visuais/stitch/imagens/18-backup-dados.png` foi usada como referencia visual.
- Confirmado que `/configuracoes` abre Configuracoes Gerais.
- Confirmado que `/configuracoes/caminhos` abre Configuracoes de Caminhos.
- Confirmado que `/configuracoes/aparencia` abre Configuracoes de Aparencia.
- Confirmado que `/configuracoes/modelo-pastas` abre Modelo de Pastas.
- Confirmado que `/configuracoes/backup` abre Backup/Dados.
- Confirmado que a sidebar principal continua apontando Configuracoes para `/configuracoes`.
- Confirmado que a navegacao secundaria marca `Backup` em `/configuracoes/backup`.
- Confirmado que `Dados do App` nao aponta para `/configuracoes/backup`.
- Confirmado que a topbar reconhece rotas iniciadas por `configuracoes`.
- Confirmado que nenhuma operacao real de backup, exportacao, importacao, restauracao ou exclusao de dados foi implementada.
- Confirmado que nenhuma persistencia real foi implementada.
- Confirmado que nenhuma area removida foi reintroduzida.
- Confirmado que nenhum HTML, imagem ou `design.md` do Stitch foi alterado.
- `dotnet restore BlueAtelier.sln` executado com sucesso.
- `dotnet build BlueAtelier.sln` executado com sucesso.
- `dotnet test BlueAtelier.sln --no-build` executado com sucesso.

## aprovacao visual manual

A tela Backup/Dados foi validada visualmente pelo usuario e esta aprovada.

## proxima etapa sugerida

Implementar Estados Vazios, Erros e Offline com base em:

```txt
referencias-visuais/stitch/html/19-estados-vazios-erros-offline.html
```
