# blue atelier - modelagem do banco SQLite

## 1. objetivo do banco SQLite

O banco SQLite do **Blue Atelier** deve persistir os dados leves que organizam o atelier.

Ele deve guardar:

- metadados;
- relações entre entidades;
- caminhos locais e de rede;
- status;
- tags;
- links;
- favoritos;
- materiais;
- configurações;
- histórico de produção;
- registros de arquivos vinculados.

O banco não deve guardar arquivos pesados. Imagens, arquivos 3D, arquivos de fatiamento, fotos finais, vídeos e documentos pesados permanecem no sistema de arquivos.

O SQLite será acessado por **Entity Framework Core**, conforme a arquitetura oficial do projeto.

Este documento não cria código, migrations reais, banco físico ou projeto .NET. Ele define a modelagem que deve orientar a implementação futura.

## 2. princípios de persistência

- O banco deve ser local, leve e confiável.
- O app é de uso pessoal, sem multiusuário, login ou permissões complexas.
- O banco deve guardar referências para arquivos, nunca os arquivos pesados.
- Caminhos devem ser armazenados como texto e validados por serviços de aplicação.
- Entidades devem ter campos de auditoria simples.
- Relações devem favorecer consultas rápidas para tela inicial, coleções, modelos, busca, favoritos e fila.
- O schema deve evoluir por migrations controladas do Entity Framework Core.
- Alterações de schema devem ser pequenas e registradas.
- Exclusões reais devem ser evitadas quando houver risco de perda de organização.
- Arquivamento deve ser preferido para coleções, modelos, links, materiais e itens da fila.

## 3. o que deve ficar no banco

O banco deve armazenar:

- títulos;
- slugs;
- descrições;
- observações;
- status;
- tags;
- categorias;
- links;
- relações entre coleção, modelo, imagens, arquivos, materiais e fila;
- caminhos de arquivos e pastas;
- metadados de arquivos;
- configurações;
- favoritos;
- checklist;
- histórico de produção;
- datas de criação, atualização, arquivamento e validação;
- resultado do último teste de caminho;
- estado conhecido de arquivo ausente ou caminho offline.

## 4. o que não deve ficar no banco

O banco não deve armazenar:

- imagens originais;
- arquivos `.stl`;
- arquivos `.obj`;
- arquivos `.3mf`;
- arquivos `.blend`;
- arquivos `.ctb`;
- projetos de slicer;
- fotos finais;
- vídeos;
- documentos pesados;
- arquivos binários do atelier;
- cache pesado de miniaturas, salvo decisão técnica futura específica.

Quando uma imagem, arquivo 3D ou documento precisar aparecer no app, o banco deve guardar apenas caminho, nome, tipo, metadados e relação com a entidade correta.

## 5. convenções de nomes

Convenções para entidades e campos:

- Entidades em `PascalCase`, como `Collection`, `ModelItem` e `GalleryImage`.
- Propriedades em `PascalCase`, seguindo C# e EF Core.
- Tabelas podem usar os nomes das entidades no singular, para manter leitura direta.
- Chaves primárias sempre chamadas `Id`.
- Chaves estrangeiras com nome da entidade + `Id`, como `CollectionId` e `ModelItemId`.
- Datas técnicas terminam com `AtUtc`.
- Campos de caminho terminam com `Path`.
- Campos de slug usam `Slug`.
- Campos opcionais devem ser nullable na implementação.
- Enums devem ser armazenados preferencialmente como texto no SQLite para facilitar backup, leitura manual e diagnóstico.

Convenções para slugs:

- letras minúsculas;
- sem acentos;
- espaços convertidos para hífen;
- sem caracteres especiais desnecessários;
- estáveis depois de criados, salvo edição explícita.

## 6. tipos de dados padrão

Tipos lógicos sugeridos:

```txt
Id: Guid armazenado como TEXT
texto curto: TEXT
texto longo: TEXT
enum: TEXT
booleano: INTEGER 0/1
inteiro: INTEGER
decimal simples: REAL
data/hora: TEXT em ISO 8601 UTC
caminho: TEXT
url: TEXT
json leve, se necessário: TEXT
```

Tamanhos lógicos recomendados:

- títulos: até 160 caracteres;
- slugs: até 180 caracteres;
- nomes de arquivo: até 260 caracteres;
- caminhos: até 1024 caracteres;
- URLs: até 2048 caracteres;
- descrições e observações: texto longo sem limite rígido inicial.

SQLite não aplica todos esses limites de forma natural, mas eles devem ser respeitados pela aplicação e, quando fizer sentido, por validações do EF Core.

## 7. estratégia de IDs

Estratégia oficial:

- Usar `Guid` como identificador lógico.
- Armazenar `Guid` como `TEXT` no SQLite.
- Gerar IDs na aplicação antes de salvar.
- Não depender de IDs inteiros sequenciais.

Motivos:

- facilita criação de dados antes da persistência;
- evita conflito em importações futuras;
- simplifica exportação e restauração;
- reduz dependência de autoincremento do SQLite.

