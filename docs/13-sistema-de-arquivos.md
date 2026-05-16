# blue atelier - sistema de arquivos

## 1. objetivo do sistema de arquivos

O sistema de arquivos do **Blue Atelier** define como o app deve lidar com arquivos e pastas reais do Windows.

O app deve funcionar como uma camada visual e operacional sobre arquivos já existentes ou criados pelo usuário em pastas locais, unidades mapeadas e caminhos de rede.

Objetivos principais:

- organizar coleções e modelos em pastas reais;
- vincular arquivos a coleções e modelos;
- abrir arquivos e pastas pelo Windows;
- copiar caminhos para uso externo;
- importar ou vincular arquivos existentes;
- identificar arquivos e pastas ausentes;
- lidar com caminhos de rede offline sem travar;
- apoiar a fila de impressão;
- manter arquivos pesados fora do banco SQLite.

Este documento não cria código, projeto .NET, serviços, migrations ou pastas reais. Ele define regras para implementação futura.

## 2. princípios gerais

- O Blue Atelier não substitui o sistema de arquivos do Windows.
- O app organiza e facilita o acesso a arquivos reais.
- O banco SQLite guarda apenas metadados, caminhos, relações, status e histórico.
- Arquivos pesados permanecem fora do banco.
- Nenhum arquivo real deve ser apagado sem autorização explícita do usuário.
- Remover um vínculo dentro do app não deve excluir o arquivo real.
- Caminho de rede offline deve ser tratado como condição normal.
- Arquivo ausente deve continuar registrado para que o usuário possa localizar ou corrigir depois.
- Operações perigosas devem exigir confirmação futura.
- O app deve preferir segurança e previsibilidade a automações agressivas.

## 3. relação entre banco SQLite e arquivos reais

O SQLite deve guardar o mapa organizado do atelier, não os arquivos em si.

O banco pode guardar:

- caminho completo do arquivo ou pasta;
- caminho normalizado;
- nome do arquivo;
- extensão;
- tipo;
- categoria;
- tamanho;
- datas conhecidas do arquivo;
- data da última validação;
- status de existência;
- relação com coleção, modelo, galeria ou fila;
- observações e tags.

O banco não deve guardar:

- imagens originais;
- arquivos 3D;
- projetos de slicer;
- arquivos prontos de impressão;
- fotos finais;
- vídeos;
- documentos pesados;
- conteúdo binário dos arquivos.

Se o arquivo for movido fora do app, o registro deve permanecer no banco como ausente até que o usuário localize novamente, edite o caminho ou remova apenas o vínculo.

## 4. pasta principal do atelier

A pasta principal do atelier é o diretório base configurado pelo usuário para organizar o trabalho.

Exemplos aceitos:

```txt
D:\atelier-3d\
Z:\atelier-3d\
\\atelier-notebook\fila-impressao\
\\desktop-atelier\arquivos-3d\
\\192.168.18.50\atelier-3d\
```

Regras:

- deve ser configurável em `PathSetting`;
- pode ser local, unidade mapeada ou caminho UNC;
- deve ser testada antes de criar pastas;
- deve mostrar último status conhecido;
- não deve impedir o uso do app se estiver temporariamente offline;
- não deve ser criada automaticamente sem confirmação futura.

Pastas derivadas, como coleções, backups, importação e exportação, podem partir dessa pasta principal ou ter caminhos próprios nas configurações.

## 5. estrutura padrão de pastas para coleções

Cada coleção pode ter uma pasta principal própria.

Estrutura sugerida:

```txt
colecao/
├── capa/
├── referencias/
├── documentos/
├── modelos/
└── notas/
```

Finalidade das pastas:

- `capa`: imagens usadas como capa da coleção;
- `referencias`: imagens, PDFs ou textos de referência geral;
- `documentos`: documentos de apoio da coleção;
- `modelos`: subpastas dos modelos pertencentes à coleção;
- `notas`: arquivos `.txt` ou `.md` com observações.

Regras:

- a estrutura deve ser criada apenas quando o usuário autorizar;
- o modelo de pastas deve ser configurável futuramente;
- pastas existentes não devem ser apagadas ou recriadas sem necessidade;
- conflitos de nome devem ser resolvidos com sufixo ou confirmação.

## 6. estrutura padrão de pastas para modelos

Cada modelo pode ter uma pasta principal dentro da coleção ou em caminho escolhido pelo usuário.

Estrutura sugerida:

```txt
modelo/
├── capa/
├── referencias/
├── arquivos-3d/
│   ├── stl/
│   ├── obj/
│   ├── 3mf/
│   ├── blend/
│   └── outros/
├── fatiamento/
│   ├── projetos-slicer/
│   └── arquivos-prontos/
├── impressao/
│   ├── enviados/
│   ├── impressos/
│   └── falhas/
├── pintura/
│   ├── referencias/
│   ├── paleta/
│   └── processo/
├── fotos-finais/
└── notas/
```

Finalidade das pastas:

- `capa`: imagem principal do modelo;
- `referencias`: referências visuais e técnicas;
- `arquivos-3d`: arquivos originais ou editáveis;
- `fatiamento`: projetos de slicer e arquivos prontos;
- `impressao`: arquivos enviados, concluídos ou relacionados a falhas;
- `pintura`: referências, paleta e fotos do processo;
- `fotos-finais`: fotos finais do modelo pronto;
- `notas`: textos e anotações.

## 7. regras de nomes de pastas

Nomes de pastas devem ser simples, previsíveis e compatíveis com Windows.

Regras:

- usar letras minúsculas sempre que possível;
- evitar acentos em nomes gerados automaticamente;
- usar hífen no lugar de espaço;
- evitar caracteres reservados do Windows;
- evitar nomes muito longos;
- evitar pontuação desnecessária;
- preservar nomes existentes escolhidos manualmente pelo usuário;
- não renomear pastas reais automaticamente sem confirmação.

Caracteres proibidos em nomes gerados:

```txt
< > : " / \ | ? *
```

Exemplos:

```txt
dioramas-de-kanto
bulbasaur-diorama-floresta
bustos-dark-fantasy
arquivos-prontos
fotos-finais
```

## 8. regras de slugs

Slugs são nomes técnicos amigáveis usados para sugerir pastas, identificar itens e manter consistência.

Regras:

- gerar slug a partir do título;
- converter para minúsculas;
- remover acentos;
- trocar espaços por hífen;
- remover caracteres especiais;
- evitar hífens duplicados;
- remover hífens no começo e no fim;
- garantir unicidade no contexto correto;
- usar sufixos como `-2`, `-3` em caso de duplicidade.

Exemplo:

```txt
Título: Bulbasaur - Diorama de Floresta
Slug: bulbasaur-diorama-de-floresta
```

Observação importante:

O slug não deve ser tratado como verdade absoluta do caminho real. O caminho real deve ficar salvo em campo próprio quando existir pasta vinculada.

## 9. extensões aceitas

Extensões aceitas inicialmente:

```txt
.stl
.obj
.3mf
.blend
.ctb
.lychee
.chitubox
.png
.jpg
.jpeg
.webp
.pdf
.txt
.md
```

Regras:

- a comparação de extensão deve ignorar maiúsculas e minúsculas;
- arquivos com extensão desconhecida podem ser vinculados como `outros`, se aprovado;
- o app não deve alterar a extensão do arquivo;
- o tipo de arquivo deve ser inferido pela extensão e permitir ajuste manual futuro;
- extensões aceitas podem evoluir por configuração ou tarefa futura.

## 10. categorias de arquivos

Categorias principais:

- imagem de capa;
- referência visual;
- arquivo 3D;
- projeto de modelagem;
- projeto de slicer;
- arquivo pronto para impressão;
- foto de processo;
- foto final;
- documento;
- nota;
- pasta;
- outro.

Relação com extensões:

- `.stl`, `.obj`, `.3mf`: arquivos 3D;
- `.blend`: projeto de modelagem;
- `.ctb`: arquivo pronto para impressão;
- `.lychee`, `.chitubox`: projeto de slicer;
- `.png`, `.jpg`, `.jpeg`, `.webp`: imagens;
- `.pdf`: documento;
- `.txt`, `.md`: notas ou documentos leves.

## 11. caminhos locais

Caminhos locais são pastas e arquivos acessados diretamente no Windows.

Exemplos:

```txt
D:\atelier-3d\
D:\atelier-3d\colecoes\
D:\atelier-3d\backups\
D:\atelier-3d\importacao\
```

Regras:

- devem ser armazenados como texto no banco;
- devem ser testados por serviço interno;
- podem ser abertos no Explorador de Arquivos;
- devem ter status conhecido, como online, ausente, inválido ou sem permissão;
- não devem ser criados fora dos caminhos configurados sem confirmação.

## 12. caminhos de rede

Caminhos de rede são pastas acessadas pela rede local, usadas para fila de impressão, arquivos compartilhados ou backup.

Exemplos:

```txt
\\atelier-notebook\fila-impressao\
\\desktop-atelier\arquivos-3d\
\\192.168.18.50\atelier-3d\
```

Regras:

- devem ser configuráveis em `PathSetting`;
- devem ter tipo, nome amigável, caminho, status, último teste e observação;
- podem ficar offline sem bloquear o app;
- devem ser testados antes de copiar arquivos;
- devem mostrar erro claro quando inacessíveis;
- não devem travar tela inicial, arquivos, galeria ou fila.

## 13. unidades mapeadas

Unidades mapeadas são letras de drive que apontam para locais de rede.

Exemplo:

```txt
Z:\atelier-3d\
```

Regras:

- devem ser aceitas como caminhos válidos;
- devem ser tratadas como caminho local com possibilidade de origem em rede;
- podem estar desconectadas;
- devem ter status offline ou inacessível quando a unidade não responder;
- não devem ser convertidas automaticamente para UNC sem regra futura aprovada.

Observação:

Uma unidade mapeada pode existir para um usuário do Windows e não existir para outro contexto de execução. Como o app é pessoal, isso é aceitável, mas deve ser registrado como cuidado técnico futuro.

## 14. caminhos UNC

Caminhos UNC apontam diretamente para computador ou endereço de rede.

Exemplos:

```txt
\\atelier-notebook\fila-impressao\
\\desktop-atelier\arquivos-3d\
\\192.168.18.50\atelier-3d\
```

Regras:

- devem ser aceitos nas configurações;
- devem preservar barras invertidas;
- devem ser validados sem bloquear a interface;
- podem retornar offline, sem permissão, inválido ou ausente;
- devem ser preferidos quando o usuário quiser evitar dependência de letra mapeada.

## 15. validação de existência de arquivo

A validação de arquivo deve verificar se o caminho salvo ainda aponta para um arquivo existente.

Informações a registrar:

- existe ou não existe;
- último teste;
- tamanho atual, se existir;
- data de modificação atual, se existir;
- mensagem de erro, se houver;
- status conhecido.

Regras:

- validação deve ser feita sob demanda ou em momentos controlados;
- a interface não deve travar esperando rede lenta;
- arquivo ausente não deve ser removido automaticamente;
- arquivo em caminho offline deve ser tratado de forma diferente de arquivo realmente inexistente, quando possível.

## 16. validação de existência de pasta

A validação de pasta deve verificar se uma pasta configurada ou vinculada está acessível.

Casos possíveis:

- pasta existe;
- pasta não existe;
- caminho inválido;
- caminho offline;
- acesso negado;
- erro desconhecido.

Regras:

- o app deve guardar o último status conhecido;
- caminhos de rede devem ter tolerância a falhas;
- validações longas devem ter feedback visual futuro;
- pasta ausente não deve remover vínculo automaticamente.

## 17. comportamento para arquivo ausente

Arquivo ausente é um arquivo registrado no app, mas não encontrado no caminho salvo.

Comportamento esperado:

- manter o registro no banco;
- mostrar status de arquivo ausente;
- preservar nome, caminho e metadados conhecidos;
- desabilitar ações que dependem do arquivo existir;
- permitir copiar o caminho antigo;
- permitir abrir a pasta pai, se existir;
- permitir localizar novamente em tarefa futura;
- permitir remover apenas o vínculo;
- nunca apagar o registro automaticamente.

Arquivos ausentes podem acontecer por movimentação manual, troca de unidade, rede offline, renomeação ou exclusão fora do app.

## 18. comportamento para pasta ausente

Pasta ausente é uma pasta registrada no app, mas não encontrada ou inacessível.

Comportamento esperado:

- manter o caminho registrado;
- mostrar estado de pasta ausente ou inacessível;
- oferecer testar novamente;
- permitir copiar caminho;
- permitir editar caminho;
- permitir criar pasta somente com confirmação futura;
- não tentar recriar estrutura automaticamente sem autorização.

Quando a pasta for de rede, o app deve preferir estado offline ou inacessível antes de tratar como perda definitiva.

## 19. comportamento para caminho de rede offline

Caminho de rede offline deve ser uma condição normal no Blue Atelier.

Comportamento esperado:

- não travar o app;
- não bloquear consulta ao banco local;
- não remover arquivos vinculados;
- não limpar fila de impressão;
- mostrar aviso discreto;
- guardar último teste;
- permitir testar novamente;
- permitir abrir configurações do caminho;
- impedir cópia para o destino até ele estar acessível.

Exemplo de mensagem futura:

```txt
Destino de rede offline. O arquivo continua na fila e pode ser enviado quando o caminho voltar.
```

## 20. abertura de arquivo

Abrir arquivo significa solicitar ao Windows que abra o arquivo no programa padrão ou programa configurado.

Regras:

- validar existência antes de abrir;
- registrar arquivo recente quando a abertura for solicitada;
- informar erro se o arquivo estiver ausente;
- informar erro se o Windows não conseguir abrir;
- não alterar o arquivo ao abrir;
- não tentar escolher programa automaticamente fora das configurações aprovadas.

Exemplos:

- `.stl` pode abrir no visualizador ou slicer padrão;
- `.blend` pode abrir no Blender;
- `.png` pode abrir no visualizador de imagens;
- `.md` pode abrir no editor padrão.

## 21. abertura de pasta

Abrir pasta significa abrir o local no Explorador de Arquivos.

Regras:

- validar existência da pasta antes de abrir;
- para arquivo, abrir a pasta que contém o arquivo;
- para pasta vinculada, abrir a própria pasta;
- se a pasta estiver ausente, mostrar mensagem e manter vínculo;
- se o caminho de rede estiver offline, mostrar aviso sem travar;
- registrar ação em arquivos recentes quando fizer sentido.

## 22. cópia de caminho

Copiar caminho é uma operação segura e não altera arquivos.

Regras:

- permitir copiar caminho completo;
- permitir copiar caminho da pasta pai;
- preservar barras do Windows;
- manter caminho antigo mesmo se arquivo estiver ausente;
- usar caminho salvo no banco;
- não validar obrigatoriamente antes de copiar, pois o usuário pode precisar do caminho mesmo ausente.

Exemplos:

```txt
D:\atelier-3d\colecoes\dioramas-de-kanto\modelos\bulbasaur\arquivos-3d\stl\bulbasaur.stl
\\atelier-notebook\fila-impressao\bulbasaur.ctb
```

## 23. cópia de arquivo

Copiar arquivo cria uma cópia do arquivo em outro destino.

Regras:

- validar existência do arquivo de origem;
- validar existência da pasta de destino;
- testar destino de rede antes da cópia;
- nunca sobrescrever sem confirmação futura;
- registrar erro se origem estiver ausente;
- registrar erro se destino estiver offline;
- preservar o arquivo original;
- registrar histórico ou arquivo recente quando aplicável.

Usos comuns:

- copiar arquivo pronto para pasta de impressão;
- copiar imagem para pasta de galeria;
- copiar referência para pasta do modelo;
- copiar backup do banco.

## 24. movimentação de arquivo

Mover arquivo altera a localização real do arquivo.

Por ser operação mais arriscada, deve ser tratada com cautela.

Regras:

- exigir confirmação futura;
- validar origem e destino;
- tratar conflito de nome antes de mover;
- atualizar caminho no banco apenas após sucesso;
- manter registro do caminho antigo em histórico, se fizer sentido;
- não mover automaticamente arquivos em massa sem tarefa específica;
- não mover arquivos em caminho de rede instável sem validação.

Preferência inicial:

Copiar é mais seguro que mover. A movimentação deve ser implementada apenas quando houver UX clara e confirmação.

## 25. envio de arquivo para fila de impressão

Enviar para fila de impressão significa criar ou atualizar um `PrintQueueItem` apontando para um arquivo pronto ou modelo.

Regras:

- o arquivo deve existir ou o app deve registrar item com alerta de origem ausente;
- extensões típicas: `.ctb`, `.stl`, `.3mf`, `.lychee`, `.chitubox`;
- o item deve guardar caminho de origem;
- o destino pode ser local ou de rede;
- a cópia para destino deve ocorrer apenas por ação explícita;
- destino offline não deve remover o item da fila;
- conflito de nome no destino deve exigir decisão futura.

A fila não controla a impressora. Ela organiza arquivos, status, destinos e tentativas.

## 26. tratamento de conflito de nome

Conflito de nome ocorre quando a pasta ou arquivo de destino já contém item com o mesmo nome.

Estratégias possíveis:

- gerar sufixo automático;
- pedir confirmação para sobrescrever;
- cancelar operação;
- permitir escolher novo nome.

Sufixo sugerido:

```txt
bulbasaur.ctb
bulbasaur-2.ctb
bulbasaur-3.ctb
```

Regras:

- nunca sobrescrever silenciosamente;
- preservar extensão original;
- evitar nomes confusos;
- registrar o nome final usado.

## 27. regras para sobrescrita

Sobrescrita é operação perigosa.

Regras:

- nunca sobrescrever arquivo real sem confirmação explícita;
- mostrar origem, destino, tamanho e data de modificação antes de confirmar;
- permitir cancelar;
- registrar operação quando houver histórico futuro;
- não usar sobrescrita automática em fila de impressão;
- preferir cópia com sufixo quando o usuário não tiver certeza.

Sobrescrita de banco, backup ou arquivos de configuração deve ser tratada com cuidado ainda maior.

## 28. regras para remoção de vínculo

Remover vínculo significa remover a referência do app para um arquivo, pasta ou imagem.

Regras:

- não excluir o arquivo real;
- informar claramente que apenas o vínculo será removido;
- remover relação com coleção, modelo, galeria ou fila conforme o caso;
- preservar histórico quando fizer sentido;
- não remover arquivo de favoritos ou recentes sem regra específica;
- pedir confirmação futura quando o vínculo estiver em uso por capa, fila ou galeria.

Exemplo de mensagem futura:

```txt
Remover vínculo não apaga o arquivo do Windows.
```

## 29. regras para exclusão de arquivo real

Excluir arquivo real é diferente de remover vínculo.

Regras:

- deve exigir autorização explícita;
- deve explicar que o arquivo será apagado do Windows;
- deve mostrar caminho completo;
- deve indicar se o arquivo está relacionado a coleção, modelo, galeria ou fila;
- deve evitar exclusão em massa sem tarefa própria;
- deve considerar lixeira do Windows ou mecanismo seguro futuro;
- deve registrar histórico quando implementado.

Na fase inicial, a recomendação é não implementar exclusão real. O app deve priorizar remoção de vínculo e abertura da pasta para o usuário decidir no Windows.

## 30. importação de arquivos

Importar arquivo significa trazer uma cópia para a estrutura organizada do atelier.

Fluxo esperado:

