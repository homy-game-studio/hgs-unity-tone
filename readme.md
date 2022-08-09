[![semantic-release](https://img.shields.io/badge/%20%20%F0%9F%93%A6%F0%9F%9A%80-semantic--release-e10079.svg)](https://github.com/semantic-release/semantic-release)

## Convenção de Package Name
A documetnação do Unity recomenda uma convensão especifica para nomes de packages.:

> Comece com `com.<company-name>`. Por exemplo, um dos pacotes oficiais do Unity é `com.unity.timeline`. 

Para mais detalhes acesse a [documentação](https://docs.unity3d.com/2020.1/Documentation/Manual/cus-naming.html).

Com isso em mente, todos os pacotes da homy para UPM devem seguir o padrão. `com.hgs.my-package-name`. Por exemplo, este template é `com.hgs.upm-template`.

Este nome deve ser especificado em `name` no **package.json**.

**ATENÇÃO** O nome do package junto e nome do repositório não podem ser alterados! Caso isso aconteça outros packages ou projetos perderão a referencia.

Além do campo `name` existe outro campo chamado `displayName` este pode ser alterado sempre que necessário, este nome aparecerá na janela do Unity Package Manager.

## Convenção de namespace
Para isolar os assets de outros scripts isolamos todos no namespace do package `HGS.<package-name>`. Por exemplo, neste package de template usamos `HGS.Template`.

## Convenção de Assembly
Cada pasta na raiz do package precisa de um AssemblyDefinition, por tanto utilizamos a convenção `HGS.<pacakge-name>.<folder-name>`. Por exemplo, neste projeto possuirmos a pasta Runtime, onde o Assembly é `HGS.Template.Runtime`.

## Branchs
Todos os packages devem possuir duas branchs reservadas.:

- `master` -> Aqui guardamos todo material do projeto.
- `upm` -> Aqui mantemos uma copia do package que se encontra na pasta `Assets/Package`.

Sempre que um merge é feito na branch `unity`, o script de CI  irá criar uma copia da subpasta `Assets/Package` automaticamente na branch `upm`. Portanto é importante que exista uma pasta chamada `Package` dentro de `Assets` para o deploy ocorra com sucesso. 

## Alterando versões de um package
Utilizamos o plugin [semantic-release](https://github.com/semantic-release/semantic-release) para facilitar o sistema de release e versionamento, portanto, sempre inicie um repositorio na versão 0.0.0, pois este será alterado automaticamente conforme o uso.

Para utilizar o semantic-relase, temos utilizar a seguinte convenção se commits.:

```
<type>(<scope>): <short summary>
  │       │             │
  │       │             └─⫸ Summary in present tense. Not capitalized. No period at the end.
  │       │
  │       └─⫸ Commit Scope: Namespace, script name, etc..
  │
  └─⫸ Commit Type: build|ci|docs|feat|fix|perf|refactor|test
```

`Type`.: 

- build: Changes that affect the build system or external dependencies (example scopes: package system)
- ci: Changes to our CI configuration files and scripts (example scopes: Circle, - BrowserStack, SauceLabs)
- docs: Documentation only changes
- feat: A new feature
- fix: A bug fix
- perf: A code change that improves performance
- refactor: A code change that neither fixes a bug nor adds a feature
- test: Adding missing tests or correcting existing tests

### Observação

Certifique-se de exlcuir todos os meta files caso você copie os arquivos deste repositório e cole em outro lugar, isso evita conflito de meta no unity.