Para tabelas de vínculo simples, como `EntityTag` e `ModelMaterial`, pode haver `Id` próprio para manter consistência e facilitar auditoria.

## 8. estratégia de datas

Campos padrão:

```txt
CreatedAtUtc
UpdatedAtUtc
ArchivedAtUtc
DeletedAtUtc
LastCheckedAtUtc
LastAccessedAtUtc
```

Regras:

- Datas técnicas devem ser salvas em UTC.
- A interface deve exibir datas no fuso local do Windows.
- `CreatedAtUtc` deve ser definido na criação.
- `UpdatedAtUtc` deve ser atualizado a cada alteração relevante.
- `ArchivedAtUtc` indica arquivamento visível ao usuário.
- `DeletedAtUtc` deve ser reservado para soft delete futuro, caso uma lixeira seja aprovada.
- Datas reais de arquivo, como criação e modificação do arquivo no Windows, devem usar campos próprios.

## 9. estratégia de slugs

Slugs serão usados para organização interna, caminhos sugeridos e leitura humana.

Regras:

- `Collection` deve ter slug único.
- `ModelItem` deve ter slug único dentro da coleção.
- `Tag` deve ter slug único global.
- `FolderTemplate` pode ter slug ou chave interna.
- Slug deve ser gerado a partir do título ou nome.
- Slug deve evitar acentos e caracteres especiais.
- Slug duplicado deve receber sufixo incremental, como `-2`, `-3`.
- Alterar slug depois de criado deve ser ação explícita, pois pode afetar pastas futuras.

Importante:

O slug no banco não deve ser a única fonte de caminho real. O caminho real deve ser guardado em campos próprios quando houver pasta vinculada.

## 10. estratégia de soft delete e arquivamento

O padrão inicial deve ser arquivamento, não exclusão real.

Arquivamento:

- usado para coleções, modelos, materiais, links e itens da fila;
- preserva histórico e relações;
- remove o item das listas principais, se a interface assim definir;
- mantém o item disponível para busca avançada ou filtros de arquivados.

Campos sugeridos:

```txt
IsArchived
ArchivedAtUtc
```

Soft delete:

- reservado para uma futura lixeira ou recuperação de exclusões;
- não deve ser usado como comportamento principal sem aprovação;
- quando usado, deve ter `IsDeleted` e `DeletedAtUtc`.

Exclusão real:

- permitida apenas para vínculos simples e dados sem risco, como remoção de uma tag de uma entidade;
- para entidades principais, deve exigir confirmação futura.

## 11. entidades principais

Entidades previstas:

- `Collection`;
- `ModelItem`;
- `GalleryImage`;
- `LinkedFile`;
- `LinkItem`;
- `FavoriteItem`;
- `Material`;
- `ModelMaterial`;
- `PrintQueueItem`;
- `ChecklistItem`;
- `ProductionHistoryEntry`;
- `Tag`;
- `EntityTag`;
- `AppSetting`;
- `PathSetting`;
- `FolderTemplate`;
- `RecentFileEntry`.

Essas entidades cobrem a base de coleções, modelos, galerias, arquivos, links, favoritos, materiais, fila, configurações, caminhos e histórico.

## 12. enums principais

### CollectionStatus

```txt
Idea
Researching
Structuring
InProduction
Paused
Finished
Archived
```

### ModelStatus

```txt
Idea
Researching
ReferencesCollected
File3dFound
File3dReviewed
ReadyToSlice
Sliced
SentToPrint
Printed
PrintFailed
Washed
Cured
Preparing
Painting
Finished
Photographed
Archived
```

### PrintQueueStatus

```txt
WaitingForSlicing
ReadyToSend
Sent
Printing
Printed
Failed
Canceled
Archived
```

### ImageType

```txt
Reference
Render
Painting
Process
FinalPhoto
Palette
Texture
Other
```

### LinkedFileType

```txt
Stl
Obj
ThreeMf
Blend
Ctb
Lychee
Chitubox
Image
Document
Text
Folder
Other
```

Observação: `ThreeMf` representa arquivos `.3mf`, pois nomes de enum em C# não devem começar com número.

### LinkCategory

```txt
Marketplace
VisualReference
Tutorial
Supplier
Material
File
Community
Research
Inspiration
Other
```

### MaterialType

```txt
Resin
Primer
Paint
Wash
Varnish
Brush
Sandpaper
Alcohol
Glove
Mask
Base
Putty
Pigment
Glue
Tool
Other
```

### PathType

```txt
MainAtelier
CollectionsRoot
Backups
Temporary
Import
Export
PrintQueueDestination
Shared3DFiles
FinishedItems
NetworkBackup
MappedDrive
Other
```

### PathStatus

```txt
NotTested
Online
Offline
Invalid
Missing
NoPermission
```

### ThemeMode

```txt
Light
Dark
System
```

### InterfaceDensity

```txt
Comfortable
Compact
```