1. Usuário escolhe arquivo existente.
2. App identifica tipo e extensão.
3. Usuário escolhe coleção ou modelo de destino.
4. App sugere pasta correta.
5. App valida conflito de nome.
6. App copia o arquivo.
7. App cria vínculo no banco.
8. App registra arquivo recente.

Regras:

- importação deve copiar, não mover, por padrão;
- origem deve permanecer preservada;
- arquivos pesados continuam fora do banco;
- conflito de nome deve ser tratado antes da cópia;
- erro de destino deve cancelar sem criar registro incorreto.

## 31. vinculação de arquivos existentes

Vincular arquivo existente significa registrar no app um caminho que já existe, sem copiar o arquivo.

Regras:

- validar se o arquivo existe no momento da vinculação;
- permitir vincular mesmo em caminho de rede, se acessível;
- salvar caminho, nome, extensão, tamanho e datas conhecidas;
- relacionar com coleção, modelo, galeria ou fila;
- não mover nem copiar o arquivo;
- se o arquivo ficar ausente depois, manter registro.

Uso recomendado:

- arquivos já organizados manualmente;
- pastas compartilhadas em rede;
- projetos de slicer existentes;
- imagens já separadas pelo usuário.

## 32. arquivos recentes

Arquivos recentes ajudam o usuário a retomar trabalho.

Devem ser registrados quando o usuário:

- abre arquivo pelo app;
- abre pasta de arquivo;
- vincula arquivo;
- importa arquivo;
- envia arquivo para fila;
- copia arquivo para destino;
- atualiza metadados relevantes.

Dados sugeridos:

- caminho;
- nome;
- extensão;
- tipo;
- relação com coleção ou modelo;
- origem da ação;
- data de acesso;
- último status conhecido.

Regras:

- arquivo recente pode continuar aparecendo mesmo se o arquivo estiver ausente;
- lista pode ser podada futuramente para não crescer demais;
- arquivos recentes não devem duplicar registros desnecessariamente.

## 33. galeria e imagens

Imagens da galeria ficam no sistema de arquivos.

Extensões aceitas:

```txt
.png
.jpg
.jpeg
.webp
```

Tipos de imagem:

- capa;
- referência;
- render;
- pintura;
- processo;
- foto final;
- paleta;
- textura;
- outro.

Regras:

- imagem original não deve ser armazenada no banco;
- o banco guarda caminho e metadados;
- imagem ausente deve mostrar placeholder futuro;
- definir capa deve apenas registrar referência;
- remover imagem da galeria remove vínculo, não arquivo real;
- importar imagem deve copiar para pasta correta apenas quando o usuário escolher essa opção.

## 34. arquivos de impressão 3D

Arquivos de impressão 3D representam modelos, malhas e projetos de modelagem.

Extensões principais:

```txt
.stl
.obj
.3mf
.blend
```

Regras:

- devem ficar em `arquivos-3d/`;
- podem ser separados por extensão;
- não devem ser armazenados no banco;
- podem ser vinculados ao modelo;
- podem ser abertos no programa padrão;
- podem ser usados como origem para fatiamento;
- devem manter metadados no banco.

Pastas sugeridas:

```txt
arquivos-3d/
├── stl/
├── obj/
├── 3mf/
├── blend/
└── outros/
```

## 35. arquivos de fatiamento

Arquivos de fatiamento incluem projetos de slicer e arquivos prontos para impressão.

Extensões principais:

```txt
.ctb
.lychee
.chitubox
```

Regras:

- `.lychee` e `.chitubox` devem ficar em `fatiamento/projetos-slicer/`;
- `.ctb` deve ficar em `fatiamento/arquivos-prontos/` ou área equivalente;
- arquivos prontos podem ser enviados para fila;
- arquivos enviados podem ser copiados para destino local ou de rede;
- destino offline deve registrar falha ou aviso, sem apagar o item.

Estrutura sugerida:

```txt
fatiamento/
├── projetos-slicer/
└── arquivos-prontos/
```

## 36. fotos finais

Fotos finais documentam o modelo pronto.

Extensões aceitas:

```txt
.png
.jpg
.jpeg
.webp
```

Regras:

- devem ficar em `fotos-finais/`;
- podem aparecer na galeria como `FinalPhoto`;
- podem ser usadas como capa, se o usuário escolher;
- não devem ser armazenadas no banco;
- podem ser vinculadas ao modelo e marcadas com tags;
- arquivo ausente deve preservar metadados e relação.

Fotos finais são parte importante do arquivo visual do atelier, mas continuam sendo arquivos normais no Windows.

## 37. backup

Backup deve proteger dados leves do app e, quando aprovado, configurações.

Itens principais para backup:

- arquivo SQLite;
- configurações;
- templates de pastas;
- exportações documentais futuras.

Arquivos pesados do atelier não devem ser copiados automaticamente pelo backup inicial.

Regras:

- backup deve usar pasta configurada;
- backup em caminho de rede deve lidar com offline;
- backup antes de migrations importantes deve ser recomendado;
- restauração deve exigir confirmação;
- app não deve sobrescrever backup sem confirmação;
- caminhos salvos no banco podem apontar para arquivos que não fazem parte do backup.

Observação:

O backup do banco preserva o mapa do atelier. Ele não substitui uma estratégia separada de backup dos arquivos reais.

## 38. segurança e prevenção de perda de dados

Regras de segurança:

- não apagar arquivos reais sem autorização explícita;
- não mover arquivos sem confirmação quando houver risco;
- não sobrescrever arquivos sem confirmação;
- não remover vínculo achando que isso exclui arquivo real;
- não criar pastas fora de caminhos configurados;
- não travar o app por rede offline;
- não armazenar arquivos pesados no banco;
- não executar operações em lote perigosas sem tarefa específica;
- informar claramente origem, destino e impacto de cada operação perigosa.

Princípio principal:

O usuário deve continuar no controle dos arquivos reais.

## 39. critérios de validação futura

Quando o sistema de arquivos for implementado, validar:

- caminho local como `D:\atelier-3d\` é aceito;
- unidade mapeada como `Z:\atelier-3d\` é aceita;
- caminho UNC como `\\atelier-notebook\fila-impressao\` é aceito;
- caminho por IP como `\\192.168.18.50\atelier-3d\` é aceito;
- pasta principal pode ser configurada e testada;
- estrutura padrão de coleção pode ser criada com autorização;
- estrutura padrão de modelo pode ser criada com autorização;
- slugs são gerados corretamente;
- conflitos de slug recebem sufixo;
- extensões aceitas são reconhecidas;
- arquivos pesados não entram no SQLite;
- arquivo vinculado registra metadados e caminho;
- arquivo ausente permanece registrado;
- pasta ausente permanece registrada;
- caminho de rede offline não trava o app;
- abrir arquivo funciona quando ele existe;
- abrir pasta funciona quando ela existe;
- copiar caminho funciona mesmo para arquivo ausente;
- copiar arquivo não sobrescreve sem confirmação;
- mover arquivo exige confirmação;
- remover vínculo não exclui arquivo real;
- exclusão real exige autorização explícita;
- enviar arquivo para fila cria item sem controlar a impressora;
- destino offline da fila é tratado como falha recuperável;
- galeria usa arquivos externos;
- fotos finais permanecem no sistema de arquivos;
- backup inicial protege banco e configurações, não arquivos pesados.

## 40. resumo do sistema de arquivos

O Blue Atelier deve tratar arquivos e pastas com cuidado, clareza e respeito ao controle do usuário.

O app organiza visualmente o atelier, mas os arquivos continuam sendo arquivos reais do Windows.

O SQLite guarda o mapa: metadados, caminhos, relações, status e histórico.

Os arquivos pesados ficam fora do banco.

Caminhos locais, unidades mapeadas e caminhos UNC devem ser aceitos.

Rede offline, arquivos ausentes e pastas ausentes são condições esperadas, não motivos para travar o app.

Qualquer operação destrutiva deve exigir confirmação explícita em implementação futura.
