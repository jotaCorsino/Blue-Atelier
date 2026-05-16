# blue atelier — regras de desenvolvimento com codex

## 1. papel do codex

O Codex será tratado como engenheiro de implementação do projeto Blue Atelier.

Ele deve implementar tarefas de forma controlada, incremental e verificável.

## 2. regra principal

Trabalhar uma tarefa por vez.

Não iniciar a próxima tarefa sem validação do ChatGPT e aprovação do usuário.

## 3. leitura obrigatória antes de cada tarefa

Antes de qualquer implementação, o Codex deve ler:

- `docs/01-descricao-geral-do-app.md`
- `docs/02-regras-de-desenvolvimento-com-codex.md`
- `docs/03-estado-atual.md`
- documento específico da etapa atual, quando existir.

## 4. visual protegido

O Codex não tem liberdade para alterar visual aprovado.

Isso inclui:

- layout;
- cores;
- espaçamentos;
- tipografia;
- componentes;
- hierarquia visual;
- comportamento visual;
- estrutura de telas.

Só pode alterar visual quando a tarefa pedir explicitamente.

## 5. front-end e back-end

Estratégia preferencial:

1. definir/refinar visual primeiro;
2. aprovar telas visualmente;
3. implementar estrutura do app;
4. implementar persistência;
5. implementar regras de negócio;
6. integrar com arquivos locais e rede.

Codex deve priorizar implementação técnica e respeitar o visual definido.

## 6. commits

Cada tarefa concluída deve gerar um commit próprio.

Mensagem de commit sugerida:

```txt
feat: descreve a tarefa implementada
fix: descreve correção
docs: atualiza documentação
refactor: ajusta estrutura interna
test: adiciona ou corrige testes
```

## 7. push obrigatório

Ao final de cada tarefa, o Codex deve executar:

```bash
git status
git add .
git commit -m "mensagem-do-commit"
git push origin main
```

Se a branch principal não for `main`, verificar a branch correta antes do push.

## 8. estado atual

Ao final de cada tarefa, o Codex deve atualizar:

```txt
docs/03-estado-atual.md
```

Esse arquivo deve conter:

- última tarefa realizada;
- arquivos alterados;
- validações executadas;
- pendências;
- próxima tarefa sugerida;
- observações importantes.

## 9. validações mínimas

Sempre que possível, o Codex deve executar:

- build;
- testes;
- verificação de formatação;
- checagem visual quando houver tela;
- revisão de arquivos modificados.

## 10. evidência visual

Quando a tarefa envolver tela, o Codex deve fornecer alguma forma de evidência visual:

- screenshot;
- descrição do comportamento visual;
- instrução clara de como abrir a tela;
- rota ou página implementada;
- componentes alterados.

## 11. proibições

O Codex não deve:

- apagar documentação sem autorização;
- reescrever o projeto inteiro;
- mudar stack sem autorização;
- alterar visual aprovado sem autorização;
- criar features fora da tarefa;
- fazer grandes refatorações não solicitadas;
- misturar várias etapas em um único commit;
- ignorar o arquivo de estado atual;
- deixar de fazer push ao final da tarefa.

## 12. formato de resposta esperado do codex

Ao concluir uma tarefa, o Codex deve responder com:

```txt
Tarefa concluída:
Resumo:
Arquivos alterados:
Validações executadas:
Pendências:
Commit:
Push:
Próxima tarefa sugerida:
```