Enums devem ser armazenados como texto no SQLite, salvo decisão técnica futura diferente.

## 13. relacionamentos

Relacionamentos principais:

- Uma `Collection` tem muitos `ModelItem`.
- Uma `Collection` pode ter muitas `GalleryImage`.
- Um `ModelItem` pode ter muitas `GalleryImage`.
- Uma `Collection` pode ter muitos `LinkedFile`.
- Um `ModelItem` pode ter muitos `LinkedFile`.
- Uma `Collection` pode ter muitos `LinkItem`.
- Um `ModelItem` pode ter muitos `LinkItem`.
- Um `ModelItem` pode ter muitos `ChecklistItem`.
- Um `ModelItem` pode ter muitos `ProductionHistoryEntry`.
- Um `ModelItem` pode ter muitos `Material` por `ModelMaterial`.
- Um `Material` pode estar em muitos `ModelItem` por `ModelMaterial`.
- Um `PrintQueueItem` deve apontar para um `ModelItem` e pode apontar para um `LinkedFile`.
- Um `FavoriteItem` pode apontar para link externo, `LinkItem` ou entidade interna.
- Uma `Tag` pode ser vinculada a várias entidades por `EntityTag`.
- `PathSetting` define caminhos usados por arquivos, fila, backup e configurações.
- `RecentFileEntry` pode apontar para `LinkedFile`, `Collection` ou `ModelItem`.

Regras importantes:

- `GalleryImage` deve pertencer a uma coleção ou a um modelo. Não deve ficar solta sem contexto, salvo se uma área global de imagens for aprovada no futuro.
- `LinkedFile` deve pertencer a uma coleção ou a um modelo, ou estar ligado a uma função específica aprovada.
- `ModelItem` deve pertencer a uma `Collection` na modelagem inicial.
- `FavoriteItem` pode usar referência polimórfica controlada pela aplicação.

## 14. índices recomendados

Índices gerais:

- `Collection.Slug` único.
- `ModelItem.CollectionId + ModelItem.Slug` único.
- `Tag.Slug` único.
- `AppSetting.Key` único.
- `PathSetting.Type + PathSetting.Name`.
- `EntityTag.EntityType + EntityTag.EntityId + EntityTag.TagId` único.
- `ModelMaterial.ModelItemId + ModelMaterial.MaterialId`.

Índices de listagem:

- `Collection.Status`.
- `Collection.UpdatedAtUtc`.
- `ModelItem.CollectionId`.
- `ModelItem.Status`.
- `ModelItem.UpdatedAtUtc`.
- `GalleryImage.CollectionId`.
- `GalleryImage.ModelItemId`.
- `LinkedFile.CollectionId`.
- `LinkedFile.ModelItemId`.
- `PrintQueueItem.Status`.
- `RecentFileEntry.LastAccessedAtUtc`.

Índices de busca:

- `Collection.Title`.
- `ModelItem.Title`.
- `Material.Name`.
- `LinkItem.Title`.
- `LinkedFile.FileName`.
- `Tag.Name`.

SQLite pode usar `LIKE` para busca simples no início. FTS5 pode ser avaliado futuramente se a busca global ficar lenta.

## 15. regras de integridade

Regras principais:

- `Collection.Title` é obrigatório.
- `Collection.Slug` é obrigatório e único.
- `ModelItem.Title` é obrigatório.
- `ModelItem.CollectionId` é obrigatório.
- `ModelItem.Slug` é obrigatório e único dentro da coleção.
- `GalleryImage.FilePath` é obrigatório.
- `LinkedFile.Path` é obrigatório.
- `LinkItem.Url` é obrigatório quando for link externo.
- `Material.Name` é obrigatório.
- `PathSetting.Path` é obrigatório.
- `AppSetting.Key` é obrigatório e único.

Regras de exclusão:

- Excluir coleção não deve apagar arquivos do sistema.
- Excluir modelo não deve apagar arquivos do sistema.
- Remover vínculo de arquivo não deve apagar o arquivo real.
- Arquivamento deve preservar relações.
- Cascata pode ser usada em vínculos simples, como `ModelMaterial` e `EntityTag`, mas deve ser evitada para entidades principais sem revisão.

Regras de dono:

- `GalleryImage` deve ter `CollectionId` ou `ModelItemId`.
- `LinkedFile` deve ter `CollectionId` ou `ModelItemId`.
- `LinkItem` pode ser global ou específico, mas essa intenção deve estar clara por campos de relação.

## 16. estratégia de migrations

Migrations devem ser criadas pelo Entity Framework Core apenas quando o projeto existir.

Regras:

- Uma migration por mudança pequena de schema.
- Nome da migration deve descrever a alteração.
- Não misturar mudanças independentes.
- Revisar migration antes de aplicar.
- Fazer backup antes de migration que altera dados existentes.
- Evitar renomear colunas sem planejar migração de dados.
- Em SQLite, lembrar que algumas alterações exigem recriação de tabela.

Processo futuro:

