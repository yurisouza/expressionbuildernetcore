# Contribuindo

Este repositório contém informações de como será a política do time em relação as branches e mensagens de commit, por favor leia antes de começar a utilizar nossos repositórios.

## Índice

[Como eu posso contribuir?](#como-eu-posso-contribuir)

  * [Reportando Bugs](#reportando-bugs)
  * [Fluxo Git](#fluxo-git)
  * [Pull Requests](#pull-requests)
  * [Pull Request Labels](#pull-request-labels)

[Styleguides](#styleguides)
  * [Git Commit Messages](#git-commit-messages)

## Como eu posso contribuir?

### Reportando Bugs

Esta seção mostra como reportar um bug para o Camaleão. Seguir estes _guidelines_ ajuda o time a entender o seu _report_ :pencil: e reproduzir o comportamento :computer: :computer:.

Antes de criar um bug report verifique se já não há uma [issue](https://github.com/yurisouza/expressionbuildernetcore/issues) aberta para o mesmo problema. Quando for criar um novo _report_ de bug, inclua [a maior quantidade de detalhes possíveis](#como-eu-crio-um-bom-report-de-bug) por favor.

#### Como eu crio um (Bom) report de Bug?

Explique o bug e inclua detalhes adicionais para ajudar na reprodução do problema:

* **Use um título claro e descritivo** na Issue para a identificação do problema.
* **Descreva os passos exatos que reproduzem o problema** com o máximo de detalhes possível. 
* **Se possível, forneça exemplos específicos para reproduzir os passos**. Inclua links ou arquivos que mostrem onde o problema ocorre.
* **Descreva o comportamento observado após seguir os passos** e aponte exatamente qual o problema nesse comportamento.
* **Explique qual era o comportamento esperado e o por quê.**

### Pull Requests

* Siga os styleguides de código.
* Verifique se todos os testes estão passando.
* Siga o padrão das mensagens de commit.
* No **Título** descreva sucintamente o que o pull request representa, seguido de um dos labels adequados, descritos [aqui](#pull-request-labels).
* Na **Descrição** documente a alteração de acordo com o styleguide:
 
  - `O que foi feito?`
  - `Por que foi feito?`
  - `Como foi feito?`
  
**Exemplo:**

```
Title:      [#bug] Correção de erros de validação no login

Description:  
        O que foi feito?
          
        - Corrige login.
        - Implementa validação de campos no login.

        Por que foi feito?
          
        - Quando se tentava logar com informações erradas a página estava 
        recarregando desnecessariamente.

        Como foi feito?

        - No momento do login, no estado não autorizado, foi retirado o
         URIEncoded (responsável pelo problema).
```

### Pull Request Labels

Essa seção lista as labels (etiquetas) usadas na mensagem de pull request.
Cada label representará uma seção no changelog, seguida da mensagem commit dos pull requests que descreverá a alteração.  

| Label |  Description |
| --- | --- |
| `enhancement` |  Feature nova ou melhorias |
| `bug` | Correção de bugs |
|`documentation`| Adição/alteração de documentação |
| `fire` |  Remoção de código |

## Styleguides

### Git Commit Messages

* Use o presente imperativo ("Adiciona feature" não "Adicionada feature"). Dica: pense na ação que o commit está realizando
* Limitar a primeira linha a 72 caracteres ou menos
* Considere iniciar a mensagem de commit com um [emoji](https://gitmoji.carloscuesta.me/) que se aplique.

[:arrow_left: Voltar](README.md)