1. Alterar entidade ou mapeamento.
2. Gerar migration.
3. Revisar migration.
4. Executar testes de persistência.
5. Validar banco criado do zero.
6. Validar banco atualizado a partir de versão anterior, quando houver dados reais.

## 17. estratégia de backup

O backup deve proteger o banco e configurações.

Estratégia inicial:

- Backup manual do arquivo SQLite.
- Backup antes de migrations relevantes.
- Exportação do banco para pasta configurada.
- Registro simples de último backup em `AppSetting` ou entidade futura própria.
- Possibilidade futura de backup em caminho de rede.

Regras:

- Backup não deve copiar todos os arquivos pesados do atelier.
- Backup do banco deve preservar metadados, caminhos e relações.
- Restaurar banco deve exigir confirmação.
- Backup em rede deve lidar com caminho offline.
- Caminho de backup deve ser configurável em `PathSetting`.

## 18. estratégia de busca global

A busca global deve consultar inicialmente:

- `Collection.Title`;
- `Collection.Description`;
- `ModelItem.Title`;
- `ModelItem.Description`;
- `Tag.Name`;
- `LinkItem.Title`;
- `LinkItem.Url`;
- `LinkedFile.FileName`;
- `LinkedFile.Path`;
- `Material.Name`;
- `Material.Brand`;
- `ProductionHistoryEntry.Title`;
- `ProductionHistoryEntry.Description`.

Estratégia inicial:

- busca simples com `LIKE`;
- resultados agrupados por tipo;
- filtro para arquivados, se aprovado;
- ordenação por relevância simples e atualização recente.

Estratégia futura:

- avaliar SQLite FTS5 se a busca simples ficar lenta;
- criar tabela de índice de busca somente se necessário;
- manter busca simples enquanto o volume for pessoal e manejável.

## 19. estratégia para caminhos locais e de rede

Caminhos devem ser tratados como dados de configuração e metadados.

Regras:

- Guardar caminho como texto.
- Guardar tipo do caminho em `PathType`.
- Guardar último status conhecido em `PathStatus`.
- Guardar `LastTestedAtUtc`.
- Não bloquear uso local se caminho de rede estiver offline.
- Validar caminho por serviço interno, não pela entidade.
- Diferenciar caminho inválido, ausente, offline e sem permissão quando possível.

Caminhos comuns:

- pasta principal do atelier;
- pasta de coleções;
- pasta de backup;
- pasta temporária;
- pasta de importação;
- pasta de exportação;
- destino de fila de impressão;
- pasta compartilhada de arquivos 3D;
- backup em rede.

## 20. estratégia para arquivos vinculados

Arquivos vinculados representam arquivos reais do Windows.

O banco deve guardar:

- caminho;
- nome;
- extensão;
- tipo;
- tamanho;
- datas conhecidas;
- categoria;
- relação com coleção ou modelo;
- observação;
- status de existência;
- data da última verificação.

O banco não deve guardar:

- conteúdo do arquivo;
- miniatura pesada;
- binário do arquivo;
- cópia do arquivo.

Regras:

- Arquivo ausente deve continuar registrado.
- Remover vínculo não deve apagar arquivo real.
- Enviar para fila deve criar ou relacionar `PrintQueueItem`.
- Caminhos longos devem ser preservados integralmente no banco.

## 21. estratégia para galeria e imagens

Galeria deve guardar metadados e caminho da imagem.

O banco deve guardar:

- caminho da imagem;
- título;
- descrição;
- tipo de imagem;
- tags;
- relação com coleção ou modelo;
- indicação de capa por referência em coleção ou modelo;
- estado de arquivo existente ou ausente.

O banco não deve guardar:

- imagem original;
- foto final;
- render em binário;
- arquivo de textura;
- cache pesado de miniatura.

Capas:

- `Collection.CoverImageId` pode apontar para `GalleryImage`.
- `ModelItem.CoverImageId` pode apontar para `GalleryImage`.
- Se a capa estiver ausente, a interface deve exibir placeholder.

## 22. estratégia para favoritos

Favoritos devem funcionar como atalhos globais do atelier.

Tipos de favorito:

- link externo;
- `LinkItem`;
- coleção;
- modelo;
- material;
- caminho ou arquivo, se aprovado futuramente.

Estratégia:

- `FavoriteItem` guarda dados de exibição e destino.
- Para link externo, pode guardar URL.
- Para item interno, pode guardar tipo da entidade e ID.
- Para link cadastrado, pode apontar para `LinkItem`.
- A barra rápida usa campo `IsPinnedToQuickBar` e `SortOrder`.

Observação:

Como favoritos podem apontar para tipos diferentes, parte da integridade será validada pela aplicação.

## 23. estratégia para materiais

Materiais representam insumos e utensílios do atelier.

O banco deve guardar:

- nome;
- tipo;
- marca;
- cor;
- fornecedor;
- link de compra;
- quantidade opcional;
- unidade opcional;
- observação;
- vínculos com modelos.

Relação com modelos:

- usar `ModelMaterial`;
- permitir quantidade e unidade no vínculo;
- permitir observação específica do uso naquele modelo.

Materiais não devem virar controle de estoque complexo sem tarefa futura específica.

## 24. estratégia para fila de impressão

A fila organiza arquivos e modelos prontos para impressão.

O banco deve guardar:

- modelo relacionado;
- arquivo relacionado, quando houver;
- status;
- caminho do arquivo de origem;
- destino local ou de rede;
- data de envio;
- data de impressão;
- tentativas;
- observações;
- última mensagem de erro.

Regras:

- A fila não controla impressora diretamente.
- O arquivo pronto permanece no sistema de arquivos.
- Cópia para destino deve ser feita por serviço interno.
- Destino offline deve gerar status ou mensagem, não travar o app.
- Histórico pode ser registrado em `ProductionHistoryEntry`.

## 25. estratégia para configurações

Configurações devem ficar no SQLite para facilitar backup e restauração.

Entidades usadas:

- `AppSetting` para configurações simples.
- `PathSetting` para caminhos.
- `FolderTemplate` para modelo padrão de pastas.

Regras:

- Configurações visuais devem respeitar `docs/08-design-system.md`.
- Tema deve usar `ThemeMode`.
- Densidade deve usar `InterfaceDensity`.
- Caminhos devem usar `PathSetting`.
- Modelo de pastas deve ser editável sem alterar pastas reais automaticamente.
- Backup deve usar caminho configurado.

## 26. dados iniciais e seeds

Seeds podem ser usados futuramente para valores básicos.

Dados iniciais possíveis:

- configurações padrão de tema;
- densidade padrão confortável;
- modelo padrão de pastas de coleção;
- modelo padrão de pastas de modelo;
- tipos básicos de caminho;
- itens padrão de checklist para modelo;
- categorias de links, se forem tratadas como dados;
- tipos de material, se forem tratados como dados.

Regras:

- Seeds não devem criar coleções ou modelos reais do usuário.
- Seeds não devem apontar para caminhos pessoais sem configuração.
- Seeds devem ser idempotentes.
- Seeds devem poder ser recriados sem duplicar dados.

## 27. riscos e cuidados

Riscos principais:

- armazenar arquivo pesado por engano no banco;
- apagar arquivo real ao remover vínculo;
- quebrar relações ao arquivar coleção ou modelo;
- criar migrations grandes demais;
- tratar caminho de rede offline como erro crítico;
- usar cascata perigosa em entidades principais;
- perder histórico de produção;
- duplicar tags por diferença de acento ou caixa;
- depender de slug como caminho real;
- criar busca global lenta sem índices.

Cuidados:

- validar caminhos por serviço;
- manter arquivos fora do banco;
- usar backup antes de mudanças importantes;
- revisar migrations;
- preferir arquivamento;
- tratar offline como condição normal;
- garantir índices para telas principais.

## 28. critérios de validação futura

Quando a modelagem for implementada, validar:

- banco SQLite é criado com sucesso;
- migrations rodam em banco novo;
- entidades principais têm tabelas correspondentes;
- relações principais funcionam;
- índices principais foram criados;
- enums são persistidos corretamente;
- arquivos pesados não entram no banco;
- caminhos são salvos como texto;
- coleção pode ter modelos;
- modelo pode ter galeria, arquivos, links, materiais, checklist e histórico;
- fila pode apontar para modelo e arquivo;
- favoritos podem apontar para links e itens internos;
- busca simples encontra coleções, modelos, arquivos, links, tags e materiais;
- backup do banco funciona;
- caminho de rede offline não quebra consultas locais.

## 29. detalhamento das entidades

### Collection

Finalidade:

Representa uma coleção, linha, série ou conjunto criativo de miniaturas.

Campos principais:

- `Id`;
- `Title`;
- `Slug`;
- `Description`;
- `Status`;
- `CoverImageId`;
- `MainFolderPath`;
- `ColorHex`;
- `Notes`;
- `IsArchived`;
- `CreatedAtUtc`;
- `UpdatedAtUtc`;
- `ArchivedAtUtc`.

Relações:

- tem muitos `ModelItem`;
- pode ter muitas `GalleryImage`;
- pode ter muitos `LinkedFile`;
- pode ter muitos `LinkItem`;
- pode ter muitas tags por `EntityTag`;
- pode ser alvo de `FavoriteItem`.

Observações:

- `CoverImageId` deve apontar para imagem relacionada à própria coleção ou a modelo da coleção, conforme regra futura.
- `MainFolderPath` guarda a pasta real vinculada, sem mover arquivos automaticamente.
- Coleção arquivada não deve apagar modelos.

Índices sugeridos:

- único em `Slug`;
- índice em `Status`;
- índice em `UpdatedAtUtc`;
- índice em `Title`.

### ModelItem

Finalidade:

Representa uma miniatura, peça, busto, base, kit, diorama ou estudo dentro de uma coleção.

Campos principais:

- `Id`;
- `CollectionId`;
- `Title`;
- `Slug`;
- `Description`;
- `Status`;
- `CoverImageId`;
- `MainFolderPath`;
- `Scale`;
- `EstimatedSize`;
- `Notes`;
- `IsArchived`;
- `CreatedAtUtc`;
- `UpdatedAtUtc`;
- `ArchivedAtUtc`.

Relações:

- pertence a uma `Collection`;
- tem muitas `GalleryImage`;
- tem muitos `LinkedFile`;
- tem muitos `LinkItem`;
- tem muitos `ChecklistItem`;
- tem muitos `ProductionHistoryEntry`;
- tem muitos `Material` por `ModelMaterial`;
- pode ter muitos `PrintQueueItem`;
- pode ter tags por `EntityTag`;
- pode ser alvo de `FavoriteItem`.

Observações:

- Slug deve ser único dentro da coleção.
- Modelo pode ser salvo incompleto, desde que tenha título e coleção.
- Status representa a etapa de produção.

Índices sugeridos:

- único em `CollectionId + Slug`;
- índice em `CollectionId`;
- índice em `Status`;
- índice em `UpdatedAtUtc`;
- índice em `Title`.

### GalleryImage

Finalidade:

Representa uma imagem vinculada a uma coleção ou modelo, como referência, render, processo, pintura, paleta, textura ou foto final.

Campos principais:

- `Id`;
- `CollectionId`;
- `ModelItemId`;
- `Title`;
- `Description`;
- `FilePath`;
- `FileName`;
- `Extension`;
- `ImageType`;
- `Width`;
- `Height`;
- `FileExists`;
- `LastCheckedAtUtc`;
- `CreatedAtUtc`;
- `UpdatedAtUtc`.

Relações:

- pertence a uma `Collection` ou a um `ModelItem`;
- pode ser usada como capa por `Collection`;
- pode ser usada como capa por `ModelItem`;
- pode ter tags por `EntityTag`.

Observações:

- O arquivo de imagem fica fora do banco.
- `FileExists` representa o último estado conhecido.
- Deve haver regra de aplicação para impedir imagem sem dono.

Índices sugeridos:

- índice em `CollectionId`;
- índice em `ModelItemId`;
- índice em `ImageType`;
- índice em `FileName`.

### LinkedFile

Finalidade:

Representa arquivo ou pasta vinculada a coleção ou modelo.

Campos principais:

- `Id`;
- `CollectionId`;
- `ModelItemId`;
- `Path`;
- `FileName`;
- `Extension`;
- `FileType`;
- `SizeBytes`;
- `FileCreatedAtUtc`;
- `FileModifiedAtUtc`;
- `Category`;
- `Notes`;
- `FileExists`;
- `LastCheckedAtUtc`;
- `CreatedAtUtc`;
- `UpdatedAtUtc`.

Relações:

- pertence a uma `Collection` ou a um `ModelItem`;
- pode ser usado por `PrintQueueItem`;
- pode aparecer em `RecentFileEntry`;
- pode ter tags por `EntityTag`.

Observações:

- O conteúdo do arquivo nunca fica no banco.
- Pastas também podem ser representadas quando `FileType` for `Folder`.
- O vínculo pode permanecer mesmo se o arquivo estiver ausente.

Índices sugeridos:

- índice em `CollectionId`;
- índice em `ModelItemId`;
- índice em `FileType`;
- índice em `Extension`;
- índice em `FileName`;
- índice em `Path`.

### LinkItem

Finalidade:

Representa link global ou link específico de coleção/modelo.

Campos principais:

- `Id`;
- `CollectionId`;
- `ModelItemId`;
- `Title`;
- `Url`;
- `Category`;
- `Description`;
- `IsGlobal`;
- `CreatedAtUtc`;
- `UpdatedAtUtc`;
- `ArchivedAtUtc`;
- `IsArchived`.

Relações:

- pode pertencer a uma `Collection`;
- pode pertencer a um `ModelItem`;
- pode ser global quando não tiver dono específico;
- pode ser usado por `FavoriteItem`;
- pode ter tags por `EntityTag`.

Observações:

- Link global aparece na área de favoritos ou links gerais.
- Link específico aparece no contexto da coleção ou modelo.
- URL deve ser validada pela aplicação.

Índices sugeridos:

- índice em `CollectionId`;
- índice em `ModelItemId`;
- índice em `Category`;
- índice em `Title`;
- índice em `Url`.

### FavoriteItem

Finalidade:

Representa favorito global ou item fixado na barra rápida.

Campos principais:

- `Id`;
- `Title`;
- `Description`;
- `TargetType`;
- `TargetId`;
- `Url`;
- `LinkItemId`;
- `Category`;
- `IsPinnedToQuickBar`;
- `SortOrder`;
- `CreatedAtUtc`;
- `UpdatedAtUtc`;
- `ArchivedAtUtc`;
- `IsArchived`.

Relações:

- pode apontar para `LinkItem`;
- pode apontar para coleção, modelo, material ou outro item interno usando `TargetType` e `TargetId`;
- pode guardar URL externa diretamente.

Observações:

- A integridade de `TargetType + TargetId` deve ser validada pela aplicação.
- `Title` pode guardar nome de exibição mesmo quando o destino muda.
- Favorito arquivado não deve aparecer na barra rápida.

Índices sugeridos:

- índice em `IsPinnedToQuickBar`;
- índice em `SortOrder`;
- índice em `TargetType + TargetId`;
- índice em `Category`.

### Material

Finalidade:

Representa material ou utensílio usado no atelier.

Campos principais:

- `Id`;
- `Name`;
- `Type`;
- `Brand`;
- `ColorName`;
- `ColorHex`;
- `Supplier`;
- `PurchaseUrl`;
- `Quantity`;
- `Unit`;
- `Notes`;
- `IsArchived`;
- `CreatedAtUtc`;
- `UpdatedAtUtc`;
- `ArchivedAtUtc`.

Relações:

- pode estar vinculado a muitos modelos por `ModelMaterial`;
- pode ser alvo de `FavoriteItem`;
- pode ter tags por `EntityTag`.

Observações:

- Quantidade é opcional e não transforma o app em controle de estoque completo.
- `PurchaseUrl` pode futuramente virar `LinkItem`, se fizer sentido.

Índices sugeridos:

- índice em `Name`;
- índice em `Type`;
- índice em `Brand`;
- índice em `Supplier`.

### ModelMaterial

Finalidade:

Representa vínculo entre modelo e material.

Campos principais:

- `Id`;
- `ModelItemId`;
- `MaterialId`;
- `Quantity`;
- `Unit`;
- `UsageNotes`;
- `SortOrder`;
- `CreatedAtUtc`;
- `UpdatedAtUtc`.

Relações:

- pertence a um `ModelItem`;
- pertence a um `Material`.

Observações:

- Permite registrar material usado em um modelo específico.
- Pode guardar quantidade diferente da quantidade geral do material.

Índices sugeridos:

- índice único em `ModelItemId + MaterialId`, salvo se usos duplicados forem aprovados;
- índice em `MaterialId`.

### PrintQueueItem

Finalidade:

Representa item da fila de impressão.

Campos principais:

- `Id`;
- `ModelItemId`;
- `LinkedFileId`;
- `Status`;
- `SourceFilePath`;
- `DestinationPathSettingId`;
- `DestinationPathSnapshot`;
- `SentAtUtc`;
- `PrintedAtUtc`;
- `FailedAtUtc`;
- `LastAttemptAtUtc`;
- `AttemptCount`;
- `LastErrorMessage`;
- `Notes`;
- `IsArchived`;
- `CreatedAtUtc`;
- `UpdatedAtUtc`;
- `ArchivedAtUtc`.

Relações:

- pertence a um `ModelItem`;
- pode apontar para um `LinkedFile`;
- pode usar um `PathSetting` como destino;
- pode gerar `ProductionHistoryEntry`.

Observações:

- A fila não controla a impressora.
- `DestinationPathSnapshot` preserva o destino usado mesmo se a configuração mudar depois.
- Falhas devem ser registradas sem remover o item.

Índices sugeridos:

- índice em `Status`;
- índice em `ModelItemId`;
- índice em `LinkedFileId`;
- índice em `CreatedAtUtc`;
- índice em `LastAttemptAtUtc`.

### ChecklistItem

Finalidade:

Representa item do checklist de produção de um modelo.

Campos principais:

- `Id`;
- `ModelItemId`;
- `Title`;
- `Description`;
- `IsCompleted`;
- `CompletedAtUtc`;
- `SortOrder`;
- `IsDefault`;
- `CreatedAtUtc`;
- `UpdatedAtUtc`.

Relações:

- pertence a um `ModelItem`.

Observações:

- Itens padrão podem ser criados a partir de seed.
- Checklist deve ser editável sem mudar status automaticamente, salvo regra futura.

Índices sugeridos:

- índice em `ModelItemId`;
- índice em `ModelItemId + SortOrder`;
- índice em `IsCompleted`.

### ProductionHistoryEntry

Finalidade:

Registra eventos importantes da produção de um modelo.

Campos principais:

- `Id`;
- `ModelItemId`;
- `PrintQueueItemId`;
- `Title`;
- `Description`;
- `EventType`;
- `StatusFrom`;
- `StatusTo`;
- `OccurredAtUtc`;
- `CreatedAtUtc`;
- `UpdatedAtUtc`.

Relações:

- pertence a um `ModelItem`;
- pode apontar para `PrintQueueItem`.

Observações:

- Útil para acompanhar impressão, falhas, pintura, fotos e arquivamento.
- `EventType` pode começar como texto controlado pela aplicação.

Índices sugeridos:

- índice em `ModelItemId`;
- índice em `OccurredAtUtc`;
- índice em `EventType`.

### Tag

Finalidade:

Representa tag reutilizável.

Campos principais:

- `Id`;
- `Name`;
- `Slug`;
- `ColorHex`;
- `Description`;
- `CreatedAtUtc`;
- `UpdatedAtUtc`.

Relações:

- vincula-se a entidades por `EntityTag`.

Observações:

- Tag deve ser normalizada por slug para evitar duplicidade.
- Cor é opcional e deve respeitar o design system.

Índices sugeridos:

- único em `Slug`;
- índice em `Name`.

### EntityTag

Finalidade:

Representa vínculo entre uma tag e uma entidade.

Campos principais:

- `Id`;
- `TagId`;
- `EntityType`;
- `EntityId`;
- `CreatedAtUtc`.

Relações:

- pertence a uma `Tag`;
- aponta para entidade por `EntityType + EntityId`.

Observações:

- Usar quando tags precisarem atender coleções, modelos, imagens, arquivos, links e materiais.
- Integridade do alvo deve ser validada pela aplicação.

Índices sugeridos:

- único em `EntityType + EntityId + TagId`;
- índice em `TagId`;
- índice em `EntityType + EntityId`.

### AppSetting

Finalidade:

Guarda configuração simples do app.

Campos principais:

- `Id`;
- `Key`;
- `Value`;
- `ValueType`;
- `Group`;
- `Description`;
- `IsUserEditable`;
- `CreatedAtUtc`;
- `UpdatedAtUtc`.

Relações:

- não precisa ter relações diretas.

Observações:

- Usar para tema, densidade, preferências simples e flags.
- Configurações complexas devem usar entidades próprias.

Índices sugeridos:

- único em `Key`;
- índice em `Group`.

### PathSetting

Finalidade:

Representa caminho local, caminho de rede ou pasta especial configurada.

Campos principais:

- `Id`;
- `Name`;
- `Path`;
- `NormalizedPath`;
- `Type`;
- `Status`;
- `IsDefault`;
- `LastTestedAtUtc`;
- `LastErrorMessage`;
- `Notes`;
- `CreatedAtUtc`;
- `UpdatedAtUtc`.

Relações:

- pode ser usado por `PrintQueueItem`;
- pode ser usado por backup, importação, exportação e estrutura de pastas.

Observações:

- Caminho deve ser testado por serviço interno.
- `Status` é o último estado conhecido, não garantia permanente.
- Caminhos de rede offline devem ser tratados como condição normal.

Índices sugeridos:

- índice em `Type`;
- índice em `Status`;
- índice em `IsDefault`;
- índice em `NormalizedPath`.

### FolderTemplate

Finalidade:

Define modelo de pastas a criar para coleções e modelos.

Campos principais:

- `Id`;
- `ParentId`;
- `TargetEntityType`;
- `Name`;
- `Slug`;
- `RelativePath`;
- `SortOrder`;
- `IsRequired`;
- `IsEnabled`;
- `CreatedAtUtc`;
- `UpdatedAtUtc`.

Relações:

- pode ter pai por `ParentId`;
- pode ter filhos por `ParentId`.

Observações:

- Não deve alterar pastas já existentes sem confirmação futura.
- `TargetEntityType` pode ser `Collection` ou `ModelItem`.
- Estrutura hierárquica pode ser montada pela relação pai/filho.

Índices sugeridos:

- índice em `TargetEntityType`;
- índice em `ParentId`;
- índice em `SortOrder`;
- índice em `TargetEntityType + RelativePath`.

### RecentFileEntry

Finalidade:

Registra arquivo vinculado, acessado, importado ou alterado recentemente.

Campos principais:

- `Id`;
- `LinkedFileId`;
- `CollectionId`;
- `ModelItemId`;
- `FilePath`;
- `FileName`;
- `Extension`;
- `FileType`;
- `Source`;
- `FileExists`;
- `LastAccessedAtUtc`;
- `LastModifiedAtUtc`;
- `CreatedAtUtc`;
- `UpdatedAtUtc`.

Relações:

- pode apontar para `LinkedFile`;
- pode apontar para `Collection`;
- pode apontar para `ModelItem`.

Observações:

- Pode guardar snapshot do caminho mesmo se o vínculo for removido.
- Deve ser podado futuramente se crescer demais.

Índices sugeridos:

- índice em `LastAccessedAtUtc`;
- índice em `LinkedFileId`;
- índice em `CollectionId`;
- índice em `ModelItemId`;
- índice em `FileName`.

## 30. resumo da modelagem

A modelagem do Blue Atelier deve manter o banco leve e confiável.

O SQLite deve guardar o mapa inteligente do atelier: nomes, descrições, status, relações, caminhos, favoritos, materiais, fila, configurações, tags e histórico.

Os arquivos reais continuam no Windows, em pastas locais ou de rede.

A implementação futura deve seguir Entity Framework Core, migrations controladas, backup antes de mudanças relevantes e validações específicas para caminhos, arquivos ausentes e rede offline.
